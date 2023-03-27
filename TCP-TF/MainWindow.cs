using static System.Net.Mime.MediaTypeNames;

namespace TCP_TF
{
  public partial class MainWindow : Form
  {
    private Interpreter _interpreter;

    public MainWindow()
    {
      InitializeComponent();
      _interpreter = new Interpreter();

      // set instrument drop-down to default
      list_Instrument.SelectedIndex = 0;
    }

    // Botão que inicia a execução
    private void button_Play_Click(object sender, EventArgs e)
    {
      // leitura do texto
      string text = text_Input.Text;

      // set BPM e instrumentos selecionados
      _interpreter.BPM = (int)num_BPM.Value;
      _interpreter.Instrument = list_Instrument.GetItemText(list_Instrument.SelectedItem);

      // reproduz musica
      _interpreter.Play(text);
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
      _interpreter.Stop();
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

      // set BPM e instrumentos selecionados
      _interpreter.BPM = (int)num_BPM.Value;
      _interpreter.Instrument = list_Instrument.GetItemText(list_Instrument.SelectedItem);

      // salva musica no arquivo indicado
      _interpreter.SaveFile(saveFileDialog1.FileName, text);
    }
  }
}