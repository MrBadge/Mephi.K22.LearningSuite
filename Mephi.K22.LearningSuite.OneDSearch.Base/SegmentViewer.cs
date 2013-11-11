// Type: Mephi.K22.LearningSuite.OneDSearch.Base.SegmentViewer
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
  public class SegmentViewer : UserControl
  {
    private Container components = (Container) null;
    private GroupBox groupBoxSegments;
    private GridControl gridControlSegments;
    private CustomView gridViewSegments;
    private GridColumn gcLength;
    private GridColumn gcSegmentName;
    private Panel panelPointsButton;
    private ContextMenu cMenuSegment;
    private MenuItem miCreateSegmentLength;
    private MenuItem miCreateSegmentDih;
    private MenuItem miCreateSegmentGold;
    private MenuItem miCreateSegmentFib;
    private Button btnCreateSeg;
    private Button btnDeleteSeg;
    private Button btnConnectedSegment;

    public bool EnabledControls
    {
      set
      {
        this.btnCreateSeg.Enabled = value;
        this.btnDeleteSeg.Enabled = value;
      }
    }

    public bool IsDiskrete
    {
      get
      {
        return this.btnConnectedSegment.Enabled;
      }
      set
      {
        this.btnConnectedSegment.Enabled = value;
      }
    }

    public event Segment.CreateSegmentByLengthHandler CreateSegmentByLength;

    public event Segment.SegmentEvent CreateSegmentByDiv2Segment;

    public event Segment.SegmentEvent CreateSegmentByGoldSegment;

    public event Segment.SegmentCollectionEvent SelectSegments;

    public event Segment.SegmentCollectionEvent DeleteSegments;

    public event Segment.CreateSegmentByFibHandler CreateSegmentByFib;

    public event EventHandler CreateConnectedSegment;

    public SegmentViewer()
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
      this.groupBoxSegments = new GroupBox();
      this.gridControlSegments = new GridControl();
      this.gridViewSegments = new CustomView();
      this.gcLength = new GridColumn();
      this.gcSegmentName = new GridColumn();
      this.panelPointsButton = new Panel();
      this.btnConnectedSegment = new Button();
      this.btnCreateSeg = new Button();
      this.btnDeleteSeg = new Button();
      this.cMenuSegment = new ContextMenu();
      this.miCreateSegmentLength = new MenuItem();
      this.miCreateSegmentDih = new MenuItem();
      this.miCreateSegmentGold = new MenuItem();
      this.miCreateSegmentFib = new MenuItem();
      this.groupBoxSegments.SuspendLayout();
      this.gridControlSegments.BeginInit();
      this.gridViewSegments.BeginInit();
      this.panelPointsButton.SuspendLayout();
      this.SuspendLayout();
      this.groupBoxSegments.Controls.Add((Control) this.gridControlSegments);
      this.groupBoxSegments.Controls.Add((Control) this.panelPointsButton);
      this.groupBoxSegments.Dock = DockStyle.Fill;
      this.groupBoxSegments.Location = new System.Drawing.Point(0, 0);
      this.groupBoxSegments.Name = "groupBoxSegments";
      this.groupBoxSegments.Size = new Size(200, 288);
      this.groupBoxSegments.TabIndex = 1;
      this.groupBoxSegments.TabStop = false;
      this.groupBoxSegments.Text = "Отрезки";
      this.gridControlSegments.Dock = DockStyle.Fill;
      this.gridControlSegments.EmbeddedNavigator.Name = "";
      this.gridControlSegments.Location = new System.Drawing.Point(3, 37);
      this.gridControlSegments.MainView = (BaseView) this.gridViewSegments;
      this.gridControlSegments.Name = "gridControlSegments";
      this.gridControlSegments.Size = new Size(194, 248);
      this.gridControlSegments.TabIndex = 0;
      this.gridControlSegments.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridViewSegments
      });
      this.gridViewSegments.Appearance.OddRow.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.gridViewSegments.Appearance.OddRow.BackColor2 = Color.White;
      this.gridViewSegments.Appearance.OddRow.GradientMode = LinearGradientMode.Vertical;
      this.gridViewSegments.Appearance.OddRow.Options.UseBackColor = true;
      this.gridViewSegments.Columns.AddRange(new GridColumn[2]
      {
        this.gcLength,
        this.gcSegmentName
      });
      this.gridViewSegments.GridControl = this.gridControlSegments;
      this.gridViewSegments.GroupPanelText = "Для группировки по колонке перетащите сюда заголовок этой колонки";
      this.gridViewSegments.Name = "gridViewSegments";
      this.gridViewSegments.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridViewSegments.OptionsSelection.MultiSelect = true;
      this.gridViewSegments.OptionsView.EnableAppearanceOddRow = true;
      this.gridViewSegments.OptionsView.ShowDetailButtons = false;
      this.gridViewSegments.OptionsView.ShowGroupPanel = false;
      this.gridViewSegments.OptionsView.ShowIndicator = false;
      this.gridViewSegments.PaintStyleName = "Flat";
      this.gridViewSegments.SortInfo.AddRange(new GridColumnSortInfo[1]
      {
        new GridColumnSortInfo(this.gcLength, ColumnSortOrder.Ascending)
      });
      this.gridViewSegments.SelectionChanged += new SelectionChangedEventHandler(this.gridViewSegments_SelectionChanged);
      this.gcLength.Caption = "Длина";
      this.gcLength.DisplayFormat.FormatString = "0.0000";
      this.gcLength.DisplayFormat.FormatType = FormatType.Numeric;
      this.gcLength.FieldName = "DisplayLength";
      this.gcLength.Name = "gcLength";
      this.gcLength.OptionsColumn.AllowEdit = false;
      this.gcLength.OptionsColumn.ReadOnly = true;
      this.gcLength.OptionsFilter.AllowAutoFilter = false;
      this.gcLength.OptionsFilter.AllowFilter = false;
      this.gcLength.OptionsFilter.ImmediateUpdateAutoFilter = false;
      this.gcLength.Visible = true;
      this.gcLength.VisibleIndex = 0;
      this.gcSegmentName.Caption = "Имя";
      this.gcSegmentName.FieldName = "Name";
      this.gcSegmentName.Name = "gcSegmentName";
      this.gcSegmentName.OptionsColumn.AllowEdit = false;
      this.gcSegmentName.OptionsColumn.ReadOnly = true;
      this.gcSegmentName.OptionsFilter.AllowAutoFilter = false;
      this.gcSegmentName.OptionsFilter.AllowFilter = false;
      this.gcSegmentName.OptionsFilter.ImmediateUpdateAutoFilter = false;
      this.gcSegmentName.Visible = true;
      this.gcSegmentName.VisibleIndex = 1;
      this.panelPointsButton.BackColor = SystemColors.Control;
      this.panelPointsButton.Controls.Add((Control) this.btnConnectedSegment);
      this.panelPointsButton.Controls.Add((Control) this.btnCreateSeg);
      this.panelPointsButton.Controls.Add((Control) this.btnDeleteSeg);
      this.panelPointsButton.Dock = DockStyle.Top;
      this.panelPointsButton.Location = new System.Drawing.Point(3, 16);
      this.panelPointsButton.Name = "panelPointsButton";
      this.panelPointsButton.Size = new Size(194, 21);
      this.panelPointsButton.TabIndex = 2;
      this.btnConnectedSegment.Enabled = false;
      this.btnConnectedSegment.FlatStyle = FlatStyle.Popup;
      this.btnConnectedSegment.Location = new System.Drawing.Point(120, 0);
      this.btnConnectedSegment.Name = "btnConnectedSegment";
      this.btnConnectedSegment.Size = new Size(88, 20);
      this.btnConnectedSegment.TabIndex = 2;
      this.btnConnectedSegment.Text = "Сопряженный";
      this.btnConnectedSegment.Click += new EventHandler(this.btnConnectedSegment_Click);
      this.btnCreateSeg.FlatStyle = FlatStyle.Popup;
      this.btnCreateSeg.Location = new System.Drawing.Point(4, 0);
      this.btnCreateSeg.Name = "btnCreateSeg";
      this.btnCreateSeg.Size = new Size(56, 20);
      this.btnCreateSeg.TabIndex = 0;
      this.btnCreateSeg.Text = "Создать";
      this.btnCreateSeg.Click += new EventHandler(this.btnCreatePoint_Click);
      this.btnDeleteSeg.FlatStyle = FlatStyle.Popup;
      this.btnDeleteSeg.Location = new System.Drawing.Point(62, 0);
      this.btnDeleteSeg.Name = "btnDeleteSeg";
      this.btnDeleteSeg.Size = new Size(56, 20);
      this.btnDeleteSeg.TabIndex = 1;
      this.btnDeleteSeg.Text = "Удалить";
      this.btnDeleteSeg.Click += new EventHandler(this.btnDelete_Click);
      this.cMenuSegment.MenuItems.AddRange(new MenuItem[4]
      {
        this.miCreateSegmentLength,
        this.miCreateSegmentDih,
        this.miCreateSegmentGold,
        this.miCreateSegmentFib
      });
      this.miCreateSegmentLength.Index = 0;
      this.miCreateSegmentLength.Text = "задать длину";
      this.miCreateSegmentLength.Click += new EventHandler(this.miCreateSegmentLength_Click);
      this.miCreateSegmentDih.Index = 1;
      this.miCreateSegmentDih.Text = "Ln=Lk/2";
      this.miCreateSegmentDih.Click += new EventHandler(this.miCreateSegmentDih_Click);
      this.miCreateSegmentGold.Index = 2;
      this.miCreateSegmentGold.Text = "Ln=Lk/1.618";
      this.miCreateSegmentGold.Click += new EventHandler(this.miCreateSegmentGold_Click);
      this.miCreateSegmentFib.Index = 3;
      this.miCreateSegmentFib.Text = "Ln=Lk*F(n-1)/Fn+(-1)^n*eps/Fn";
      this.miCreateSegmentFib.Click += new EventHandler(this.miCreateSegmentFib_Click);
      this.Controls.Add((Control) this.groupBoxSegments);
      this.Name = "SegmentViewer";
      this.Size = new Size(200, 288);
      this.groupBoxSegments.ResumeLayout(false);
      this.gridControlSegments.EndInit();
      this.gridViewSegments.EndInit();
      this.panelPointsButton.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public void SetDataBinding(SegmentCollection collection)
    {
      this.gridControlSegments.DataSource = (object) collection;
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      SegmentCollection selected = this.GetSelected();
      this.gridViewSegments.BeginDataUpdate();
      if (this.DeleteSegments != null && selected != null)
        this.DeleteSegments(selected);
      this.gridViewSegments.EndDataUpdate();
    }

    private void miCreateSegmentLength_Click(object sender, EventArgs e)
    {
      SegmentLength segmentLength = new SegmentLength();
      if (segmentLength.ShowDialog() != DialogResult.OK || this.CreateSegmentByLength == null)
        return;
      this.CreateSegmentByLength((double) float.Parse(segmentLength.tbLen.Text));
    }

    private void btnCreatePoint_Click(object sender, EventArgs e)
    {
      this.cMenuSegment.Show((Control) this, new System.Drawing.Point(80, 35));
    }

    private void gridViewSegments_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      int[] selectedRows = this.gridViewSegments.GetSelectedRows();
      if (selectedRows == null || selectedRows.Length <= 0)
        return;
      SegmentCollection p = new SegmentCollection();
      for (int index = 0; index < selectedRows.Length; ++index)
      {
        Segment segment = (Segment) this.gridViewSegments.GetRow(selectedRows[index]);
        if (segment != null)
          p.Add((Element) segment);
      }
      if (this.SelectSegments == null)
        return;
      this.SelectSegments(p);
    }

    private SegmentCollection GetSelected()
    {
      int[] selectedRows = this.gridViewSegments.GetSelectedRows();
      SegmentCollection segmentCollection = new SegmentCollection();
      if (selectedRows != null && selectedRows.Length > 0)
      {
        for (int index = 0; index < selectedRows.Length; ++index)
        {
          Segment segment = (Segment) this.gridViewSegments.GetRow(selectedRows[index]);
          if (segment != null)
            segmentCollection.Add((Element) segment);
        }
      }
      return segmentCollection;
    }

    private void miCreateSegmentDih_Click(object sender, EventArgs e)
    {
      int[] selectedRows = this.gridViewSegments.GetSelectedRows();
      if (selectedRows != null && selectedRows.Length == 1)
      {
        Segment s = (Segment) this.gridViewSegments.GetRow(selectedRows[0]);
        if (this.CreateSegmentByDiv2Segment == null)
          return;
        this.CreateSegmentByDiv2Segment(s);
      }
      else
      {
        int num = (int) MessageBox.Show("Сначала выделите строку в таблице", "Ошибка!");
      }
    }

    private void miCreateSegmentGold_Click(object sender, EventArgs e)
    {
      int[] selectedRows = this.gridViewSegments.GetSelectedRows();
      if (selectedRows != null && selectedRows.Length == 1)
      {
        Segment s = (Segment) this.gridViewSegments.GetRow(selectedRows[0]);
        if (this.CreateSegmentByGoldSegment == null)
          return;
        this.CreateSegmentByGoldSegment(s);
      }
      else
      {
        int num = (int) MessageBox.Show("Сначала выделите строку в таблице", "Ошибка!");
      }
    }

    private void miCreateSegmentFib_Click(object sender, EventArgs e)
    {
      int[] selectedRows = this.gridViewSegments.GetSelectedRows();
      if (selectedRows != null && selectedRows.Length == 1)
      {
        Segment s = (Segment) this.gridViewSegments.GetRow(selectedRows[0]);
        SegmentNumFib segmentNumFib = new SegmentNumFib();
        if (segmentNumFib.ShowDialog() != DialogResult.OK || this.CreateSegmentByFib == null)
          return;
        this.CreateSegmentByFib(s, int.Parse(segmentNumFib.tbNumFib.Text));
      }
      else
      {
        int num = (int) MessageBox.Show("Сначала выделите строку в таблице", "Ошибка!");
      }
    }

    private void miLinkedSeg_Click(object sender, EventArgs e)
    {
    }

    private void btnConnectedSegment_Click(object sender, EventArgs e)
    {
      if (this.CreateConnectedSegment == null)
        return;
      this.CreateConnectedSegment((object) this, (EventArgs) null);
    }
  }
}
