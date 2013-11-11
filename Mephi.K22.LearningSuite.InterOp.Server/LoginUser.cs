// Type: Mephi.K22.LearningSuite.InterOp.Server.LoginUser
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class LoginUser
  {
    static LoginUser()
    {
    }

    public static Guid GetUserId(string login, string pass)
    {
      DataTable dataTable = Connection.GetData("SELECT si.Id StudentId  FROM  \tStudent si  WHERE  \tsi.Login = '" + login.Replace("'", "@").Replace("-", "@").Replace("/", "@") + "'  \tAND si.Pass = '" + pass.Replace("'", "@").Replace("-", "@").Replace("/", "@") + "' ").Tables[0];
      if (dataTable != null && dataTable.Rows.Count == 1)
        return (Guid) dataTable.Rows[0]["StudentId"];
      else
        return Guid.Empty;
    }
  }
}
