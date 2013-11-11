// Type: Mephi.K22.LearningSuite.Transport.FF.Base.ArcNode
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class ArcNode
  {
    private ArcCollection _startArcs;
    private ArcCollection _endArcs;

    public ArcCollection StartArcs
    {
      get
      {
        return this._startArcs;
      }
    }

    public ArcCollection EndArcs
    {
      get
      {
        return this._endArcs;
      }
    }

    public ArcNode()
    {
      this._startArcs = new ArcCollection();
      this._endArcs = new ArcCollection();
    }
  }
}
