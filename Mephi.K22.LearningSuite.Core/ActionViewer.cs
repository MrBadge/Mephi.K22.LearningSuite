// Type: Mephi.K22.LearningSuite.Core.ActionViewer
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Core
{
  public class ActionViewer : UserControl
  {
    private GridControl gridControlActions;
    private CustomView gridViewActions;
    private Panel panelButtons;
    private GridColumn gcMessage;
    private GridColumn gcTime;
    private GridColumn gcParams;
    private GridColumn gcActionType;
    private RepositoryItemMemoEdit messageMemo;
    private Button btnUndoAll;
    private Button btnUndo;
    private Button btnRedo;
    private Button btnRedoAll;
    private CheckBox chkColumnHeaders;
    private ImageList ilAction;
    private GridColumn gcAccuracy;
    private RepositoryItemImageComboBox imageCBAccuracy;
    private GridColumn gcComment;
    private RepositoryItemMemoEdit commentMemo;
    private Label labelName;
    private IContainer components;
    public ActionViewer.ActionEventHandler OnUndoAll;
    public ActionViewer.ActionEventHandler OnUndo;
    public ActionViewer.ActionEventHandler OnRedo;
    public ActionViewer.ActionEventHandler OnRedoAll;

    public bool EnabledControls
    {
      set
      {
        this.btnRedo.Enabled = value;
        this.btnRedoAll.Enabled = value;
        this.btnUndo.Enabled = value;
        this.btnUndoAll.Enabled = value;
      }
    }

    public ActionViewer()
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
      ResourceManager resourceManager = new ResourceManager(typeof (ActionViewer));
      this.gridControlActions = new GridControl();
      this.gridViewActions = new CustomView();
      this.gcTime = new GridColumn();
      this.gcAccuracy = new GridColumn();
      this.imageCBAccuracy = new RepositoryItemImageComboBox();
      this.ilAction = new ImageList(this.components);
      this.gcMessage = new GridColumn();
      this.messageMemo = new RepositoryItemMemoEdit();
      this.gcComment = new GridColumn();
      this.commentMemo = new RepositoryItemMemoEdit();
      this.gcParams = new GridColumn();
      this.gcActionType = new GridColumn();
      this.panelButtons = new Panel();
      this.chkColumnHeaders = new CheckBox();
      this.btnRedoAll = new Button();
      this.btnRedo = new Button();
      this.btnUndo = new Button();
      this.labelName = new Label();
      this.btnUndoAll = new Button();
      this.gridControlActions.BeginInit();
      this.gridViewActions.BeginInit();
      this.imageCBAccuracy.BeginInit();
      this.messageMemo.BeginInit();
      this.commentMemo.BeginInit();
      this.panelButtons.SuspendLayout();
      this.SuspendLayout();
      this.gridControlActions.Dock = DockStyle.Fill;
      this.gridControlActions.EmbeddedNavigator.Name = "";
      this.gridControlActions.Location = new Point(68, 0);
      this.gridControlActions.MainView = (BaseView) this.gridViewActions;
      this.gridControlActions.Name = "gridControlActions";
      this.gridControlActions.RepositoryItems.AddRange(new RepositoryItem[3]
      {
        (RepositoryItem) this.messageMemo,
        (RepositoryItem) this.imageCBAccuracy,
        (RepositoryItem) this.commentMemo
      });
      this.gridControlActions.Size = new Size(512, 364);
      this.gridControlActions.TabIndex = 1;
      this.gridControlActions.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridViewActions
      });
      this.gridViewActions.Appearance.OddRow.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.gridViewActions.Appearance.OddRow.BackColor2 = Color.White;
      this.gridViewActions.Appearance.OddRow.GradientMode = LinearGradientMode.Vertical;
      this.gridViewActions.Appearance.OddRow.Options.UseBackColor = true;
      this.gridViewActions.Columns.AddRange(new GridColumn[6]
      {
        this.gcTime,
        this.gcAccuracy,
        this.gcMessage,
        this.gcComment,
        this.gcParams,
        this.gcActionType
      });
      this.gridViewActions.GridControl = this.gridControlActions;
      this.gridViewActions.GroupPanelText = "Для группировки по колонке перетащите сюда заголовок этой колонки";
      this.gridViewActions.Name = "gridViewActions";
      this.gridViewActions.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridViewActions.OptionsSelection.MultiSelect = true;
      this.gridViewActions.OptionsView.EnableAppearanceOddRow = true;
      this.gridViewActions.OptionsView.RowAutoHeight = true;
      this.gridViewActions.OptionsView.ShowDetailButtons = false;
      this.gridViewActions.OptionsView.ShowGroupPanel = false;
      this.gridViewActions.OptionsView.ShowIndicator = false;
      this.gridViewActions.PaintStyleName = "Flat";
      this.gridViewActions.SortInfo.AddRange(new GridColumnSortInfo[1]
      {
        new GridColumnSortInfo(this.gcTime, ColumnSortOrder.Ascending)
      });
      this.gcTime.Caption = "Время";
      this.gcTime.DisplayFormat.FormatString = "HH:mm:ss";
      this.gcTime.DisplayFormat.FormatType = FormatType.DateTime;
      this.gcTime.FieldName = "ActionDateTime";
      this.gcTime.Name = "gcTime";
      this.gcTime.OptionsColumn.AllowEdit = false;
      this.gcTime.OptionsColumn.ReadOnly = true;
      this.gcTime.OptionsColumn.ShowInCustomizationForm = false;
      this.gcTime.OptionsFilter.AllowAutoFilter = false;
      this.gcTime.OptionsFilter.AllowFilter = false;
      this.gcTime.Visible = true;
      this.gcTime.VisibleIndex = 0;
      this.gcTime.Width = 50;
      this.gcAccuracy.ColumnEdit = (RepositoryItem) this.imageCBAccuracy;
      this.gcAccuracy.FieldName = "ResultAccuracy";
      this.gcAccuracy.Name = "gcAccuracy";
      this.gcAccuracy.OptionsColumn.AllowEdit = false;
      this.gcAccuracy.OptionsColumn.AllowSize = false;
      this.gcAccuracy.OptionsColumn.ReadOnly = true;
      this.gcAccuracy.OptionsFilter.AllowAutoFilter = false;
      this.gcAccuracy.OptionsFilter.AllowFilter = false;
      this.gcAccuracy.Visible = true;
      this.gcAccuracy.VisibleIndex = 1;
      this.gcAccuracy.Width = 28;
      this.imageCBAccuracy.AutoHeight = false;
      this.imageCBAccuracy.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.imageCBAccuracy.GlyphAlignment = HorzAlignment.Center;
      ((ComboBoxItemCollection) this.imageCBAccuracy.Items).AddRange(new object[5]
      {
        (object) new ImageComboBoxItem("", (object) "mayYes", 1),
        (object) new ImageComboBoxItem("", (object) "mayNot", 3),
        (object) new ImageComboBoxItem("", (object) "notSpecified", 2),
        (object) new ImageComboBoxItem("верно", (object) "yes", 0),
        (object) new ImageComboBoxItem("не верно", (object) "no", 4)
      });
      this.imageCBAccuracy.Name = "imageCBAccuracy";
      this.imageCBAccuracy.SmallImages = (object) this.ilAction;
      this.ilAction.ImageSize = new Size(16, 16);
      this.ilAction.ImageStream = (ImageListStreamer) resourceManager.GetObject("ilAction.ImageStream");
      this.ilAction.TransparentColor = Color.Transparent;
      this.gcMessage.Caption = "Действие";
      this.gcMessage.ColumnEdit = (RepositoryItem) this.messageMemo;
      this.gcMessage.FieldName = "Message";
      this.gcMessage.Name = "gcMessage";
      this.gcMessage.OptionsColumn.AllowEdit = false;
      this.gcMessage.OptionsColumn.ReadOnly = true;
      this.gcMessage.OptionsColumn.ShowInCustomizationForm = false;
      this.gcMessage.OptionsFilter.AllowAutoFilter = false;
      this.gcMessage.OptionsFilter.AllowFilter = false;
      this.gcMessage.Visible = true;
      this.gcMessage.VisibleIndex = 2;
      this.gcMessage.Width = 290;
      this.messageMemo.Appearance.Options.UseTextOptions = true;
      this.messageMemo.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
      this.messageMemo.Name = "messageMemo";
      this.gcComment.Caption = "Комментарий";
      this.gcComment.ColumnEdit = (RepositoryItem) this.commentMemo;
      this.gcComment.FieldName = "Comment";
      this.gcComment.Name = "gcComment";
      this.gcComment.OptionsColumn.AllowEdit = false;
      this.gcComment.OptionsColumn.ReadOnly = true;
      this.gcComment.OptionsColumn.ShowInCustomizationForm = false;
      this.gcComment.OptionsFilter.AllowAutoFilter = false;
      this.gcComment.OptionsFilter.AllowFilter = false;
      this.gcComment.Visible = true;
      this.gcComment.VisibleIndex = 3;
      this.gcComment.Width = 140;
      this.commentMemo.Appearance.Options.UseTextOptions = true;
      this.commentMemo.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
      this.commentMemo.Name = "commentMemo";
      this.gcParams.Caption = "Parameters";
      this.gcParams.FieldName = "Parameters";
      this.gcParams.Name = "gcParams";
      this.gcParams.OptionsColumn.AllowEdit = false;
      this.gcParams.OptionsColumn.ReadOnly = true;
      this.gcParams.OptionsColumn.ShowInCustomizationForm = false;
      this.gcParams.OptionsFilter.AllowAutoFilter = false;
      this.gcParams.OptionsFilter.AllowFilter = false;
      this.gcActionType.Caption = "ActionType";
      this.gcActionType.FieldName = "ActionType";
      this.gcActionType.Name = "gcActionType";
      this.gcActionType.OptionsColumn.AllowEdit = false;
      this.gcActionType.OptionsColumn.ReadOnly = true;
      this.gcActionType.OptionsColumn.ShowInCustomizationForm = false;
      this.gcActionType.OptionsFilter.AllowAutoFilter = false;
      this.gcActionType.OptionsFilter.AllowFilter = false;
      this.panelButtons.Controls.Add((Control) this.chkColumnHeaders);
      this.panelButtons.Controls.Add((Control) this.btnRedoAll);
      this.panelButtons.Controls.Add((Control) this.btnRedo);
      this.panelButtons.Controls.Add((Control) this.btnUndo);
      this.panelButtons.Controls.Add((Control) this.labelName);
      this.panelButtons.Controls.Add((Control) this.btnUndoAll);
      this.panelButtons.Dock = DockStyle.Left;
      this.panelButtons.Location = new Point(0, 0);
      this.panelButtons.Name = "panelButtons";
      this.panelButtons.Size = new Size(68, 364);
      this.panelButtons.TabIndex = 0;
      this.chkColumnHeaders.Checked = true;
      this.chkColumnHeaders.CheckState = CheckState.Checked;
      this.chkColumnHeaders.Location = new Point(4, 100);
      this.chkColumnHeaders.Name = "chkColumnHeaders";
      this.chkColumnHeaders.Size = new Size(80, 40);
      this.chkColumnHeaders.TabIndex = 5;
      this.chkColumnHeaders.Text = "Названия столбцов";
      this.chkColumnHeaders.Visible = false;
      this.chkColumnHeaders.CheckedChanged += new EventHandler(this.chkColumnHeaders_CheckedChanged);
      this.btnRedoAll.FlatStyle = FlatStyle.Popup;
      this.btnRedoAll.Location = new Point(4, 76);
      this.btnRedoAll.Name = "btnRedoAll";
      this.btnRedoAll.Size = new Size(60, 20);
      this.btnRedoAll.TabIndex = 4;
      this.btnRedoAll.Text = "RedoAll";
      this.btnRedoAll.Click += new EventHandler(this.btnRedoAll_Click);
      this.btnRedo.FlatStyle = FlatStyle.Popup;
      this.btnRedo.Location = new Point(4, 52);
      this.btnRedo.Name = "btnRedo";
      this.btnRedo.Size = new Size(60, 20);
      this.btnRedo.TabIndex = 3;
      this.btnRedo.Text = "Redo";
      this.btnRedo.Click += new EventHandler(this.btnRedo_Click);
      this.btnUndo.FlatStyle = FlatStyle.Popup;
      this.btnUndo.Location = new Point(4, 28);
      this.btnUndo.Name = "btnUndo";
      this.btnUndo.Size = new Size(60, 20);
      this.btnUndo.TabIndex = 2;
      this.btnUndo.Text = "Undo";
      this.btnUndo.Click += new EventHandler(this.btnUndo_Click);
      this.labelName.Location = new Point(4, 144);
      this.labelName.Name = "labelName";
      this.labelName.Size = new Size(60, 22);
      this.labelName.TabIndex = 0;
      this.labelName.Text = "Действия";
      this.labelName.TextAlign = ContentAlignment.MiddleLeft;
      this.labelName.Visible = false;
      this.btnUndoAll.FlatStyle = FlatStyle.Popup;
      this.btnUndoAll.Location = new Point(4, 4);
      this.btnUndoAll.Name = "btnUndoAll";
      this.btnUndoAll.Size = new Size(60, 20);
      this.btnUndoAll.TabIndex = 1;
      this.btnUndoAll.Text = "UndoAll";
      this.btnUndoAll.Click += new EventHandler(this.btnUndoAll_Click);
      this.Controls.Add((Control) this.gridControlActions);
      this.Controls.Add((Control) this.panelButtons);
      this.Name = "ActionViewer";
      this.Size = new Size(580, 364);
      this.gridControlActions.EndInit();
      this.gridViewActions.EndInit();
      this.imageCBAccuracy.EndInit();
      this.messageMemo.EndInit();
      this.commentMemo.EndInit();
      this.panelButtons.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public void SetDataBinding(ActionCollection collection)
    {
      this.gridControlActions.DataSource = (object) collection;
    }

    private void chkColumnHeaders_CheckedChanged(object sender, EventArgs e)
    {
      this.gridViewActions.OptionsView.ShowColumnHeaders = this.chkColumnHeaders.Checked;
    }

    private void btnUndoAll_Click(object sender, EventArgs e)
    {
      if (this.OnUndoAll == null)
        return;
      this.OnUndoAll();
    }

    private void btnUndo_Click(object sender, EventArgs e)
    {
      if (this.OnUndo == null)
        return;
      this.OnUndo();
    }

    private void btnRedo_Click(object sender, EventArgs e)
    {
      if (this.OnRedo == null)
        return;
      this.OnRedo();
    }

    private void btnRedoAll_Click(object sender, EventArgs e)
    {
      if (this.OnRedoAll == null)
        return;
      this.OnRedoAll();
    }

    public delegate void ActionEventHandler();
  }
}
