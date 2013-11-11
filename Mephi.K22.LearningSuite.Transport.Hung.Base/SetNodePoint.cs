// Type: Mephi.K22.LearningSuite.Transport.Hung.Base.SetNodePoint
// Assembly: Mephi.K22.LearningSuite.Transport.Hung.Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC80F8F5-CA0E-46B8-8326-1307EB7CFB9A
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.Hung.Base.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Transport.Hung.Base
{
  public class SetNodePoint : Form
  {
    private int _factCount = 0;
    private int _consCount = 0;
    private bool _complete = false;
    private Container components = (Container) null;
    private Panel panel1;
    private Panel panel2;
    private Panel panel3;
    private GroupBox groupBox1;
    private Label label1;
    private Label label2;
    private Label label3;
    private GroupBox groupBox2;
    private Button btnSetPonts;
    private TextBox tbFactoryCount;
    private TextBox tbCustCount;
    private Button btnOk;
    internal ListBox lbNodes;
    internal ListBox lbPoint;
    internal ListBox lbCorresp;
    private Button btnUnset;
    private Button btnSet;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private Button btnCancel;

    public SetNodePoint()
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
      this.panel1 = new Panel();
      this.groupBox1 = new GroupBox();
      this.label1 = new Label();
      this.tbCustCount = new TextBox();
      this.label3 = new Label();
      this.tbFactoryCount = new TextBox();
      this.btnSetPonts = new Button();
      this.label2 = new Label();
      this.panel2 = new Panel();
      this.btnCancel = new Button();
      this.btnOk = new Button();
      this.panel3 = new Panel();
      this.groupBox2 = new GroupBox();
      this.textBox3 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox1 = new TextBox();
      this.btnUnset = new Button();
      this.btnSet = new Button();
      this.lbCorresp = new ListBox();
      this.lbPoint = new ListBox();
      this.lbNodes = new ListBox();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.groupBox1);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(502, 48);
      this.panel1.TabIndex = 0;
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.tbCustCount);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.tbFactoryCount);
      this.groupBox1.Controls.Add((Control) this.btnSetPonts);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(502, 48);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.label1.Location = new Point(12, 24);
      this.label1.Name = "label1";
      this.label1.Size = new Size(100, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "п. производства";
      this.label1.TextAlign = ContentAlignment.MiddleRight;
      this.tbCustCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.tbCustCount.Location = new Point(370, 24);
      this.tbCustCount.Name = "tbCustCount";
      this.tbCustCount.Size = new Size(48, 20);
      this.tbCustCount.TabIndex = 4;
      this.tbCustCount.Text = "0";
      this.tbCustCount.TextAlign = HorizontalAlignment.Right;
      this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label3.Location = new Point(266, 24);
      this.label3.Name = "label3";
      this.label3.Size = new Size(100, 20);
      this.label3.TabIndex = 3;
      this.label3.Text = "п. потребления";
      this.label3.TextAlign = ContentAlignment.MiddleRight;
      this.tbFactoryCount.Location = new Point(116, 24);
      this.tbFactoryCount.Name = "tbFactoryCount";
      this.tbFactoryCount.Size = new Size(48, 20);
      this.tbFactoryCount.TabIndex = 2;
      this.tbFactoryCount.Text = "0";
      this.tbFactoryCount.TextAlign = HorizontalAlignment.Right;
      this.btnSetPonts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSetPonts.Location = new Point(422, 24);
      this.btnSetPonts.Name = "btnSetPonts";
      this.btnSetPonts.Size = new Size(75, 20);
      this.btnSetPonts.TabIndex = 5;
      this.btnSetPonts.Text = "Задать";
      this.btnSetPonts.Click += new EventHandler(this.btnSetPonts_Click);
      this.label2.Location = new Point(4, 8);
      this.label2.Name = "label2";
      this.label2.Size = new Size(160, 20);
      this.label2.TabIndex = 0;
      this.label2.Text = "Количество";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.panel2.Controls.Add((Control) this.btnCancel);
      this.panel2.Controls.Add((Control) this.btnOk);
      this.panel2.Dock = DockStyle.Bottom;
      this.panel2.Location = new Point(0, 221);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(502, 28);
      this.panel2.TabIndex = 0;
      this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel.Location = new Point(340, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 20);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnOk.Location = new Point(422, 4);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(75, 20);
      this.btnOk.TabIndex = 0;
      this.btnOk.Text = "Ок";
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.panel3.Controls.Add((Control) this.groupBox2);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(0, 48);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(502, 173);
      this.panel3.TabIndex = 2;
      this.groupBox2.Controls.Add((Control) this.textBox3);
      this.groupBox2.Controls.Add((Control) this.textBox2);
      this.groupBox2.Controls.Add((Control) this.textBox1);
      this.groupBox2.Controls.Add((Control) this.btnUnset);
      this.groupBox2.Controls.Add((Control) this.btnSet);
      this.groupBox2.Controls.Add((Control) this.lbCorresp);
      this.groupBox2.Controls.Add((Control) this.lbPoint);
      this.groupBox2.Controls.Add((Control) this.lbNodes);
      this.groupBox2.Dock = DockStyle.Fill;
      this.groupBox2.Location = new Point(0, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(502, 173);
      this.groupBox2.TabIndex = 0;
      this.groupBox2.TabStop = false;
      this.textBox3.BorderStyle = BorderStyle.None;
      this.textBox3.Location = new Point(288, 8);
      this.textBox3.Name = "textBox3";
      this.textBox3.ReadOnly = true;
      this.textBox3.Size = new Size(208, 13);
      this.textBox3.TabIndex = 6;
      this.textBox3.Text = "соответствие";
      this.textBox3.TextAlign = HorizontalAlignment.Center;
      this.textBox2.BorderStyle = BorderStyle.None;
      this.textBox2.Location = new Point(88, 8);
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      this.textBox2.Size = new Size(116, 13);
      this.textBox2.TabIndex = 2;
      this.textBox2.Text = "пункт";
      this.textBox2.TextAlign = HorizontalAlignment.Center;
      this.textBox1.BorderStyle = BorderStyle.None;
      this.textBox1.Location = new Point(4, 8);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(80, 13);
      this.textBox1.TabIndex = 0;
      this.textBox1.Text = "вершина";
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.btnUnset.Location = new Point(208, 76);
      this.btnUnset.Name = "btnUnset";
      this.btnUnset.Size = new Size(75, 20);
      this.btnUnset.TabIndex = 5;
      this.btnUnset.Text = "<---";
      this.btnUnset.Click += new EventHandler(this.btnUnset_Click);
      this.btnSet.Location = new Point(208, 52);
      this.btnSet.Name = "btnSet";
      this.btnSet.Size = new Size(75, 20);
      this.btnSet.TabIndex = 4;
      this.btnSet.Text = "--->";
      this.btnSet.Click += new EventHandler(this.btnSet_Click);
      this.lbCorresp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lbCorresp.Location = new Point(288, 24);
      this.lbCorresp.Name = "lbCorresp";
      this.lbCorresp.Size = new Size(208, 147);
      this.lbCorresp.TabIndex = 7;
      this.lbPoint.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.lbPoint.Location = new Point(88, 24);
      this.lbPoint.Name = "lbPoint";
      this.lbPoint.Size = new Size(116, 147);
      this.lbPoint.TabIndex = 3;
      this.lbNodes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.lbNodes.Location = new Point(4, 24);
      this.lbNodes.Name = "lbNodes";
      this.lbNodes.Size = new Size(80, 147);
      this.lbNodes.TabIndex = 1;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(502, 249);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Name = "SetNodePoint";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Установите соответствие между вершинами и пунктами";
      this.Closing += new CancelEventHandler(this.SetNodePoint_Closing);
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void btnSetPonts_Click(object sender, EventArgs e)
    {
      try
      {
        this._factCount = int.Parse(this.tbFactoryCount.Text);
        this._consCount = int.Parse(this.tbCustCount.Text);
        this.SetFCCount(this._factCount, this._consCount, this.lbNodes.Items.Count);
      }
      catch
      {
        foreach (ItemNodePoint itemNodePoint in this.lbCorresp.Items)
        {
          this.lbNodes.Items.Add((object) itemNodePoint.Node);
          this.lbPoint.Items.Add((object) itemNodePoint.Point);
        }
        this.lbCorresp.Items.Clear();
      }
    }

    private void SetFCCount(int fc, int cc, int nc)
    {
      foreach (ItemNodePoint itemNodePoint in this.lbCorresp.Items)
      {
        this.lbNodes.Items.Add((object) itemNodePoint.Node);
        this.lbPoint.Items.Add((object) itemNodePoint.Point);
      }
      if (nc == fc + cc + 2 && cc > 0 && fc > 0)
      {
        this.lbCorresp.Items.Clear();
        this.lbPoint.Items.Clear();
        this.lbPoint.Items.Add((object) new ItemPoint(0, PointType.source));
        for (int index = 0; index < fc; ++index)
          this.lbPoint.Items.Add((object) new ItemPoint(index + 1, PointType.factory));
        for (int index = 0; index < cc; ++index)
          this.lbPoint.Items.Add((object) new ItemPoint(index + 1, PointType.consumer));
        this.lbPoint.Items.Add((object) new ItemPoint(0, PointType.target));
      }
      else
      {
        int num = (int) MessageBox.Show("Вы ввели неверно число пунктов!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
      }
    }

    private void btnSet_Click(object sender, EventArgs e)
    {
      if (this.lbNodes.SelectedItem == null || this.lbPoint.SelectedItem == null)
        return;
      ItemNode node = (ItemNode) this.lbNodes.SelectedItem;
      ItemPoint point = (ItemPoint) this.lbPoint.SelectedItem;
      this.lbCorresp.Items.Add((object) new ItemNodePoint(node, point));
      this.lbNodes.Items.Remove((object) node);
      this.lbPoint.Items.Remove((object) point);
    }

    private void btnUnset_Click(object sender, EventArgs e)
    {
      if (this.lbCorresp.SelectedItem == null)
        return;
      ItemNodePoint itemNodePoint = (ItemNodePoint) this.lbCorresp.SelectedItem;
      this.lbNodes.Items.Add((object) itemNodePoint.Node);
      this.lbPoint.Items.Add((object) itemNodePoint.Point);
      this.lbCorresp.Items.Remove((object) itemNodePoint);
    }

    private void SetNodePoint_Closing(object sender, CancelEventArgs e)
    {
      e.Cancel = !this._complete;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (this.lbNodes.Items.Count != 0 || this.lbPoint.Items.Count != 0)
        return;
      this._complete = true;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this._complete = true;
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
