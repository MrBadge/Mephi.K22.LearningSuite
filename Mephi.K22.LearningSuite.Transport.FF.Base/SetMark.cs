// Type: Mephi.K22.LearningSuite.Transport.FF.Base.SetMark
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class SetMark : Form
  {
    private Container components = (Container) null;
    private Panel panel1;
    private Button btnCancel;
    private Button btnOk;
    private GroupBox groupBox1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Panel panel2;
    private Panel panel3;
    private RadioButton rbMinus;
    private RadioButton rbPlus;
    private TextBox tbZ;
    private RadioButton rbE;
    private RadioButton rbInf;
    private TextBox tbE;

    public bool Empty
    {
      get
      {
        return this.tbZ.Text == string.Empty;
      }
    }

    public int Z
    {
      get
      {
        try
        {
          if (this.tbZ.Text != string.Empty)
            return int.Parse(this.tbZ.Text);
          else
            return 0;
        }
        catch
        {
          return 0;
        }
      }
    }

    public bool Plus
    {
      get
      {
        return this.rbPlus.Checked;
      }
    }

    public bool Inf
    {
      get
      {
        return this.rbInf.Checked;
      }
    }

    public int E
    {
      get
      {
        try
        {
          return int.Parse(this.tbE.Text);
        }
        catch
        {
          return 0;
        }
      }
    }

    public SetMark()
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
      this.panel2 = new Panel();
      this.rbMinus = new RadioButton();
      this.rbPlus = new RadioButton();
      this.tbZ = new TextBox();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.panel3 = new Panel();
      this.rbE = new RadioButton();
      this.rbInf = new RadioButton();
      this.tbE = new TextBox();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.btnCancel);
      this.panel1.Controls.Add((Control) this.btnOk);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 80);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(206, 26);
      this.panel1.TabIndex = 1;
      this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(126, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 20);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnOk.Location = new Point(42, 4);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(75, 20);
      this.btnOk.TabIndex = 0;
      this.btnOk.Text = "Ок";
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.groupBox1.Controls.Add((Control) this.panel2);
      this.groupBox1.Controls.Add((Control) this.tbZ);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.panel3);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(206, 80);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Enter += new EventHandler(this.groupBox1_Enter);
      this.panel2.Controls.Add((Control) this.rbMinus);
      this.panel2.Controls.Add((Control) this.rbPlus);
      this.panel2.Location = new Point(68, 12);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(36, 64);
      this.panel2.TabIndex = 2;
      this.rbMinus.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.rbMinus.Location = new Point(4, 36);
      this.rbMinus.Name = "rbMinus";
      this.rbMinus.Size = new Size(28, 24);
      this.rbMinus.TabIndex = 1;
      this.rbMinus.Text = "-";
      this.rbPlus.Checked = true;
      this.rbPlus.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.rbPlus.Location = new Point(4, 4);
      this.rbPlus.Name = "rbPlus";
      this.rbPlus.Size = new Size(28, 24);
      this.rbPlus.TabIndex = 0;
      this.rbPlus.TabStop = true;
      this.rbPlus.Text = "+";
      this.tbZ.Location = new Point(28, 32);
      this.tbZ.Name = "tbZ";
      this.tbZ.Size = new Size(40, 20);
      this.tbZ.TabIndex = 1;
      this.tbZ.Text = "";
      this.tbZ.TextAlign = HorizontalAlignment.Right;
      this.tbZ.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.label3.Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label3.Location = new Point(104, 8);
      this.label3.Name = "label3";
      this.label3.Size = new Size(12, 64);
      this.label3.TabIndex = 3;
      this.label3.Text = ";";
      this.label3.TextAlign = ContentAlignment.MiddleCenter;
      this.label2.Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label2.Location = new Point(188, 8);
      this.label2.Name = "label2";
      this.label2.Size = new Size(12, 64);
      this.label2.TabIndex = 5;
      this.label2.Text = ")";
      this.label2.TextAlign = ContentAlignment.MiddleCenter;
      this.label1.Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label1.Location = new Point(8, 8);
      this.label1.Name = "label1";
      this.label1.Size = new Size(20, 64);
      this.label1.TabIndex = 0;
      this.label1.Text = "(";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.panel3.Controls.Add((Control) this.rbE);
      this.panel3.Controls.Add((Control) this.rbInf);
      this.panel3.Controls.Add((Control) this.tbE);
      this.panel3.Location = new Point(116, 12);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(68, 64);
      this.panel3.TabIndex = 4;
      this.rbE.Checked = true;
      this.rbE.Location = new Point(4, 36);
      this.rbE.Name = "rbE";
      this.rbE.Size = new Size(16, 24);
      this.rbE.TabIndex = 1;
      this.rbE.TabStop = true;
      this.rbE.CheckedChanged += new EventHandler(this.rbE_CheckedChanged);
      this.rbInf.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.rbInf.Location = new Point(4, 4);
      this.rbInf.Name = "rbInf";
      this.rbInf.Size = new Size(60, 24);
      this.rbInf.TabIndex = 0;
      this.rbInf.Text = "inf";
      this.rbInf.TextAlign = ContentAlignment.MiddleCenter;
      this.tbE.Location = new Point(20, 36);
      this.tbE.Name = "tbE";
      this.tbE.Size = new Size(44, 20);
      this.tbE.TabIndex = 2;
      this.tbE.Text = "";
      this.tbE.TextAlign = HorizontalAlignment.Right;
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(206, 106);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "SetMark";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Задайте пометку";
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void rbE_CheckedChanged(object sender, EventArgs e)
    {
      if (this.rbE.Checked)
        this.tbE.Enabled = true;
      else
        this.tbE.Enabled = false;
    }
  }
}
