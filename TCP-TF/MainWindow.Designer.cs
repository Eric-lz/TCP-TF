namespace TCP_TF
{
  partial class MainWindow
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      text_Input = new TextBox();
      label_Input = new Label();
      button_Play = new Button();
      label_BPM = new Label();
      num_BPM = new NumericUpDown();
      button_Browse = new Button();
      list_Instrument = new ComboBox();
      label_Instrument = new Label();
      button_Stop = new Button();
      openFileDialog1 = new OpenFileDialog();
      button_SaveFile = new Button();
      saveFileDialog1 = new SaveFileDialog();
      ((System.ComponentModel.ISupportInitialize)num_BPM).BeginInit();
      SuspendLayout();
      // 
      // text_Input
      // 
      text_Input.Location = new Point(12, 48);
      text_Input.Multiline = true;
      text_Input.Name = "text_Input";
      text_Input.Size = new Size(443, 385);
      text_Input.TabIndex = 0;
      // 
      // label_Input
      // 
      label_Input.AutoSize = true;
      label_Input.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
      label_Input.Location = new Point(12, 20);
      label_Input.Name = "label_Input";
      label_Input.Size = new Size(94, 25);
      label_Input.TabIndex = 1;
      label_Input.Text = "Text Input";
      // 
      // button_Play
      // 
      button_Play.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
      button_Play.Location = new Point(650, 390);
      button_Play.Name = "button_Play";
      button_Play.Size = new Size(80, 43);
      button_Play.TabIndex = 2;
      button_Play.Text = "Play";
      button_Play.UseVisualStyleBackColor = true;
      button_Play.Click += button_Play_Click;
      // 
      // label_BPM
      // 
      label_BPM.AutoSize = true;
      label_BPM.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
      label_BPM.Location = new Point(472, 71);
      label_BPM.Name = "label_BPM";
      label_BPM.Size = new Size(155, 25);
      label_BPM.TabIndex = 5;
      label_BPM.Text = "Beats per Minute";
      // 
      // num_BPM
      // 
      num_BPM.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
      num_BPM.Location = new Point(633, 69);
      num_BPM.Maximum = new decimal(new int[] { 250, 0, 0, 0 });
      num_BPM.Minimum = new decimal(new int[] { 40, 0, 0, 0 });
      num_BPM.Name = "num_BPM";
      num_BPM.Size = new Size(86, 32);
      num_BPM.TabIndex = 6;
      num_BPM.Value = new decimal(new int[] { 120, 0, 0, 0 });
      // 
      // button_Browse
      // 
      button_Browse.Location = new Point(366, 15);
      button_Browse.Name = "button_Browse";
      button_Browse.Size = new Size(89, 30);
      button_Browse.TabIndex = 7;
      button_Browse.Text = "Browse";
      button_Browse.UseVisualStyleBackColor = true;
      button_Browse.Click += button_Browse_Click;
      // 
      // list_Instrument
      // 
      list_Instrument.FormattingEnabled = true;
      list_Instrument.Items.AddRange(new object[] { "Piano", "Tubular Bell", "Accordion", "Acoustic Guitar", "Distortion Guitar", "Slap Bass", "Synth Bass", "Ocarina", "Polysynth", "Synth Drum" });
      list_Instrument.Location = new Point(633, 129);
      list_Instrument.Name = "list_Instrument";
      list_Instrument.Size = new Size(86, 29);
      list_Instrument.TabIndex = 9;
      // 
      // label_Instrument
      // 
      label_Instrument.AutoSize = true;
      label_Instrument.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
      label_Instrument.Location = new Point(524, 129);
      label_Instrument.Name = "label_Instrument";
      label_Instrument.Size = new Size(103, 25);
      label_Instrument.TabIndex = 10;
      label_Instrument.Text = "Instrument";
      // 
      // button_Stop
      // 
      button_Stop.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
      button_Stop.Location = new Point(564, 390);
      button_Stop.Name = "button_Stop";
      button_Stop.Size = new Size(80, 43);
      button_Stop.TabIndex = 12;
      button_Stop.Text = "Stop";
      button_Stop.UseVisualStyleBackColor = true;
      button_Stop.Click += button_Stop_Click;
      // 
      // openFileDialog1
      // 
      openFileDialog1.Filter = "Text file|*.txt|All files|*.*";
      openFileDialog1.FileOk += openFileDialog1_FileOk;
      // 
      // button_SaveFile
      // 
      button_SaveFile.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
      button_SaveFile.Location = new Point(478, 390);
      button_SaveFile.Name = "button_SaveFile";
      button_SaveFile.Size = new Size(80, 43);
      button_SaveFile.TabIndex = 13;
      button_SaveFile.Text = "Save";
      button_SaveFile.UseVisualStyleBackColor = true;
      button_SaveFile.Click += button_SaveFile_Click;
      // 
      // saveFileDialog1
      // 
      saveFileDialog1.FileName = "song";
      saveFileDialog1.Filter = "MIDI file|*.mid|All files|*.*";
      saveFileDialog1.InitialDirectory = "%USERPROFILE%/Desktop";
      saveFileDialog1.Tag = "";
      saveFileDialog1.FileOk += saveFileDialog1_FileOk;
      // 
      // MainWindow
      // 
      AutoScaleDimensions = new SizeF(9F, 21F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(742, 447);
      Controls.Add(button_SaveFile);
      Controls.Add(button_Stop);
      Controls.Add(label_Instrument);
      Controls.Add(list_Instrument);
      Controls.Add(button_Browse);
      Controls.Add(num_BPM);
      Controls.Add(label_BPM);
      Controls.Add(button_Play);
      Controls.Add(label_Input);
      Controls.Add(text_Input);
      Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
      Margin = new Padding(4);
      Name = "MainWindow";
      Text = "Trabalho Final TCP";
      ((System.ComponentModel.ISupportInitialize)num_BPM).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox text_Input;
    private Label label_Input;
    private Button button_Play;
    private Label label_BPM;
    private NumericUpDown num_BPM;
    private Button button_Browse;
    private ComboBox list_Instrument;
    private Label label_Instrument;
    private Button button_Stop;
    private OpenFileDialog openFileDialog1;
    private Button button_SaveFile;
    private SaveFileDialog saveFileDialog1;
  }
}