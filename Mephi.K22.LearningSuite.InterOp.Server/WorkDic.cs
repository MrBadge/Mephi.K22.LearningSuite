// Type: Mephi.K22.LearningSuite.InterOp.Server.WorkDic
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class WorkDic
  {
    static WorkDic()
    {
    }

    public static DataTable GetData(Guid userId)
    {
      return WorkDic.GetData(userId, string.Empty);
    }

    public static DataTable GetData(Guid userId, string filter)
    {
      string query = "SELECT   \tw.Id WorkId  \t, w.Name WorkName  FROM  \tWork w ";
      if (string.Empty != filter)
        query = query + "AND " + filter;
      return Connection.GetData(query).Tables[0];
    }

    public static void Add(Guid userId, string name)
    {
      Connection.ExecuteNonQuery(string.Format("INSERT INTO Work (Id, Name) VALUES ('{0}','{1}')", (object) Guid.NewGuid(), (object) name));
    }

    public static void Edit(Guid userId, Guid uId, string name)
    {
      Connection.ExecuteNonQuery(string.Format("UPDATE Work SET Name = '{0}' WHERE Id = '{1}'", (object) name, (object) uId));
    }

    public static void Delete(Guid userId, Guid uId)
    {
      Connection.ExecuteNonQuery(string.Format("DELETE FROM Work Where Id = '{0}'", (object) uId));
    }
  }
}
