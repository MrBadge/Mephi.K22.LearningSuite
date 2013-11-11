// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.HungTable
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

using System;
using System.Text;

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public class HungTable
  {
    private uint _dimH = 0U;
    private uint _dimV = 0U;
    private ElementAA[] _aa = (ElementAA[]) null;
    private ElementBB[] _bb = (ElementBB[]) null;
    private ElementCD[,] _cd = (ElementCD[,]) null;

    public uint DimH
    {
      get
      {
        return this._dimH;
      }
    }

    public uint DimV
    {
      get
      {
        return this._dimV;
      }
    }

    public event HungTable.ValueAAChangedHandler ValueAAChanged;

    public event HungTable.ValueBBChangedHandler ValueBBChanged;

    public event HungTable.ValueCDChangedHandler ValueCDChanged;

    public event HungTable.SelectionCDChangedHandler SelectionCDChanged;

    public HungTable(uint dimV, uint dimH)
    {
      this._dimH = dimH;
      this._dimV = dimV;
      this.InitDataContainers();
      this.InitData();
    }

    private void InitDataContainers()
    {
      this._aa = new ElementAA[(uint) this._dimV];
      this._bb = new ElementBB[(uint) this._dimH];
      this._cd = new ElementCD[(int) (IntPtr) this._dimV, (int) (IntPtr) this._dimH];
    }

    private void InitData()
    {
      for (uint i = 0U; i < this._dimV; ++i)
      {
        this._aa[(uint) i] = new ElementAA(i, 0);
        for (uint j = 0U; j < this._dimH; ++j)
        {
          if ((int) i == 0)
            this._bb[(uint) j] = new ElementBB(j, 0);
          this._cd[(int) (IntPtr) i, (int) (IntPtr) j] = new ElementCD(i, j, 0, false);
        }
      }
    }

    public void SetValAA(uint i, int a)
    {
      this._aa[(uint) i].Val = a;
      if (this.ValueAAChanged == null)
        return;
      this.ValueAAChanged(i, a);
    }

    public void SetValBB(uint j, int b)
    {
      this._bb[(uint) j].Val = b;
      if (this.ValueBBChanged == null)
        return;
      this.ValueBBChanged(j, b);
    }

    public void SetValCD(uint i, uint j, int cd)
    {
      this._cd[(int) (IntPtr) i, (int) (IntPtr) j].Val = cd;
      if (this.ValueCDChanged == null)
        return;
      this.ValueCDChanged(i, j, cd);
    }

    public void SetSelection(uint i, uint j, bool sel)
    {
      this._cd[(int) (IntPtr) i, (int) (IntPtr) j].IsSelected = sel;
      if (this.SelectionCDChanged == null)
        return;
      this.SelectionCDChanged(i, j, sel);
    }

    public int GetValAA(uint i)
    {
      return this._aa[(uint) i].Val;
    }

    public int GetValBB(uint j)
    {
      return this._bb[(uint) j].Val;
    }

    public int GetValCD(uint i, uint j)
    {
      return this._cd[(int) (IntPtr) i, (int) (IntPtr) j].Val;
    }

    public bool GetSelection(uint i, uint j)
    {
      return this._cd[(int) (IntPtr) i, (int) (IntPtr) j].IsSelected;
    }

    public string GetString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("{0} {1} ", (object) this.DimV, (object) this.DimH);
      for (uint i = 0U; i < this._dimV; ++i)
        stringBuilder.AppendFormat("{0} ", (object) this.GetValAA(i));
      for (uint j = 0U; j < this._dimH; ++j)
        stringBuilder.AppendFormat("{0} ", (object) this.GetValBB(j));
      for (uint i = 0U; i < this._dimV; ++i)
      {
        for (uint j = 0U; j < this._dimH; ++j)
          stringBuilder.AppendFormat("{0} {1} ", (object) this.GetValCD(i, j), (object) (this.GetSelection(i, j) ? 1 : 0));
      }
      return stringBuilder.ToString().Trim();
    }

    public static HungTable GetFromString(string s)
    {
      string[] strArray = s.Split(new char[1]
      {
        ' '
      });
      uint dimV = uint.Parse(strArray[0]);
      uint dimH = uint.Parse(strArray[1]);
      HungTable hungTable = new HungTable(dimV, dimH);
      for (uint i = 0U; i < dimV; ++i)
        hungTable.SetValAA(i, int.Parse(strArray[(uint) (2U + i)]));
      for (uint j = 0U; j < dimH; ++j)
        hungTable.SetValBB(j, int.Parse(strArray[(uint) (2U + dimV + j)]));
      for (uint i = 0U; i < dimV; ++i)
      {
        for (uint j = 0U; j < dimH; ++j)
        {
          hungTable.SetValCD(i, j, int.Parse(strArray[(uint) (uint) (2 + (int) dimV + (int) dimH + ((int) i * (int) dimH + (int) j) * 2)]));
          hungTable.SetSelection(i, j, strArray[(uint) (uint) (2 + (int) dimV + (int) dimH + ((int) i * (int) dimH + (int) j) * 2 + 1)] != "0");
        }
      }
      return hungTable;
    }

    public HungTable Clone()
    {
      HungTable hungTable = new HungTable(this._dimV, this._dimH);
      for (uint i = 0U; i < this._dimV; ++i)
      {
        hungTable.SetValAA(i, this.GetValAA(i));
        for (uint j = 0U; j < this._dimH; ++j)
        {
          if ((int) i == 0)
            hungTable.SetValBB(j, this.GetValBB(j));
          hungTable.SetValCD(i, j, this.GetValCD(i, j));
          hungTable.SetSelection(i, j, this.GetSelection(i, j));
        }
      }
      return hungTable;
    }

    public delegate void ValueAAChangedHandler(uint i, int val);

    public delegate void ValueBBChangedHandler(uint j, int val);

    public delegate void ValueCDChangedHandler(uint i, uint j, int val);

    public delegate void SelectionCDChangedHandler(uint i, uint j, bool val);
  }
}
