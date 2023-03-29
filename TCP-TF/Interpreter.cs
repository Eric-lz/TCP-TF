namespace TCP_TF
{
  public class Interpreter
  {
    // Constantes
    const int NOTES_IN_OCTAVE = 12;
    const int MAX_OCTAVE = 3;
    const int DEFAULT_VOLUME = 60;
    const int DEFAULT_OCTAVE = 0;

    /// <summary>
    /// Construtor do interpretador.
    /// </summary>
    public Interpreter() { }

    /// <summary>
    /// Converte uma string (texto livre) para uma lista de comandos MIDI
    /// </summary>
    /// <param name="text">String de entrada (texto livre)</param>
    /// <param name="bpm">BPM da musica</param>
    /// <param name="instrumentName">Instrumento inicial</param>
    /// <returns>List of KeyValuePairs (comando, valor)</returns>
    public static List<KeyValuePair<string, int>> textToMidiCommands(string text, int bpm, string instrumentName)
    {
      // array de caracteres vindo do Parser
      char[] characters = Parser.Parse(text);

      int octave = DEFAULT_OCTAVE;
      int volume = DEFAULT_VOLUME;
      int instrument = Dictionaries.instrumentToMIDI[instrumentName];

      // lista de comandos
      List<KeyValuePair<string, int>> midiCommands = new();
      char prev_character = '\0';

      // inicializa lista com o instrumento e o BPM
      midiCommands.Add(new KeyValuePair<string, int>("Instrument", instrument));
      midiCommands.Add(new KeyValuePair<string, int>("Volume", volume));
      midiCommands.Add(new KeyValuePair<string, int>("BPM", bpm));

      foreach (var character in characters)
      {
        // null terminator, chegou no fim do texto
        if (character == '\0')
        {
          midiCommands.Add(new KeyValuePair<string, int>("Stop", 0));
          break;
        }

        // char corresponde a nota
        else if (CharCorrespondsToNote(character))
        {
          int note = Dictionaries.charToMIDINote[character] + (octave * NOTES_IN_OCTAVE);
          midiCommands.Add(new KeyValuePair<string, int>("Note", note));
        }

        // char corresponde a aumentar volume
        else if (character == ' ')
        {
          if (volume == 60) volume = 120;
          else volume = 60;
          midiCommands.Add(new KeyValuePair<string, int>("Volume", volume));
        }

        // char corresponde a alterar instrumento
        else if (CharCorrespondsToInstrument(character))
        {
          instrument = Dictionaries.charToMIDIInstrument[character];
          midiCommands.Add(new KeyValuePair<string, int>("Instrument", instrument));
        }

        // char corresponde a alterar instrumento (soma do atual + digito)
        else if (char.IsDigit(character))
        {
          instrument += (int)char.GetNumericValue(character);
          midiCommands.Add(new KeyValuePair<string, int>("Instrument", instrument));
        }

        // char corresponde a aumentar oitava
        else if (character == '?' || character == '.')
        {
          if (octave < MAX_OCTAVE-1) octave++;
          else octave = DEFAULT_OCTAVE;
        }

        // char anterior era nota
        else if (CharCorrespondsToNote(prev_character))
        {
          int note = Dictionaries.charToMIDINote[prev_character] + (octave * NOTES_IN_OCTAVE);
          midiCommands.Add(new KeyValuePair<string, int>("Note", note));
        }

        // char anterior não era nota, faz uma pausa (nota silenciosa)
        else
        {
          midiCommands.Add(new KeyValuePair<string, int>("Volume", 0));
          midiCommands.Add(new KeyValuePair<string, int>("Note", 0));
          midiCommands.Add(new KeyValuePair<string, int>("Volume", volume));
        }

        prev_character = character;
      }

      return midiCommands;
    }

    /// <summary>
    /// Verifica se um caractere corresponde a uma nota musical (C, D, E, F, G, A, B)
    /// </summary>
    /// <param name="character">Character to be tested</param>
    /// <returns>True if character is a note, false otherwise</returns>
    private static bool CharCorrespondsToNote(char character)
    {
      return (character >= 'A' && character <= 'G');
    }

    /// <summary>
    /// Verifica se um caractere corresponde a um instrumento no mapeamento
    /// (caractere está presente no dictionary <see cref="Dictionaries.charToMIDIInstrument"/>
    /// </summary>
    /// <param name="character">Character to be tested</param>
    /// <returns>True if character is mapped to an instrument, false otherwise</returns>
    private static bool CharCorrespondsToInstrument(char character)
    {
      return Dictionaries.charToMIDIInstrument.TryGetValue(character, out _);
    }

  }
}

