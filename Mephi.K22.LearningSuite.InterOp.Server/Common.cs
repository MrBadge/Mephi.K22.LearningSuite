// Type: Mephi.K22.LearningSuite.InterOp.Server.Common
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class Common
  {
    private static Common _inst = (Common) null;

    static Common()
    {
    }

    private Common()
    {
    }

    public static Common GetInstance()
    {
      if (Common._inst == null)
        Common._inst = new Common();
      return Common._inst;
    }

    public Guid Authorize(string login, string pass)
    {
      return Connection.Authorize(login, pass);
    }
  }
}
