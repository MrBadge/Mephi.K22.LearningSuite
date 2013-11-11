// Type: Mephi.K22.LearningSuite.OneDSearch.TestDih
// Assembly: Mephi.K22.LearningSuite.OneDSearch, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A759670E-215D-48E9-9EE9-703E6D1ED21B
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.OneDSearch.Base;
using System;
using System.Collections;

namespace Mephi.K22.LearningSuite.OneDSearch
{
  public class TestDih : BaseTest
  {
    private readonly double _eps = 0.0;
    private readonly double _leftPoint = 0.0;
    private readonly double _rightPoint = 0.0;
    private readonly int _nmax = 0;
    internal State methodState = State.begin;
    internal int step = 0;
    internal double prevTest = 0.0;
    internal double prevTestValue = 0.0;
    internal double leftFront = 0.0;
    internal double rigthFront = 0.0;
    internal bool isDouble = false;
    internal bool isOver = false;
    private readonly ExtremumType _extType;
    private readonly DihTaskObject.StopTypeEnum _stopType;

    public override object[] InnerState
    {
      get
      {
        return new object[8]
        {
          (object) this.methodState,
          (object) this.step,
          (object) this.prevTest,
          (object) this.prevTestValue,
          (object) this.leftFront,
          (object) this.rigthFront,
          (object) (bool) this.isDouble,
          (object) (bool) this.isOver
        };
      }
      set
      {
        object[] objArray = value;
        this.methodState = (State) objArray[0];
        this.step = (int) objArray[1];
        this.prevTest = (double) objArray[2];
        this.prevTestValue = (double) objArray[3];
        this.leftFront = (double) objArray[4];
        this.rigthFront = (double) objArray[5];
        this.isDouble = (bool) objArray[6];
        this.isOver = (bool) objArray[7];
      }
    }

    public TestDih()
    {
    }

    public TestDih(double eps, double left, double right, ExtremumType eType, DihTaskObject.StopTypeEnum stopType, int maxStep)
    {
      this._eps = eps;
      this._leftPoint = left;
      this._rightPoint = right;
      this._extType = eType;
      this._stopType = stopType;
      this._nmax = maxStep;
      this.methodState = this._rightPoint - this._leftPoint >= eps ? State.begin : State.end;
      this.leftFront = this._leftPoint;
      this.rigthFront = this._rightPoint;
      if (this.rigthFront - this.leftFront >= this._eps + Constants.DoublePrecision)
        return;
      this.methodState = State.end;
    }

    public override BaseTest TestCopy()
    {
      return (BaseTest) new TestDih(this._eps, this._leftPoint, this._rightPoint, this._extType, this._stopType, this._nmax)
      {
        methodState = this.methodState,
        step = this.step,
        prevTest = this.prevTest,
        prevTestValue = this.prevTestValue,
        leftFront = this.leftFront,
        rigthFront = this.rigthFront,
        isOver = this.isOver,
        isDouble = this.isDouble
      };
    }

    public override ActionResult TestAction(Action act)
    {
      ActionResult actionResult = new ActionResult();
      ArrayList errKeys = new ArrayList();
      switch (act.ActionType)
      {
        case (byte) 0:
          actionResult.Accuracy = AccuracyType.notSpecified;
          break;
        case (byte) 1:
          actionResult.Accuracy = AccuracyType.notSpecified;
          break;
        case (byte) 2:
          actionResult.Accuracy = AccuracyType.notSpecified;
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
          actionResult.Accuracy = AccuracyType.notSpecified;
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
          if (this._stopType == DihTaskObject.StopTypeEnum.steps && this.step == 2 * this._nmax || this._stopType == DihTaskObject.StopTypeEnum.precise && Math.Abs(this.rigthFront - this.leftFront) < this._eps)
          {
            if (this.IsResultRight((double) act.Parameters[0], (double) act.Parameters[1]))
            {
              actionResult.Accuracy = AccuracyType.yes;
            }
            else
            {
              errKeys.Add((object) 5);
              actionResult.Accuracy = AccuracyType.no;
            }
          }
          else
          {
            errKeys.Add((object) 5);
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
          actionResult.Accuracy = AccuracyType.notSpecified;
          break;
      }
      return actionResult;
    }

    private bool IsPointRigth(double coord, double funcVal, out ArrayList errKeys)
    {
      errKeys = new ArrayList();
      bool flag = false;
      if (this._leftPoint <= coord && coord <= this._rightPoint)
      {
        if (Math.Abs(this._leftPoint - coord) > Constants.DoublePrecision)
        {
          if (Math.Abs(this._rightPoint - coord) > Constants.DoublePrecision)
          {
            if (this.methodState == State.begin || this.methodState == State.normal)
            {
              if (this.step % 2 == 0)
              {
                if (this.isDouble)
                {
                  if (coord >= (this.leftFront + this.rigthFront) / 2.0)
                  {
                    double num = this.leftFront;
                    this.leftFront = this.rigthFront - this._eps;
                    this.rigthFront = 2.0 * this.rigthFront - num - this._eps;
                  }
                  this.isDouble = false;
                }
                if (Math.Abs(coord - ((this.leftFront + this.rigthFront) / 2.0 - this._eps / 2.0)) < Constants.DoublePrecision || Math.Abs(coord - ((this.leftFront + this.rigthFront) / 2.0 + this._eps / 2.0)) < Constants.DoublePrecision)
                  flag = true;
                else
                  errKeys.Add((object) 1);
              }
              else if ((Math.Abs(coord - ((this.leftFront + this.rigthFront) / 2.0 - this._eps / 2.0)) < Constants.DoublePrecision || Math.Abs(coord - ((this.leftFront + this.rigthFront) / 2.0 + this._eps / 2.0)) < Constants.DoublePrecision) && Math.Abs(coord - this.prevTest) > Constants.DoublePrecision)
              {
                flag = true;
                if (Math.Abs(funcVal - this.prevTestValue) < Constants.DoublePrecision)
                {
                  this.isDouble = true;
                  this.rigthFront = (this.leftFront + this.rigthFront) / 2.0 + this._eps / 2.0;
                }
                else
                {
                  if (this.prevTest < coord)
                  {
                    double num1 = coord;
                    coord = this.prevTest;
                    this.prevTest = num1;
                    double num2 = funcVal;
                    funcVal = this.prevTestValue;
                    this.prevTestValue = num2;
                  }
                  if (this._extType == ExtremumType.min)
                  {
                    if (funcVal < this.prevTestValue)
                      this.rigthFront = (this.leftFront + this.rigthFront) / 2.0 + this._eps / 2.0;
                    else
                      this.leftFront = (this.leftFront + this.rigthFront) / 2.0 - this._eps / 2.0;
                  }
                  else if (funcVal < this.prevTestValue)
                    this.leftFront = (this.leftFront + this.rigthFront) / 2.0 - this._eps / 2.0;
                  else
                    this.rigthFront = (this.leftFront + this.rigthFront) / 2.0 + this._eps / 2.0;
                }
              }
              else
                errKeys.Add((object) 1);
            }
            else if (this.methodState == State.end)
              errKeys.Add((object) 3);
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
      this.prevTestValue = funcVal;
      this.prevTest = coord;
      this.step = this.step + 1;
      if (this.methodState == State.begin)
        this.methodState = State.normal;
      if (this.methodState == State.normal && (this._stopType == DihTaskObject.StopTypeEnum.steps && this.step >= 2 * this._nmax || this._stopType == DihTaskObject.StopTypeEnum.precise && Math.Abs(this.rigthFront - this.leftFront + Constants.DoublePrecision) < this._eps))
        this.methodState = State.end;
      return flag;
    }

    private bool IsResultRight(double left, double right)
    {
      if (this.isDouble)
      {
        double num1 = this.rigthFront - this._eps;
        double num2 = 2.0 * this.rigthFront - this.leftFront - this._eps;
        return Math.Abs(this.leftFront - left) < Constants.DoublePrecision && Math.Abs(this.rigthFront - right) < Constants.DoublePrecision || Math.Abs(num1 - left) < Constants.DoublePrecision && Math.Abs(num2 - right) < Constants.DoublePrecision;
      }
      else
        return Math.Abs(this.leftFront - left) < Constants.DoublePrecision && Math.Abs(this.rigthFront - right) < Constants.DoublePrecision;
    }

    public override bool IsOver()
    {
      return this.isOver;
    }
  }
}
