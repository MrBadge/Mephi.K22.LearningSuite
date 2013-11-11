// Type: Mephi.K22.LearningSuite.OneDSearch.Base.DrawPallet
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System.Drawing;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class DrawPallet
  {
    public static string FontName = "MS Reference Sans Serif";
    public static int FontSizeNormal = 7;
    public static Pen blackPen = (Pen) null;
    public static Pen blackPenDotted1 = (Pen) null;
    public static Pen blackPenDotted2 = (Pen) null;
    public static Pen redPenWiden = (Pen) null;
    public static Pen grayPen = (Pen) null;
    public static Pen greenPenW1 = (Pen) null;
    public static Pen greenPenW2 = (Pen) null;
    public static SolidBrush redBrush = (SolidBrush) null;
    public static SolidBrush blueBrush = (SolidBrush) null;
    public static SolidBrush yellowBrush = (SolidBrush) null;
    public static SolidBrush grayBrush = (SolidBrush) null;
    public static SolidBrush blackBrush = (SolidBrush) null;
    public static SolidBrush whiteBrush = (SolidBrush) null;

    static DrawPallet()
    {
      DrawPallet.blackPen = new Pen(Color.Black);
      DrawPallet.blackPenDotted1 = new Pen(Color.Black);
      DrawPallet.blackPenDotted1.DashPattern = new float[4]
      {
        4f,
        5f,
        4f,
        5f
      };
      DrawPallet.blackPenDotted2 = new Pen(Color.Black);
      DrawPallet.blackPenDotted2.DashPattern = new float[4]
      {
        2f,
        2f,
        2f,
        2f
      };
      DrawPallet.redPenWiden = new Pen(Color.Red, (float) DrawElement.MousePrecision);
      DrawPallet.grayPen = new Pen(Color.Gray);
      DrawPallet.greenPenW1 = new Pen(Color.Green, 1f);
      DrawPallet.greenPenW2 = new Pen(Color.Green, 2f);
      DrawPallet.whiteBrush = new SolidBrush(Color.White);
      DrawPallet.redBrush = new SolidBrush(Color.Red);
      DrawPallet.blueBrush = new SolidBrush(Color.Blue);
      DrawPallet.yellowBrush = new SolidBrush(Color.Yellow);
      DrawPallet.grayBrush = new SolidBrush(Color.Gray);
      DrawPallet.blackBrush = new SolidBrush(Color.Black);
    }
  }
}
