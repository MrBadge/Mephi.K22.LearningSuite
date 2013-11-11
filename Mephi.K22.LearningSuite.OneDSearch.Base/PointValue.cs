// Type: Mephi.K22.LearningSuite.OneDSearch.Base.PointValue
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  [Serializable]
  public class PointValue
  {
    private double _coord = 0.0;
    private double _value = 0.0;

    public double Coord
    {
      get
      {
        return this._coord;
      }
      set
      {
        this._coord = value;
      }
    }

    public double Value
    {
      get
      {
        return this._value;
      }
      set
      {
        this._value = value;
      }
    }

    public PointValue()
    {
    }

    public PointValue(double coord, double func)
    {
      this._coord = coord;
      this._value = func;
    }
  }
}
