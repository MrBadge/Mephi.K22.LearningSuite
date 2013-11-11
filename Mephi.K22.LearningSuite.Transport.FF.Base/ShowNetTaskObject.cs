// Type: Mephi.K22.LearningSuite.Transport.FF.Base.ShowNetTaskObject
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using Mephi.K22.LearningSuite.Core;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class ShowNetTaskObject : BaseTaskObjectControl
  {
    private Container components = (Container) null;
    protected internal BaseNetControl baseNetControl1;
    private Panel panel2;
    private TextBox tbName;
    public Panel panelTop;
    private CheckBox cbEdit;

    public ShowNetTaskObject(string name, Net net, bool enableEdit)
    {
      this.InitializeComponent();
      this.baseNetControl1.IsCreate = true;
      this.cbEdit.Checked = enableEdit;
      this.baseNetControl1.EnabledControls = enableEdit;
      this.baseNetControl1.Net = net;
      this.tbName.Text = name;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.baseNetControl1 = new BaseNetControl();
      this.panelTop = new Panel();
      this.cbEdit = new CheckBox();
      this.tbName = new TextBox();
      this.panel2 = new Panel();
      this.panelTop.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.baseNetControl1.Actions = (ActionCollection) null;
      this.baseNetControl1.Dock = DockStyle.Fill;
      this.baseNetControl1.EnabledControls = false;
      this.baseNetControl1.IsCreate = true;
      this.baseNetControl1.IsOver = false;
      this.baseNetControl1.Location = new Point(0, 0);
      this.baseNetControl1.Name = "baseNetControl1";
      this.baseNetControl1.Net = (Net) null;
      this.baseNetControl1.Size = new Size(516, 316);
      this.baseNetControl1.TabIndex = 0;
      this.baseNetControl1.Task = (Task) null;
      this.panelTop.Controls.Add((Control) this.cbEdit);
      this.panelTop.Controls.Add((Control) this.tbName);
      this.panelTop.Dock = DockStyle.Top;
      this.panelTop.Location = new Point(0, 0);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new Size(516, 24);
      this.panelTop.TabIndex = 1;
      this.cbEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cbEdit.BackColor = SystemColors.Control;
      this.cbEdit.Enabled = false;
      this.cbEdit.Location = new Point(400, 2);
      this.cbEdit.Name = "cbEdit";
      this.cbEdit.Size = new Size(112, 20);
      this.cbEdit.TabIndex = 2;
      this.cbEdit.Text = "Редактирование";
      this.tbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbName.Location = new Point(4, 0);
      this.tbName.Name = "tbName";
      this.tbName.ReadOnly = true;
      this.tbName.Size = new Size(392, 20);
      this.tbName.TabIndex = 0;
      this.tbName.Text = "";
      this.panel2.Controls.Add((Control) this.baseNetControl1);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(0, 24);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(516, 316);
      this.panel2.TabIndex = 2;
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panelTop);
      this.Name = "ShowNetTaskObject";
      this.Size = new Size(516, 340);
      this.panelTop.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
