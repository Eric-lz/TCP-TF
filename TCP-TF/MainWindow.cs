using static System.Net.Mime.MediaTypeNames;

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
      int bpm = (int)num_BPM.Value;
      var instrument = list_Instrument.GetItemText(list_Instrument.SelectedItem);

      // inicia reprodução
      var midiCommands = Interpreter.textToMidiCommands(text, bpm, instrument);
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

      string filename = saveFileDialog1.FileName;
      int bpm = (int)num_BPM.Value;
      var instrument = list_Instrument.GetItemText(list_Instrument.SelectedItem);

      // inicia reprodução
      var midiCommands = Interpreter.textToMidiCommands(text, bpm, instrument);
      _player.WriteFile(filename, midiCommands);
    }
  }
}