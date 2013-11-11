// Type: Mephi.K22.LearningSuite.OneDSearch.Base.DiskTaskObject
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using Mephi.K22.LearningSuite.Core;
using System;
using System.Globalization;
using System.Xml;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  [Serializable]
  public class DiskTaskObject : BaseSeacrhTaskObject
  {
    private ExtremumType _extType = ExtremumType.min;
    private double _left = 0.0;
    private double _right = 0.0;
    private string _funcText = string.Empty;
    private double[] _points = new double[0];

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

    public double[] Points
    {
      get
      {
        return this._points;
      }
      set
      {
        this._points = value;
      }
    }

    public DiskTaskObject()
    {
    }

    public DiskTaskObject(string name, double left, double right, string funcText, double[] points, ExtremumType eType)
    {
      this.Name = name;
      this._left = left;
      this._right = right;
      this._funcText = funcText;
      this._points = (double[]) points.Clone();
      this._extType = eType;
    }

    public override string GetDBObject()
    {
      XmlDocument xmlDocument = new XmlDocument();
      string str = string.Empty;
      NumberFormatInfo numberFormat = new CultureInfo("ru-RU", false).NumberFormat;
      numberFormat.NumberDecimalSeparator = ".";
      foreach (double num in this._points)
        str = str + string.Format("<point>{0}</point>", (object) num.ToString((IFormatProvider) numberFormat));
      xmlDocument.LoadXml(string.Format("<task><assName>{7}</assName><type>{6}</type><name>{0}</name><left>{1}</left><right>{2}</right><funcText>{3}</funcText><points>{4}</points><extType>{5}</extType></task>", (object) this.Name, (object) this._left, (object) this._right, (object) this._funcText, (object) str, (object) this._extType.ToString(), (object) this.GetType().ToString(), (object) this.GetType().Assembly.FullName));
      return xmlDocument.OuterXml;
    }

    public static DiskTaskObject GetTaskObject(string DBObject)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(DBObject);
      XmlElement documentElement = xmlDocument.DocumentElement;
      XmlNode xmlNode1 = documentElement.SelectSingleNode("//points");
      double[] points = (double[]) null;
      if (xmlNode1 != null)
        points = new double[xmlNode1.ChildNodes.Count];
      NumberFormatInfo numberFormat = new CultureInfo("ru-RU", false).NumberFormat;
      numberFormat.NumberDecimalSeparator = ".";
      for (int index = 0; index < xmlNode1.ChildNodes.Count; ++index)
      {
        XmlNode xmlNode2 = xmlNode1.ChildNodes[index];
        points[index] = double.Parse(xmlNode2.InnerText, (IFormatProvider) numberFormat);
      }
      return new DiskTaskObject(documentElement.SelectSingleNode("//task//name").InnerText, double.Parse(documentElement.SelectSingleNode("//task//left").InnerText), double.Parse(documentElement.SelectSingleNode("//task//right").InnerText), documentElement.SelectSingleNode("//task//funcText").InnerText, points, documentElement.SelectSingleNode("//task//extType").InnerText == ExtremumType.min.ToString() ? ExtremumType.min : ExtremumType.max);
    }
  }
}
