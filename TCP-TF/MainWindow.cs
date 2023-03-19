namespace TCP_TF
{
  public partial class MainWindow : Form
  {
    private Parser _parser;
    private SoundReproduction _reproducer;
    private Interpreter _interpreter;

    public MainWindow()
    {
      InitializeComponent();
      _parser = new Parser();
      _reproducer = new SoundReproduction();
      _interpreter = new Interpreter(_reproducer);

      // set instrument drop-down to default
      list_Instrument.SelectedIndex = 0;
    }

    // Bot�o que inicia a execu��o
    private void button_Play_Click(object sender, EventArgs e)
    {
      string text = text_Input.Text;  // ler texto
      _interpreter.SetBPM((int)num_BPM.Value);
      _interpreter.SetInstrument(list_Instrument.GetItemText(list_Instrument.SelectedItem));
      _interpreter.Interpret(_parser.Parse(text));
    }

    // Bot�o de sele��o de arquivo
    private void button_Browse_Click(object sender, EventArgs e)
    {
      openFileDialog1.ShowDialog();
    }

    // Abre janela de sele��o de arquivo de entrada
    private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
      string fileName = openFileDialog1.FileName;
      string fileContent = File.ReadAllText(fileName);
      text_Input.Text = fileContent;
    }

    // Bot�o de parar execu��o
    private void button_Stop_Click(object sender, EventArgs e)
    {
      _interpreter.Stop();
    }
   }
}