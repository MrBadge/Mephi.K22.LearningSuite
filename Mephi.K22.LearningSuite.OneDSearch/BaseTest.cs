// Type: Mephi.K22.LearningSuite.OneDSearch.BaseTest
// Assembly: Mephi.K22.LearningSuite.OneDSearch, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A759670E-215D-48E9-9EE9-703E6D1ED21B
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.dll

using Mephi.K22.LearningSuite.Core;

namespace Mephi.K22.LearningSuite.OneDSearch
{
  public abstract class BaseTest
  {
    public virtual object[] InnerState
    {
      get
      {
        return (object[]) null;
      }
      set
      {
      }
    }

    public virtual ActionResult TestAction(Action act)
    {
      return (ActionResult) null;
    }

    public virtual BaseTest TestCopy()
    {
      return (BaseTest) null;
    }

    public virtual bool IsOver()
    {
      return false;
    }
  }
}
