// Type: Mephi.K22.LearningSuite.Core.TaskClassAttribute
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;

namespace Mephi.K22.LearningSuite.Core
{
  public class TaskClassAttribute : Attribute
  {
    private string _taskName;

    public string TaskName
    {
      get
      {
        return this._taskName;
      }
    }

    public TaskClassAttribute(string taskName)
    {
      this._taskName = taskName;
    }
  }
}
