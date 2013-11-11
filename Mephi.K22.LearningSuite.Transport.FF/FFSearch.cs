// Type: Mephi.K22.LearningSuite.Transport.FF.FFSearch
// Assembly: Mephi.K22.LearningSuite.Transport.FF, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DA688CD5-CC79-4F9D-90F5-6DF17C731483
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.Transport.FF.Base;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.FF
{
  [TaskClass("Метод Форда-Фолкерсона")]
  public class FFSearch : ICheck
  {
    private FFTest _test = (FFTest) null;
    private ActionCollection _undoActions = new ActionCollection();
    private TransportControl _transportControl;
    private BaseTaskObject _taskObject;
    private ActionCollection _actionCollection;
    private Net _net;
    private Task _task;
    private RunMode _mode;

    public FFSearch(Task task)
    {
      this._task = task;
      this._net = ((TransportTaskObject) task.TaskObject).Net.Clone();
      this._transportControl = new TransportControl(this);
      this._transportControl.Net = this._net;
      this.LoadTask(task.TaskObject);
      this.TestInit();
    }

    public FFSearch(Task task, RunMode mode, int retryNum)
    {
      this._mode = mode;
      this._task = task;
      this._net = ((TransportTaskObject) task.TaskObject).Net.Clone();
      using (BaseContainerForm baseContainerForm = new BaseContainerForm())
      {
        this._transportControl = new TransportControl(this);
        this._transportControl.Net = this._net;
        this._transportControl.Task = task;
        if (mode == RunMode.play)
        {
          this._transportControl.ReadOnly = true;
          this._transportControl.actionViewer.EnabledControls = true;
          this._transportControl.Actions = task.Retries.GetRetry(retryNum).Actions;
          baseContainerForm.Text = "Просмотр протокола";
        }
        else if (mode == RunMode.check)
        {
          this._transportControl.ReadOnly = true;
          this._transportControl.actionViewer.EnabledControls = true;
          this._transportControl.Actions = task.Retries.GetRetry(retryNum).Actions;
          baseContainerForm.Text = "Проверка решения";
        }
        else
        {
          this._transportControl.ReadOnly = false;
          this._transportControl.actionViewer.EnabledControls = true;
          this._transportControl.Actions = task.Retries.GetRetry(task.CompletedRetryCount).Actions;
          baseContainerForm.Text = "Решение задачи";
          this._transportControl.RequireCreateNet = ((TransportTaskObject) task.TaskObject).ReqCreate;
        }
        this._actionCollection = this._transportControl.Actions;
        baseContainerForm.Controls.Add((Control) this._transportControl);
        this._transportControl.Dock = DockStyle.Fill;
        this.LoadTask(task.TaskObject);
        this.TestInit();
        this.LoadErrors();
        baseContainerForm.StartPosition = FormStartPosition.CenterParent;
        if (mode == RunMode.play)
        {
          foreach (Action act in (CollectionBase) task.Retries.GetRetry(retryNum).Actions)
          {
            int num = (int) this.RunAction(act, false);
          }
        }
        else if (mode == RunMode.check)
        {
          foreach (Action act in (CollectionBase) task.Retries.GetRetry(retryNum).Actions)
          {
            int num = (int) this.RunAction(act, false);
          }
        }
        else
        {
          using (BaseTaskObjectForm baseTaskObjectForm = new BaseTaskObjectForm())
          {
            baseTaskObjectForm.TaskObjectControl = (BaseTaskObjectControl) new ShowNetTaskObject(task.TaskObject.Name, this._net, false);
            baseTaskObjectForm.btnCancel.Visible = false;
            baseTaskObjectForm.Text = "Просмотр задания";
            int num = (int) baseTaskObjectForm.ShowDialog();
          }
        }
        int num1 = (int) baseContainerForm.ShowDialog();
        this._transportControl.Dispose();
      }
    }

    private void LoadErrors()
    {
    }

    internal AccuracyType RunAction(Action act, bool isRedo)
    {
      AccuracyType accuracyType = AccuracyType.notSpecified;
      if (!isRedo)
        this._undoActions.Clear();
      act.InnerState = this._test.InnerState;
      if (this._task.ControlMode != ControlMode.control)
      {
        act.Result = this._test.TestAction(act);
        accuracyType = act.Result.Accuracy;
      }
      switch (act.ActionType)
      {
        case (byte) 1:
          this._transportControl.SetFlowF((int) act.Parameters[0], (int) act.Parameters[1], (int) act.Parameters[2]);
          break;
        case (byte) 2:
          this._transportControl.SetMark((int) act.Parameters[0], (bool) act.Parameters[1], (int) act.Parameters[2], (bool) act.Parameters[3], (bool) act.Parameters[4], (int) act.Parameters[5]);
          break;
        case (byte) 3:
          this._transportControl.DelMark((int) act.Parameters[0]);
          break;
        case (byte) 4:
          this._transportControl.SetResult((int) act.Parameters[0]);
          break;
        case (byte) 5:
          this._transportControl.SetNetwork((string) act.Parameters[0]);
          break;
        default:
          throw new Exception("Invalid action type!");
      }
      return accuracyType;
    }

    internal void UndoAction(Action act)
    {
      switch (act.ActionType)
      {
        case (byte) 1:
          this._net.GetArc((int) act.Parameters[0], (int) act.Parameters[1]).F = (int) act.Parameters[3];
          break;
        case (byte) 2:
          bool flag = (bool) act.Parameters[6];
          int index = (int) act.Parameters[0];
          if (!flag)
          {
            this._net[index].IsMark = false;
            break;
          }
          else
          {
            this._net[index].SetMark((bool) act.Parameters[7], (int) act.Parameters[8], (bool) act.Parameters[9], (bool) act.Parameters[10], (int) act.Parameters[11]);
            break;
          }
        case (byte) 3:
          this._net.SetMark((int) act.Parameters[0], (bool) act.Parameters[1], (int) act.Parameters[2], (bool) act.Parameters[3], (bool) act.Parameters[4], (int) act.Parameters[5]);
          break;
        case (byte) 4:
          this.UndoStop();
          break;
        case (byte) 5:
          this._transportControl.UndoSetNetwork((string) act.Parameters[1]);
          break;
        default:
          throw new Exception("Invalid action type!");
      }
      this._test.InnerState = act.InnerState;
    }

    private void UndoStop()
    {
      this._transportControl.UndoStop();
    }

    [TaskExecEntryPoint]
    public static void Init(Task task, RunMode mode, int retryNum)
    {
      FFSearch ffSearch = new FFSearch(task, mode, retryNum);
    }

    [TaskCreateEntryPoint]
    public static BaseTaskObject GetTaskObject(BaseTaskObject to)
    {
      if (to == null)
        to = (BaseTaskObject) new TransportTaskObject();
      BaseTaskObjectForm baseTaskObjectForm = new BaseTaskObjectForm();
      baseTaskObjectForm.TaskObjectControl = (BaseTaskObjectControl) new CreateNetTaskObject((TransportTaskObject) to);
      int num = (int) baseTaskObjectForm.ShowDialog();
      return baseTaskObjectForm.TaskObjectControl.GetTaskObject();
    }

    AccuracyType ICheck.TestAction(Action a)
    {
      return this.RunAction(a, false);
    }

    bool ICheck.IsOver()
    {
      return this._test.IsOver();
    }

    public static ICheck InitCheck(Task task)
    {
      return (ICheck) new FFSearch(task);
    }

    internal void Undo()
    {
      Action lastAction = this._actionCollection.GetLastAction();
      if (lastAction == null)
        return;
      this.UndoAction(lastAction);
      this._actionCollection.Remove(lastAction);
      this._undoActions.Add(lastAction);
    }

    internal void UndoAll()
    {
      Action lastAction;
      do
      {
        lastAction = this._actionCollection.GetLastAction();
        if (lastAction != null)
        {
          this.UndoAction(lastAction);
          this._actionCollection.Remove(lastAction);
          this._undoActions.Add(lastAction);
        }
      }
      while (lastAction != null);
    }

    internal void Redo()
    {
      Action lastAction = this._undoActions.GetLastAction();
      if (lastAction == null)
        return;
      int num = (int) this.RunAction(lastAction, true);
      this._undoActions.Remove(lastAction);
      this._actionCollection.Add(lastAction);
    }

    internal void RedoAll()
    {
      Action lastAction;
      do
      {
        lastAction = this._undoActions.GetLastAction();
        if (lastAction != null)
        {
          int num = (int) this.RunAction(lastAction, true);
          this._undoActions.Remove(lastAction);
          this._actionCollection.Add(lastAction);
        }
      }
      while (lastAction != null);
    }

    private void LoadTask(BaseTaskObject taskObj)
    {
      if (taskObj == null)
        return;
      this._taskObject = taskObj;
    }

    private void TestInit()
    {
      this._test = new FFTest(this._net);
    }
  }
}
