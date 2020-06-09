// Decompiled with JetBrains decompiler
// Type: CounterStrikeAnnouncer.Form1
// Assembly: CounterStrikeAnnouncer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B430407B-F596-411E-A84B-0186B9542B95
// Assembly location: C:\Users\user\Desktop\Decompile\CounterStrikeAnnouncer\CounterStrikeAnnouncer.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CounterStrikeAnnouncer
{
  public class Form1 : Form
  {
    public float volu;
    public int game;
    private IContainer components;
    private Button buttonInitialize;
    private TrackBar trackBar1;
    private Label label1;
    private ComboBox comboBox1;

    public Form1()
    {
      this.InitializeComponent();
      this.volu = (float) this.trackBar1.Value;
      this.volu /= 10f;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Announcer announcer = new Announcer(this);
      this.buttonInitialize.Enabled = false;
      this.buttonInitialize.Text = "Running...";
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      Environment.Exit(614);
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
      this.volu = (float) this.trackBar1.Value;
      this.volu /= 10f;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboBox1.Text == "Unreal Tournament 2004")
        this.game = 0;
      if (!(this.comboBox1.Text == "Halo 4"))
        return;
      this.game = 1;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.buttonInitialize = new Button();
      this.trackBar1 = new TrackBar();
      this.label1 = new Label();
      this.comboBox1 = new ComboBox();
      this.trackBar1.BeginInit();
      this.SuspendLayout();
      this.buttonInitialize.Location = new Point(12, 12);
      this.buttonInitialize.Name = "buttonInitialize";
      this.buttonInitialize.Size = new Size(75, 23);
      this.buttonInitialize.TabIndex = 0;
      this.buttonInitialize.Text = "Turn On";
      this.buttonInitialize.UseVisualStyleBackColor = true;
      this.buttonInitialize.Click += new EventHandler(this.button1_Click);
      this.trackBar1.LargeChange = 2;
      this.trackBar1.Location = new Point(12, 68);
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new Size(257, 45);
      this.trackBar1.TabIndex = 10;
      this.trackBar1.TabStop = false;
      this.trackBar1.Value = 10;
      this.trackBar1.Scroll += new EventHandler(this.trackBar1_Scroll);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(9, 52);
      this.label1.Name = "label1";
      this.label1.Size = new Size(42, 13);
      this.label1.TabIndex = 11;
      this.label1.Text = "Volume";
      this.comboBox1.FlatStyle = FlatStyle.Flat;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[2]
      {
        (object) "Unreal Tournament 2004",
        (object) "Halo 4"
      });
      this.comboBox1.Location = new Point(94, 13);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(178, 21);
      this.comboBox1.TabIndex = 12;
      this.comboBox1.Text = "Unreal Tournament 2004";
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(284, 125);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.trackBar1);
      this.Controls.Add((Control) this.buttonInitialize);
      this.MaximizeBox = false;
      this.Name = nameof (Form1);
      this.ShowIcon = false;
      this.Text = "Counter Strike Announcer";
      this.trackBar1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
