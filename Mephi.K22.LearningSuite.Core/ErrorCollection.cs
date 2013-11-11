// Type: Mephi.K22.LearningSuite.Core.ErrorCollection
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System.Collections;

namespace Mephi.K22.LearningSuite.Core
{
  public class ErrorCollection : CollectionBase
  {
    public Error this[int index]
    {
      get
      {
        return (Error) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    public int Add(Error value)
    {
      return this.List.Add((object) value);
    }

    public int IndexOf(Error value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, Error value)
    {
      this.List.Insert(index, (object) value);
    }

    public void Remove(Error value)
    {
      this.List.Remove((object) value);
    }

    public bool Contains(Error value)
    {
      return this.List.Contains((object) value);
    }
  }
}
