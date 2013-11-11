// Type: Mephi.K22.LearningSuite.Core.BaseTaskObjectForm
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Core
{
  public class BaseTaskObjectForm : Form
  {
    internal bool isEdit = false;
    private Container components = (Container) null;
    public Button btnCancel;
    public Button btnOk;
    private BaseTaskObjectControl _taskObjectControl;
    private GroupBox groupBox1;
    private Panel panel1;
    private Panel panel2;

    public BaseTaskObjectControl TaskObjectControl
    {
      get
      {
        return this._taskObjectControl;
      }
      set
      {
        this._taskObjectControl = value;
      }
    }

    public event BaseTaskObjectForm.OnApplyHandler OnApply;

    public BaseTaskObjectForm()
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
      this.btnCancel = new Button();
      this.btnOk = new Button();
      this.groupBox1 = new GroupBox();
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(298, 8);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 20);
      this.btnCancel.TabIndex = 0;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnOk.Location = new Point(378, 8);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(75, 20);
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "OK";
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(458, 178);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.panel1.Controls.Add((Control) this.groupBox1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(458, 178);
      this.panel1.TabIndex = 3;
      this.panel2.Controls.Add((Control) this.btnCancel);
      this.panel2.Controls.Add((Control) this.btnOk);
      this.panel2.Dock = DockStyle.Bottom;
      this.panel2.Location = new Point(0, 178);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(458, 32);
      this.panel2.TabIndex = 4;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(458, 210);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel2);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "BaseTaskObjectForm";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Создание";
      this.Load += new EventHandler(this.BaseTaskObjectForm_Load);
      this.Closed += new EventHandler(this.BaseDetailForm_Closed);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public virtual void Clear()
    {
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (this.OnApply != null && this._taskObjectControl != null)
        this.OnApply((object) this._taskObjectControl.GetTaskObject());
      this.Close();
      this.DialogResult = DialogResult.OK;
    }

    private void BaseDetailForm_Closed(object sender, EventArgs e)
    {
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void BaseTaskObjectForm_Load(object sender, EventArgs e)
    {
      if (this._taskObjectControl == null)
        return;
      this.groupBox1.Controls.Add((Control) this._taskObjectControl);
      this._taskObjectControl.Location = new Point(3, 16);
      this.Size = new Size(this._taskObjectControl.Width + 12, this._taskObjectControl.Height + 80);
      this.MaximumSize = new Size(this._taskObjectControl.Width + 12, this._taskObjectControl.Height + 80);
    }

    public delegate void OnApplyHandler(object o);
  }
}
