// Type: Mephi.K22.LearningSuite.InterOp.Server.Role
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class Role
  {
    static Role()
    {
    }

    public static DataTable GetData(Guid userId)
    {
      return Connection.GetData("select Id, Name, Code from Role").Tables[0];
    }
  }
}
