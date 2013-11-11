// Type: Mephi.K22.LearningSuite.Transport.FF.Base.SetResultFrm
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class SetResultFrm : Form
  {
    private Container components = (Container) null;
    private Panel panel1;
    private Button btnCancel;
    private Button btnOk;
    private GroupBox groupBox1;
    private TextBox tbRes;

    public int Result
    {
      get
      {
        try
        {
          return int.Parse(this.tbRes.Text);
        }
        catch
        {
          return 0;
        }
      }
      set
      {
        this.tbRes.Text = value.ToString();
      }
    }

    public SetResultFrm()
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
      this.tbRes = new TextBox();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.btnCancel);
      this.panel1.Controls.Add((Control) this.btnOk);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 76);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(190, 26);
      this.panel1.TabIndex = 3;
      this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(110, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 20);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnOk.Location = new Point(26, 4);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(75, 20);
      this.btnOk.TabIndex = 2;
      this.btnOk.Text = "Ок";
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.groupBox1.Controls.Add((Control) this.tbRes);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(190, 76);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.tbRes.Location = new Point(48, 32);
      this.tbRes.Name = "tbRes";
      this.tbRes.TabIndex = 0;
      this.tbRes.Text = "0";
      this.tbRes.TextAlign = HorizontalAlignment.Right;
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(190, 102);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "SetResult";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Задайте результат";
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
