// Type: Mephi.K22.LearningSuite.OneDSearch.DiskSearch
// Assembly: Mephi.K22.LearningSuite.OneDSearch, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A759670E-215D-48E9-9EE9-703E6D1ED21B
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.OneDSearch.Base;

namespace Mephi.K22.LearningSuite.OneDSearch
{
  [TaskClass("Дискреты")]
  public class DiskSearch : BaseSearch, ICheck
  {
    public DiskSearch(Task task, RunMode mode, int retryNum)
      : base(task, mode, retryNum, ResultType.point)
    {
    }

    public DiskSearch(Task task)
      : base(task)
    {
    }

    [TaskExecEntryPoint]
    public new static void Init(Task task, RunMode mode, int retryNum)
    {
      DiskSearch diskSearch = new DiskSearch(task, mode, retryNum);
    }

    protected override void SetMethodSpecificProperties()
    {
      this.oneDControl.IsDiskrete = true;
    }

    protected override void LoadTask(BaseTaskObject taskObj)
    {
      if (taskObj == null)
        return;
      this.taskObject = taskObj;
      this.func = new Function(((DiskTaskObject) this.taskObject).FuncText);
      Point point1 = new Point(((DiskTaskObject) this.taskObject).Left, "X0");
      point1.IsPredefined = true;
      this.pointCollection.Add((BasePoint) point1);
      this.funcButtonCollection.Add(new FuncButton((BasePoint) point1));
      Point point2 = new Point(((DiskTaskObject) this.taskObject).Right, "X1");
      point2.IsPredefined = true;
      this.pointCollection.Add((BasePoint) point2);
      this.funcButtonCollection.Add(new FuncButton((BasePoint) point2));
      for (int index = 0; index < ((DiskTaskObject) this.taskObject).Points.Length; ++index)
      {
        Point point3 = new Point(((DiskTaskObject) this.taskObject).Points[index], string.Format("X{0}", (object) (index + 2)));
        point3.IsPredefined = true;
        this.pointCollection.Add((BasePoint) point3);
        this.funcButtonCollection.Add(new FuncButton((BasePoint) point3));
      }
    }

    protected override void TestInit()
    {
      DiskTaskObject diskTaskObject = (DiskTaskObject) this.taskObject;
      this.test = (BaseTest) new TestDisk(diskTaskObject.Points, diskTaskObject.Left, diskTaskObject.Right, diskTaskObject.ExtremumType);
    }

    [TaskCreateEntryPoint]
    public new static BaseTaskObject GetTaskObject(BaseTaskObject to)
    {
      BaseTaskObjectForm baseTaskObjectForm = new BaseTaskObjectForm();
      baseTaskObjectForm.TaskObjectControl = (BaseTaskObjectControl) new CreateDiskTaskObject((DiskTaskObject) to);
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
      return (ICheck) new DiskSearch(task);
    }
  }
}
