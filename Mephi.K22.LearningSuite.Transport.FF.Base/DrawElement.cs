// Type: Mephi.K22.LearningSuite.Transport.FF.Base.DrawElement
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public abstract class DrawElement
  {
    public static readonly int MousePrecision = 5;
    private bool _isMoving = false;
    private bool _isSelected = false;
    private const SmoothingMode meSmoothingMode = SmoothingMode.AntiAlias;
    protected Region DrawRegion;

    public bool IsMoving
    {
      get
      {
        return this._isMoving;
      }
      set
      {
        this._isMoving = value;
      }
    }

    public bool IsSelected
    {
      get
      {
        return this._isSelected;
      }
      set
      {
        this._isSelected = value;
      }
    }

    static DrawElement()
    {
    }

    public virtual void Draw(Graphics g, float scale, float zeroPointX, float zeroPointY)
    {
      g.SmoothingMode = SmoothingMode.AntiAlias;
    }

    public virtual bool HitTest(int x, int y)
    {
      return this.DrawRegion != null && this.DrawRegion.IsVisible((float) x, (float) y);
    }

    public virtual void Move(int dx, int dy, float scale)
    {
    }
  }
}
