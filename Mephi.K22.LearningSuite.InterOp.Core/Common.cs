// Type: Mephi.K22.LearningSuite.InterOp.Core.Common
// Assembly: Mephi.K22.LearningSuite.InterOp.Core, Version=1.0.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 8A518B76-7E22-4573-9961-0A744E0497AC
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.InterOp.Core.dll

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Mephi.K22.LearningSuite.InterOp.Core
{
  public class Common
  {
    public static object TransformObj(object taskObj, bool compress)
    {
      compress = false;
      if (taskObj == null)
        return (object) null;
      IFormatter formatter = (IFormatter) new BinaryFormatter();
      MemoryStream memoryStream = new MemoryStream();
      formatter.Serialize((Stream) memoryStream, taskObj);
      return (object) memoryStream.GetBuffer();
    }

    public static object ReTransformObj(object bytes, bool compress)
    {
      compress = false;
      if (bytes == null)
        return (object) null;
      return new BinaryFormatter().Deserialize((Stream) new MemoryStream((byte[]) bytes));
    }
  }
}
