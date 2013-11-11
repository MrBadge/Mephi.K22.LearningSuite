// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.ItemNodePoint
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public class ItemNodePoint
  {
    private ItemNode _node;
    private ItemPoint _point;

    public ItemPoint Point
    {
      get
      {
        return this._point;
      }
    }

    public ItemNode Node
    {
      get
      {
        return this._node;
      }
    }

    public ItemNodePoint(ItemNode node, ItemPoint point)
    {
      this._node = node;
      this._point = point;
    }

    public override string ToString()
    {
      return string.Format("{0} <-> {1}", (object) this._node.ToString(), (object) this._point.ToString());
    }

    public string GetString()
    {
      return string.Format("{0};{1};{2}", (object) this._node.Number, (object) (byte) this._point.PointType, (object) this._point.Number);
    }

    public static ItemNodePoint GetObject(string s)
    {
      string[] strArray = s.Split(new char[1]
      {
        ';'
      });
      return new ItemNodePoint(new ItemNode(int.Parse(strArray[0])), new ItemPoint(int.Parse(strArray[2]), (PointType) byte.Parse(strArray[1])));
    }
  }
}
