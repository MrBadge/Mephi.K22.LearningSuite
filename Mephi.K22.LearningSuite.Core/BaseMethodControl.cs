// Type: Mephi.K22.LearningSuite.Core.BaseMethodControl
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System.ComponentModel;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Core
{
  public class BaseMethodControl : UserControl
  {
    private Container components = (Container) null;

    public BaseMethodControl()
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
      this.components = new Container();
    }
  }
}
