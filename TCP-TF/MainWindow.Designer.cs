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
      this.text_Input = new System.Windows.Forms.TextBox();
      this.label_Input = new System.Windows.Forms.Label();
      this.button_Play = new System.Windows.Forms.Button();
      this.label_BPM = new System.Windows.Forms.Label();
      this.num_BPM = new System.Windows.Forms.NumericUpDown();
      this.button_Input = new System.Windows.Forms.Button();
      this.list_Instrument = new System.Windows.Forms.ComboBox();
      this.label_Instrument = new System.Windows.Forms.Label();
      this.button_Stop = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.num_BPM)).BeginInit();
      this.SuspendLayout();
      // 
      // text_Input
      // 
      this.text_Input.Location = new System.Drawing.Point(12, 48);
      this.text_Input.Multiline = true;
      this.text_Input.Name = "text_Input";
      this.text_Input.Size = new System.Drawing.Size(443, 385);
      this.text_Input.TabIndex = 0;
      // 
      // label_Input
      // 
      this.label_Input.AutoSize = true;
      this.label_Input.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label_Input.Location = new System.Drawing.Point(12, 20);
      this.label_Input.Name = "label_Input";
      this.label_Input.Size = new System.Drawing.Size(94, 25);
      this.label_Input.TabIndex = 1;
      this.label_Input.Text = "Text Input";
      // 
      // button_Play
      // 
      this.button_Play.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.button_Play.Location = new System.Drawing.Point(650, 390);
      this.button_Play.Name = "button_Play";
      this.button_Play.Size = new System.Drawing.Size(80, 43);
      this.button_Play.TabIndex = 2;
      this.button_Play.Text = "Play";
      this.button_Play.UseVisualStyleBackColor = true;
      this.button_Play.Click += new System.EventHandler(this.button_Play_Click);
      // 
      // label_BPM
      // 
      this.label_BPM.AutoSize = true;
      this.label_BPM.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label_BPM.Location = new System.Drawing.Point(472, 71);
      this.label_BPM.Name = "label_BPM";
      this.label_BPM.Size = new System.Drawing.Size(155, 25);
      this.label_BPM.TabIndex = 5;
      this.label_BPM.Text = "Beats per Minute";
      // 
      // num_BPM
      // 
      this.num_BPM.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.num_BPM.Location = new System.Drawing.Point(633, 69);
      this.num_BPM.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
      this.num_BPM.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
      this.num_BPM.Name = "num_BPM";
      this.num_BPM.Size = new System.Drawing.Size(86, 32);
      this.num_BPM.TabIndex = 6;
      this.num_BPM.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
      // 
      // button_Input
      // 
      this.button_Input.Location = new System.Drawing.Point(366, 15);
      this.button_Input.Name = "button_Input";
      this.button_Input.Size = new System.Drawing.Size(89, 30);
      this.button_Input.TabIndex = 7;
      this.button_Input.Text = "Browse";
      this.button_Input.UseVisualStyleBackColor = true;
      this.button_Input.Click += new System.EventHandler(this.button_Input_Click);
      // 
      // list_Instrument
      // 
      this.list_Instrument.FormattingEnabled = true;
      this.list_Instrument.Items.AddRange(new object[] {
            "Piano",
            "Guitarra",
            "Saxofone",
            "Ocarina"});
      this.list_Instrument.Location = new System.Drawing.Point(633, 129);
      this.list_Instrument.Name = "list_Instrument";
      this.list_Instrument.Size = new System.Drawing.Size(86, 29);
      this.list_Instrument.TabIndex = 9;
      // 
      // label_Instrument
      // 
      this.label_Instrument.AutoSize = true;
      this.label_Instrument.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label_Instrument.Location = new System.Drawing.Point(524, 129);
      this.label_Instrument.Name = "label_Instrument";
      this.label_Instrument.Size = new System.Drawing.Size(103, 25);
      this.label_Instrument.TabIndex = 10;
      this.label_Instrument.Text = "Instrument";
      // 
      // button_Stop
      // 
      this.button_Stop.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.button_Stop.Location = new System.Drawing.Point(564, 390);
      this.button_Stop.Name = "button_Stop";
      this.button_Stop.Size = new System.Drawing.Size(80, 43);
      this.button_Stop.TabIndex = 12;
      this.button_Stop.Text = "Stop";
      this.button_Stop.UseVisualStyleBackColor = true;
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
      // 
      // MainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(742, 447);
      this.Controls.Add(this.button_Stop);
      this.Controls.Add(this.label_Instrument);
      this.Controls.Add(this.list_Instrument);
      this.Controls.Add(this.button_Input);
      this.Controls.Add(this.num_BPM);
      this.Controls.Add(this.label_BPM);
      this.Controls.Add(this.button_Play);
      this.Controls.Add(this.label_Input);
      this.Controls.Add(this.text_Input);
      this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "MainWindow";
      this.Text = "Trabalho Final TCP";
      ((System.ComponentModel.ISupportInitialize)(this.num_BPM)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private TextBox text_Input;
    private Label label_Input;
    private Button button_Play;
    private Label label_BPM;
    private NumericUpDown num_BPM;
    private Button button_Input;
    private ComboBox list_Instrument;
    private Label label_Instrument;
    private Button button_Stop;
    private OpenFileDialog openFileDialog1;
  }
}