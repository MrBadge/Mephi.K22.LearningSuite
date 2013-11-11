// Type: Mephi.K22.LearningSuite.Core.ThemeMethodCollection
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.Collections;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public sealed class ThemeMethodCollection : CollectionBase
  {
    public MethodInfo this[int index]
    {
      get
      {
        return (MethodInfo) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    public int Add(MethodInfo value)
    {
      return this.List.Add((object) value);
    }

    public int IndexOf(MethodInfo value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, MethodInfo value)
    {
      this.List.Insert(index, (object) value);
    }

    public void Remove(MethodInfo value)
    {
      this.List.Remove((object) value);
    }

    public bool Contains(MethodInfo value)
    {
      return this.List.Contains((object) value);
    }
  }
}
