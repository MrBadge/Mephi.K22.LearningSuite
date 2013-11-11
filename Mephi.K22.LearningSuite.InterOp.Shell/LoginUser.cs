// Type: Mephi.K22.LearningSuite.InterOp.Shell.LoginUser
// Assembly: Mephi.K22.LearningSuite.InterOp.Shell, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: 82648340-9D79-4EA1-B115-1CE6B455ECC3
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Shell.dll

using System;

namespace Mephi.K22.LearningSuite.InterOp.Shell
{
  public class LoginUser
  {
    static LoginUser()
    {
    }

    public static Guid GetUserId(string login, string pass)
    {
      return Mephi.K22.LearningSuite.InterOp.Server.LoginUser.GetUserId(login, pass);
    }
  }
}
