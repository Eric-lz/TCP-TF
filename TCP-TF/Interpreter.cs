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

    // MIDI output object
    private readonly MidiOut midiOut;

    // Constantes
    const int NOTES_IN_OCTAVE = 12;
    const int MAX_OCTAVE = 3;
    const int DEFAULT_VOLUME = 60;
    const int DEFAULT_OCTAVE = 0;
    const int DEFAULT_INSTRUMENT = 0;
    const int MIDI_FILE_TYPE = 0;
    const int TRACK_NUMBER = 0;
    const int CHANNEL_NUMBER = 1;

    // Flag que indica se reprodutor está executando
    private bool isRunning;

    // Notas
    private int instrument;
    private int bpm;
    private int octave;
    private int volume;

    // getter e setter do BPM e do instrumento
    public int BPM
    {
      get => bpm;
      set => bpm = value;
    }
    public string Instrument
    {
      set => instrument = _instrumentToMIDI[value];
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

      // MIDI output
      midiOut = new MidiOut(0);

      // notas
      octave = DEFAULT_OCTAVE;
      volume = DEFAULT_VOLUME;
      instrument = DEFAULT_INSTRUMENT;
    }

    /// <summary>
    /// Recebe um texto, converte para musica e inicia a reprodução
    /// </summary>
    public void Play(string text)
    {
      // inicia reprodução apenas se não estiver reproduzindo
      if (!isRunning)
      {
        var commands = Parse(text);
        isRunning = true;
        PlayCommands(commands);
      }
    }

    /// <summary>
    /// Para a reprodução
    /// </summary>
    public void Stop()
    {
      // flag de parada
      isRunning = false;

      // envia sinal de parada para todas as notas possíveis individualmente
      for (int i = 0; i < 127; i++)
      {
        midiOut.Send(MidiMessage.StopNote(i, 0, 1).RawData);
      }

      // retorna volume e oitava para valores padrões
      volume = DEFAULT_VOLUME;
      octave = DEFAULT_OCTAVE;
    }

    /// <summary>
    /// Recebe um texto, converte para musica e salva em arquivo MIDI
    /// </summary>
    public void SaveFile(string filename, string text)
    {
      var commands = Parse(text);
      WriteFile(filename, commands);
    }

    /// <summary>
    /// Recebe o texto de entrada e converte em comandos para o reprodutor.
    /// </summary>
    private List<KeyValuePair<string, int>> Parse(string text)
    {
      // adiciona null terminator ao fim do texto (sinal de parada)
      text += '\0';
      text.ToCharArray();

      // lista de comandos
      List<KeyValuePair<string, int>> commands = new();
      char prev_character = '\0';

      // inicializa lista com o primeiro instrumento
      commands.Add(new KeyValuePair<string, int>("Instrument", instrument));

      foreach (var character in text)
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
          int note = _charToMIDI[character] + (octave * NOTES_IN_OCTAVE);
          commands.Add(new KeyValuePair<string, int>("Note", note));
        }

        // char corresponde a aumentar volume
        else if (character == ' ')
        {
          if (volume < 120) volume += 30;
          else volume = 60;
          commands.Add(new KeyValuePair<string, int>("Volume", volume));
        }

        // char corresponde a alterar instrumento
        else if (CharCorrespondsToInstrument(character))
        {
          instrument = _charToInstruments[character];
          commands.Add(new KeyValuePair<string, int>("Instrument", instrument));
        }

        // char corresponde a alterar instrumento (soma do atual + digito)
        else if (char.IsDigit(character))
        {
          instrument += (int)char.GetNumericValue(character);
          commands.Add(new KeyValuePair<string, int>("Instrument", instrument));
        }

        // char corresponde a aumentar oitava
        else if (character == '?' || character == '.')
        {
          if (octave < MAX_OCTAVE) octave++;
          else octave = 0;
        }

        // char anterior era nota
        else if (CharCorrespondsToNote(prev_character))
        {
          int note = _charToMIDI[character] + (octave * NOTES_IN_OCTAVE);
          commands.Add(new KeyValuePair<string, int>("Note", note));
        }

        prev_character = character;
      }

      return commands;
    }

    /// <summary>
    /// Recebe uma lista de comandos e salva como musica em arquivo formato MIDI.
    /// </summary>
    private void WriteFile(string filename, List<KeyValuePair<string, int>> commands)
    {
      // tempo de duração da nota
      int NoteDuration = 3 * bpm / 4;

      // volume a ser tocado
      int w_volume = DEFAULT_VOLUME;

      // tempo
      long absoluteTime = 0;

      // cria uma collection de eventos MIDI
      var collection = new MidiEventCollection(MIDI_FILE_TYPE, bpm);

      // inicializa collection
      collection.AddEvent(new TextEvent("Note Stream", MetaEventType.TextEvent, absoluteTime), TRACK_NUMBER);
      absoluteTime++;
      collection.AddEvent(new TempoEvent(Convert.ToInt32((60 * 1000 * 1000) / bpm), absoluteTime), TRACK_NUMBER);
      absoluteTime++;

      // preenche collection
      foreach (KeyValuePair<string, int> command in commands)
      {
        switch (command.Key)
        {
          case "Note":
            collection.AddEvent(new NoteOnEvent(absoluteTime, CHANNEL_NUMBER, command.Value, w_volume, NoteDuration), TRACK_NUMBER);
            collection.AddEvent(new NoteEvent(absoluteTime + NoteDuration, CHANNEL_NUMBER, MidiCommandCode.NoteOff, command.Value, 0), TRACK_NUMBER);
            absoluteTime += bpm;
            break;

          case "Instrument":
            collection.AddEvent(new PatchChangeEvent(absoluteTime, CHANNEL_NUMBER, command.Value), TRACK_NUMBER);
            break;

          case "Volume":
            w_volume = command.Value;
            break;

          case "Stop":
            collection.PrepareForExport();
            break;
        }
      }

      // exporta arquivo .mid
      MidiFile.Export(filename, collection);
    }

    /// <summary>
    /// Recebe uma lista de comandos e reproduz.
    /// </summary>
    private async void PlayCommands(List<KeyValuePair<string, int>> commands)
    {
      int w_volume = DEFAULT_VOLUME;
      int w_instrument = instrument;

      float sleepTime = (1 / (float)bpm) * 60 * 1000;

      foreach (KeyValuePair<string, int> command in commands)
      {
        if (isRunning)
        {
          switch (command.Key)
          {
            case "Note":
              PlayNote(command.Value, w_volume, w_instrument);
              await Task.Delay(Convert.ToInt32(Math.Round(sleepTime)));
              break;

            case "Instrument":
              w_instrument = command.Value;
              break;

            case "Volume":
              w_volume = command.Value;
              break;

            case "Stop":
              Stop();
              break;
          }
        }
      }
    }

    /// <summary>
    /// Toca a nota correspondente.
    /// </summary>
    private async void PlayNote(int note, int volume, int instrument)
    {
      // tempo de duração da nota
      int NoteDuration = 3 * bpm / 4;

      // calcula tempo de espera baseado no BPM selecionado
      float sleepTime = (1 / (float)bpm) * 60 * 1000;
      sleepTime = sleepTime - NoteDuration;

      // set instrument
      midiOut.Send(new PatchChangeEvent(0, 1, instrument).GetAsShortMessage());

      // toca a nota, espera o delay, para a nota
      midiOut.Send(MidiMessage.StartNote(note, volume, 1).RawData);
      await Task.Delay(Convert.ToInt32(Math.Round(sleepTime)));
      midiOut.Send(MidiMessage.StopNote(note, 0, 1).RawData);
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
        {"Polysynth", 90 },
        {"Synth Drum", 118}
      };
      return instrumentToMIDI;
    }
  }
}

