// Type: Mephi.K22.LearningSuite.InterOp.Server.Task
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class Task
  {
    static Task()
    {
    }

    public static DataTable GetData(Guid userId)
    {
      return Task.GetData(userId, string.Empty);
    }

    public static DataTable GetData(Guid userId, string filter)
    {
      string query = "SELECT   \tt.Id TaskId  \t, t.Name TaskName  \t, t.TaskObjectXml TaskObjectXml  \t, m.Name MethodName  \t, m.Id MethodId  FROM  \tTask t  \tINNER JOIN Method m ON (t.MethodId = m.Id)";
      if (string.Empty != filter)
        query = query + " WHERE " + filter;
      return Connection.GetData(query).Tables[0];
    }

    public static DataTable GetData(Guid userId, Guid varId)
    {
      return Connection.GetData("SELECT   \tt.Id TaskId  \t, t.Name TaskName  \t, vt.MaxRetries MaxRetries  \t, t.TaskObjectXml TaskObjectXml  \t, m.Name MethodName  \t, m.Id MethodId  FROM  \tTask t  \tINNER JOIN Method m ON (t.MethodId = m.Id)  \tINNER JOIN VariantTask vt ON (vt.TaskId = t.Id)  WHERE  \tvt.VariantId = '" + varId.ToString() + "' ").Tables[0];
    }

    public static void Add(Guid userId, string taskName, Guid methodId, string taskObjXml)
    {
      SqlCommand sqlCommand = Connection.GetSqlCommand("admin_AddTask");
      sqlCommand.Parameters.Add("@taskName", SqlDbType.NVarChar, 200).Value = (object) taskName;
      sqlCommand.Parameters.Add("@methodId", SqlDbType.UniqueIdentifier).Value = (object) methodId;
      sqlCommand.Parameters.Add("@taskObjXml", SqlDbType.NVarChar, 4000).Value = (object) taskObjXml;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      Connection.ExecuteSqlCommand(sqlCommand);
    }

    public static void Edit(Guid userId, Guid tId, string taskName, Guid methodId, string taskObj)
    {
      SqlCommand sqlCommand = Connection.GetSqlCommand("admin_EditTask");
      sqlCommand.Parameters.Add("@taskName", SqlDbType.NVarChar, 200).Value = (object) taskName;
      sqlCommand.Parameters.Add("@methodId", SqlDbType.UniqueIdentifier).Value = (object) methodId;
      sqlCommand.Parameters.Add("@taskId", SqlDbType.UniqueIdentifier).Value = (object) tId;
      sqlCommand.Parameters.Add("@taskObjXml", SqlDbType.NVarChar, 4000).Value = (object) taskObj;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      Connection.ExecuteSqlCommand(sqlCommand);
    }

    public static void Delete(Guid userId, Guid tId)
    {
      Connection.ExecuteNonQuery(string.Format("DELETE FROM Task Where Id = '{0}'", (object) tId));
    }
  }
}
