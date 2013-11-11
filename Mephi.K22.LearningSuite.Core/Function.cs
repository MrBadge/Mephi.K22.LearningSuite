// Type: Mephi.K22.LearningSuite.Core.Function
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Mephi.K22.LearningSuite.Core
{
  public class Function
  {
    private string[] _errors = new string[0];
    private const string ClassName = "Function";
    private const string FuncName = "GetValue";
    private const string NameSpace = "Mephi.K22.LearningSuite.Calculator";
    private string _text;
    private Assembly _ass;

    public string Text
    {
      get
      {
        return this._text;
      }
      set
      {
        this._text = value;
        this._ass = this.CreateCompiledAssembly(this._text, ref this._errors);
      }
    }

    public string[] Errors
    {
      get
      {
        return this._errors;
      }
    }

    public Function(string text)
    {
      this._text = text;
      this._ass = this.CreateCompiledAssembly(this._text, ref this._errors);
    }

    public bool Test()
    {
      return this._errors.Length == 0;
    }

    public double Eval(double[] args)
    {
      if (this.Test())
        return this.GetValue(this._ass, args);
      else
        return 0.0;
    }

    private Assembly CreateCompiledAssembly(string funcText, ref string[] errors)
    {
      CodeCompileUnit compileUnit = this.CreateCompileUnit("Mephi.K22.LearningSuite.Calculator", "Function", "GetValue", funcText);
      CompilerErrorCollection cec = (CompilerErrorCollection) null;
      Assembly assembly = this.CompileCode(compileUnit, ref cec);
      if (cec.Count == 0)
      {
        errors = new string[0];
        return assembly;
      }
      else
      {
        errors = new string[cec.Count];
        for (int index = 0; index < cec.Count; ++index)
          errors[index] = cec[index].ErrorText;
        return (Assembly) null;
      }
    }

    private double GetValue(Assembly ass, double[] args)
    {
      object[] @params = Function.GetParams(args);
      return this.GetFuncValue(ass, "Mephi.K22.LearningSuite.Calculator", "Function", "GetValue", @params);
    }

    private CodeCompileUnit CreateCompileUnit(string nameSpace, string className, string funcName, string funcText)
    {
      CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
      CodeNamespace codeNamespace = new CodeNamespace(nameSpace);
      codeNamespace.Imports.Add(new CodeNamespaceImport("System"));
      codeCompileUnit.Namespaces.Add(codeNamespace);
      codeNamespace.Types.Add(new CodeTypeDeclaration(className)
      {
        Members = {
          (CodeTypeMember) this.CreateFunctionMethod(funcName, funcText)
        }
      });
      return codeCompileUnit;
    }

    private CodeMemberMethod CreateFunctionMethod(string funcName, string funcText)
    {
      CodeMemberMethod codeMemberMethod = new CodeMemberMethod();
      codeMemberMethod.Name = funcName;
      codeMemberMethod.ReturnType = new CodeTypeReference("System.Double");
      codeMemberMethod.Parameters.Add(new CodeParameterDeclarationExpression("System.Double[]", "x"));
      codeMemberMethod.Statements.Add((CodeStatement) new CodeMethodReturnStatement((CodeExpression) new CodeArgumentReferenceExpression(funcText)));
      codeMemberMethod.Attributes = (MemberAttributes) 24579;
      return codeMemberMethod;
    }

    private double GetFuncValue(Assembly ass, string nameSpace, string className, string funcName, object[] args)
    {
      System.Reflection.MethodInfo method = ass.GetType(nameSpace + "." + className).GetMethod(funcName);
      object obj = new object();
      try
      {
        double d = (double) method.Invoke(obj, args);
        if (!double.IsInfinity(d))
          return d;
        return Math.Sign(d) == -1 ? double.MinValue : double.MaxValue;
      }
      catch
      {
        return 0.0;
      }
    }

    private Assembly CompileCode(CodeCompileUnit compileUnit, ref CompilerErrorCollection cec)
    {
      CompilerResults compilerResults = new CSharpCodeProvider().CreateCompiler().CompileAssemblyFromDom(new CompilerParameters()
      {
        ReferencedAssemblies = {
          "System.dll"
        },
        GenerateExecutable = false,
        GenerateInMemory = true
      }, compileUnit);
      cec = compilerResults.Errors;
      if (compilerResults.Errors.Count == 0)
        return compilerResults.CompiledAssembly;
      else
        return (Assembly) null;
    }

    private static object[] GetParams(double[] args)
    {
      return new object[1]
      {
        (object) args
      };
    }

    public static void Test(string text)
    {
      Function function = new Function(text);
      bool flag = function.Test();
      string[] errors = function.Errors;
      FunctionTestResult functionTestResult = new FunctionTestResult();
      if (!flag)
      {
        functionTestResult.listBox1.DataSource = (object) errors;
      }
      else
      {
        string[] strArray = new string[1]
        {
          "Ошибок не обнаружено"
        };
        functionTestResult.listBox1.DataSource = (object) strArray;
      }
      int num = (int) functionTestResult.ShowDialog();
    }
  }
}
