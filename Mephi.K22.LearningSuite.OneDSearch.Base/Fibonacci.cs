// Type: Mephi.K22.LearningSuite.OneDSearch.Base.Fibonacci
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class Fibonacci
  {
    public static int FibNumber(int n)
    {
      int num1 = 1;
      int num2 = 1;
      for (int index = 0; index < n; ++index)
      {
        int num3 = num1;
        num1 = num2;
        num2 += num3;
      }
      return num1;
    }

    public static int GetMaxStep(double l, double e)
    {
      int num = 0;
      while ((double) Fibonacci.FibNumber(num + 1) > l / e || l / e >= (double) Fibonacci.FibNumber(num + 2))
        ++num;
      return num;
    }
  }
}
