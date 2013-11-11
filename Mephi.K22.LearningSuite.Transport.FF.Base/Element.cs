// Type: Mephi.K22.LearningSuite.Transport.FF.Base.Element
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public abstract class Element
  {
    protected string baseName = string.Empty;
    protected DrawElement protectedDrawObject = (DrawElement) null;
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

    public bool HitTest(int x, int y)
    {
      return this.protectedDrawObject.HitTest(x, y);
    }
  }
}
