// Type: Mephi.K22.LearningSuite.OneDSearch.Base.PointViewer
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using Mephi.K22.LearningSuite.Core;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class PointViewer : UserControl
  {
    private Container components = (Container) null;
    private GroupBox groupBoxPoints;
    private GridControl gridControlPoints;
    private CustomView gridViewPoints;
    private GridColumn gcName;
    private GridColumn gcDisplayCoordX;
    private GridColumn gcDisplayFuncValue;
    private Button btnDeletePoint;
    private Button btnCreatePoint;
    private Panel panelPointsButton;
    private ContextMenu cMenuPoint;
    private MenuItem miCreatePointCoord;
    private MenuItem miCreatePointDih;
    private MenuItem miCreatePointPauell;
    private Button btnExperiment;
    private MenuItem miSplitter1;
    private MenuItem miFictPoint;

    public bool EnabledControls
    {
      set
      {
        this.btnCreatePoint.Enabled = value;
        this.btnDeletePoint.Enabled = value;
        this.btnExperiment.Enabled = value;
      }
    }

    public bool IsDiskrete
    {
      set
      {
        this.miFictPoint.Enabled = value;
        this.miCreatePointCoord.Enabled = this.miCreatePointDih.Enabled = this.miCreatePointPauell.Enabled = !value;
      }
    }

    public event Point.CreatePointByCoordHandler CreatePointByCoord;

    public event EventHandler CreateFictDiskrete;

    public event Point.Point2PointsEvent CreatePointByDiv2Points;

    public event Point.PointCollectionEvent DeletePoints;

    public event Point.PointCollectionEvent SelectPoints;

    public event Point.PointCollectionEvent RunTests;

    public event Point.PointCollectionEvent CreatePaul;

    public PointViewer()
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
      this.groupBoxPoints = new GroupBox();
      this.gridControlPoints = new GridControl();
      this.gridViewPoints = new CustomView();
      this.gcDisplayCoordX = new GridColumn();
      this.gcName = new GridColumn();
      this.gcDisplayFuncValue = new GridColumn();
      this.panelPointsButton = new Panel();
      this.btnExperiment = new Button();
      this.btnCreatePoint = new Button();
      this.btnDeletePoint = new Button();
      this.cMenuPoint = new ContextMenu();
      this.miCreatePointCoord = new MenuItem();
      this.miCreatePointDih = new MenuItem();
      this.miCreatePointPauell = new MenuItem();
      this.miSplitter1 = new MenuItem();
      this.miFictPoint = new MenuItem();
      this.groupBoxPoints.SuspendLayout();
      this.gridControlPoints.BeginInit();
      this.gridViewPoints.BeginInit();
      this.panelPointsButton.SuspendLayout();
      this.SuspendLayout();
      this.groupBoxPoints.Controls.Add((Control) this.gridControlPoints);
      this.groupBoxPoints.Controls.Add((Control) this.panelPointsButton);
      this.groupBoxPoints.Dock = DockStyle.Fill;
      this.groupBoxPoints.Location = new System.Drawing.Point(0, 0);
      this.groupBoxPoints.Name = "groupBoxPoints";
      this.groupBoxPoints.Size = new Size(228, 248);
      this.groupBoxPoints.TabIndex = 1;
      this.groupBoxPoints.TabStop = false;
      this.groupBoxPoints.Text = "Точки";
      this.gridControlPoints.Dock = DockStyle.Fill;
      this.gridControlPoints.EmbeddedNavigator.Name = "";
      this.gridControlPoints.Location = new System.Drawing.Point(3, 37);
      this.gridControlPoints.MainView = (BaseView) this.gridViewPoints;
      this.gridControlPoints.Name = "gridControlPoints";
      this.gridControlPoints.Size = new Size(222, 208);
      this.gridControlPoints.TabIndex = 0;
      this.gridControlPoints.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridViewPoints
      });
      this.gridViewPoints.Appearance.OddRow.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.gridViewPoints.Appearance.OddRow.BackColor2 = Color.White;
      this.gridViewPoints.Appearance.OddRow.GradientMode = LinearGradientMode.Vertical;
      this.gridViewPoints.Appearance.OddRow.Options.UseBackColor = true;
      this.gridViewPoints.Columns.AddRange(new GridColumn[3]
      {
        this.gcDisplayCoordX,
        this.gcName,
        this.gcDisplayFuncValue
      });
      this.gridViewPoints.GridControl = this.gridControlPoints;
      this.gridViewPoints.GroupPanelText = "Для группировки по колонке перетащите сюда заголовок этой колонки";
      this.gridViewPoints.Name = "gridViewPoints";
      this.gridViewPoints.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridViewPoints.OptionsSelection.MultiSelect = true;
      this.gridViewPoints.OptionsView.EnableAppearanceOddRow = true;
      this.gridViewPoints.OptionsView.ShowDetailButtons = false;
      this.gridViewPoints.OptionsView.ShowGroupPanel = false;
      this.gridViewPoints.OptionsView.ShowIndicator = false;
      this.gridViewPoints.PaintStyleName = "Flat";
      this.gridViewPoints.SortInfo.AddRange(new GridColumnSortInfo[1]
      {
        new GridColumnSortInfo(this.gcDisplayCoordX, ColumnSortOrder.Ascending)
      });
      this.gridViewPoints.SelectionChanged += new SelectionChangedEventHandler(this.gridViewPoints_SelectionChanged);
      this.gcDisplayCoordX.Caption = "x";
      this.gcDisplayCoordX.DisplayFormat.FormatString = "0.0000";
      this.gcDisplayCoordX.DisplayFormat.FormatType = FormatType.Numeric;
      this.gcDisplayCoordX.FieldName = "DisplayCoordX";
      this.gcDisplayCoordX.Name = "gcDisplayCoordX";
      this.gcDisplayCoordX.OptionsColumn.AllowEdit = false;
      this.gcDisplayCoordX.OptionsColumn.ReadOnly = true;
      this.gcDisplayCoordX.OptionsFilter.AllowAutoFilter = false;
      this.gcDisplayCoordX.OptionsFilter.AllowFilter = false;
      this.gcDisplayCoordX.OptionsFilter.ImmediateUpdateAutoFilter = false;
      this.gcDisplayCoordX.Visible = true;
      this.gcDisplayCoordX.VisibleIndex = 0;
      this.gcDisplayCoordX.Width = 65;
      this.gcName.Caption = "Имя";
      this.gcName.FieldName = "Name";
      this.gcName.Name = "gcName";
      this.gcName.OptionsColumn.AllowEdit = false;
      this.gcName.OptionsColumn.ReadOnly = true;
      this.gcName.OptionsFilter.AllowAutoFilter = false;
      this.gcName.OptionsFilter.AllowFilter = false;
      this.gcName.OptionsFilter.ImmediateUpdateAutoFilter = false;
      this.gcName.Visible = true;
      this.gcName.VisibleIndex = 1;
      this.gcName.Width = 65;
      this.gcDisplayFuncValue.Caption = "F(x)";
      this.gcDisplayFuncValue.DisplayFormat.FormatString = "0.0000";
      this.gcDisplayFuncValue.DisplayFormat.FormatType = FormatType.Numeric;
      this.gcDisplayFuncValue.FieldName = "DisplayFuncValue";
      this.gcDisplayFuncValue.Name = "gcDisplayFuncValue";
      this.gcDisplayFuncValue.OptionsColumn.AllowEdit = false;
      this.gcDisplayFuncValue.OptionsColumn.ReadOnly = true;
      this.gcDisplayFuncValue.OptionsFilter.AllowAutoFilter = false;
      this.gcDisplayFuncValue.OptionsFilter.AllowFilter = false;
      this.gcDisplayFuncValue.OptionsFilter.ImmediateUpdateAutoFilter = false;
      this.gcDisplayFuncValue.Visible = true;
      this.gcDisplayFuncValue.VisibleIndex = 2;
      this.gcDisplayFuncValue.Width = 100;
      this.panelPointsButton.BackColor = SystemColors.Control;
      this.panelPointsButton.Controls.Add((Control) this.btnExperiment);
      this.panelPointsButton.Controls.Add((Control) this.btnCreatePoint);
      this.panelPointsButton.Controls.Add((Control) this.btnDeletePoint);
      this.panelPointsButton.Dock = DockStyle.Top;
      this.panelPointsButton.Location = new System.Drawing.Point(3, 16);
      this.panelPointsButton.Name = "panelPointsButton";
      this.panelPointsButton.Size = new Size(222, 21);
      this.panelPointsButton.TabIndex = 1;
      this.btnExperiment.FlatStyle = FlatStyle.Popup;
      this.btnExperiment.Location = new System.Drawing.Point(68, 0);
      this.btnExperiment.Name = "btnExperiment";
      this.btnExperiment.Size = new Size(84, 20);
      this.btnExperiment.TabIndex = 2;
      this.btnExperiment.Text = "Эксперимент";
      this.btnExperiment.Click += new EventHandler(this.btnExperiment_Click);
      this.btnCreatePoint.FlatStyle = FlatStyle.Popup;
      this.btnCreatePoint.Location = new System.Drawing.Point(4, 0);
      this.btnCreatePoint.Name = "btnCreatePoint";
      this.btnCreatePoint.Size = new Size(60, 20);
      this.btnCreatePoint.TabIndex = 0;
      this.btnCreatePoint.Text = "Создать";
      this.btnCreatePoint.Click += new EventHandler(this.btnCreatePoint_Click);
      this.btnDeletePoint.FlatStyle = FlatStyle.Popup;
      this.btnDeletePoint.Location = new System.Drawing.Point(156, 0);
      this.btnDeletePoint.Name = "btnDeletePoint";
      this.btnDeletePoint.Size = new Size(60, 20);
      this.btnDeletePoint.TabIndex = 1;
      this.btnDeletePoint.Text = "Удалить";
      this.btnDeletePoint.Click += new EventHandler(this.btnDelete_Click);
      this.cMenuPoint.MenuItems.AddRange(new MenuItem[5]
      {
        this.miCreatePointCoord,
        this.miCreatePointDih,
        this.miCreatePointPauell,
        this.miSplitter1,
        this.miFictPoint
      });
      this.miCreatePointCoord.Index = 0;
      this.miCreatePointCoord.Text = "задать координату";
      this.miCreatePointCoord.Click += new EventHandler(this.miCreatePointCoord_Click);
      this.miCreatePointDih.Index = 1;
      this.miCreatePointDih.Text = "Xn=(Xm+Xk)/2";
      this.miCreatePointDih.Click += new EventHandler(this.miCreatePointDih_Click);
      this.miCreatePointPauell.Index = 2;
      this.miCreatePointPauell.Text = "Xn=()*()*()/()*()*()";
      this.miCreatePointPauell.Click += new EventHandler(this.miCreatePointPauell_Click);
      this.miSplitter1.Index = 3;
      this.miSplitter1.Text = "-";
      this.miFictPoint.Enabled = false;
      this.miFictPoint.Index = 4;
      this.miFictPoint.Text = "Фиктивная точка";
      this.miFictPoint.Click += new EventHandler(this.miFictPoint_Click);
      this.Controls.Add((Control) this.groupBoxPoints);
      this.Name = "PointViewer";
      this.Size = new Size(228, 248);
      this.groupBoxPoints.ResumeLayout(false);
      this.gridControlPoints.EndInit();
      this.gridViewPoints.EndInit();
      this.panelPointsButton.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public void SetDataBinding(PointCollection collection)
    {
      this.gridControlPoints.DataSource = (object) collection;
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      PointCollection selected = this.GetSelected();
      this.gridViewPoints.BeginDataUpdate();
      if (this.DeletePoints != null)
        this.DeletePoints(selected);
      this.gridViewPoints.EndDataUpdate();
    }

    private void btnCreatePoint_Click(object sender, EventArgs e)
    {
      this.cMenuPoint.Show((Control) this, new System.Drawing.Point(80, 35));
    }

    private void miCreatePointCoord_Click(object sender, EventArgs e)
    {
      PointCoord pointCoord = new PointCoord();
      if (pointCoord.ShowDialog() != DialogResult.OK || this.CreatePointByCoord == null)
        return;
      this.CreatePointByCoord(pointCoord.Coord);
    }

    private void miCreatePointDih_Click(object sender, EventArgs e)
    {
      int[] selectedRows = this.gridViewPoints.GetSelectedRows();
      if (selectedRows != null && selectedRows.Length == 2)
      {
        Point point1 = (Point) this.gridViewPoints.GetRow(selectedRows[0]);
        Point point2 = (Point) this.gridViewPoints.GetRow(selectedRows[1]);
        if (this.CreatePointByDiv2Points == null)
          return;
        this.CreatePointByDiv2Points((BasePoint) point1, (BasePoint) point2);
      }
      else
      {
        int num = (int) MessageBox.Show("Сначала выделите две строки в таблице", "Ошибка!");
      }
    }

    private void gridViewPoints_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      PointCollection selected = this.GetSelected();
      if (this.SelectPoints == null)
        return;
      this.SelectPoints(selected);
    }

    private void btnExperiment_Click(object sender, EventArgs e)
    {
      PointCollection selected = this.GetSelected();
      this.gridViewPoints.BeginDataUpdate();
      if (this.RunTests != null)
        this.RunTests(selected);
      this.gridViewPoints.EndDataUpdate();
    }

    private PointCollection GetSelected()
    {
      int[] selectedRows = this.gridViewPoints.GetSelectedRows();
      PointCollection pointCollection = new PointCollection();
      if (selectedRows != null && selectedRows.Length > 0)
      {
        for (int index = 0; index < selectedRows.Length; ++index)
        {
          BasePoint basePoint = this.gridViewPoints.GetRow(selectedRows[index]) as BasePoint;
          if (basePoint != null)
            pointCollection.Add(basePoint);
        }
      }
      return pointCollection;
    }

    public void BeginEdit()
    {
      this.gridViewPoints.BeginDataUpdate();
    }

    public void EndEdit()
    {
      this.gridViewPoints.EndDataUpdate();
    }

    private void miCreatePointPauell_Click(object sender, EventArgs e)
    {
      int[] selectedRows = this.gridViewPoints.GetSelectedRows();
      PointCollection pCol = new PointCollection();
      if (selectedRows != null && selectedRows.Length == 3)
      {
        bool flag = true;
        for (int index = 0; index < selectedRows.Length; ++index)
        {
          if (!((BasePoint) this.gridViewPoints.GetRow(selectedRows[index])).FuncButton.IsEval)
          {
            flag = false;
            break;
          }
        }
        if (flag)
        {
          for (int index = 0; index < selectedRows.Length; ++index)
          {
            Point point = (Point) this.gridViewPoints.GetRow(selectedRows[index]);
            pCol.Add((BasePoint) point);
          }
          if (this.CreatePaul == null)
            return;
          this.CreatePaul(pCol);
        }
        else
        {
          int num = (int) MessageBox.Show("В данных точках должны быть проведены эксперименты", "Ошибка!");
        }
      }
      else
      {
        int num1 = (int) MessageBox.Show("Сначала выделите три строки в таблице", "Ошибка!");
      }
    }

    private void miFictPoint_Click(object sender, EventArgs e)
    {
      if (this.CreateFictDiskrete == null)
        return;
      this.CreateFictDiskrete((object) this, (EventArgs) null);
    }
  }
}
