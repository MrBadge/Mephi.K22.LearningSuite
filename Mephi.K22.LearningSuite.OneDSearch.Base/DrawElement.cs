// Type: Mephi.K22.LearningSuite.OneDSearch.Base.DrawElement
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public abstract class DrawElement
  {
    public static readonly int MousePrecision = 5;
    private float _ScreenCoordX = 0.0f;
    private float _ScreenCoordY = 0.0f;
    private bool _showNames = false;
    private bool _isMoving = false;
    private bool _isSelected = false;
    private const SmoothingMode meSmoothingMode = SmoothingMode.HighSpeed;
    protected Region DrawRegion;

    public float ScreenCoordX
    {
      get
      {
        return this._ScreenCoordX;
      }
      set
      {
        this._ScreenCoordX = value;
      }
    }

    public float ScreenCoordY
    {
      get
      {
        return this._ScreenCoordY;
      }
      set
      {
        this._ScreenCoordY = value;
      }
    }

    public bool ShowNames
    {
      get
      {
        return this._showNames;
      }
      set
      {
        this._showNames = value;
      }
    }

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
      g.SmoothingMode = SmoothingMode.HighSpeed;
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
