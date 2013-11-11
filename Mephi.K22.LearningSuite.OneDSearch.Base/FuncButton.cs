// Type: Mephi.K22.LearningSuite.OneDSearch.Base.FuncButton
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class FuncButton : Element
  {
    private double _funcValue = double.MinValue;
    private BasePoint _point = (BasePoint) null;
    private bool _isEval = false;

    public double RealCoordX
    {
      get
      {
        if (this._point is Point)
          return this._point.CoordX;
        if (this._point is Diskrete)
          return ((Diskrete) this._point).PointStub.Coord;
        else
          throw new NotImplementedException();
      }
    }

    public double CoordX
    {
      get
      {
        return this._point.CoordX;
      }
    }

    public bool IsEval
    {
      get
      {
        return this._isEval;
      }
      set
      {
        this._isEval = value;
      }
    }

    public double FuncValue
    {
      get
      {
        return this._funcValue;
      }
    }

    public BasePoint point
    {
      get
      {
        return this._point;
      }
    }

    public FuncButton(double funcValue, BasePoint point)
    {
      this._funcValue = funcValue;
      this._point = point;
      this._isEval = true;
      point.FuncButton = this;
      this.DrawObject = (DrawElement) new DrawFuncButton(this);
    }

    public FuncButton(BasePoint point)
    {
      this._isEval = false;
      this._point = point;
      this._funcValue = double.MinValue;
      point.FuncButton = this;
      this.DrawObject = (DrawElement) new DrawFuncButton(this);
    }

    public void SetFuncValue(double val)
    {
      this._funcValue = val;
      this._isEval = true;
      if (this.Parent != null)
        this.Parent.ElementChanged((Element) this);
      this._point.CoordX += 0.0;
    }

    public void ResetValue()
    {
      this._funcValue = double.MinValue;
      this._isEval = false;
      this._point.CoordX += 0.0;
    }

    public delegate void FuncButtonEvent(FuncButton p);
  }
}
