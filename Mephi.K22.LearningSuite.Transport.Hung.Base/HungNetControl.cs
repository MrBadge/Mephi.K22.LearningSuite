// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.HungNetControl
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

using Mephi.K22.LearningSuite.Transport.FF.Base;

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public class HungNetControl : BaseNetControl
  {
    public event Net.SetNetworkHandler SetResultNetwork;

    protected override void SetResultInternal()
    {
      if (this.SetResultNetwork == null)
        return;
      this.SetResultNetwork(this._net);
    }
  }
}
