// Type: Mephi.K22.LearningSuite.Core.Retry
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public class Retry
  {
    private int _rNum = 0;
    private bool _isActive = false;
    private RetryCollection _parent = (RetryCollection) null;
    private ActionCollection _actions;

    public int ActionsCount
    {
      get
      {
        return this._actions != null ? this._actions.Count : 0;
      }
    }

    public int RetryNum
    {
      get
      {
        return this._rNum;
      }
      set
      {
        this._parent.ElementChanged(this);
        this._rNum = value;
      }
    }

    public ActionCollection Actions
    {
      get
      {
        return this._actions;
      }
      set
      {
        this._parent.ElementChanged(this);
        this._actions = value;
      }
    }

    public bool IsActive
    {
      get
      {
        return this._isActive;
      }
      set
      {
        this._parent.ElementChanged(this);
        this._isActive = value;
      }
    }

    internal RetryCollection Parent
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

    public Retry()
    {
    }

    public Retry(Task t, int rNum)
    {
      this._rNum = rNum;
      this._actions = new ActionCollection();
    }
  }
}
