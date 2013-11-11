namespace Mephi.K22.LearningSuite.Transport.Hung
{
    using Mephi.K22.LearningSuite.Core;
    using Mephi.K22.LearningSuite.Transport.FF.Base;
    using Mephi.K22.LearningSuite.Transport.Hung.Base;
    using System;
    using System.Windows.Forms;

    [TaskClass("Венгерский метод")]
    public class HungSearch : ICheck
    {
        private ActionCollection _actionCollection;
        private HungTransportControl _hungTransportControl;
        private RunMode _mode;
        private Net _net;
        private HungTable _startTable;
        private Task _task;
        private BaseTaskObject _taskObject;
        private HungTest _test;
        private ActionCollection _undoActions;

        public HungSearch(Task task)
        {
            this._test = null;
            this._undoActions = new ActionCollection();
            this._task = task;
            this._startTable = ((Mephi.K22.LearningSuite.Transport.Hung.Base.TransportTaskObject) task.TaskObject).Table.Clone();
            this._net = new Net();
            this._hungTransportControl = new HungTransportControl(this);
            this._hungTransportControl.StartTable = this._startTable;
            this._hungTransportControl.CurrTable = new HungTable(this._startTable.DimV, this._startTable.DimH);
            this._hungTransportControl.Task = task;
            this._hungTransportControl.Net = this._net;
            this.LoadTask(task.TaskObject);
            this.TestInit();
        }

        public HungSearch(Task task, RunMode mode, int retryNum)
        {
            this._test = null;
            this._undoActions = new ActionCollection();
            this._mode = mode;
            this._task = task;
            this._startTable = ((Mephi.K22.LearningSuite.Transport.Hung.Base.TransportTaskObject) task.TaskObject).Table.Clone();
            this._net = new Net();
            using (BaseContainerForm form = new BaseContainerForm())
            {
                this._hungTransportControl = new HungTransportControl(this);
                this._hungTransportControl.StartTable = this._startTable;
                this._hungTransportControl.CurrTable = new HungTable(this._startTable.DimV, this._startTable.DimH);
                this._hungTransportControl.Task = task;
                this._hungTransportControl.Net = this._net;
                if (mode == RunMode.play)
                {
                    this._hungTransportControl.ReadOnly = true;
                    this._hungTransportControl.actionViewer.EnabledControls = true;
                    this._hungTransportControl.Actions = task.Retries.GetRetry(retryNum).Actions;
                    form.Text = "Просмотр протокола";
                }
                else if (mode == RunMode.check)
                {
                    this._hungTransportControl.ReadOnly = true;
                    this._hungTransportControl.actionViewer.EnabledControls = true;
                    this._hungTransportControl.Actions = task.Retries.GetRetry(retryNum).Actions;
                    form.Text = "Проверка решения";
                }
                else
                {
                    this._hungTransportControl.ReadOnly = false;
                    this._hungTransportControl.actionViewer.EnabledControls = true;
                    this._hungTransportControl.Actions = task.Retries.GetRetry(task.CompletedRetryCount).Actions;
                    form.Text = "Решение задачи";
                }
                this._actionCollection = this._hungTransportControl.Actions;
                form.Controls.Add(this._hungTransportControl);
                this._hungTransportControl.Dock = DockStyle.Fill;
                this.LoadTask(task.TaskObject);
                this.TestInit();
                this.LoadErrors();
                form.StartPosition = FormStartPosition.CenterParent;
                if (mode == RunMode.play)
                {
                    foreach (Mephi.K22.LearningSuite.Core.Action action in task.Retries.GetRetry(retryNum).Actions)
                    {
                        this.RunAction(action, false);
                    }
                }
                else if (mode == RunMode.check)
                {
                    foreach (Mephi.K22.LearningSuite.Core.Action action2 in task.Retries.GetRetry(retryNum).Actions)
                    {
                        this.RunAction(action2, false);
                    }
                }
                else
                {
                    using (BaseTaskObjectForm form2 = new BaseTaskObjectForm())
                    {
                        form2.TaskObjectControl = new CreateHungTaskObject((Mephi.K22.LearningSuite.Transport.Hung.Base.TransportTaskObject) task.TaskObject);
                        form2.TaskObjectControl.Enabled = false;
                        form2.btnCancel.Visible = false;
                        form2.Text = "Просмотр задания";
                        form2.ShowDialog();
                    }
                }
                form.ShowDialog();
            }
            this._hungTransportControl.Dispose();
        }

        [TaskCreateEntryPoint]
        public static BaseTaskObject GetTaskObject(BaseTaskObject to)
        {
            if (to == null)
            {
                to = new Mephi.K22.LearningSuite.Transport.Hung.Base.TransportTaskObject();
            }
            BaseTaskObjectForm form = new BaseTaskObjectForm();
            form.TaskObjectControl = new CreateHungTaskObject((Mephi.K22.LearningSuite.Transport.Hung.Base.TransportTaskObject) to);
            form.ShowDialog();
            return form.TaskObjectControl.GetTaskObject();
        }

        [TaskExecEntryPoint]
        public static void Init(Task task, RunMode mode, int retryNum)
        {
            HungSearch search = new HungSearch(task, mode, retryNum);
        }

        public static ICheck InitCheck(Task task)
        {
            return new HungSearch(task);
        }

        private void LoadErrors()
        {
        }

        private void LoadTask(BaseTaskObject taskObj)
        {
            if (taskObj != null)
            {
                this._taskObject = taskObj;
            }
        }

        bool ICheck.IsOver()
        {
            return this._test.IsOver();
        }

        AccuracyType ICheck.TestAction(Mephi.K22.LearningSuite.Core.Action a)
        {
            return this.RunAction(a, false);
        }

        internal void Redo()
        {
            Mephi.K22.LearningSuite.Core.Action lastAction = this._undoActions.GetLastAction();
            if (lastAction != null)
            {
                this.RunAction(lastAction, true);
                this._undoActions.Remove(lastAction);
                this._actionCollection.Add(lastAction);
            }
        }

        internal void RedoAll()
        {
            Mephi.K22.LearningSuite.Core.Action act = null;
            do
            {
                act = this._undoActions.GetLastAction();
                if (act != null)
                {
                    this.RunAction(act, true);
                    this._undoActions.Remove(act);
                    this._actionCollection.Add(act);
                }
            }
            while (act != null);
        }

        internal AccuracyType RunAction(Mephi.K22.LearningSuite.Core.Action act, bool isRedo)
        {
            AccuracyType notSpecified = AccuracyType.notSpecified;
            if (!isRedo)
            {
                this._undoActions.Clear();
            }
            act.InnerState = this._test.InnerState;
            if (this._task.ControlMode != ControlMode.control)
            {
                act.Result = this._test.TestAction(act);
                notSpecified = act.Result.Accuracy;
            }
            switch (act.ActionType)
            {
                case 0:
                    this._hungTransportControl.SetValAA((uint) act.Parameters[0], (int) act.Parameters[1]);
                    return notSpecified;

                case 1:
                    this._hungTransportControl.SetValBB((uint) act.Parameters[0], (int) act.Parameters[1]);
                    return notSpecified;

                case 2:
                    this._hungTransportControl.SetValCD((uint) act.Parameters[0], (uint) act.Parameters[1], (int) act.Parameters[2]);
                    return notSpecified;

                case 3:
                    this._hungTransportControl.SetSelection((uint) act.Parameters[0], (uint) act.Parameters[1], (bool) act.Parameters[2]);
                    return notSpecified;

                case 4:
                    this._hungTransportControl.GoToNet((string) act.Parameters[1]);
                    return notSpecified;

                case 5:
                    this._hungTransportControl.SetFlowF((int) act.Parameters[0], (int) act.Parameters[1], (int) act.Parameters[2]);
                    return notSpecified;

                case 6:
                    this._hungTransportControl.SetMark((int) act.Parameters[0], (bool) act.Parameters[1], (int) act.Parameters[2], (bool) act.Parameters[3], (bool) act.Parameters[4], (int) act.Parameters[5]);
                    return notSpecified;

                case 7:
                    this._hungTransportControl.DelMark((int) act.Parameters[0]);
                    return notSpecified;

                case 9:
                    this._hungTransportControl.SetNetworkResult();
                    return notSpecified;

                case 10:
                    this._hungTransportControl.SetResultTable((string) act.Parameters[0], (int) act.Parameters[1]);
                    return notSpecified;
            }
            Exception exception = new Exception("Invalid action type!");
            throw exception;
        }

        private void TestInit()
        {
            this._test = new HungTest(this._startTable, this._net);
        }

        internal void Undo()
        {
            Mephi.K22.LearningSuite.Core.Action lastAction = this._actionCollection.GetLastAction();
            if (lastAction != null)
            {
                this.UndoAction(lastAction);
                this._actionCollection.Remove(lastAction);
                this._undoActions.Add(lastAction);
            }
        }

        internal void UndoAction(Mephi.K22.LearningSuite.Core.Action act)
        {
            switch (act.ActionType)
            {
                case 0:
                    this._hungTransportControl.SetValAA((uint) act.Parameters[0], (int) act.Parameters[2]);
                    break;

                case 1:
                    this._hungTransportControl.SetValBB((uint) act.Parameters[0], (int) act.Parameters[2]);
                    break;

                case 2:
                    this._hungTransportControl.SetValCD((uint) act.Parameters[0], (uint) act.Parameters[1], (int) act.Parameters[3]);
                    break;

                case 3:
                    this._hungTransportControl.SetSelection((uint) act.Parameters[0], (uint) act.Parameters[1], (bool) act.Parameters[3]);
                    break;

                case 4:
                    this._hungTransportControl.UndoGoToNet((string) act.Parameters[3]);
                    break;

                case 5:
                    this._net.GetArc((int) act.Parameters[0], (int) act.Parameters[1]).F = (int) act.Parameters[3];
                    break;

                case 6:
                {
                    bool flag = (bool) act.Parameters[6];
                    int num = (int) act.Parameters[0];
                    if (flag)
                    {
                        this._net[num].SetMark((bool) act.Parameters[7], (int) act.Parameters[8], (bool) act.Parameters[9], (bool) act.Parameters[10], (int) act.Parameters[11]);
                    }
                    else
                    {
                        this._net[num].IsMark = false;
                    }
                    break;
                }
                case 7:
                    this._net.SetMark((int) act.Parameters[0], (bool) act.Parameters[1], (int) act.Parameters[2], (bool) act.Parameters[3], (bool) act.Parameters[4], (int) act.Parameters[5]);
                    break;

                case 9:
                    this._hungTransportControl.UndoSetResultNetwork();
                    break;

                case 10:
                    this._hungTransportControl.UndoSetResultTable();
                    break;

                default:
                {
                    Exception exception = new Exception("Invalid action type!");
                    throw exception;
                }
            }
            this._test.InnerState = act.InnerState;
        }

        internal void UndoAll()
        {
            Mephi.K22.LearningSuite.Core.Action act = null;
            do
            {
                act = this._actionCollection.GetLastAction();
                if (act != null)
                {
                    this.UndoAction(act);
                    this._actionCollection.Remove(act);
                    this._undoActions.Add(act);
                }
            }
            while (act != null);
        }
    }
}

