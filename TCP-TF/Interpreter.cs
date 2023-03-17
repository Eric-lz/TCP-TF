namespace TCP_TF
{
    public class Interpreter
    {

        private readonly Dictionary<char, string> _charToMusicalNotes;
        private readonly Dictionary<char, int> _charToInstruments;

        /// <summary>
        /// Construtor do interpretador.
        /// </summary>
        public Interpreter()
        {
            _charToMusicalNotes = InicializeMusicalNotesDict();
            _charToInstruments = InicializeInstrumentsDict();
        }

        /// <summary>
        /// Recebe uma cadeia de caracteres e gera sons de acordo.
        /// </summary>
        public void Interpret(char[] text_characteres)
        {
            Sound reproducer = new Sound();
            for (int i = 0; i < text_characteres.Length; i++)
            {
                char character = text_characteres[i];
                if (CharCorrespondsToNote(character))
                {
                    reproducer.PlayNote(_charToMusicalNotes[character]);
                }
                else if (character == ' ')
                {
                    reproducer.DoubleVolume();
                }
                else if (CharCorrespondsToInstrument(character))
                {
                    reproducer.SetInstrument(_charToInstruments[character]);
                }
                else if (char.IsDigit(character))
                {
                    reproducer.SetInstrument(reproducer.GetInstrument() + (int)char.GetNumericValue(character));
                }
                else if (character == '!' || character == '.')
                {
                    reproducer.IncreaseOneOctave();
                }
                else if (i > 0)
                {
                    char prev_character = text_characteres[i - 1];
                    if (CharCorrespondsToNote(prev_character))
                    {
                        reproducer.PlayNote(_charToMusicalNotes[prev_character]);
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
    }
}

