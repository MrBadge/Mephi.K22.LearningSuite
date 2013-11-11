// Type: Mephi.K22.LearningSuite.Transport.FF.Base.SetFlow
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
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
    internal RadioButton rbHinf;
    internal RadioButton rbHVal;

    public int FlowH
    {
      get
      {
        if (this.rbHinf.Checked)
          return int.MaxValue;
        try
        {
          return int.Parse(this.tbFlowH.Text);
        }
        catch
        {
          return 0;
        }
      }
      set
      {
        if (this.rbHinf.Checked)
          this.tbFlowH.Text = string.Empty;
        else
          this.tbFlowH.Text = value.ToString();
      }
    }

    public bool IsHInf
    {
      get
      {
        return this.rbHinf.Checked;
      }
      set
      {
        this.rbHinf.Checked = value;
        this.rbHVal.Checked = !value;
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
      this.rbHVal = new RadioButton();
      this.rbHinf = new RadioButton();
      this.tbFlowF = new TextBox();
      this.tbFlowH = new TextBox();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.btnCancel);
      this.panel1.Controls.Add((Control) this.btnOk);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 68);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(174, 26);
      this.panel1.TabIndex = 3;
      this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(94, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 20);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnOk.Location = new Point(10, 4);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(75, 20);
      this.btnOk.TabIndex = 2;
      this.btnOk.Text = "Ок";
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.groupBox1.Controls.Add((Control) this.rbHVal);
      this.groupBox1.Controls.Add((Control) this.rbHinf);
      this.groupBox1.Controls.Add((Control) this.tbFlowF);
      this.groupBox1.Controls.Add((Control) this.tbFlowH);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(174, 68);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.rbHVal.Checked = true;
      this.rbHVal.Location = new Point(8, 36);
      this.rbHVal.Name = "rbHVal";
      this.rbHVal.Size = new Size(16, 20);
      this.rbHVal.TabIndex = 3;
      this.rbHVal.TabStop = true;
      this.rbHVal.CheckedChanged += new EventHandler(this.rbHVal_CheckedChanged);
      this.rbHinf.Location = new Point(8, 12);
      this.rbHinf.Name = "rbHinf";
      this.rbHinf.Size = new Size(44, 20);
      this.rbHinf.TabIndex = 2;
      this.rbHinf.Text = "inf";
      this.rbHinf.CheckedChanged += new EventHandler(this.rbHinf_CheckedChanged);
      this.tbFlowF.Location = new Point(104, 28);
      this.tbFlowF.Name = "tbFlowF";
      this.tbFlowF.Size = new Size(64, 20);
      this.tbFlowF.TabIndex = 1;
      this.tbFlowF.Text = "";
      this.tbFlowF.TextAlign = HorizontalAlignment.Right;
      this.tbFlowH.Location = new Point(24, 36);
      this.tbFlowH.Name = "tbFlowH";
      this.tbFlowH.Size = new Size(64, 20);
      this.tbFlowH.TabIndex = 0;
      this.tbFlowH.Text = "";
      this.tbFlowH.TextAlign = HorizontalAlignment.Right;
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(174, 94);
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

    private void rbHVal_CheckedChanged(object sender, EventArgs e)
    {
      this.SetChecked();
    }

    private void SetChecked()
    {
      if (this.rbHVal.Checked)
        this.tbFlowH.Enabled = true;
      else
        this.tbFlowH.Enabled = false;
    }

    private void rbHinf_CheckedChanged(object sender, EventArgs e)
    {
      this.SetChecked();
    }
  }
}
