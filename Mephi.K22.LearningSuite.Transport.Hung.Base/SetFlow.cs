// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.SetFlow
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public class SetFlow : Form
  {
    private Container components = (Container) null;
    private Panel panel1;
    private Button btnCancel;
    private Button btnOk;
    private GroupBox groupBox1;
    internal TextBox tbFlowF;
    internal TextBox tbFlowH;
    private RadioButton radioButton1;
    private RadioButton radioButton2;

    public int FlowH
    {
      get
      {
        return int.Parse(this.tbFlowH.Text);
      }
      set
      {
        this.tbFlowH.Text = value.ToString();
      }
    }

    public int FlowF
    {
      get
      {
        try
        {
          return int.Parse(this.tbFlowF.Text);
        }
        catch
        {
          return 0;
        }
      }
      set
      {
        this.tbFlowF.Text = value.ToString();
      }
    }

    public SetFlow()
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
      this.btnCancel = new Button();
      this.btnOk = new Button();
      this.groupBox1 = new GroupBox();
      this.tbFlowF = new TextBox();
      this.tbFlowH = new TextBox();
      this.radioButton1 = new RadioButton();
      this.radioButton2 = new RadioButton();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.btnCancel);
      this.panel1.Controls.Add((Control) this.btnOk);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 68);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(182, 26);
      this.panel1.TabIndex = 3;
      this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(102, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 20);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnOk.Location = new Point(18, 4);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(75, 20);
      this.btnOk.TabIndex = 2;
      this.btnOk.Text = "Ок";
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.groupBox1.Controls.Add((Control) this.tbFlowF);
      this.groupBox1.Controls.Add((Control) this.tbFlowH);
      this.groupBox1.Controls.Add((Control) this.radioButton2);
      this.groupBox1.Controls.Add((Control) this.radioButton1);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(182, 68);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.tbFlowF.Location = new Point(108, 28);
      this.tbFlowF.Name = "tbFlowF";
      this.tbFlowF.Size = new Size(64, 20);
      this.tbFlowF.TabIndex = 1;
      this.tbFlowF.Text = "";
      this.tbFlowF.TextAlign = HorizontalAlignment.Right;
      this.tbFlowH.Location = new Point(24, 40);
      this.tbFlowH.Name = "tbFlowH";
      this.tbFlowH.Size = new Size(64, 20);
      this.tbFlowH.TabIndex = 0;
      this.tbFlowH.Text = "";
      this.tbFlowH.TextAlign = HorizontalAlignment.Right;
      this.radioButton1.Location = new Point(8, 12);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new Size(36, 20);
      this.radioButton1.TabIndex = 5;
      this.radioButton1.Text = "inf";
      this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
      this.radioButton2.Checked = true;
      this.radioButton2.Location = new Point(8, 40);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new Size(16, 20);
      this.radioButton2.TabIndex = 6;
      this.radioButton2.TabStop = true;
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(182, 94);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "SetFlow";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Задайте поток";
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    public void SetFFocus()
    {
      this.groupBox1.Focus();
      this.tbFlowF.Focus();
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
    }
  }
}
