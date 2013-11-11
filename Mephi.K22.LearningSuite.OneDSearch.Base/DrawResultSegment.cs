// Type: Mephi.K22.LearningSuite.OneDSearch.Base.DrawResultSegment
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System.Drawing;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class DrawResultSegment : DrawElement
  {
    private float _screenCoordX1 = 0.0f;
    private float _size = 6f;
    private ResultSegment _segment;

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

    internal ResultSegment ResultSegment
    {
      get
      {
        return this._segment;
      }
    }

    internal DrawResultSegment(ResultSegment segment)
    {
      this._segment = segment;
    }

    public override void Draw(Graphics g, float scale, float zeroPointX, float zeroPointY)
    {
      base.Draw(g, scale, zeroPointX, zeroPointY);
      this.ScreenCoordX = (float) this._segment.StartX * scale + zeroPointX;
      this.ScreenCoordX1 = (float) this._segment.EndX * scale + zeroPointX;
      g.DrawLine(DrawPallet.redPenWiden, this.ScreenCoordX, zeroPointY, this.ScreenCoordX1, zeroPointY);
    }

    public override void Move(int dx, int dy, float scale)
    {
      this._segment.EndX += (double) dx / (double) scale;
    }
  }
}
