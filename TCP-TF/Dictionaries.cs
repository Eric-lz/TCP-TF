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
      {'C', 60},
      {'D', 62},
      {'E', 64},
      {'F', 65},
      {'G', 67},
      {'A', 69},
      {'B', 71}
    };
  }
}
