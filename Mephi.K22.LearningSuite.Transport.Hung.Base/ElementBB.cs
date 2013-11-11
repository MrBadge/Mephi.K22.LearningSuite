// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.ElementBB
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public sealed class ElementBB : ElementBase
  {
    private uint _j = 0U;

    public uint J
    {
      get
      {
        return this._j;
      }
    }

    public ElementBB(uint j, int val)
      : base(val)
    {
      this._j = j;
    }
  }
}
