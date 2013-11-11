// Type: Mephi.K22.LearningSuite.Core.MethodInfo
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public class MethodInfo
  {
    private string _assemblyName = string.Empty;
    private string _className = string.Empty;
    private string _methodName = string.Empty;
    private string _exec = string.Empty;
    private string _createTaskExec = string.Empty;

    public string Exec
    {
      get
      {
        return this._exec;
      }
    }

    public string CreateTaskExec
    {
      get
      {
        return this._createTaskExec;
      }
    }

    public string ClassName
    {
      get
      {
        return this._className;
      }
    }

    public string AssemblyName
    {
      get
      {
        return this._assemblyName;
      }
    }

    public string MethodName
    {
      get
      {
        return this._methodName;
      }
    }

    public MethodInfo(string assName, string className, string methodName, string exec, string createExec)
    {
      this._assemblyName = assName;
      this._className = className;
      this._methodName = methodName;
      this._exec = exec;
      this._createTaskExec = createExec;
    }

    public MethodInfo Clone()
    {
      return new MethodInfo(this._assemblyName, this._className, this._methodName, this._exec, this._createTaskExec);
    }

    public override string ToString()
    {
      return string.Format("{0} ({1}, {2}, {3})", (object) this._methodName, (object) this._assemblyName, (object) this._className, (object) this._exec);
    }
  }
}
