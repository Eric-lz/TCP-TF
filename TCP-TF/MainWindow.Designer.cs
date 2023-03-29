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
      button_Browse = new Button();
      label_Instrument = new Label();
      button_Stop = new Button();
      openFileDialog1 = new OpenFileDialog();
      button_SaveFile = new Button();
      saveFileDialog1 = new SaveFileDialog();
      button_Help = new Button();
      label_Params = new Label();
      list_Instrument = new ComboBox();
      bar_BPM = new TrackBar();
      bar_Volume = new TrackBar();
      bar_Octave = new TrackBar();
      label_Volume = new Label();
      label_Octave = new Label();
      label_setBPM = new Label();
      label_setVolume = new Label();
      label_setOctave = new Label();
      ((System.ComponentModel.ISupportInitialize)bar_BPM).BeginInit();
      ((System.ComponentModel.ISupportInitialize)bar_Volume).BeginInit();
      ((System.ComponentModel.ISupportInitialize)bar_Octave).BeginInit();
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
      button_Play.Location = new Point(633, 390);
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
      label_BPM.Location = new Point(461, 61);
      label_BPM.Name = "label_BPM";
      label_BPM.Size = new Size(155, 25);
      label_BPM.TabIndex = 5;
      label_BPM.Text = "Beats per Minute";
      // 
      // button_Browse
      // 
      button_Browse.Location = new Point(297, 15);
      button_Browse.Name = "button_Browse";
      button_Browse.Size = new Size(89, 30);
      button_Browse.TabIndex = 7;
      button_Browse.Text = "Open File";
      button_Browse.UseVisualStyleBackColor = true;
      button_Browse.Click += button_Browse_Click;
      // 
      // label_Instrument
      // 
      label_Instrument.AutoSize = true;
      label_Instrument.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
      label_Instrument.Location = new Point(461, 298);
      label_Instrument.Name = "label_Instrument";
      label_Instrument.Size = new Size(103, 25);
      label_Instrument.TabIndex = 10;
      label_Instrument.Text = "Instrument";
      // 
      // button_Stop
      // 
      button_Stop.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
      button_Stop.Location = new Point(547, 390);
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
      button_SaveFile.Location = new Point(461, 390);
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
      // button_Help
      // 
      button_Help.Location = new Point(392, 15);
      button_Help.Name = "button_Help";
      button_Help.Size = new Size(63, 30);
      button_Help.TabIndex = 14;
      button_Help.Text = "Help";
      button_Help.UseVisualStyleBackColor = true;
      button_Help.Click += button_Help_Click;
      // 
      // label_Params
      // 
      label_Params.AutoSize = true;
      label_Params.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
      label_Params.Location = new Point(513, 20);
      label_Params.Name = "label_Params";
      label_Params.Size = new Size(176, 25);
      label_Params.TabIndex = 15;
      label_Params.Text = "Starting Parameters";
      // 
      // list_Instrument
      // 
      list_Instrument.FormattingEnabled = true;
      list_Instrument.Items.AddRange(new object[] { "Piano", "Tubular Bell", "Harpsichord", "Accordion", "Acoustic Guitar", "Distortion Guitar", "Slap Bass", "Synth Bass", "Ocarina", "Pan Flute", "Agogo", "Polysynth", "Synth Drum" });
      list_Instrument.Location = new Point(461, 326);
      list_Instrument.Name = "list_Instrument";
      list_Instrument.Size = new Size(204, 29);
      list_Instrument.TabIndex = 9;
      // 
      // bar_BPM
      // 
      bar_BPM.LargeChange = 20;
      bar_BPM.Location = new Point(461, 89);
      bar_BPM.Maximum = 240;
      bar_BPM.Minimum = 40;
      bar_BPM.Name = "bar_BPM";
      bar_BPM.Size = new Size(204, 45);
      bar_BPM.SmallChange = 10;
      bar_BPM.TabIndex = 16;
      bar_BPM.TickFrequency = 10;
      bar_BPM.TickStyle = TickStyle.Both;
      bar_BPM.Value = 120;
      bar_BPM.Scroll += bar_BPM_Scroll;
      // 
      // bar_Volume
      // 
      bar_Volume.LargeChange = 20;
      bar_Volume.Location = new Point(461, 165);
      bar_Volume.Maximum = 100;
      bar_Volume.Name = "bar_Volume";
      bar_Volume.Size = new Size(204, 45);
      bar_Volume.SmallChange = 10;
      bar_Volume.TabIndex = 17;
      bar_Volume.TickFrequency = 10;
      bar_Volume.TickStyle = TickStyle.Both;
      bar_Volume.Value = 100;
      bar_Volume.Scroll += bar_Volume_Scroll;
      // 
      // bar_Octave
      // 
      bar_Octave.LargeChange = 2;
      bar_Octave.Location = new Point(461, 241);
      bar_Octave.Maximum = 8;
      bar_Octave.Minimum = 1;
      bar_Octave.Name = "bar_Octave";
      bar_Octave.Size = new Size(204, 45);
      bar_Octave.TabIndex = 18;
      bar_Octave.TickStyle = TickStyle.Both;
      bar_Octave.Value = 4;
      bar_Octave.Scroll += bar_Octave_Scroll;
      // 
      // label_Volume
      // 
      label_Volume.AutoSize = true;
      label_Volume.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
      label_Volume.Location = new Point(461, 137);
      label_Volume.Name = "label_Volume";
      label_Volume.Size = new Size(76, 25);
      label_Volume.TabIndex = 19;
      label_Volume.Text = "Volume";
      // 
      // label_Octave
      // 
      label_Octave.AutoSize = true;
      label_Octave.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
      label_Octave.Location = new Point(461, 213);
      label_Octave.Name = "label_Octave";
      label_Octave.Size = new Size(70, 25);
      label_Octave.TabIndex = 20;
      label_Octave.Text = "Octave";
      // 
      // label_setBPM
      // 
      label_setBPM.AutoSize = true;
      label_setBPM.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
      label_setBPM.Location = new Point(663, 94);
      label_setBPM.Name = "label_setBPM";
      label_setBPM.Size = new Size(49, 30);
      label_setBPM.TabIndex = 21;
      label_setBPM.Text = "120";
      // 
      // label_setVolume
      // 
      label_setVolume.AutoSize = true;
      label_setVolume.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
      label_setVolume.Location = new Point(663, 172);
      label_setVolume.Name = "label_setVolume";
      label_setVolume.Size = new Size(49, 30);
      label_setVolume.TabIndex = 22;
      label_setVolume.Text = "100";
      // 
      // label_setOctave
      // 
      label_setOctave.AutoSize = true;
      label_setOctave.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
      label_setOctave.Location = new Point(667, 248);
      label_setOctave.Name = "label_setOctave";
      label_setOctave.Size = new Size(25, 30);
      label_setOctave.TabIndex = 23;
      label_setOctave.Text = "4";
      // 
      // MainWindow
      // 
      AutoScaleMode = AutoScaleMode.None;
      ClientSize = new Size(730, 447);
      Controls.Add(label_setOctave);
      Controls.Add(label_setVolume);
      Controls.Add(label_setBPM);
      Controls.Add(label_Octave);
      Controls.Add(label_Volume);
      Controls.Add(bar_Octave);
      Controls.Add(bar_Volume);
      Controls.Add(bar_BPM);
      Controls.Add(label_Params);
      Controls.Add(button_Help);
      Controls.Add(button_SaveFile);
      Controls.Add(button_Stop);
      Controls.Add(label_Instrument);
      Controls.Add(list_Instrument);
      Controls.Add(button_Browse);
      Controls.Add(label_BPM);
      Controls.Add(button_Play);
      Controls.Add(label_Input);
      Controls.Add(text_Input);
      Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Margin = new Padding(4);
      MaximizeBox = false;
      Name = "MainWindow";
      SizeGripStyle = SizeGripStyle.Hide;
      Text = "MIDI Text to Sound";
      ((System.ComponentModel.ISupportInitialize)bar_BPM).EndInit();
      ((System.ComponentModel.ISupportInitialize)bar_Volume).EndInit();
      ((System.ComponentModel.ISupportInitialize)bar_Octave).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox text_Input;
    private Label label_Input;
    private Button button_Play;
    private Label label_BPM;
    private Button button_Browse;
    private Label label_Instrument;
    private Button button_Stop;
    private OpenFileDialog openFileDialog1;
    private Button button_SaveFile;
    private SaveFileDialog saveFileDialog1;
    private Button button_Help;
    private Label label_Params;
    private ComboBox list_Instrument;
    private TrackBar bar_BPM;
    private TrackBar bar_Volume;
    private TrackBar bar_Octave;
    private Label label_Volume;
    private Label label_Octave;
    private Label label_setBPM;
    private Label label_setVolume;
    private Label label_setOctave;
  }
}