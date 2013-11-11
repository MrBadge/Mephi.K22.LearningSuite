// Type: Mephi.K22.LearningSuite.OneDSearch.TestScan
// Assembly: Mephi.K22.LearningSuite.OneDSearch, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A759670E-215D-48E9-9EE9-703E6D1ED21B
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.OneDSearch.Base;
using System;
using System.Collections;

namespace Mephi.K22.LearningSuite.OneDSearch
{
  public class TestScan : BaseTest
  {
    private readonly double _eps = 0.0;
    private readonly double _leftPoint = 0.0;
    private readonly double _rightPoint = 0.0;
    private readonly int _nmax = 0;
    internal State methodState = State.begin;
    internal int step = 0;
    internal double prevTest = 0.0;
    internal bool isOver = false;
    private readonly ExtremumType _extType;

    public override object[] InnerState
    {
      get
      {
        return new object[4]
        {
          (object) this.methodState,
          (object) this.step,
          (object) this.prevTest,
          (object) this.isOver
        };
      }
      set
      {
        object[] objArray = value;
        this.methodState = (State) objArray[0];
        this.step = (int) objArray[1];
        this.prevTest = (double) objArray[2];
        this.isOver = (bool) objArray[3];
      }
    }

    public TestScan()
    {
    }

    public TestScan(double eps, double left, double right, ExtremumType eType)
    {
      this._eps = eps;
      this._leftPoint = left;
      this._rightPoint = right;
      this._extType = eType;
      this._nmax = (int) Math.Floor((this._rightPoint - this._leftPoint + Constants.DoublePrecision) / (this._eps / 2.0)) - 1;
      if (this._rightPoint - this._leftPoint < eps)
        this.methodState = State.end;
      else
        this.methodState = State.begin;
    }

    public override BaseTest TestCopy()
    {
      return (BaseTest) new TestScan(this._eps, this._leftPoint, this._rightPoint, this._extType)
      {
        methodState = this.methodState,
        step = this.step,
        prevTest = this.prevTest,
        isOver = this.isOver
      };
    }

    public override ActionResult TestAction(Action act)
    {
      ActionResult actionResult = new ActionResult();
      ArrayList errKeys = new ArrayList();
      switch (act.ActionType)
      {
        case (byte) 0:
          if (this.IsCoordUse((double) act.Parameters[0]))
          {
            actionResult.Accuracy = AccuracyType.mayYes;
            break;
          }
          else
          {
            actionResult.Accuracy = AccuracyType.mayNot;
            actionResult.Comment = "Нет необходимости создавать такую точку";
            break;
          }
        case (byte) 1:
          if (this.IsCoordUse((double) act.Parameters[0]))
          {
            actionResult.Accuracy = AccuracyType.mayYes;
            break;
          }
          else
          {
            actionResult.Accuracy = AccuracyType.mayNot;
            actionResult.Comment = "Нет необходимости создавать такую точку";
            break;
          }
        case (byte) 2:
          if (this.IsCoordUse((double) act.Parameters[0]))
          {
            actionResult.Accuracy = AccuracyType.mayYes;
            break;
          }
          else
          {
            actionResult.Accuracy = AccuracyType.mayNot;
            actionResult.Comment = "Нет необходимости создавать такую точку";
            break;
          }
        case (byte) 4:
          if (this.IsSegmentUse((double) act.Parameters[2] - (double) act.Parameters[0]))
          {
            actionResult.Accuracy = AccuracyType.mayYes;
            break;
          }
          else
          {
            actionResult.Accuracy = AccuracyType.mayNot;
            actionResult.Comment = "Нет необходимости создавать такой отрезок";
            break;
          }
        case (byte) 5:
          if (this.IsSegmentUse((double) act.Parameters[0]))
          {
            actionResult.Accuracy = AccuracyType.mayYes;
            break;
          }
          else
          {
            actionResult.Accuracy = AccuracyType.mayNot;
            actionResult.Comment = "Нет необходимости создавать такой отрезок";
            break;
          }
        case (byte) 6:
          actionResult.Accuracy = AccuracyType.notSpecified;
          break;
        case (byte) 7:
          actionResult.Accuracy = AccuracyType.notSpecified;
          break;
        case (byte) 8:
          string str = string.Empty;
          actionResult.Accuracy = !this.IsPointRigth((double) act.Parameters[0], out errKeys) ? AccuracyType.no : AccuracyType.yes;
          actionResult.Comment = str;
          actionResult.ErrorKeys = errKeys;
          break;
        case (byte) 9:
          this.isOver = true;
          actionResult.Accuracy = AccuracyType.no;
          int length = act.Parameters.Length - 2;
          double[] experiments = new double[length];
          for (int index = 0; index < length; ++index)
            experiments[index] = (double) act.Parameters[index + 2];
          if (this.IsResultRight((double) act.Parameters[0], (double) act.Parameters[1], experiments))
          {
            actionResult.Accuracy = AccuracyType.yes;
          }
          else
          {
            errKeys.Add((object) 5);
            actionResult.Accuracy = AccuracyType.no;
          }
          actionResult.ErrorKeys = errKeys;
          break;
        case (byte) 10:
          if (this.IsSegmentUse((double) act.Parameters[0]))
          {
            actionResult.Accuracy = AccuracyType.mayYes;
            break;
          }
          else
          {
            actionResult.Accuracy = AccuracyType.mayNot;
            actionResult.Comment = "Нет необходимости создавать такой отрезок";
            break;
          }
        case (byte) 11:
          if (this.IsSegmentUse((double) act.Parameters[0]))
          {
            actionResult.Accuracy = AccuracyType.mayYes;
            break;
          }
          else
          {
            actionResult.Accuracy = AccuracyType.mayNot;
            actionResult.Comment = "Нет необходимости создавать такой отрезок";
            break;
          }
        case (byte) 12:
          if (this.IsCoordUse((double) act.Parameters[0]))
          {
            actionResult.Accuracy = AccuracyType.mayYes;
            break;
          }
          else
          {
            actionResult.Accuracy = AccuracyType.mayNot;
            actionResult.Comment = "Нет необходимости создавать такую точку";
            break;
          }
      }
      return actionResult;
    }

    private bool IsCoordUse(double coord)
    {
      int num1 = 0;
      for (double num2 = this._leftPoint; num2 <= this._rightPoint; num2 = (double) num1 * this._eps / 2.0 + this._leftPoint)
      {
        if (Math.Abs(num2 - coord) < Constants.DoublePrecision)
          return true;
        ++num1;
      }
      return false;
    }

    private bool IsSegmentUse(double len)
    {
      return Math.Abs(len - this._eps / 2.0) < Constants.DoublePrecision;
    }

    private bool IsPointRigth(double coord, out ArrayList errKeys)
    {
      errKeys = new ArrayList();
      bool flag = false;
      if (this._leftPoint <= coord && coord <= this._rightPoint)
      {
        if (Math.Abs(this._leftPoint - coord) > Constants.DoublePrecision)
        {
          if (Math.Abs(this._rightPoint - coord) > Constants.DoublePrecision)
          {
            if (this.methodState == State.begin)
            {
              int num1 = (int) Math.Floor((coord - this._leftPoint + Constants.DoublePrecision) / (this._eps / 2.0));
              int num2 = (int) Math.Floor((this._rightPoint - coord + Constants.DoublePrecision) / (this._eps / 2.0));
              if (Math.Abs(this._leftPoint + (double) num1 * this._eps / 2.0 - coord) < Constants.DoublePrecision || Math.Abs(this._rightPoint - (double) num2 * this._eps / 2.0 - coord) < Constants.DoublePrecision)
              {
                flag = true;
              }
              else
              {
                flag = false;
                errKeys.Add((object) 1);
              }
            }
            else if (this.methodState == State.normal)
            {
              if (Math.Abs(this.prevTest - (double) (int) Math.Floor((this.prevTest - coord) / (this._eps / 2.0)) * this._eps / 2.0 - coord) < Constants.DoublePrecision)
              {
                flag = true;
              }
              else
              {
                flag = false;
                errKeys.Add((object) 1);
              }
            }
            else if (this.methodState == State.end)
            {
              errKeys.Add((object) 3);
              if (Math.Abs(this.prevTest - (double) (int) Math.Floor((this.prevTest - coord) / (this._eps / 2.0)) * this._eps / 2.0 - coord) >= Constants.DoublePrecision)
                errKeys.Add((object) 1);
            }
          }
          else
          {
            flag = false;
            errKeys.Add((object) 2);
          }
        }
        else
        {
          flag = false;
          errKeys.Add((object) 2);
        }
      }
      else
      {
        flag = false;
        errKeys.Add((object) 4);
      }
      this.prevTest = coord;
      this.step = this.step + 1;
      if (this.methodState == State.begin)
        this.methodState = State.normal;
      if (this.methodState == State.normal && this.step >= this._nmax)
        this.methodState = State.end;
      return flag;
    }

    private bool IsResultRight(double left, double right, double[] experiments)
    {
      int num1 = experiments.Length / 2;
      double num2 = this._extType == ExtremumType.min ? double.MaxValue : double.MinValue;
      int index1 = 0;
      for (int index2 = 0; index2 < num1; ++index2)
      {
        if (this._extType == ExtremumType.min && experiments[2 * index2 + 1] < num2 || this._extType == ExtremumType.max && experiments[2 * index2 + 1] > num2)
        {
          num2 = experiments[2 * index2 + 1];
          index1 = 2 * index2;
        }
      }
      double num3 = experiments[index1];
      int index3 = int.MinValue;
      double num4 = double.MinValue;
      for (int index2 = 0; index2 < num1; ++index2)
      {
        if (experiments[2 * index2] < experiments[index1] && experiments[2 * index2] > num4)
        {
          num4 = experiments[2 * index2];
          index3 = 2 * index2;
        }
      }
      double num5 = index3 == int.MinValue ? this._leftPoint : experiments[index3];
      int index4 = int.MaxValue;
      double num6 = double.MaxValue;
      for (int index2 = 0; index2 < num1; ++index2)
      {
        if (experiments[index1] < experiments[2 * index2] && experiments[2 * index2] < num6)
        {
          num6 = experiments[2 * index2];
          index4 = 2 * index2;
        }
      }
      double num7 = index4 == int.MaxValue ? this._rightPoint : experiments[index4];
      return Math.Abs(num5 - left) < Constants.DoublePrecision && Math.Abs(num7 - right) < Constants.DoublePrecision;
    }

    public override bool IsOver()
    {
      return this.isOver;
    }
  }
}
