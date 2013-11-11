// Type: Mephi.K22.LearningSuite.Core.BaseTaskObject
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.Reflection;
using System.Xml;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public abstract class BaseTaskObject
  {
    private string _name = string.Empty;

    public string Name
    {
      get
      {
        return this._name;
      }
      set
      {
        this._name = value;
      }
    }

    public abstract string GetDBObject();

    public static BaseTaskObject GetTaskObject(string DBObject)
    {
      return (BaseTaskObject) BaseTaskObject.GetTaskType(DBObject).GetMethod("GetTaskObject").Invoke((object) null, new object[1]
      {
        (object) DBObject
      });
    }

    private static Type GetTaskType(string DBObject)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(DBObject);
      XmlElement documentElement = xmlDocument.DocumentElement;
      return Assembly.Load(documentElement.SelectSingleNode("//task//assName").InnerText).GetType(documentElement.SelectSingleNode("//task//type").InnerText);
    }
  }
}
