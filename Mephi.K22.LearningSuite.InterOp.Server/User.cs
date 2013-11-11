// Type: Mephi.K22.LearningSuite.InterOp.Server.User
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class User
  {
    static User()
    {
    }

    public static DataTable GetData(Guid userId)
    {
      return User.GetData(userId, string.Empty);
    }

    public static DataTable GetData(Guid userId, string filter)
    {
      string query = "SELECT   \tu.Id UserId  \t, u.FirstName FirstName  \t, u.LastName LastName  \t, u.Login Login  \t, u.Pass Pass  \t, r.Id RoleId  \t, r.Name RoleName  \t, r.Code RoleCode  FROM  \tUsers u  \tINNER JOIN UsersRole ur ON (u.Id = ur.UserId)  \tINNER JOIN Role r ON (r.Id = ur.RoleId)";
      if (string.Empty != filter)
        query = query + "AND " + filter;
      return Connection.GetData(query).Tables[0];
    }

    public static void Add(Guid userId, string firstName, string lastName, string login, string pass, Guid roleId)
    {
      Guid guid = Guid.NewGuid();
      Connection.ExecuteNonQuery(string.Format("INSERT INTO Users (Id, FirstName, LastName, Login, Pass) VALUES ('{0}','{1}','{2}','{3}','{4}')", (object) guid, (object) firstName, (object) lastName, (object) login, (object) pass));
      Connection.ExecuteNonQuery(string.Format("INSERT into UsersRole (UserId, RoleId) VALUES ('{0}', '{1}')", (object) guid, (object) roleId));
    }

    public static void Edit(Guid userId, Guid uId, string firstName, string lastName, string login, string pass, Guid roleId)
    {
      Connection.ExecuteNonQuery(string.Format("UPDATE Users SET FirstName = '{0}', LastName = '{1}', Login = '{2}', Pass = '{3}' WHERE Id = '{4}'", (object) firstName, (object) lastName, (object) login, (object) pass, (object) uId));
      Connection.ExecuteNonQuery(string.Format("UPDATE UsersRole SET RoleId = '{0}' WHERE UserId = '{1}'", (object) roleId, (object) uId));
    }

    public static void Delete(Guid userId, Guid uId)
    {
      Connection.ExecuteNonQuery(string.Format("DELETE FROM UsersRole Where UserId = '{0}'", (object) uId));
      Connection.ExecuteNonQuery(string.Format("DELETE FROM Users Where Id = '{0}'", (object) uId));
    }
  }
}
