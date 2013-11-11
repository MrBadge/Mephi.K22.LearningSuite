// Type: Mephi.K22.LearningSuite.InterOp.Server.Term
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using Mephi.K22.LearningSuite.DbAccess;
using System;
using System.Data;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class Term
  {
    static Term()
    {
    }

    public static DataTable GetData(Guid userId)
    {
      return Connection.GetData("SELECT Id, dbo.GetTerm(TermYear, TermPeriod) TermName FROM Term").Tables[0];
    }

    public static void Add(Guid userId, int termYear, int termPeriod)
    {
      Connection.ExecuteNonQuery(string.Format("INSERT INTO Term (Id, TermYear, TermPeriod) VALUES ('{0}','{1}','{2}')", (object) Guid.NewGuid(), (object) termYear, (object) termPeriod));
    }

    public static void Edit(Guid userId, Guid termId, int termYear, int termPeriod)
    {
      Connection.ExecuteNonQuery(string.Format("UPDATE Term SET TermYear = '{0}', TermPeriod = '{1}' WHERE Id = '{2}'", (object) termYear, (object) termPeriod, (object) termId));
    }

    public static void Delete(Guid userId, Guid termId)
    {
      Connection.ExecuteNonQuery(string.Format("DELETE FROM Term Where Id = '{0}'", (object) termId));
    }
  }
}
