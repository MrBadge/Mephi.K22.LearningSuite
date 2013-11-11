// Type: Mephi.K22.LearningSuite.Transport.FF.Base.Node
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using System;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  [Serializable]
  public class Node : Element
  {
    private int _centerX;
    private int _centerY;
    private int _number;
    private bool _isMark;
    private int _e;
    private int _z;
    private bool _plus;
    private bool _inf;
    private bool _empty;

    public bool IsEmpty
    {
      get
      {
        return this._empty;
      }
      set
      {
        this._empty = value;
      }
    }

    public int Z
    {
      get
      {
        return this._z;
      }
      set
      {
        this._z = value;
      }
    }

    public bool Plus
    {
      get
      {
        return this._plus;
      }
      set
      {
        this._plus = value;
      }
    }

    public bool Inf
    {
      get
      {
        return this._inf;
      }
      set
      {
        this._inf = value;
      }
    }

    public int E
    {
      get
      {
        return this._e;
      }
      set
      {
        this._e = value;
      }
    }

    public int Number
    {
      get
      {
        return this._number;
      }
      set
      {
        this._number = value;
      }
    }

    public bool IsMark
    {
      get
      {
        return this._isMark;
      }
      set
      {
        this._isMark = value;
      }
    }

    public int CenterX
    {
      get
      {
        return this._centerX;
      }
      set
      {
        this._centerX = value;
      }
    }

    public int CenterY
    {
      get
      {
        return this._centerY;
      }
      set
      {
        this._centerY = value;
      }
    }

    public Node(int x, int y, int n)
    {
      this._centerX = x;
      this._centerY = y;
      this._number = n;
      this.DrawObject = (DrawElement) new DrawNode(this);
    }

    public void SetMark(bool empty, int z, bool plus, bool inf, int e)
    {
      this._empty = empty;
      this._z = !this._empty ? z : 0;
      this._e = e;
      this._plus = plus;
      this._inf = inf;
      this._isMark = true;
    }

    public void UnsetMark()
    {
      this._e = 0;
      this._z = 0;
      this._plus = false;
      this._isMark = false;
      this._empty = false;
    }

    public Node Clone()
    {
      Node node = new Node(this.CenterX, this.CenterY, this.Number);
      node.E = this.E;
      node.Inf = this.Inf;
      node.IsEmpty = this.IsEmpty;
      node.IsMark = this.IsMark;
      node.Name = this.Name;
      node.Plus = this.Plus;
      node.Z = this.Z;
      return node;
    }

    public string GetString()
    {
      return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}", (object) this.CenterX, (object) this.CenterY, (object) this.E, (object) this.Bool2Int(this.Inf), (object) this.Bool2Int(this.IsEmpty), (object) this.Bool2Int(this.IsMark), (object) this.Name, (object) this.Number, (object) this.Bool2Int(this.Plus), (object) this.Z);
    }

    public static Node GetFromString(string s)
    {
      string[] strArray = s.Split(new char[1]
      {
        '|'
      });
      Node node = new Node(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[7]));
      node.E = int.Parse(strArray[2]);
      node.Inf = int.Parse(strArray[3]) == 1;
      node.IsEmpty = int.Parse(strArray[4]) == 1;
      node.IsMark = int.Parse(strArray[5]) == 1;
      node.Name = strArray[6];
      node.Plus = int.Parse(strArray[8]) == 1;
      node.Z = int.Parse(strArray[9]);
      return node;
    }

    private int Bool2Int(bool b)
    {
      return b ? 1 : 0;
    }
  }
}
