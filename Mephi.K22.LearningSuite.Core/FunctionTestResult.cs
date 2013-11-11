// Type: Mephi.K22.LearningSuite.Core.FunctionTestResult
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Core
{
  public class FunctionTestResult : Form
  {
    private Container components = (Container) null;
    private Panel panel1;
    private Panel panel2;
    private Button button1;
    public ListBox listBox1;
    private GroupBox groupBox1;

    public FunctionTestResult()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.button1 = new Button();
      this.listBox1 = new ListBox();
      this.groupBox1 = new GroupBox();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.groupBox1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(596, 270);
      this.panel1.TabIndex = 0;
      this.panel2.Controls.Add((Control) this.button1);
      this.panel2.Dock = DockStyle.Bottom;
      this.panel2.Location = new Point(0, 270);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(596, 31);
      this.panel2.TabIndex = 1;
      this.button1.Anchor = AnchorStyles.Right;
      this.button1.Location = new Point(516, 8);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 20);
      this.button1.TabIndex = 0;
      this.button1.Text = "Закрыть";
      this.button1.Click += new EventHandler(this.button1_Click);
      this.listBox1.Dock = DockStyle.Fill;
      this.listBox1.Location = new Point(3, 16);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(590, 251);
      this.listBox1.TabIndex = 0;
      this.groupBox1.Controls.Add((Control) this.listBox1);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(596, 270);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Результат";
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(596, 301);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel2);
      this.Name = "FunctionTestResult";
      this.Text = "Результат проверки фунции";
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
