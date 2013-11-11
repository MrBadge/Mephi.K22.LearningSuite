// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.ElementBase
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public abstract class ElementBase
  {
    private int _val = int.MinValue;

    public int Val
    {
      get
      {
        return this._val;
      }
      set
      {
        this._val = value;
      }
    }

    public ElementBase(int val)
    {
      this._val = val;
    }
  }
}
