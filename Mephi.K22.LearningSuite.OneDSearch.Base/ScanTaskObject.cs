// Type: Mephi.K22.LearningSuite.OneDSearch.Base.ScanTaskObject
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using Mephi.K22.LearningSuite.Core;
using System;
using System.Xml;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  [Serializable]
  public class ScanTaskObject : BaseSeacrhTaskObject
  {
    private ExtremumType _extType = ExtremumType.min;
    private double _left = 0.0;
    private double _right = 0.0;
    private string _funcText = string.Empty;

    public ExtremumType ExtremumType
    {
      get
      {
        return this._extType;
      }
      set
      {
        this._extType = value;
      }
    }

    public string FuncText
    {
      get
      {
        return this._funcText;
      }
      set
      {
        this._funcText = value;
      }
    }

    public double Left
    {
      get
      {
        return this._left;
      }
      set
      {
        this._left = value;
      }
    }

    public double Right
    {
      get
      {
        return this._right;
      }
      set
      {
        this._right = value;
      }
    }

    public ScanTaskObject()
    {
    }

    public ScanTaskObject(string name, double left, double right, string funcText, double eps, ExtremumType eType)
    {
      this.Name = name;
      this._left = left;
      this._right = right;
      this._funcText = funcText;
      this.Epsilon = eps;
      this._extType = eType;
    }

    public override string GetDBObject()
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(string.Format("<task><assName>{7}</assName><type>{6}</type><name>{0}</name><left>{1}</left><right>{2}</right><funcText>{3}</funcText><eps>{4}</eps><extType>{5}</extType></task>", (object) this.Name, (object) this._left, (object) this._right, (object) this._funcText, (object) this.Epsilon, (object) this._extType.ToString(), (object) this.GetType().ToString(), (object) this.GetType().Assembly.FullName));
      return xmlDocument.OuterXml;
    }

    public static ScanTaskObject GetTaskObject(string DBObject)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(DBObject);
      XmlElement documentElement = xmlDocument.DocumentElement;
      return new ScanTaskObject(documentElement.SelectSingleNode("//task//name").InnerText, double.Parse(documentElement.SelectSingleNode("//task//left").InnerText), double.Parse(documentElement.SelectSingleNode("//task//right").InnerText), documentElement.SelectSingleNode("//task//funcText").InnerText, double.Parse(documentElement.SelectSingleNode("//task//eps").InnerText), documentElement.SelectSingleNode("//task//extType").InnerText == ExtremumType.min.ToString() ? ExtremumType.min : ExtremumType.max);
    }
  }
}
