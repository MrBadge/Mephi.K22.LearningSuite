// Type: Mephi.K22.LearningSuite.Core.UnhandledException
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Core
{
  public class UnhandledException : Form
  {
    private Container components = (Container) null;
    private Panel panel1;
    private Panel panel2;
    private Button button1;
    private Label label1;
    private TextBox textBox1;
    private LinkLabel linkLabel1;

    public UnhandledException(Exception e)
    {
      this.InitializeComponent();
      this.FillData(e);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (UnhandledException));
      this.panel1 = new Panel();
      this.button1 = new Button();
      this.linkLabel1 = new LinkLabel();
      this.panel2 = new Panel();
      this.textBox1 = new TextBox();
      this.label1 = new Label();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.button1);
      this.panel1.Controls.Add((Control) this.linkLabel1);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 345);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(592, 28);
      this.panel1.TabIndex = 0;
      this.button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.button1.Location = new Point(512, 4);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 20);
      this.button1.TabIndex = 0;
      this.button1.Text = "Закрыть";
      this.button1.Click += new EventHandler(this.button1_Click);
      this.linkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.linkLabel1.Location = new Point(0, 4);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(108, 20);
      this.linkLabel1.TabIndex = 2;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Отправить письмо";
      this.linkLabel1.TextAlign = ContentAlignment.MiddleLeft;
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.panel2.Controls.Add((Control) this.textBox1);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(592, 345);
      this.panel2.TabIndex = 1;
      this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox1.Location = new Point(4, 64);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.ScrollBars = ScrollBars.Vertical;
      this.textBox1.Size = new Size(584, 276);
      this.textBox1.TabIndex = 1;
      this.textBox1.Text = "";
      this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.label1.Location = new Point(4, 4);
      this.label1.Name = "label1";
      this.label1.Size = new Size(584, 60);
      this.label1.TabIndex = 0;
      this.label1.Text = "Произошла критическая ошибка в программе. Информация об ошибке приведена ниже. Пожалуйста, отправьте эту информацию с описанием Ваших действий на почту тех. поддержки.";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(592, 373);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Icon = (Icon) resourceManager.GetObject("$this.Icon");
      this.Name = "UnhandledException";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Критическая ошибка!";
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Process.Start("mailto:sdubovitsky@gmail.com?cc=sadchikov@cyber.mephi.ru&subject=LS-BUG");
    }

    private void FillData(Exception ex)
    {
      StringBuilder sb = new StringBuilder();
      this.FillExceptionInfo(ex, sb);
      this.textBox1.Text = sb.ToString();
      this.textBox1.SelectionLength = 0;
    }

    private void FillExceptionInfo(Exception ex, StringBuilder sb)
    {
      sb.AppendFormat("Произошла ошибка типа {0}\r\n", (object) ((object) ex).GetType());
      sb.AppendFormat("Объект вызвавший ошибку: {0}\r\n", (object) ex.Source);
      sb.AppendFormat("Ошибка произошла в методе {0}\r\n", (object) ex.TargetSite);
      sb.AppendFormat("Основная информация об ошибке: {0}\r\n", (object) ex.Message);
      sb.AppendFormat("Стек вызова: {0}\r\n\r\n", (object) ex.StackTrace);
      if (ex.InnerException == null)
        return;
      this.FillExceptionInfo(ex.InnerException, sb);
    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("http://lrn.vault13.ru");
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
