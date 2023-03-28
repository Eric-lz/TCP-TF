﻿using Microsoft.VisualBasic.ApplicationServices;
using NAudio.Midi;
using NAudio.SoundFont;
using System.Diagnostics.Metrics;

namespace TCP_TF
{
  public class SoundReproduction
  {
    // MIDI output object
    private readonly MidiOut midiOut;

    // Flag que indica se reprodutor está executando
    private bool _isPlaying;

    // Constantes
    const int DEFAULT_VOLUME = 60;
    const int DEFAULT_INSTRUMENT = 0;
    const int DEFAULT_BPM = 120;
    const int MIDI_FILE_TYPE = 0;
    const int TRACK_NUMBER = 0;
    const int CHANNEL_NUMBER = 1;
    const int DEVICE_NO = 0;

    public SoundReproduction()
    {
      // MIDI output
      midiOut = new MidiOut(DEVICE_NO);

      _isPlaying = false;
    }

    /// <summary>
    /// Toca a nota correspondente.
    /// </summary>
    public async void PlayNote(int note, int volume, int instrument, int bpm)
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
    /// Recebe uma lista de comandos e reproduz.
    /// </summary>
    public async void PlayCommands(List<KeyValuePair<string, int>> midiCommands)
    {
      int bpm = DEFAULT_BPM;
      int volume = DEFAULT_VOLUME;
      int instrument = DEFAULT_INSTRUMENT;

      float sleepTime = (1 / (float)bpm) * 60 * 1000;

      // retorna da função se já estiver rodando
      if (_isPlaying)
      {
        return;
      }

      _isPlaying = true;

      foreach (KeyValuePair<string, int> midiCommand in midiCommands)
      {
        if (_isPlaying)
        {
          switch (midiCommand.Key)
          {
            case "Note":
              PlayNote(midiCommand.Value, volume, instrument, bpm);
              await Task.Delay(Convert.ToInt32(Math.Round(sleepTime)));
              break;

            case "Instrument":
              instrument = midiCommand.Value;
              break;

            case "Volume":
              volume = midiCommand.Value;
              break;

            case "BPM":
              bpm = midiCommand.Value;
              sleepTime = (1 / (float)bpm) * 60 * 1000;
              break;

            case "Stop":
              Stop();
              break;
          }
        }
      }
    }

    /// <summary>
    /// Recebe uma lista de comandos e salva como musica em arquivo formato MIDI.
    /// </summary>
    public void WriteFile(string filename, List<KeyValuePair<string, int>> midiCommands)
    {
      // volume a ser tocado
      int volume = DEFAULT_VOLUME;

      // tempo
      int bpm = DEFAULT_BPM;
      long absoluteTime = 0;

      // tempo de duração da nota
      int NoteDuration = 3 * bpm / 4;

      // cria uma collection de eventos MIDI
      var collection = new MidiEventCollection(MIDI_FILE_TYPE, bpm);

      // inicializa collection
      collection.AddEvent(new TextEvent("Note Stream", MetaEventType.TextEvent, absoluteTime), TRACK_NUMBER);
      absoluteTime++;
      collection.AddEvent(new TempoEvent(Convert.ToInt32((60 * 1000 * 1000) / bpm), absoluteTime), TRACK_NUMBER);
      absoluteTime++;

      // preenche collection
      foreach (KeyValuePair<string, int> midiCommand in midiCommands)
      {
        switch (midiCommand.Key)
        {
          case "Note":
            collection.AddEvent(new NoteOnEvent(absoluteTime, CHANNEL_NUMBER, midiCommand.Value, volume, NoteDuration), TRACK_NUMBER);
            collection.AddEvent(new NoteEvent(absoluteTime + NoteDuration, CHANNEL_NUMBER, MidiCommandCode.NoteOff, midiCommand.Value, 0), TRACK_NUMBER);
            absoluteTime += bpm;
            break;

          case "Instrument":
            collection.AddEvent(new PatchChangeEvent(absoluteTime, CHANNEL_NUMBER, midiCommand.Value), TRACK_NUMBER);
            break;

          case "Volume":
            volume = midiCommand.Value;
            break;

          case "BPM":
            bpm = midiCommand.Value;
            collection.AddEvent(new TempoEvent(Convert.ToInt32((60 * 1000 * 1000) / bpm), absoluteTime), TRACK_NUMBER);
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
    /// Para a reprodução
    /// </summary>
    public void Stop()
    {
      // flag de parada
      _isPlaying = false;

      // envia sinal de parada para todas as notas possíveis individualmente
      for (int i = 0; i < 127; i++)
      {
        midiOut.Send(MidiMessage.StopNote(i, 0, 1).RawData);
      }
    }
  }
}

