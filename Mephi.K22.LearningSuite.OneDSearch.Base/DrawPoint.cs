// Type: Mephi.K22.LearningSuite.OneDSearch.Base.DrawPoint
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class DrawPoint : DrawElement
  {
    private float _size = 3f;
    private BasePoint _point;

    internal BasePoint Point
    {
      get
      {
        return this._point;
      }
    }

    internal DrawPoint(BasePoint point)
    {
      this._point = point;
    }

    public override void Draw(Graphics g, float scale, float zeroPointX, float zeroPointY)
    {
      base.Draw(g, scale, zeroPointX, zeroPointY);
      GraphicsPath path = new GraphicsPath();
      this.ScreenCoordX = (float) this._point.CoordX * scale + zeroPointX;
      this.ScreenCoordY = zeroPointY;
      Pen pen = new Pen(Color.Blue);
      path.AddEllipse(this.ScreenCoordX - this._size, this.ScreenCoordY - this._size, 2f * this._size, 2f * this._size);
      path.Widen(DrawPallet.redPenWiden);
      this.DrawRegion = new Region(path);
      SolidBrush solidBrush1;
      SolidBrush solidBrush2;
      if (this.IsSelected)
      {
        solidBrush1 = DrawPallet.redBrush;
        solidBrush2 = DrawPallet.redBrush;
      }
      else
      {
        solidBrush1 = DrawPallet.yellowBrush;
        solidBrush2 = DrawPallet.whiteBrush;
      }
      GraphicsPath graphicsPath = new GraphicsPath();
      graphicsPath.FillMode = FillMode.Winding;
      g.FillEllipse((Brush) solidBrush2, this.ScreenCoordX - this._size, this.ScreenCoordY - this._size, 2f * this._size, 2f * this._size);
      g.DrawEllipse(DrawPallet.blackPen, this.ScreenCoordX - this._size, this.ScreenCoordY - this._size, 2f * this._size, 2f * this._size);
      this._point.CoordX.ToString("0.00", (IFormatProvider) new NumberFormatInfo()
      {
        NumberDecimalSeparator = "."
      });
      Font font = new Font(DrawPallet.FontName, (float) DrawPallet.FontSizeNormal);
      StringFormat format = new StringFormat();
      string s = string.Empty;
      if (this._point is Point)
      {
        if (this._point.Name != string.Empty || this._point.Name != "")
          s = this._point.Name;
      }
      else
      {
        if (this._point is Diskrete && !((Diskrete) this._point).IsFictive)
          s = ((Diskrete) this._point).PointStub.Coord.ToString("0.00");
        if (this._point is Diskrete && ((Diskrete) this._point).IsFictive)
          s = "Ф";
      }
      PointF point = new PointF(this.ScreenCoordX, this.ScreenCoordY);
      format.Alignment = StringAlignment.Near;
      format.LineAlignment = StringAlignment.Far;
      g.DrawString(s, font, (Brush) DrawPallet.blackBrush, point, format);
      graphicsPath.Dispose();
    }

    public override void Move(int dx, int dy, float scale)
    {
    }
  }
}
