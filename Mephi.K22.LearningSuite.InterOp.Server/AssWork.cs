// Type: Mephi.K22.LearningSuite.InterOp.Server.AssWork
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class AssWork
  {
    static AssWork()
    {
    }

    public static DataSet GetData(Guid userId, Guid studentId)
    {
      DataTable table = Connection.GetData(string.Format(" SELECT  \ta.Id AssigmentId  \t, a.DateTime AssigmentDateTime  \t, w.Id WorkId  \t, w.Name WorkName  \t, v.Id VariantId  \t, v.Name VariantName  \t, IsNull( (SELECT TOP 1 1 FROM Execution e WHERE e.AssigmentId = a.id), 0) IsExecute  FROM  \tAssigment a  \tINNER JOIN Student s ON (a.StudentId = s.Id)  \tINNER JOIN Variant v ON (a.VariantId = v.Id)  \tINNER JOIN Work w ON (v.WorkId = w.Id)  WHERE   \ts.Id = '{0}' ", (object) studentId)).Tables[0];
      table.TableName = "Master";
      table.DataSet.Tables.Remove(table);
      return new DataSet()
      {
        Tables = {
          table
        }
      };
    }

    public static DataTable GetWork(Guid userId, Guid assId)
    {
      return Connection.GetData(string.Format(" SELECT  \ta.Id AssigmentId  \t, v.Id VariantId  \t, v.Name VariantName  \t, w.Id WorkId  \t, w.Name WorkName  FROM  \tAssigment a  \tINNER JOIN Variant v ON (a.VariantId = v.Id)  \tINNER JOIN Work w ON (v.WorkId = w.Id)  WHERE   \ta.Id = '{0}'", (object) assId)).Tables[0];
    }

    public static Guid Start(Guid userId, Guid assId)
    {
      Guid guid = Guid.NewGuid();
      Connection.ExecuteNonQuery(string.Format(" INSERT INTO Execution (Id, AssigmentId) VALUES ('{0}', '{1}')", (object) guid, (object) assId));
      return guid;
    }

    public static DataTable GetTask(Guid userId, Guid assId)
    {
      return Connection.GetData(string.Format(" SELECT  \tvt.MaxRetries MaxRetries  \t, t.Id TaskId  \t, t.Name TaskName  \t, t.TaskObjectXml TaskObjectXml  \t, m.Id MethodId  \t, m.Name MethodName  \t, m.Assembly MethodAssembly  \t, m.Class MethodClass  \t, m.Method MethodMethod  \t, m.CreateTaskExec MethodCreateTaskExec  FROM  \tAssigment a  \tINNER JOIN Variant v ON (a.VariantId = v.Id)  \tINNER JOIN Work w ON (v.WorkId = w.Id)  \tINNER JOIN VariantTask vt ON (vt.VariantId = v.Id)  \tINNER JOIN Task t ON (t.Id = vt.TaskId)  \tINNER JOIN Method m ON (m.Id = t.MethodId)  WHERE   \ta.Id = '{0}'", (object) assId)).Tables[0];
    }

    public static void SaveProtocol()
    {
    }

    public static void SaveProtocolTask(Guid userId, Guid execId, Guid taskExecId, Guid taskId, DateTime dt)
    {
      Connection.ExecuteNonQuery(string.Format(" DELETE FROM [ActionError]  WHERE ActionId in (SELECT a.Id FROM ExecutionTask et, [Action] a  WHERE et.TaskId = '{0}' AND et.ExecutionId = '{1}' AND et.Id = a.ExecutionTaskId)", (object) taskId, (object) execId));
      Connection.ExecuteNonQuery(string.Format(" DELETE FROM [Action]  WHERE ExecutionTaskId in (SELECT Id FROM ExecutionTask WHERE TaskId = '{0}' AND ExecutionId = '{1}')", (object) taskId, (object) execId));
      Connection.ExecuteNonQuery(string.Format(" DELETE FROM ExecutionTask WHERE TaskId = '{0}' AND ExecutionId = '{1}'", (object) taskId, (object) execId));
      Connection.ExecuteNonQuery(string.Format("INSERT INTO ExecutionTask (Id, ExecutionId, DateTime, TaskId)  VALUES ('{0}', '{1}', '{2}', '{3}')", (object) taskExecId, (object) execId, (object) dt.ToString("yyyy-MM-dd HH:mm:ss"), (object) taskId));
    }

    public static void SaveProtocolAction(Guid userId, Guid taskExecId, DateTime actionDateTime, int actionType, string message, AccuracyType resultAccuracy, object parameters, object innerState, string resultComment, int actionCounter)
    {
      SqlCommand sqlCommand = Connection.GetSqlCommand("shell_SaveAction");
      sqlCommand.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = (object) Guid.NewGuid();
      sqlCommand.Parameters.Add("@ExecutionTaskId", SqlDbType.UniqueIdentifier).Value = (object) taskExecId;
      sqlCommand.Parameters.Add("@dt", SqlDbType.DateTime).Value = (object) actionDateTime.ToString("yyyy-MM-dd HH:mm:ss");
      sqlCommand.Parameters.Add("@Type", SqlDbType.Int).Value = (object) actionType;
      sqlCommand.Parameters.Add("@Message", SqlDbType.NVarChar, 500).Value = (object) message;
      sqlCommand.Parameters.Add("@ResultAccuracy", SqlDbType.Int).Value = (object) (byte) resultAccuracy;
      sqlCommand.Parameters.Add("@Parameters", SqlDbType.Image).Value = Mephi.K22.LearningSuite.InterOp.Core.Common.TransformObj(parameters, true);
      sqlCommand.Parameters.Add("@InnerState", SqlDbType.Image).Value = Mephi.K22.LearningSuite.InterOp.Core.Common.TransformObj(innerState, false);
      sqlCommand.Parameters.Add("@ResultComment", SqlDbType.NVarChar, 500).Value = (object) resultComment;
      sqlCommand.Parameters.Add("@ActionOrder", SqlDbType.Int).Value = (object) actionCounter;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      Connection.ExecuteSqlCommand(sqlCommand);
    }
  }
}
