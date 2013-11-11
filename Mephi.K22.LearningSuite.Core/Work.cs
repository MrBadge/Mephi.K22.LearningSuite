// Type: Mephi.K22.LearningSuite.Core.Work
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;

namespace Mephi.K22.LearningSuite.Core
{
  public class Work
  {
    private string _name = string.Empty;
    private Guid _id = Guid.Empty;
    private VariantCollection _vc = (VariantCollection) null;

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

    public VariantCollection Variants
    {
      get
      {
        return this._vc;
      }
    }

    public Work()
    {
      this._vc = new VariantCollection();
    }

    public Work(Guid id, string name)
    {
      this._id = id;
      this._name = name;
      this._vc = new VariantCollection();
    }
  }
}
