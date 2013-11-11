// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.SetResultNetwork
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public class SetResultNetwork : Form
  {
    private Container components = (Container) null;
    private Panel panel1;
    private Panel panel2;
    internal HungTableControl hungTableControl1;
    private Label label1;
    private Label label2;
    private TextBox textBox1;
    private Button btnCancel;
    private Button btnOk;

    public int Sum
    {
      get
      {
        try
        {
          return int.Parse(this.textBox1.Text);
        }
        catch
        {
          return 0;
        }
      }
    }

    public SetResultNetwork()
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
      this.textBox1 = new TextBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.hungTableControl1 = new HungTableControl();
      this.panel2 = new Panel();
      this.btnCancel = new Button();
      this.btnOk = new Button();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.textBox1);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.hungTableControl1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(206, 134);
      this.panel1.TabIndex = 0;
      this.textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.textBox1.Location = new Point(124, 108);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(76, 20);
      this.textBox1.TabIndex = 3;
      this.textBox1.Text = "0";
      this.textBox1.TextAlign = HorizontalAlignment.Right;
      this.label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label2.Location = new Point(4, 108);
      this.label2.Name = "label2";
      this.label2.Size = new Size(120, 20);
      this.label2.TabIndex = 2;
      this.label2.Text = "Стоимость перевозок";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.label1.Location = new Point(4, 4);
      this.label1.Name = "label1";
      this.label1.Size = new Size(100, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "План перевозок";
      this.label1.TextAlign = ContentAlignment.MiddleLeft;
      this.hungTableControl1.IsSetResult = false;
      this.hungTableControl1.Location = new Point(4, 24);
      this.hungTableControl1.Name = "hungTableControl1";
      this.hungTableControl1.ReadOnly = false;
      this.hungTableControl1.Selectable = true;
      this.hungTableControl1.Size = new Size(80, 80);
      this.hungTableControl1.TabIndex = 0;
      this.panel2.Controls.Add((Control) this.btnCancel);
      this.panel2.Controls.Add((Control) this.btnOk);
      this.panel2.Dock = DockStyle.Bottom;
      this.panel2.Location = new Point(0, 134);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(206, 28);
      this.panel2.TabIndex = 1;
      this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(46, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 20);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnOk.Location = new Point(126, 4);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(75, 20);
      this.btnOk.TabIndex = 3;
      this.btnOk.Text = "Ок";
      this.btnOk.Click += new EventHandler(this.button2_Click);
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(206, 162);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel2);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "SetResultNetwork";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Задайте результат";
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }
  }
}
