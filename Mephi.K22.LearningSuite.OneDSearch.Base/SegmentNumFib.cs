﻿// Type: Mephi.K22.LearningSuite.OneDSearch.Base.SegmentNumFib
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class SegmentNumFib : Form
  {
    private Container components = (Container) null;
    private GroupBox groupBox1;
    private Panel panel1;
    private Button btnOk;
    private Button btnCancel;
    internal TextBox tbNumFib;

    public SegmentNumFib()
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
      this.groupBox1 = new GroupBox();
      this.tbNumFib = new TextBox();
      this.panel1 = new Panel();
      this.btnCancel = new Button();
      this.btnOk = new Button();
      this.groupBox1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.tbNumFib);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(284, 37);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.tbNumFib.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbNumFib.Location = new System.Drawing.Point(4, 12);
      this.tbNumFib.Name = "tbNumFib";
      this.tbNumFib.Size = new Size(276, 20);
      this.tbNumFib.TabIndex = 1;
      this.tbNumFib.Text = "";
      this.panel1.Controls.Add((Control) this.btnCancel);
      this.panel1.Controls.Add((Control) this.btnOk);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 37);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(284, 26);
      this.panel1.TabIndex = 1;
      this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(204, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 20);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnOk.Location = new System.Drawing.Point(120, 4);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(75, 20);
      this.btnOk.TabIndex = 2;
      this.btnOk.Text = "Ок";
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(284, 63);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "SegmentLength";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Введите количество экспериментов";
      this.groupBox1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      try
      {
        float.Parse(this.tbNumFib.Text);
        this.DialogResult = DialogResult.OK;
        this.Hide();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Соблюдайте формат: 0", "Ошибка!");
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Hide();
    }
  }
}
