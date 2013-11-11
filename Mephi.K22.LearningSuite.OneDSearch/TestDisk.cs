// Type: Mephi.K22.LearningSuite.OneDSearch.TestDisk
// Assembly: Mephi.K22.LearningSuite.OneDSearch, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A759670E-215D-48E9-9EE9-703E6D1ED21B
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.OneDSearch.Base;
using System;
using System.Collections;

namespace Mephi.K22.LearningSuite.OneDSearch
{
  public class TestDisk : BaseTest
  {
    private readonly double _leftPoint = 0.0;
    private readonly double _rightPoint = 0.0;
    private readonly int _nmax = 0;
    private readonly double[] _points = (double[]) null;
    internal State methodState = State.begin;
    internal int step = 0;
    internal double prevTest = 0.0;
    internal double prevTestValue = 0.0;
    internal double leftFront = 0.0;
    internal double rightFront = 0.0;
    internal bool isOver = false;
    internal bool isDouble = false;
    internal int fictivPointCount = 0;
    private readonly ExtremumType _extType;

    public override object[] InnerState
    {
      get
      {
        return new object[9]
        {
          (object) this.methodState,
          (object) this.step,
          (object) this.prevTest,
          (object) this.prevTestValue,
          (object) (bool) this.isOver,
          (object) this.fictivPointCount,
          (object) (bool) this.isDouble,
          (object) this.leftFront,
          (object) this.rightFront
        };
      }
      set
      {
        object[] objArray = value;
        this.methodState = (State) objArray[0];
        this.step = (int) objArray[1];
        this.prevTest = (double) objArray[2];
        this.prevTestValue = (double) objArray[3];
        this.isOver = (bool) objArray[4];
        this.fictivPointCount = (int) objArray[5];
        this.isDouble = (bool) objArray[6];
        this.leftFront = (double) objArray[7];
        this.rightFront = (double) objArray[8];
      }
    }

    public TestDisk()
    {
    }

    public TestDisk(double[] points, double left, double right, ExtremumType eType)
    {
      this._points = (double[]) points.Clone();
      for (int index1 = 0; index1 < this._points.Length; ++index1)
      {
        for (int index2 = 0; index2 < this._points.Length - 1 - index1; ++index2)
        {
          if (this._points[index2] > this._points[index2 + 1])
          {
            double num = this._points[index2];
            this._points[index2] = this._points[index2 + 1];
            this._points[index2 + 1] = num;
          }
        }
      }
      for (int index = 0; index < this._points.Length - 1; ++index)
      {
        if (this._points[index] > this._points[index + 1])
          throw new Exception("Бля-я-я-я-я!");
      }
      this._leftPoint = left;
      this._rightPoint = right;
      this._extType = eType;
    }

    public override BaseTest TestCopy()
    {
      return (BaseTest) new TestDisk(this._points, this._leftPoint, this._rightPoint, this._extType)
      {
        methodState = this.methodState,
        step = this.step,
        prevTest = this.prevTest,
        isOver = this.isOver,
        fictivPointCount = this.fictivPointCount,
        prevTestValue = this.prevTestValue,
        leftFront = this.leftFront,
        rightFront = this.rightFront
      };
    }

    public override ActionResult TestAction(Action act)
    {
      ActionResult actionResult = new ActionResult();
      ArrayList errKeys = new ArrayList();
      switch (act.ActionType)
      {
        case (byte) 0:
          actionResult.Accuracy = AccuracyType.no;
          actionResult.Comment = "Нельзя создавать точки";
          break;
        case (byte) 1:
          actionResult.Accuracy = AccuracyType.no;
          actionResult.Comment = "Нельзя создавать точки";
          break;
        case (byte) 2:
          actionResult.Accuracy = AccuracyType.no;
          actionResult.Comment = "Нельзя создавать точки";
          break;
        case (byte) 3:
          actionResult.Accuracy = AccuracyType.notSpecified;
          break;
        case (byte) 4:
          actionResult.Accuracy = AccuracyType.notSpecified;
          break;
        case (byte) 5:
          actionResult.Accuracy = AccuracyType.notSpecified;
          break;
        case (byte) 6:
          actionResult.Accuracy = AccuracyType.no;
          actionResult.Comment = "Нельзя создавать точки";
          break;
        case (byte) 7:
          actionResult.Accuracy = AccuracyType.notSpecified;
          break;
        case (byte) 8:
          string str = string.Empty;
          actionResult.Accuracy = !this.IsPointRigth((double) act.Parameters[0], (double) act.Parameters[1], out errKeys) ? AccuracyType.no : AccuracyType.yes;
          actionResult.Comment = str;
          actionResult.ErrorKeys = errKeys;
          break;
        case (byte) 9:
          this.isOver = true;
          actionResult.Accuracy = AccuracyType.no;
          double num = (double) act.Parameters[0];
          if (Math.Abs(Math.Abs(num - this.leftFront) - 1.0) < Constants.DoublePrecision || Math.Abs(Math.Abs(num - this.rightFront) - 1.0) < Constants.DoublePrecision)
          {
            actionResult.Accuracy = AccuracyType.yes;
          }
          else
          {
            errKeys.Add((object) 8);
            actionResult.Accuracy = AccuracyType.no;
          }
          actionResult.ErrorKeys = errKeys;
          break;
        case (byte) 10:
          actionResult.Accuracy = AccuracyType.notSpecified;
          break;
        case (byte) 11:
          actionResult.Accuracy = AccuracyType.notSpecified;
          break;
        case (byte) 12:
          actionResult.Accuracy = AccuracyType.no;
          actionResult.Comment = "Нельзя создавать точки";
          break;
        case (byte) 13:
          if (this.methodState == State.begin)
          {
            actionResult.Accuracy = AccuracyType.yes;
            this.methodState = !this.IsFictivePointsNeeded() ? State.pointsReady : State.connectedSegmentCreated;
            break;
          }
          else
          {
            actionResult.Accuracy = AccuracyType.no;
            actionResult.ErrorKeys.Add((object) 1);
            actionResult.Comment = "Первым действием должен быть переход к сопряженному отрезку";
            break;
          }
        case (byte) 14:
          actionResult.Accuracy = AccuracyType.yes;
          if (this.methodState != State.connectedSegmentCreated)
          {
            actionResult.Accuracy = AccuracyType.no;
            actionResult.ErrorKeys.Add((object) 3);
            actionResult.Comment = "Нельзя создавать фиктивные точки";
          }
          else if (!this.IsFictivePointsNeeded())
          {
            actionResult.Accuracy = AccuracyType.no;
            actionResult.ErrorKeys.Add((object) 2);
            actionResult.Comment = "Фиктивных точек или достаточно, или они не требуются";
          }
          ++this.fictivPointCount;
          this.methodState = this.IsFictivePointsNeeded() ? State.connectedSegmentCreated : State.pointsReady;
          break;
        case (byte) 15:
          actionResult.Accuracy = AccuracyType.no;
          if (this.IsPointRigth((double) act.Parameters[0], (double) act.Parameters[1], out errKeys) && this.IsFictiveFuncValueRight((double) act.Parameters[1], (bool) act.Parameters[3], (double) act.Parameters[4], (bool) act.Parameters[5], (double) act.Parameters[6]))
            actionResult.Accuracy = AccuracyType.yes;
          actionResult.ErrorKeys = errKeys;
          break;
      }
      return actionResult;
    }

    private bool IsFictivePointsNeeded()
    {
      int num1 = 2 + this._points.Length + this.fictivPointCount;
      int n = 0;
      int num2;
      do
      {
        num2 = Fibonacci.FibNumber(n);
        ++n;
      }
      while (num2 < num1 - 1);
      return num2 != num1 - 1;
    }

    private bool IsPointRigth(double coord, double funcVal, out ArrayList errKeys)
    {
      errKeys = new ArrayList();
      bool flag = false;
      if (0.0 <= coord && coord <= (double) (2 + this._points.Length + this.fictivPointCount - 1))
      {
        if (Math.Abs(0.0 - coord) > Constants.DoublePrecision)
        {
          if (Math.Abs((double) (2 + this._points.Length + this.fictivPointCount - 1) - coord) > Constants.DoublePrecision)
          {
            if (this.methodState == State.pointsReady)
            {
              int num1 = 2 + this._points.Length + this.fictivPointCount - 1;
              this.leftFront = 0.0;
              this.rightFront = (double) num1;
              int n = 0;
              while (num1 > Fibonacci.FibNumber(n))
                ++n;
              int num2 = Fibonacci.FibNumber(n - 1);
              if (Math.Abs(this.leftFront + (double) num2 - coord) < Constants.DoublePrecision || Math.Abs(this.rightFront - (double) num2 - coord) < Constants.DoublePrecision)
              {
                flag = true;
                this.prevTestValue = funcVal;
                this.prevTest = coord;
              }
              else
                errKeys.Add((object) 7);
            }
            else if (this.methodState == State.normal)
            {
              if (this.isDouble)
              {
                if (coord >= this.rightFront)
                {
                  double num = this.prevTest - this.leftFront;
                  this.leftFront = this.prevTest;
                  this.prevTest = this.rightFront;
                  this.rightFront = this.rightFront + num;
                }
                this.isDouble = false;
              }
              if (Math.Abs(coord - (this.leftFront + this.rightFront - this.prevTest)) < Constants.DoublePrecision)
              {
                flag = true;
                if (this.prevTest < coord)
                {
                  double num1 = coord;
                  coord = this.prevTest;
                  this.prevTest = num1;
                  double num2 = funcVal;
                  funcVal = this.prevTestValue;
                  this.prevTestValue = num2;
                }
                if (Math.Abs(funcVal - this.prevTestValue) < Constants.DoublePrecision)
                {
                  this.isDouble = true;
                  this.rightFront = this.prevTest;
                  this.prevTest = coord;
                }
                else if (this._extType == ExtremumType.min)
                {
                  if (funcVal < this.prevTestValue)
                  {
                    this.rightFront = this.prevTest;
                    this.prevTest = coord;
                    this.prevTestValue = funcVal;
                  }
                  else
                    this.leftFront = coord;
                }
                else if (funcVal < this.prevTestValue)
                {
                  this.leftFront = coord;
                }
                else
                {
                  this.rightFront = this.prevTest;
                  this.prevTest = coord;
                  this.prevTestValue = funcVal;
                }
              }
              else
                errKeys.Add((object) 7);
            }
            else if (this.methodState == State.end)
            {
              flag = false;
              errKeys.Add((object) 6);
            }
          }
          else
          {
            flag = false;
            errKeys.Add((object) 4);
          }
        }
        else
        {
          flag = false;
          errKeys.Add((object) 4);
        }
      }
      else
      {
        flag = false;
        errKeys.Add((object) 5);
      }
      this.step = this.step + 1;
      if (this.methodState == State.pointsReady)
        this.methodState = State.normal;
      if (this.methodState == State.normal && (Math.Abs(this.prevTest - this.leftFront) < 1.0 - Constants.DoublePrecision || Math.Abs(this.prevTest - this.rightFront) < 1.0 - Constants.DoublePrecision))
        this.methodState = State.end;
      return flag;
    }

    private bool IsFictiveFuncValueRight(double funcValue, bool hasLeftValue, double leftValue, bool hasRightValue, double rightValue)
    {
      bool flag = false;
      if (this._extType == ExtremumType.max)
      {
        if ((!hasLeftValue || hasLeftValue && leftValue > funcValue) && (!hasRightValue || hasRightValue && rightValue < funcValue))
          flag = true;
      }
      else if ((!hasLeftValue || hasLeftValue && leftValue < funcValue) && (!hasRightValue || hasRightValue && rightValue > funcValue))
        flag = true;
      return flag;
    }

    public override bool IsOver()
    {
      return this.isOver;
    }
  }
}
