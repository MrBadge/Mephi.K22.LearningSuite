// Type: Mephi.K22.LearningSuite.Core.BaseContainerForm
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Core
{
  public class BaseContainerForm : Form
  {
    private Container components = (Container) null;
    private byte _formType;
    public BaseControl gridWorkSpaceControl;

    public virtual byte FormType
    {
      get
      {
        return this._formType;
      }
      set
      {
        this._formType = value;
      }
    }

    public event BaseContainerForm.formClosingDelegate formClosing;

    public event EventHandler formActivated;

    public BaseContainerForm()
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
      ResourceManager resourceManager = new ResourceManager(typeof (BaseContainerForm));
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(692, 473);
      this.Icon = (Icon) resourceManager.GetObject("$this.Icon");
      this.Name = "BaseContainerForm";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Closing += new CancelEventHandler(this.WorkSpace_Closing);
      this.Load += new EventHandler(this.ContainerForm_Load);
      this.Activated += new EventHandler(this.BaseContainerForm_Activated);
    }

    private void ContainerForm_Load(object sender, EventArgs e)
    {
      if (this.gridWorkSpaceControl == null)
        return;
      this.Controls.Add((Control) this.gridWorkSpaceControl);
      this.gridWorkSpaceControl.Dock = DockStyle.Fill;
    }

    private void WorkSpace_Closing(object sender, CancelEventArgs e)
    {
      if (this.formClosing == null)
        return;
      this.formClosing(this.FormType);
    }

    private void BaseContainerForm_Activated(object sender, EventArgs e)
    {
      this.Activate();
      if (this.formActivated == null)
        return;
      this.formActivated(sender, e);
    }

    public delegate void formClosingDelegate(byte formName);
  }
}
