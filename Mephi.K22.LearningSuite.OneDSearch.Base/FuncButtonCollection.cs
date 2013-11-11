// Type: Mephi.K22.LearningSuite.OneDSearch.Base.FuncButtonCollection
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;
using System.Collections;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class FuncButtonCollection : ElementCollection
  {
    public FuncButton this[int index]
    {
      get
      {
        return (FuncButton) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    public int Add(FuncButton value)
    {
      return this.List.Add((object) value);
    }

    public int IndexOf(FuncButton value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, FuncButton value)
    {
      this.List.Insert(index, (object) value);
    }

    public void Remove(FuncButton value)
    {
      this.List.Remove((object) value);
    }

    public bool Contains(FuncButton value)
    {
      return this.List.Contains((object) value);
    }

    public FuncButton GetButton(double coordX)
    {
      FuncButton funcButton1 = (FuncButton) null;
      foreach (FuncButton funcButton2 in (IEnumerable) this.List)
      {
        if (Math.Abs(funcButton2.CoordX - coordX) < Constants.DoublePrecision)
          funcButton1 = funcButton2;
      }
      return funcButton1;
    }

    public FuncButton GetButton(double coordX, string pointName)
    {
      FuncButton funcButton1 = (FuncButton) null;
      foreach (FuncButton funcButton2 in (IEnumerable) this.List)
      {
        if (Math.Abs(funcButton2.CoordX - coordX) < Constants.DoublePrecision && funcButton2.point.Name == pointName)
          funcButton1 = funcButton2;
      }
      return funcButton1;
    }
  }
}
