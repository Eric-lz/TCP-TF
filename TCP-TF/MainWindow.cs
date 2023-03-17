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
            /*
            string text =   ;// ler texto ou arquivo de texto
            interpreter.Interpret(parser.Parse(text)); 
            */
        }
    }
}