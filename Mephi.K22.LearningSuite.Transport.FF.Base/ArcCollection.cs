// Type: Mephi.K22.LearningSuite.Transport.FF.Base.ArcCollection
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class ArcCollection : ElementCollection
  {
    public Arc this[int index]
    {
      get
      {
        return (Arc) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    public int Add(Arc value)
    {
      return this.List.Add((object) value);
    }

    public int IndexOf(Arc value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, Arc value)
    {
      this.List.Insert(index, (object) value);
    }

    public void Remove(Arc value)
    {
      this.List.Remove((object) value);
    }

    public bool Contains(Arc value)
    {
      return this.List.Contains((object) value);
    }
  }
}
