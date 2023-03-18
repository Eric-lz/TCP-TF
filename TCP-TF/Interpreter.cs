using System.Diagnostics.Metrics;

namespace TCP_TF
{
    public class Interpreter
    {

        private readonly Dictionary<char, string> _charToMusicalNotes;
        private readonly Dictionary<char, int> _charToInstruments;
        private SoundReproduction _reproducer;
        private float _currentBPM;
        private int _currentInstrument;

        /// <summary>
        /// Construtor do interpretador.
        /// </summary>
        public Interpreter(SoundReproduction reproducer)
        {
            _charToMusicalNotes = InicializeMusicalNotesDict();
            _charToInstruments = InicializeInstrumentsDict();
            _reproducer = reproducer;
        }

        /// <summary>
        /// Recebe uma cadeia de caracteres e gera sons de acordo.
        /// </summary>
        public void Interpret(char[] text_characteres)
        {
            for (int i = 0; i < text_characteres.Length; i++)
            {
                char character = text_characteres[i];
                if (CharCorrespondsToNote(character))
                {
                    _reproducer.PlayNote(_charToMusicalNotes[character]);
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
        public void SetInstrument(int input)
        {
          int instrument;

          switch(input){
            case 1:
              instrument = 24;
            break;

            case 2:
              instrument = 64;
            break;

            case 3:
              instrument = 79;
            break;

            case 4:
              instrument = 90;
            break;

            default:
              instrument = 0;
            break;
          }

          _currentInstrument = instrument;
          _reproducer.SetInstrument(instrument);
        }
  }
}

