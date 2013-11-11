// Type: Mephi.K22.LearningSuite.OneDSearch.OneDControl
// Assembly: Mephi.K22.LearningSuite.OneDSearch, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A759670E-215D-48E9-9EE9-703E6D1ED21B
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.OneDSearch.Base;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.OneDSearch
{
  public class OneDControl : BaseMethodControl
  {
    private bool _readOnly = false;
    private IContainer components = (IContainer) null;
    private SegmentCollection _segmentCollection = (SegmentCollection) null;
    private PointCollection _pointCollection = (PointCollection) null;
    private ActionCollection _actionCollection = (ActionCollection) null;
    private FuncButtonCollection _funcButtonCollection = (FuncButtonCollection) null;
    private Task _task = (Task) null;
    private readonly double _SegmentDistance = 10.0;
    private bool _isDiskrete = false;
    private Panel panelLog;
    private Splitter splitterBottom;
    private Panel panelRight;
    private Panel panelPoints;
    private Splitter splitterMiddleHor;
    private Panel panelSegments;
    private Splitter splitterVert;
    private Panel panelGraph;
    private BaseGraphControl graphControl;
    private ImageList imageList;
    private PointViewer pointViewer;
    private SegmentViewer segmentViewer;
    internal ActionViewer actionViewer;
    private BaseSearch _scanSearch;

    public PointCollection Points
    {
      set
      {
        this._pointCollection = value;
      }
    }

    public SegmentCollection Segments
    {
      set
      {
        this._segmentCollection = value;
      }
    }

    public ActionCollection Actions
    {
      get
      {
        return this._actionCollection;
      }
      set
      {
        this._actionCollection = value;
      }
    }

    public FuncButtonCollection FuncButtons
    {
      set
      {
        this._funcButtonCollection = value;
      }
    }

    internal Task Task
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

    public bool ReadOnly
    {
      get
      {
        return this._readOnly;
      }
      set
      {
        this.graphControl.EnabledControls = !value;
        this.pointViewer.EnabledControls = !value;
        this.segmentViewer.EnabledControls = !value;
        this._readOnly = value;
      }
    }

    internal ResultSegment ResultSegment
    {
      set
      {
        this.graphControl.ResSegment = value;
      }
    }

    internal ResultType ResType
    {
      get
      {
        return this.graphControl.ResType;
      }
      set
      {
        this.graphControl.ResType = value;
      }
    }

    public bool IsDiskrete
    {
      set
      {
        this._isDiskrete = value;
        this.segmentViewer.IsDiskrete = this._isDiskrete;
        this.graphControl.IsDiskrete = this._isDiskrete;
        this.pointViewer.IsDiskrete = this._isDiskrete;
      }
    }

    public OneDControl(BaseSearch scanSearch)
    {
      this.InitializeComponent();
      this._scanSearch = scanSearch;
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
      ResourceManager resourceManager = new ResourceManager(typeof (OneDControl));
      this.imageList = new ImageList(this.components);
      this.graphControl = new BaseGraphControl();
      this.pointViewer = new PointViewer();
      this.segmentViewer = new SegmentViewer();
      this.panelLog = new Panel();
      this.actionViewer = new ActionViewer();
      this.splitterBottom = new Splitter();
      this.panelRight = new Panel();
      this.panelPoints = new Panel();
      this.splitterMiddleHor = new Splitter();
      this.panelSegments = new Panel();
      this.splitterVert = new Splitter();
      this.panelGraph = new Panel();
      this.panelLog.SuspendLayout();
      this.panelRight.SuspendLayout();
      this.panelPoints.SuspendLayout();
      this.panelSegments.SuspendLayout();
      this.panelGraph.SuspendLayout();
      this.SuspendLayout();
      this.imageList.ImageSize = new Size(16, 16);
      this.imageList.ImageStream = (ImageListStreamer) resourceManager.GetObject("imageList.ImageStream");
      this.imageList.TransparentColor = Color.Transparent;
      this.graphControl.Dock = DockStyle.Fill;
      this.graphControl.Location = new System.Drawing.Point(0, 0);
      this.graphControl.Name = "graphControl";
      this.graphControl.ResSegment = (ResultSegment) null;
      this.graphControl.Size = new Size(521, 377);
      this.graphControl.TabIndex = 0;
      this.pointViewer.Dock = DockStyle.Fill;
      this.pointViewer.Location = new System.Drawing.Point(0, 0);
      this.pointViewer.Name = "pointViewer";
      this.pointViewer.Size = new Size(230, 188);
      this.pointViewer.TabIndex = 0;
      this.segmentViewer.Dock = DockStyle.Fill;
      this.segmentViewer.Location = new System.Drawing.Point(0, 0);
      this.segmentViewer.Name = "segmentViewer";
      this.segmentViewer.Size = new Size(230, 182);
      this.segmentViewer.TabIndex = 0;
      this.panelLog.BorderStyle = BorderStyle.FixedSingle;
      this.panelLog.Controls.Add((Control) this.actionViewer);
      this.panelLog.Dock = DockStyle.Bottom;
      this.panelLog.Location = new System.Drawing.Point(0, 384);
      this.panelLog.Name = "panelLog";
      this.panelLog.Size = new Size(760, 96);
      this.panelLog.TabIndex = 4;
      this.actionViewer.Dock = DockStyle.Fill;
      this.actionViewer.Location = new System.Drawing.Point(0, 0);
      this.actionViewer.Name = "actionViewer";
      this.actionViewer.Size = new Size(758, 94);
      this.actionViewer.TabIndex = 0;
      this.splitterBottom.Dock = DockStyle.Bottom;
      this.splitterBottom.Location = new System.Drawing.Point(0, 379);
      this.splitterBottom.Name = "splitterBottom";
      this.splitterBottom.Size = new Size(760, 5);
      this.splitterBottom.TabIndex = 3;
      this.splitterBottom.TabStop = false;
      this.panelRight.Controls.Add((Control) this.panelPoints);
      this.panelRight.Controls.Add((Control) this.splitterMiddleHor);
      this.panelRight.Controls.Add((Control) this.panelSegments);
      this.panelRight.Dock = DockStyle.Right;
      this.panelRight.Location = new System.Drawing.Point(528, 0);
      this.panelRight.Name = "panelRight";
      this.panelRight.Size = new Size(232, 379);
      this.panelRight.TabIndex = 2;
      this.panelPoints.BorderStyle = BorderStyle.FixedSingle;
      this.panelPoints.Controls.Add((Control) this.pointViewer);
      this.panelPoints.Dock = DockStyle.Fill;
      this.panelPoints.Location = new System.Drawing.Point(0, 0);
      this.panelPoints.Name = "panelPoints";
      this.panelPoints.Size = new Size(232, 190);
      this.panelPoints.TabIndex = 0;
      this.splitterMiddleHor.Dock = DockStyle.Bottom;
      this.splitterMiddleHor.Location = new System.Drawing.Point(0, 190);
      this.splitterMiddleHor.Name = "splitterMiddleHor";
      this.splitterMiddleHor.Size = new Size(232, 5);
      this.splitterMiddleHor.TabIndex = 1;
      this.splitterMiddleHor.TabStop = false;
      this.panelSegments.BorderStyle = BorderStyle.FixedSingle;
      this.panelSegments.Controls.Add((Control) this.segmentViewer);
      this.panelSegments.Dock = DockStyle.Bottom;
      this.panelSegments.Location = new System.Drawing.Point(0, 195);
      this.panelSegments.Name = "panelSegments";
      this.panelSegments.Size = new Size(232, 184);
      this.panelSegments.TabIndex = 2;
      this.splitterVert.Dock = DockStyle.Right;
      this.splitterVert.Location = new System.Drawing.Point(523, 0);
      this.splitterVert.Name = "splitterVert";
      this.splitterVert.Size = new Size(5, 379);
      this.splitterVert.TabIndex = 1;
      this.splitterVert.TabStop = false;
      this.panelGraph.BorderStyle = BorderStyle.FixedSingle;
      this.panelGraph.Controls.Add((Control) this.graphControl);
      this.panelGraph.Dock = DockStyle.Fill;
      this.panelGraph.Location = new System.Drawing.Point(0, 0);
      this.panelGraph.Name = "panelGraph";
      this.panelGraph.Size = new Size(523, 379);
      this.panelGraph.TabIndex = 0;
      this.Controls.Add((Control) this.panelGraph);
      this.Controls.Add((Control) this.splitterVert);
      this.Controls.Add((Control) this.panelRight);
      this.Controls.Add((Control) this.splitterBottom);
      this.Controls.Add((Control) this.panelLog);
      this.Name = "OneDControl";
      this.Size = new Size(760, 480);
      this.Load += new EventHandler(this.ScanControl_Load);
      this.panelLog.ResumeLayout(false);
      this.panelRight.ResumeLayout(false);
      this.panelPoints.ResumeLayout(false);
      this.panelSegments.ResumeLayout(false);
      this.panelGraph.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void ScanControl_Load(object sender, EventArgs e)
    {
      this.pointViewer.CreatePointByCoord += new Mephi.K22.LearningSuite.OneDSearch.Base.Point.CreatePointByCoordHandler(this.CreatePointByCoord);
      this.pointViewer.CreatePointByDiv2Points += new Mephi.K22.LearningSuite.OneDSearch.Base.Point.Point2PointsEvent(this.CreatePointByDiv2Points);
      this.pointViewer.DeletePoints += new Mephi.K22.LearningSuite.OneDSearch.Base.Point.PointCollectionEvent(this.DeletePoints);
      this.pointViewer.RunTests += new Mephi.K22.LearningSuite.OneDSearch.Base.Point.PointCollectionEvent(this.RunTests);
      this.pointViewer.SelectPoints += new Mephi.K22.LearningSuite.OneDSearch.Base.Point.PointCollectionEvent(this.SelectPoints);
      this.graphControl.RunTest += new FuncButton.FuncButtonEvent(this.RunTest);
      this.graphControl.CreatePointBySegment += new Mephi.K22.LearningSuite.OneDSearch.Base.Point.CreatePointBySegmentHandler(this.CreatePointBySegment);
      this.graphControl.PointCollection = this._pointCollection;
      this.graphControl.FuncButtonCollection = this._funcButtonCollection;
      this.pointViewer.SetDataBinding(this._pointCollection);
      this._pointCollection.ListChanged += new ListChangedEventHandler(this.ListChanged);
      this.segmentViewer.CreateSegmentByLength += new Segment.CreateSegmentByLengthHandler(this.CreateSegmentByLength);
      this.segmentViewer.DeleteSegments += new Segment.SegmentCollectionEvent(this.DeleteSegments);
      this.segmentViewer.CreateSegmentByDiv2Segment += new Segment.SegmentEvent(this.CreateSegmentByDiv2Segment);
      this.segmentViewer.CreateSegmentByGoldSegment += new Segment.SegmentEvent(this.CreateSegmentByGoldSegment);
      this.segmentViewer.SelectSegments += new Segment.SegmentCollectionEvent(this.SelectSegments);
      this.segmentViewer.CreateSegmentByFib += new Segment.CreateSegmentByFibHandler(this.CreateSegmentByFib);
      this.segmentViewer.CreateConnectedSegment += new EventHandler(this.segmentViewer_CreateConnectedSegment);
      this.pointViewer.CreateFictDiskrete += new EventHandler(this.pointViewer_CreateFictDiskrete);
      this.graphControl.CreateSegmentBy2Points += new Segment.CreateSegmentBy2PointsHandler(this.CreateSegmentBy2Points);
      this.graphControl.SetResultSegment += new ResultSegment.ResultSegmentEvent(this.SetResult);
      this.graphControl.SetResultPoint += new BaseGraphControl.ResultPointHandler(this.SetResultPoint);
      this.pointViewer.CreatePaul += new Mephi.K22.LearningSuite.OneDSearch.Base.Point.PointCollectionEvent(this.CreatePaul);
      this.graphControl.SegmentCollection = this._segmentCollection;
      this.segmentViewer.SetDataBinding(this._segmentCollection);
      this._segmentCollection.ListChanged += new ListChangedEventHandler(this.ListChanged);
      this.graphControl.OnShowTask += new EventHandler(this.graphControl_OnShowTask);
      this.actionViewer.OnUndoAll += new ActionViewer.ActionEventHandler(this.OnUndoAll);
      this.actionViewer.OnUndo += new ActionViewer.ActionEventHandler(this.OnUndo);
      this.actionViewer.OnRedo += new ActionViewer.ActionEventHandler(this.OnRedo);
      this.actionViewer.OnRedoAll += new ActionViewer.ActionEventHandler(this.OnRedoAll);
      this.ParentForm.Closing += new CancelEventHandler(this.ParentForm_Closing);
      this.actionViewer.SetDataBinding(this._actionCollection);
    }

    public void CreatePointBySegment(BasePoint p, Segment s, Direction d)
    {
      double num = d != Direction.left ? p.CoordX + s.Length : p.CoordX - s.Length;
      string str = string.Format("X{0}", (object) BasePoint.PointCounter);
      Action act = new Action();
      act.ActionType = (byte) 2;
      act.Parameters = new object[8]
      {
        (object) num,
        (object) str,
        (object) p.CoordX,
        (object) p.Name,
        (object) s.Length,
        (object) s.Name,
        (object) d,
        d == Direction.left ? (object) "влево" : (object) "вправо"
      };
      act.Message = string.Format("Создана точка {0} = {1} (откладыванием отрезка {2} ({3}) от точки {4} ({5}) {6})", act.Parameters[1], (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), act.Parameters[5], (object) ((double) act.Parameters[4]).ToString(Constants.DefaultDoubleFormat), act.Parameters[3], (object) ((double) act.Parameters[2]).ToString(Constants.DefaultDoubleFormat), act.Parameters[7]);
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    public void CreatePointByCoord(double coord)
    {
      if ((Mephi.K22.LearningSuite.OneDSearch.Base.Point) this._pointCollection.GetPoint(coord) != null)
        return;
      Action act = new Action();
      act.ActionType = (byte) 0;
      act.Parameters = new object[2]
      {
        (object) coord,
        (object) string.Format("X{0}", (object) BasePoint.PointCounter)
      };
      act.Message = string.Format("Создана точка {1} = {0}", (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), act.Parameters[1]);
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    private void CreatePaul(PointCollection pCol)
    {
      Action act = new Action();
      act.ActionType = (byte) 12;
      string str = string.Format("X{0}", (object) BasePoint.PointCounter);
      double num = Paul.FuncPaul(pCol[0].CoordX, pCol[1].CoordX, pCol[2].CoordX, pCol[0].FuncButton.FuncValue, pCol[1].FuncButton.FuncValue, pCol[2].FuncButton.FuncValue);
      act.Parameters = new object[5]
      {
        (object) num,
        (object) str,
        (object) pCol[0].CoordX,
        (object) pCol[1].CoordX,
        (object) pCol[2].CoordX
      };
      act.Message = string.Format("Создана точка {0}={1} по методу Пауэлла для точек {2}, {3} и {4}", (object) str, (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), (object) ((double) act.Parameters[2]).ToString(Constants.DefaultDoubleFormat), (object) ((double) act.Parameters[3]).ToString(Constants.DefaultDoubleFormat), (object) ((double) act.Parameters[4]).ToString(Constants.DefaultDoubleFormat));
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    public void CreatePointByDiv2Points(BasePoint p1, BasePoint p2)
    {
      double num = (p1.CoordX + p2.CoordX) / 2.0;
      string str = string.Format("X{0}", (object) BasePoint.PointCounter);
      Action act = new Action();
      act.ActionType = (byte) 1;
      act.Parameters = new object[6]
      {
        (object) num,
        (object) str,
        (object) p1.CoordX,
        (object) p1.Name,
        (object) p2.CoordX,
        (object) p2.Name
      };
      act.Message = string.Format("Создана точка {0} = {1} (по середине между точками {2}, {3})", act.Parameters[1], (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), act.Parameters[3], act.Parameters[5]);
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    internal Mephi.K22.LearningSuite.OneDSearch.Base.Point CreatePoint(double coordX, string name)
    {
      Mephi.K22.LearningSuite.OneDSearch.Base.Point point = new Mephi.K22.LearningSuite.OneDSearch.Base.Point(coordX, name);
      this._pointCollection.Add((BasePoint) point);
      this._funcButtonCollection.Add(new FuncButton((BasePoint) point));
      return point;
    }

    public void DeletePoints(PointCollection pCol)
    {
      foreach (Mephi.K22.LearningSuite.OneDSearch.Base.Point p in (CollectionBase) pCol)
      {
        if (!p.IsPredefined)
          this.DeletePoint(p);
      }
    }

    private void DeletePoint(Mephi.K22.LearningSuite.OneDSearch.Base.Point p)
    {
      if (p.IsPredefined)
        return;
      Action act = new Action();
      act.ActionType = (byte) 6;
      act.Parameters = new object[4]
      {
        (object) p.CoordX,
        (object) p.Name,
        (object) (bool) p.FuncButton.IsEval,
        (object) p.FuncButton.FuncValue
      };
      act.Message = string.Format("Удалена точка {1} ({0})", (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), act.Parameters[1]);
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    internal void DeletePointImpl(double coordX)
    {
      BasePoint point = this._pointCollection.GetPoint(coordX);
      if (point == null)
        return;
      this._pointCollection.Remove(point);
      if (point.FuncButton != null)
      {
        this._funcButtonCollection.Remove(point.FuncButton);
        point.FuncButton.DrawObject = (DrawElement) null;
        point.FuncButton = (FuncButton) null;
      }
      point.DrawObject = (DrawElement) null;
    }

    public void SelectPoints(PointCollection pCol)
    {
      this.graphControl.SelectPoints(pCol);
    }

    public void RunTests(PointCollection pCol)
    {
      foreach (BasePoint basePoint in (CollectionBase) pCol)
      {
        if (!basePoint.FuncButton.IsEval)
          this.RunTest(basePoint.FuncButton);
      }
      this.graphControl.CustomInvalidate();
    }

    private void RunTest(FuncButton fb)
    {
      if (fb.IsEval)
        return;
      if (fb.point is Mephi.K22.LearningSuite.OneDSearch.Base.Point || fb.point is Diskrete && !((Diskrete) fb.point).IsFictive)
      {
        Action act = new Action();
        act.ActionType = (byte) 8;
        act.Parameters = new object[3]
        {
          (object) fb.CoordX,
          (object) this._scanSearch.GetFuncValue(fb.RealCoordX),
          (object) fb.point.Name
        };
        act.Message = string.Format("Проведен эксперимент в точке {0}. F = {1}", (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), (object) ((double) act.Parameters[1]).ToString(Constants.DefaultDoubleFormat));
        this._actionCollection.Add(act);
        this.pointViewer.BeginEdit();
        this._scanSearch.RunAction(act, false);
        this.pointViewer.EndEdit();
      }
      else
      {
        if (!(fb.point is Diskrete) || !((Diskrete) fb.point).IsFictive)
          return;
        FictiveFuncValue fictiveFuncValue = new FictiveFuncValue();
        if (fictiveFuncValue.ShowDialog() != DialogResult.OK)
          return;
        Action act = new Action();
        act.ActionType = (byte) 15;
        int index1;
        int index2 = index1 = -1;
        for (int index3 = 0; index3 < this._funcButtonCollection.Count; ++index3)
        {
          if (fb.CoordX != this._funcButtonCollection[index3].CoordX && this._funcButtonCollection[index3].IsEval)
          {
            if (this._funcButtonCollection[index3].CoordX < fb.CoordX)
            {
              if (index2 == -1)
                index2 = index3;
              if (this._funcButtonCollection[index3].CoordX > this._funcButtonCollection[index2].CoordX)
                index2 = index3;
            }
            if (this._funcButtonCollection[index3].CoordX > fb.CoordX)
            {
              if (index1 == -1)
                index1 = index3;
              if (this._funcButtonCollection[index3].CoordX < this._funcButtonCollection[index1].CoordX)
                index1 = index3;
            }
          }
        }
        act.Parameters = new object[7]
        {
          (object) fb.CoordX,
          (object) fictiveFuncValue.FuncValue,
          (object) fb.point.Name,
          (object) (bool) (index2 != -1),
          (object) (index2 != -1 ? this._funcButtonCollection[index2].FuncValue : 0.0),
          (object) (bool) (index1 != -1),
          (object) (index1 != -1 ? this._funcButtonCollection[index1].FuncValue : 0.0)
        };
        act.Message = string.Format("Проведен эксперимент в фиктивной точке {0}. F = {1}", (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), (object) ((double) act.Parameters[1]).ToString(Constants.DefaultDoubleFormat));
        this._actionCollection.Add(act);
        this.pointViewer.BeginEdit();
        this._scanSearch.RunAction(act, false);
        this.pointViewer.EndEdit();
      }
    }

    internal void RunTestImpl(double coord, double funcValue, string pointName)
    {
      this._funcButtonCollection.GetButton(coord, pointName).SetFuncValue(funcValue);
    }

    private void CreateSegmentByLength(double len)
    {
      Action act = new Action();
      act.ActionType = (byte) 3;
      act.Parameters = new object[3]
      {
        (object) len,
        (object) string.Format("L{0}", (object) Segment.SegmentCount),
        (object) (this._segmentCollection.MinY() - this._SegmentDistance)
      };
      act.Message = string.Format("Создан отрезок {0} длиной {1}", act.Parameters[1], (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat));
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    private void CreateSegmentByFib(Segment s, int num)
    {
      Action act = new Action();
      act.ActionType = (byte) 11;
      double num1 = s.Length * (double) Fibonacci.FibNumber(num - 1) / (double) Fibonacci.FibNumber(num) + (num % 2 == 1 ? -1.0 : 1.0) * ((BaseSeacrhTaskObject) this._task.TaskObject).Epsilon / (double) Fibonacci.FibNumber(num);
      act.Parameters = new object[5]
      {
        (object) num1,
        (object) string.Format("L{0}", (object) Segment.SegmentCount),
        (object) s.Name,
        (object) num,
        (object) (this._segmentCollection.MinY() - this._SegmentDistance)
      };
      act.Message = string.Format("Создан отрезок {0} длиной {1} по методу Фибоначчи по отрезку {2} и N = {3}", act.Parameters[1], (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), act.Parameters[2], act.Parameters[3]);
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    private void CreateSegmentByGoldSegment(Segment s)
    {
      Action act = new Action();
      act.ActionType = (byte) 10;
      act.Parameters = new object[4]
      {
        (object) (s.Length / Constants.GoldNumber),
        (object) string.Format("L{0}", (object) Segment.SegmentCount),
        (object) s.Name,
        (object) (this._segmentCollection.MinY() - this._SegmentDistance)
      };
      act.Message = string.Format("Создан отрезок {0} длиной {1} по методу золотого сечения по отрезку {2}", act.Parameters[1], (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), act.Parameters[2]);
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    private void CreateSegmentByDiv2Segment(Segment s)
    {
      Action act = new Action();
      act.ActionType = (byte) 5;
      act.Parameters = new object[4]
      {
        (object) (s.Length / 2.0),
        (object) string.Format("L{0}", (object) Segment.SegmentCount),
        (object) s.Name,
        (object) (this._segmentCollection.MinY() - this._SegmentDistance)
      };
      act.Message = string.Format("Создан отрезок {0} длиной {1} делением отрезка {2} пополам", act.Parameters[1], (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), act.Parameters[2]);
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    private void CreateSegmentBy2Points(BasePoint p1, BasePoint p2, double x, double y)
    {
      Action act = new Action();
      act.ActionType = (byte) 4;
      act.Parameters = new object[7]
      {
        (object) p1.CoordX,
        (object) p1.Name,
        (object) p2.CoordX,
        (object) p2.Name,
        (object) string.Format("L{0}", (object) Segment.SegmentCount),
        (object) x,
        (object) y
      };
      act.Message = string.Format("Создан отрезок {0} : проведен между точками {1} ({2}) и {3} ({4})", act.Parameters[4], act.Parameters[1], (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), act.Parameters[3], (object) ((double) act.Parameters[2]).ToString(Constants.DefaultDoubleFormat));
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    internal Segment CreateSegment(double len, string name)
    {
      Segment segment = new Segment(name, len);
      this._segmentCollection.Add((Element) segment);
      return segment;
    }

    private void DeleteSegments(SegmentCollection sCol)
    {
      foreach (Segment s in (CollectionBase) sCol)
        this.DeleteSegment(s);
    }

    private void DeleteSegment(Segment s)
    {
      Action act = new Action();
      act.ActionType = (byte) 7;
      act.Parameters = new object[2]
      {
        (object) s.Length,
        (object) s.Name
      };
      act.Message = string.Format("Удален отрезок {1} ({0})", (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), act.Parameters[1]);
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    internal void DeleteSegmentImpl(double len, string name)
    {
      Segment segment = this._segmentCollection.GetSegment(len, name);
      if (segment == null)
        return;
      this._segmentCollection.Remove(segment);
      segment.DrawObject = (DrawElement) null;
    }

    private void SelectSegments(SegmentCollection sCol)
    {
      this.graphControl.SelectSegments(sCol);
    }

    private void SetResult(ResultSegment rs)
    {
      Action act = new Action();
      act.ActionType = (byte) 9;
      ArrayList arrayList = new ArrayList();
      int length1 = 0;
      foreach (FuncButton funcButton in (CollectionBase) this._funcButtonCollection)
      {
        if (funcButton.IsEval)
          ++length1;
      }
      PointValue[] pointValueArray = new PointValue[length1];
      int length2 = 2 + 2 * length1;
      act.Parameters = new object[length2];
      act.Parameters[0] = (object) rs.StartX;
      act.Parameters[1] = (object) rs.EndX;
      int num = 0;
      foreach (FuncButton funcButton in (CollectionBase) this._funcButtonCollection)
      {
        if (funcButton.IsEval)
        {
          act.Parameters[2 + num] = (object) funcButton.CoordX;
          act.Parameters[2 + num + 1] = (object) funcButton.FuncValue;
          num += 2;
        }
      }
      act.Message = string.Format("Задан результат: отрезок  {0}-{1}", (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat), (object) ((double) act.Parameters[1]).ToString(Constants.DefaultDoubleFormat));
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    private void SetResultPoint(double coord)
    {
      Action act = new Action();
      act.ActionType = (byte) 9;
      act.Parameters = new object[2];
      act.Parameters[0] = (object) coord;
      act.Parameters[1] = (object) 0.0;
      act.Message = string.Format("Задан результат: точка  {0}", (object) ((double) act.Parameters[0]).ToString(Constants.DefaultDoubleFormat));
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    public void SetResult(double l, double r)
    {
      if (this.ResType != ResultType.segment)
        return;
      this.graphControl.ResSegment = new ResultSegment(l)
      {
        EndX = r
      };
    }

    private void ListChanged(object sender, ListChangedEventArgs e)
    {
      this.graphControl.CustomInvalidate();
    }

    public void Stop()
    {
      this.ReadOnly = true;
    }

    internal void graphControl_OnShowTask(object sender, EventArgs e)
    {
      BaseTaskObjectForm baseTaskObjectForm = new BaseTaskObjectForm();
      if (this._task.TaskObject is DihTaskObject)
        baseTaskObjectForm.TaskObjectControl = ((DihTaskObject) this._task.TaskObject).Left != 0.0 || ((DihTaskObject) this._task.TaskObject).Right != 0.0 ? (BaseTaskObjectControl) new CreateDihTaskObject((DihTaskObject) this._task.TaskObject, false) : (BaseTaskObjectControl) new CreatePauelTaskObject((DihTaskObject) this._task.TaskObject, false);
      else if (this._task.TaskObject is ScanTaskObject)
        baseTaskObjectForm.TaskObjectControl = (BaseTaskObjectControl) new CreateScanTaskObject((ScanTaskObject) this._task.TaskObject, false);
      else if (this._task.TaskObject is DiskTaskObject)
      {
        baseTaskObjectForm.TaskObjectControl = (BaseTaskObjectControl) new CreateDiskTaskObject((DiskTaskObject) this._task.TaskObject, false);
      }
      else
      {
        int num = (int) MessageBox.Show("ERROR-4");
        throw new NotImplementedException("ERROR-4");
      }
      baseTaskObjectForm.btnCancel.Visible = false;
      baseTaskObjectForm.Text = "Просмотр задания";
      int num1 = (int) baseTaskObjectForm.ShowDialog();
    }

    private void OnUndoAll()
    {
      this._scanSearch.UndoAll();
    }

    private void OnUndo()
    {
      this._scanSearch.Undo();
      this.graphControl.Refresh();
    }

    private void OnRedo()
    {
      this._scanSearch.Redo();
      this.graphControl.Refresh();
    }

    private void OnRedoAll()
    {
      this._scanSearch.RedoAll();
    }

    private void ParentForm_Closing(object sender, CancelEventArgs e)
    {
      this.pointViewer.CreatePointByCoord -= new Mephi.K22.LearningSuite.OneDSearch.Base.Point.CreatePointByCoordHandler(this.CreatePointByCoord);
      this.pointViewer.CreatePointByDiv2Points -= new Mephi.K22.LearningSuite.OneDSearch.Base.Point.Point2PointsEvent(this.CreatePointByDiv2Points);
      this.pointViewer.DeletePoints -= new Mephi.K22.LearningSuite.OneDSearch.Base.Point.PointCollectionEvent(this.DeletePoints);
      this.pointViewer.RunTests -= new Mephi.K22.LearningSuite.OneDSearch.Base.Point.PointCollectionEvent(this.RunTests);
      this.pointViewer.SelectPoints -= new Mephi.K22.LearningSuite.OneDSearch.Base.Point.PointCollectionEvent(this.SelectPoints);
      this.graphControl.RunTest -= new FuncButton.FuncButtonEvent(this.RunTest);
      this.graphControl.CreatePointBySegment -= new Mephi.K22.LearningSuite.OneDSearch.Base.Point.CreatePointBySegmentHandler(this.CreatePointBySegment);
      this._pointCollection.ListChanged -= new ListChangedEventHandler(this.ListChanged);
      this.segmentViewer.CreateSegmentByLength -= new Segment.CreateSegmentByLengthHandler(this.CreateSegmentByLength);
      this.segmentViewer.DeleteSegments -= new Segment.SegmentCollectionEvent(this.DeleteSegments);
      this.segmentViewer.CreateSegmentByDiv2Segment -= new Segment.SegmentEvent(this.CreateSegmentByDiv2Segment);
      this.segmentViewer.CreateSegmentByGoldSegment -= new Segment.SegmentEvent(this.CreateSegmentByGoldSegment);
      this.segmentViewer.SelectSegments -= new Segment.SegmentCollectionEvent(this.SelectSegments);
      this.segmentViewer.CreateSegmentByFib -= new Segment.CreateSegmentByFibHandler(this.CreateSegmentByFib);
      this.segmentViewer.CreateConnectedSegment -= new EventHandler(this.segmentViewer_CreateConnectedSegment);
      this.pointViewer.CreateFictDiskrete -= new EventHandler(this.pointViewer_CreateFictDiskrete);
      this.graphControl.CreateSegmentBy2Points -= new Segment.CreateSegmentBy2PointsHandler(this.CreateSegmentBy2Points);
      this.graphControl.SetResultSegment -= new ResultSegment.ResultSegmentEvent(this.SetResult);
      this.graphControl.SetResultPoint -= new BaseGraphControl.ResultPointHandler(this.SetResultPoint);
      this.pointViewer.CreatePaul -= new Mephi.K22.LearningSuite.OneDSearch.Base.Point.PointCollectionEvent(this.CreatePaul);
      this._segmentCollection.ListChanged -= new ListChangedEventHandler(this.ListChanged);
      this.graphControl.OnShowTask -= new EventHandler(this.graphControl_OnShowTask);
      this.actionViewer.OnUndoAll -= new ActionViewer.ActionEventHandler(this.OnUndoAll);
      this.actionViewer.OnUndo -= new ActionViewer.ActionEventHandler(this.OnUndo);
      this.actionViewer.OnRedo -= new ActionViewer.ActionEventHandler(this.OnRedo);
      this.actionViewer.OnRedoAll -= new ActionViewer.ActionEventHandler(this.OnRedoAll);
      this.ParentForm.Closing -= new CancelEventHandler(this.ParentForm_Closing);
    }

    private void segmentViewer_CreateConnectedSegment(object sender, EventArgs e)
    {
      Action act = new Action();
      act.ActionType = (byte) 13;
      int count = this._pointCollection.Count;
      PointSaveStub[] pointSaveStubArray = new PointSaveStub[count];
      for (int index = 0; index < count; ++index)
        pointSaveStubArray[index] = new PointSaveStub(this._pointCollection[index].CoordX, this._pointCollection[index].Name, this._pointCollection[index].FuncButton.IsEval, this._pointCollection[index].FuncButton.FuncValue);
      act.Parameters = new object[1]
      {
        (object) pointSaveStubArray
      };
      act.Message = string.Format("Выполнен переход к сопряженному отрезку", new object[0]);
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    internal void CreateConnectedSegmentImpl(PointSaveStub[] points)
    {
      PointSaveStub[] pointSaveStubArray = (PointSaveStub[]) points.Clone();
      for (int index1 = 0; index1 < pointSaveStubArray.Length; ++index1)
      {
        for (int index2 = 1; index2 < pointSaveStubArray.Length - index1; ++index2)
        {
          if (pointSaveStubArray[index2].Coord < pointSaveStubArray[index2 - 1].Coord)
          {
            PointSaveStub pointSaveStub = pointSaveStubArray[index2];
            pointSaveStubArray[index2] = pointSaveStubArray[index2 - 1];
            pointSaveStubArray[index2 - 1] = pointSaveStub;
          }
        }
      }
      for (int index = 0; index < pointSaveStubArray.Length; ++index)
        this.DeletePointImpl(pointSaveStubArray[index].Coord);
      for (int i = 0; i < pointSaveStubArray.Length; ++i)
      {
        Diskrete diskrete = new Diskrete(pointSaveStubArray[i], i);
        if (pointSaveStubArray[i].Name == "Ф")
          diskrete.IsFictive = true;
        this._pointCollection.Add((BasePoint) diskrete);
        FuncButton funcButton = new FuncButton((BasePoint) diskrete);
        this._funcButtonCollection.Add(funcButton);
        funcButton.IsEval = pointSaveStubArray[i].IsEval;
        if (funcButton.IsEval)
          funcButton.SetFuncValue(pointSaveStubArray[i].Fx);
      }
      this.segmentViewer.IsDiskrete = false;
    }

    internal void UndoCreateConnectedSegmentImpl(PointSaveStub[] points)
    {
      PointSaveStub[] pointSaveStubArray = (PointSaveStub[]) points.Clone();
      double[] numArray = new double[this._pointCollection.Count];
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = this._pointCollection[index].CoordX;
      for (int index = 0; index < numArray.Length; ++index)
        this.DeletePointImpl(numArray[index]);
      for (int index = 0; index < numArray.Length; ++index)
      {
        Mephi.K22.LearningSuite.OneDSearch.Base.Point point = new Mephi.K22.LearningSuite.OneDSearch.Base.Point(pointSaveStubArray[index].Coord, pointSaveStubArray[index].Name);
        this._pointCollection.Add((BasePoint) point);
        FuncButton funcButton = new FuncButton((BasePoint) point);
        this._funcButtonCollection.Add(funcButton);
        funcButton.IsEval = pointSaveStubArray[index].IsEval;
        if (funcButton.IsEval)
          funcButton.SetFuncValue(pointSaveStubArray[index].Fx);
      }
      this.segmentViewer.IsDiskrete = true;
    }

    private void pointViewer_CreateFictDiskrete(object sender, EventArgs e)
    {
      Action act = new Action();
      act.ActionType = (byte) 14;
      double num1 = double.MinValue;
      foreach (BasePoint basePoint in (CollectionBase) this._pointCollection)
      {
        if (basePoint.CoordX > num1)
          num1 = basePoint.CoordX;
      }
      if (this.segmentViewer.IsDiskrete)
      {
        int num2 = 1;
        while (this._pointCollection.GetPoint((double) ((int) num1 - num2)) != null)
          ++num2;
        num1 -= (double) num2;
      }
      act.Parameters = new object[1]
      {
        (object) num1
      };
      act.Message = string.Format("Создана фиктивная точка", new object[0]);
      this._actionCollection.Add(act);
      this._scanSearch.RunAction(act, false);
    }

    internal void CreateFictDiskreteImpl(double coord)
    {
      if (!this.segmentViewer.IsDiskrete)
      {
        BasePoint point = this._pointCollection.GetPoint(coord);
        Diskrete diskrete = new Diskrete(true, (int) point.CoordX);
        point.CoordX = point.CoordX + 1.0;
        this._pointCollection.Add((BasePoint) diskrete);
        this._funcButtonCollection.Add(new FuncButton((BasePoint) diskrete));
      }
      else
      {
        Diskrete diskrete = new Diskrete(true, (int) coord);
        this._pointCollection.Add((BasePoint) diskrete);
        this._funcButtonCollection.Add(new FuncButton((BasePoint) diskrete));
      }
    }

    internal void UndoCreateFictDiskreteImpl(double coord)
    {
      this.DeletePointImpl(coord);
      if (this.segmentViewer.IsDiskrete)
        return;
      foreach (BasePoint basePoint in (CollectionBase) this._pointCollection)
      {
        if (basePoint.CoordX > coord)
          --basePoint.CoordX;
      }
    }
  }
}
