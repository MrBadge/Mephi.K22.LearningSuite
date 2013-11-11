// Type: Mephi.K22.LearningSuite.OneDSearch.Base.DihTaskObject
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using Mephi.K22.LearningSuite.Core;
using System;
using System.Globalization;
using System.Threading;
using System.Xml;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  [Serializable]
  public class DihTaskObject : BaseSeacrhTaskObject
  {
    private ExtremumType _extType = ExtremumType.min;
    private double _left = 0.0;
    private double _right = 0.0;
    private string _funcText = string.Empty;
    private DihTaskObject.StopTypeEnum _stopType = DihTaskObject.StopTypeEnum.precise;
    private int _maxSteps = 0;

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

    public int MaxSteps
    {
      get
      {
        return this._maxSteps;
      }
      set
      {
        this._maxSteps = value;
      }
    }

    public DihTaskObject.StopTypeEnum StopType
    {
      get
      {
        return this._stopType;
      }
      set
      {
        this._stopType = value;
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

    public DihTaskObject()
    {
    }

    public DihTaskObject(string name, double left, double right, string funcText, double eps, ExtremumType eType, DihTaskObject.StopTypeEnum stopType, int maxSteps)
    {
      this.Name = name;
      this._left = left;
      this._right = right;
      this._funcText = funcText;
      this.Epsilon = eps;
      this._extType = eType;
      this._stopType = stopType;
      this._maxSteps = maxSteps;
    }

    public override string GetDBObject()
    {
      XmlDocument xmlDocument = new XmlDocument();
      CultureInfo cultureInfo = (CultureInfo) Thread.CurrentThread.CurrentCulture.Clone();
      cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
      xmlDocument.LoadXml(string.Format("<task><assName>{9}</assName><type>{8}</type><name>{0}</name><left>{1}</left><right>{2}</right><funcText>{3}</funcText><eps>{4}</eps><extType>{5}</extType><stopType>{6}</stopType><maxSteps>{7}</maxSteps></task>", (object) this.Name, (object) this._left.ToString((IFormatProvider) cultureInfo.NumberFormat), (object) this._right.ToString((IFormatProvider) cultureInfo.NumberFormat), (object) this._funcText, (object) this.Epsilon.ToString((IFormatProvider) cultureInfo.NumberFormat), (object) this._extType.ToString(), (object) this._stopType.ToString(), (object) this._maxSteps, (object) this.GetType().ToString(), (object) this.GetType().Assembly.FullName));
      return xmlDocument.OuterXml;
    }

    public static DihTaskObject GetTaskObject(string DBObject)
    {
      CultureInfo cultureInfo = (CultureInfo) Thread.CurrentThread.CurrentCulture.Clone();
      cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(DBObject);
      XmlElement documentElement = xmlDocument.DocumentElement;
      return new DihTaskObject(documentElement.SelectSingleNode("//task//name").InnerText, double.Parse(documentElement.SelectSingleNode("//task//left").InnerText, (IFormatProvider) cultureInfo.NumberFormat), double.Parse(documentElement.SelectSingleNode("//task//right").InnerText, (IFormatProvider) cultureInfo.NumberFormat), documentElement.SelectSingleNode("//task//funcText").InnerText, double.Parse(documentElement.SelectSingleNode("//task//eps").InnerText, (IFormatProvider) cultureInfo.NumberFormat), documentElement.SelectSingleNode("//task//extType").InnerText == ExtremumType.min.ToString() ? ExtremumType.min : ExtremumType.max, documentElement.SelectSingleNode("//task//stopType").InnerText == DihTaskObject.StopTypeEnum.precise.ToString() ? DihTaskObject.StopTypeEnum.precise : DihTaskObject.StopTypeEnum.steps, int.Parse(documentElement.SelectSingleNode("//task//maxSteps").InnerText));
    }

    public enum StopTypeEnum
    {
      precise,
      steps,
    }
  }
}
