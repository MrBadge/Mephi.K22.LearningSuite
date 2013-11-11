// Type: Mephi.K22.LearningSuite.OneDSearch.Base.DrawSegment
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class DrawSegment : DrawElement
  {
    private float _screenCoordX1 = 0.0f;
    private float _size = 6f;
    private Segment _segment;

    public float ScreenCoordX1
    {
      get
      {
        return this._screenCoordX1;
      }
      set
      {
        this._screenCoordX1 = value;
      }
    }

    internal Segment Segment
    {
      get
      {
        return this._segment;
      }
    }

    internal DrawSegment(Segment segment)
    {
      this._segment = segment;
    }

    public override void Draw(Graphics g, float scale, float zeroPointX, float zeroPointY)
    {
      base.Draw(g, scale, zeroPointX, zeroPointY);
      this.ScreenCoordX = (float) this._segment.StartX * scale + zeroPointX;
      this.ScreenCoordX1 = (float) (this._segment.StartX + this._segment.Length) * scale + zeroPointX;
      if ((double) this.ScreenCoordX == (double) this.ScreenCoordX1)
        return;
      this.ScreenCoordY = (float) -this._segment.StartY + zeroPointY;
      GraphicsPath path = new GraphicsPath();
      path.AddLine(this.ScreenCoordX, this.ScreenCoordY, this.ScreenCoordX1, this.ScreenCoordY);
      path.Widen(DrawPallet.redPenWiden);
      this.DrawRegion = new Region(path);
      Pen pen = !this.IsSelected ? DrawPallet.greenPenW1 : DrawPallet.greenPenW2;
      g.DrawLine(pen, this.ScreenCoordX, this.ScreenCoordY, this.ScreenCoordX1, this.ScreenCoordY);
      g.DrawLine(pen, this.ScreenCoordX, this.ScreenCoordY - this._size / 2f, this.ScreenCoordX, this.ScreenCoordY + this._size / 2f);
      g.DrawLine(pen, this.ScreenCoordX1, this.ScreenCoordY - this._size / 2f, this.ScreenCoordX1, this.ScreenCoordY + this._size / 2f);
      if (this.IsMoving)
      {
        g.DrawLine(DrawPallet.blackPenDotted2, this.ScreenCoordX, this.ScreenCoordY + ((double) this.ScreenCoordY > (double) zeroPointY ? -1f : 1f) * this._size, this.ScreenCoordX, zeroPointY);
        g.DrawLine(DrawPallet.blackPenDotted2, this.ScreenCoordX1, this.ScreenCoordY + ((double) this.ScreenCoordY > (double) zeroPointY ? -1f : 1f) * this._size, this.ScreenCoordX1, zeroPointY);
      }
      Font font = new Font(DrawPallet.FontName, (float) DrawPallet.FontSizeNormal);
      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Center;
      format.LineAlignment = StringAlignment.Near;
      string s = Math.Abs(this._segment.Length).ToString("0.00", (IFormatProvider) new NumberFormatInfo()
      {
        NumberDecimalSeparator = "."
      });
      g.DrawString(s, font, (Brush) DrawPallet.blackBrush, new PointF((float) (((double) this.ScreenCoordX + (double) this.ScreenCoordX1) / 2.0), this.ScreenCoordY), format);
      if (this._segment.Name != string.Empty)
      {
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Far;
        g.DrawString(this._segment.Name, font, (Brush) DrawPallet.blackBrush, new PointF((float) (((double) this.ScreenCoordX + (double) this.ScreenCoordX1) / 2.0), this.ScreenCoordY), format);
      }
      path.Dispose();
    }

    public override void Move(int dx, int dy, float scale)
    {
      this._segment.StartX += (double) dx / (double) scale;
      this._segment.StartY -= (double) dy;
    }
  }
}
