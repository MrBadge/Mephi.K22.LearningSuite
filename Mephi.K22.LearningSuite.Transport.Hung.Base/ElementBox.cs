// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.ElementBox
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public class ElementBox : TextBox
  {
    private Container components = (Container) null;
    private bool _isSelect = false;
    private ElementBase _element;

    public ElementBase Element
    {
      get
      {
        return this._element;
      }
      set
      {
        this._element = value;
      }
    }

    public bool IsSelect
    {
      get
      {
        return this._isSelect;
      }
      set
      {
        this._isSelect = value;
        if (this._isSelect)
          this.BackColor = Color.Yellow;
        else
          this.BackColor = Color.White;
      }
    }

    public ElementBox()
    {
      this.InitializeComponent();
      this.BackColor = Color.White;
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
