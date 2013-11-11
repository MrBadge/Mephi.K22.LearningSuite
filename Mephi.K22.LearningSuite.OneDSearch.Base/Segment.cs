// Type: Mephi.K22.LearningSuite.OneDSearch.Base.Segment
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class Segment : Element
  {
    private static int _YCount = 0;
    private double _startX = 1.0;
    private double _startY = -40.0;
    private double _length = 0.0;

    public double DisplayLength
    {
      get
      {
        return this._length;
      }
    }

    public double Length
    {
      get
      {
        return this._length;
      }
      set
      {
        this._length = value;
        if (this.Parent == null)
          return;
        this.Parent.ElementChanged((Element) this);
      }
    }

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

    public double StartY
    {
      get
      {
        return this._startY;
      }
      set
      {
        this._startY = value;
        if (this.Parent == null)
          return;
        this.Parent.ElementChanged((Element) this);
      }
    }

    public static int SegmentCount
    {
      get
      {
        return Segment._YCount;
      }
      set
      {
        Segment._YCount = value;
      }
    }

    static Segment()
    {
    }

    public Segment(double length)
    {
      this._length = length;
      this.Name = string.Format("L{0}", (object) Segment._YCount);
      ++Segment._YCount;
      this.DrawObject = (DrawElement) new DrawSegment(this);
    }

    public Segment(string name, double length)
    {
      this._length = length;
      this.Name = name;
      ++Segment._YCount;
      this.DrawObject = (DrawElement) new DrawSegment(this);
    }

    public delegate void SegmentEvent(Segment s);

    public delegate void SegmentCollectionEvent(SegmentCollection p);

    public delegate void CreateSegmentByLengthHandler(double len);

    public delegate void CreateSegmentByFibHandler(Segment s, int num);

    public delegate void CreateSegmentBy2PointsHandler(BasePoint p1, BasePoint p2, double x, double y);
  }
}
