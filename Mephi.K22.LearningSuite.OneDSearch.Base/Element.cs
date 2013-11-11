// Type: Mephi.K22.LearningSuite.OneDSearch.Base.Element
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public abstract class Element
  {
    protected string baseName = string.Empty;
    protected DrawElement protectedDrawObject = (DrawElement) null;
    private bool _isPredefined = false;
    private ElementCollection _parent = (ElementCollection) null;

    public virtual string Name
    {
      get
      {
        return this.baseName;
      }
      set
      {
        this.baseName = value;
      }
    }

    public DrawElement DrawObject
    {
      get
      {
        return this.protectedDrawObject;
      }
      set
      {
        this.protectedDrawObject = value;
      }
    }

    internal ElementCollection Parent
    {
      get
      {
        return this._parent;
      }
      set
      {
        this._parent = value;
      }
    }

    public bool IsPredefined
    {
      get
      {
        return this._isPredefined;
      }
      set
      {
        this._isPredefined = value;
      }
    }

    public bool HitTest(int x, int y)
    {
      return this.protectedDrawObject.HitTest(x, y);
    }
  }
}
