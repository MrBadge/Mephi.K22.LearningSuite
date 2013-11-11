// Type: Mephi.K22.LearningSuite.Core.BaseTreeListControl
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using DevExpress.XtraTreeList;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Core
{
  public class BaseTreeListControl : BaseControl
  {
    private Container components = (Container) null;
    private ToolBar toolBar;
    public Panel panelFilter;
    public TreeList treeList;

    public BaseTreeListControl()
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
      this.treeList = new TreeList();
      this.toolBar = new ToolBar();
      this.panelFilter = new Panel();
      this.treeList.BeginInit();
      this.SuspendLayout();
      this.treeList.Dock = DockStyle.Fill;
      this.treeList.Location = new Point(0, 88);
      this.treeList.Name = "treeList";
      this.treeList.Size = new Size(640, 208);
      this.treeList.TabIndex = 0;
      this.toolBar.DropDownArrows = true;
      this.toolBar.Location = new Point(0, 0);
      this.toolBar.Name = "toolBar";
      this.toolBar.ShowToolTips = true;
      this.toolBar.Size = new Size(640, 42);
      this.toolBar.TabIndex = 1;
      this.panelFilter.Dock = DockStyle.Top;
      this.panelFilter.Location = new Point(0, 42);
      this.panelFilter.Name = "panelFilter";
      this.panelFilter.Size = new Size(640, 46);
      this.panelFilter.TabIndex = 2;
      this.Controls.Add((Control) this.treeList);
      this.Controls.Add((Control) this.panelFilter);
      this.Controls.Add((Control) this.toolBar);
      this.Name = "BaseTreeListControl";
      this.Size = new Size(640, 296);
      this.treeList.EndInit();
      this.ResumeLayout(false);
    }
  }
}
