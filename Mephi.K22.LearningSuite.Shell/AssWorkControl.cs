// Type: Mephi.K22.LearningSuite.Shell.AssWorkControl
// Assembly: Mephi.K22.LearningSuite.Shell, Version=0.1.3236.13214, Culture=neutral, PublicKeyToken=null
// MVID: 06872E41-5D58-4E8A-9BE5-49AA900D1161
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Shell.exe

using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using Mephi.K22.LearningSuite.Core;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Shell
{
  public class AssWorkControl : BaseGridControl
  {
    private IContainer components = (IContainer) null;
    private CustomView ViewTask;
    private GridColumn gcTaskName;
    private GridColumn gcMethodName;
    private GridColumn gcMaxRetries;
    private GridColumn gcWorkName;
    private GridColumn gcVariantName;
    private GridColumn gcAssigmentDate;
    private GridColumn gcAssigmentTime;
    private GridColumn gcIsExecute;
    private RepositoryItemCheckEdit repositoryItemCheckEdit1;
    private GridColumn gcRemainRetries;
    private RepositoryItemMemoEdit repositoryItemMemoEdit;

    internal Guid SelectedAss
    {
      get
      {
        return this.SelectedRow != null ? (Guid) this.SelectedRow["AssigmentId"] : Guid.Empty;
      }
    }

    public AssWorkControl()
    {
      this.InitializeComponent();
      this.toolBar.Visible = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (AssWorkControl));
      GridLevelNode gridLevelNode = new GridLevelNode();
      this.ViewTask = new CustomView();
      this.gcTaskName = new GridColumn();
      this.repositoryItemMemoEdit = new RepositoryItemMemoEdit();
      this.gcMethodName = new GridColumn();
      this.gcMaxRetries = new GridColumn();
      this.gcRemainRetries = new GridColumn();
      this.gcWorkName = new GridColumn();
      this.gcVariantName = new GridColumn();
      this.gcAssigmentDate = new GridColumn();
      this.gcAssigmentTime = new GridColumn();
      this.gcIsExecute = new GridColumn();
      this.repositoryItemCheckEdit1 = new RepositoryItemCheckEdit();
      this.Grid.BeginInit();
      this.View.BeginInit();
      this.ViewTask.BeginInit();
      this.repositoryItemMemoEdit.BeginInit();
      this.repositoryItemCheckEdit1.BeginInit();
      this.SuspendLayout();
      this.toolBar.Name = "toolBar";
      this.toolBar.Size = new Size(684, 26);
      this.imageList.ImageStream = (ImageListStreamer) resourceManager.GetObject("imageList.ImageStream");
      this.Grid.EmbeddedNavigator.Name = "";
      gridLevelNode.LevelTemplate = (BaseView) this.ViewTask;
      gridLevelNode.RelationName = "Задачи";
      this.Grid.LevelTree.Nodes.AddRange(new GridLevelNode[1]
      {
        gridLevelNode
      });
      this.Grid.Location = new Point(0, 26);
      this.Grid.Name = "Grid";
      this.Grid.RepositoryItems.AddRange(new RepositoryItem[2]
      {
        (RepositoryItem) this.repositoryItemCheckEdit1,
        (RepositoryItem) this.repositoryItemMemoEdit
      });
      this.Grid.Size = new Size(684, 306);
      this.Grid.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.ViewTask
      });
      this.View.Appearance.OddRow.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.View.Appearance.OddRow.BackColor2 = Color.White;
      this.View.Appearance.OddRow.GradientMode = LinearGradientMode.Vertical;
      this.View.Appearance.OddRow.Options.UseBackColor = true;
      this.View.Columns.AddRange(new GridColumn[5]
      {
        this.gcWorkName,
        this.gcVariantName,
        this.gcAssigmentDate,
        this.gcAssigmentTime,
        this.gcIsExecute
      });
      this.View.OptionsDetail.AllowExpandEmptyDetails = true;
      this.View.OptionsDetail.AllowZoomDetail = false;
      this.View.OptionsDetail.ShowDetailTabs = false;
      this.View.OptionsDetail.SmartDetailHeight = true;
      this.View.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.View.OptionsSelection.MultiSelect = true;
      this.View.OptionsView.EnableAppearanceOddRow = true;
      this.View.OptionsView.ShowGroupPanel = false;
      this.ViewTask.Appearance.OddRow.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.ViewTask.Appearance.OddRow.BackColor2 = Color.White;
      this.ViewTask.Appearance.OddRow.GradientMode = LinearGradientMode.Vertical;
      this.ViewTask.Appearance.OddRow.Options.UseBackColor = true;
      this.ViewTask.Columns.AddRange(new GridColumn[4]
      {
        this.gcTaskName,
        this.gcMethodName,
        this.gcMaxRetries,
        this.gcRemainRetries
      });
      this.ViewTask.GridControl = this.Grid;
      this.ViewTask.Name = "ViewTask";
      this.ViewTask.OptionsDetail.AllowExpandEmptyDetails = true;
      this.ViewTask.OptionsDetail.AllowZoomDetail = false;
      this.ViewTask.OptionsDetail.ShowDetailTabs = false;
      this.ViewTask.OptionsDetail.SmartDetailHeight = true;
      this.ViewTask.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.ViewTask.OptionsSelection.MultiSelect = true;
      this.ViewTask.OptionsView.EnableAppearanceOddRow = true;
      this.ViewTask.OptionsView.RowAutoHeight = true;
      this.ViewTask.OptionsView.ShowGroupPanel = false;
      this.ViewTask.PaintStyleName = "Flat";
      this.gcTaskName.Caption = "Задача";
      this.gcTaskName.ColumnEdit = (RepositoryItem) this.repositoryItemMemoEdit;
      this.gcTaskName.FieldName = "TaskName";
      this.gcTaskName.Name = "gcTaskName";
      this.gcTaskName.OptionsColumn.AllowEdit = false;
      this.gcTaskName.OptionsColumn.ReadOnly = true;
      this.gcTaskName.Visible = true;
      this.gcTaskName.VisibleIndex = 0;
      this.gcTaskName.Width = 347;
      this.repositoryItemMemoEdit.Name = "repositoryItemMemoEdit";
      this.gcMethodName.Caption = "Метод";
      this.gcMethodName.FieldName = "MethodName";
      this.gcMethodName.Name = "gcMethodName";
      this.gcMethodName.OptionsColumn.AllowEdit = false;
      this.gcMethodName.OptionsColumn.ReadOnly = true;
      this.gcMethodName.Visible = true;
      this.gcMethodName.VisibleIndex = 1;
      this.gcMethodName.Width = 197;
      this.gcMaxRetries.Caption = "Количество попыток";
      this.gcMaxRetries.FieldName = "MaxRetries";
      this.gcMaxRetries.Name = "gcMaxRetries";
      this.gcMaxRetries.OptionsColumn.AllowEdit = false;
      this.gcMaxRetries.OptionsColumn.ReadOnly = true;
      this.gcMaxRetries.Visible = true;
      this.gcMaxRetries.VisibleIndex = 2;
      this.gcMaxRetries.Width = 123;
      this.gcRemainRetries.Caption = "Попыток осталось";
      this.gcRemainRetries.FieldName = "RemainRetries";
      this.gcRemainRetries.Name = "gcRemainRetries";
      this.gcRemainRetries.OptionsColumn.AllowEdit = false;
      this.gcRemainRetries.OptionsColumn.ReadOnly = true;
      this.gcWorkName.Caption = "Работа";
      this.gcWorkName.FieldName = "WorkName";
      this.gcWorkName.Name = "gcWorkName";
      this.gcWorkName.OptionsColumn.AllowEdit = false;
      this.gcWorkName.OptionsColumn.ReadOnly = true;
      this.gcWorkName.Visible = true;
      this.gcWorkName.VisibleIndex = 0;
      this.gcWorkName.Width = 166;
      this.gcVariantName.Caption = "Вариант";
      this.gcVariantName.FieldName = "VariantName";
      this.gcVariantName.Name = "gcVariantName";
      this.gcVariantName.OptionsColumn.AllowEdit = false;
      this.gcVariantName.OptionsColumn.ReadOnly = true;
      this.gcVariantName.Visible = true;
      this.gcVariantName.VisibleIndex = 1;
      this.gcVariantName.Width = 212;
      this.gcAssigmentDate.Caption = "Дата назначения";
      this.gcAssigmentDate.DisplayFormat.FormatString = "d";
      this.gcAssigmentDate.DisplayFormat.FormatType = FormatType.DateTime;
      this.gcAssigmentDate.FieldName = "AssigmentDateTime";
      this.gcAssigmentDate.GroupFormat.FormatString = "d";
      this.gcAssigmentDate.GroupFormat.FormatType = FormatType.DateTime;
      this.gcAssigmentDate.Name = "gcAssigmentDate";
      this.gcAssigmentDate.OptionsColumn.AllowEdit = false;
      this.gcAssigmentDate.OptionsColumn.ReadOnly = true;
      this.gcAssigmentDate.Visible = true;
      this.gcAssigmentDate.VisibleIndex = 2;
      this.gcAssigmentDate.Width = 99;
      this.gcAssigmentTime.Caption = "Время назначения";
      this.gcAssigmentTime.DisplayFormat.FormatString = "t";
      this.gcAssigmentTime.DisplayFormat.FormatType = FormatType.DateTime;
      this.gcAssigmentTime.FieldName = "AssigmentDateTime";
      this.gcAssigmentTime.GroupFormat.FormatString = "t";
      this.gcAssigmentTime.GroupFormat.FormatType = FormatType.DateTime;
      this.gcAssigmentTime.Name = "gcAssigmentTime";
      this.gcAssigmentTime.OptionsColumn.AllowEdit = false;
      this.gcAssigmentTime.OptionsColumn.ReadOnly = true;
      this.gcAssigmentTime.Visible = true;
      this.gcAssigmentTime.VisibleIndex = 3;
      this.gcAssigmentTime.Width = 108;
      this.gcIsExecute.Caption = "Выполнялась";
      this.gcIsExecute.ColumnEdit = (RepositoryItem) this.repositoryItemCheckEdit1;
      this.gcIsExecute.FieldName = "IsExecute";
      this.gcIsExecute.Name = "gcIsExecute";
      this.gcIsExecute.OptionsColumn.AllowEdit = false;
      this.gcIsExecute.OptionsColumn.ReadOnly = true;
      this.gcIsExecute.Visible = true;
      this.gcIsExecute.VisibleIndex = 4;
      this.gcIsExecute.Width = 82;
      this.repositoryItemCheckEdit1.AutoHeight = false;
      this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
      this.repositoryItemCheckEdit1.ValueChecked = (object) 1;
      this.repositoryItemCheckEdit1.ValueUnchecked = (object) 0;
      this.Name = "AssWorkControl";
      this.Size = new Size(684, 332);
      this.Grid.EndInit();
      this.View.EndInit();
      this.ViewTask.EndInit();
      this.repositoryItemMemoEdit.EndInit();
      this.repositoryItemCheckEdit1.EndInit();
      this.ResumeLayout(false);
    }

    private DataSet GetDataSource()
    {
      return Mephi.K22.LearningSuite.InterOp.Shell.AssWork.GetData(ApplicationMain.userId, ApplicationMain.userId);
    }

    protected override void Initialize()
    {
      base.Initialize();
      this.Grid.DataSource = (object) this.GetDataSource();
      this.Grid.DataMember = "Master";
      for (int rowHandle = 0; rowHandle < this.View.RowCount; ++rowHandle)
        this.View.ExpandMasterRow(rowHandle);
    }
  }
}
