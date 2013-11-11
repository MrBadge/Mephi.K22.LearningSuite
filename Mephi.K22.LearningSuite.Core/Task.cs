// Type: Mephi.K22.LearningSuite.Core.Task
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.Xml.Serialization;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public class Task
  {
    private string _taskName = string.Empty;
    private MethodInfo _metInfo = (MethodInfo) null;
    private BaseTaskObject _taskObject = (BaseTaskObject) null;
    private int _retryCount = 0;
    private Guid _id = Guid.Empty;
    [XmlIgnore]
    private TaskCollection _parent = (TaskCollection) null;
    private int _curRetries = 0;
    private RetryCollection _retries = (RetryCollection) null;
    private ControlMode _controlMode = ControlMode.learn;

    public ControlMode ControlMode
    {
      get
      {
        return this._controlMode;
      }
      set
      {
        this._controlMode = value;
      }
    }

    public RetryCollection Retries
    {
      get
      {
        return this._retries;
      }
      set
      {
        this._parent.ElementChanged(this);
        this._retries = value;
      }
    }

    public int CompletedRetryCount
    {
      get
      {
        return this._curRetries;
      }
      set
      {
        this._parent.ElementChanged(this);
        this._curRetries = value;
      }
    }

    public string TaskName
    {
      get
      {
        return this._taskName;
      }
      set
      {
        this._taskName = value;
      }
    }

    public Guid Id
    {
      get
      {
        return this._id;
      }
      set
      {
        this._id = value;
      }
    }

    public MethodInfo MetInfo
    {
      get
      {
        return this._metInfo;
      }
      set
      {
        this._metInfo = value;
      }
    }

    public BaseTaskObject TaskObject
    {
      get
      {
        return this._taskObject;
      }
      set
      {
        this._taskObject = value;
      }
    }

    public int RetryCount
    {
      get
      {
        return this._retryCount;
      }
      set
      {
        this._retryCount = value;
      }
    }

    public string MethodName
    {
      get
      {
        return this._metInfo.MethodName;
      }
    }

    internal TaskCollection Parent
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

    public Task()
    {
    }

    public Task(string taskName, MethodInfo metInfo, BaseTaskObject taskObject, int retryCount, Guid id)
    {
      this._taskName = taskName;
      this._metInfo = metInfo;
      this._taskObject = taskObject;
      this._retryCount = retryCount;
      this._id = id;
      this._retries = new RetryCollection();
    }

    public Task(string taskName, MethodInfo metInfo, BaseTaskObject taskObject, int retryCount)
    {
      this._taskName = taskName;
      this._metInfo = metInfo;
      this._taskObject = taskObject;
      this._retryCount = retryCount;
      this._retries = new RetryCollection();
    }
  }
}
