// Type: Mephi.K22.LearningSuite.Transport.FF.Base.TransportTaskObject
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using Mephi.K22.LearningSuite.Core;
using System.Text;
using System.Xml;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class TransportTaskObject : BaseTaskObject
  {
    private Net _net = (Net) null;
    private bool _reqCreate = false;

    public Net Net
    {
      get
      {
        return this._net;
      }
    }

    public bool ReqCreate
    {
      get
      {
        return this._reqCreate;
      }
      set
      {
        this._reqCreate = value;
      }
    }

    public TransportTaskObject()
    {
      this._net = new Net();
    }

    public TransportTaskObject(Net net, bool reqCreate)
    {
      this._net = net.Clone();
      this._reqCreate = reqCreate;
    }

    public override string GetDBObject()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("<task><assName>{1}</assName><type>{0}</type><name>{2}</name><reqcreate>{3}</reqcreate>{4}</task>", (object) this.GetType().ToString(), (object) this.GetType().Assembly.FullName, (object) this.Name, (object) (this._reqCreate ? 1 : 0), (object) this._net.GetString());
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(stringBuilder.ToString());
      return xmlDocument.OuterXml;
    }

    public static TransportTaskObject GetTaskObject(string DBObject)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(DBObject);
      XmlElement documentElement = xmlDocument.DocumentElement;
      TransportTaskObject transportTaskObject = new TransportTaskObject(Net.GetFromString(string.Format("<net>{0}</net>", (object) documentElement.SelectSingleNode("//task//net").InnerXml)), int.Parse(documentElement.SelectSingleNode("//task//reqcreate").InnerText) == 1);
      transportTaskObject.Name = documentElement.SelectSingleNode("//task//name").InnerText;
      return transportTaskObject;
    }
  }
}
