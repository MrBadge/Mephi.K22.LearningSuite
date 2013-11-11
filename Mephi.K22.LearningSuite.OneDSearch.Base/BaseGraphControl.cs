// Type: Mephi.K22.LearningSuite.OneDSearch.Base.BaseGraphControl
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using Mephi.K22.LearningSuite.Core;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class BaseGraphControl : UserControl
  {
    private static float scale = 64f;
    private static float zeroX = 10f;
    private static float zeroY = 0.0f;
    private static readonly double _CoordPrecision = 2.0;
    private static readonly int _MaxScale = 1025;
    private static readonly int _MinScale = 1;
    private static readonly int _AxisXZeroPad = 10;
    private IContainer components = (IContainer) null;
    private ResultType _resType = ResultType.segment;
    private DrawAxis _axis = new DrawAxis();
    private ResultSegment _resSegment = (ResultSegment) null;
    private System.Drawing.Point _mouseDownPoint = System.Drawing.Point.Empty;
    private Element _curElement = (Element) null;
    private bool _isFlipped = false;
    private float _startFlipX = 0.0f;
    private float _deltaLX = 0.0f;
    private Segment _drawingSegment = (Segment) null;
    private float _startDrawingPointX = 0.0f;
    private BaseGraphControl.ImageState _state = BaseGraphControl.ImageState.other;
    private bool _isDiskrete = false;
    private ImageList imageList;
    private ToolBarButton tbbScaleP;
    private ToolBarButton tbbScaleM;
    private ToolBarButton tbbZeroPP;
    private ToolBarButton tbbZeroPM;
    private Panel panelGraph;
    private ToolBarButton tbbSeparator1;
    private ToolBarButton tbbSeparator2;
    private ToolBar toolBarGraph;
    private Splitter splitter1;
    private ToolBarButton tbbSeparator3;
    private ToolBarButton tbbSetResult;
    private ToolBarButton tbbSeparator4;
    private ToolBarButton tbbShowTask;
    private pnlgrph panelImage;
    private ToolBarButton tbbSeparator5;
    private ToolBarButton tbbExit;
    private ToolBarButton tbbScaleA;
    private PointCollection _pointCollection;
    private SegmentCollection _segmentCollection;
    private FuncButtonCollection _funcButtonCollection;

    public SegmentCollection SegmentCollection
    {
      set
      {
        this._segmentCollection = value;
      }
    }

    public PointCollection PointCollection
    {
      set
      {
        this._pointCollection = value;
      }
    }

    public FuncButtonCollection FuncButtonCollection
    {
      set
      {
        this._funcButtonCollection = value;
      }
    }

    public ResultSegment ResSegment
    {
      get
      {
        return this._resSegment;
      }
      set
      {
        this._resSegment = value;
      }
    }

    public bool EnabledControls
    {
      set
      {
        this.panelImage.Enabled = value;
        this.tbbSetResult.Enabled = value;
      }
    }

    public ResultType ResType
    {
      get
      {
        return this._resType;
      }
      set
      {
        this._resType = value;
      }
    }

    public bool IsDiskrete
    {
      set
      {
        this._isDiskrete = value;
      }
    }

    public event FuncButton.FuncButtonEvent RunTest;

    public event Point.CreatePointBySegmentHandler CreatePointBySegment;

    public event Segment.CreateSegmentBy2PointsHandler CreateSegmentBy2Points;

    public event ResultSegment.ResultSegmentEvent SetResultSegment;

    public event BaseGraphControl.ResultPointHandler SetResultPoint;

    public event EventHandler OnShowTask;

    static BaseGraphControl()
    {
    }

    public BaseGraphControl()
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
      ResourceManager resourceManager = new ResourceManager(typeof (BaseGraphControl));
      this.panelGraph = new Panel();
      this.panelImage = new pnlgrph();
      this.splitter1 = new Splitter();
      this.toolBarGraph = new ToolBar();
      this.tbbSeparator1 = new ToolBarButton();
      this.tbbScaleM = new ToolBarButton();
      this.tbbScaleP = new ToolBarButton();
      this.tbbSeparator2 = new ToolBarButton();
      this.tbbZeroPM = new ToolBarButton();
      this.tbbZeroPP = new ToolBarButton();
      this.tbbSeparator3 = new ToolBarButton();
      this.tbbSetResult = new ToolBarButton();
      this.tbbSeparator4 = new ToolBarButton();
      this.tbbShowTask = new ToolBarButton();
      this.tbbSeparator5 = new ToolBarButton();
      this.tbbExit = new ToolBarButton();
      this.imageList = new ImageList(this.components);
      this.tbbScaleA = new ToolBarButton();
      this.panelGraph.SuspendLayout();
      this.SuspendLayout();
      this.panelGraph.BackColor = SystemColors.Control;
      this.panelGraph.Controls.Add((Control) this.panelImage);
      this.panelGraph.Controls.Add((Control) this.splitter1);
      this.panelGraph.Controls.Add((Control) this.toolBarGraph);
      this.panelGraph.Dock = DockStyle.Fill;
      this.panelGraph.Location = new System.Drawing.Point(0, 0);
      this.panelGraph.Name = "panelGraph";
      this.panelGraph.Size = new Size(728, 488);
      this.panelGraph.TabIndex = 0;
      this.panelImage.BackColor = Color.White;
      this.panelImage.Dock = DockStyle.Fill;
      this.panelImage.Location = new System.Drawing.Point(0, 27);
      this.panelImage.Name = "panelImage";
      this.panelImage.Size = new Size(728, 461);
      this.panelImage.TabIndex = 3;
      this.panelImage.Resize += new EventHandler(this.panelImage_Resize);
      this.panelImage.MouseUp += new MouseEventHandler(this.panelImage_MouseUp);
      this.panelImage.Paint += new PaintEventHandler(this.panelImage_Paint);
      this.panelImage.MouseMove += new MouseEventHandler(this.panelImage_MouseMove);
      this.panelImage.MouseDown += new MouseEventHandler(this.panelImage_MouseDown);
      this.splitter1.BackColor = Color.Black;
      this.splitter1.Cursor = Cursors.Default;
      this.splitter1.Dock = DockStyle.Top;
      this.splitter1.Location = new System.Drawing.Point(0, 26);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new Size(728, 1);
      this.splitter1.TabIndex = 4;
      this.splitter1.TabStop = false;
      this.toolBarGraph.Appearance = ToolBarAppearance.Flat;
      this.toolBarGraph.Buttons.AddRange(new ToolBarButton[13]
      {
        this.tbbSeparator1,
        this.tbbScaleM,
        this.tbbScaleA,
        this.tbbScaleP,
        this.tbbSeparator2,
        this.tbbZeroPM,
        this.tbbZeroPP,
        this.tbbSeparator3,
        this.tbbSetResult,
        this.tbbSeparator4,
        this.tbbShowTask,
        this.tbbSeparator5,
        this.tbbExit
      });
      this.toolBarGraph.Divider = false;
      this.toolBarGraph.DropDownArrows = true;
      this.toolBarGraph.ImageList = this.imageList;
      this.toolBarGraph.Location = new System.Drawing.Point(0, 0);
      this.toolBarGraph.Name = "toolBarGraph";
      this.toolBarGraph.ShowToolTips = true;
      this.toolBarGraph.Size = new Size(728, 26);
      this.toolBarGraph.TabIndex = 2;
      this.toolBarGraph.TextAlign = ToolBarTextAlign.Right;
      this.toolBarGraph.ButtonClick += new ToolBarButtonClickEventHandler(this.toolBarGraph_ButtonClick);
      this.tbbSeparator1.Style = ToolBarButtonStyle.Separator;
      this.tbbSeparator1.Visible = false;
      this.tbbScaleM.ImageIndex = 3;
      this.tbbScaleP.ImageIndex = 2;
      this.tbbSeparator2.Style = ToolBarButtonStyle.Separator;
      this.tbbZeroPM.ImageIndex = 0;
      this.tbbZeroPP.ImageIndex = 1;
      this.tbbSeparator3.Style = ToolBarButtonStyle.Separator;
      this.tbbSetResult.ImageIndex = 5;
      this.tbbSetResult.Text = "Результат";
      this.tbbSeparator4.Style = ToolBarButtonStyle.Separator;
      this.tbbShowTask.ImageIndex = 4;
      this.tbbShowTask.Text = "Задание";
      this.tbbSeparator5.Style = ToolBarButtonStyle.Separator;
      this.tbbExit.ImageIndex = 6;
      this.tbbExit.Text = "Закончить";
      this.imageList.ImageSize = new Size(16, 16);
      this.imageList.ImageStream = (ImageListStreamer) resourceManager.GetObject("imageList.ImageStream");
      this.imageList.TransparentColor = Color.Transparent;
      this.tbbScaleA.ImageIndex = 7;
      this.Controls.Add((Control) this.panelGraph);
      this.Name = "BaseGraphControl";
      this.Size = new Size(728, 488);
      this.Load += new EventHandler(this.BaseGraphControl_Load);
      this.panelGraph.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void panelImage_Paint(object sender, PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      graphics.Clear(Color.White);
      this._axis.Draw(graphics, BaseGraphControl.scale, BaseGraphControl.zeroX, BaseGraphControl.zeroY);
      if (this._funcButtonCollection != null)
        this._funcButtonCollection.Draw(graphics, BaseGraphControl.scale, BaseGraphControl.zeroX, BaseGraphControl.zeroY);
      if (this._pointCollection != null)
        this._pointCollection.Draw(graphics, BaseGraphControl.scale, BaseGraphControl.zeroX, BaseGraphControl.zeroY);
      if (this._segmentCollection != null)
        this._segmentCollection.Draw(graphics, BaseGraphControl.scale, BaseGraphControl.zeroX, BaseGraphControl.zeroY);
      if (this._drawingSegment != null && this._drawingSegment.DrawObject != null)
        this._drawingSegment.DrawObject.Draw(graphics, BaseGraphControl.scale, BaseGraphControl.zeroX, BaseGraphControl.zeroY);
      if (this._resSegment == null)
        return;
      this._resSegment.DrawObject.Draw(graphics, BaseGraphControl.scale, BaseGraphControl.zeroX, BaseGraphControl.zeroY);
    }

    private void panelImage_Resize(object sender, EventArgs e)
    {
      BaseGraphControl.zeroY = (float) (this.panelImage.Height / 2);
      this._axis.ScreenWidth = (float) this.panelImage.Width;
      this._axis.ScreenHeight = (float) this.panelImage.Height;
      this.panelImage.Invalidate();
    }

    private void panelImage_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        this._mouseDownPoint = new System.Drawing.Point(e.X, e.Y);
        this._startDrawingPointX = (float) e.X;
        Element element1 = (Element) null;
        Element element2 = (this._segmentCollection.GetClicked(e.X, e.Y) ?? this._pointCollection.GetClicked(e.X, e.Y)) ?? this._funcButtonCollection.GetClicked(e.X, e.Y);
        if (element2 != null && element2.GetType() == typeof (Segment))
        {
          this._curElement = element2;
          this._curElement.DrawObject.IsMoving = true;
          this._deltaLX = (float) e.X - this._curElement.DrawObject.ScreenCoordX;
          this._state = BaseGraphControl.ImageState.movingSegment;
        }
        else if (element2 != null && element2.GetType() == typeof (FuncButton))
        {
          if (this.RunTest != null)
            this.RunTest((FuncButton) element2);
        }
        else
        {
          Element element3;
          if ((BasePoint) (element3 = (Element) this.GetAxisPoint((float) e.X)) != null && this._state != BaseGraphControl.ImageState.setResult)
          {
            this._drawingSegment = this.CreateTempSegment(4.94065645841247E-324);
            this._drawingSegment.StartX = ((double) element3.DrawObject.ScreenCoordX - (double) BaseGraphControl.zeroX) / (double) BaseGraphControl.scale;
            this._drawingSegment.StartY = (double) -e.Y + (double) BaseGraphControl.zeroY;
            this._curElement = (Element) null;
            this._state = BaseGraphControl.ImageState.createSegment;
          }
          else if (this._state == BaseGraphControl.ImageState.setResult)
          {
            Element element4 = (Element) this.GetAxisPoint((float) e.X);
            if (element4 != null)
            {
              if (this._resType == ResultType.segment)
              {
                this._curElement = element4;
                this._resSegment = new ResultSegment(((BasePoint) element4).CoordX);
              }
              else if (this._resType == ResultType.point)
              {
                this.SetResultP(((BasePoint) element4).CoordX);
                this._state = BaseGraphControl.ImageState.other;
              }
            }
            else
              this._state = BaseGraphControl.ImageState.other;
          }
        }
        this.panelImage.Invalidate();
        element1 = (Element) null;
      }
      else if (e.Button == MouseButtons.Right)
        ;
    }

    private void panelImage_MouseMove(object sender, MouseEventArgs e)
    {
      if (this._mouseDownPoint.IsEmpty)
        return;
      if (this._state == BaseGraphControl.ImageState.movingSegment)
      {
        if (this._isFlipped)
        {
          if ((double) Math.Abs((float) e.X - this._startFlipX) > 2.0 * BaseGraphControl._CoordPrecision)
          {
            this._isFlipped = false;
            this._curElement.DrawObject.Move((int) ((double) e.X - (double) this._startFlipX - (double) Math.Sign((float) e.X - this._startFlipX) * BaseGraphControl._CoordPrecision), 0, BaseGraphControl.scale);
          }
          else
            this.SegmentMove((Segment) this._curElement, 0.0, (double) (e.Y - this._mouseDownPoint.Y));
        }
        else
        {
          Segment s = (Segment) this._curElement;
          int num1 = (int) ((s.StartX + s.Length) * (double) BaseGraphControl.scale + (double) BaseGraphControl.zeroX);
          int num2 = (int) (s.StartX * (double) BaseGraphControl.scale + (double) BaseGraphControl.zeroX);
          BasePoint axisPoint1 = this.GetAxisPoint((float) num1);
          BasePoint axisPoint2 = this.GetAxisPoint((float) num2);
          if (axisPoint1 != null)
          {
            this._isFlipped = true;
            this._startFlipX = (float) this._mouseDownPoint.X;
            this.SegmentMove(s, axisPoint1.CoordX - s.Length - s.StartX, (double) (e.Y - this._mouseDownPoint.Y));
          }
          else if (axisPoint2 != null)
          {
            this._isFlipped = true;
            this._startFlipX = (float) this._mouseDownPoint.X;
            this.SegmentMove(s, axisPoint2.CoordX - s.StartX, (double) (e.Y - this._mouseDownPoint.Y));
          }
          else
            this.SegmentMove(s, ((double) e.X - (double) this._deltaLX - (double) BaseGraphControl.zeroX) / (double) BaseGraphControl.scale - s.StartX, (double) (e.Y - this._mouseDownPoint.Y));
        }
      }
      else if (this._state == BaseGraphControl.ImageState.createSegment)
      {
        if (this._isFlipped)
        {
          if ((double) Math.Abs((float) e.X - this._startFlipX) > 2.0 * BaseGraphControl._CoordPrecision)
          {
            this._isFlipped = false;
            this.SegmentSetLength(this._drawingSegment, this._drawingSegment.Length + ((double) e.X - (double) this._startFlipX - (double) Math.Sign((float) e.X - this._startFlipX) * BaseGraphControl._CoordPrecision) / (double) BaseGraphControl.scale);
          }
        }
        else
        {
          BasePoint axisPoint1 = this.GetAxisPoint((float) (this._drawingSegment.StartX + this._drawingSegment.Length) * BaseGraphControl.scale + BaseGraphControl.zeroX);
          if (axisPoint1 != null && axisPoint1.CoordX != this._drawingSegment.StartX)
          {
            this._isFlipped = true;
            BasePoint axisPoint2 = this.GetAxisPoint((float) this._drawingSegment.StartX * BaseGraphControl.scale + BaseGraphControl.zeroX);
            this.SegmentSetLength(this._drawingSegment, axisPoint1.CoordX - axisPoint2.CoordX);
            this._startFlipX = (float) e.X;
          }
          else
            this.SegmentSetLength(this._drawingSegment, ((double) e.X - (double) this._startDrawingPointX) / (double) BaseGraphControl.scale);
        }
      }
      else if (this._state == BaseGraphControl.ImageState.setResult && this._resSegment != null)
        this.ResultSegmentMove((double) (e.X - this._mouseDownPoint.X));
      this._mouseDownPoint.X = e.X;
      this._mouseDownPoint.Y = e.Y;
    }

    private void panelImage_MouseUp(object sender, MouseEventArgs e)
    {
      this._mouseDownPoint = System.Drawing.Point.Empty;
      if (this._state == BaseGraphControl.ImageState.movingSegment)
      {
        this._curElement.DrawObject.IsMoving = false;
        BasePoint axisPoint1 = this.GetAxisPoint(this._curElement.DrawObject.ScreenCoordX);
        BasePoint axisPoint2 = this.GetAxisPoint(((DrawSegment) this._curElement.DrawObject).ScreenCoordX1);
        if (axisPoint1 != null)
        {
          if (this.GetAxisPoint(((DrawSegment) this._curElement.DrawObject).ScreenCoordX1) == null && this.CreatePointBySegment != null && !this._isDiskrete)
            this.CreatePointBySegment(axisPoint1, (Segment) this._curElement, Direction.right);
        }
        else if (axisPoint2 != null && this.GetAxisPoint(this._curElement.DrawObject.ScreenCoordX) == null && (this.CreatePointBySegment != null && !this._isDiskrete))
          this.CreatePointBySegment(axisPoint2, (Segment) this._curElement, Direction.left);
        this._curElement = (Element) null;
      }
      else if (this._state == BaseGraphControl.ImageState.createSegment)
      {
        BasePoint axisPoint1 = this.GetAxisPoint(((DrawSegment) this._drawingSegment.DrawObject).ScreenCoordX1);
        if (axisPoint1 != null && !this.IsEqual(axisPoint1.CoordX, this._drawingSegment.StartX) && !this.IsEqual((double) ((DrawSegment) this._drawingSegment.DrawObject).ScreenCoordX1, (double) this._drawingSegment.DrawObject.ScreenCoordX))
        {
          BasePoint axisPoint2 = this.GetAxisPoint(this._drawingSegment.DrawObject.ScreenCoordX);
          if (this._drawingSegment.Length < 0.0)
          {
            this._drawingSegment.Length = this._drawingSegment.StartX - axisPoint1.CoordX;
            this._drawingSegment.StartX = axisPoint1.CoordX;
            if (this.CreateSegmentBy2Points != null)
              this.CreateSegmentBy2Points(axisPoint1, axisPoint2, axisPoint1.CoordX, this._drawingSegment.StartY);
          }
          else if (this.CreateSegmentBy2Points != null)
            this.CreateSegmentBy2Points(axisPoint2, axisPoint1, axisPoint2.CoordX, this._drawingSegment.StartY);
        }
        this._drawingSegment = (Segment) null;
      }
      else if (this._state == BaseGraphControl.ImageState.setResult)
      {
        if (this._resSegment != null)
        {
          BasePoint axisPoint = this.GetAxisPoint((float) e.X);
          if (axisPoint != null)
          {
            if (axisPoint.CoordX != this._resSegment.StartX)
              this.SetResult(axisPoint.CoordX);
            else
              this._resSegment = (ResultSegment) null;
          }
          else
            this._resSegment = (ResultSegment) null;
        }
        this._state = BaseGraphControl.ImageState.other;
      }
      Element clicked1 = this._pointCollection.GetClicked(e.X, e.Y);
      if (clicked1 == null)
      {
        Element clicked2 = this._segmentCollection.GetClicked(e.X, e.Y);
        if (clicked2 != null)
          this.SelectSegment((Segment) clicked2, false, true);
      }
      else
        this.SelectPoint((BasePoint) clicked1, false, true);
      this._startFlipX = 0.0f;
      this._isFlipped = false;
      this._startDrawingPointX = 0.0f;
      this._state = BaseGraphControl.ImageState.other;
      this.panelImage.Invalidate();
    }

    private void toolBarGraph_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
    {
      if (e.Button == this.tbbScaleP)
      {
        if ((double) BaseGraphControl.scale < (double) BaseGraphControl._MaxScale)
        {
          ++BaseGraphControl.scale;
          BaseGraphControl.zeroX += (BaseGraphControl.zeroX - (float) BaseGraphControl._AxisXZeroPad) / BaseGraphControl.scale;
        }
      }
      else if (e.Button == this.tbbScaleM)
      {
        if ((double) BaseGraphControl.scale > (double) BaseGraphControl._MinScale)
        {
          --BaseGraphControl.scale;
          BaseGraphControl.zeroX -= (BaseGraphControl.zeroX - (float) BaseGraphControl._AxisXZeroPad) / BaseGraphControl.scale;
        }
      }
      else if (e.Button == this.tbbScaleA)
      {
        double num1 = double.MaxValue;
        double num2 = double.MinValue;
        foreach (BasePoint basePoint in (CollectionBase) this._pointCollection)
        {
          if (basePoint.CoordX < num1)
            num1 = basePoint.CoordX;
          if (basePoint.CoordX > num2)
            num2 = basePoint.CoordX;
        }
        if (num2 != num1 && this._pointCollection.Count >= 2)
        {
          BaseGraphControl.scale = (float) (this.panelImage.Width - 4 * BaseGraphControl._AxisXZeroPad) / (float) (num2 - num1);
          BaseGraphControl.zeroX = (float) (2 * BaseGraphControl._AxisXZeroPad) - BaseGraphControl.scale * (float) num1;
        }
      }
      else if (e.Button == this.tbbZeroPP)
        BaseGraphControl.zeroX -= 10f;
      else if (e.Button == this.tbbZeroPM)
        BaseGraphControl.zeroX += 10f;
      else if (e.Button == this.tbbSetResult)
      {
        int num = (int) MessageBox.Show("Укажите результат", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        this._state = BaseGraphControl.ImageState.setResult;
      }
      else if (e.Button == this.tbbShowTask)
      {
        if (this.OnShowTask != null)
          this.OnShowTask((object) this, (EventArgs) null);
      }
      else if (e.Button == this.tbbExit && MessageBox.Show("Решение текущей задачи будет закончено. Вы уверены?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        ((Form) this.Parent.Parent.Parent).Close();
      this.panelImage.Invalidate();
    }

    private bool IsEqual(double d1, double d2)
    {
      return Math.Abs(d1 - d2) < Constants.DoublePrecision;
    }

    private void UnselectAll()
    {
      this._pointCollection.UnSelectAll();
      this._segmentCollection.UnSelectAll();
    }

    private void SelectPoint(BasePoint p, bool needRepaint, bool resetSelection)
    {
      if (p == null)
        return;
      if (resetSelection)
        this._pointCollection.UnSelectAll();
      p.DrawObject.IsSelected = true;
      if (!needRepaint)
        return;
      this.panelImage.Invalidate();
    }

    private BasePoint GetAxisPoint(float ScreenX)
    {
      foreach (BasePoint basePoint in (CollectionBase) this._pointCollection)
      {
        if ((double) Math.Abs(basePoint.DrawObject.ScreenCoordX - ScreenX) <= BaseGraphControl._CoordPrecision)
          return basePoint;
      }
      return (BasePoint) null;
    }

    public void SelectPoints(PointCollection pCol)
    {
      this._pointCollection.UnSelectAll();
      foreach (Element element in (CollectionBase) pCol)
        element.DrawObject.IsSelected = true;
      this.panelImage.Invalidate();
    }

    private void BaseGraphControl_Load(object sender, EventArgs e)
    {
    }

    public void SelectSegments(SegmentCollection sCol)
    {
      this._segmentCollection.UnSelectAll();
      foreach (Element element in (CollectionBase) sCol)
        element.DrawObject.IsSelected = true;
      this.panelImage.Invalidate();
    }

    private Segment CreateTempSegment(double length)
    {
      return new Segment("", length);
    }

    private void SegmentSetLength(Segment s, double length)
    {
      s.Length = length;
      this.panelImage.Invalidate();
    }

    private void SegmentMove(Segment s, double deltaX, double deltaY)
    {
      s.StartX += deltaX;
      s.StartY -= deltaY;
      this.panelImage.Invalidate();
    }

    private void SelectSegment(Segment s, bool needRepaint, bool resetSelection)
    {
      if (s == null)
        return;
      if (resetSelection)
        this._segmentCollection.UnSelectAll();
      s.DrawObject.IsSelected = true;
      if (!needRepaint)
        return;
      this.panelImage.Invalidate();
    }

    private void ResultSegmentMove(double dx)
    {
      this._resSegment.DrawObject.Move((int) dx, 0, BaseGraphControl.scale);
      this.panelImage.Invalidate();
    }

    private void SetResult(double ex)
    {
      this._resSegment.EndX = ex;
      if (this._resSegment.EndX < this._resSegment.StartX)
      {
        double startX = this._resSegment.StartX;
        this._resSegment.StartX = this._resSegment.EndX;
        this._resSegment.EndX = startX;
      }
      if (this.SetResultSegment == null)
        return;
      this.SetResultSegment(this._resSegment);
    }

    private void SetResultP(double point)
    {
      if (this.SetResultPoint == null)
        return;
      this.SetResultPoint(point);
    }

    public void CustomInvalidate()
    {
      this.panelImage.Invalidate();
    }

    private enum ImageState
    {
      movingSegment,
      createSegment,
      setResult,
      other,
    }

    public delegate void ResultPointHandler(double coord);
  }
}
