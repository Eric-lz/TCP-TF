using Microsoft.VisualBasic.ApplicationServices;

namespace TCP_TF
{
    public class Sound
    {
        private int _currentInstrument;
        private int _currentVolume;

        const int DEFAULT_INSTRUMENT = 1;
        const int DEFAULT_VOLUME = 50;

        public Sound()
        {
            _currentInstrument = DEFAULT_INSTRUMENT;
            _currentVolume = DEFAULT_VOLUME;
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
        /// Dobra o volume. Se não puder aumentar, volta ao volume default.
        /// </summary>
        public void DoubleVolume()
        {
            
        }

        /// <summary>
        /// Aumenta uma oitava. Se não puder aumentar, volta à oitava default.
        /// </summary>
        public void IncreaseOneOctave()
        {

        }
    }
}

