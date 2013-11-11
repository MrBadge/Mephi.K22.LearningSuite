// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.ElementCD
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public sealed class ElementCD : ElementBase
  {
    private uint _i = 0U;
    private uint _j = 0U;
    private bool _isSelected = false;

    public uint I
    {
      get
      {
        return this._i;
      }
    }

    public uint J
    {
      get
      {
        return this._j;
      }
    }

    public bool IsSelected
    {
      get
      {
        return this._isSelected;
      }
      set
      {
        this._isSelected = value;
      }
    }

    public ElementCD(uint i, uint j, int val, bool isSelected)
      : base(val)
    {
      this._i = i;
      this._j = j;
      this._isSelected = isSelected;
    }
  }
}
