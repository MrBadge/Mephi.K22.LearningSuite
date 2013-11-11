// Type: Mephi.K22.LearningSuite.InterOp.Server.DbObject
// Assembly: Mephi.K22.LearningSuite.InterOp.Server, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: C772D404-5682-40FA-BDF4-787F790B9ABE
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Server.dll

using System;
using System.Data;

namespace Mephi.K22.LearningSuite.InterOp.Server
{
  public class DbObject
  {
    public DataSet GetData(string filter)
    {
      return new DataSet();
    }

    public virtual DataSet GetData()
    {
      return new DataSet();
    }

    public void Add()
    {
    }

    public void Delete(Guid id)
    {
    }

    public void Edit(Guid id, object[] args)
    {
    }
  }
}
