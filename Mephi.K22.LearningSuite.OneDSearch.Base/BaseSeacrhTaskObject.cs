// Type: Mephi.K22.LearningSuite.OneDSearch.Base.BaseSeacrhTaskObject
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using Mephi.K22.LearningSuite.Core;
using System;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  [Serializable]
  public abstract class BaseSeacrhTaskObject : BaseTaskObject
  {
    private double _epsilon = 0.0;

    public double Epsilon
    {
      get
      {
        return this._epsilon;
      }
      set
      {
        this._epsilon = value;
      }
    }

    public override string GetDBObject()
    {
      return string.Empty;
    }
  }
}
