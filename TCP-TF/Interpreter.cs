using NAudio.Midi;
using System.Diagnostics.Metrics;

namespace TCP_TF
{
  public class Interpreter
  {

    private readonly Dictionary<char, string> _charToMusicalNotes;
    private readonly Dictionary<char, int> _charToInstruments;
    private readonly Dictionary<string, int> _instrumentToMIDI;
    private readonly SoundReproduction _reproducer;
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

      // laço de leitura char por char
      for (int i = 0; i < text_characteres.Length; i++)
      {
        // read char by char
        char character = text_characteres[i];

        // se for null terminator OU receber sinal de parada, para a reprodução
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
    private static bool CharCorrespondsToNote(char character)
    {
      return (character >= 'A' && character <= 'G');
    }

    /// <summary>
    /// Verifica se o caractere corresponde a um instrumento.
    /// </summary>
    private static bool CharCorrespondsToInstrument(char character)
    {
      return (character == '!' || character == '\n' || character == '\r' || character == ';' || character == ',' ||
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
    /// Salva a musica em arquivo .mid
    /// </summary>
    public void SaveFile(string filename, char[] text_characteres)
    {
      const int MidiFileType = 0;
      const int TicksPerQuarterNote = 120;

      const int TrackNumber = 0;
      const int ChannelNumber = 1;
      int _currentOctave = 0;

      long absoluteTime = 0;

      var collection = new MidiEventCollection(MidiFileType, TicksPerQuarterNote);

      collection.AddEvent(new TextEvent("Note Stream", MetaEventType.TextEvent, absoluteTime), TrackNumber);
      ++absoluteTime;
      collection.AddEvent(new TempoEvent(Convert.ToInt32((60 * 1000 * 1000) / _currentBPM), absoluteTime), TrackNumber);

      int patchNumber = 0;  // instrument

      collection.AddEvent(new PatchChangeEvent(0, ChannelNumber, patchNumber), TrackNumber);

      int NoteVelocity = 60;
      const int NoteDuration = 3 * TicksPerQuarterNote / 4;
      const long SpaceBetweenNotes = TicksPerQuarterNote;

      char prev_character = '\0';

      foreach (var character in text_characteres)
      {
        if (character == '\0')
        {
          collection.PrepareForExport();
          break;
        }
        else if (CharCorrespondsToNote(character))
        {
          int note = _charToMIDI[character] + (_currentOctave * 12);
          collection.AddEvent(new NoteOnEvent(absoluteTime, ChannelNumber, note, NoteVelocity, NoteDuration), TrackNumber);
          collection.AddEvent(new NoteEvent(absoluteTime + NoteDuration, ChannelNumber, MidiCommandCode.NoteOff, note, 0), TrackNumber);
          absoluteTime += SpaceBetweenNotes;
        }
        else if (character == ' ')
        {
          if (NoteVelocity < 120)
          {
            NoteVelocity += 30;
          }
          else
          {
            NoteVelocity = 60;
          }
        }
        else if (CharCorrespondsToInstrument(character))
        {
          _currentInstrument = _charToInstruments[character];
          collection.AddEvent(new PatchChangeEvent(absoluteTime, ChannelNumber, _currentInstrument), TrackNumber);
        }
        else if (char.IsDigit(character))
        {
          collection.AddEvent(new PatchChangeEvent(absoluteTime, ChannelNumber, _currentInstrument + (int)char.GetNumericValue(character)), TrackNumber);
        }
        else if (character == '?' || character == '.')
        {
          if (_currentOctave < 3)
          {
            _currentOctave++;
          }
          else
          {
            _currentOctave = 0;
          }
        }
        else
        { 
          if (CharCorrespondsToNote(prev_character))
          {
            int note = _charToMIDI[character] + (_currentOctave * 12);
            collection.AddEvent(new NoteOnEvent(absoluteTime, ChannelNumber, note, NoteVelocity, NoteDuration), TrackNumber);
            collection.AddEvent(new NoteEvent(absoluteTime + NoteDuration, ChannelNumber, MidiCommandCode.NoteOff, note, 0), TrackNumber);
            absoluteTime += SpaceBetweenNotes;
          }
        }

        prev_character = character;
      }

      MidiFile.Export(filename, collection);
    }

    private Dictionary<char, int> _charToMIDI = new Dictionary<char, int>()
    {
      {'C', 60},
      {'D', 62},
      {'E', 64},
      {'F', 65},
      {'G', 67},
      {'A', 69},
      {'B', 71}
    };

    /// <summary>
    /// Inicializa o dicionário que mapeia cada caractere para uma nota.
    /// </summary>
    private static Dictionary<char, string> InicializeMusicalNotesDict()
    {
      Dictionary<char, string> charToMusicalNotes = new()
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
    private static Dictionary<char, int> InicializeInstrumentsDict()
    {
      Dictionary<char, int> charToInstruments = new()
      {
        {'!', 114},
        {'O', 7},
        {'o', 7},
        {'I', 7},
        {'i', 7},
        {'U', 7},
        {'u', 7},
        {'\r', 15},
        {'\n', 15},
        {';', 76},
        {',', 20}
      };
      return charToInstruments;
    }

    /// <summary>
    /// Inicializa o dicionário que mapeia cada instrumento para seu valor MIDI.
    /// </summary>
    private static Dictionary<string, int> InicializeNameToMIDIDict()
    {
      Dictionary<string, int> instrumentToMIDI = new()
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

