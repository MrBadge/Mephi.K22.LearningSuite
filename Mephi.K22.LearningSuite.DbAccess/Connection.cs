// Type: Mephi.K22.LearningSuite.DbAccess.Connection
// Assembly: Mephi.K22.LearningSuite.DbAccess, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: 38E9397A-B228-4FC4-84D5-10B573A37ED7
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.DbAccess.dll

using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Mephi.K22.LearningSuite.DbAccess
{
  public class Connection
  {
    private static SqlConnection _connection = (SqlConnection) null;

    static Connection()
    {
      Connection._connection = new SqlConnection(Configuration.ConnectionString);
    }

    public static Guid Authorize(string login, string pass)
    {
      Guid.NewGuid();
      DataSet data = Connection.GetData(string.Format("SELECT Id FROM Users u WHERE u.Login='{0}' AND u.Pass='{1}'", (object) login, (object) pass));
      if (data == null || data.Tables.Count <= 0 || data.Tables[0].Rows.Count != 1)
        return Guid.Empty;
      Guid guid = (Guid) data.Tables[0].Rows[0]["Id"];
      data.Clear();
      return guid;
    }

    public static DataSet GetData(string query)
    {
      DataSet dataSet = new DataSet();
      try
      {
        Connection._connection.Open();
        ((DataAdapter) new SqlDataAdapter(query, Connection._connection)).Fill(dataSet);
        return dataSet;
      }
      catch (Exception ex)
      {
        string message = ex.Message;
        return (DataSet) null;
      }
      finally
      {
        Connection.connectionClose();
      }
    }

    public static SqlCommand GetSqlCommand(string text)
    {
      return new SqlCommand(text, Connection._connection);
    }

    public static bool ExecuteSqlCommand(SqlCommand comm)
    {
      try
      {
        Connection._connection.Open();
        comm.ExecuteScalar();
        return true;
      }
      catch
      {
        throw;
      }
      finally
      {
        Connection.connectionClose();
      }
    }

    public static bool ExecuteNonQuery(string query)
    {
      try
      {
        Connection._connection.Open();
        new SqlCommand(query, Connection._connection)
        {
          CommandType = CommandType.Text
        }.ExecuteScalar();
        return true;
      }
      catch
      {
        throw;
      }
      finally
      {
        Connection.connectionClose();
      }
    }

    private static void connectionClose()
    {
      if (Connection._connection.State != ConnectionState.Open)
        return;
      Connection._connection.Close();
    }
  }
}
