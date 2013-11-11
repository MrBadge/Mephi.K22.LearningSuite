// Type: Mephi.K22.LearningSuite.InterOp.Server.Method
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class Method
  {
    static Method()
    {
    }

    public static DataTable GetData(Guid userId)
    {
      return Method.GetData(userId, string.Empty);
    }

    public static DataTable GetData(Guid userId, string filter)
    {
      string query = "SELECT m.Id MethodId  \t, m.Assembly Assembly  \t, m.Class Class  \t, m.Method Method  \t, m.Name Name  \t, m.CreateTaskExec CreateTaskExec  FROM  \tMethod m ";
      if (string.Empty != filter)
        query = query + "WHERE " + filter;
      return Connection.GetData(query).Tables[0];
    }

    public static Guid Add(Guid userId, string assemblyName, string className, string methodName, string name, string createExec)
    {
      Guid guid = Guid.NewGuid();
      Connection.ExecuteNonQuery(string.Format("INSERT INTO Method (Id, Assembly, Class, Method, Name, CreateTaskExec) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", (object) guid, (object) assemblyName, (object) className, (object) methodName, (object) name, (object) createExec));
      return guid;
    }

    public static void Delete(Guid userId, Guid mId)
    {
      Connection.ExecuteNonQuery(string.Format("DELETE FROM Method Where Id = '{0}'", (object) mId));
    }

    public static void AddError(Guid methId, string text, int code)
    {
      Connection.ExecuteNonQuery(string.Format("INSERT INTO Error (Id, MethodId, Code, Name) VALUES ('{0}','{1}',{2},'{3}')", (object) Guid.NewGuid(), (object) methId, (object) code, (object) text));
    }
  }
}
