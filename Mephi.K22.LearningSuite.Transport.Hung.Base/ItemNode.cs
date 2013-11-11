// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.ItemNode
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public class ItemNode
  {
    private int _number = 0;

    public int Number
    {
      get
      {
        return this._number;
      }
    }

    public ItemNode(int number)
    {
      this._number = number;
    }

    public override string ToString()
    {
      return string.Format("вершина {0}", (object) this._number);
    }
  }
}
