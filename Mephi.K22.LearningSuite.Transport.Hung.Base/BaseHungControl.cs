// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.BaseHungControl
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.Transport.FF.Base;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public class BaseHungControl : UserControl
  {
    private bool _isOver = false;
    private HungTable _startTable = (HungTable) null;
    private HungTable _currTable = (HungTable) null;
    private Net _net = (Net) null;
    private Net _tempNet = (Net) null;
    private HungTable _resHungTable = (HungTable) null;
    private ArrayList _correspondTable = new ArrayList();
    private bool _enabledControls;
    private Panel panelLeft;
    private Panel panelTables;
    private ImageList imageList;
    private HungNetControl baseNetControl;
    private Splitter splitter;
    private Panel panelRight;
    private HungTableControl startHTControl;
    private HungTableControl currHTControl;
    private Label lblCurrTable;
    private Label lblStartTable;
    private Button btnSetResult;
    private Button btn2net;
    private Panel panelLeftButtom;
    private IContainer components;

    public HungTable StartTable
    {
      get
      {
        return this._startTable;
      }
      set
      {
        if (value == null)
          return;
        this._startTable = value;
        this.startHTControl.SetDimensions(this._startTable.DimV, this._startTable.DimH);
        this.startHTControl.Subscribe(this._startTable);
        this.currHTControl.Location = new Point(this.currHTControl.Location.X, this.startHTControl.Location.Y * 2 + this.startHTControl.Height);
        this.lblCurrTable.Location = new Point(this.lblCurrTable.Location.X, this.lblStartTable.Location.Y + this.startHTControl.Location.Y + this.startHTControl.Height);
        this.startHTControl.ReadOnly = true;
        this.panelTables.Width = this.startHTControl.Location.X + this.startHTControl.Width + 4;
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
        if (value == null)
          return;
        this._currTable = value;
        this.currHTControl.ReadOnly = false;
        this.currHTControl.SetDimensions(this._currTable.DimV, this._currTable.DimH);
        this.currHTControl.Subscribe(this._currTable);
        this.currHTControl.ValueAAChanged += new HungTableControl.ValueAAChangedHandler(this.currHTControl_ValueAAChanged);
        this.currHTControl.ValueBBChanged += new HungTableControl.ValueBBChangedHandler(this.currHTControl_ValueBBChanged);
        this.currHTControl.ValueCDChanged += new HungTableControl.ValueCDChangedHandler(this.currHTControl_ValueCDChanged);
        this.currHTControl.SelectionCDChanged += new HungTableControl.SelectionCDChangedHandler(this.currHTControl_SelectionCDChanged);
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
        this.panelLeft.Enabled = this._enabledControls && !this._isOver;
        this.panelRight.Enabled = this._enabledControls && !this._isOver;
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
        this.baseNetControl.Net = this._net;
        this.baseNetControl.Refresh();
      }
    }

    public bool IsCreateOnSolve
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

    public bool IsOver
    {
      get
      {
        return this._isOver;
      }
      set
      {
        this._isOver = value;
        this.panelLeft.Enabled = this._enabledControls && !this._isOver;
        this.panelRight.Enabled = this._enabledControls && !this._isOver;
      }
    }

    public event BaseHungControl.ValueAAChangedHandler ValueAAChanged;

    public event BaseHungControl.ValueBBChangedHandler ValueBBChanged;

    public event BaseHungControl.ValueCDChangedHandler ValueCDChanged;

    public event BaseHungControl.SelectionCDChangedHandler SelectionCDChanged;

    public event BaseHungControl.GoToNetHandler GoToNet;

    public event Net.SetMarkHandler SetMark;

    public event Net.SetFlowHandler SetFlow;

    public event Net.DelMarkHandler DelMark;

    public event Net.SetNetworkHandler SetResultNetwork;

    public event BaseHungControl.SetResultTableHandler SetResultTable;

    public BaseHungControl()
    {
      this.InitializeComponent();
      this.baseNetControl.tbbSetResult.Text = "К таблице";
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
      ResourceManager resourceManager = new ResourceManager(typeof (BaseHungControl));
      this.panelLeft = new Panel();
      this.panelTables = new Panel();
      this.lblCurrTable = new Label();
      this.lblStartTable = new Label();
      this.currHTControl = new HungTableControl();
      this.startHTControl = new HungTableControl();
      this.panelLeftButtom = new Panel();
      this.btnSetResult = new Button();
      this.btn2net = new Button();
      this.imageList = new ImageList(this.components);
      this.baseNetControl = new HungNetControl();
      this.splitter = new Splitter();
      this.panelRight = new Panel();
      this.panelLeft.SuspendLayout();
      this.panelTables.SuspendLayout();
      this.panelLeftButtom.SuspendLayout();
      this.panelRight.SuspendLayout();
      this.SuspendLayout();
      this.panelLeft.BorderStyle = BorderStyle.FixedSingle;
      this.panelLeft.Controls.Add((Control) this.panelTables);
      this.panelLeft.Controls.Add((Control) this.panelLeftButtom);
      this.panelLeft.Dock = DockStyle.Left;
      this.panelLeft.Location = new Point(0, 0);
      this.panelLeft.Name = "panelLeft";
      this.panelLeft.Size = new Size(164, 488);
      this.panelLeft.TabIndex = 0;
      this.panelTables.AutoScroll = true;
      this.panelTables.BackColor = SystemColors.Control;
      this.panelTables.Controls.Add((Control) this.lblCurrTable);
      this.panelTables.Controls.Add((Control) this.lblStartTable);
      this.panelTables.Controls.Add((Control) this.currHTControl);
      this.panelTables.Controls.Add((Control) this.startHTControl);
      this.panelTables.Dock = DockStyle.Fill;
      this.panelTables.Location = new Point(0, 0);
      this.panelTables.Name = "panelTables";
      this.panelTables.Size = new Size(162, 434);
      this.panelTables.TabIndex = 1;
      this.lblCurrTable.Location = new Point(4, 104);
      this.lblCurrTable.Name = "lblCurrTable";
      this.lblCurrTable.Size = new Size(112, 20);
      this.lblCurrTable.TabIndex = 5;
      this.lblCurrTable.Text = "Текущая таблица";
      this.lblCurrTable.TextAlign = ContentAlignment.BottomLeft;
      this.lblStartTable.Location = new Point(4, 0);
      this.lblStartTable.Name = "lblStartTable";
      this.lblStartTable.Size = new Size(112, 20);
      this.lblStartTable.TabIndex = 4;
      this.lblStartTable.Text = "Начальная таблица";
      this.lblStartTable.TextAlign = ContentAlignment.BottomLeft;
      this.currHTControl.Location = new Point(4, 124);
      this.currHTControl.Name = "currHTControl";
      this.currHTControl.ReadOnly = false;
      this.currHTControl.Selectable = true;
      this.currHTControl.Size = new Size(80, 80);
      this.currHTControl.TabIndex = 1;
      this.startHTControl.Location = new Point(4, 20);
      this.startHTControl.Name = "startHTControl";
      this.startHTControl.ReadOnly = false;
      this.startHTControl.Selectable = true;
      this.startHTControl.Size = new Size(80, 80);
      this.startHTControl.TabIndex = 0;
      this.panelLeftButtom.Controls.Add((Control) this.btnSetResult);
      this.panelLeftButtom.Controls.Add((Control) this.btn2net);
      this.panelLeftButtom.Dock = DockStyle.Bottom;
      this.panelLeftButtom.Location = new Point(0, 434);
      this.panelLeftButtom.Name = "panelLeftButtom";
      this.panelLeftButtom.Size = new Size(162, 52);
      this.panelLeftButtom.TabIndex = 2;
      this.btnSetResult.Location = new Point(4, 28);
      this.btnSetResult.Name = "btnSetResult";
      this.btnSetResult.Size = new Size(112, 20);
      this.btnSetResult.TabIndex = 3;
      this.btnSetResult.Text = "Вывод результата";
      this.btnSetResult.Click += new EventHandler(this.btnSetResult_Click);
      this.btn2net.Location = new Point(4, 4);
      this.btn2net.Name = "btn2net";
      this.btn2net.Size = new Size(112, 20);
      this.btn2net.TabIndex = 2;
      this.btn2net.Text = "Переход к сети";
      this.btn2net.Click += new EventHandler(this.btn2net_Click);
      this.imageList.ImageSize = new Size(16, 16);
      this.imageList.ImageStream = (ImageListStreamer) resourceManager.GetObject("imageList.ImageStream");
      this.imageList.TransparentColor = Color.Transparent;
      this.baseNetControl.Actions = (ActionCollection) null;
      this.baseNetControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.baseNetControl.EnabledControls = true;
      this.baseNetControl.IsCreate = false;
      this.baseNetControl.IsCreateOnSolve = false;
      this.baseNetControl.IsOver = false;
      this.baseNetControl.Location = new Point(1, 0);
      this.baseNetControl.Name = "baseNetControl";
      this.baseNetControl.Net = (Net) null;
      this.baseNetControl.Size = new Size(560, 488);
      this.baseNetControl.TabIndex = 0;
      this.baseNetControl.Task = (Task) null;
      this.splitter.Location = new Point(164, 0);
      this.splitter.Name = "splitter";
      this.splitter.Size = new Size(3, 488);
      this.splitter.TabIndex = 2;
      this.splitter.TabStop = false;
      this.panelRight.Controls.Add((Control) this.baseNetControl);
      this.panelRight.Dock = DockStyle.Fill;
      this.panelRight.Enabled = false;
      this.panelRight.Location = new Point(167, 0);
      this.panelRight.Name = "panelRight";
      this.panelRight.Size = new Size(561, 488);
      this.panelRight.TabIndex = 3;
      this.Controls.Add((Control) this.panelRight);
      this.Controls.Add((Control) this.splitter);
      this.Controls.Add((Control) this.panelLeft);
      this.Name = "BaseHungControl";
      this.Size = new Size(728, 488);
      this.Load += new EventHandler(this.BaseHungControl_Load);
      this.panelLeft.ResumeLayout(false);
      this.panelTables.ResumeLayout(false);
      this.panelLeftButtom.ResumeLayout(false);
      this.panelRight.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void currHTControl_ValueAAChanged(uint i, int val)
    {
      if (this.ValueAAChanged == null)
        return;
      this.ValueAAChanged(i, val);
    }

    private void currHTControl_ValueBBChanged(uint j, int val)
    {
      if (this.ValueBBChanged == null)
        return;
      this.ValueBBChanged(j, val);
    }

    private void currHTControl_ValueCDChanged(uint i, uint j, int val)
    {
      if (this.ValueCDChanged == null)
        return;
      this.ValueCDChanged(i, j, val);
    }

    private void currHTControl_SelectionCDChanged(uint i, uint j, bool val)
    {
      if (this.SelectionCDChanged == null)
        return;
      this.SelectionCDChanged(i, j, val);
    }

    private void btn2net_Click(object sender, EventArgs e)
    {
      if (this.GoToNet == null)
        return;
      this._tempNet = this._net.Clone();
      this._tempNet.ClearMarkAndFlow();
      using (BaseTaskObjectForm baseTaskObjectForm = new BaseTaskObjectForm())
      {
        baseTaskObjectForm.TaskObjectControl = (BaseTaskObjectControl) new Mephi.K22.LearningSuite.Transport.FF.ShowNetTaskObject(string.Empty, this._tempNet, true);
        baseTaskObjectForm.btnCancel.Visible = false;
        baseTaskObjectForm.Text = "Создайте сеть";
        ((Mephi.K22.LearningSuite.Transport.FF.ShowNetTaskObject) baseTaskObjectForm.TaskObjectControl).panelTop.Visible = false;
        ((Mephi.K22.LearningSuite.Transport.FF.ShowNetTaskObject) baseTaskObjectForm.TaskObjectControl).baseNetControl1.tbbSetSourceTarget.Visible = false;
        ((Mephi.K22.LearningSuite.Transport.FF.ShowNetTaskObject) baseTaskObjectForm.TaskObjectControl).baseNetControl1.IsHInfEnable = true;
        baseTaskObjectForm.Closing += new CancelEventHandler(this.tf_Closing);
        if (baseTaskObjectForm.ShowDialog() != DialogResult.OK)
          ;
        baseTaskObjectForm.Closing -= new CancelEventHandler(this.tf_Closing);
      }
    }

    public void EnableNetControl()
    {
      this.panelLeft.Enabled = false;
      this.panelRight.Enabled = true;
    }

    public void DisableNetControl()
    {
      this.panelLeft.Enabled = true;
      this.panelRight.Enabled = false;
    }

    private void BaseHungControl_Load(object sender, EventArgs e)
    {
      this.baseNetControl.SetMark += new Net.SetMarkHandler(this.baseNetControl_SetMark);
      this.baseNetControl.SetFlowF += new Net.SetFlowHandler(this.baseNetControl_SetFlowF);
      this.baseNetControl.DelMark += new Net.DelMarkHandler(this.baseNetControl_DelMark);
      this.baseNetControl.SetResultNetwork += new Net.SetNetworkHandler(this.baseNetControl_SetResultNetwork);
    }

    private void baseNetControl_SetMark(Node n, bool empty, int z, bool plus, bool inf, int e)
    {
      if (this.SetMark == null)
        return;
      this.SetMark(n, empty, z, plus, inf, e);
    }

    private void baseNetControl_SetFlowF(Arc a, int h)
    {
      if (this.SetFlow == null)
        return;
      this.SetFlow(a, h);
    }

    private void baseNetControl_DelMark(Node n)
    {
      if (this.DelMark == null)
        return;
      this.DelMark(n);
    }

    private void baseNetControl_SetResultNetwork(Net n1)
    {
      if (this.SetResultNetwork == null)
        return;
      this.SetResultNetwork(n1);
    }

    public void UnsetEvents()
    {
      this.baseNetControl.SetMark -= new Net.SetMarkHandler(this.baseNetControl_SetMark);
      this.baseNetControl.SetFlowF -= new Net.SetFlowHandler(this.baseNetControl_SetFlowF);
      this.baseNetControl.DelMark -= new Net.DelMarkHandler(this.baseNetControl_DelMark);
      this.baseNetControl.SetResultNetwork -= new Net.SetNetworkHandler(this.baseNetControl_SetResultNetwork);
    }

    private void btnSetResult_Click(object sender, EventArgs e)
    {
      using (SetResultNetwork setResultNetwork1 = new SetResultNetwork())
      {
        this._resHungTable = new HungTable(this._startTable.DimV, this._startTable.DimH);
        HungTableControl hungTableControl = setResultNetwork1.hungTableControl1;
        int height = hungTableControl.Height;
        int width = hungTableControl.Width;
        hungTableControl.IsSetResult = true;
        hungTableControl.SetDimensions(this._resHungTable.DimV, this._resHungTable.DimH);
        hungTableControl.Subscribe(this._resHungTable);
        for (uint i = 0U; i < this._startTable.DimV; ++i)
          this._resHungTable.SetValAA(i, this._startTable.GetValAA(i));
        for (uint j = 0U; j < this._startTable.DimH; ++j)
          this._resHungTable.SetValBB(j, this._startTable.GetValBB(j));
        SetResultNetwork setResultNetwork2 = setResultNetwork1;
        int num1 = setResultNetwork2.Height + (hungTableControl.Height > height ? hungTableControl.Height - height : 0);
        setResultNetwork2.Height = num1;
        int num2 = 92 + (hungTableControl.Width > width ? hungTableControl.Width - width : 0);
        setResultNetwork1.Width = num2 > 212 ? num2 : 212;
        hungTableControl.IsSetResult = true;
        hungTableControl.ValueAAChanged += new HungTableControl.ValueAAChangedHandler(this.tc_ValueAAChanged);
        hungTableControl.ValueBBChanged += new HungTableControl.ValueBBChangedHandler(this.tc_ValueBBChanged);
        hungTableControl.ValueCDChanged += new HungTableControl.ValueCDChangedHandler(this.tc_ValueCDChanged);
        if (setResultNetwork1.ShowDialog() == DialogResult.OK && this.SetResultTable != null)
          this.SetResultTable(this._resHungTable, setResultNetwork1.Sum);
        hungTableControl.ValueAAChanged -= new HungTableControl.ValueAAChangedHandler(this.tc_ValueAAChanged);
        hungTableControl.ValueBBChanged -= new HungTableControl.ValueBBChangedHandler(this.tc_ValueBBChanged);
        hungTableControl.ValueCDChanged -= new HungTableControl.ValueCDChangedHandler(this.tc_ValueCDChanged);
      }
    }

    private void tc_ValueAAChanged(uint i, int val)
    {
      this._resHungTable.SetValAA(i, val);
    }

    private void tc_ValueBBChanged(uint j, int val)
    {
      this._resHungTable.SetValBB(j, val);
    }

    private void tc_ValueCDChanged(uint i, uint j, int val)
    {
      this._resHungTable.SetValCD(i, j, val);
    }

    private void tf_Closing(object sender, CancelEventArgs e)
    {
      using (SetNodePoint setNodePoint = new SetNodePoint())
      {
        foreach (Node node in (CollectionBase) this._tempNet.Nodes)
        {
          bool flag = false;
          foreach (string s in this._correspondTable)
          {
            ItemNodePoint @object = ItemNodePoint.GetObject(s);
            if (@object.Node.Number == node.Number)
            {
              flag = true;
              setNodePoint.lbCorresp.Items.Add((object) @object);
              break;
            }
          }
          if (!flag)
            setNodePoint.lbNodes.Items.Add((object) new ItemNode(node.Number));
        }
        foreach (string s in this._correspondTable)
        {
          ItemNodePoint @object = ItemNodePoint.GetObject(s);
          bool flag = false;
          foreach (Node node in (CollectionBase) this._tempNet.Nodes)
          {
            if (node.Number == @object.Node.Number)
            {
              flag = true;
              break;
            }
          }
          if (!flag)
            setNodePoint.lbPoint.Items.Add((object) @object.Point);
        }
        if (setNodePoint.ShowDialog() != DialogResult.OK)
          return;
        ArrayList corrList = new ArrayList();
        foreach (ItemNodePoint itemNodePoint in setNodePoint.lbCorresp.Items)
        {
          corrList.Add((object) itemNodePoint.GetString());
          if (itemNodePoint.Point.PointType == PointType.source)
            this._tempNet.StartNode = this._tempNet[itemNodePoint.Node.Number];
          else if (itemNodePoint.Point.PointType == PointType.target)
            this._tempNet.EndNode = this._tempNet[itemNodePoint.Node.Number];
        }
        this.GoToNet(this._tempNet, corrList);
        this._correspondTable = corrList;
      }
    }

    public delegate void ValueAAChangedHandler(uint i, int val);

    public delegate void ValueBBChangedHandler(uint j, int val);

    public delegate void ValueCDChangedHandler(uint i, uint j, int val);

    public delegate void SelectionCDChangedHandler(uint i, uint j, bool val);

    public delegate void GoToNetHandler(Net net, ArrayList corrList);

    public delegate void SetResultTableHandler(HungTable table, int sum);
  }
}
