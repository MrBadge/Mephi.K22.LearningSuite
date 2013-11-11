// Type: Mephi.K22.LearningSuite.OneDSearch.Base.DrawElementCollection
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System.Collections;
using System.Drawing;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
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
