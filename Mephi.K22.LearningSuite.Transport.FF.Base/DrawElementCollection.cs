// Type: Mephi.K22.LearningSuite.Transport.FF.Base.DrawElementCollection
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using System.Collections;
using System.Drawing;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class DrawElementCollection : CollectionBase
  {
    public DrawElement this[int index]
    {
      get
      {
        return (DrawElement) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    public void Draw(Graphics g, float scale, float zeroX, float zeroY)
    {
      for (int index = this.List.Count - 1; index >= 0; --index)
        ((DrawElement) this.List[index]).Draw(g, scale, zeroX, zeroY);
    }

    public int Add(DrawElement value)
    {
      return this.List.Add((object) value);
    }

    public int IndexOf(DrawElement value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, DrawElement value)
    {
      this.List.Insert(index, (object) value);
    }

    public void Remove(DrawElement value)
    {
      this.List.Remove((object) value);
    }

    public bool Contains(DrawElement value)
    {
      return this.List.Contains((object) value);
    }

    public DrawElement GetClicked(int x, int y)
    {
      foreach (DrawElement drawElement in (IEnumerable) this.List)
      {
        if (drawElement.HitTest(x, y))
          return drawElement;
      }
      return (DrawElement) null;
    }

    public void UnselectAll()
    {
      foreach (DrawElement drawElement in (IEnumerable) this.List)
        drawElement.IsSelected = false;
    }
  }
}
