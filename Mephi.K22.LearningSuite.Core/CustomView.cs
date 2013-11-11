// Type: Mephi.K22.LearningSuite.Core.CustomView
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Mephi.K22.LearningSuite.Core
{
  public class CustomView : GridView
  {
    public CustomView()
    {
      this.Appearance.OddRow.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.Appearance.OddRow.BackColor2 = Color.White;
      this.Appearance.OddRow.GradientMode = LinearGradientMode.Vertical;
      this.Appearance.OddRow.Options.UseBackColor = true;
      this.PaintStyleName = "Flat";
      this.GroupPanelText = "Для группировки по колонке перетащите сюда заголовок этой колонки";
    }
  }
}
