// Type: Mephi.K22.LearningSuite.InterOp.Server.WorkExec
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class WorkExec
  {
    static WorkExec()
    {
    }

    public static DataTable GetExecInfo(Guid userId)
    {
      return Connection.GetData(" SELECT  \ts.Id StudentId  \t, s.LastName StudentLastName  \t, s.FirstName StudentFirstName  \t, g.Name GroupName  \t, a.Id AssigmentId   \t, A.DateTime AssigmentDateTime  \t, w.Name WorkName  \t, v.Name VariantName  \t, e.Id ExecutionId   \t, et.Id ExecutionTaskId  \t, et.DateTime ExecutionTaskDateTime  \t, etI.Id TaskId  \t, etI.Name TaskName  \t, m.Name MethodName  \t, r.Total TotalActionCount  \t, r.HasErrors HasErrorsActionCount  \t, r.HasNoErrors HasNoErrorsActionCount  \t, r.IsOver IsOver  FROM   \tExecution e  \tINNER JOIN ExecutionTask et ON (e.Id = et.ExecutionId)  \tINNER JOIN Task etI ON (etI.Id = et.TaskId)  \tINNER JOIN Method m ON (m.Id = etI.MethodId)  \tINNER JOIN Assigment a ON (a.Id = e.AssigmentId)  \tINNER JOIN Variant v ON (a.VariantId = v.Id)  \tINNER JOIN [Work] w ON (v.WorkId = w.Id)  \tINNER JOIN Student s ON (a.StudentId = s.Id)  \tLEFT OUTER JOIN [Groups] g ON (s.GroupId = g.Id)  \tLEFT OUTER JOIN [Result] r ON (r.ExecutionTaskId = et.Id) ").Tables[0];
    }

    public static DataTable GetActions(Guid userId, Guid execTaskId)
    {
      return Connection.GetData(string.Format(" SELECT   \ta.Id ActionId  \t, a.DateTime ActionDateTime  \t, a.Type ActionType  \t, a.Message ActionMessage  \t, a.ResultAccuracy ActionResultAccuracy  \t, a.Parameters ActionParameters  \t, a.InnerState ActionInnerState  \t, a.ResultComment ActionResultComment  \t, a.ActionOrder ActionOrder  FROM  \tAction a  WHERE  \ta.ExecutionTaskId = '{0}'  ORDER BY   \ta.ActionOrder ", (object) execTaskId)).Tables[0];
    }

    public static void SaveResult(Guid userid, Guid executionTaskId, int t, int r, int nr, bool isOver)
    {
      Connection.ExecuteNonQuery(string.Format("DELETE FROM Result WHERE ExecutionTaskId = '{0}'", (object) executionTaskId));
      Connection.ExecuteNonQuery(string.Format("INSERT INTO Result (Id, ExecutionTaskId, Total, HasErrors, HasNoErrors, IsOver) VALUES (NEWID(), '{0}', {1}, {2}, {3}, {4})", (object) executionTaskId, (object) t, (object) nr, (object) r, (object) (isOver ? 1 : 0)));
    }
  }
}
