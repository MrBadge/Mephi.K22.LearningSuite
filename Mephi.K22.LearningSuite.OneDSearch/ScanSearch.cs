// Type: Mephi.K22.LearningSuite.OneDSearch.ScanSearch
// Assembly: Mephi.K22.LearningSuite.OneDSearch, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A759670E-215D-48E9-9EE9-703E6D1ED21B
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.OneDSearch.Base;

namespace Mephi.K22.LearningSuite.OneDSearch
{
  [TaskClass("Сканирование")]
  public class ScanSearch : BaseSearch, ICheck
  {
    public ScanSearch(Task task, RunMode mode, int retryNum)
      : base(task, mode, retryNum, ResultType.segment)
    {
    }

    public ScanSearch(Task task)
      : base(task)
    {
    }

    [TaskExecEntryPoint]
    public new static void Init(Task task, RunMode mode, int retryNum)
    {
      ScanSearch scanSearch = new ScanSearch(task, mode, retryNum);
    }

    protected override void LoadTask(BaseTaskObject taskObj)
    {
      if (taskObj == null)
        return;
      this.taskObject = taskObj;
      this.func = new Function(((ScanTaskObject) this.taskObject).FuncText);
      Point point1 = new Point(((ScanTaskObject) this.taskObject).Left, "X0");
      point1.IsPredefined = true;
      this.pointCollection.Add((BasePoint) point1);
      this.funcButtonCollection.Add(new FuncButton((BasePoint) point1));
      Point point2 = new Point(((ScanTaskObject) this.taskObject).Right, "X1");
      point2.IsPredefined = true;
      this.pointCollection.Add((BasePoint) point2);
      this.funcButtonCollection.Add(new FuncButton((BasePoint) point2));
      this.segmentCollection.Add((Element) new Segment("eps", ((BaseSeacrhTaskObject) this.taskObject).Epsilon));
    }

    protected override void TestInit()
    {
      this.test = (BaseTest) new TestScan(((BaseSeacrhTaskObject) this.taskObject).Epsilon, ((ScanTaskObject) this.taskObject).Left, ((ScanTaskObject) this.taskObject).Right, ((ScanTaskObject) this.taskObject).ExtremumType);
    }

    [TaskCreateEntryPoint]
    public new static BaseTaskObject GetTaskObject(BaseTaskObject to)
    {
      BaseTaskObjectForm baseTaskObjectForm = new BaseTaskObjectForm();
      baseTaskObjectForm.TaskObjectControl = (BaseTaskObjectControl) new CreateScanTaskObject((ScanTaskObject) to);
      int num = (int) baseTaskObjectForm.ShowDialog();
      return baseTaskObjectForm.TaskObjectControl.GetTaskObject();
    }

    AccuracyType ICheck.TestAction(Action a)
    {
      return this.test.TestAction(a).Accuracy;
    }

    bool ICheck.IsOver()
    {
      return this.test.IsOver();
    }

    public static ICheck InitCheck(Task task)
    {
      return (ICheck) new ScanSearch(task);
    }
  }
}
