// Type: Mephi.K22.LearningSuite.OneDSearch.Base.DrawAxis
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;
using System.Drawing;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class DrawAxis : DrawElement
  {
    internal static float HorizontalPad = 10f;
    internal static float VerticalPad = 10f;
    private float _screenWidth = 0.0f;
    private float _screenHeight = 0.0f;
    private int _triangleH = 12;
    private int _triangleL = 8;

    public float ScreenWidth
    {
      set
      {
        this._screenWidth = value;
      }
    }

    public float ScreenHeight
    {
      set
      {
        this._screenHeight = value;
      }
    }

    static DrawAxis()
    {
    }

    public override void Draw(Graphics g, float scale, float zeroPointX, float zeroPointY)
    {
      base.Draw(g, scale, zeroPointX, zeroPointY);
      g.DrawLine(DrawPallet.grayPen, DrawAxis.HorizontalPad / 2f, zeroPointY, this._screenWidth - DrawAxis.HorizontalPad, zeroPointY);
      g.DrawLine(DrawPallet.grayPen, DrawAxis.HorizontalPad, this._screenHeight - DrawAxis.VerticalPad, DrawAxis.HorizontalPad, DrawAxis.VerticalPad);
      float num1 = (float) -((double) zeroPointX - (double) DrawAxis.HorizontalPad) / scale;
      float num2 = (float) -((double) zeroPointX - ((double) this._screenWidth - (double) DrawAxis.HorizontalPad)) / scale;
      int num3 = (int) Math.Floor((double) num1);
      int num4 = (int) Math.Floor((double) num2);
      Font font = new Font(DrawPallet.FontName, (float) DrawPallet.FontSizeNormal);
      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Center;
      format.LineAlignment = StringAlignment.Center;
      int num5 = num3;
      while (num5 <= num4)
      {
        g.DrawLine(DrawPallet.grayPen, (float) num5 * scale + zeroPointX, zeroPointY + 5f, (float) num5 * scale + zeroPointX, zeroPointY);
        g.DrawLine(DrawPallet.grayPen, (float) num5 * scale + zeroPointX, zeroPointY + 10f, (float) num5 * scale + zeroPointX, zeroPointY + 13f);
        string s = num5.ToString();
        System.Drawing.Point point = new System.Drawing.Point((int) ((double) num5 * (double) scale + (double) zeroPointX), (int) ((double) zeroPointY + 23.0));
        g.DrawString(s, font, (Brush) DrawPallet.blackBrush, (PointF) point, format);
        num5 += (int) Math.Ceiling(30.0 / (double) scale);
      }
      PointF pointF1 = new PointF(this._screenWidth - DrawAxis.HorizontalPad, zeroPointY);
      PointF pointF2 = new PointF(this._screenWidth - DrawAxis.HorizontalPad - (float) this._triangleH, zeroPointY - (float) (this._triangleL / 2));
      PointF pointF3 = new PointF(this._screenWidth - DrawAxis.HorizontalPad - (float) this._triangleH, zeroPointY + (float) (this._triangleL / 2));
      PointF[] points1 = new PointF[3]
      {
        pointF1,
        pointF2,
        pointF3
      };
      g.FillPolygon((Brush) DrawPallet.grayBrush, points1);
      g.DrawPolygon(DrawPallet.grayPen, points1);
      PointF[] pointFArray = (PointF[]) null;
      pointF1 = new PointF(DrawAxis.HorizontalPad, DrawAxis.VerticalPad);
      pointF2 = new PointF(DrawAxis.HorizontalPad - (float) (this._triangleL / 2), DrawAxis.VerticalPad + (float) this._triangleH);
      pointF3 = new PointF(DrawAxis.HorizontalPad + (float) (this._triangleL / 2), DrawAxis.VerticalPad + (float) this._triangleH);
      PointF[] points2 = new PointF[3]
      {
        pointF1,
        pointF2,
        pointF3
      };
      g.FillPolygon((Brush) DrawPallet.grayBrush, points2);
      g.DrawPolygon(DrawPallet.grayPen, points2);
      pointFArray = (PointF[]) null;
      PointF point1 = new PointF(this._screenWidth - DrawAxis.HorizontalPad, zeroPointY);
      format.Alignment = StringAlignment.Far;
      format.LineAlignment = StringAlignment.Near;
      g.DrawString("x", font, (Brush) DrawPallet.blackBrush, point1, format);
      point1 = new PointF(DrawAxis.HorizontalPad, DrawAxis.VerticalPad);
      format.Alignment = StringAlignment.Near;
      format.LineAlignment = StringAlignment.Near;
      g.DrawString("F(x)", font, (Brush) DrawPallet.blackBrush, point1, format);
    }
  }
}
