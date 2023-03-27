using NAudio.Midi;
using System.Diagnostics.Metrics;

namespace TCP_TF
{
  public class Interpreter
  {
    // Dictionaries
    private readonly Dictionary<char, int> _charToInstruments;
    private readonly Dictionary<char, int> _charToMIDI;
    private readonly Dictionary<string, int> _instrumentToMIDI;

    // Parser
    private readonly Parser _parser;

    // Player
    private readonly SoundReproduction _player;

    // Constantes
    const int NOTES_IN_OCTAVE = 12;
    const int MAX_OCTAVE = 3;
    const int DEFAULT_VOLUME = 60;
    const int DEFAULT_OCTAVE = 0;
    const int DEFAULT_INSTRUMENT = 0;

    // Notas
    private int _instrument;
    private int _bpm;
    private int _octave;
    private int _volume;

    // getter e setter do BPM e do instrumento
    public int BPM
    {
      get => _bpm;
      set => _bpm = value;
    }
    public string Instrument
    {
      set => _instrument = _instrumentToMIDI[value];
    }

    /// <summary>
    /// Construtor do interpretador.
    /// </summary>
    public Interpreter()
    {
      // dictionaries
      _charToInstruments = InitCharToInstrumentDict();
      _charToMIDI = InitCharToMidiDict();
      _instrumentToMIDI = InitInstrumentToMidiDict();

      // Parser
      _parser = new Parser();

      // Player
      _player = new SoundReproduction();

      // notas
      _octave = DEFAULT_OCTAVE;
      _volume = DEFAULT_VOLUME;
      _instrument = DEFAULT_INSTRUMENT;
    }

    /// <summary>
    /// Recebe um texto, converte para musica e inicia a reprodução
    /// </summary>
    public void Play(string text)
    {
      // inicia reprodução
      var commands = Interpret(text);
      _player.PlayCommands(commands);
    }

    public void Stop()
    {
      _player.Stop();

      // retorna volume e oitava para valores padrões
      _volume = DEFAULT_VOLUME;
      _octave = DEFAULT_OCTAVE;
    }

    /// <summary>
    /// Recebe um texto, converte para musica e salva em arquivo MIDI
    /// </summary>
    public void SaveFile(string filename, string text)
    {
      var commands = Interpret(text);
      _player.WriteFile(filename, commands);
    }

    /// <summary>
    /// Recebe o texto de entrada e converte em comandos para o reprodutor.
    /// </summary>
    private List<KeyValuePair<string, int>> Interpret(string text)
    {
      char[] characters = _parser.Parse(text);

      // lista de comandos
      List<KeyValuePair<string, int>> commands = new();
      char prev_character = '\0';

      // inicializa lista com o instrumento e o BPM
      commands.Add(new KeyValuePair<string, int>("Instrument", _instrument));
      commands.Add(new KeyValuePair<string, int>("BPM", _bpm));

      foreach (var character in characters)
      {
        // null terminator, chegou no fim do texto
        if (character == '\0')
        {
          commands.Add(new KeyValuePair<string, int>("Stop", 0));
          break;
        }

        // char corresponde a nota
        else if (CharCorrespondsToNote(character))
        {
          int note = _charToMIDI[character] + (_octave * NOTES_IN_OCTAVE);
          commands.Add(new KeyValuePair<string, int>("Note", note));
        }

        // char corresponde a aumentar volume
        else if (character == ' ')
        {
          if (_volume < 120) _volume += 30;
          else _volume = 60;
          commands.Add(new KeyValuePair<string, int>("Volume", _volume));
        }

        // char corresponde a alterar instrumento
        else if (CharCorrespondsToInstrument(character))
        {
          _instrument = _charToInstruments[character];
          commands.Add(new KeyValuePair<string, int>("Instrument", _instrument));
        }

        // char corresponde a alterar instrumento (soma do atual + digito)
        else if (char.IsDigit(character))
        {
          _instrument += (int)char.GetNumericValue(character);
          commands.Add(new KeyValuePair<string, int>("Instrument", _instrument));
        }

        // char corresponde a aumentar oitava
        else if (character == '?' || character == '.')
        {
          if (_octave < MAX_OCTAVE) _octave++;
          else _octave = 0;
        }

        // char anterior era nota
        else if (CharCorrespondsToNote(prev_character))
        {
          int note = _charToMIDI[character] + (_octave * NOTES_IN_OCTAVE);
          commands.Add(new KeyValuePair<string, int>("Note", note));
        }

        prev_character = character;
      }

      return commands;
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


    private static Dictionary<char, int> InitCharToMidiDict()
    {
      Dictionary<char, int> charToMIDI = new()
      {
        {'C', 60},
        {'D', 62},
        {'E', 64},
        {'F', 65},
        {'G', 67},
        {'A', 69},
        {'B', 71}
      };
      return charToMIDI;
    }

    /// <summary>
    /// Inicializa o dicionário que mapeia cada caractere para um instrumento.
    /// </summary>
    private static Dictionary<char, int> InitCharToInstrumentDict()
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
    private static Dictionary<string, int> InitInstrumentToMidiDict()
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
        {"Polysynth", 90},
        {"Synth Drum", 118}
      };
      return instrumentToMIDI;
    }
  }
}

