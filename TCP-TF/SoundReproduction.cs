using Microsoft.VisualBasic.ApplicationServices;
using NAudio.Midi;
using NAudio.SoundFont;

namespace TCP_TF
{
    public class SoundReproduction
    {
        private int _currentInstrument;
        private int _currentVolume;
        private int _currentOctave;
        private float _currentBPM;

        const int DEFAULT_INSTRUMENT = 1;
        const int DEFAULT_VOLUME = 60;
        const int DEFAULT_OCTAVE = 0;
        const int DEFAULT_BPM = 120;

        const int MAX_VOLUME = 120;

        MidiOut midiOut = new MidiOut(0);

        public SoundReproduction()
        {
            _currentInstrument = DEFAULT_INSTRUMENT;
            _currentVolume = DEFAULT_VOLUME;
            _currentOctave = DEFAULT_OCTAVE;
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
        public void PlayNote(string note)
        {
            float sleepTime = (1 / _currentBPM) * 60 * 1000;

            switch (note)
            {
                case ("Lá"):
                  midiOut.Send(MidiMessage.StartNote(69+(_currentOctave*12), _currentVolume, 1).RawData);
                  Thread.Sleep(Convert.ToInt32(Math.Round(sleepTime)));
                  midiOut.Send(MidiMessage.StopNote(69+(_currentOctave*12), 0, 1).RawData);
                break;

                case ("Si"):
                  midiOut.Send(MidiMessage.StartNote(71+(_currentOctave*12), _currentVolume, 1).RawData);
                  Thread.Sleep(Convert.ToInt32(Math.Round(sleepTime)));
                  midiOut.Send(MidiMessage.StopNote(71+(_currentOctave*12), 0, 1).RawData);
                break;

                case ("Dó"):
                  midiOut.Send(MidiMessage.StartNote(60+(_currentOctave*12), _currentVolume, 1).RawData);
                  Thread.Sleep(Convert.ToInt32(Math.Round(sleepTime)));
                  midiOut.Send(MidiMessage.StopNote(60+(_currentOctave*12), 0, 1).RawData);
                break;

                case ("Ré"):
                  midiOut.Send(MidiMessage.StartNote(62+(_currentOctave*12), _currentVolume, 1).RawData);
                  Thread.Sleep(Convert.ToInt32(Math.Round(sleepTime)));
                  midiOut.Send(MidiMessage.StopNote(62+(_currentOctave*12), 0, 1).RawData);
                break;

                case ("Mi"):
                  midiOut.Send(MidiMessage.StartNote(64+(_currentOctave*12), _currentVolume, 1).RawData);
                  Thread.Sleep(Convert.ToInt32(Math.Round(sleepTime)));
                  midiOut.Send(MidiMessage.StopNote(64+(_currentOctave*12), 0, 1).RawData);
                break;

                case ("Fá"):
                  midiOut.Send(MidiMessage.StartNote(65+(_currentOctave*12), _currentVolume, 1).RawData);
                  Thread.Sleep(Convert.ToInt32(Math.Round(sleepTime)));
                  midiOut.Send(MidiMessage.StopNote(65+(_currentOctave*12), 0, 1).RawData);
                break;

                case ("Sol"):
                  midiOut.Send(MidiMessage.StartNote(67+(_currentOctave*12), _currentVolume, 1).RawData);
                  Thread.Sleep(Convert.ToInt32(Math.Round(sleepTime)));
                  midiOut.Send(MidiMessage.StopNote(67+(_currentOctave*12), 0, 1).RawData);
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
            if (_currentOctave <= 4)
            {
                _currentOctave++;
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

