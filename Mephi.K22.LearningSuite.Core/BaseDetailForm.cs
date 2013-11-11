// Type: Mephi.K22.LearningSuite.Core.BaseDetailForm
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Core
{
  public class BaseDetailForm : Form
  {
    public bool isEdit = false;
    private Container components = (Container) null;
    public Button btnCancel;
    public Button btnOk;

    public event BaseDetailForm.OnAddSaveDelegate OnAddSave;

    public event BaseDetailForm.OnEditSaveDelegate OnEditSave;

    public event BaseDetailForm.OnCloseDelegate OnClose;

    public BaseDetailForm()
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
      this.SuspendLayout();
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(280, 232);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.TabIndex = 0;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOk.Location = new Point(360, 232);
      this.btnOk.Name = "btnOk";
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "OK";
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(440, 261);
      this.Controls.Add((Control) this.btnOk);
      this.Controls.Add((Control) this.btnCancel);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "BaseDetailForm";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "DetailForm";
      this.Closed += new EventHandler(this.BaseDetailForm_Closed);
      this.ResumeLayout(false);
    }

    public virtual void Clear()
    {
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (this.isEdit)
        this.OnEditSave();
      else
        this.OnAddSave();
      this.Close();
      this.DialogResult = DialogResult.OK;
    }

    private void BaseDetailForm_Closed(object sender, EventArgs e)
    {
      this.OnClose();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    public delegate void OnAddSaveDelegate();

    public delegate void OnEditSaveDelegate();

    public delegate void OnCloseDelegate();
  }
}
