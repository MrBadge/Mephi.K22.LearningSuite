// Type: Mephi.K22.LearningSuite.Transport.FF.Base.DrawNode
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class DrawNode : DrawElement
  {
    internal static readonly int radius = 17;
    private Node _node;

    static DrawNode()
    {
    }

    public DrawNode(Node node)
    {
      this._node = node;
    }

    public override void Draw(Graphics g, float scale, float zeroPointX, float zeroPointY)
    {
      base.Draw(g, scale, zeroPointX, zeroPointY);
      GraphicsPath path1 = new GraphicsPath();
      FontFamily family = new FontFamily("Courier New");
      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Center;
      format.LineAlignment = StringAlignment.Center;
      path1.AddEllipse(this._node.CenterX - DrawNode.radius, this._node.CenterY - DrawNode.radius, 2 * DrawNode.radius, 2 * DrawNode.radius);
      this.DrawRegion = new Region(path1);
      path1.Dispose();
      GraphicsPath path2 = new GraphicsPath();
      path2.AddEllipse(this._node.CenterX - DrawNode.radius + 1, this._node.CenterY - DrawNode.radius + 1, DrawNode.radius * 2 - 2, DrawNode.radius * 2 - 2);
      SolidBrush solidBrush = new SolidBrush(Color.LightBlue);
      g.FillPath((Brush) solidBrush, path2);
      path2.Dispose();
      GraphicsPath path3 = new GraphicsPath();
      path3.AddEllipse(this._node.CenterX - DrawNode.radius + 1, this._node.CenterY - DrawNode.radius + 1, DrawNode.radius * 2 - 2, DrawNode.radius * 2 - 2);
      path3.AddString(this._node.Number.ToString(), family, 0, 15f, new Rectangle(this._node.CenterX - DrawNode.radius + 1, this._node.CenterY - DrawNode.radius + 1, DrawNode.radius * 2 - 2, DrawNode.radius * 2 - 2), format);
      Pen pen1 = !this.IsSelected ? new Pen(Color.Blue, 1f) : new Pen(Color.Red, 1f);
      g.DrawPath(pen1, path3);
      path3.Dispose();
      if (this._node.IsMark)
      {
        GraphicsPath path4 = new GraphicsPath();
        Rectangle rectangle = new Rectangle((int) Math.Round((double) this._node.CenterX - 35.0), this._node.CenterY - DrawNode.radius - 15 - 4, 70, 15);
        path4.AddRectangle(rectangle);
        rectangle = new Rectangle((int) Math.Round((double) this._node.CenterX - 35.0), this._node.CenterY - DrawNode.radius - 15 - 4, 35, 15);
        string str = "(";
        if (!this._node.IsEmpty)
          str = str + this._node.Z.ToString();
        string s1 = !this._node.Plus ? str + "-" : str + "+";
        format.Alignment = StringAlignment.Far;
        path4.AddString(s1, family, 0, 10f, rectangle, format);
        format.Alignment = StringAlignment.Near;
        if (this._node.Inf)
        {
          string s2 = ";";
          rectangle = new Rectangle((int) Math.Round((double) this._node.CenterX), this._node.CenterY - DrawNode.radius - 15 - 4, 7, 15);
          path4.AddString(s2, family, 0, 10f, rectangle, format);
          string s3 = "∞";
          rectangle = new Rectangle((int) Math.Round((double) this._node.CenterX + 7.0), this._node.CenterY - DrawNode.radius - 15 - 4, 14, 15);
          path4.AddString(s3, family, 0, 20f, rectangle, format);
          string s4 = ")";
          rectangle = new Rectangle((int) Math.Round((double) this._node.CenterX + 21.0), this._node.CenterY - DrawNode.radius - 15 - 4, 14, 15);
          path4.AddString(s4, family, 0, 10f, rectangle, format);
        }
        else
        {
          rectangle = new Rectangle((int) Math.Round((double) this._node.CenterX), this._node.CenterY - DrawNode.radius - 15 - 4, 35, 15);
          string s2 = ";" + this._node.E.ToString() + ")";
          path4.AddString(s2, family, 0, 10f, rectangle, format);
        }
        g.FillPath((Brush) solidBrush, path4);
        Pen pen2 = new Pen(Color.Blue, 1f);
        g.DrawPath(pen2, path4);
        path4.Dispose();
      }
      solidBrush.Dispose();
    }

    public override bool HitTest(int x, int y)
    {
      return this.DrawRegion.IsVisible((float) x, (float) y);
    }
  }
}
