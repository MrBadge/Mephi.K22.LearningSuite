// Type: Mephi.K22.LearningSuite.OneDSearch.TestPaul
// Assembly: Mephi.K22.LearningSuite.OneDSearch, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A759670E-215D-48E9-9EE9-703E6D1ED21B
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.OneDSearch.Base;
using System;
using System.Collections;

namespace Mephi.K22.LearningSuite.OneDSearch
{
  public class TestPaul : BaseTest
  {
    private readonly double _eps = 0.0;
    private readonly double _leftPoint = 0.0;
    private readonly double _rightPoint = 0.0;
    private readonly int _nmax = 0;
    internal State methodState = State.begin;
    internal int step = 0;
    internal double[] prevTests = new double[4];
    internal double[] prevTestVals = new double[4];
    internal bool isDouble = false;
    internal bool isOver = false;
    private readonly ExtremumType _extType;

    public override object[] InnerState
    {
      get
      {
        object[] objArray = new object[12];
        objArray[0] = (object) this.methodState;
        objArray[1] = (object) this.step;
        for (int index = 0; index < 4; ++index)
        {
          objArray[2 + index] = (object) this.prevTests[index];
          objArray[6 + index] = (object) this.prevTestVals[index];
        }
        objArray[10] = (object) this.isDouble;
        objArray[11] = (object) this.isOver;
        return objArray;
      }
      set
      {
        object[] objArray = value;
        this.methodState = (State) objArray[0];
        this.step = (int) objArray[1];
        for (int index = 0; index < 4; ++index)
        {
          this.prevTests[index] = (double) objArray[2 + index];
          this.prevTestVals[index] = (double) objArray[6 + index];
        }
        this.isDouble = (bool) objArray[10];
        this.isOver = (bool) objArray[11];
      }
    }

    public TestPaul()
    {
    }

    public TestPaul(double eps, double left, double right, ExtremumType eType, int maxStep)
    {
      this._eps = eps;
      this._leftPoint = left;
      this._rightPoint = right;
      this._extType = eType;
      this._nmax = maxStep;
      this.methodState = State.begin;
    }

    public override BaseTest TestCopy()
    {
      TestPaul testPaul = new TestPaul(this._eps, this._leftPoint, this._rightPoint, this._extType, this._nmax);
      testPaul.methodState = this.methodState;
      testPaul.step = this.step;
      testPaul.isDouble = this.isDouble;
      testPaul.isOver = this.isOver;
      for (int index = 0; index < 4; ++index)
      {
        testPaul.prevTests[index] = this.prevTests[index];
        testPaul.prevTestVals[index] = this.prevTestVals[index];
      }
      return (BaseTest) testPaul;
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
          if (this.IsResultRight((double) act.Parameters[0]))
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
      bool flag1 = false;
      if (this.methodState == State.begin || this.methodState == State.normal)
      {
        if (this.step <= 2)
        {
          if (this.methodState == State.begin)
          {
            flag1 = true;
          }
          else
          {
            flag1 = true;
            for (int index = 0; index < this.step; ++index)
            {
              if (Math.Abs(this.prevTests[index] - coord) < this._eps)
              {
                flag1 = false;
                break;
              }
            }
          }
          this.prevTests[this.step] = coord;
          this.prevTestVals[this.step] = funcVal;
        }
        else
        {
          double num1 = double.MinValue;
          if (this.isDouble)
            num1 = Paul.FuncPaul(this.prevTests[0], this.prevTests[1], this.prevTests[3], this.prevTestVals[0], this.prevTestVals[1], this.prevTestVals[3]);
          double num2 = Paul.FuncPaul(this.prevTests[0], this.prevTests[1], this.prevTests[2], this.prevTestVals[0], this.prevTestVals[1], this.prevTestVals[2]);
          if (Math.Abs(coord - num2) < Constants.DoublePrecision || Math.Abs(coord - num1) < Constants.DoublePrecision)
          {
            this.isDouble = false;
            flag1 = true;
            bool flag2 = false;
            for (int index = 0; index < 3; ++index)
            {
              if (Math.Abs(this.prevTests[index] - coord) < this._eps)
              {
                flag2 = true;
                break;
              }
            }
            if (flag2)
            {
              flag1 = false;
              errKeys.Add((object) 3);
            }
            this.prevTests[3] = coord;
            this.prevTestVals[3] = funcVal;
            for (int index1 = 0; index1 < this.prevTestVals.Length; ++index1)
            {
              for (int index2 = this.prevTestVals.Length - 1; index2 >= 1; --index2)
              {
                if (this._extType == ExtremumType.min && this.prevTestVals[index2] < this.prevTestVals[index2 - 1] || this._extType == ExtremumType.max && this.prevTestVals[index2] > this.prevTestVals[index2 - 1])
                {
                  double num3 = this.prevTestVals[index2];
                  this.prevTestVals[index2] = this.prevTestVals[index2 - 1];
                  this.prevTestVals[index2 - 1] = num3;
                  double num4 = this.prevTests[index2];
                  this.prevTests[index2] = this.prevTests[index2 - 1];
                  this.prevTests[index2 - 1] = num4;
                }
              }
            }
            if (Math.Abs(this.prevTestVals[3] - this.prevTestVals[2]) < Constants.DoublePrecision)
              this.isDouble = true;
          }
          else
            flag1 = false;
        }
      }
      else if (this.methodState == State.end)
        errKeys.Add((object) 3);
      this.step = this.step + 1;
      if (this.methodState == State.begin)
        this.methodState = State.normal;
      return flag1;
    }

    private bool IsResultRight(double coord)
    {
      double num1 = double.MinValue;
      if (this.isDouble)
        num1 = Paul.FuncPaul(this.prevTests[0], this.prevTests[1], this.prevTests[3], this.prevTestVals[0], this.prevTestVals[1], this.prevTestVals[3]);
      double num2 = Paul.FuncPaul(this.prevTests[0], this.prevTests[1], this.prevTests[2], this.prevTestVals[0], this.prevTestVals[1], this.prevTestVals[2]);
      bool flag = false;
      for (int index = 0; index < 4; ++index)
      {
        if (Math.Abs(this.prevTests[index] - num2) < this._eps || Math.Abs(this.prevTests[index] - num1) < this._eps)
        {
          flag = true;
          break;
        }
      }
      if (!flag)
        return false;
      for (int index1 = 0; index1 < this.prevTestVals.Length; ++index1)
      {
        for (int index2 = this.prevTestVals.Length - 1; index2 >= 1; --index2)
        {
          if (this._extType == ExtremumType.min && this.prevTestVals[index2] < this.prevTestVals[index2 - 1] || this._extType == ExtremumType.max && this.prevTestVals[index2] > this.prevTestVals[index2 - 1])
          {
            double num3 = this.prevTestVals[index2];
            this.prevTestVals[index2] = this.prevTestVals[index2 - 1];
            this.prevTestVals[index2 - 1] = num3;
            double num4 = this.prevTests[index2];
            this.prevTests[index2] = this.prevTests[index2 - 1];
            this.prevTests[index2 - 1] = num4;
          }
        }
      }
      return Math.Abs(coord - this.prevTests[0]) < Constants.DoublePrecision;
    }

    public override bool IsOver()
    {
      return this.isOver;
    }
  }
}
