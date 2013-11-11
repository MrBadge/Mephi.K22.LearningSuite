// Type: Mephi.K22.LearningSuite.Core.VariantCollection
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.Collections;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public class VariantCollection : CollectionBase
  {
    public Variant this[int index]
    {
      get
      {
        return (Variant) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    public int Add(Variant value)
    {
      return this.List.Add((object) value);
    }

    public void Remove(Variant value)
    {
      this.List.Remove((object) value);
    }

    public int IndexOf(Variant value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, Variant value)
    {
      this.List.Insert(index, (object) value);
    }

    public bool Contains(Variant value)
    {
      return this.List.Contains((object) value);
    }
  }
}
