// Type: Mephi.K22.LearningSuite.Transport.FF.Base.SetSourceTarget
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class SetSourceTarget : Form
  {
    private Container components = (Container) null;
    private Panel panel1;
    private Button btnCancel;
    private Button btnOk;
    private GroupBox groupBox1;
    private TextBox tbFlowF;
    private TextBox tbFlowH;
    private Label label1;
    private Label label2;

    public int Source
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

    public int Target
    {
      get
      {
        return int.Parse(this.tbFlowF.Text);
      }
      set
      {
        this.tbFlowF.Text = value.ToString();
      }
    }

    public SetSourceTarget()
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
      this.label2 = new Label();
      this.label1 = new Label();
      this.tbFlowF = new TextBox();
      this.tbFlowH = new TextBox();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.btnCancel);
      this.panel1.Controls.Add((Control) this.btnOk);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 72);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(150, 26);
      this.panel1.TabIndex = 3;
      this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(84, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(60, 20);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnOk.Location = new Point(20, 4);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(60, 20);
      this.btnOk.TabIndex = 2;
      this.btnOk.Text = "Ок";
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.tbFlowF);
      this.groupBox1.Controls.Add((Control) this.tbFlowH);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(150, 72);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.label2.Location = new Point(8, 44);
      this.label2.Name = "label2";
      this.label2.Size = new Size(50, 20);
      this.label2.TabIndex = 3;
      this.label2.Text = "Target";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.label1.Location = new Point(8, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(50, 20);
      this.label1.TabIndex = 2;
      this.label1.Text = "Source";
      this.label1.TextAlign = ContentAlignment.MiddleLeft;
      this.tbFlowF.Location = new Point(80, 44);
      this.tbFlowF.Name = "tbFlowF";
      this.tbFlowF.Size = new Size(64, 20);
      this.tbFlowF.TabIndex = 1;
      this.tbFlowF.Text = "";
      this.tbFlowH.Location = new Point(80, 16);
      this.tbFlowH.Name = "tbFlowH";
      this.tbFlowH.Size = new Size(64, 20);
      this.tbFlowH.TabIndex = 0;
      this.tbFlowH.Text = "";
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(150, 98);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "SetSourceTarget";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "SetFlow";
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
  }
}
