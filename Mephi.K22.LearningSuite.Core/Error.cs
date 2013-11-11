// Type: Mephi.K22.LearningSuite.Core.Error
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

namespace Mephi.K22.LearningSuite.Core
{
  public class Error
  {
    private string _name;
    private int _code;

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

    public int Code
    {
      get
      {
        return this._code;
      }
      set
      {
        this._code = value;
      }
    }

    public Error(string name, int code)
    {
      this._name = name;
      this._code = code;
    }
  }
}
