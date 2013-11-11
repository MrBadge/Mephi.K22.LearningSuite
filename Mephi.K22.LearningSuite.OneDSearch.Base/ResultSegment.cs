// Type: Mephi.K22.LearningSuite.OneDSearch.Base.ResultSegment
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class ResultSegment : Element
  {
    private double _startX = 1.0;
    private double _endX = 1.0;

    public double StartX
    {
      get
      {
        return this._startX;
      }
      set
      {
        this._startX = value;
        if (this.Parent == null)
          return;
        this.Parent.ElementChanged((Element) this);
      }
    }

    public double EndX
    {
      get
      {
        return this._endX;
      }
      set
      {
        this._endX = value;
        if (this.Parent == null)
          return;
        this.Parent.ElementChanged((Element) this);
      }
    }

    public ResultSegment(double startX)
    {
      this._startX = startX;
      this._endX = startX + 4.94065645841247E-324;
      this.DrawObject = (DrawElement) new DrawResultSegment(this);
    }

    public delegate void ResultSegmentEvent(ResultSegment rs);
  }
}
