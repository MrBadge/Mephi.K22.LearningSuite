// Type: Mephi.K22.LearningSuite.OneDSearch.Base.Diskrete
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class Diskrete : BasePoint
  {
    private PointSaveStub _point = (PointSaveStub) null;
    private bool _isFictiv = false;

    internal PointSaveStub PointStub
    {
      get
      {
        return this._point;
      }
    }

    public bool IsFictive
    {
      get
      {
        return this._isFictiv;
      }
      set
      {
        this._isFictiv = value;
      }
    }

    public Diskrete(PointSaveStub p, int i)
    {
      this._point = p;
      this.CoordX = (double) i;
      this.baseName = this._point.Name;
      this.CreateDrawObject();
    }

    public Diskrete(bool isFictive, int i)
    {
      this._isFictiv = isFictive;
      this._point = (PointSaveStub) null;
      this.CoordX = (double) i;
      this.baseName = "Ф";
      this.CreateDrawObject();
    }
  }
}
