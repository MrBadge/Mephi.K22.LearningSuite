// Type: Mephi.K22.LearningSuite.InterOp.Shell.AssWork
// Assembly: Mephi.K22.LearningSuite.InterOp.Shell, Version=0.1.3236.13213, Culture=neutral, PublicKeyToken=null
// MVID: 82648340-9D79-4EA1-B115-1CE6B455ECC3
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Shell.dll

using Mephi.K22.LearningSuite.Core;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Mephi.K22.LearningSuite.InterOp.Shell
{
  public class AssWork
  {
    public static DataSet GetData(Guid userId, Guid studentId)
    {
      return Mephi.K22.LearningSuite.InterOp.Server.AssWork.GetData(userId, studentId);
    }

    public static Work GetWork(Guid userId, Guid assId)
    {
      DataTable work1 = Mephi.K22.LearningSuite.InterOp.Server.AssWork.GetWork(userId, assId);
      if (work1.Rows.Count != 1)
        return (Work) null;
      Work work2 = new Work((Guid) work1.Rows[0]["WorkId"], (string) work1.Rows[0]["WorkName"]);
      Mephi.K22.LearningSuite.Core.Variant variant = new Mephi.K22.LearningSuite.Core.Variant((Guid) work1.Rows[0]["VariantId"], (string) work1.Rows[0]["VariantName"]);
      work2.Variants.Add(variant);
      foreach (DataRow dataRow in (InternalDataCollectionBase) Mephi.K22.LearningSuite.InterOp.Server.AssWork.GetTask(userId, assId).Rows)
      {
        MethodInfo metInfo = new MethodInfo((string) dataRow["MethodAssembly"], (string) dataRow["MethodClass"], (string) dataRow["MethodName"], (string) dataRow["MethodMethod"], (string) dataRow["MethodCreateTaskExec"]);
        Mephi.K22.LearningSuite.Core.Task task = new Mephi.K22.LearningSuite.Core.Task((string) dataRow["TaskName"], metInfo, BaseTaskObject.GetTaskObject((string) dataRow["TaskObjectXml"]), (int) dataRow["MaxRetries"], (Guid) dataRow["TaskId"]);
        variant.Tasks.Add(task);
      }
      return work2;
    }

    public static Guid Start(Guid userId, Guid assId)
    {
      return Mephi.K22.LearningSuite.InterOp.Server.AssWork.Start(userId, assId);
    }

    public static void SaveProtocol(Guid userId, Guid execId, Work work, string fileName)
    {
      if (userId != Guid.Empty)
      {
        if (work.Variants[0].Tasks != null && work.Variants[0].Tasks.Count > 0)
        {
          foreach (Mephi.K22.LearningSuite.Core.Task task in (CollectionBase) work.Variants[0].Tasks)
          {
            Guid taskExecId = Guid.NewGuid();
            Mephi.K22.LearningSuite.InterOp.Server.AssWork.SaveProtocolTask(userId, execId, taskExecId, task.Id, DateTime.Now);
            if (task.Retries != null)
            {
              foreach (Retry retry in (CollectionBase) task.Retries)
              {
                if (retry != null && retry.IsActive)
                {
                  if (retry.Actions != null)
                  {
                    int num = 0;
                    IEnumerator enumerator = retry.Actions.GetEnumerator();
                    try
                    {
                      while (enumerator.MoveNext())
                      {
                        Action action = (Action) enumerator.Current;
                        Mephi.K22.LearningSuite.InterOp.Server.AssWork.SaveProtocolAction(userId, taskExecId, action.ActionDateTime, (int) action.ActionType, action.Message, action.Result == null ? AccuracyType.notSpecified : action.Result.Accuracy, (object) action.Parameters, (object) action.InnerState, action.Result == null ? string.Empty : action.Result.Comment, num++);
                      }
                      break;
                    }
                    finally
                    {
                      IDisposable disposable = enumerator as IDisposable;
                      if (disposable != null)
                        disposable.Dispose();
                    }
                  }
                  else
                    break;
                }
              }
            }
          }
        }
        Mephi.K22.LearningSuite.InterOp.Server.AssWork.SaveProtocol();
      }
      else
      {
        if (work.Variants[0].Tasks == null || work.Variants[0].Tasks.Count <= 0)
          return;
        int num = 1;
        foreach (Mephi.K22.LearningSuite.Core.Task task in (CollectionBase) work.Variants[0].Tasks)
        {
          if (task.Retries != null)
          {
            foreach (Retry retry in (CollectionBase) task.Retries)
            {
              if (retry != null && retry.IsActive && retry.Actions != null)
              {
                IFormatter formatter = (IFormatter) new BinaryFormatter();
                FileStream fileStream = new FileStream(string.Format("{0}.{1}", (object) fileName, (object) task.Id), FileMode.Create);
                MemoryStream memoryStream = new MemoryStream();
                formatter.Serialize((Stream) fileStream, (object) retry.Actions);
                fileStream.Close();
                ++num;
              }
            }
          }
        }
      }
    }

    public static Work LoadWorkFromFile(string path)
    {
      StreamReader streamReader = new StreamReader(path, Encoding.UTF8);
      Work work = new Work(new Guid(streamReader.ReadLine()), streamReader.ReadLine());
      Mephi.K22.LearningSuite.Core.Variant variant = new Mephi.K22.LearningSuite.Core.Variant(new Guid(streamReader.ReadLine()), streamReader.ReadLine());
      work.Variants.Add(variant);
      int num = int.Parse(streamReader.ReadLine());
      for (int index = 0; index < num; ++index)
      {
        MethodInfo metInfo = new MethodInfo(streamReader.ReadLine(), streamReader.ReadLine(), streamReader.ReadLine(), streamReader.ReadLine(), streamReader.ReadLine());
        string taskName = streamReader.ReadLine();
        int retryCount = int.Parse(streamReader.ReadLine());
        string g = streamReader.ReadLine();
        string DBObject = streamReader.ReadLine();
        Mephi.K22.LearningSuite.Core.Task task = new Mephi.K22.LearningSuite.Core.Task(taskName, metInfo, BaseTaskObject.GetTaskObject(DBObject), retryCount, new Guid(g));
        variant.Tasks.Add(task);
      }
      streamReader.Close();
      return work;
    }
  }
}
