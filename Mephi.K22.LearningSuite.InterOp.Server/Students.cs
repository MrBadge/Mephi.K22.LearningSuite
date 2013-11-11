// Type: Mephi.K22.LearningSuite.InterOp.Server.Students
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class Students
  {
    static Students()
    {
    }

    public static DataTable GetData(Guid userId)
    {
      return Students.GetData(userId, string.Empty);
    }

    public static DataTable GetData(Guid userId, string filter)
    {
      string query = " SELECT  \ts.Id StudentId  \t, s.LastName StudentLastName  \t, s.FirstName StudentFirstName  \t, s.LastName + ' ' + s.FirstName StudentName \t, s.Login StudentLogin \t, s.Pass StudentPass  \t, s.GroupId GroupId  \t, g.Name GroupName  \t, dbo.GetTerm(t.TermYear, t.TermPeriod) TermName  FROM  \tStudent s  \tLEFT JOIN Groups g ON (s.GroupId = g.Id)  \tLEFT JOIN Term t ON (g.TermId = t.Id) ";
      if (string.Empty != filter)
        query = query + " WHERE " + filter;
      return Connection.GetData(query).Tables[0];
    }

    public static void Add(Guid userId, string firstName, string lastName, string login, string pass, Guid groupId)
    {
      Guid guid = Guid.NewGuid();
      string query;
      if (Guid.Empty == groupId)
        query = string.Format("INSERT INTO Student (Id, FirstName, LastName, Login, Pass) VALUES ('{0}','{1}','{2}','{3}','{4}')", (object) guid, (object) firstName, (object) lastName, (object) login, (object) pass);
      else
        query = string.Format("INSERT INTO Student (Id, FirstName, LastName, Login, Pass, GroupId) VALUES ('{0}','{1}','{2}','{3}','{4}', '{5}')", (object) guid, (object) firstName, (object) lastName, (object) login, (object) pass, (object) groupId);
      Connection.ExecuteNonQuery(query);
    }

    public static void Edit(Guid userId, Guid studentId, string firstName, string lastName, string login, string pass, Guid groupId)
    {
      string query;
      if (Guid.Empty == groupId)
        query = string.Format("UPDATE Student SET FirstName = '{0}', LastName = '{1}', Login = '{2}', Pass = '{3}', GroupId = NULL WHERE Id = '{4}'", (object) firstName, (object) lastName, (object) login, (object) pass, (object) studentId);
      else
        query = string.Format("UPDATE Student SET FirstName = '{0}', LastName = '{1}', Login = '{2}', Pass = '{3}', groupId='{4}' WHERE Id = '{5}'", (object) firstName, (object) lastName, (object) login, (object) pass, (object) groupId, (object) studentId);
      Connection.ExecuteNonQuery(query);
    }

    public static void Delete(Guid userId, Guid studentId)
    {
      Connection.ExecuteNonQuery(string.Format("DELETE FROM Student Where Id = '{0}'", (object) studentId));
    }
  }
}
