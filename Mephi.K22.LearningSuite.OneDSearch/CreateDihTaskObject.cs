// Type: Mephi.K22.LearningSuite.OneDSearch.CreateDihTaskObject
// Assembly: Mephi.K22.LearningSuite.OneDSearch, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A759670E-215D-48E9-9EE9-703E6D1ED21B
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.OneDSearch.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.OneDSearch
{
  public class CreateDihTaskObject : BaseTaskObjectControl
  {
    private Container components = (Container) null;
    private Label lblSegment;
    private TextBox tbSegStart;
    private TextBox tbSegEnd;
    private Label label1;
    private Label label2;
    private Label label3;
    private Button button1;
    private TextBox tbFunc;
    private Label label5;
    private TextBox tbEps;
    private RadioButton rbMin;
    private TextBox textBox1;
    private Label label4;
    private TextBox tbName;
    private RadioButton rbMax;
    private GroupBox groupBox1;
    private RadioButton rbPrecise;
    private RadioButton rbCount;
    private TextBox tbStepCount;

    public CreateDihTaskObject(DihTaskObject to)
    {
      this.InitializeComponent();
      if (to == null)
        return;
      this.tbName.Text = to.Name;
      this.tbEps.Text = to.Epsilon.ToString(Constants.DefaultDoubleFormat);
      this.tbFunc.Text = to.FuncText;
      this.tbSegEnd.Text = to.Right.ToString(Constants.DefaultDoubleFormat);
      this.tbSegStart.Text = to.Left.ToString(Constants.DefaultDoubleFormat);
      if (to.ExtremumType == ExtremumType.max)
      {
        this.rbMin.Checked = false;
        this.rbMax.Checked = true;
      }
      else
      {
        this.rbMin.Checked = true;
        this.rbMax.Checked = false;
      }
      if (to.StopType == DihTaskObject.StopTypeEnum.precise)
      {
        this.rbCount.Checked = false;
        this.rbPrecise.Checked = true;
      }
      else
      {
        this.rbCount.Checked = true;
        this.rbPrecise.Checked = false;
      }
      this.tbStepCount.Text = to.MaxSteps.ToString();
    }

    public CreateDihTaskObject(DihTaskObject to, bool enableEdit)
    {
      this.InitializeComponent();
      if (to != null)
      {
        this.tbName.Text = to.Name;
        this.tbEps.Text = to.Epsilon.ToString(Constants.DefaultDoubleFormat);
        this.tbFunc.Text = to.FuncText;
        this.tbSegEnd.Text = to.Right.ToString(Constants.DefaultDoubleFormat);
        this.tbSegStart.Text = to.Left.ToString(Constants.DefaultDoubleFormat);
        if (to.ExtremumType == ExtremumType.max)
        {
          this.rbMin.Checked = false;
          this.rbMax.Checked = true;
        }
        else
        {
          this.rbMin.Checked = true;
          this.rbMax.Checked = false;
        }
        if (to.StopType == DihTaskObject.StopTypeEnum.precise)
        {
          this.rbCount.Checked = false;
          this.rbPrecise.Checked = true;
        }
        else
        {
          this.rbCount.Checked = true;
          this.rbPrecise.Checked = false;
        }
        this.tbStepCount.Text = to.MaxSteps.ToString();
      }
      this.tbName.ReadOnly = this.tbSegStart.ReadOnly = this.tbSegEnd.ReadOnly = this.tbEps.ReadOnly = this.tbFunc.ReadOnly = true;
      this.tbFunc.PasswordChar = '$';
      this.rbMax.Enabled = this.rbMin.Enabled = this.button1.Enabled = this.textBox1.Enabled = false;
      this.rbPrecise.Enabled = this.rbCount.Enabled = false;
      this.tbStepCount.ReadOnly = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.lblSegment = new Label();
      this.tbSegStart = new TextBox();
      this.tbSegEnd = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.tbFunc = new TextBox();
      this.button1 = new Button();
      this.label5 = new Label();
      this.tbEps = new TextBox();
      this.rbMin = new RadioButton();
      this.rbMax = new RadioButton();
      this.textBox1 = new TextBox();
      this.label4 = new Label();
      this.tbName = new TextBox();
      this.groupBox1 = new GroupBox();
      this.rbPrecise = new RadioButton();
      this.tbStepCount = new TextBox();
      this.rbCount = new RadioButton();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.lblSegment.Location = new System.Drawing.Point(0, 68);
      this.lblSegment.Name = "lblSegment";
      this.lblSegment.Size = new Size(120, 20);
      this.lblSegment.TabIndex = 2;
      this.lblSegment.Text = "Начальный интервал";
      this.lblSegment.TextAlign = ContentAlignment.MiddleLeft;
      this.tbSegStart.Location = new System.Drawing.Point(124, 68);
      this.tbSegStart.Name = "tbSegStart";
      this.tbSegStart.Size = new Size(124, 20);
      this.tbSegStart.TabIndex = 3;
      this.tbSegStart.Text = "";
      this.tbSegStart.TextAlign = HorizontalAlignment.Right;
      this.tbSegEnd.Location = new System.Drawing.Point(272, 68);
      this.tbSegEnd.Name = "tbSegEnd";
      this.tbSegEnd.Size = new Size(124, 20);
      this.tbSegEnd.TabIndex = 5;
      this.tbSegEnd.Text = "";
      this.tbSegEnd.TextAlign = HorizontalAlignment.Right;
      this.label1.Location = new System.Drawing.Point(252, 68);
      this.label1.Name = "label1";
      this.label1.Size = new Size(16, 20);
      this.label1.TabIndex = 4;
      this.label1.Text = "-";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.label2.Location = new System.Drawing.Point(0, 188);
      this.label2.Name = "label2";
      this.label2.Size = new Size(120, 20);
      this.label2.TabIndex = 8;
      this.label2.Text = "Тип экстремума";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.label3.Location = new System.Drawing.Point(0, 216);
      this.label3.Name = "label3";
      this.label3.Size = new Size(120, 20);
      this.label3.TabIndex = 11;
      this.label3.Text = "Целевая функция";
      this.label3.TextAlign = ContentAlignment.MiddleLeft;
      this.tbFunc.Location = new System.Drawing.Point(124, 216);
      this.tbFunc.Name = "tbFunc";
      this.tbFunc.Size = new Size(196, 20);
      this.tbFunc.TabIndex = 12;
      this.tbFunc.Text = "";
      this.button1.Location = new System.Drawing.Point(324, 216);
      this.button1.Name = "button1";
      this.button1.Size = new Size(72, 20);
      this.button1.TabIndex = 13;
      this.button1.Text = "Проверить";
      this.button1.Click += new EventHandler(this.button1_Click);
      this.label5.Location = new System.Drawing.Point(0, 96);
      this.label5.Name = "label5";
      this.label5.Size = new Size(120, 20);
      this.label5.TabIndex = 6;
      this.label5.Text = "Epsilon";
      this.label5.TextAlign = ContentAlignment.MiddleLeft;
      this.tbEps.Location = new System.Drawing.Point(124, 96);
      this.tbEps.Name = "tbEps";
      this.tbEps.Size = new Size(272, 20);
      this.tbEps.TabIndex = 7;
      this.tbEps.Text = "";
      this.tbEps.TextAlign = HorizontalAlignment.Right;
      this.rbMin.Location = new System.Drawing.Point(128, 188);
      this.rbMin.Name = "rbMin";
      this.rbMin.Size = new Size(52, 20);
      this.rbMin.TabIndex = 9;
      this.rbMin.Text = "min";
      this.rbMax.Location = new System.Drawing.Point(184, 188);
      this.rbMax.Name = "rbMax";
      this.rbMax.Size = new Size(48, 20);
      this.rbMax.TabIndex = 10;
      this.rbMax.Text = "max";
      this.textBox1.BorderStyle = BorderStyle.None;
      this.textBox1.Location = new System.Drawing.Point(128, 240);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(124, 13);
      this.textBox1.TabIndex = 14;
      this.textBox1.Text = "аргумент функции: x[0]";
      this.label4.Location = new System.Drawing.Point(0, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(120, 20);
      this.label4.TabIndex = 0;
      this.label4.Text = "Описание";
      this.label4.TextAlign = ContentAlignment.MiddleLeft;
      this.tbName.Location = new System.Drawing.Point(124, 0);
      this.tbName.Multiline = true;
      this.tbName.Name = "tbName";
      this.tbName.Size = new Size(272, 60);
      this.tbName.TabIndex = 1;
      this.tbName.Text = "";
      this.groupBox1.Controls.Add((Control) this.rbPrecise);
      this.groupBox1.Controls.Add((Control) this.tbStepCount);
      this.groupBox1.Controls.Add((Control) this.rbCount);
      this.groupBox1.Location = new System.Drawing.Point(124, 120);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(272, 60);
      this.groupBox1.TabIndex = 15;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Критерий останова";
      this.rbPrecise.Location = new System.Drawing.Point(4, 36);
      this.rbPrecise.Name = "rbPrecise";
      this.rbPrecise.Size = new Size(120, 20);
      this.rbPrecise.TabIndex = 1;
      this.rbPrecise.Text = "Точность";
      this.rbPrecise.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
      this.tbStepCount.Location = new System.Drawing.Point(128, 16);
      this.tbStepCount.Name = "tbStepCount";
      this.tbStepCount.Size = new Size(140, 20);
      this.tbStepCount.TabIndex = 1;
      this.tbStepCount.Text = "";
      this.tbStepCount.TextAlign = HorizontalAlignment.Right;
      this.rbCount.Location = new System.Drawing.Point(4, 16);
      this.rbCount.Name = "rbCount";
      this.rbCount.Size = new Size(120, 20);
      this.rbCount.TabIndex = 0;
      this.rbCount.Text = "Количество шагов";
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.tbName);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.rbMax);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.tbEps);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.tbFunc);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.tbSegEnd);
      this.Controls.Add((Control) this.tbSegStart);
      this.Controls.Add((Control) this.lblSegment);
      this.Controls.Add((Control) this.rbMin);
      this.Name = "CreateDihTaskObject";
      this.Size = new Size(396, 260);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public override BaseTaskObject GetTaskObject()
    {
      DihTaskObject dihTaskObject = (DihTaskObject) null;
      try
      {
        dihTaskObject = new DihTaskObject(this.tbName.Text, double.Parse(this.tbSegStart.Text), double.Parse(this.tbSegEnd.Text), this.tbFunc.Text, double.Parse(this.tbEps.Text), this.rbMin.Checked ? ExtremumType.min : ExtremumType.max, this.rbPrecise.Checked ? DihTaskObject.StopTypeEnum.precise : DihTaskObject.StopTypeEnum.steps, int.Parse(this.tbStepCount.Text));
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
      return (BaseTaskObject) dihTaskObject;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Function.Test(this.tbFunc.Text);
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
    }
  }
}
