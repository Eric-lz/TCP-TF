using System.Diagnostics.Metrics;

namespace TCP_TF
{
  public class Interpreter
  {

    private readonly Dictionary<char, string> _charToMusicalNotes;
    private readonly Dictionary<char, int> _charToInstruments;
    private readonly Dictionary<string, int> _instrumentToMIDI;
    private SoundReproduction _reproducer;
    private float _currentBPM;
    private int _currentInstrument;
    private bool isRunning;
    private bool stopSignal;

    /// <summary>
    /// Construtor do interpretador.
    /// </summary>
    public Interpreter(SoundReproduction reproducer)
    {
      _charToMusicalNotes = InicializeMusicalNotesDict();
      _charToInstruments = InicializeInstrumentsDict();
      _instrumentToMIDI = InicializeNameToMIDIDict();
      _reproducer = reproducer;
    }

    /// <summary>
    /// Recebe uma cadeia de caracteres e gera sons de acordo.
    /// </summary>
    public async void Interpret(char[] text_characteres)
    {
      // flag que indica se está reproduzindo 
      isRunning = true;

      for (int i = 0; i < text_characteres.Length; i++)
      {
        // read char by char
        char character = text_characteres[i];

        if(character == '\0' || stopSignal == true)
        {
          _reproducer.StopPlayback();
          isRunning = false;
          stopSignal = false;
          break;
        }

        if (CharCorrespondsToNote(character))
        {
          float sleepTime = (1 / _currentBPM) * 60 * 1000;
          _reproducer.PlayNote(_charToMusicalNotes[character]);
          await Task.Delay(Convert.ToInt32(Math.Round(sleepTime)));
        }
        else if (character == ' ')
        {
          _reproducer.SetVolume(_reproducer.GetVolume() + 30);
        }
        else if (CharCorrespondsToInstrument(character))
        {
          _reproducer.SetInstrument(_charToInstruments[character]);
        }
        else if (char.IsDigit(character))
        {
          _reproducer.SetInstrument(_reproducer.GetInstrument() + (int)char.GetNumericValue(character));
        }
        else if (character == '?' || character == '.')
        {
          _reproducer.IncreaseOneOctave();
        }
        else if (i > 0)
        {
          char prev_character = text_characteres[i - 1];
          if (CharCorrespondsToNote(prev_character))
          {
            _reproducer.PlayNote(_charToMusicalNotes[prev_character]);
          }
        }
      }
    }

    /// <summary>
    /// Verifica se o caractere corresponde a uma nota.
    /// </summary>
    private bool CharCorrespondsToNote(char character)
    {
      return (character >= 'A' && character <= 'G');
    }

    /// <summary>
    /// Verifica se o caractere corresponde a um instrumento.
    /// </summary>
    private bool CharCorrespondsToInstrument(char character)
    {
      return (character == '!' || character == '\n' || character == ';' || character == ',' ||
      char.ToLower(character) == 'i' || char.ToLower(character) == 'o' || char.ToLower(character) == 'u');
    }

    /// <summary>
    /// Setter do BPM.
    /// </summary>
    public void SetBPM(int bpm)
    {
      _currentBPM = bpm;
      _reproducer.SetBPM(bpm);
    }

    /// <summary>
    /// Setter do Instrumento.
    /// </summary>
    public void SetInstrument(string input)
    {
      _currentInstrument = _instrumentToMIDI[input];
      _reproducer.SetInstrument(_currentInstrument);
    }
        
    /// <summary>
    /// Para a reprodução.
    /// </summary> 
    public void Stop()
    {
      // envia sinal de parada para o reproducer
      _reproducer.StopPlayback();

      // se interpretador estiver rodando, envia sinal de parada
      if(isRunning)
      {
        stopSignal = true;
      }
    }

    /// <summary>
    /// Inicializa o dicionário que mapeia cada caractere para uma nota.
    /// </summary>
    private Dictionary<char, string> InicializeMusicalNotesDict()
    {
      Dictionary<char, string> charToMusicalNotes = new Dictionary<char, string>
      {
        {'A', "Lá"},
        {'B', "Si"},
        {'C', "Dó"},
        {'D', "Ré"},
        {'E', "Mi"},
        {'F', "Fá"},
        {'G', "Sol"}
      };
      return charToMusicalNotes;
    }

    /// <summary>
    /// Inicializa o dicionário que mapeia cada caractere para um instrumento.
    /// </summary>
    private Dictionary<char, int> InicializeInstrumentsDict()
    {
      Dictionary<char, int> charToInstruments = new Dictionary<char, int>
      {
        {'!', 114},
        {'O', 7},
        {'o', 7},
        {'I', 7},
        {'i', 7},
        {'U', 7},
        {'u', 7},
        {'\n', 15},
        {';', 76},
        {',', 20}
      };
      return charToInstruments;
    }

    /// <summary>
    /// Inicializa o dicionário que mapeia cada instrumento para seu valor MIDI.
    /// </summary>
    private Dictionary<string, int> InicializeNameToMIDIDict()
    {
      Dictionary<string, int> instrumentToMIDI = new Dictionary<string, int>
      {
        {"Piano", 0},
        {"Tubular Bell", 14},
        {"Accordion", 21},
        {"Acoustic Guitar", 24},
        {"Distortion Guitar", 30},
        {"Slap Bass", 36},
        {"Synth Bass", 38},
        {"Ocarina", 79},
        {"Polysynth", 90 },
        {"Synth Drum", 118}
      };
      return instrumentToMIDI;
    }
  }
}

