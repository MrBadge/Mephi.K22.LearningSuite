// Type: Mephi.K22.LearningSuite.DbAccess.Configuration
// Assembly: Mephi.K22.LearningSuite.DbAccess, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: 38E9397A-B228-4FC4-84D5-10B573A37ED7
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.DbAccess.dll

using System.Collections.Specialized;
using System.Configuration;

namespace Mephi.K22.LearningSuite.DbAccess
{
  internal class Configuration
  {
    private static string _connectionString = string.Empty;

    internal static string ConnectionString
    {
      get
      {
        return Configuration._connectionString;
      }
    }

    static Configuration()
    {
      NameValueCollection nameValueCollection = (NameValueCollection) ConfigurationSettings.GetConfig("server/access");
      if (nameValueCollection == null)
        return;
      Configuration._connectionString = nameValueCollection["ConnectionString"];
    }

    private Configuration()
    {
    }
  }
}
