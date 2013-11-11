// Type: Mephi.K22.LearningSuite.Transport.FF.Base.BaseNetControl
// Assembly: Mephi.K22.LearningSuite.Transport.FF.Base, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07732E5D-62A2-40BA-B564-99E5EF219EBC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.Base.dll

using Mephi.K22.LearningSuite.Core;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.FF.Base
{
  public class BaseNetControl : UserControl
  {
    public bool IsHInfEnable = false;
    private bool _isCreate = false;
    private bool _isOver = false;
    private bool _isCreateOnSolve = false;
    protected Net _net = (Net) null;
    private ActionCollection _actions = (ActionCollection) null;
    private bool _isMoving = false;
    private Node _tempNode = (Node) null;
    protected Arc _tempArc = (Arc) null;
    private Point _prevMouse = new Point(0, 0);
    private Task _task = (Task) null;
    public string TaskName = string.Empty;
    private bool _enabledControls;
    private Panel panelGraph;
    protected pnlgrph panelImage;
    private ToolBar toolBarNet;
    private ContextMenu cmNode;
    private ContextMenu cmArc;
    private MenuItem setMark;
    private MenuItem unsetMark;
    private MenuItem setFlow;
    private ToolBarButton tbbCreateNode;
    private ToolBarButton tbbCreateArc;
    private ImageList imageList;
    private ToolBarButton tbbSeparator1;
    private ContextMenu cmArcCreate;
    private MenuItem miSetFlowH;
    public ToolBarButton tbbSetSourceTarget;
    public ToolBarButton tbbSetResult;
    private ToolBarButton tbbSeparator2;
    private ToolBarButton tbbCreateNet;
    private ToolBarButton tbbDelete;
    private IContainer components;

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

    public bool EnabledControls
    {
      get
      {
        return this._enabledControls;
      }
      set
      {
        this._enabledControls = value;
        this.Enabled = this._enabledControls && !this._isOver;
      }
    }

    public bool IsOver
    {
      get
      {
        return this._isOver;
      }
      set
      {
        this._isOver = value;
        this.Enabled = this._enabledControls && !this._isOver;
      }
    }

    public bool IsCreateOnSolve
    {
      get
      {
        return this._isCreateOnSolve;
      }
      set
      {
        this._isCreateOnSolve = value;
        if (value)
        {
          this.tbbSetResult.Visible = false;
          this.tbbSeparator2.Visible = false;
          this.tbbCreateNet.Visible = true;
          this.panelImage.Enabled = false;
        }
        else
        {
          this.tbbSetResult.Visible = true;
          this.tbbSeparator2.Visible = false;
          this.tbbCreateNet.Visible = false;
          this.panelImage.Enabled = true;
        }
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

    public Net Net
    {
      get
      {
        return this._net;
      }
      set
      {
        this._net = value;
        this.panelImage.Invalidate();
      }
    }

    public bool IsCreate
    {
      get
      {
        return this._isCreate;
      }
      set
      {
        this._isCreate = value;
        this.tbbCreateArc.Visible = value;
        this.tbbDelete.Visible = value;
        this.tbbCreateNode.Visible = value;
        this.tbbSeparator1.Visible = value;
        this.tbbSetSourceTarget.Visible = value;
        this.tbbSeparator1.Visible = false;
        this.tbbSetResult.Visible = !value;
        this.tbbSeparator2.Visible = !value;
        this.tbbCreateNet.Visible = !value;
      }
    }

    public event Net.SetMarkHandler SetMark;

    public event Net.SetNetworkHandler SetNetEvent;

    public event Net.DelMarkHandler DelMark;

    public event Net.SetFlowHandler SetFlowF;

    public event Net.SetResultHandler SetResult;

    public BaseNetControl()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ResourceManager resourceManager = new ResourceManager(typeof (BaseNetControl));
      this.panelGraph = new Panel();
      this.panelImage = new pnlgrph();
      this.toolBarNet = new ToolBar();
      this.tbbCreateNode = new ToolBarButton();
      this.tbbCreateArc = new ToolBarButton();
      this.tbbSetSourceTarget = new ToolBarButton();
      this.tbbSeparator1 = new ToolBarButton();
      this.tbbSetResult = new ToolBarButton();
      this.tbbSeparator2 = new ToolBarButton();
      this.tbbCreateNet = new ToolBarButton();
      this.imageList = new ImageList(this.components);
      this.cmNode = new ContextMenu();
      this.setMark = new MenuItem();
      this.unsetMark = new MenuItem();
      this.cmArc = new ContextMenu();
      this.setFlow = new MenuItem();
      this.cmArcCreate = new ContextMenu();
      this.miSetFlowH = new MenuItem();
      this.tbbDelete = new ToolBarButton();
      this.panelGraph.SuspendLayout();
      this.SuspendLayout();
      this.panelGraph.BackColor = SystemColors.Control;
      this.panelGraph.Controls.Add((Control) this.panelImage);
      this.panelGraph.Controls.Add((Control) this.toolBarNet);
      this.panelGraph.Dock = DockStyle.Fill;
      this.panelGraph.Location = new Point(0, 0);
      this.panelGraph.Name = "panelGraph";
      this.panelGraph.Size = new Size(728, 488);
      this.panelGraph.TabIndex = 0;
      this.panelImage.BackColor = Color.White;
      this.panelImage.BorderStyle = BorderStyle.FixedSingle;
      this.panelImage.Dock = DockStyle.Fill;
      this.panelImage.Location = new Point(0, 29);
      this.panelImage.Name = "panelImage";
      this.panelImage.Size = new Size(728, 459);
      this.panelImage.TabIndex = 3;
      this.panelImage.Resize += new EventHandler(this.panelImage_Resize);
      this.panelImage.MouseUp += new MouseEventHandler(this.panelImage_MouseUp);
      this.panelImage.Paint += new PaintEventHandler(this.panelImage_Paint);
      this.panelImage.MouseMove += new MouseEventHandler(this.panelImage_MouseMove);
      this.panelImage.MouseDown += new MouseEventHandler(this.panelImage_MouseDown);
      this.toolBarNet.Appearance = ToolBarAppearance.Flat;
      this.toolBarNet.BorderStyle = BorderStyle.FixedSingle;
      this.toolBarNet.Buttons.AddRange(new ToolBarButton[8]
      {
        this.tbbCreateNode,
        this.tbbCreateArc,
        this.tbbDelete,
        this.tbbSetSourceTarget,
        this.tbbSeparator1,
        this.tbbSetResult,
        this.tbbSeparator2,
        this.tbbCreateNet
      });
      this.toolBarNet.DropDownArrows = true;
      this.toolBarNet.ImageList = this.imageList;
      this.toolBarNet.Location = new Point(0, 0);
      this.toolBarNet.Name = "toolBarNet";
      this.toolBarNet.ShowToolTips = true;
      this.toolBarNet.Size = new Size(728, 29);
      this.toolBarNet.TabIndex = 4;
      this.toolBarNet.TextAlign = ToolBarTextAlign.Right;
      this.toolBarNet.ButtonClick += new ToolBarButtonClickEventHandler(this.toolBarNet_ButtonClick);
      this.tbbCreateNode.ImageIndex = 0;
      this.tbbCreateNode.Visible = false;
      this.tbbCreateArc.ImageIndex = 1;
      this.tbbCreateArc.Visible = false;
      this.tbbSetSourceTarget.ImageIndex = 3;
      this.tbbSetSourceTarget.Visible = false;
      this.tbbSeparator1.Style = ToolBarButtonStyle.Separator;
      this.tbbSeparator1.Visible = false;
      this.tbbSetResult.ImageIndex = 4;
      this.tbbSetResult.Text = "Результат";
      this.tbbSeparator2.Style = ToolBarButtonStyle.Separator;
      this.tbbCreateNet.ImageIndex = 5;
      this.tbbCreateNet.Text = "Изменить";
      this.imageList.ImageSize = new Size(16, 16);
      this.imageList.ImageStream = (ImageListStreamer) resourceManager.GetObject("imageList.ImageStream");
      this.imageList.TransparentColor = Color.Transparent;
      this.cmNode.MenuItems.AddRange(new MenuItem[2]
      {
        this.setMark,
        this.unsetMark
      });
      this.setMark.Index = 0;
      this.setMark.Text = "Установить пометку";
      this.setMark.Click += new EventHandler(this.setMark_Click);
      this.unsetMark.Index = 1;
      this.unsetMark.Text = "Удалить пометку";
      this.unsetMark.Click += new EventHandler(this.unsetMark_Click);
      this.cmArc.MenuItems.AddRange(new MenuItem[1]
      {
        this.setFlow
      });
      this.setFlow.Index = 0;
      this.setFlow.Text = "Задать поток";
      this.setFlow.Click += new EventHandler(this.setFlow_Click);
      this.cmArcCreate.MenuItems.AddRange(new MenuItem[1]
      {
        this.miSetFlowH
      });
      this.miSetFlowH.Index = 0;
      this.miSetFlowH.Text = "Задать поток";
      this.miSetFlowH.Click += new EventHandler(this.menuItem1_Click);
      this.tbbDelete.ImageIndex = 6;
      this.tbbDelete.Visible = false;
      this.Controls.Add((Control) this.panelGraph);
      this.Name = "BaseNetControl";
      this.Size = new Size(728, 488);
      this.Load += new EventHandler(this.BaseNetControl_Load);
      this.panelGraph.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void setMark_Click(object sender, EventArgs e)
    {
      using (SetMark setMark = new SetMark())
      {
        if (setMark.ShowDialog() != DialogResult.OK || this._tempNode == null)
          return;
        if (this.SetMark != null)
          this.SetMark(this._tempNode, setMark.Empty, setMark.Z, setMark.Plus, setMark.Inf, setMark.E);
        this.panelImage.Invalidate();
      }
    }

    private void setFlow_Click(object sender, EventArgs e)
    {
      if (this._tempArc == null)
        return;
      using (SetFlow setFlow = new SetFlow())
      {
        setFlow.IsHInf = this._tempArc.InfH;
        setFlow.FlowH = this._tempArc.H;
        setFlow.FlowF = this._tempArc.F;
        setFlow.SetFFocus();
        setFlow.tbFlowF.ReadOnly = false;
        setFlow.tbFlowH.ReadOnly = true;
        setFlow.rbHinf.Enabled = false;
        setFlow.rbHVal.Enabled = false;
        if (setFlow.ShowDialog() == DialogResult.OK && this.SetFlowF != null)
          this.SetFlowF(this._tempArc, setFlow.FlowF);
        this.panelImage.Invalidate();
      }
    }

    private void unsetMark_Click(object sender, EventArgs e)
    {
      if (this._tempNode == null || this.DelMark == null)
        return;
      this.DelMark(this._tempNode);
    }

    protected virtual void SetResultInternal()
    {
      using (SetResultFrm setResultFrm = new SetResultFrm())
      {
        if (setResultFrm.ShowDialog() != DialogResult.OK || this.SetResult == null)
          return;
        this.SetResult(setResultFrm.Result);
      }
    }

    private void SetNetInternal()
    {
      if (this.SetNetEvent == null)
        return;
      Net net = this._net.Clone();
      using (BaseTaskObjectForm baseTaskObjectForm = new BaseTaskObjectForm())
      {
        baseTaskObjectForm.TaskObjectControl = (BaseTaskObjectControl) new ShowNetTaskObject(string.Empty, net, true);
        baseTaskObjectForm.btnCancel.Visible = false;
        baseTaskObjectForm.Text = "Создание сети";
        ((ShowNetTaskObject) baseTaskObjectForm.TaskObjectControl).panelTop.Visible = false;
        int num = (int) baseTaskObjectForm.ShowDialog();
        this.SetNetEvent(net);
      }
    }

    private void SetNet(Net n1)
    {
      this._net.Replace(n1);
      this.panelImage.Invalidate();
    }

    private void BaseNetControl_Load(object sender, EventArgs e)
    {
    }

    private void toolBarNet_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
    {
      if (e.Button == this.tbbCreateNode)
        this._net.AddNode(new Node(20, 20, this._net.NodeCounter));
      else if (e.Button == this.tbbCreateArc)
      {
        using (AddArc addArc = new AddArc())
        {
          if (addArc.ShowDialog() == DialogResult.OK)
          {
            if (this._net[addArc.FromArc] != null)
            {
              if (this._net[addArc.ToArc] != null)
                this._net.AddArc(this._net[addArc.FromArc], this._net[addArc.ToArc]);
            }
          }
        }
      }
      else if (e.Button == this.tbbSetSourceTarget)
      {
        using (SetSourceTarget setSourceTarget = new SetSourceTarget())
        {
          setSourceTarget.Source = this._net.StartNode != null ? this._net.StartNode.Number : 0;
          setSourceTarget.Target = this._net.EndNode != null ? this._net.EndNode.Number : 0;
          if (setSourceTarget.ShowDialog() == DialogResult.OK)
          {
            this._net.StartNode = this._net[setSourceTarget.Source];
            this._net.EndNode = this._net[setSourceTarget.Target];
          }
        }
      }
      else if (e.Button == this.tbbSetResult)
        this.SetResultInternal();
      else if (e.Button == this.tbbCreateNet)
        this.SetNetInternal();
      else if (e.Button == this.tbbDelete)
      {
        if (this._tempArc != null)
        {
          this._net.RemoveArc(this._tempArc);
          this._tempArc = (Arc) null;
        }
        else if (this._tempNode != null)
        {
          this._net.RemoveNode(this._tempNode);
          this._tempNode = (Node) null;
        }
      }
      this.panelImage.Invalidate();
    }

    private void panelImage_Paint(object sender, PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      graphics.Clear(Color.White);
      if (this._net == null)
        return;
      this._net.DrawNet(graphics);
    }

    private void panelImage_Resize(object sender, EventArgs e)
    {
      this.panelImage.Invalidate();
    }

    protected void BaseNetControl_SetFlowH(Arc a, int h, bool isInf)
    {
      if (a == null)
        return;
      a.H = h;
      a.InfH = isInf;
    }

    protected virtual void menuItem1_Click(object sender, EventArgs e)
    {
      using (SetFlow setFlow = new SetFlow())
      {
        setFlow.tbFlowF.ReadOnly = true;
        setFlow.tbFlowH.ReadOnly = false;
        if (this.IsHInfEnable)
          setFlow.rbHinf.Enabled = true;
        else
          setFlow.rbHinf.Enabled = false;
        if (this._tempArc.InfH)
        {
          setFlow.rbHinf.Checked = true;
          setFlow.rbHVal.Checked = false;
          setFlow.tbFlowH.Text = string.Empty;
        }
        else
        {
          setFlow.rbHinf.Checked = false;
          setFlow.rbHVal.Checked = true;
          setFlow.tbFlowH.Text = this._tempArc.H.ToString();
        }
        if (setFlow.ShowDialog() == DialogResult.OK)
          this.BaseNetControl_SetFlowH(this._tempArc, setFlow.FlowH, setFlow.IsHInf);
        this.panelImage.Invalidate();
      }
    }

    private void panelImage_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this._isMoving || this._tempNode == null)
        return;
      this._net.MoveNode(this._tempNode, e.X - this._prevMouse.X, e.Y - this._prevMouse.Y);
      this._prevMouse.X = e.X;
      this._prevMouse.Y = e.Y;
      this.Refresh();
    }

    private void panelImage_MouseUp(object sender, MouseEventArgs e)
    {
      if (this._net == null)
        return;
      if (this._isCreate)
      {
        if (this._net.GetClicked(e.X, e.Y) is Arc && e.Button == MouseButtons.Right)
          this.cmArcCreate.Show((Control) this, new Point(e.X, e.Y + 20));
      }
      else if (e.Button == MouseButtons.Left)
      {
        if (!this._isMoving || this._tempNode == null)
          ;
      }
      else if (e.Button == MouseButtons.Right)
      {
        Element clicked = this._net.GetClicked(e.X, e.Y);
        if (clicked is Node)
        {
          if (((Node) clicked).IsMark)
          {
            this.setMark.Enabled = true;
            this.unsetMark.Enabled = true;
          }
          else
          {
            this.setMark.Enabled = true;
            this.unsetMark.Enabled = false;
          }
          this.cmNode.Show((Control) this, new Point(e.X, e.Y));
        }
        else if (clicked is Arc)
          this.cmArc.Show((Control) this, new Point(e.X, e.Y + 20));
      }
      this._isMoving = false;
      this.panelImage.Invalidate();
    }

    private void panelImage_MouseDown(object sender, MouseEventArgs e)
    {
      if (this._net == null)
        return;
      Element clicked = this._net.GetClicked(e.X, e.Y);
      if (clicked != null)
      {
        if (this._net != null)
          this._net.UnselectAll();
        clicked.DrawObject.IsSelected = true;
        if (clicked.GetType() == typeof (Node))
        {
          this._tempNode = (Node) clicked;
          this._tempArc = (Arc) null;
          this._isMoving = true;
          this._prevMouse.X = e.X;
          this._prevMouse.Y = e.Y;
        }
        else if (clicked.GetType() == typeof (Arc))
        {
          this._tempArc = (Arc) clicked;
          this._tempNode = (Node) null;
        }
      }
      this.Refresh();
    }
  }
}
