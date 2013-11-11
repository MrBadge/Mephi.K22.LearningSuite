// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.TransportTaskObject
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

using Mephi.K22.LearningSuite.Core;
using System.Text;
using System.Xml;

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public class TransportTaskObject : BaseTaskObject
  {
    private HungTable _table = (HungTable) null;

    public HungTable Table
    {
      get
      {
        return this._table;
      }
      set
      {
        this._table = value;
      }
    }

    public TransportTaskObject()
    {
    }

    public TransportTaskObject(HungTable table)
    {
      this._table = table.Clone();
    }

    public override string GetDBObject()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("<task><assName>{1}</assName><type>{0}</type><name>{2}</name><table>{3}</table></task>", (object) this.GetType().ToString(), (object) this.GetType().Assembly.FullName, (object) this.Name, (object) this._table.GetString());
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(stringBuilder.ToString());
      return xmlDocument.OuterXml;
    }

    public static TransportTaskObject GetTaskObject(string DBObject)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(DBObject);
      XmlElement documentElement = xmlDocument.DocumentElement;
      TransportTaskObject transportTaskObject = new TransportTaskObject(HungTable.GetFromString(documentElement.SelectSingleNode("//task//table").InnerXml));
      transportTaskObject.Name = documentElement.SelectSingleNode("//task//name").InnerText;
      return transportTaskObject;
    }
  }
}
