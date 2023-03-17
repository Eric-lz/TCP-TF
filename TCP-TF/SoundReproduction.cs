using Microsoft.VisualBasic.ApplicationServices;

namespace TCP_TF
{
    public class SoundReproduction
    {
        private int _currentInstrument;
        private int _currentVolume;
        private string _currentOctave;

        const int DEFAULT_INSTRUMENT = 1;
        const int DEFAULT_VOLUME = 50;
        const string DEFAULT_OCTAVE = "Dó";

        const int MAX_VOLUME = 100;


        public SoundReproduction()
        {
            _currentInstrument = DEFAULT_INSTRUMENT;
            _currentVolume = DEFAULT_VOLUME;
            _currentOctave = DEFAULT_OCTAVE;
        }

        /// <summary>
        /// Setter do instrumento.
        /// </summary>
        public void SetInstrument(int instrument)
        {
            _currentInstrument = instrument;
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
        public void PlayNote(string note)
        {
            switch (note)
            {
                case ("Lá"):
                    
                break;
                case ("Si"):
                    
                break;
                case ("Dó"):
                    
                break;
                case ("Ré"):
                    
                break;
                case ("Mi"):
                    
                break;
                case ("Fá"):
                    
                break;
                case ("Sol"):
                    
                break;
                default: 
                break;
            }
        }

        /// <summary>
        /// Aumenta uma oitava. Se não puder aumentar, volta à oitava default.
        /// </summary>
        public void IncreaseOneOctave()
        {
            string[] notes = Enum.GetNames(typeof(Notes));
            int nextOctave = Array.IndexOf(notes, _currentOctave) + 1;

            if (nextOctave <= 6)
            {
                _currentOctave = notes[nextOctave];
            }
            else if (nextOctave == 7)
            {
                _currentOctave = "Dó";
            }
            else
            {
                _currentOctave = DEFAULT_OCTAVE;
            }
        }

        public enum Notes
        {
            Dó,
            Ré,
            Mi,
            Fa,
            Sol,
            Lá,
            Si
        }
    }
}

