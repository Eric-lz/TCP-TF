namespace TCP_TF
{
  internal class Dictionaries
  {
    public static readonly Dictionary<string, int> instrumentToMIDI = new()
    {
      {"Piano", 0},
      {"Harpsichord", 6},
      {"Tubular Bell", 14},
      {"Church Organ", 19},
      {"Accordion", 21},
      {"Acoustic Guitar", 24},
      {"Distortion Guitar", 30},
      {"Slap Bass", 36},
      {"Synth Bass", 38},
      {"Pan Flute", 75},
      {"Ocarina", 79},
      {"Polysynth", 90},
      {"Agogo", 113},
      {"Synth Drum", 118}
    };

    public static readonly Dictionary<char, int> charToMIDIInstrument = new()
    {
      {'!', 113},
      {'O', 6},
      {'o', 6},
      {'I', 6},
      {'i', 6},
      {'U', 6},
      {'u', 6},
      {'\n', 14},
      {'\r', 14},
      {';', 75},
      {',', 19}
    };

    public static readonly Dictionary<char, int> charToMIDINote = new()
    {
      {'C', 12},
      {'D', 14},
      {'E', 16},
      {'F', 17},
      {'G', 19},
      {'A', 9},
      {'B', 11}
    };
  }
}
