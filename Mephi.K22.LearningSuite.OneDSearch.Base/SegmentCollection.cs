// Type: Mephi.K22.LearningSuite.OneDSearch.Base.SegmentCollection
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;
using System.Collections;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class SegmentCollection : ElementCollection
  {
    public Segment this[int index]
    {
      get
      {
        return (Segment) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    public override int Add(Element value)
    {
      return this.List.Add((object) value);
    }

    public int IndexOf(Segment value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, Segment value)
    {
      this.List.Insert(index, (object) value);
    }

    public void Remove(Segment value)
    {
      this.List.Remove((object) value);
    }

    public bool Contains(Segment value)
    {
      return this.List.Contains((object) value);
    }

    public double MinY()
    {
      if (this.List == null)
        return 0.0;
      double num = double.MaxValue;
      foreach (Segment segment in (IEnumerable) this.List)
        num = segment.StartY;
      return num == double.MaxValue ? 0.0 : num;
    }

    public Segment GetSegment(double len, string name)
    {
      foreach (Segment segment in (IEnumerable) this.List)
      {
        if (Math.Abs(segment.Length - len) < Constants.DoublePrecision && segment.Name.Equals(name))
          return segment;
      }
      return (Segment) null;
    }
  }
}
