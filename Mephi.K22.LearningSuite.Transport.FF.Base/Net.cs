// Type: Mephi.K22.LearningSuite.Transport.FF.Base.Net
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using System.Collections;
using System.Drawing;
using System.Text;
using System.Xml;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class Net
  {
    private int _nodeCounter = 1;
    private Hashtable _nodeArc = (Hashtable) null;
    private NodeCollection _nodeList = (NodeCollection) null;
    private ArcCollection _arcList = (ArcCollection) null;
    private Node _startNode;
    private Node _endNode;

    public Hashtable NodeArc
    {
      get
      {
        return this._nodeArc;
      }
    }

    public NodeCollection Nodes
    {
      get
      {
        return this._nodeList;
      }
    }

    public ArcCollection Arcs
    {
      get
      {
        return this._arcList;
      }
    }

    public int NodeCounter
    {
      get
      {
        return this._nodeCounter;
      }
    }

    public Node this[int i]
    {
      get
      {
        foreach (Node node in (CollectionBase) this._nodeList)
        {
          if (node.Number == i)
            return node;
        }
        return (Node) null;
      }
    }

    public Node StartNode
    {
      get
      {
        return this._startNode;
      }
      set
      {
        this._startNode = value;
      }
    }

    public Node EndNode
    {
      get
      {
        return this._endNode;
      }
      set
      {
        this._endNode = value;
      }
    }

    public Net()
    {
      this._nodeArc = new Hashtable();
      this._nodeList = new NodeCollection();
      this._arcList = new ArcCollection();
    }

    public void SetMark(int n, bool empty, int z, bool plus, bool inf, int e)
    {
      if (this[n] == null)
        return;
      this[n].SetMark(empty, z, plus, inf, e);
    }

    public void SetFlowF(int nFrom, int nTo, int f)
    {
      this.GetArc(nFrom, nTo).F = f;
    }

    public void DelMark(int n)
    {
      this[n].UnsetMark();
    }

    public static Net GetFromString(string s)
    {
      Net net = new Net();
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(s);
      XmlElement documentElement = xmlDocument.DocumentElement;
      XmlNodeList xmlNodeList = documentElement.SelectNodes("//net//nodes//n1");
      Hashtable hashtable1 = new Hashtable();
      Hashtable hashtable2 = new Hashtable();
      Hashtable hashtable3 = new Hashtable();
      Hashtable hashtable4 = new Hashtable();
      foreach (XmlNode xmlNode in xmlNodeList)
      {
        Node fromString = Node.GetFromString(xmlNode.SelectSingleNode("d").InnerText);
        hashtable1.Add((object) int.Parse(xmlNode.SelectSingleNode("i").InnerText), (object) fromString);
        net.AddNode(fromString);
      }
      foreach (XmlNode xmlNode in documentElement.SelectNodes("//net//arcs//a1"))
      {
        Arc fromString = Arc.GetFromString(xmlNode.SelectSingleNode("d").InnerText);
        hashtable2.Add((object) int.Parse(xmlNode.SelectSingleNode("i").InnerText), (object) fromString);
      }
      int num1 = int.Parse(documentElement.SelectSingleNode("sn").InnerText);
      int num2 = int.Parse(documentElement.SelectSingleNode("en").InnerText);
      foreach (XmlNode xmlNode in documentElement.SelectNodes("//net//nass//nas"))
      {
        int num3 = int.Parse(xmlNode.SelectSingleNode("n2").InnerText);
        string[] strArray = xmlNode.SelectSingleNode("a2").InnerText.Split(new char[1]
        {
          '|'
        });
        ArrayList arrayList = new ArrayList();
        foreach (string s1 in strArray)
        {
          if (s1 != string.Empty)
          {
            int num4 = int.Parse(s1);
            hashtable3.Add((object) num4, (object) num3);
          }
        }
      }
      foreach (XmlNode xmlNode in documentElement.SelectNodes("//net//naes//nae"))
      {
        int num3 = int.Parse(xmlNode.SelectSingleNode("n3").InnerText);
        string[] strArray = xmlNode.SelectSingleNode("a3").InnerText.Split(new char[1]
        {
          '|'
        });
        ArrayList arrayList = new ArrayList();
        foreach (string s1 in strArray)
        {
          if (s1 != string.Empty)
          {
            int num4 = int.Parse(s1);
            hashtable4.Add((object) num4, (object) num3);
          }
        }
      }
      foreach (int num3 in (IEnumerable) hashtable3.Keys)
        net.AddArc((Node) hashtable1[hashtable3[(object) num3]], (Node) hashtable1[hashtable4[(object) num3]], (Arc) hashtable2[(object) num3]);
      net.StartNode = num1 == -1 ? (Node) null : (Node) hashtable1[(object) num1];
      net.EndNode = num2 == -1 ? (Node) null : (Node) hashtable1[(object) num2];
      return net;
    }

    public string GetString()
    {
      Hashtable hashtable1 = new Hashtable();
      Hashtable hashtable2 = new Hashtable();
      Hashtable hashtable3 = new Hashtable();
      Hashtable hashtable4 = new Hashtable();
      int num1 = 0;
      foreach (Node node in (IEnumerable) this.NodeArc.Keys)
      {
        hashtable1.Add((object) node, (object) num1);
        ++num1;
      }
      int num2 = 0;
      foreach (Node node in (IEnumerable) this.NodeArc.Keys)
      {
        hashtable3.Add(hashtable1[(object) node], (object) new ArrayList());
        foreach (Arc arc in (CollectionBase) ((ArcNode) this.NodeArc[(object) node]).StartArcs)
        {
          hashtable2.Add((object) arc, (object) num2);
          ((ArrayList) hashtable3[hashtable1[(object) node]]).Add((object) num2);
          ++num2;
        }
      }
      foreach (Node node in (IEnumerable) this.NodeArc.Keys)
      {
        ArcNode arcNode = (ArcNode) this.NodeArc[(object) node];
        hashtable4.Add(hashtable1[(object) node], (object) new ArrayList());
        foreach (Arc arc in (CollectionBase) arcNode.EndArcs)
          ((ArrayList) hashtable4[hashtable1[(object) node]]).Add(hashtable2[(object) arc]);
      }
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("<net>", new object[0]);
      stringBuilder.AppendFormat("<nodes>", new object[0]);
      foreach (Node node in (IEnumerable) hashtable1.Keys)
        stringBuilder.AppendFormat("<n1><i>{0}</i><d>{1}</d></n1>", hashtable1[(object) node], (object) node.GetString());
      stringBuilder.AppendFormat("</nodes>", new object[0]);
      stringBuilder.AppendFormat("<arcs>", new object[0]);
      foreach (Arc arc in (IEnumerable) hashtable2.Keys)
        stringBuilder.AppendFormat("<a1><i>{0}</i><d>{1}</d></a1>", hashtable2[(object) arc], (object) arc.GetString());
      stringBuilder.AppendFormat("</arcs>", new object[0]);
      stringBuilder.AppendFormat("<sn>{0}</sn>", this.StartNode != null ? hashtable1[(object) this.StartNode] : (object) -1);
      stringBuilder.AppendFormat("<en>{0}</en>", this.EndNode != null ? hashtable1[(object) this.EndNode] : (object) -1);
      stringBuilder.AppendFormat("<nass>", new object[0]);
      foreach (int num3 in (IEnumerable) hashtable3.Keys)
      {
        ArrayList arrayList = (ArrayList) hashtable3[(object) num3];
        string str = string.Empty;
        foreach (int num4 in arrayList)
          str = !(str == string.Empty) ? string.Format("{0}|{1}", (object) str, (object) num4) : string.Format("{0}", (object) num4);
        stringBuilder.AppendFormat("<nas><n2>{0}</n2><a2>{1}</a2></nas>", (object) num3, (object) str);
      }
      stringBuilder.AppendFormat("</nass>", new object[0]);
      stringBuilder.AppendFormat("<naes>", new object[0]);
      foreach (int num3 in (IEnumerable) hashtable4.Keys)
      {
        ArrayList arrayList = (ArrayList) hashtable4[(object) num3];
        string str = string.Empty;
        foreach (int num4 in arrayList)
          str = !(str == string.Empty) ? string.Format("{0}|{1}", (object) str, (object) num4) : string.Format("{0}", (object) num4);
        stringBuilder.AppendFormat("<nae><n3>{0}</n3><a3>{1}</a3></nae>", (object) num3, (object) str);
      }
      stringBuilder.AppendFormat("</naes>", new object[0]);
      stringBuilder.AppendFormat("</net>", new object[0]);
      return stringBuilder.ToString();
    }

    public void AddNode(Node n)
    {
      ++this._nodeCounter;
      this._nodeList.Add(n);
      if (this._nodeArc.Contains((object) n))
        return;
      this._nodeArc.Add((object) n, (object) new ArcNode());
    }

    public Node AddNode(int x, int y, int n)
    {
      ++this._nodeCounter;
      Node n1 = new Node(x, y, n);
      this.AddNode(n1);
      return n1;
    }

    public void AddArc(Node startNode, Node endNode, Arc arc)
    {
      this._arcList.Add(arc);
      ((ArcNode) this._nodeArc[(object) startNode]).StartArcs.Add(arc);
      ((ArcNode) this._nodeArc[(object) endNode]).EndArcs.Add(arc);
    }

    public Arc AddArc(Node startNode, Node endNode)
    {
      Arc arc = new Arc(startNode.CenterX, startNode.CenterY);
      arc.IsFinished = true;
      arc.EndX = endNode.CenterX;
      arc.EndY = endNode.CenterY;
      this.AddArc(startNode, endNode, arc);
      return arc;
    }

    public void DrawNet(Graphics g)
    {
      foreach (Node node in (CollectionBase) this._nodeList)
      {
        foreach (Element element in (CollectionBase) ((ArcNode) this._nodeArc[(object) node]).StartArcs)
          element.DrawObject.Draw(g, 0.0f, 0.0f, 0.0f);
      }
      foreach (Element element in (CollectionBase) this._nodeList)
        element.DrawObject.Draw(g, 0.0f, 0.0f, 0.0f);
    }

    public Element GetClicked(int x, int y)
    {
      foreach (Node node in (CollectionBase) this._nodeList)
      {
        if (node.DrawObject.HitTest(x, y))
          return (Element) node;
      }
      foreach (Node node in (CollectionBase) this._nodeList)
      {
        foreach (Arc arc in (CollectionBase) ((ArcNode) this._nodeArc[(object) node]).StartArcs)
        {
          if (arc.DrawObject.HitTest(x, y))
            return (Element) arc;
        }
      }
      return (Element) null;
    }

    public void UnselectAll()
    {
      foreach (Node node in (CollectionBase) this._nodeList)
      {
        node.DrawObject.IsSelected = false;
        foreach (Element element in (CollectionBase) ((ArcNode) this._nodeArc[(object) node]).StartArcs)
          element.DrawObject.IsSelected = false;
      }
    }

    public void MoveNode(Node n, int dx, int dy)
    {
      n.CenterX += dx;
      n.CenterY += dy;
      ArcNode arcNode = (ArcNode) this._nodeArc[(object) n];
      foreach (Arc arc in (CollectionBase) arcNode.StartArcs)
      {
        arc.StartX = n.CenterX;
        arc.StartY = n.CenterY;
      }
      foreach (Arc arc in (CollectionBase) arcNode.EndArcs)
      {
        arc.EndX = n.CenterX;
        arc.EndY = n.CenterY;
      }
    }

    public Net Clone()
    {
      Net net = new Net();
      Hashtable hashtable1 = new Hashtable();
      Hashtable hashtable2 = new Hashtable();
      foreach (Node node in (CollectionBase) this._nodeList)
      {
        Node n = node.Clone();
        net.AddNode(n);
        hashtable1.Add((object) node, (object) n);
      }
      net.StartNode = this._startNode != null ? (Node) hashtable1[(object) this._startNode] : (Node) null;
      net.EndNode = this._endNode != null ? (Node) hashtable1[(object) this._endNode] : (Node) null;
      foreach (Arc arc1 in (CollectionBase) this._arcList)
      {
        Arc arc2 = arc1.Clone();
        hashtable2.Add((object) arc1, (object) arc2);
      }
      foreach (Arc a in (CollectionBase) this._arcList)
      {
        Node arcFrom = this.GetArcFrom(a);
        Node arcTo = this.GetArcTo(a);
        net.AddArc((Node) hashtable1[(object) arcFrom], (Node) hashtable1[(object) arcTo], (Arc) hashtable2[(object) a]);
      }
      return net;
    }

    public Node GetArcFrom(Arc a)
    {
      foreach (Node node in (IEnumerable) this._nodeArc.Keys)
      {
        foreach (Arc arc in (CollectionBase) ((ArcNode) this._nodeArc[(object) node]).StartArcs)
        {
          if (a == arc)
            return node;
        }
      }
      return (Node) null;
    }

    public Node GetArcTo(Arc a)
    {
      foreach (Node node in (IEnumerable) this._nodeArc.Keys)
      {
        foreach (Arc arc in (CollectionBase) ((ArcNode) this._nodeArc[(object) node]).EndArcs)
        {
          if (a == arc)
            return node;
        }
      }
      return (Node) null;
    }

    public Arc GetArc(int nFrom, int nTo)
    {
      ArcNode arcNode1 = (ArcNode) this._nodeArc[(object) this[nFrom]];
      ArcNode arcNode2 = (ArcNode) this._nodeArc[(object) this[nTo]];
      foreach (Arc arc1 in (CollectionBase) arcNode1.StartArcs)
      {
        foreach (Arc arc2 in (CollectionBase) arcNode2.EndArcs)
        {
          if (arc1 == arc2)
            return arc1;
        }
      }
      return (Arc) null;
    }

    public void Replace(Net newNet)
    {
      this._nodeArc.Clear();
      this._nodeList.Clear();
      this._arcList.Clear();
      this._nodeCounter = 0;
      this._startNode = (Node) null;
      this._endNode = (Node) null;
      this._arcList = newNet.Arcs;
      this._nodeList = newNet.Nodes;
      this._nodeArc = newNet.NodeArc;
      this._startNode = newNet.StartNode;
      this._endNode = newNet.EndNode;
    }

    public void RemoveArc(Arc a)
    {
      if (a == null)
        return;
      this._arcList.Remove(a);
      foreach (ArcNode arcNode in (IEnumerable) this._nodeArc.Values)
      {
        if (arcNode.StartArcs.Contains(a))
          arcNode.StartArcs.Remove(a);
        else if (arcNode.EndArcs.Contains(a))
          arcNode.EndArcs.Remove(a);
      }
    }

    public void RemoveNode(Node n)
    {
      if (n == null)
        return;
      ArrayList arrayList = new ArrayList();
      foreach (Arc arc in (CollectionBase) ((ArcNode) this._nodeArc[(object) n]).StartArcs)
        arrayList.Add((object) arc);
      foreach (Arc arc in (CollectionBase) ((ArcNode) this._nodeArc[(object) n]).EndArcs)
        arrayList.Add((object) arc);
      foreach (Arc a in arrayList)
        this.RemoveArc(a);
      this._nodeArc.Remove((object) n);
      this._nodeList.Remove(n);
    }

    public void ClearMarkAndFlow()
    {
      foreach (Arc arc in (CollectionBase) this._arcList)
        arc.F = 0;
      foreach (Node node in (CollectionBase) this._nodeList)
        node.UnsetMark();
    }

    public delegate void SetMarkHandler(Node n, bool empty, int z, bool plus, bool inf, int e);

    public delegate void SetFlowHandler(Arc a, int h);

    public delegate void DelMarkHandler(Node n);

    public delegate void SetResultHandler(int res);

    public delegate void SetNetworkHandler(Net n1);
  }
}
