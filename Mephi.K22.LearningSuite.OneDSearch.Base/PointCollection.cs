// Type: Mephi.K22.LearningSuite.OneDSearch.Base.PointCollection
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;
using System.Collections;
using System.ComponentModel;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class PointCollection : ElementCollection, IBindingList, IList, ICollection, IEnumerable
  {
    public BasePoint this[int index]
    {
      get
      {
        return (BasePoint) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    public int Add(BasePoint value)
    {
      return this.List.Add((object) value);
    }

    public int IndexOf(BasePoint value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, BasePoint value)
    {
      this.List.Insert(index, (object) value);
    }

    public void Remove(BasePoint value)
    {
      this.List.Remove((object) value);
    }

    public bool Contains(BasePoint value)
    {
      return this.List.Contains((object) value);
    }

    public BasePoint GetPoint(double coordX)
    {
      foreach (BasePoint basePoint in (IEnumerable) this.List)
      {
        if (Math.Abs(basePoint.CoordX - coordX) < Constants.DoublePrecision)
          return basePoint;
      }
      return (BasePoint) null;
    }

    public BasePoint GetPoint(double coordX, string name)
    {
      foreach (BasePoint basePoint in (IEnumerable) this.List)
      {
        if (Math.Abs(basePoint.CoordX - coordX) < Constants.DoublePrecision && basePoint.Name == name)
          return basePoint;
      }
      return (BasePoint) null;
    }
  }
}
