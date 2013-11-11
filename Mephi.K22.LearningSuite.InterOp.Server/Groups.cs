// Type: Mephi.K22.LearningSuite.InterOp.Server.Groups
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class Groups
  {
    static Groups()
    {
    }

    public static DataTable GetData(Guid userId)
    {
      return Groups.GetData(userId, string.Empty);
    }

    public static DataTable GetData(Guid userId, string filter)
    {
      string query = "SELECT \tg.Id GroupId \t, Name GroupName \t, t.Id TermId \t, dbo.GetTerm(TermYear, TermPeriod) TermName FROM \tGroups g \tINNER JOIN Term t ON (g.TermId = t.Id) ";
      if (string.Empty != filter)
        query = query + "AND " + filter;
      return Connection.GetData(query).Tables[0];
    }

    public static void Add(Guid userId, string groupName, Guid termId)
    {
      Connection.ExecuteNonQuery(string.Format("INSERT INTO Groups (Id, Name, TermId) VALUES ('{0}','{1}','{2}')", (object) Guid.NewGuid(), (object) groupName, (object) termId));
    }

    public static void Edit(Guid userId, Guid groupId, string groupName, Guid termId)
    {
      Connection.ExecuteNonQuery(string.Format("UPDATE Groups SET Name = '{0}', TermId = '{1}' WHERE Id = '{2}'", (object) groupName, (object) termId, (object) groupId));
    }

    public static void Delete(Guid userId, Guid groupId)
    {
      Connection.ExecuteNonQuery(string.Format("DELETE FROM Groups Where Id = '{0}'", (object) groupId));
    }
  }
}
