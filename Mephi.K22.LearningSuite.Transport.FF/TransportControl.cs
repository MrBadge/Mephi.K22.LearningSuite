// Type: Mephi.K22.LearningSuite.Transport.FF.TransportControl
// Assembly: Mephi.K22.LearningSuite.Transport.FF, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DA688CD5-CC79-4F9D-90F5-6DF17C731483
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.Transport.FF.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.FF
{
  public class TransportControl : BaseMethodControl
  {
    private bool _readOnly = false;
    private Task _task = (Task) null;
    private ActionCollection _actions = (ActionCollection) null;
    private Net _net = (Net) null;
    private Container components = (Container) null;
    private FFSearch _ffSearch;
    private Panel panel1;
    private Panel panel2;
    private Splitter splitter1;
    internal ActionViewer actionViewer;
    private BaseNetControl baseNetControl;

    public Net Net
    {
      set
      {
        this._net = value;
        this.baseNetControl.Net = this._net;
      }
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

    public Task Task
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

    public bool ReadOnly
    {
      get
      {
        return this._readOnly;
      }
      set
      {
        this.baseNetControl.EnabledControls = !value;
        this._readOnly = value;
      }
    }

    internal bool RequireCreateNet
    {
      get
      {
        return this.baseNetControl.IsCreateOnSolve;
      }
      set
      {
        this.baseNetControl.IsCreateOnSolve = value;
      }
    }

    public TransportControl(FFSearch ffSearch)
    {
      this.InitializeComponent();
      this._ffSearch = ffSearch;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.panel1 = new Panel();
      this.actionViewer = new ActionViewer();
      this.panel2 = new Panel();
      this.baseNetControl = new BaseNetControl();
      this.splitter1 = new Splitter();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.actionViewer);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 304);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(664, 100);
      this.panel1.TabIndex = 0;
      this.actionViewer.Dock = DockStyle.Fill;
      this.actionViewer.Location = new Point(0, 0);
      this.actionViewer.Name = "actionViewer";
      this.actionViewer.Size = new Size(662, 98);
      this.actionViewer.TabIndex = 0;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.baseNetControl);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(664, 304);
      this.panel2.TabIndex = 1;
      this.baseNetControl.Actions = (ActionCollection) null;
      this.baseNetControl.Dock = DockStyle.Fill;
      this.baseNetControl.EnabledControls = false;
      this.baseNetControl.Location = new Point(0, 0);
      this.baseNetControl.Name = "baseNetControl";
      this.baseNetControl.Size = new Size(662, 302);
      this.baseNetControl.TabIndex = 0;
      this.baseNetControl.Task = (Task) null;
      this.baseNetControl.IsCreate = false;
      this.splitter1.Cursor = Cursors.HSplit;
      this.splitter1.Dock = DockStyle.Bottom;
      this.splitter1.Location = new Point(0, 301);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new Size(664, 3);
      this.splitter1.TabIndex = 2;
      this.splitter1.TabStop = false;
      this.Controls.Add((Control) this.splitter1);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Name = "TransportControl";
      this.Size = new Size(664, 404);
      this.Load += new EventHandler(this.TransportControl_Load);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    internal void baseNetControl_OnShowTask(object sender, EventArgs e)
    {
      BaseTaskObjectForm baseTaskObjectForm = new BaseTaskObjectForm();
      baseTaskObjectForm.btnCancel.Visible = false;
      baseTaskObjectForm.Text = "Просмотр задания";
      int num = (int) baseTaskObjectForm.ShowDialog();
    }

    private void TransportControl_Load(object sender, EventArgs e)
    {
      this.baseNetControl.SetMark += new Net.SetMarkHandler(this.baseNetControl_SetMark);
      this.baseNetControl.SetFlowF += new Net.SetFlowHandler(this.baseNetControl_SetFlowF);
      this.baseNetControl.DelMark += new Net.DelMarkHandler(this.baseNetControl_DelMark);
      this.baseNetControl.SetResult += new Net.SetResultHandler(this.baseNetControl_SetResult);
      this.actionViewer.SetDataBinding(this._actions);
      this.actionViewer.OnUndoAll += new ActionViewer.ActionEventHandler(this.OnUndoAll);
      this.actionViewer.OnUndo += new ActionViewer.ActionEventHandler(this.OnUndo);
      this.actionViewer.OnRedoAll += new ActionViewer.ActionEventHandler(this.OnRedoAll);
      this.actionViewer.OnRedo += new ActionViewer.ActionEventHandler(this.OnRedo);
      this.baseNetControl.SetNetEvent += new Net.SetNetworkHandler(this.baseNetControl_SetNetEvent);
      this.ParentForm.Closing += new CancelEventHandler(this.ParentForm_Closing);
    }

    private void ParentForm_Closing(object sender, CancelEventArgs e)
    {
      this.baseNetControl.SetMark -= new Net.SetMarkHandler(this.baseNetControl_SetMark);
      this.baseNetControl.SetFlowF -= new Net.SetFlowHandler(this.baseNetControl_SetFlowF);
      this.baseNetControl.DelMark -= new Net.DelMarkHandler(this.baseNetControl_DelMark);
      this.baseNetControl.SetResult -= new Net.SetResultHandler(this.baseNetControl_SetResult);
      this.actionViewer.OnUndoAll -= new ActionViewer.ActionEventHandler(this.OnUndoAll);
      this.actionViewer.OnUndo -= new ActionViewer.ActionEventHandler(this.OnUndo);
      this.actionViewer.OnRedoAll -= new ActionViewer.ActionEventHandler(this.OnRedoAll);
      this.actionViewer.OnRedo -= new ActionViewer.ActionEventHandler(this.OnRedo);
      this.baseNetControl.SetNetEvent -= new Net.SetNetworkHandler(this.baseNetControl_SetNetEvent);
      this.ParentForm.Closing -= new CancelEventHandler(this.ParentForm_Closing);
    }

    internal void SetMark(int n, bool empty, int z, bool plus, bool inf, int e)
    {
      this._net.SetMark(n, empty, z, plus, inf, e);
    }

    internal void SetFlowF(int nFrom, int nTo, int h)
    {
      this._net.SetFlowF(nFrom, nTo, h);
    }

    internal void DelMark(int n)
    {
      this._net.DelMark(n);
    }

    internal void SetResult(int n)
    {
      this.baseNetControl.IsOver = true;
    }

    internal void UndoStop()
    {
      this.baseNetControl.IsOver = false;
    }

    internal void SetNetwork(string s1)
    {
      this._net.Replace(Net.GetFromString(s1));
      this.baseNetControl.IsCreateOnSolve = false;
    }

    internal void UndoSetNetwork(string s1)
    {
      this._net.Replace(Net.GetFromString(s1));
      this.baseNetControl.IsCreateOnSolve = true;
    }

    private void baseNetControl_SetNetEvent(Net n1)
    {
      this.ffSearch_SetNetwork(n1);
    }

    internal void ffSearch_SetNetwork(Net n1)
    {
      Action act = new Action();
      act.ActionType = (byte) 5;
      act.Parameters = new object[2]
      {
        (object) n1.GetString(),
        (object) this._net.GetString()
      };
      act.Message = string.Format("Задана сеть", new object[0]);
      this._actions.Add(act);
      int num = (int) this._ffSearch.RunAction(act, false);
    }

    private void baseNetControl_SetMark(Node n, bool empty, int z, bool plus, bool inf, int e)
    {
      Action act = new Action();
      act.ActionType = (byte) 2;
      act.Parameters = new object[12]
      {
        (object) n.Number,
        (object) empty,
        (object) z,
        (object) plus,
        (object) inf,
        (object) e,
        (object) n.IsMark,
        (object) n.IsEmpty,
        (object) n.Z,
        (object) n.Plus,
        (object) n.Inf,
        (object) n.E
      };
      act.Message = string.Format("Установлена пометка {1}{2};{3} на вершину {0}", act.Parameters[0], (bool) act.Parameters[1] ? (object) "" : act.Parameters[2], (bool) act.Parameters[3] ? (object) "+" : (object) "-", (bool) act.Parameters[4] ? (object) "inf" : act.Parameters[5]);
      this._actions.Add(act);
      int num = (int) this._ffSearch.RunAction(act, false);
    }

    private void baseNetControl_SetFlowF(Arc a, int f)
    {
      Action act = new Action();
      act.ActionType = (byte) 1;
      act.Parameters = new object[4]
      {
        (object) this._net.GetArcFrom(a).Number,
        (object) this._net.GetArcTo(a).Number,
        (object) f,
        (object) a.F
      };
      act.Message = string.Format("Задан поток F {0} дуги {1}-{2}", act.Parameters[2], act.Parameters[0], act.Parameters[1]);
      this._actions.Add(act);
      int num = (int) this._ffSearch.RunAction(act, false);
    }

    private void baseNetControl_DelMark(Node n)
    {
      Action act = new Action();
      act.ActionType = (byte) 3;
      act.Parameters = new object[6]
      {
        (object) n.Number,
        (object) n.IsEmpty,
        (object) n.Z,
        (object) n.Plus,
        (object) n.Inf,
        (object) n.E
      };
      act.Message = string.Format("Удалена пометка с вершины {0}", act.Parameters[0]);
      this._actions.Add(act);
      int num = (int) this._ffSearch.RunAction(act, false);
    }

    private void baseNetControl_SetResult(int res)
    {
      Action act = new Action();
      act.ActionType = (byte) 4;
      act.Parameters = new object[1]
      {
        (object) res
      };
      act.Message = string.Format("Задан результат {0}", act.Parameters[0]);
      this._actions.Add(act);
      int num = (int) this._ffSearch.RunAction(act, false);
    }

    private void OnUndoAll()
    {
      this._ffSearch.UndoAll();
      this.baseNetControl.Refresh();
    }

    private void OnUndo()
    {
      this._ffSearch.Undo();
      this.baseNetControl.Refresh();
    }

    private void OnRedo()
    {
      this._ffSearch.Redo();
      this.baseNetControl.Refresh();
    }

    private void OnRedoAll()
    {
      this._ffSearch.RedoAll();
      this.baseNetControl.Refresh();
    }
  }
}
