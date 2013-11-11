// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.HungTableControl
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public sealed class HungTableControl : UserControl
  {
    private int _textH = 20;
    private int _textW = 30;
    private int _maxTextLength = 3;
    private int _textSpacing = 3;
    private int _pnlSpacing = 5;
    private ElementBox[] _textBoxAA = (ElementBox[]) null;
    private ElementBox[] _textBoxBB = (ElementBox[]) null;
    private ElementBox[,] _textBoxCD = (ElementBox[,]) null;
    private bool _readOnly = false;
    private bool _selectable = true;
    private bool _isSetResult = false;
    private Container components = (Container) null;
    private uint _dimH;
    private uint _dimV;
    private HungTable _ht;
    private Panel pnlOuter;
    private Panel pnlTop;
    private Panel pnlInner;
    private Panel pnlLeft;

    public bool ReadOnly
    {
      get
      {
        return this._readOnly;
      }
      set
      {
        this._readOnly = value;
        this.pnlOuter.Enabled = !this._readOnly;
      }
    }

    public bool Selectable
    {
      get
      {
        return this._selectable;
      }
      set
      {
        this._selectable = value;
      }
    }

    public bool IsSetResult
    {
      get
      {
        return this._isSetResult;
      }
      set
      {
        this._isSetResult = value;
        if (this._textBoxAA != null)
        {
          for (int index = 0; (long) index < (long) this._dimV; ++index)
            this._textBoxAA[index].ReadOnly = this._isSetResult;
        }
        if (this._textBoxBB == null)
          return;
        for (int index = 0; (long) index < (long) this._dimH; ++index)
          this._textBoxBB[index].ReadOnly = this._isSetResult;
      }
    }

    public event HungTableControl.ValueAAChangedHandler ValueAAChanged;

    public event HungTableControl.ValueBBChangedHandler ValueBBChanged;

    public event HungTableControl.ValueCDChangedHandler ValueCDChanged;

    public event HungTableControl.SelectionCDChangedHandler SelectionCDChanged;

    public HungTableControl()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.pnlOuter = new Panel();
      this.pnlLeft = new Panel();
      this.pnlTop = new Panel();
      this.pnlInner = new Panel();
      this.pnlOuter.SuspendLayout();
      this.SuspendLayout();
      this.pnlOuter.BorderStyle = BorderStyle.FixedSingle;
      this.pnlOuter.Controls.Add((Control) this.pnlLeft);
      this.pnlOuter.Controls.Add((Control) this.pnlTop);
      this.pnlOuter.Controls.Add((Control) this.pnlInner);
      this.pnlOuter.Dock = DockStyle.Fill;
      this.pnlOuter.Location = new Point(0, 0);
      this.pnlOuter.Name = "pnlOuter";
      this.pnlOuter.Size = new Size(80, 80);
      this.pnlOuter.TabIndex = 0;
      this.pnlLeft.BorderStyle = BorderStyle.FixedSingle;
      this.pnlLeft.Location = new Point(8, 32);
      this.pnlLeft.Name = "pnlLeft";
      this.pnlLeft.Size = new Size(16, 40);
      this.pnlLeft.TabIndex = 1;
      this.pnlTop.BorderStyle = BorderStyle.FixedSingle;
      this.pnlTop.Location = new Point(32, 8);
      this.pnlTop.Name = "pnlTop";
      this.pnlTop.Size = new Size(40, 16);
      this.pnlTop.TabIndex = 0;
      this.pnlInner.BorderStyle = BorderStyle.FixedSingle;
      this.pnlInner.Location = new Point(32, 32);
      this.pnlInner.Name = "pnlInner";
      this.pnlInner.Size = new Size(40, 40);
      this.pnlInner.TabIndex = 2;
      this.Controls.Add((Control) this.pnlOuter);
      this.Name = "HungTableControl";
      this.Size = new Size(80, 80);
      this.pnlOuter.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public void Subscribe(HungTable ht)
    {
      if (this._ht != null)
        this.Unsubscribe(this._ht);
      this._ht = ht;
      for (uint i = 0U; i < ht.DimV; ++i)
      {
        this.SetValAA(i, ht.GetValAA(i));
        for (uint j = 0U; j < ht.DimH; ++j)
        {
          if ((int) i == 0)
            this.SetValBB(j, ht.GetValBB(j));
          this.SetValCD(i, j, ht.GetValCD(i, j));
          this.SetSelCD(i, j, ht.GetSelection(i, j));
        }
      }
      ht.ValueAAChanged += new HungTable.ValueAAChangedHandler(this.ht_ValueAAChanged);
      ht.ValueBBChanged += new HungTable.ValueBBChangedHandler(this.ht_ValueBBChanged);
      ht.ValueCDChanged += new HungTable.ValueCDChangedHandler(this.ht_ValueCDChanged);
      ht.SelectionCDChanged += new HungTable.SelectionCDChangedHandler(this.ht_SelectionCDChanged);
    }

    public void Unsubscribe(HungTable ht)
    {
      ht.ValueAAChanged -= new HungTable.ValueAAChangedHandler(this.ht_ValueAAChanged);
      ht.ValueBBChanged -= new HungTable.ValueBBChangedHandler(this.ht_ValueBBChanged);
      ht.ValueCDChanged -= new HungTable.ValueCDChangedHandler(this.ht_ValueCDChanged);
      ht.SelectionCDChanged -= new HungTable.SelectionCDChangedHandler(this.ht_SelectionCDChanged);
    }

    public void SetDimensions(uint v, uint h)
    {
      if (this._textBoxAA != null && this._textBoxBB != null && this._textBoxCD != null)
      {
        for (int index1 = 0; (long) index1 < (long) this._dimV; ++index1)
        {
          if (this._textBoxAA[index1] != null)
            this.RemoveTextBox(this._textBoxAA[index1]);
          for (int index2 = 0; (long) index2 < (long) this._dimH; ++index2)
          {
            if (index1 == 0 && this._textBoxBB[index2] != null)
              this.RemoveTextBox(this._textBoxBB[index2]);
            if (this._textBoxCD[index1, index2] != null)
              this.RemoveTextBox(this._textBoxCD[index1, index2]);
          }
        }
      }
      this._dimH = h;
      this._dimV = v;
      this._textBoxAA = new ElementBox[(uint) this._dimV];
      this._textBoxBB = new ElementBox[(uint) this._dimH];
      this._textBoxCD = new ElementBox[(int) (IntPtr) this._dimV, (int) (IntPtr) this._dimH];
      this.SetSize();
      this.CreateEBox();
    }

    private void SetSize()
    {
      this.Width = (int) ((long) (1 + 3 * this._pnlSpacing + (this._textSpacing + this._textW + this._textSpacing)) + ((long) this._textSpacing + (long) this._dimH * (long) (this._textW + this._textSpacing)) + 1L);
      this.Height = (int) ((long) (1 + 3 * this._pnlSpacing + (this._textSpacing + this._textH + this._textSpacing)) + ((long) this._textSpacing + (long) this._dimV * (long) (this._textH + this._textSpacing)) + 1L);
      this.pnlOuter.Top = 1;
      this.pnlOuter.Left = 1;
      this.pnlOuter.Width = (int) ((long) (3 * this._pnlSpacing + (this._textSpacing + this._textW + this._textSpacing)) + ((long) this._textSpacing + (long) this._dimH * (long) (this._textW + this._textSpacing)));
      this.pnlOuter.Height = (int) ((long) (3 * this._pnlSpacing + (this._textSpacing + this._textH + this._textSpacing)) + ((long) this._textSpacing + (long) this._dimV * (long) (this._textH + this._textSpacing)));
      this.pnlInner.Top = this._pnlSpacing + (this._textSpacing + this._textH + this._textSpacing) + this._pnlSpacing;
      this.pnlInner.Left = this._pnlSpacing + (this._textSpacing + this._textW + this._textSpacing) + this._pnlSpacing;
      this.pnlInner.Height = (int) ((long) this._textSpacing + (long) this._dimV * (long) (this._textH + this._textSpacing));
      this.pnlInner.Width = (int) ((long) this._textSpacing + (long) this._dimH * (long) (this._textW + this._textSpacing));
      this.pnlTop.Top = this._pnlSpacing;
      this.pnlTop.Left = this._pnlSpacing + (this._textSpacing + this._textW + this._textSpacing) + this._pnlSpacing;
      this.pnlTop.Height = this._textSpacing + (this._textH + this._textSpacing);
      this.pnlTop.Width = (int) ((long) this._textSpacing + (long) this._dimH * (long) (this._textW + this._textSpacing));
      this.pnlLeft.Top = this._pnlSpacing + (this._textSpacing + this._textH + this._textSpacing) + this._pnlSpacing;
      this.pnlLeft.Left = this._pnlSpacing;
      this.pnlLeft.Height = (int) ((long) this._textSpacing + (long) this._dimV * (long) (this._textH + this._textSpacing));
      this.pnlLeft.Width = this._textSpacing + (this._textW + this._textSpacing);
    }

    private ElementBox GetTextBox(uint type, uint i, uint j)
    {
      ElementBox elementBox = new ElementBox();
      elementBox.Leave += new EventHandler(this.tb_Leave);
      elementBox.KeyPress += new KeyPressEventHandler(this.tb_KeyPress);
      elementBox.DoubleClick += new EventHandler(this.tb_DoubleClick);
      elementBox.Width = this._textW;
      elementBox.Height = this._textH;
      elementBox.MaxLength = this._maxTextLength;
      elementBox.BorderStyle = BorderStyle.Fixed3D;
      elementBox.TextAlign = HorizontalAlignment.Right;
      elementBox.Text = "0";
      switch (type)
      {
        case 0U:
          this.pnlLeft.Controls.Add((Control) elementBox);
          elementBox.Element = (ElementBase) new ElementAA(i, 0);
          break;
        case 1U:
          this.pnlTop.Controls.Add((Control) elementBox);
          elementBox.Element = (ElementBase) new ElementBB(j, 0);
          break;
        case 2U:
          this.pnlInner.Controls.Add((Control) elementBox);
          elementBox.Element = (ElementBase) new ElementCD(i, j, 0, false);
          break;
      }
      elementBox.Top = (int) ((long) this._textSpacing + (long) i * (long) (this._textH + this._textSpacing));
      elementBox.Left = (int) ((long) this._textSpacing + (long) j * (long) (this._textW + this._textSpacing));
      elementBox.TabIndex = (int) this._dimH * (int) i + (int) j;
      return elementBox;
    }

    private void RemoveTextBox(ElementBox eb)
    {
      eb.Leave += new EventHandler(this.tb_Leave);
      eb.KeyPress += new KeyPressEventHandler(this.tb_KeyPress);
      eb.DoubleClick += new EventHandler(this.tb_DoubleClick);
      if (eb.Element.GetType() == typeof (ElementAA))
        this.pnlLeft.Controls.Remove((Control) eb);
      else if (eb.Element.GetType() == typeof (ElementBB))
      {
        this.pnlTop.Controls.Remove((Control) eb);
      }
      else
      {
        if (eb.Element.GetType() != typeof (ElementCD))
          return;
        this.pnlInner.Controls.Remove((Control) eb);
      }
    }

    private void CreateEBox()
    {
      for (uint i = 0U; i < this._dimV; ++i)
      {
        this._textBoxAA[(uint) i] = this.GetTextBox(0U, i, 0U);
        for (uint j = 0U; j < this._dimH; ++j)
        {
          if ((int) i == 0)
            this._textBoxBB[(uint) j] = this.GetTextBox(1U, 0U, j);
          this._textBoxCD[(int) (IntPtr) i, (int) (IntPtr) j] = this.GetTextBox(2U, i, j);
        }
      }
    }

    public void SetValAA(uint i, int val)
    {
      this._textBoxAA[(uint) i].Text = val.ToString();
    }

    public void SetValBB(uint j, int val)
    {
      this._textBoxBB[(uint) j].Text = val.ToString();
    }

    public void SetValCD(uint i, uint j, int val)
    {
      this._textBoxCD[(int) (IntPtr) i, (int) (IntPtr) j].Text = val.ToString();
    }

    public void SetSelCD(uint i, uint j, bool sel)
    {
      this._textBoxCD[(int) (IntPtr) i, (int) (IntPtr) j].IsSelect = sel;
    }

    private void tb_Leave(object sender, EventArgs e)
    {
      uint i = 0U;
      uint j = 0U;
      int num1 = int.MinValue;
      byte num2 = (byte) 0;
      if (((ElementBox) sender).Element.GetType() == typeof (ElementCD))
      {
        i = ((ElementCD) ((ElementBox) sender).Element).I;
        j = ((ElementCD) ((ElementBox) sender).Element).J;
        num1 = this._ht.GetValCD(i, j);
        num2 = (byte) 0;
      }
      else if (((ElementBox) sender).Element.GetType() == typeof (ElementAA))
      {
        i = ((ElementAA) ((ElementBox) sender).Element).I;
        num1 = this._ht.GetValAA(i);
        num2 = (byte) 1;
      }
      else if (((ElementBox) sender).Element.GetType() == typeof (ElementBB))
      {
        j = ((ElementBB) ((ElementBox) sender).Element).J;
        num1 = this._ht.GetValBB(j);
        num2 = (byte) 2;
      }
      int val;
      try
      {
        val = int.Parse(((Control) sender).Text);
      }
      catch
      {
        int num3 = (int) MessageBox.Show("Вы ввели неверное значение!\nВы можете задать только целое число!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        ((Control) sender).Text = num1.ToString();
        return;
      }
      if (num1 == val)
        return;
      if ((int) num2 == 0)
      {
        if (this.ValueCDChanged == null)
          return;
        this.ValueCDChanged(i, j, val);
      }
      else if ((int) num2 == 1)
      {
        if (this.ValueAAChanged == null)
          return;
        this.ValueAAChanged(i, val);
      }
      else
      {
        if ((int) num2 != 2 || this.ValueBBChanged == null)
          return;
        this.ValueBBChanged(j, val);
      }
    }

    private void tb_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((int) e.KeyChar != (int) Convert.ToChar(13))
        return;
      this.tb_Leave(sender, (EventArgs) null);
    }

    private void tb_DoubleClick(object sender, EventArgs e)
    {
      if (!this._selectable || ((ElementBox) sender).Element.GetType() != typeof (ElementCD) || this.SelectionCDChanged == null)
        return;
      this.SelectionCDChanged(((ElementCD) ((ElementBox) sender).Element).I, ((ElementCD) ((ElementBox) sender).Element).J, !((ElementBox) sender).IsSelect);
    }

    private void ht_ValueAAChanged(uint i, int val)
    {
      this.SetValAA(i, val);
    }

    private void ht_ValueBBChanged(uint j, int val)
    {
      this.SetValBB(j, val);
    }

    private void ht_ValueCDChanged(uint i, uint j, int val)
    {
      this.SetValCD(i, j, val);
    }

    private void ht_SelectionCDChanged(uint i, uint j, bool val)
    {
      this.SetSelCD(i, j, val);
    }

    public delegate void ValueAAChangedHandler(uint i, int val);

    public delegate void ValueBBChangedHandler(uint j, int val);

    public delegate void ValueCDChangedHandler(uint i, uint j, int val);

    public delegate void SelectionCDChangedHandler(uint i, uint j, bool val);
  }
}
