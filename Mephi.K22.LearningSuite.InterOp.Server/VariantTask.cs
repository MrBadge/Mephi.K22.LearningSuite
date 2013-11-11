// Type: Mephi.K22.LearningSuite.InterOp.Server.VariantTask
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class VariantTask
  {
    static VariantTask()
    {
    }

    public static void Add(Guid userId, Guid varId, Guid taskId, int maxRetries)
    {
      Connection.ExecuteNonQuery(string.Format("INSERT INTO VariantTask (VariantId, TaskId, MaxRetries) VALUES ('{0}','{1}','{2}')", (object) varId, (object) taskId, (object) maxRetries));
    }

    public static void Edit(Guid userId, Guid varId, Guid taskId, int maxRetries)
    {
      Connection.ExecuteNonQuery(string.Format("UPDATE VariantTask SET MaxRetries = '{0}' WHERE VariantId = '{1}' AND TaskId = '{2}'", (object) maxRetries, (object) varId, (object) taskId));
    }

    public static void Delete(Guid userId, Guid varId, Guid taskId)
    {
      Connection.ExecuteNonQuery(string.Format("DELETE FROM VariantTask Where VariantId = '{0}' AND TaskId = '{1}'", (object) varId, (object) taskId));
    }
  }
}
