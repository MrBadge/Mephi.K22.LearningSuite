// Type: Mephi.K22.LearningSuite.InterOp.Server.Variant
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class Variant
  {
    static Variant()
    {
    }

    public static DataTable GetData(Guid userId)
    {
      return Variant.GetData(userId, string.Empty);
    }

    public static DataTable GetData(Guid userId, string filter)
    {
      string query = "SELECT   \tv.Id VariantId  \t, v.Name VariantName  \t, v.WorkId WorkId  \t, w.Name WorkName  FROM  \tVariant v  \tINNER JOIN Work w ON (w.Id = v.WorkId) ";
      if (string.Empty != filter)
        query = query + " WHERE " + filter;
      return Connection.GetData(query).Tables[0];
    }

    public static void Add(Guid userId, string name, Guid workId)
    {
      Connection.ExecuteNonQuery(string.Format("INSERT INTO Variant (Id, Name, WorkId) VALUES ('{0}','{1}','{2}')", (object) Guid.NewGuid(), (object) name, (object) workId));
    }

    public static void Edit(Guid userId, Guid vId, string name, Guid workId)
    {
      Connection.ExecuteNonQuery(string.Format("UPDATE Variant SET Name = '{0}', WorkId = '{1}' WHERE Id = '{2}'", (object) name, (object) workId, (object) vId));
    }

    public static void Delete(Guid userId, Guid vId)
    {
      Connection.ExecuteNonQuery(string.Format("DELETE FROM Variant Where Id = '{0}'", (object) vId));
    }

    public static DataTable GetVariantInfo(Guid userId, Guid varId)
    {
      return Connection.GetData(string.Format(" SELECT  \tv.Id VariantId  \t, v.Name VariantName  \t, w.Id WorkId  \t, w.Name WorkName  FROM  \tVariant v  \tINNER JOIN Work w ON (v.WorkId = w.Id)  WHERE   \tv.Id = '{0}'", (object) varId)).Tables[0];
    }

    public static DataTable GetTask(Guid userId, Guid varId)
    {
      return Connection.GetData(string.Format(" SELECT  \tvt.MaxRetries MaxRetries  \t, t.Id TaskId  \t, t.Name TaskName  \t, t.TaskObjectXml TaskObjectXml  \t, m.Id MethodId  \t, m.Name MethodName  \t, m.Assembly MethodAssembly  \t, m.Class MethodClass  \t, m.Method MethodMethod  \t, m.CreateTaskExec MethodCreateTaskExec  FROM  \tVariant v  \tINNER JOIN Work w ON (v.WorkId = w.Id)  \tINNER JOIN VariantTask vt ON (vt.VariantId = v.Id)  \tINNER JOIN Task t ON (t.Id = vt.TaskId)  \tINNER JOIN Method m ON (m.Id = t.MethodId)  WHERE   \tv.Id = '{0}'", (object) varId)).Tables[0];
    }
  }
}
