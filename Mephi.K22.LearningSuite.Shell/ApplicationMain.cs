// Type: Mephi.K22.LearningSuite.Shell.ApplicationMain
// Assembly: Mephi.K22.LearningSuite.Shell, Version=0.1.3236.13214, Culture=neutral, PublicKeyToken=null
// MVID: 06872E41-5D58-4E8A-9BE5-49AA900D1161
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Shell.exe

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.InterOp.Shell;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Shell
{
  public class ApplicationMain
  {
    internal static Guid userId;
    internal static Guid execId;
    internal static ControlMode controlMode;

    public ApplicationMain()
    {
      using (Login login = new Login())
      {
        while (login.ShowDialog() == DialogResult.OK)
        {
          if (login.cbMode.SelectedIndex == 0)
          {
            ApplicationMain.userId = Guid.Empty;
          }
          else
          {
            ApplicationMain.userId = LoginUser.GetUserId(login.tbLogin.Text, login.tbPass.Text);
            if (ApplicationMain.userId == Guid.Empty)
            {
              int num = (int) MessageBox.Show("В доступе отказано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
              break;
            }
          }
          if (ApplicationMain.userId != Guid.Empty)
          {
            ApplicationMain.controlMode = ControlMode.control;
            using (AssWork assWork = new AssWork())
            {
              assWork.Grid.DataSource = (object) Mephi.K22.LearningSuite.InterOp.Shell.AssWork.GetData(ApplicationMain.userId, ApplicationMain.userId);
              assWork.Grid.DataMember = "Master";
              while (assWork.ShowDialog() == DialogResult.OK)
              {
                Guid assId = assWork.AssId;
                Work work = Mephi.K22.LearningSuite.InterOp.Shell.AssWork.GetWork(ApplicationMain.userId, assId);
                ApplicationMain.execId = Mephi.K22.LearningSuite.InterOp.Shell.AssWork.Start(ApplicationMain.userId, assId);
                this.StartWork(work);
                assWork.Grid.DataSource = (object) Mephi.K22.LearningSuite.InterOp.Shell.AssWork.GetData(ApplicationMain.userId, ApplicationMain.userId);
                assWork.Grid.DataMember = "Master";
              }
            }
          }
          else
          {
            ApplicationMain.controlMode = ControlMode.learn;
            this.StartWork(Mephi.K22.LearningSuite.InterOp.Shell.AssWork.LoadWorkFromFile("var.lrn"));
          }
        }
      }
    }

    private void StartWork(Work work)
    {
      if (work == null)
        return;
      TaskSelector taskSelector = new TaskSelector();
      taskSelector.WorkInfo = work;
      taskSelector.TaskSelected += new TaskSelector.DelegateTask(this.OnTaskSelect);
      taskSelector.OnViewProtocol += new TaskSelector.DelegateTaskCollection(this.OnViewProtocol);
      taskSelector.OnSaveProtocol += new TaskSelector.OnSaveProtocolDelegate(this.SaveProtocol);
      int num = (int) taskSelector.ShowDialog();
      taskSelector.TaskSelected -= new TaskSelector.DelegateTask(this.OnTaskSelect);
      taskSelector.OnViewProtocol -= new TaskSelector.DelegateTaskCollection(this.OnViewProtocol);
      taskSelector.OnSaveProtocol -= new TaskSelector.OnSaveProtocolDelegate(this.SaveProtocol);
    }

    [STAThread]
    private static void Main()
    {
      Application.ThreadException += new ThreadExceptionEventHandler(ApplicationMain.Application_ThreadException);
      try
      {
        ApplicationMain applicationMain = new ApplicationMain();
      }
      catch (Exception ex)
      {
        int num = (int) new UnhandledException(ex).ShowDialog();
      }
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      int num = (int) new UnhandledException(e.Exception).ShowDialog();
    }

    private void OnTaskSelect(Task t)
    {
      if (t.RetryCount <= t.CompletedRetryCount)
        return;
      ++t.CompletedRetryCount;
      t.ControlMode = ApplicationMain.controlMode;
      Retry retry = new Retry(t, t.CompletedRetryCount);
      t.Retries.Add(retry);
      MethodControlLoader.Exec(t, RunMode.run, int.MinValue);
    }

    private void OnViewProtocol(TaskCollection tc)
    {
      Protocol protocol = new Protocol(tc);
      protocol.gridControl1.DataSource = (object) tc;
      protocol.OnRetryDelete += new Protocol.RetryEvent(this.p_OnRetryDelete);
      int num = (int) protocol.ShowDialog();
      protocol.OnRetryDelete -= new Protocol.RetryEvent(this.p_OnRetryDelete);
    }

    private void p_OnRetryDelete(Task t, Retry r)
    {
      t.Retries.Remove(r);
    }

    private void SaveProtocol(Work work)
    {
      string fileName = string.Empty;
      if (ApplicationMain.userId == Guid.Empty)
        fileName = "proto.sv";
      Mephi.K22.LearningSuite.InterOp.Shell.AssWork.SaveProtocol(ApplicationMain.userId, ApplicationMain.execId, work, fileName);
    }
  }
}
