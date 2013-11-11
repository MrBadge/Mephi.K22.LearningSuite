// Type: Mephi.K22.LearningSuite.Shell.Login
// Assembly: Mephi.K22.LearningSuite.Shell, Version=0.1.3236.13214, Culture=neutral, PublicKeyToken=null
// MVID: 06872E41-5D58-4E8A-9BE5-49AA900D1161
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Shell.exe

using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Shell
{
  public class Login : Form
  {
    private Container components = (Container) null;
    private Label label1;
    internal ComboBox cbMode;
    private GroupBox groupBox1;
    private Label label2;
    private Label label3;
    internal TextBox tbLogin;
    internal TextBox tbPass;
    private Button button1;
    private Button button2;

    public Login()
    {
      this.InitializeComponent();
      this.cbMode.Items.AddRange(new object[1]
      {
        (object) "Обучение"
      });
      if (ConfigurationSettings.AppSettings["mode"] == "314")
        this.cbMode.Items.AddRange(new object[1]
        {
          (object) "Контроль"
        });
      this.cbMode.SelectedIndex = 0;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (Login));
      this.label1 = new Label();
      this.cbMode = new ComboBox();
      this.groupBox1 = new GroupBox();
      this.button2 = new Button();
      this.button1 = new Button();
      this.tbPass = new TextBox();
      this.tbLogin = new TextBox();
      this.label3 = new Label();
      this.label2 = new Label();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.label1.Location = new Point(8, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(88, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Режим работы";
      this.label1.TextAlign = ContentAlignment.MiddleLeft;
      this.cbMode.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbMode.Location = new Point(100, 16);
      this.cbMode.Name = "cbMode";
      this.cbMode.Size = new Size(196, 21);
      this.cbMode.TabIndex = 1;
      this.cbMode.SelectedIndexChanged += new EventHandler(this.cbMode_SelectedIndexChanged);
      this.groupBox1.Controls.Add((Control) this.button2);
      this.groupBox1.Controls.Add((Control) this.button1);
      this.groupBox1.Controls.Add((Control) this.tbPass);
      this.groupBox1.Controls.Add((Control) this.tbLogin);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.cbMode);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(380, 102);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.button2.DialogResult = DialogResult.Cancel;
      this.button2.Location = new Point(300, 60);
      this.button2.Name = "button2";
      this.button2.TabIndex = 7;
      this.button2.Text = "Закрыть";
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button1.Location = new Point(300, 24);
      this.button1.Name = "button1";
      this.button1.TabIndex = 6;
      this.button1.Text = "Вход";
      this.button1.Click += new EventHandler(this.button1_Click);
      this.tbPass.Location = new Point(100, 72);
      this.tbPass.Name = "tbPass";
      this.tbPass.PasswordChar = '%';
      this.tbPass.Size = new Size(196, 20);
      this.tbPass.TabIndex = 5;
      this.tbPass.Text = "";
      this.tbLogin.Location = new Point(100, 44);
      this.tbLogin.Name = "tbLogin";
      this.tbLogin.Size = new Size(196, 20);
      this.tbLogin.TabIndex = 3;
      this.tbLogin.Text = "";
      this.label3.Location = new Point(8, 72);
      this.label3.Name = "label3";
      this.label3.Size = new Size(88, 20);
      this.label3.TabIndex = 4;
      this.label3.Text = "Пароль";
      this.label3.TextAlign = ContentAlignment.MiddleLeft;
      this.label2.Location = new Point(8, 44);
      this.label2.Name = "label2";
      this.label2.Size = new Size(88, 20);
      this.label2.TabIndex = 2;
      this.label2.Text = "Логин";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.AcceptButton = (IButtonControl) this.button1;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.button2;
      this.ClientSize = new Size(380, 102);
      this.Controls.Add((Control) this.groupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) resourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = "Login";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Вход";
      this.TopMost = true;
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbMode.SelectedIndex == 0)
        this.tbLogin.Enabled = this.tbPass.Enabled = false;
      else
        this.tbLogin.Enabled = this.tbPass.Enabled = true;
    }
  }
}
