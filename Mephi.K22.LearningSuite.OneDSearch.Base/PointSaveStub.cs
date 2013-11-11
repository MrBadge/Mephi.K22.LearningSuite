// Type: Mephi.K22.LearningSuite.OneDSearch.Base.PointSaveStub
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  [Serializable]
  public class PointSaveStub
  {
    private double _coord;
    private string _name;
    private bool _isEval;
    private double _fx;

    public double Coord
    {
      get
      {
        return this._coord;
      }
    }

    public string Name
    {
      get
      {
        return this._name;
      }
    }

    public bool IsEval
    {
      get
      {
        return this._isEval;
      }
    }

    public double Fx
    {
      get
      {
        return this._fx;
      }
    }

    public PointSaveStub(double coord, string name, bool isEval, double fx)
    {
      this._coord = coord;
      this._name = name;
      this._fx = fx;
      this._isEval = isEval;
    }
  }
}
