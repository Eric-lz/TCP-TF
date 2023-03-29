namespace TCP_TF
{
  public partial class MainWindow : Form
  {
    private readonly SoundReproduction _player;

    public MainWindow()
    {
      InitializeComponent();

      // inicializa reprodutor
      _player = new SoundReproduction();

      // set instrument drop-down to default
      list_Instrument.SelectedIndex = 0;
    }

    // Botão que inicia a execução
    private void button_Play_Click(object sender, EventArgs e)
    {
      // leitura do texto
      string text = text_Input.Text;

      // leitura dos parâmetros iniciais da interface
      int bpm = bar_BPM.Value;
      int volume = bar_Volume.Value;
      int octave = bar_Octave.Value;
      var instrument = list_Instrument.GetItemText(list_Instrument.SelectedItem);

      // converte texto para comandos MIDI
      var midiCommands = Interpreter.textToMidiCommands(text, bpm, volume, octave, instrument);
      // envia comandos MIDI para reprodução
      _player.PlayCommands(midiCommands);
    }

    // Botão de seleção de arquivo
    private void button_Browse_Click(object sender, EventArgs e)
    {
      // exibe dialogo de abrir arquivo
      openFileDialog1.ShowDialog();
    }

    // Abre janela de seleção de arquivo de entrada
    private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
      // abre arquivo indicado
      string fileName = openFileDialog1.FileName;
      string fileContent = File.ReadAllText(fileName);

      // transfere texto no arquivo para a caixa de texto
      text_Input.Text = fileContent;
    }

    // Botão de parar execução
    private void button_Stop_Click(object sender, EventArgs e)
    {
      _player.Stop();
    }

    private void button_SaveFile_Click(object sender, EventArgs e)
    {
      // exibe dialogo de salvar arquivo
      saveFileDialog1.ShowDialog();
    }

    private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
      // leitura do texto
      string text = text_Input.Text;

      // leitura do nome do arquivo
      string filename = saveFileDialog1.FileName;

      // leitura dos parâmetros iniciais da interface
      int bpm = bar_BPM.Value;
      int volume = bar_Volume.Value;
      int octave = bar_Octave.Value;
      var instrument = list_Instrument.GetItemText(list_Instrument.SelectedItem);

      // converte texto para comandos MIDI
      var midiCommands = Interpreter.textToMidiCommands(text, bpm, volume, octave, instrument);
      // salva comandos MIDI em arquivo .mid
      _player.WriteFile(filename, midiCommands);
    }

    private void bar_BPM_Scroll(object sender, EventArgs e)
    {
      label_setBPM.Text = bar_BPM.Value.ToString();
    }

    private void bar_Volume_Scroll(object sender, EventArgs e)
    {
      label_setVolume.Text = bar_Volume.Value.ToString();
    }

    private void bar_Octave_Scroll(object sender, EventArgs e)
    {
      label_setOctave.Text = bar_Octave.Value.ToString();
    }

    private void button_Help_Click(object sender, EventArgs e)
    {
      var help = new HelpWindow();
      help.Show();
    }
  }
}