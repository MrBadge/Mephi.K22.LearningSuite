// Type: Mephi.K22.LearningSuite.Core.BaseGridControl
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Core
{
  public class BaseGridControl : BaseControl
  {
    private bool _enableEdit = true;
    public BaseFilterControl FilterControl = (BaseFilterControl) null;
    public BaseDetailForm DetailForm = (BaseDetailForm) null;
    public ToolBar toolBar;
    protected ToolBarButton tbbAdd;
    protected ToolBarButton tbbEdit;
    protected ToolBarButton tbbDelete;
    protected ToolBarButton tbbRefresh;
    protected ImageList imageList;
    private Panel panelFilter;
    public GridControl Grid;
    public CustomView View;
    private IContainer components;

    public DataRow SelectedRow
    {
      get
      {
        int[] selectedRows = this.View.GetSelectedRows();
        if (selectedRows.Length > 0)
          return ((DataRowView) this.View.GetRow(selectedRows[0])).Row;
        else
          return (DataRow) null;
      }
    }

    protected bool EnableEdit
    {
      get
      {
        return this._enableEdit;
      }
      set
      {
        this._enableEdit = value;
        this.SetEditEnable(value);
      }
    }

    public BaseGridControl()
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
      ResourceManager resourceManager = new ResourceManager(typeof (BaseGridControl));
      this.toolBar = new ToolBar();
      this.tbbAdd = new ToolBarButton();
      this.tbbEdit = new ToolBarButton();
      this.tbbDelete = new ToolBarButton();
      this.tbbRefresh = new ToolBarButton();
      this.imageList = new ImageList(this.components);
      this.panelFilter = new Panel();
      this.Grid = new GridControl();
      this.View = new CustomView();
      this.Grid.BeginInit();
      this.View.BeginInit();
      this.SuspendLayout();
      this.toolBar.Appearance = ToolBarAppearance.Flat;
      this.toolBar.Buttons.AddRange(new ToolBarButton[4]
      {
        this.tbbAdd,
        this.tbbEdit,
        this.tbbDelete,
        this.tbbRefresh
      });
      this.toolBar.Divider = false;
      this.toolBar.DropDownArrows = true;
      this.toolBar.ImageList = this.imageList;
      this.toolBar.Location = new Point(0, 0);
      this.toolBar.Name = "toolBar";
      this.toolBar.ShowToolTips = true;
      this.toolBar.Size = new Size(840, 26);
      this.toolBar.TabIndex = 1;
      this.toolBar.TextAlign = ToolBarTextAlign.Right;
      this.toolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
      this.tbbAdd.ImageIndex = 0;
      this.tbbAdd.Text = "Добавить";
      this.tbbAdd.ToolTipText = "Добавить";
      this.tbbEdit.ImageIndex = 3;
      this.tbbEdit.Text = "Редактировать";
      this.tbbEdit.ToolTipText = "Редактировать";
      this.tbbDelete.ImageIndex = 1;
      this.tbbDelete.Text = "Удалить";
      this.tbbDelete.ToolTipText = "Удалить";
      this.tbbRefresh.ImageIndex = 2;
      this.tbbRefresh.Text = "Обновить";
      this.tbbRefresh.ToolTipText = "Обновить";
      this.imageList.ImageSize = new Size(16, 16);
      this.imageList.ImageStream = (ImageListStreamer) resourceManager.GetObject("imageList.ImageStream");
      this.imageList.TransparentColor = Color.Transparent;
      this.panelFilter.Dock = DockStyle.Top;
      this.panelFilter.Location = new Point(0, 26);
      this.panelFilter.Name = "panelFilter";
      this.panelFilter.Size = new Size(840, 46);
      this.panelFilter.TabIndex = 2;
      this.Grid.Dock = DockStyle.Fill;
      this.Grid.EmbeddedNavigator.Name = "";
      this.Grid.Location = new Point(0, 72);
      this.Grid.MainView = (BaseView) this.View;
      this.Grid.Name = "Grid";
      this.Grid.Size = new Size(840, 320);
      this.Grid.TabIndex = 3;
      this.Grid.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.View
      });
      this.Grid.DoubleClick += new EventHandler(this.Grid_DoubleClick);
      this.View.GridControl = this.Grid;
      this.View.GroupPanelText = "Для группировки по колонке перетащите сюда заголовок этой колонки";
      this.View.Name = "View";
      this.View.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.View.OptionsView.EnableAppearanceOddRow = true;
      this.Controls.Add((Control) this.Grid);
      this.Controls.Add((Control) this.panelFilter);
      this.Controls.Add((Control) this.toolBar);
      this.Name = "BaseGridControl";
      this.Size = new Size(840, 392);
      this.Load += new EventHandler(this.GridWorkSpaceControl_Load);
      this.Grid.EndInit();
      this.View.EndInit();
      this.ResumeLayout(false);
    }

    private void GridWorkSpaceControl_Load(object sender, EventArgs e)
    {
      this.Initialize();
    }

    protected virtual void Initialize()
    {
      this.InitializeFilter();
    }

    private void InitializeFilter()
    {
      if (this.FilterControl != null)
      {
        this.panelFilter.Size = this.FilterControl.Size;
        this.panelFilter.Controls.Add((Control) this.FilterControl);
        this.FilterControl.Dock = DockStyle.Top;
      }
      else
        this.panelFilter.Size = new Size(0, 0);
    }

    protected virtual DataTable GetData()
    {
      return new DataTable();
    }

    private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
    {
      if (e.Button == this.tbbAdd)
        this.AddNewItem();
      else if (e.Button == this.tbbEdit)
        this.EditItem();
      else if (e.Button == this.tbbDelete)
      {
        this.DeleteItem();
      }
      else
      {
        if (e.Button != this.tbbRefresh)
          return;
        this.RefreshData();
      }
    }

    private void AddNewItem()
    {
      if (this.DetailForm == null)
        return;
      this.DetailForm.isEdit = false;
      this.DetailForm.Text = "Добавление";
      this.BeforeShowAddForm();
      this.DetailForm.OnAddSave += new BaseDetailForm.OnAddSaveDelegate(this.SaveOnAdd);
      this.DetailForm.OnClose += new BaseDetailForm.OnCloseDelegate(this.CloseDetail);
      if (this.DetailForm.ShowDialog() == DialogResult.OK)
        this.RefreshData();
      this.AfterShowDetailForm();
    }

    private void EditItem()
    {
      if (this.DetailForm == null || this.SelectedRow == null)
        return;
      this.DetailForm.isEdit = true;
      this.DetailForm.Text = "Редактирование";
      this.BeforeShowEditForm();
      this.DetailForm.OnEditSave += new BaseDetailForm.OnEditSaveDelegate(this.SaveOnEdit);
      this.DetailForm.OnClose += new BaseDetailForm.OnCloseDelegate(this.CloseDetail);
      if (this.DetailForm.ShowDialog() == DialogResult.OK)
        this.RefreshData();
      this.AfterShowDetailForm();
    }

    private void CloseDetail()
    {
      if (this.DetailForm.isEdit)
        this.DetailForm.OnEditSave -= new BaseDetailForm.OnEditSaveDelegate(this.SaveOnEdit);
      else
        this.DetailForm.OnAddSave -= new BaseDetailForm.OnAddSaveDelegate(this.SaveOnAdd);
    }

    private void DeleteItem()
    {
      if (this.SelectedRow == null)
        return;
      this.OnDelete();
      this.RefreshData();
    }

    public virtual void OnDelete()
    {
    }

    public virtual void RefreshData()
    {
      this.Grid.DataSource = (object) this.GetData();
    }

    public virtual void BeforeShowAddForm()
    {
      this.DetailForm.Clear();
    }

    public virtual void BeforeShowEditForm()
    {
      this.DetailForm.Clear();
    }

    public virtual void BeforeShowDetailForm()
    {
    }

    public virtual void AfterShowDetailForm()
    {
    }

    public virtual void SaveOnAdd()
    {
    }

    public virtual void SaveOnEdit()
    {
    }

    private void Grid_DoubleClick(object sender, EventArgs e)
    {
      if (!this._enableEdit)
        return;
      this.EditItem();
    }

    private void SetEditEnable(bool enable)
    {
      this.tbbEdit.Enabled = enable;
    }
  }
}
