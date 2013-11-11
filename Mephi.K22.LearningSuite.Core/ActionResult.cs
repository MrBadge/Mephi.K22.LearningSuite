// Type: Mephi.K22.LearningSuite.Core.ActionResult
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.Collections;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public class ActionResult
  {
    private AccuracyType _accuracy;
    private string _comment;
    private ArrayList _errorKeys;

    public string Comment
    {
      get
      {
        return this._comment;
      }
      set
      {
        this._comment = value;
      }
    }

    public AccuracyType Accuracy
    {
      get
      {
        return this._accuracy;
      }
      set
      {
        this._accuracy = value;
      }
    }

    public ArrayList ErrorKeys
    {
      get
      {
        return this._errorKeys;
      }
      set
      {
        this._errorKeys = value;
      }
    }

    public ActionResult()
    {
      this._errorKeys = new ArrayList();
      this._accuracy = AccuracyType.notSpecified;
      this._comment = string.Empty;
    }
  }
}
