// Type: Mephi.K22.LearningSuite.Transport.FF.CreateNetTaskObject
// Assembly: Mephi.K22.LearningSuite.Transport.FF, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DA688CD5-CC79-4F9D-90F5-6DF17C731483
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.Transport.FF.Base;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.FF
{
  public class CreateNetTaskObject : BaseTaskObjectControl
  {
    private Container components = (Container) null;
    private BaseNetControl baseNetControl1;
    private Panel panel1;
    private Panel panel2;
    private TextBox tbName;
    private CheckBox cbEdit;
    private TransportTaskObject _tto;

    public CreateNetTaskObject(TransportTaskObject to)
    {
      this.InitializeComponent();
      this._tto = to;
      this.baseNetControl1.IsCreate = true;
      this.baseNetControl1.EnabledControls = true;
      this.baseNetControl1.Net = this._tto.Net;
      if (this._tto == null)
        return;
      this.tbName.Text = this._tto.Name;
      this.cbEdit.Checked = this._tto.ReqCreate;
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
      this.panel1 = new Panel();
      this.cbEdit = new CheckBox();
      this.tbName = new TextBox();
      this.panel2 = new Panel();
      this.panel1.SuspendLayout();
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
      this.panel1.Controls.Add((Control) this.cbEdit);
      this.panel1.Controls.Add((Control) this.tbName);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(516, 24);
      this.panel1.TabIndex = 1;
      this.cbEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cbEdit.BackColor = SystemColors.Control;
      this.cbEdit.Location = new Point(404, 0);
      this.cbEdit.Name = "cbEdit";
      this.cbEdit.Size = new Size(112, 20);
      this.cbEdit.TabIndex = 1;
      this.cbEdit.Text = "Редактирование";
      this.tbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbName.Location = new Point(4, 0);
      this.tbName.Name = "tbName";
      this.tbName.Size = new Size(396, 20);
      this.tbName.TabIndex = 0;
      this.tbName.Text = "";
      this.panel2.Controls.Add((Control) this.baseNetControl1);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(0, 24);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(516, 316);
      this.panel2.TabIndex = 2;
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Name = "CreateNetTaskObject";
      this.Size = new Size(516, 340);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public override BaseTaskObject GetTaskObject()
    {
      this._tto.Name = this.tbName.Text;
      this._tto.ReqCreate = this.cbEdit.Checked;
      return (BaseTaskObject) this._tto;
    }
  }
}
