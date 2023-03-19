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
        }

        private void button_Play_Click(object sender, EventArgs e)
        {
            string text = text_Input.Text;  // ler texto
            _interpreter.SetBPM((int)num_BPM.Value);
            _interpreter.SetInstrument(list_Instrument.SelectedIndex);
            _interpreter.Interpret(_parser.Parse(text));
        }

    private void button_Input_Click(object sender, EventArgs e)
    {
      openFileDialog1.ShowDialog();
    }

    private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
      string fileName = openFileDialog1.FileName;
      string fileContent = File.ReadAllText(fileName);
      text_Input.Text = fileContent;
    }

    private void button_Stop_Click(object sender, EventArgs e)
    {
      _interpreter.Stop();
    }
  }
}