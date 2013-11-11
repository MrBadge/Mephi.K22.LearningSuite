// Type: Mephi.K22.LearningSuite.Transport.FF.Base.Arc
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using System;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  [Serializable]
  public class Arc : Element
  {
    private bool _isFinished = false;
    private bool _isHinf = false;
    private int _startX;
    private int _startY;
    private int _endX;
    private int _endY;
    private int _h;
    private int _f;

    public int F
    {
      get
      {
        return this._f;
      }
      set
      {
        this._f = value;
      }
    }

    public int H
    {
      get
      {
        return this._h;
      }
      set
      {
        this._h = value;
      }
    }

    public bool InfH
    {
      get
      {
        return this._isHinf;
      }
      set
      {
        this._isHinf = value;
      }
    }

    public bool IsFinished
    {
      get
      {
        return this._isFinished;
      }
      set
      {
        this._isFinished = value;
      }
    }

    public int StartX
    {
      get
      {
        return this._startX;
      }
      set
      {
        this._startX = value;
      }
    }

    public int StartY
    {
      get
      {
        return this._startY;
      }
      set
      {
        this._startY = value;
      }
    }

    public int EndX
    {
      get
      {
        return this._endX;
      }
      set
      {
        this._endX = value;
      }
    }

    public int EndY
    {
      get
      {
        return this._endY;
      }
      set
      {
        this._endY = value;
      }
    }

    public Arc(int x, int y)
    {
      this._startX = x;
      this._startY = y;
      this._endX = x + 1;
      this._endY = y + 1;
      this.DrawObject = (DrawElement) new DrawArc(this);
    }

    public void SetFlow(int jh, bool jisHinf, int jf)
    {
      this._f = jf;
      this._isHinf = jisHinf;
      if (jisHinf)
        this._h = int.MinValue;
      else
        this._h = jh;
    }

    public string GetString()
    {
      return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", (object) this.EndX, (object) this.EndY, (object) this.F, (object) this.H, (object) this.Bool2Int(this.InfH), (object) this.Bool2Int(this.IsFinished), (object) this.Name, (object) this.StartX, (object) this.StartY);
    }

    public static Arc GetFromString(string s)
    {
      string[] strArray = s.Split(new char[1]
      {
        '|'
      });
      Arc arc = new Arc(int.Parse(strArray[7]), int.Parse(strArray[8]));
      arc.EndX = int.Parse(strArray[0]);
      arc.EndY = int.Parse(strArray[1]);
      arc.F = int.Parse(strArray[2]);
      arc.H = int.Parse(strArray[3]);
      arc.InfH = int.Parse(strArray[4]) == 1;
      arc.IsFinished = int.Parse(strArray[5]) == 1;
      arc.Name = strArray[6];
      return arc;
    }

    private int Bool2Int(bool b)
    {
      return b ? 1 : 0;
    }

    public Arc Clone()
    {
      Arc arc = new Arc(this.StartX, this.StartY);
      arc.EndX = this.EndX;
      arc.EndY = this.EndY;
      arc.F = this.F;
      arc.H = this.H;
      arc.InfH = this.InfH;
      arc.IsFinished = this.IsFinished;
      arc.Name = this.Name;
      arc.StartX = this.StartX;
      arc.StartY = this.StartY;
      return arc;
    }
  }
}
