// Type: Mephi.K22.LearningSuite.InterOp.Server.Assigment
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class Assigment
  {
    static Assigment()
    {
    }

    public static DataTable GetData(Guid userId)
    {
      return Assigment.GetData(userId, string.Empty);
    }

    public static DataTable GetData(Guid userId, string filter)
    {
      string query = " SELECT  \ta.Id AssigmentId  \t, a.DateTime AssigmentDateTime  \t, s.Id StudentId  \t, s.FirstName StudentFirstName  \t, s.LastName StudentLastName  \t, g.Name GroupName  \t, v.Id VariantId  \t, v.Name VariantName  \t, w.Id WorkId  \t, w.Name WorkName  FROM  \tAssigment a  \tINNER JOIN Student s ON (s.id = a.StudentId)  \tLEFT JOIN Groups g ON (s.GroupId = g.Id)  \tINNER JOIN Variant v ON (a.VariantId = v.Id)  \tINNER JOIN [Work] w ON (v.WorkId = w.Id) ";
      if (string.Empty != filter)
        query = query + " WHERE " + filter;
      return Connection.GetData(query).Tables[0];
    }

    public static void AddStudent(Guid userId, Guid studentId, Guid variantId)
    {
      Connection.ExecuteNonQuery(string.Format("INSERT INTO Assigment (Id, StudentId, VariantId, DateTime) VALUES ('{0}','{1}','{2}', getdate())", (object) Guid.NewGuid(), (object) studentId, (object) variantId));
    }

    public static void AddGroup(Guid userId, Guid groupId, Guid variantId)
    {
      Guid.NewGuid();
      Connection.ExecuteNonQuery(string.Format("INSERT INTO Assigment (Id, StudentId, VariantId, DateTime)  SELECT newid(), s.Id, '{0}', getdate() FROM Student s WHERE s.GroupId = '{1}'", (object) variantId, (object) groupId));
    }

    public static void Edit(Guid userId, Guid assId, Guid stuId, Guid varId)
    {
      Connection.ExecuteNonQuery(string.Format("UPDATE Assigment SET StudentId = '{0}', VariantId = '{1}', DateTime = getdate() WHERE Id = '{2}'", (object) stuId, (object) varId, (object) assId));
    }

    public static void Delete(Guid userId, Guid assId)
    {
      Connection.ExecuteNonQuery(string.Format("DELETE FROM Assigment Where Id = '{0}'", (object) assId));
    }
  }
}
