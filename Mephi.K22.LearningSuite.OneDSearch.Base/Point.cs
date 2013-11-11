// Type: Mephi.K22.LearningSuite.OneDSearch.Base.Point
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class Point : BasePoint
  {
    public Point(double coordX)
      : this(coordX, string.Format("X{0}", (object) BasePoint.PointCounter))
    {
    }

    public Point(double coordX, string name)
    {
      this.CoordX = coordX;
      this.baseName = name;
      ++BasePoint.PointCounter;
      this.CreateDrawObject();
    }

    public delegate void PointEvent(BasePoint p);

    public delegate void CreatePointBySegmentHandler(BasePoint p, Segment s, Direction d);

    public delegate void PointCollectionEvent(PointCollection pCol);

    public delegate void Point2PointsEvent(BasePoint p1, BasePoint p2);

    public delegate void CreatePointByCoordHandler(double x);
  }
}
