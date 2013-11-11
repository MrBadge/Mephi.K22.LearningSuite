// Type: Mephi.K22.LearningSuite.Shell.TaskSelector
// Assembly: Mephi.K22.LearningSuite.Shell, Version=0.1.3236.13214, Culture=neutral, PublicKeyToken=null
// MVID: 06872E41-5D58-4E8A-9BE5-49AA900D1161
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Shell.exe

using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Mephi.K22.LearningSuite.Core;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Shell
{
  public class TaskSelector : Form
  {
    private Label label1;
    private TextBox tbWorkName;
    private TextBox tbVariantName;
    private Label label2;
    private Panel panel1;
    private Panel panel2;
    private Button button1;
    private Panel panel3;
    private GridControl Grid;
    private CustomView View;
    private ToolBar toolBar;
    private ImageList imageList;
    private ToolBarButton tbbRunTask;
    private ToolBarButton tbbSaveProtocol;
    private ToolBarButton tbbViewProtocol;
    private IContainer components;
    private GridColumn gcTaskName;
    private GridColumn gcMethodName;
    private GridColumn gcRetryCount;
    private RepositoryItemMemoEdit repositoryItemMemoEdit;
    private RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    private GridView gridView1;
    private GridColumn gcCompletedRetryCount;
    private Work _work;
    public TaskSelector.DelegateTask TaskSelected;
    public TaskSelector.DelegateTaskCollection OnViewProtocol;
    public TaskSelector.OnSaveProtocolDelegate OnSaveProtocol;

    public Work WorkInfo
    {
      get
      {
        return this._work;
      }
      set
      {
        this._work = value;
        this.tbWorkName.Text = this._work.Name;
        this.tbVariantName.Text = this._work.Variants[0].Name;
        this.Grid.DataSource = (object) this._work.Variants[0].Tasks;
      }
    }

    public TaskSelector()
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
      ResourceManager resourceManager = new ResourceManager(typeof (TaskSelector));
      this.gridView1 = new GridView();
      this.Grid = new GridControl();
      this.View = new CustomView();
      this.gcMethodName = new GridColumn();
      this.gcTaskName = new GridColumn();
      this.repositoryItemMemoEdit = new RepositoryItemMemoEdit();
      this.gcRetryCount = new GridColumn();
      this.gcCompletedRetryCount = new GridColumn();
      this.repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
      this.label1 = new Label();
      this.tbWorkName = new TextBox();
      this.tbVariantName = new TextBox();
      this.label2 = new Label();
      this.panel1 = new Panel();
      this.button1 = new Button();
      this.panel2 = new Panel();
      this.toolBar = new ToolBar();
      this.tbbRunTask = new ToolBarButton();
      this.tbbSaveProtocol = new ToolBarButton();
      this.tbbViewProtocol = new ToolBarButton();
      this.imageList = new ImageList(this.components);
      this.panel3 = new Panel();
      this.gridView1.BeginInit();
      this.Grid.BeginInit();
      this.View.BeginInit();
      this.repositoryItemMemoEdit.BeginInit();
      this.repositoryItemLookUpEdit1.BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      this.gridView1.GridControl = this.Grid;
      this.gridView1.Name = "gridView1";
      this.Grid.Dock = DockStyle.Fill;
      this.Grid.EmbeddedNavigator.Name = "";
      this.Grid.Location = new Point(0, 28);
      this.Grid.MainView = (BaseView) this.View;
      this.Grid.Name = "Grid";
      this.Grid.RepositoryItems.AddRange(new RepositoryItem[2]
      {
        (RepositoryItem) this.repositoryItemMemoEdit,
        (RepositoryItem) this.repositoryItemLookUpEdit1
      });
      this.Grid.Size = new Size(642, 389);
      this.Grid.TabIndex = 1;
      this.Grid.ViewCollection.AddRange(new BaseView[2]
      {
        (BaseView) this.View,
        (BaseView) this.gridView1
      });
      this.Grid.DoubleClick += new EventHandler(this.Grid_DoubleClick);
      this.View.Appearance.OddRow.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.View.Appearance.OddRow.BackColor2 = Color.White;
      this.View.Appearance.OddRow.GradientMode = LinearGradientMode.Vertical;
      this.View.Appearance.OddRow.Options.UseBackColor = true;
      this.View.Columns.AddRange(new GridColumn[4]
      {
        this.gcMethodName,
        this.gcTaskName,
        this.gcRetryCount,
        this.gcCompletedRetryCount
      });
      this.View.GridControl = this.Grid;
      this.View.GroupPanelText = "Для группировки по колонке перетащите сюда заголовок этой колонки";
      this.View.Name = "View";
      this.View.OptionsDetail.AllowZoomDetail = false;
      this.View.OptionsDetail.ShowDetailTabs = false;
      this.View.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.View.OptionsView.EnableAppearanceOddRow = true;
      this.View.OptionsView.RowAutoHeight = true;
      this.View.OptionsView.ShowDetailButtons = false;
      this.View.OptionsView.ShowGroupPanel = false;
      this.View.PaintStyleName = "Flat";
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
      this.gcRetryCount.Caption = "Попыток всего";
      this.gcRetryCount.FieldName = "RetryCount";
      this.gcRetryCount.Name = "gcRetryCount";
      this.gcRetryCount.OptionsColumn.AllowEdit = false;
      this.gcRetryCount.OptionsColumn.ReadOnly = true;
      this.gcRetryCount.Visible = true;
      this.gcRetryCount.VisibleIndex = 2;
      this.gcRetryCount.Width = 115;
      this.gcCompletedRetryCount.Caption = "Попыток выполнено";
      this.gcCompletedRetryCount.FieldName = "CompletedRetryCount";
      this.gcCompletedRetryCount.Name = "gcCompletedRetryCount";
      this.gcCompletedRetryCount.OptionsColumn.AllowEdit = false;
      this.gcCompletedRetryCount.OptionsColumn.ReadOnly = true;
      this.gcCompletedRetryCount.Visible = true;
      this.gcCompletedRetryCount.VisibleIndex = 3;
      this.gcCompletedRetryCount.Width = 79;
      this.repositoryItemLookUpEdit1.AutoHeight = false;
      this.repositoryItemLookUpEdit1.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
      this.label1.Location = new Point(4, 4);
      this.label1.Name = "label1";
      this.label1.Size = new Size(52, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Работа";
      this.label1.TextAlign = ContentAlignment.MiddleLeft;
      this.tbWorkName.Location = new Point(56, 4);
      this.tbWorkName.Name = "tbWorkName";
      this.tbWorkName.ReadOnly = true;
      this.tbWorkName.Size = new Size(216, 20);
      this.tbWorkName.TabIndex = 1;
      this.tbWorkName.Text = "";
      this.tbVariantName.Location = new Point(332, 4);
      this.tbVariantName.Name = "tbVariantName";
      this.tbVariantName.ReadOnly = true;
      this.tbVariantName.Size = new Size(216, 20);
      this.tbVariantName.TabIndex = 3;
      this.tbVariantName.Text = "";
      this.label2.Location = new Point(280, 4);
      this.label2.Name = "label2";
      this.label2.Size = new Size(52, 20);
      this.label2.TabIndex = 2;
      this.label2.Text = "Вариант";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.panel1.Controls.Add((Control) this.button1);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 445);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(642, 28);
      this.panel1.TabIndex = 4;
      this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.button1.Location = new Point(562, 4);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 20);
      this.button1.TabIndex = 0;
      this.button1.Text = "Закрыть";
      this.button1.Click += new EventHandler(this.button1_Click);
      this.panel2.Controls.Add((Control) this.Grid);
      this.panel2.Controls.Add((Control) this.toolBar);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(0, 28);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(642, 417);
      this.panel2.TabIndex = 5;
      this.toolBar.Appearance = ToolBarAppearance.Flat;
      this.toolBar.Buttons.AddRange(new ToolBarButton[3]
      {
        this.tbbRunTask,
        this.tbbSaveProtocol,
        this.tbbViewProtocol
      });
      this.toolBar.DropDownArrows = true;
      this.toolBar.ImageList = this.imageList;
      this.toolBar.Location = new Point(0, 0);
      this.toolBar.Name = "toolBar";
      this.toolBar.ShowToolTips = true;
      this.toolBar.Size = new Size(642, 28);
      this.toolBar.TabIndex = 0;
      this.toolBar.TextAlign = ToolBarTextAlign.Right;
      this.toolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
      this.tbbRunTask.ImageIndex = 0;
      this.tbbRunTask.Text = "Решать задачу";
      this.tbbSaveProtocol.ImageIndex = 1;
      this.tbbSaveProtocol.Text = "Сохранить протокол";
      this.tbbViewProtocol.ImageIndex = 2;
      this.tbbViewProtocol.Text = "Просмотр протокола";
      this.imageList.ImageSize = new Size(16, 16);
      this.imageList.ImageStream = (ImageListStreamer) resourceManager.GetObject("imageList.ImageStream");
      this.imageList.TransparentColor = Color.Transparent;
      this.panel3.Controls.Add((Control) this.label1);
      this.panel3.Controls.Add((Control) this.tbWorkName);
      this.panel3.Controls.Add((Control) this.tbVariantName);
      this.panel3.Controls.Add((Control) this.label2);
      this.panel3.Dock = DockStyle.Top;
      this.panel3.Location = new Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(642, 28);
      this.panel3.TabIndex = 4;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(642, 473);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel3);
      this.Icon = (Icon) resourceManager.GetObject("$this.Icon");
      this.Name = "TaskSelector";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Задание на работу";
      this.Closing += new CancelEventHandler(this.TaskSelector_Closing);
      this.gridView1.EndInit();
      this.Grid.EndInit();
      this.View.EndInit();
      this.repositoryItemMemoEdit.EndInit();
      this.repositoryItemLookUpEdit1.EndInit();
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
    {
      if (e.Button == this.tbbRunTask)
        this.StartTask();
      else if (e.Button == this.tbbViewProtocol)
      {
        this.ViewProtocol();
      }
      else
      {
        if (e.Button != this.tbbSaveProtocol)
          return;
        this.SaveProtocol();
      }
    }

    private void StartTask()
    {
      if (this.TaskSelected == null)
        return;
      int[] selectedRows = this.View.GetSelectedRows();
      if (selectedRows.Length <= 0)
        return;
      this.TaskSelected((Task) this.View.GetRow(selectedRows[0]));
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void ViewProtocol()
    {
      if (this.OnViewProtocol == null || this.View.GetSelectedRows().Length <= 0)
        return;
      this.OnViewProtocol(this._work.Variants[0].Tasks);
    }

    private void SaveProtocol()
    {
      int num = (int) MessageBox.Show("Сохраняются только активные попытки выполнения заданий!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
      if (this.OnSaveProtocol == null)
        return;
      this.OnSaveProtocol(this.WorkInfo);
    }

    private void Grid_DoubleClick(object sender, EventArgs e)
    {
      int[] selectedRows = this.View.GetSelectedRows();
      if (selectedRows.Length <= 0)
        return;
      this.TaskSelected((Task) this.View.GetRow(selectedRows[0]));
    }

    private void TaskSelector_Closing(object sender, CancelEventArgs e)
    {
      if (MessageBox.Show("Перед выходом из работы необходимо выбрать попытки выполнения заданий и сохранить протокол!\r\nЗакрыть это окно?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        return;
      e.Cancel = true;
    }

    public delegate void DelegateTask(Task t);

    public delegate void DelegateTaskCollection(TaskCollection tc);

    public delegate void OnSaveProtocolDelegate(Work work);
  }
}
