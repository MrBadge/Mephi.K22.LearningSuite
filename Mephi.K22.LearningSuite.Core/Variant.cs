// Type: Mephi.K22.LearningSuite.Core.Variant
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public class Variant
  {
    private string _name = string.Empty;
    private Guid _id = Guid.Empty;
    private TaskCollection _vc = (TaskCollection) null;

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

    public TaskCollection Tasks
    {
      get
      {
        return this._vc;
      }
    }

    public Variant()
    {
      this._vc = new TaskCollection();
    }

    public Variant(Guid id, string name)
    {
      this._id = id;
      this._name = name;
      this._vc = new TaskCollection();
    }
  }
}
