// Type: Mephi.K22.LearningSuite.Core.Action
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.Xml.Serialization;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public class Action
  {
    private DateTime _actionDateTime = DateTime.MinValue;
    private object[] _parameters = (object[]) null;
    private string _message = string.Empty;
    private byte _actionType = (byte) 0;
    [XmlIgnore]
    private ActionCollection _parent = (ActionCollection) null;
    private ActionResult _result;
    private object[] _innerState;

    public DateTime ActionDateTime
    {
      get
      {
        return this._actionDateTime;
      }
      set
      {
        this._actionDateTime = value;
      }
    }

    public byte ActionType
    {
      get
      {
        return this._actionType;
      }
      set
      {
        this._actionType = value;
      }
    }

    public string Message
    {
      get
      {
        return this._message;
      }
      set
      {
        this._message = value;
      }
    }

    public object[] Parameters
    {
      get
      {
        return this._parameters;
      }
      set
      {
        this._parameters = value;
      }
    }

    public ActionResult Result
    {
      get
      {
        return this._result;
      }
      set
      {
        this._result = value;
      }
    }

    public object[] InnerState
    {
      get
      {
        return this._innerState;
      }
      set
      {
        this._innerState = value;
      }
    }

    [XmlIgnore]
    public string ResultAccuracy
    {
      get
      {
        if (this._result != null)
          return this._result.Accuracy.ToString();
        else
          return AccuracyType.notSpecified.ToString();
      }
    }

    [XmlIgnore]
    public ActionCollection Parent
    {
      get
      {
        return this._parent;
      }
      set
      {
        this._parent = value;
      }
    }

    public string Comment
    {
      get
      {
        return this._result == null ? string.Empty : this._result.Comment;
      }
    }

    public Action()
    {
      this._actionDateTime = DateTime.Now;
    }

    public Action(DateTime actionDateTime, byte actionType, string message, params object[] parameters)
    {
      this._actionDateTime = actionDateTime;
      this._message = message;
      this._parameters = parameters;
      this._actionType = actionType;
    }
  }
}
