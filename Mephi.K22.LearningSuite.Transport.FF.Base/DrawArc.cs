// Type: Mephi.K22.LearningSuite.Transport.FF.Base.DrawArc
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class DrawArc : DrawElement
  {
    public const int LenghtS = 70;
    public const int HeightS = 15;
    private const int _B = 7;
    private const int _A = 15;
    private Arc _arc;

    public DrawArc(Arc arc)
    {
      this._arc = arc;
      this._arc.DrawObject = (DrawElement) this;
    }

    public override void Draw(Graphics g, float scale, float zeroPointX, float zeroPointY)
    {
      base.Draw(g, scale, zeroPointX, zeroPointY);
      GraphicsPath path1 = new GraphicsPath();
      if (this._arc.EndX == this._arc.StartX && this._arc.EndY == this._arc.StartY)
        this._arc.EndX = this._arc.EndX + 1;
      path1.AddLine(this._arc.StartX, this._arc.StartY, this._arc.EndX, this._arc.EndY);
      Pen pen1 = new Pen(Color.Blue, 15f);
      path1.Widen(pen1);
      this.DrawRegion = new Region(path1);
      pen1.Dispose();
      path1.Dispose();
      if (this._arc.IsFinished)
      {
        GraphicsPath path2 = new GraphicsPath();
        path2.AddEllipse(this._arc.EndX - DrawNode.radius, this._arc.EndY - DrawNode.radius, 2 * DrawNode.radius, 2 * DrawNode.radius);
        this.DrawRegion.Exclude(path2);
        path2.Dispose();
        GraphicsPath path3 = new GraphicsPath();
        path3.AddEllipse(this._arc.StartX - DrawNode.radius, this._arc.StartY - DrawNode.radius, 2 * DrawNode.radius, 2 * DrawNode.radius);
        this.DrawRegion.Exclude(path3);
        path3.Dispose();
      }
      double num1 = Math.PI / 2.0;
      double x1 = (double) (this._arc.EndX - this._arc.StartX);
      double x2 = (double) (this._arc.EndY - this._arc.StartY);
      double num2 = Math.Sqrt(Math.Pow(x1, 2.0) + Math.Pow(x2, 2.0));
      double num3 = (double) DrawNode.radius / num2;
      double num4 = (double) (DrawNode.radius + 15) / num2;
      double num5 = 15.0 / num2;
      double num6 = this._arc.StartX == this._arc.EndX ? num1 : Math.Atan(1.0 * x2 / (1.0 * x1));
      int num7;
      int num8;
      int x1_1;
      int y1;
      int num9;
      int num10;
      if (this._arc.IsFinished)
      {
        num7 = (int) ((double) this._arc.StartX + x1 * (1.0 - num3));
        num8 = (int) ((double) this._arc.StartY + x2 * (1.0 - num3));
        x1_1 = (int) ((double) this._arc.StartX + x1 * num3);
        y1 = (int) ((double) this._arc.StartY + x2 * num3);
        num9 = (int) ((double) this._arc.StartX + x1 * (1.0 - num4));
        num10 = (int) ((double) this._arc.StartY + x2 * (1.0 - num4));
      }
      else
      {
        x1_1 = this._arc.StartX;
        y1 = this._arc.StartY;
        num9 = (int) ((double) this._arc.StartX + x1 * (1.0 - num5));
        num10 = (int) ((double) this._arc.StartY + x2 * (1.0 - num5));
        num7 = (int) Math.Round((double) this._arc.EndX);
        num8 = (int) Math.Round((double) this._arc.EndY);
      }
      GraphicsPath path4 = new GraphicsPath();
      int num11 = (int) ((double) num9 + 7.0 * Math.Sin(num6));
      int num12 = (int) ((double) num10 - 7.0 * Math.Cos(num6));
      int num13 = (int) ((double) num9 - 7.0 * Math.Sin(num6));
      int num14 = (int) ((double) num10 + 7.0 * Math.Cos(num6));
      path4.AddLine(x1_1, y1, num7, num8);
      path4.AddLine(num7, num8, num13, num14);
      path4.AddLine(num13, num14, num11, num12);
      path4.AddLine(num11, num12, num7, num8);
      Pen pen2;
      SolidBrush solidBrush;
      if (this.IsSelected)
      {
        pen2 = new Pen(Color.Red, 1f);
        solidBrush = new SolidBrush(Color.Red);
      }
      else
      {
        pen2 = new Pen(Color.Gray, 1f);
        solidBrush = new SolidBrush(Color.Gray);
      }
      g.DrawPath(pen2, path4);
      g.FillPath((Brush) solidBrush, path4);
      solidBrush.Dispose();
      if (this._arc.IsFinished)
      {
        GraphicsPath path2 = new GraphicsPath();
        solidBrush = new SolidBrush(Color.Beige);
        pen2 = !this.IsSelected ? new Pen(Color.Gray, 1f) : new Pen(Color.Red, 1f);
        Rectangle rectangle = new Rectangle((int) Math.Round((double) (this._arc.StartX + this._arc.EndX - 70) / 2.0), (int) Math.Round((double) (this._arc.StartY + this._arc.EndY - 15) / 2.0), 70, 15);
        path2.AddRectangle(rectangle);
        g.FillPath((Brush) solidBrush, path2);
        FontFamily family = new FontFamily("Courier New");
        path2.AddString(string.Format("({0};{1})", this._arc.InfH ? (object) "inf" : (object) this._arc.H.ToString(), (object) this._arc.F), family, 0, 10f, rectangle, new StringFormat()
        {
          Alignment = StringAlignment.Center,
          LineAlignment = StringAlignment.Center
        });
        g.DrawPath(pen2, path2);
        path2.Dispose();
      }
      pen2.Dispose();
      solidBrush.Dispose();
    }

    public override bool HitTest(int x, int y)
    {
      return this.DrawRegion.IsVisible((float) x, (float) y);
    }
  }
}
