// Type: Mephi.K22.LearningSuite.Shell.Protocol
// Assembly: Mephi.K22.LearningSuite.Shell, Version=0.1.3236.13214, Culture=neutral, PublicKeyToken=null
// MVID: 06872E41-5D58-4E8A-9BE5-49AA900D1161
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Shell.exe

using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Mephi.K22.LearningSuite.Core;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Shell
{
  public class Protocol : Form
  {
    private Panel panelBottom;
    private Button button1;
    private Panel panelTop;
    private ToolBar toolBar;
    private ImageList imageList;
    private ToolBarButton tbbView;
    private ToolBarButton tbbDelete;
    private GridColumn gcRetry;
    private Panel panel1;
    private Label label1;
    private Label label2;
    internal TextBox tbMethod;
    internal TextBox tbTask;
    private IContainer components;
    public GridControl gridControl1;
    private GridColumn gcMethodName;
    private GridColumn gcTaskName;
    private RepositoryItemMemoEdit repositoryItemMemoEdit;
    private GridColumn detgcRetryNum;
    private GridColumn detgcActionsCount;
    private CustomView detailView;
    private CustomView masterView;
    private RepositoryItemCheckEdit repositoryItemCheckEdit1;
    private GridColumn gridColumn1;
    private TaskCollection _taskCollection;

    public event Protocol.RetryEvent OnRetryDelete;

    public Protocol(TaskCollection tc)
    {
      this.InitializeComponent();
      this._taskCollection = tc;
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
      GridLevelNode gridLevelNode = new GridLevelNode();
      ResourceManager resourceManager = new ResourceManager(typeof (Protocol));
      this.detailView = new CustomView();
      this.detgcRetryNum = new GridColumn();
      this.detgcActionsCount = new GridColumn();
      this.gridColumn1 = new GridColumn();
      this.repositoryItemCheckEdit1 = new RepositoryItemCheckEdit();
      this.gridControl1 = new GridControl();
      this.masterView = new CustomView();
      this.gcMethodName = new GridColumn();
      this.gcTaskName = new GridColumn();
      this.repositoryItemMemoEdit = new RepositoryItemMemoEdit();
      this.gcRetry = new GridColumn();
      this.panelBottom = new Panel();
      this.button1 = new Button();
      this.panelTop = new Panel();
      this.toolBar = new ToolBar();
      this.tbbView = new ToolBarButton();
      this.tbbDelete = new ToolBarButton();
      this.imageList = new ImageList(this.components);
      this.panel1 = new Panel();
      this.label1 = new Label();
      this.tbMethod = new TextBox();
      this.tbTask = new TextBox();
      this.label2 = new Label();
      this.detailView.BeginInit();
      this.repositoryItemCheckEdit1.BeginInit();
      this.gridControl1.BeginInit();
      this.masterView.BeginInit();
      this.repositoryItemMemoEdit.BeginInit();
      this.panelBottom.SuspendLayout();
      this.panelTop.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.detailView.Appearance.OddRow.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.detailView.Appearance.OddRow.BackColor2 = Color.White;
      this.detailView.Appearance.OddRow.GradientMode = LinearGradientMode.Vertical;
      this.detailView.Appearance.OddRow.Options.UseBackColor = true;
      this.detailView.Columns.AddRange(new GridColumn[3]
      {
        this.detgcRetryNum,
        this.detgcActionsCount,
        this.gridColumn1
      });
      this.detailView.GridControl = this.gridControl1;
      this.detailView.GroupPanelText = "Для группировки по колонке перетащите сюда заголовок этой колонки";
      this.detailView.Name = "detailView";
      this.detailView.OptionsDetail.AllowZoomDetail = false;
      this.detailView.OptionsDetail.ShowDetailTabs = false;
      this.detailView.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.detailView.OptionsView.EnableAppearanceOddRow = true;
      this.detailView.OptionsView.RowAutoHeight = true;
      this.detailView.OptionsView.ShowDetailButtons = false;
      this.detailView.OptionsView.ShowGroupPanel = false;
      this.detailView.PaintStyleName = "Flat";
      this.detgcRetryNum.Caption = "Номер попытки";
      this.detgcRetryNum.FieldName = "RetryNum";
      this.detgcRetryNum.Name = "detgcRetryNum";
      this.detgcRetryNum.OptionsColumn.AllowEdit = false;
      this.detgcRetryNum.OptionsColumn.ReadOnly = true;
      this.detgcRetryNum.Visible = true;
      this.detgcRetryNum.VisibleIndex = 0;
      this.detgcActionsCount.Caption = "Действий";
      this.detgcActionsCount.FieldName = "ActionsCount";
      this.detgcActionsCount.Name = "detgcActionsCount";
      this.detgcActionsCount.OptionsColumn.AllowEdit = false;
      this.detgcActionsCount.OptionsColumn.ReadOnly = true;
      this.detgcActionsCount.Visible = true;
      this.detgcActionsCount.VisibleIndex = 1;
      this.gridColumn1.Caption = "Активна";
      this.gridColumn1.ColumnEdit = (RepositoryItem) this.repositoryItemCheckEdit1;
      this.gridColumn1.FieldName = "IsActive";
      this.gridColumn1.Name = "gridColumn1";
      this.gridColumn1.Visible = true;
      this.gridColumn1.VisibleIndex = 2;
      this.repositoryItemCheckEdit1.AutoHeight = false;
      this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
      this.repositoryItemCheckEdit1.CheckedChanged += new EventHandler(this.repositoryItemCheckEdit1_CheckedChanged);
      this.gridControl1.Dock = DockStyle.Fill;
      this.gridControl1.EmbeddedNavigator.Name = "";
      gridLevelNode.LevelTemplate = (BaseView) this.detailView;
      gridLevelNode.RelationName = "Retries";
      this.gridControl1.LevelTree.Nodes.AddRange(new GridLevelNode[1]
      {
        gridLevelNode
      });
      this.gridControl1.Location = new Point(0, 28);
      this.gridControl1.MainView = (BaseView) this.masterView;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.RepositoryItems.AddRange(new RepositoryItem[2]
      {
        (RepositoryItem) this.repositoryItemMemoEdit,
        (RepositoryItem) this.repositoryItemCheckEdit1
      });
      this.gridControl1.Size = new Size(642, 389);
      this.gridControl1.TabIndex = 8;
      this.gridControl1.ViewCollection.AddRange(new BaseView[2]
      {
        (BaseView) this.masterView,
        (BaseView) this.detailView
      });
      this.gridControl1.FocusedViewChanged += new ViewFocusEventHandler(this.gridControl1_FocusedViewChanged);
      this.masterView.Appearance.OddRow.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.masterView.Appearance.OddRow.BackColor2 = Color.White;
      this.masterView.Appearance.OddRow.GradientMode = LinearGradientMode.Vertical;
      this.masterView.Appearance.OddRow.Options.UseBackColor = true;
      this.masterView.Columns.AddRange(new GridColumn[2]
      {
        this.gcMethodName,
        this.gcTaskName
      });
      this.masterView.GridControl = this.gridControl1;
      this.masterView.GroupPanelText = "Для группировки по колонке перетащите сюда заголовок этой колонки";
      this.masterView.Name = "masterView";
      this.masterView.OptionsBehavior.AutoExpandAllGroups = true;
      this.masterView.OptionsDetail.AllowExpandEmptyDetails = true;
      this.masterView.OptionsDetail.AllowZoomDetail = false;
      this.masterView.OptionsDetail.ShowDetailTabs = false;
      this.masterView.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.masterView.OptionsView.EnableAppearanceOddRow = true;
      this.masterView.OptionsView.RowAutoHeight = true;
      this.masterView.OptionsView.ShowGroupPanel = false;
      this.masterView.PaintStyleName = "Flat";
      this.gcMethodName.Caption = "Метод";
      this.gcMethodName.FieldName = "MethodName";
      this.gcMethodName.Name = "gcMethodName";
      this.gcMethodName.OptionsColumn.AllowEdit = false;
      this.gcMethodName.OptionsColumn.ReadOnly = true;
      this.gcMethodName.Visible = true;
      this.gcMethodName.VisibleIndex = 0;
      this.gcMethodName.Width = 161;
      this.gcTaskName.Caption = "Задача";
      this.gcTaskName.ColumnEdit = (RepositoryItem) this.repositoryItemMemoEdit;
      this.gcTaskName.FieldName = "TaskName";
      this.gcTaskName.Name = "gcTaskName";
      this.gcTaskName.OptionsColumn.AllowEdit = false;
      this.gcTaskName.OptionsColumn.ReadOnly = true;
      this.gcTaskName.Visible = true;
      this.gcTaskName.VisibleIndex = 1;
      this.gcTaskName.Width = 283;
      this.repositoryItemMemoEdit.Name = "repositoryItemMemoEdit";
      this.gcRetry.AppearanceCell.Options.UseTextOptions = true;
      this.gcRetry.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
      this.gcRetry.Caption = "Попытка";
      this.gcRetry.FieldName = "RetryNum";
      this.gcRetry.ImageAlignment = StringAlignment.Center;
      this.gcRetry.Name = "gcRetry";
      this.gcRetry.OptionsColumn.AllowEdit = false;
      this.gcRetry.OptionsColumn.ReadOnly = true;
      this.gcRetry.Visible = true;
      this.gcRetry.VisibleIndex = 0;
      this.panelBottom.Controls.Add((Control) this.button1);
      this.panelBottom.Dock = DockStyle.Bottom;
      this.panelBottom.Location = new Point(0, 445);
      this.panelBottom.Name = "panelBottom";
      this.panelBottom.Size = new Size(642, 28);
      this.panelBottom.TabIndex = 5;
      this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.button1.Location = new Point(562, 4);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 20);
      this.button1.TabIndex = 0;
      this.button1.Text = "Закрыть";
      this.button1.Click += new EventHandler(this.button1_Click);
      this.panelTop.Controls.Add((Control) this.gridControl1);
      this.panelTop.Controls.Add((Control) this.toolBar);
      this.panelTop.Dock = DockStyle.Fill;
      this.panelTop.Location = new Point(0, 28);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new Size(642, 417);
      this.panelTop.TabIndex = 6;
      this.toolBar.Appearance = ToolBarAppearance.Flat;
      this.toolBar.Buttons.AddRange(new ToolBarButton[2]
      {
        this.tbbView,
        this.tbbDelete
      });
      this.toolBar.DropDownArrows = true;
      this.toolBar.ImageList = this.imageList;
      this.toolBar.Location = new Point(0, 0);
      this.toolBar.Name = "toolBar";
      this.toolBar.ShowToolTips = true;
      this.toolBar.Size = new Size(642, 28);
      this.toolBar.TabIndex = 7;
      this.toolBar.TextAlign = ToolBarTextAlign.Right;
      this.toolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
      this.tbbView.ImageIndex = 1;
      this.tbbView.Text = "Просмотр";
      this.tbbDelete.ImageIndex = 0;
      this.tbbDelete.Text = "Удалить";
      this.imageList.ImageSize = new Size(16, 16);
      this.imageList.ImageStream = (ImageListStreamer) resourceManager.GetObject("imageList.ImageStream");
      this.imageList.TransparentColor = Color.Transparent;
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.tbMethod);
      this.panel1.Controls.Add((Control) this.tbTask);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(642, 28);
      this.panel1.TabIndex = 7;
      this.panel1.Visible = false;
      this.label1.Location = new Point(4, 4);
      this.label1.Name = "label1";
      this.label1.Size = new Size(52, 20);
      this.label1.TabIndex = 4;
      this.label1.Text = "Метод";
      this.label1.TextAlign = ContentAlignment.MiddleLeft;
      this.tbMethod.Location = new Point(56, 4);
      this.tbMethod.Name = "tbMethod";
      this.tbMethod.ReadOnly = true;
      this.tbMethod.Size = new Size(216, 20);
      this.tbMethod.TabIndex = 5;
      this.tbMethod.Text = "";
      this.tbTask.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbTask.Location = new Point(332, 4);
      this.tbTask.Multiline = true;
      this.tbTask.Name = "tbTask";
      this.tbTask.ReadOnly = true;
      this.tbTask.Size = new Size(308, 20);
      this.tbTask.TabIndex = 7;
      this.tbTask.Text = "";
      this.label2.Location = new Point(280, 4);
      this.label2.Name = "label2";
      this.label2.Size = new Size(52, 20);
      this.label2.TabIndex = 6;
      this.label2.Text = "Задача";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(642, 473);
      this.Controls.Add((Control) this.panelTop);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panelBottom);
      this.Icon = (Icon) resourceManager.GetObject("$this.Icon");
      this.Name = "Protocol";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Протокол работы";
      this.Load += new EventHandler(this.Protocol_Load);
      this.detailView.EndInit();
      this.repositoryItemCheckEdit1.EndInit();
      this.gridControl1.EndInit();
      this.masterView.EndInit();
      this.repositoryItemMemoEdit.EndInit();
      this.panelBottom.ResumeLayout(false);
      this.panelTop.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void ViewRetries_DoubleClick(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show((sender as ColumnView).FocusedRowHandle.ToString());
    }

    private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
    {
      Task currentTask = this.GetCurrentTask();
      if (currentTask == null)
        return;
      Retry currentRetry = this.GetCurrentRetry();
      if (e.Button == this.tbbView)
      {
        if (currentTask != null && currentRetry != null)
        {
          MethodControlLoader.Exec(currentTask, RunMode.play, currentRetry.RetryNum);
        }
        else
        {
          int num1 = (int) MessageBox.Show("Выделите строку с попыткой решения!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }
      }
      else
      {
        if (e.Button != this.tbbDelete)
          return;
        if (currentTask != null && currentRetry != null)
        {
          if (this.OnRetryDelete == null || MessageBox.Show(string.Format("Вы уверены что хотите удалить попытку {0} задачи \"{1}\"?", (object) currentRetry.RetryNum, (object) currentTask.TaskName), "Удаление попытки", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            return;
          this.OnRetryDelete(currentTask, currentRetry);
        }
        else
        {
          int num2 = (int) MessageBox.Show("Выделите строку с попыткой решения!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }
      }
    }

    private Task GetCurrentTask()
    {
      int[] selectedRows = this.masterView.GetSelectedRows();
      Task task = (Task) null;
      if (selectedRows.Length > 0)
        task = (Task) this.masterView.GetRow(selectedRows[0]);
      return task;
    }

    private Retry GetCurrentRetry()
    {
      Retry retry = (Retry) null;
      int[] selectedRows1 = this.masterView.GetSelectedRows();
      if (selectedRows1.Length > 0)
      {
        Task task = (Task) this.masterView.GetRow(selectedRows1[0]);
        this.masterView.GetRelationCount(selectedRows1[0]);
        if (!this.masterView.GetMasterRowExpandedEx(selectedRows1[0], 0))
          this.masterView.SetMasterRowExpandedEx(selectedRows1[0], 0, true);
        GridView gridView = this.masterView.GetDetailView(selectedRows1[0], 0) as GridView;
        if (gridView != null)
        {
          int[] selectedRows2 = gridView.GetSelectedRows();
          if (selectedRows2.Length > 0)
            retry = (Retry) gridView.GetRow(selectedRows2[0]);
        }
      }
      return retry;
    }

    private void Protocol_Load(object sender, EventArgs e)
    {
      for (int rowHandle = 0; rowHandle < this.masterView.RowCount; ++rowHandle)
        this.masterView.ExpandMasterRow(rowHandle);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void gridControl1_FocusedViewChanged(object sender, ViewFocusEventArgs e)
    {
      if (e.View == null || e.View.ParentView == null)
        return;
      ((ColumnView) e.View.ParentView).FocusedRowHandle = e.View.SourceRowHandle;
    }

    private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
    {
      Retry currentRetry = this.GetCurrentRetry();
      Task currentTask = this.GetCurrentTask();
      currentRetry.IsActive = !currentRetry.IsActive;
      foreach (Retry retry in (CollectionBase) currentTask.Retries)
      {
        if (currentRetry.IsActive && retry != currentRetry)
          retry.IsActive = false;
      }
    }

    public delegate void RetryEvent(Task t, Retry r);
  }
}
