// Type: Mephi.K22.LearningSuite.Core.MethodControlLoader
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace Mephi.K22.LearningSuite.Core
{
  public class MethodControlLoader
  {
    public static MethodInfoCollection ScanForMethods()
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath);
      MethodInfoCollection methodInfoCollection = new MethodInfoCollection();
      string exec = string.Empty;
      string createExec = string.Empty;
      foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.dll"))
      {
        try
        {
          Assembly element = Assembly.LoadFrom(fileInfo.FullName);
          if (Attribute.IsDefined(element, typeof (TaskAssemblyAttribute)))
          {
            System.Type[] types = element.GetTypes();
            ThemeMethodCollection methodCollection = new ThemeMethodCollection();
            foreach (System.Type type in types)
            {
              if (Attribute.IsDefined((MemberInfo) type, typeof (TaskClassAttribute)))
              {
                TaskClassAttribute taskClassAttribute = (TaskClassAttribute) Attribute.GetCustomAttribute((MemberInfo) type, typeof (TaskClassAttribute));
                foreach (System.Reflection.MethodInfo methodInfo in type.GetMethods())
                {
                  if (Attribute.IsDefined((MemberInfo) methodInfo, typeof (TaskExecEntryPointAttribute)))
                    exec = methodInfo.Name;
                  if (Attribute.IsDefined((MemberInfo) methodInfo, typeof (TaskCreateEntryPointAttribute)))
                    createExec = methodInfo.Name;
                }
                methodCollection.Add(new MethodInfo(element.FullName, type.Name, taskClassAttribute.TaskName, exec, createExec));
              }
            }
            methodInfoCollection.Add(methodCollection);
          }
        }
        catch
        {
        }
      }
      return methodInfoCollection;
    }

    public static BaseMethodControl LoadAss(MethodInfo minf)
    {
      BaseMethodControl baseMethodControl = (BaseMethodControl) null;
      try
      {
        string[] strArray = minf.AssemblyName.Split(new char[1]
        {
          ','
        });
        baseMethodControl = (BaseMethodControl) Activator.CreateInstance(Assembly.Load(minf.AssemblyName).GetType(strArray[0] + "." + minf.ClassName));
      }
      catch (Exception ex)
      {
        string message = ex.Message;
      }
      return baseMethodControl;
    }

    public static void Exec(Task t, RunMode mode, int retryNum)
    {
      string[] strArray = t.MetInfo.AssemblyName.Split(new char[1]
      {
        ','
      });
      Assembly.Load(t.MetInfo.AssemblyName).GetType(strArray[0] + "." + t.MetInfo.ClassName).GetMethod(t.MetInfo.Exec).Invoke((object) null, new object[3]
      {
        (object) t,
        (object) mode,
        (object) retryNum
      });
    }

    public static ICheck ExecCheck(Task t)
    {
      string[] strArray = t.MetInfo.AssemblyName.Split(new char[1]
      {
        ','
      });
      return (ICheck) Assembly.Load(t.MetInfo.AssemblyName).GetType(strArray[0] + "." + t.MetInfo.ClassName).GetMethod("InitCheck").Invoke((object) null, new object[1]
      {
        (object) t
      });
    }

    public static BaseTaskObject CreateExec(string assName, string className, string createTaskExec, object taskObject)
    {
      try
      {
        string[] strArray = assName.Split(new char[1]
        {
          ','
        });
        return (BaseTaskObject) Assembly.Load(assName).GetType(strArray[0] + "." + className).GetMethod(createTaskExec).Invoke(new object(), new object[1]
        {
          taskObject
        });
      }
      catch (Exception ex)
      {
        string message = ex.Message;
        return (BaseTaskObject) null;
      }
    }

    public static ErrorCollection GetErrorsFromMethod(string assName, string className, string methName)
    {
      ErrorCollection errorCollection = new ErrorCollection();
      try
      {
        assName.Split(new char[1]
        {
          ','
        });
        Assembly assembly = Assembly.Load(assName);
        string[] manifestResourceNames = assembly.GetManifestResourceNames();
        if (manifestResourceNames.Length > 0)
        {
          foreach (string name in manifestResourceNames)
          {
            if (name.EndsWith(".info.xml"))
            {
              try
              {
                Stream manifestResourceStream = assembly.GetManifestResourceStream(name);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(manifestResourceStream);
                string innerText = xmlDocument.GetElementsByTagName("themeName")[0].InnerText;
                foreach (XmlElement xmlElement1 in xmlDocument.GetElementsByTagName("method"))
                {
                  if (xmlElement1.GetElementsByTagName("class")[0].InnerText == className && xmlElement1.GetElementsByTagName("exec")[0].InnerText == methName)
                  {
                    IEnumerator enumerator = xmlElement1.GetElementsByTagName("error").GetEnumerator();
                    try
                    {
                      while (enumerator.MoveNext())
                      {
                        XmlElement xmlElement2 = (XmlElement) enumerator.Current;
                        errorCollection.Add(new Error(xmlElement2.GetElementsByTagName("text")[0].InnerText, int.Parse(xmlElement2.GetElementsByTagName("code")[0].InnerText)));
                      }
                      break;
                    }
                    finally
                    {
                      IDisposable disposable = enumerator as IDisposable;
                      if (disposable != null)
                        disposable.Dispose();
                    }
                  }
                }
                manifestResourceStream.Close();
              }
              catch
              {
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        string message = ex.Message;
        return (ErrorCollection) null;
      }
      return errorCollection;
    }
  }
}
