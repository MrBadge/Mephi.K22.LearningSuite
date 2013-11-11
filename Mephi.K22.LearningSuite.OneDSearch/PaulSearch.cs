// Type: Mephi.K22.LearningSuite.OneDSearch.PaulSearch
// Assembly: Mephi.K22.LearningSuite.OneDSearch, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A759670E-215D-48E9-9EE9-703E6D1ED21B
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.OneDSearch.Base;

namespace Mephi.K22.LearningSuite.OneDSearch
{
  [TaskClass("Пауэлл")]
  public class PaulSearch : BaseSearch, ICheck
  {
    public PaulSearch(Task task, RunMode mode, int retryNum)
      : base(task, mode, retryNum, ResultType.point)
    {
    }

    public PaulSearch(Task task)
      : base(task)
    {
    }

    [TaskExecEntryPoint]
    public new static void Init(Task task, RunMode mode, int retryNum)
    {
      PaulSearch paulSearch = new PaulSearch(task, mode, retryNum);
    }

    protected override void LoadTask(BaseTaskObject taskObj)
    {
      if (taskObj == null)
        return;
      this.taskObject = taskObj;
      this.func = new Function(((DihTaskObject) this.taskObject).FuncText);
      this.segmentCollection.Add((Element) new Segment("eps", ((BaseSeacrhTaskObject) this.taskObject).Epsilon));
    }

    protected override void TestInit()
    {
      this.test = (BaseTest) new TestPaul(((BaseSeacrhTaskObject) this.taskObject).Epsilon, ((DihTaskObject) this.taskObject).Left, ((DihTaskObject) this.taskObject).Right, ((DihTaskObject) this.taskObject).ExtremumType, ((DihTaskObject) this.taskObject).MaxSteps);
    }

    [TaskCreateEntryPoint]
    public new static BaseTaskObject GetTaskObject(BaseTaskObject to)
    {
      BaseTaskObjectForm baseTaskObjectForm = new BaseTaskObjectForm();
      baseTaskObjectForm.TaskObjectControl = (BaseTaskObjectControl) new CreatePauelTaskObject((DihTaskObject) to);
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
      return (ICheck) new PaulSearch(task);
    }
  }
}
