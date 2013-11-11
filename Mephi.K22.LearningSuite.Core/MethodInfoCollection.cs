// Type: Mephi.K22.LearningSuite.Core.MethodInfoCollection
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.Collections;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public sealed class MethodInfoCollection : CollectionBase
  {
    public ThemeMethodCollection this[int index]
    {
      get
      {
        return (ThemeMethodCollection) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    public int Add(ThemeMethodCollection value)
    {
      return this.List.Add((object) value);
    }

    public int IndexOf(ThemeMethodCollection value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, ThemeMethodCollection value)
    {
      this.List.Insert(index, (object) value);
    }

    public void Remove(ThemeMethodCollection value)
    {
      this.List.Remove((object) value);
    }

    public bool Contains(ThemeMethodCollection value)
    {
      return this.List.Contains((object) value);
    }

    public ThemeMethodCollection ToMethodInfoCollection()
    {
      int num = 0;
      foreach (CollectionBase collectionBase in (IEnumerable) this.List)
      {
        foreach (MethodInfo methodInfo in collectionBase)
          ++num;
      }
      ThemeMethodCollection methodCollection = new ThemeMethodCollection();
      foreach (CollectionBase collectionBase in (IEnumerable) this.List)
      {
        foreach (MethodInfo methodInfo in collectionBase)
        {
          methodCollection.Add(methodInfo.Clone());
          ++num;
        }
      }
      return methodCollection;
    }
  }
}
