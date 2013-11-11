// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.ElementAA
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public sealed class ElementAA : ElementBase
  {
    private uint _i = 0U;

    public uint I
    {
      get
      {
        return this._i;
      }
    }

    public ElementAA(uint i, int val)
      : base(val)
    {
      this._i = i;
    }
  }
}
