// Type: Mephi.K22.LearningSuite.OneDSearch.Base.PointValueCollection
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;
using System.Collections;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  [Serializable]
  public class PointValueCollection : CollectionBase
  {
    public PointValue this[int index]
    {
      get
      {
        return (PointValue) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    public int Add(PointValue value)
    {
      return this.List.Add((object) value);
    }

    public int Add(double coord, double func)
    {
      return this.Add(new PointValue(coord, func));
    }

    public int IndexOf(PointValue value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, PointValue value)
    {
      this.List.Insert(index, (object) value);
    }

    public void Remove(PointValue value)
    {
      this.List.Remove((object) value);
    }

    public bool Contains(PointValue value)
    {
      return this.List.Contains((object) value);
    }
  }
}
