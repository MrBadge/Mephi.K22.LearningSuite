// Type: Mephi.K22.LearningSuite.OneDSearch.Base.DrawFuncButton
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class DrawFuncButton : DrawElement
  {
    private float _buttonSize = 6f;
    private float _calcSize = 4f;
    private float _buttonHeight = 20f;
    private FuncButton _button;

    internal FuncButton FuncButton
    {
      get
      {
        return this._button;
      }
    }

    internal DrawFuncButton(FuncButton button)
    {
      this._button = button;
    }

    public override void Draw(Graphics g, float scale, float zeroPointX, float zeroPointY)
    {
      base.Draw(g, scale, zeroPointX, zeroPointY);
      GraphicsPath path = new GraphicsPath();
      this.ScreenCoordX = (float) this._button.CoordX * scale + zeroPointX;
      this.ScreenCoordY = zeroPointY;
      Pen pen = new Pen(Color.Blue);
      if (!this._button.IsEval)
      {
        PointF[] points = new PointF[3]
        {
          new PointF(this.ScreenCoordX, this.ScreenCoordY - this._buttonSize - this._buttonHeight),
          new PointF(this.ScreenCoordX - (float) ((double) this._buttonSize * Math.Sqrt(3.0) / 2.0), (float) ((double) this.ScreenCoordY - (double) this._buttonHeight + (double) this._buttonSize / 2.0)),
          new PointF(this.ScreenCoordX + (float) ((double) this._buttonSize * Math.Sqrt(3.0) / 2.0), (float) ((double) this.ScreenCoordY - (double) this._buttonHeight + (double) this._buttonSize / 2.0))
        };
        path.AddPolygon(points);
        path.Widen(DrawPallet.redPenWiden);
      }
      else
      {
        float num = zeroPointY - (float) this._button.FuncValue * scale;
        path.AddEllipse(this.ScreenCoordX - this._calcSize, num - this._calcSize, this._calcSize * 2f, this._calcSize * 2f);
      }
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
      if (!this._button.IsEval)
      {
        PointF[] points = new PointF[3]
        {
          new PointF(this.ScreenCoordX, this.ScreenCoordY - this._buttonHeight - this._buttonSize),
          new PointF(this.ScreenCoordX - (float) ((double) this._buttonSize * Math.Sqrt(3.0) / 2.0), (float) ((double) this.ScreenCoordY - (double) this._buttonHeight + (double) this._buttonSize / 2.0)),
          new PointF(this.ScreenCoordX + (float) ((double) this._buttonSize * Math.Sqrt(3.0) / 2.0), (float) ((double) this.ScreenCoordY - (double) this._buttonHeight + (double) this._buttonSize / 2.0))
        };
        g.FillPolygon((Brush) DrawPallet.grayBrush, points);
        g.DrawPolygon(DrawPallet.blackPen, points);
      }
      else
      {
        float num = zeroPointY - (float) this._button.FuncValue * scale;
        g.DrawLine(DrawPallet.blackPenDotted1, this.ScreenCoordX, this.ScreenCoordY, this.ScreenCoordX, num);
        g.DrawLine(DrawPallet.blackPenDotted1, DrawAxis.HorizontalPad, num, this.ScreenCoordX, num);
        g.FillEllipse((Brush) solidBrush1, this.ScreenCoordX - this._calcSize, num - this._calcSize, this._calcSize * 2f, this._calcSize * 2f);
        g.DrawEllipse(DrawPallet.blackPen, this.ScreenCoordX - this._calcSize, num - this._calcSize, this._calcSize * 2f, this._calcSize * 2f);
        string s = this._button.FuncValue.ToString("0.00", (IFormatProvider) new NumberFormatInfo()
        {
          NumberDecimalSeparator = "."
        });
        PointF point = new PointF(this.ScreenCoordX, num);
        Font font = new Font(DrawPallet.FontName, (float) DrawPallet.FontSizeNormal);
        g.DrawString(s, font, (Brush) DrawPallet.blackBrush, point, new StringFormat()
        {
          Alignment = StringAlignment.Center,
          LineAlignment = this._button.FuncValue <= 0.0 ? StringAlignment.Near : StringAlignment.Far
        });
      }
      graphicsPath.Dispose();
    }

    public override void Move(int dx, int dy, float scale)
    {
    }
  }
}
