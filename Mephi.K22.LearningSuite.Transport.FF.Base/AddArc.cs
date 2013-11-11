// Type: Mephi.K22.LearningSuite.Transport.FF.Base.AddArc
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class AddArc : Form
  {
    private Container components = (Container) null;
    private Panel panel1;
    private Panel panel2;
    private GroupBox groupBox1;
    private Label label1;
    private TextBox tbFrom;
    private TextBox tbTo;
    private Label label2;
    private Button btnCancel;
    private Button btnOk;

    public int FromArc
    {
      get
      {
        return int.Parse(this.tbFrom.Text);
      }
    }

    public int ToArc
    {
      get
      {
        return int.Parse(this.tbTo.Text);
      }
    }

    public AddArc()
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
      this.groupBox1 = new GroupBox();
      this.tbTo = new TextBox();
      this.label2 = new Label();
      this.tbFrom = new TextBox();
      this.label1 = new Label();
      this.panel2 = new Panel();
      this.btnOk = new Button();
      this.btnCancel = new Button();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.groupBox1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(176, 66);
      this.panel1.TabIndex = 0;
      this.groupBox1.Controls.Add((Control) this.tbTo);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.tbFrom);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(176, 66);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.tbTo.Location = new Point(64, 40);
      this.tbTo.Name = "tbTo";
      this.tbTo.Size = new Size(104, 20);
      this.tbTo.TabIndex = 3;
      this.tbTo.Text = "";
      this.tbTo.TextAlign = HorizontalAlignment.Right;
      this.label2.Location = new Point(8, 40);
      this.label2.Name = "label2";
      this.label2.Size = new Size(32, 20);
      this.label2.TabIndex = 2;
      this.label2.Text = "К";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.tbFrom.Location = new Point(64, 16);
      this.tbFrom.Name = "tbFrom";
      this.tbFrom.Size = new Size(104, 20);
      this.tbFrom.TabIndex = 1;
      this.tbFrom.Text = "";
      this.tbFrom.TextAlign = HorizontalAlignment.Right;
      this.label1.Location = new Point(8, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(32, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "От";
      this.label1.TextAlign = ContentAlignment.MiddleLeft;
      this.panel2.Controls.Add((Control) this.btnOk);
      this.panel2.Controls.Add((Control) this.btnCancel);
      this.panel2.Dock = DockStyle.Bottom;
      this.panel2.Location = new Point(0, 66);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(176, 28);
      this.panel2.TabIndex = 1;
      this.btnOk.Location = new Point(20, 4);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(75, 20);
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "Ok";
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(100, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 20);
      this.btnCancel.TabIndex = 0;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(176, 94);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel2);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "AddArc";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Добавить дугу";
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }
  }
}
