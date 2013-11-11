namespace Mephi.K22.LearningSuite.Transport.Hung
{
    using Mephi.K22.LearningSuite.Core;
    using Mephi.K22.LearningSuite.Transport.FF.Base;
    using Mephi.K22.LearningSuite.Transport.Hung.Base;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class HungTransportControl : BaseMethodControl
    {
        private ActionCollection _actions = null;
        private HungTable _currTable;
        private Mephi.K22.LearningSuite.Transport.FF.Base.Net _net;
        private bool _readOnly = false;
        private HungSearch _search;
        private HungTable _startTable;
        private Mephi.K22.LearningSuite.Core.Task _task = null;
        internal ActionViewer actionViewer;
        private BaseHungControl baseHungControl;
        private Container components = null;
        private Panel panel1;
        private Panel panel2;
        private Splitter splitter1;

        public HungTransportControl(HungSearch search)
        {
            this.InitializeComponent();
            this._search = search;
        }

        private void baseHungControl_DelMark(Node n)
        {
            Mephi.K22.LearningSuite.Core.Action action = new Mephi.K22.LearningSuite.Core.Action();
            action.ActionType = 7;
            action.Parameters = new object[] { n.Number, n.IsEmpty, n.Z, n.Plus, n.Inf, n.E };
            action.Message = string.Format("Удалена пометка с вершины {0}", action.Parameters[0]);
            this._actions.Add(action);
            this._search.RunAction(action, false);
        }

        private void baseHungControl_GoToNet(Mephi.K22.LearningSuite.Transport.FF.Base.Net newNet, ArrayList corrList)
        {
            Mephi.K22.LearningSuite.Core.Action action = new Mephi.K22.LearningSuite.Core.Action();
            action.ActionType = 4;
            action.Parameters = new object[] { this._currTable.GetString(), newNet.GetString(), corrList, this._net.GetString() };
            action.Message = string.Format("Выполнен переход к сети", new object[0]);
            this._actions.Add(action);
            this._search.RunAction(action, false);
        }

        private void baseHungControl_SelectionCDChanged(uint i, uint j, bool val)
        {
            Mephi.K22.LearningSuite.Core.Action action = new Mephi.K22.LearningSuite.Core.Action();
            action.ActionType = 3;
            action.Parameters = new object[] { i, j, val, this._currTable.GetSelection(i, j) };
            action.Message = string.Format("Элемент {0}:{1}, {2}", i + 1, j + 1, val ? "выделен" : "выделение снято");
            this._actions.Add(action);
            this._search.RunAction(action, false);
        }

        private void baseHungControl_SetFlow(Arc a, int f)
        {
            Mephi.K22.LearningSuite.Core.Action action = new Mephi.K22.LearningSuite.Core.Action();
            action.ActionType = 5;
            action.Parameters = new object[] { this._net.GetArcFrom(a).Number, this._net.GetArcTo(a).Number, f, a.F };
            action.Message = string.Format("Задан поток F {0} дуги {1}-{2}", action.Parameters[2], action.Parameters[0], action.Parameters[1]);
            this._actions.Add(action);
            this._search.RunAction(action, false);
        }

        private void baseHungControl_SetMark(Node n, bool empty, int z, bool plus, bool inf, int e)
        {
            Mephi.K22.LearningSuite.Core.Action action = new Mephi.K22.LearningSuite.Core.Action();
            action.ActionType = 6;
            action.Parameters = new object[] { n.Number, empty, z, plus, inf, e, n.IsMark, n.IsEmpty, n.Z, n.Plus, n.Inf, n.E };
            action.Message = string.Format("Установлена пометка {1}{2};{3} на вершину {0}", new object[] { action.Parameters[0], ((bool) action.Parameters[1]) ? "" : action.Parameters[2], ((bool) action.Parameters[3]) ? "+" : "-", ((bool) action.Parameters[4]) ? "inf" : action.Parameters[5] });
            this._actions.Add(action);
            this._search.RunAction(action, false);
        }

        private void baseHungControl_SetResultNetwork(Mephi.K22.LearningSuite.Transport.FF.Base.Net n1)
        {
            Mephi.K22.LearningSuite.Core.Action action = new Mephi.K22.LearningSuite.Core.Action();
            action.ActionType = 9;
            action.Parameters = new object[0];
            action.Message = string.Format("Выполнен переход к таблице", new object[0]);
            this._actions.Add(action);
            this._search.RunAction(action, false);
        }

        private void baseHungControl_SetResultTable(HungTable table, int sum)
        {
            Mephi.K22.LearningSuite.Core.Action action = new Mephi.K22.LearningSuite.Core.Action();
            action.ActionType = 10;
            action.Parameters = new object[] { table.GetString(), sum };
            action.Message = string.Format("Задан ответ", new object[0]);
            this._actions.Add(action);
            this._search.RunAction(action, false);
        }

        private void baseHungControl_ValueAAChanged(uint i, int val)
        {
            Mephi.K22.LearningSuite.Core.Action action = new Mephi.K22.LearningSuite.Core.Action();
            action.ActionType = 0;
            action.Parameters = new object[] { i, val, this._currTable.GetValAA(i) };
            action.Message = string.Format("Задан {0}-й элемент A, значение {1}", i + 1, val);
            this._actions.Add(action);
            this._search.RunAction(action, false);
        }

        private void baseHungControl_ValueBBChanged(uint j, int val)
        {
            Mephi.K22.LearningSuite.Core.Action action = new Mephi.K22.LearningSuite.Core.Action();
            action.ActionType = 1;
            action.Parameters = new object[] { j, val, this._currTable.GetValBB(j) };
            action.Message = string.Format("Задан {0}-й элемент B, значение {1}", j + 1, val);
            this._actions.Add(action);
            this._search.RunAction(action, false);
        }

        private void baseHungControl_ValueCDChanged(uint i, uint j, int val)
        {
            Mephi.K22.LearningSuite.Core.Action action = new Mephi.K22.LearningSuite.Core.Action();
            action.ActionType = 2;
            action.Parameters = new object[] { i, j, val, this._currTable.GetValCD(i, j) };
            action.Message = string.Format("Задан {0}:{1} элемент, значение {2}", i + 1, j + 1, val);
            this._actions.Add(action);
            this._search.RunAction(action, false);
        }

        internal void DelMark(int n)
        {
            this._net.DelMark(n);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        internal void GoToNet(string newnetstr)
        {
            this._net.Replace(Mephi.K22.LearningSuite.Transport.FF.Base.Net.GetFromString(newnetstr));
            this.baseHungControl.EnableNetControl();
            this.baseHungControl.IsCreateOnSolve = false;
        }

        private void HungTransportControl_Load(object sender, EventArgs e)
        {
            this.baseHungControl.ValueAAChanged += new BaseHungControl.ValueAAChangedHandler(this.baseHungControl_ValueAAChanged);
            this.baseHungControl.ValueBBChanged += new BaseHungControl.ValueBBChangedHandler(this.baseHungControl_ValueBBChanged);
            this.baseHungControl.ValueCDChanged += new BaseHungControl.ValueCDChangedHandler(this.baseHungControl_ValueCDChanged);
            this.baseHungControl.SelectionCDChanged += new BaseHungControl.SelectionCDChangedHandler(this.baseHungControl_SelectionCDChanged);
            this.baseHungControl.SetResultNetwork += new Mephi.K22.LearningSuite.Transport.FF.Base.Net.SetNetworkHandler(this.baseHungControl_SetResultNetwork);
            this.baseHungControl.GoToNet += new BaseHungControl.GoToNetHandler(this.baseHungControl_GoToNet);
            this.baseHungControl.SetFlow += new Mephi.K22.LearningSuite.Transport.FF.Base.Net.SetFlowHandler(this.baseHungControl_SetFlow);
            this.baseHungControl.SetMark += new Mephi.K22.LearningSuite.Transport.FF.Base.Net.SetMarkHandler(this.baseHungControl_SetMark);
            this.baseHungControl.DelMark += new Mephi.K22.LearningSuite.Transport.FF.Base.Net.DelMarkHandler(this.baseHungControl_DelMark);
            this.baseHungControl.SetResultTable += new BaseHungControl.SetResultTableHandler(this.baseHungControl_SetResultTable);
            this.actionViewer.SetDataBinding(this._actions);
            this.actionViewer.OnUndoAll = (ActionViewer.ActionEventHandler) Delegate.Combine(this.actionViewer.OnUndoAll, new ActionViewer.ActionEventHandler(this.OnUndoAll));
            this.actionViewer.OnUndo = (ActionViewer.ActionEventHandler) Delegate.Combine(this.actionViewer.OnUndo, new ActionViewer.ActionEventHandler(this.OnUndo));
            this.actionViewer.OnRedoAll = (ActionViewer.ActionEventHandler) Delegate.Combine(this.actionViewer.OnRedoAll, new ActionViewer.ActionEventHandler(this.OnRedoAll));
            this.actionViewer.OnRedo = (ActionViewer.ActionEventHandler) Delegate.Combine(this.actionViewer.OnRedo, new ActionViewer.ActionEventHandler(this.OnRedo));
            base.ParentForm.Closing += new CancelEventHandler(this.ParentForm_Closing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.baseHungControl = new BaseHungControl();
            this.panel2 = new Panel();
            this.actionViewer = new ActionViewer();
            this.splitter1 = new Splitter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.baseHungControl);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x298, 0x121);
            this.panel1.TabIndex = 0;
            this.baseHungControl.CurrTable = null;
            this.baseHungControl.Dock = DockStyle.Fill;
            this.baseHungControl.Location = new Point(0, 0);
            this.baseHungControl.Name = "baseHungControl";
            this.baseHungControl.Size = new Size(0x298, 0x121);
            this.baseHungControl.StartTable = null;
            this.baseHungControl.TabIndex = 0;
            this.panel2.BorderStyle = BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.actionViewer);
            this.panel2.Dock = DockStyle.Bottom;
            this.panel2.Location = new Point(0, 0x124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x298, 0x70);
            this.panel2.TabIndex = 1;
            this.actionViewer.Dock = DockStyle.Fill;
            this.actionViewer.Location = new Point(0, 0);
            this.actionViewer.Name = "actionViewer";
            this.actionViewer.Size = new Size(0x296, 110);
            this.actionViewer.TabIndex = 0;
            this.splitter1.Dock = DockStyle.Bottom;
            this.splitter1.Location = new Point(0, 0x121);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new Size(0x298, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.splitter1);
            base.Controls.Add(this.panel2);
            base.Name = "HungTransportControl";
            base.Size = new Size(0x298, 0x194);
            base.Load += new EventHandler(this.HungTransportControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void OnRedo()
        {
            this._search.Redo();
            this.baseHungControl.Refresh();
        }

        private void OnRedoAll()
        {
            this._search.RedoAll();
            this.baseHungControl.Refresh();
        }

        private void OnUndo()
        {
            this._search.Undo();
            this.baseHungControl.Refresh();
        }

        private void OnUndoAll()
        {
            this._search.UndoAll();
            this.baseHungControl.Refresh();
        }

        private void ParentForm_Closing(object sender, CancelEventArgs e)
        {
            this.baseHungControl.UnsetEvents();
            this.baseHungControl.ValueAAChanged -= new BaseHungControl.ValueAAChangedHandler(this.baseHungControl_ValueAAChanged);
            this.baseHungControl.ValueBBChanged -= new BaseHungControl.ValueBBChangedHandler(this.baseHungControl_ValueBBChanged);
            this.baseHungControl.ValueCDChanged -= new BaseHungControl.ValueCDChangedHandler(this.baseHungControl_ValueCDChanged);
            this.baseHungControl.SelectionCDChanged -= new BaseHungControl.SelectionCDChangedHandler(this.baseHungControl_SelectionCDChanged);
            this.baseHungControl.SetResultNetwork -= new Mephi.K22.LearningSuite.Transport.FF.Base.Net.SetNetworkHandler(this.baseHungControl_SetResultNetwork);
            this.baseHungControl.GoToNet -= new BaseHungControl.GoToNetHandler(this.baseHungControl_GoToNet);
            this.baseHungControl.SetFlow -= new Mephi.K22.LearningSuite.Transport.FF.Base.Net.SetFlowHandler(this.baseHungControl_SetFlow);
            this.baseHungControl.SetMark -= new Mephi.K22.LearningSuite.Transport.FF.Base.Net.SetMarkHandler(this.baseHungControl_SetMark);
            this.baseHungControl.DelMark -= new Mephi.K22.LearningSuite.Transport.FF.Base.Net.DelMarkHandler(this.baseHungControl_DelMark);
            this.baseHungControl.SetResultNetwork -= new Mephi.K22.LearningSuite.Transport.FF.Base.Net.SetNetworkHandler(this.baseHungControl_SetResultNetwork);
            this.actionViewer.OnUndoAll = (ActionViewer.ActionEventHandler) Delegate.Remove(this.actionViewer.OnUndoAll, new ActionViewer.ActionEventHandler(this.OnUndoAll));
            this.actionViewer.OnUndo = (ActionViewer.ActionEventHandler) Delegate.Remove(this.actionViewer.OnUndo, new ActionViewer.ActionEventHandler(this.OnUndo));
            this.actionViewer.OnRedoAll = (ActionViewer.ActionEventHandler) Delegate.Remove(this.actionViewer.OnRedoAll, new ActionViewer.ActionEventHandler(this.OnRedoAll));
            this.actionViewer.OnRedo = (ActionViewer.ActionEventHandler) Delegate.Remove(this.actionViewer.OnRedo, new ActionViewer.ActionEventHandler(this.OnRedo));
            base.ParentForm.Closing -= new CancelEventHandler(this.ParentForm_Closing);
        }

        internal void SetFlowF(int nFrom, int nTo, int h)
        {
            this._net.SetFlowF(nFrom, nTo, h);
        }

        internal void SetMark(int n, bool empty, int z, bool plus, bool inf, int e)
        {
            this._net.SetMark(n, empty, z, plus, inf, e);
        }

        internal void SetNetworkResult()
        {
            this.baseHungControl.DisableNetControl();
        }

        internal void SetResultTable(string netstr, int sum)
        {
            this.baseHungControl.IsOver = true;
        }

        internal void SetSelection(uint i, uint j, bool val)
        {
            this._currTable.SetSelection(i, j, val);
        }

        internal void SetValAA(uint i, int val)
        {
            this._currTable.SetValAA(i, val);
        }

        internal void SetValBB(uint j, int val)
        {
            this._currTable.SetValBB(j, val);
        }

        internal void SetValCD(uint i, uint j, int val)
        {
            this._currTable.SetValCD(i, j, val);
        }

        internal void UndoGoToNet(string newnetstr)
        {
            this._net.Replace(Mephi.K22.LearningSuite.Transport.FF.Base.Net.GetFromString(newnetstr));
            this.baseHungControl.DisableNetControl();
            this.baseHungControl.IsCreateOnSolve = false;
        }

        internal void UndoSetResultNetwork()
        {
            this.baseHungControl.EnableNetControl();
        }

        internal void UndoSetResultTable()
        {
            this.baseHungControl.IsOver = false;
        }

        public ActionCollection Actions
        {
            get
            {
                return this._actions;
            }
            set
            {
                this._actions = value;
            }
        }

        public HungTable CurrTable
        {
            get
            {
                return this._currTable;
            }
            set
            {
                this._currTable = value;
                this.baseHungControl.CurrTable = this._currTable;
            }
        }

        public Mephi.K22.LearningSuite.Transport.FF.Base.Net Net
        {
            get
            {
                return this._net;
            }
            set
            {
                if (this._net != null)
                {
                    this._net.Replace(value);
                }
                else
                {
                    this._net = value;
                }
                this.baseHungControl.Net = this._net;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return this._readOnly;
            }
            set
            {
                this.baseHungControl.EnabledControls = !value;
                this._readOnly = value;
            }
        }

        public HungTable StartTable
        {
            get
            {
                return this._startTable;
            }
            set
            {
                this._startTable = value;
                this.baseHungControl.StartTable = this._startTable;
            }
        }

        public Mephi.K22.LearningSuite.Core.Task Task
        {
            get
            {
                return this._task;
            }
            set
            {
                this._task = value;
            }
        }
    }
}

