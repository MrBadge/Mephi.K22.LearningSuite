// Type: Mephi.K22.LearningSuite.OneDSearch.Base.Paul
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class Paul
  {
    public static double FuncPaul(double x1, double x2, double x3, double fx1, double fx2, double fx3)
    {
      return 0.5 * (((x2 * x2 - x3 * x3) * fx1 + (x3 * x3 - x1 * x1) * fx2 + (x1 * x1 - x2 * x2) * fx3) / ((x2 - x3) * fx1 + (x3 - x1) * fx2 + (x1 - x2) * fx3));
    }
  }
}
