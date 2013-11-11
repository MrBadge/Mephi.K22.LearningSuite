// Type: Mephi.K22.LearningSuite.OneDSearch.Base.BasePoint
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public abstract class BasePoint : Element
  {
    private double _coordX = 0.0;
    private FuncButton _funcButton = (FuncButton) null;
    private static int _pointCounter = 0;

    public double DisplayCoordX
    {
      get
      {
        return this._coordX;
      }
    }

    public double CoordX
    {
      get
      {
        return this._coordX;
      }
      set
      {
        this._coordX = value;
        if (this.Parent == null)
          return;
        this.Parent.ElementChanged((Element) this);
      }
    }

    public FuncButton FuncButton
    {
      get
      {
        return this._funcButton;
      }
      set
      {
        this._funcButton = value;
        if (this.Parent == null)
          return;
        this.Parent.ElementChanged((Element) this);
      }
    }

    public string DisplayFuncValue
    {
      get
      {
        if (this._funcButton != null && this._funcButton.IsEval)
          return this._funcButton.FuncValue.ToString("0.0000");
        else
          return string.Empty;
      }
    }

    public static int PointCounter
    {
      get
      {
        return BasePoint._pointCounter;
      }
      set
      {
        BasePoint._pointCounter = value;
      }
    }

    public override string Name
    {
      get
      {
        return this.baseName;
      }
      set
      {
        this.Name = value;
        if (this.Parent == null)
          return;
        this.Parent.ElementChanged((Element) this);
      }
    }

    static BasePoint()
    {
    }

    protected virtual void CreateDrawObject()
    {
      this.DrawObject = (DrawElement) new DrawPoint(this);
    }
  }
}
