// Type: Mephi.K22.LearningSuite.OneDSearch.BaseSearch
// Assembly: Mephi.K22.LearningSuite.OneDSearch, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A759670E-215D-48E9-9EE9-703E6D1ED21B
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.OneDSearch.Base;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.OneDSearch
{
  public abstract class BaseSearch
  {
    private BaseTest _test = (BaseTest) null;
    private SegmentCollection _segmentCollection = (SegmentCollection) null;
    private ActionCollection _undoActions = new ActionCollection();
    private OneDControl _oneDControl;
    private Function _func;
    private BaseTaskObject _taskObject;
    private PointCollection _pointCollection;
    private ActionCollection _actionCollection;
    private FuncButtonCollection _funcButtonCollection;
    private Task _task;
    private RunMode _mode;

    protected Function func
    {
      get
      {
        return this._func;
      }
      set
      {
        this._func = value;
      }
    }

    protected BaseTest test
    {
      get
      {
        return this._test;
      }
      set
      {
        this._test = value;
      }
    }

    protected BaseTaskObject taskObject
    {
      get
      {
        return this._taskObject;
      }
      set
      {
        this._taskObject = value;
      }
    }

    protected SegmentCollection segmentCollection
    {
      get
      {
        return this._segmentCollection;
      }
      set
      {
        this._segmentCollection = value;
      }
    }

    protected PointCollection pointCollection
    {
      get
      {
        return this._pointCollection;
      }
      set
      {
        this._pointCollection = value;
      }
    }

    protected ActionCollection actionCollection
    {
      get
      {
        return this._actionCollection;
      }
      set
      {
        this._actionCollection = value;
      }
    }

    protected FuncButtonCollection funcButtonCollection
    {
      get
      {
        return this._funcButtonCollection;
      }
      set
      {
        this._funcButtonCollection = value;
      }
    }

    protected OneDControl oneDControl
    {
      get
      {
        return this._oneDControl;
      }
      set
      {
        this._oneDControl = value;
      }
    }

    public BaseSearch(Task task)
    {
      this._task = task;
      this._segmentCollection = new SegmentCollection();
      this._pointCollection = new PointCollection();
      this._funcButtonCollection = new FuncButtonCollection();
      this.LoadTask(task.TaskObject);
      this.TestInit();
    }

    public BaseSearch(Task task, RunMode mode, int retryNum, ResultType resType)
    {
      this._mode = mode;
      this._task = task;
      this._segmentCollection = new SegmentCollection();
      this._pointCollection = new PointCollection();
      this._funcButtonCollection = new FuncButtonCollection();
      BaseContainerForm baseContainerForm = new BaseContainerForm();
      this._oneDControl = new OneDControl(this);
      this.SetMethodSpecificProperties();
      this._oneDControl.Points = this._pointCollection;
      this._oneDControl.Segments = this._segmentCollection;
      this._oneDControl.FuncButtons = this._funcButtonCollection;
      this._oneDControl.Task = task;
      this._oneDControl.ResType = resType;
      if (mode == RunMode.play)
      {
        this._oneDControl.Actions = task.Retries.GetRetry(retryNum).Actions;
        baseContainerForm.Text = "Просмотр протокола";
        this._oneDControl.actionViewer.EnabledControls = true;
      }
      else if (mode == RunMode.check)
      {
        this._oneDControl.Actions = task.Retries.GetRetry(retryNum).Actions;
        baseContainerForm.Text = "Проверка решения";
        this._oneDControl.actionViewer.EnabledControls = true;
      }
      else
      {
        this._oneDControl.Actions = task.Retries.GetRetry(task.CompletedRetryCount).Actions;
        baseContainerForm.Text = "Решение задачи";
      }
      this._actionCollection = this._oneDControl.Actions;
      baseContainerForm.Controls.Add((Control) this._oneDControl);
      this._oneDControl.Dock = DockStyle.Fill;
      this.LoadTask(task.TaskObject);
      this.TestInit();
      this.LoadErrors();
      baseContainerForm.StartPosition = FormStartPosition.CenterParent;
      if (mode == RunMode.play)
      {
        this._oneDControl.ReadOnly = true;
        foreach (Action act in (CollectionBase) task.Retries.GetRetry(retryNum).Actions)
          this.RunAction(act, false);
      }
      else if (mode == RunMode.check)
      {
        this._oneDControl.ReadOnly = false;
        foreach (Action act in (CollectionBase) task.Retries.GetRetry(retryNum).Actions)
          this.RunAction(act, false);
      }
      else
        this._oneDControl.graphControl_OnShowTask((object) this, (EventArgs) null);
      int num = (int) baseContainerForm.ShowDialog();
      this._oneDControl.Dispose();
    }

    public static void Init(Task task, RunMode mode, int retryNum)
    {
      int num = (int) MessageBox.Show("ERROR-0");
      throw new NotImplementedException("ERROR-0");
    }

    public static void InitCheck(Task task, int retryNum)
    {
      int num = (int) MessageBox.Show("ERROR-5");
      throw new NotImplementedException("ERROR-5");
    }

    protected virtual void LoadTask(BaseTaskObject taskObj)
    {
      int num = (int) MessageBox.Show("ERROR-1");
      throw new NotImplementedException();
    }

    protected virtual void TestInit()
    {
      int num = (int) MessageBox.Show("ERROR-2");
      throw new NotImplementedException();
    }

    private void LoadErrors()
    {
    }

    internal double GetFuncValue(double arg)
    {
      try
      {
        return this._func.Eval(new double[1]
        {
          arg
        });
      }
      catch
      {
        return double.MinValue;
      }
    }

    internal void RunAction(Action act, bool isRedo)
    {
      if (!isRedo)
        this._undoActions.Clear();
      act.InnerState = this._test.InnerState;
      //if (this._task.ControlMode != ControlMode.control)
        //ActionResult actionResult = new ActionResult();
        //actionResult.Accuracy = AccuracyType.yes;
        act.Result = this._test.TestAction(act);
      switch (act.ActionType)
      {
        case (byte) 0:
          this._oneDControl.CreatePoint((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 1:
          this._oneDControl.CreatePoint((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 2:
          this._oneDControl.CreatePoint((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 3:
          this._oneDControl.CreateSegment((double) act.Parameters[0], (string) act.Parameters[1]).StartY = (double) act.Parameters[2];
          break;
        case (byte) 4:
          Segment segment = this._oneDControl.CreateSegment((double) act.Parameters[2] - (double) act.Parameters[0], (string) act.Parameters[4]);
          segment.StartX = (double) act.Parameters[5];
          segment.StartY = (double) act.Parameters[6];
          break;
        case (byte) 5:
          this._oneDControl.CreateSegment((double) act.Parameters[0], (string) act.Parameters[1]).StartY = (double) act.Parameters[3];
          break;
        case (byte) 6:
          this._oneDControl.DeletePointImpl((double) act.Parameters[0]);
          break;
        case (byte) 7:
          this._oneDControl.DeleteSegmentImpl((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 8:
          this._oneDControl.RunTestImpl((double) act.Parameters[0], (double) act.Parameters[1], (string) act.Parameters[2]);
          break;
        case (byte) 9:
          this._oneDControl.SetResult((double) act.Parameters[0], (double) act.Parameters[1]);
          this._oneDControl.Stop();
          break;
        case (byte) 10:
          this._oneDControl.CreateSegment((double) act.Parameters[0], (string) act.Parameters[1]).StartY = (double) act.Parameters[3];
          break;
        case (byte) 11:
          this._oneDControl.CreateSegment((double) act.Parameters[0], (string) act.Parameters[1]).StartY = (double) act.Parameters[4];
          break;
        case (byte) 12:
          this._oneDControl.CreatePoint((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 13:
          this._oneDControl.CreateConnectedSegmentImpl((PointSaveStub[]) act.Parameters[0]);
          break;
        case (byte) 14:
          this._oneDControl.CreateFictDiskreteImpl((double) act.Parameters[0]);
          break;
        case (byte) 15:
          this._oneDControl.RunTestImpl((double) act.Parameters[0], (double) act.Parameters[1], (string) act.Parameters[2]);
          break;
        default:
          throw new Exception("Invalid action type!");
      }
    }

    internal void UndoAction(Action act)
    {
      switch (act.ActionType)
      {
        case (byte) 0:
          this.UndoCreatePoint((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 1:
          this.UndoCreatePoint((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 2:
          this.UndoCreatePoint((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 3:
          this.UndoCreateSegment((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 4:
          this.UndoCreateSegment(Math.Abs((double) act.Parameters[0] - (double) act.Parameters[2]), (string) act.Parameters[4]);
          break;
        case (byte) 5:
          this.UndoCreateSegment((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 6:
          this.UndoDeletePoint((double) act.Parameters[0], (string) act.Parameters[1], (bool) act.Parameters[2], (double) act.Parameters[3]);
          break;
        case (byte) 7:
          this.UndoDeleteSegment((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 8:
          this.UndoRunTest((double) act.Parameters[0], (string) act.Parameters[2]);
          break;
        case (byte) 9:
          this.UndoSetResult();
          this.UndoStop();
          break;
        case (byte) 10:
          this.UndoCreateSegment((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 11:
          this.UndoCreateSegment((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 12:
          this.UndoCreatePoint((double) act.Parameters[0], (string) act.Parameters[1]);
          break;
        case (byte) 13:
          this._oneDControl.UndoCreateConnectedSegmentImpl((PointSaveStub[]) act.Parameters[0]);
          break;
        case (byte) 14:
          this._oneDControl.UndoCreateFictDiskreteImpl((double) act.Parameters[0]);
          break;
        case (byte) 15:
          this.UndoRunTest((double) act.Parameters[0], (string) act.Parameters[2]);
          break;
        default:
          throw new Exception("Invalid action type!");
      }
      this._test.InnerState = act.InnerState;
    }

    private void UndoStop()
    {
      if (this._mode == RunMode.play)
        return;
      this._oneDControl.ReadOnly = false;
    }

    private void UndoSetResult()
    {
      this._oneDControl.ResultSegment = (ResultSegment) null;
    }

    private void UndoRunTest(double coord, string pointName)
    {
      FuncButton button = this._funcButtonCollection.GetButton(coord, pointName);
      button.ResetValue();
      button.point.CoordX = button.point.CoordX;
    }

    private void UndoDeleteSegment(double len, string name)
    {
      this._segmentCollection.Add((Element) new Segment(name, len));
    }

    private void UndoDeletePoint(double coord, string name, bool isEval, double funcValue)
    {
      Point point = new Point(coord, name);
      this._pointCollection.Add((BasePoint) point);
      FuncButton funcButton = this._funcButtonCollection.GetButton(coord);
      if (funcButton == null)
      {
        funcButton = new FuncButton((BasePoint) point);
        this._funcButtonCollection.Add(funcButton);
      }
      funcButton.IsEval = isEval;
      if (!isEval)
        return;
      funcButton.SetFuncValue(funcValue);
    }

    private void UndoCreatePoint(double coord, string name)
    {
      this._pointCollection.Remove(this._pointCollection.GetPoint(coord, name));
      this._funcButtonCollection.Remove(this._funcButtonCollection.GetButton(coord, name));
    }

    private void UndoCreateSegment(double len, string name)
    {
      this._segmentCollection.Remove(this._segmentCollection.GetSegment(len, name));
    }

    public static BaseTaskObject GetTaskObject(BaseTaskObject to)
    {
      int num = (int) MessageBox.Show("ERROR-3");
      throw new NotImplementedException();
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
      this.RunAction(lastAction, true);
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
          this.RunAction(lastAction, true);
          this._undoActions.Remove(lastAction);
          this._actionCollection.Add(lastAction);
        }
      }
      while (lastAction != null);
    }

    protected virtual void SetMethodSpecificProperties()
    {
    }
  }
}
