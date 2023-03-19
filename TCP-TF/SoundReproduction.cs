using Microsoft.VisualBasic.ApplicationServices;
using NAudio.Midi;
using NAudio.SoundFont;

namespace TCP_TF
{
  public class SoundReproduction
  {
    // internal data
    private readonly Dictionary<string, int> _noteToMIDI;
    private int _currentInstrument;
    private int _currentVolume;
    private int _currentOctave;
    private float _currentBPM;

    // defaults
    private const int DEFAULT_INSTRUMENT = 0;
    private const int DEFAULT_VOLUME = 60;
    private const int DEFAULT_OCTAVE = 0;
    private const int DEFAULT_BPM = 120;

    // max values
    private const int MAX_VOLUME = 120;
    private const int MAX_OCTAVE = 4;

    // MIDI output object
    private readonly MidiOut midiOut;

    public SoundReproduction()
    {
      _currentInstrument = DEFAULT_INSTRUMENT;
      _currentVolume = DEFAULT_VOLUME;
      _currentOctave = DEFAULT_OCTAVE;

      _noteToMIDI = InicializeMIDINoteDict();
      midiOut = new MidiOut(0);
    }

    /// <summary>
    /// Setter do BPM.
    /// </summary>
    public void SetBPM(int bpm)
    {
      _currentBPM = bpm;
    }

    /// <summary>
    /// Setter do instrumento.
    /// </summary>
    public void SetInstrument(int instrument)
    {
      _currentInstrument = instrument;
      midiOut.Send(new PatchChangeEvent(0, 1, instrument).GetAsShortMessage());
    }

    /// <summary>
    /// Getter do instrumento.
    /// </summary>
    public int GetInstrument()
    {
      return _currentInstrument;
    }

    /// <summary>
    /// Setter do volume. Se o novo volume for menor que 0 ou maior que o máximo, seta o volume com valor default.
    /// </summary>
    public void SetVolume(int volume)
    {
      if (volume >= 0 && volume <= MAX_VOLUME)
      {
        _currentVolume = volume;
      }
      else
      {
        _currentVolume = DEFAULT_VOLUME;
      }
    }

    /// <summary>
    /// Getter do volume.
    /// </summary>
    public int GetVolume()
    {
      return _currentVolume;
    }

    /// <summary>
    /// Toca a nota correspondente.
    /// </summary>
    public async void PlayNote(string note)
    {
      // calculo do tempo de espera baseado no BPM selecionado
      float sleepTime = (1 / _currentBPM) * 60 * 1000;

      // toca a nota, espera o delay, para a nota
      midiOut.Send(MidiMessage.StartNote(_noteToMIDI[note]+(_currentOctave*12), _currentVolume, 1).RawData);
      await Task.Delay(Convert.ToInt32(Math.Round(sleepTime)) - 20);  // subtrai 20 ms para garantir que próxima nota será tocada
      midiOut.Send(MidiMessage.StopNote(_noteToMIDI[note]+(_currentOctave*12), 0, 1).RawData);
    }


    /// <summary>
    /// Para a reprodução
    /// </summary>
    public void StopPlayback()
    {
      // envia sinal de parada para todas as notas possíveis individualmente
      for(int i = _noteToMIDI["Dó"]; i < _noteToMIDI["Dó"] + (MAX_OCTAVE-1)*12; i++)
      {
        midiOut.Send(MidiMessage.StopNote(i, 0, 1).RawData);
      }
      
      // retorna volume e oitava para valores padrões
      _currentVolume = DEFAULT_VOLUME;
      _currentOctave = DEFAULT_OCTAVE;
    }


    /// <summary>
    /// Aumenta uma oitava. Se não puder aumentar, volta à oitava default.
    /// </summary>
    public void IncreaseOneOctave()
    {
      if (_currentOctave < MAX_OCTAVE-1)
      {
        _currentOctave++;
      }
      else
      {
        _currentOctave = DEFAULT_OCTAVE;
      }
    }

    /// <summary>
    /// Inicializa o dicionário que mapeia cada nota para seu valor MIDI.
    /// </summary>
    private Dictionary<string, int> InicializeMIDINoteDict()
    {
      Dictionary<string, int> noteToMIDI = new Dictionary<string, int>
      {
        {"Si", 71},
        {"Dó", 60},
        {"Lá", 69},
        {"Ré", 62},
        {"Mi", 64},
        {"Fá", 65},
        {"Sol", 67}
      };
      return noteToMIDI;
    }
  }
}

