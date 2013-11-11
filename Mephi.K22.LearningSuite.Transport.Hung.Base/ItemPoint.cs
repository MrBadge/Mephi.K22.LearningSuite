// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.ItemPoint
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public class ItemPoint
  {
    private PointType _type;
    private int _num;

    public int Number
    {
      get
      {
        return this._num;
      }
    }

    public PointType PointType
    {
      get
      {
        return this._type;
      }
    }

    public ItemPoint(int num, PointType type)
    {
      this._num = num;
      this._type = type;
    }

    public override string ToString()
    {
      if (this._type == PointType.source)
        return "исток";
      if (this._type == PointType.target)
        return "сток";
      if (this._type == PointType.factory)
        return string.Format("п. производства {0}", (object) this._num);
      if (this._type == PointType.consumer)
        return string.Format("п. потребления {0}", (object) this._num);
      else
        return "";
    }
  }
}
