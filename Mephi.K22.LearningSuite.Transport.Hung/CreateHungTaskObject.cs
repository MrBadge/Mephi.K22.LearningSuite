namespace Mephi.K22.LearningSuite.Transport.Hung
{
    using Mephi.K22.LearningSuite.Core;
    using Mephi.K22.LearningSuite.Transport.Hung.Base;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class CreateHungTaskObject : BaseTaskObjectControl
    {
        private HungTable _ht;
        private bool _isSubs = false;
        private TransportTaskObject _tto;
        private Button btnSetDim;
        private Container components = null;
        private HungTableControl hungTableControl;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel1;
        private TextBox tbDimH;
        private TextBox tbDimV;
        private TextBox tbName;

        public CreateHungTaskObject(TransportTaskObject to)
        {
            this.InitializeComponent();
            this._tto = to;
            if (this._tto != null)
            {
                this.tbName.Text = this._tto.Name;
                if (this._tto.Table != null)
                {
                    this._ht = this._tto.Table;
                    this.tbDimV.Text = this._ht.DimV.ToString();
                    this.tbDimH.Text = this._ht.DimH.ToString();
                    this.hungTableControl.SetDimensions(this._ht.DimV, this._ht.DimH);
                    this.hungTableControl.Subscribe(this._ht);
                    this.hungTableControl.ValueAAChanged += new HungTableControl.ValueAAChangedHandler(this.hungTableControl_ValueAAChanged);
                    this.hungTableControl.ValueBBChanged += new HungTableControl.ValueBBChangedHandler(this.hungTableControl_ValueBBChanged);
                    this.hungTableControl.ValueCDChanged += new HungTableControl.ValueCDChangedHandler(this.hungTableControl_ValueCDChanged);
                    this._isSubs = true;
                }
            }
        }

        private void btnSetDim_Click(object sender, EventArgs e)
        {
            this._ht = new HungTable(uint.Parse(this.tbDimV.Text.ToString()), uint.Parse(this.tbDimH.Text.ToString()));
            this.hungTableControl.SetDimensions(this._ht.DimV, this._ht.DimH);
            this.hungTableControl.Subscribe(this._ht);
            if (this._isSubs)
            {
                this.hungTableControl.ValueAAChanged -= new HungTableControl.ValueAAChangedHandler(this.hungTableControl_ValueAAChanged);
                this.hungTableControl.ValueBBChanged -= new HungTableControl.ValueBBChangedHandler(this.hungTableControl_ValueBBChanged);
                this.hungTableControl.ValueCDChanged -= new HungTableControl.ValueCDChangedHandler(this.hungTableControl_ValueCDChanged);
            }
            this.hungTableControl.ValueAAChanged += new HungTableControl.ValueAAChangedHandler(this.hungTableControl_ValueAAChanged);
            this.hungTableControl.ValueBBChanged += new HungTableControl.ValueBBChangedHandler(this.hungTableControl_ValueBBChanged);
            this.hungTableControl.ValueCDChanged += new HungTableControl.ValueCDChangedHandler(this.hungTableControl_ValueCDChanged);
            this._isSubs = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public override BaseTaskObject GetTaskObject()
        {
            this._tto.Name = this.tbName.Text;
            this._tto.Table = this._ht;
            return this._tto;
        }

        private void hungTableControl_ValueAAChanged(uint i, int val)
        {
            this._ht.SetValAA(i, val);
        }

        private void hungTableControl_ValueBBChanged(uint j, int val)
        {
            this._ht.SetValBB(j, val);
        }

        private void hungTableControl_ValueCDChanged(uint i, uint j, int val)
        {
            this._ht.SetValCD(i, j, val);
        }

        private void InitializeComponent()
        {
            this.tbName = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.hungTableControl = new HungTableControl();
            this.label3 = new Label();
            this.tbDimV = new TextBox();
            this.tbDimH = new TextBox();
            this.label4 = new Label();
            this.label5 = new Label();
            this.btnSetDim = new Button();
            this.panel1 = new Panel();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.tbName.Location = new Point(0x68, 0);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new Size(240, 40);
            this.tbName.TabIndex = 0;
            this.tbName.Text = "";
            this.label1.Location = new Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(100, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.label2.Location = new Point(0, 0x44);
            this.label2.Name = "label2";
            this.label2.Size = new Size(100, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Таблица";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.hungTableControl.Location = new Point(0, 0);
            this.hungTableControl.Name = "hungTableControl";
            this.hungTableControl.ReadOnly = false;
            this.hungTableControl.Selectable = false;
            this.hungTableControl.Size = new Size(80, 80);
            this.hungTableControl.TabIndex = 3;
            this.label3.Location = new Point(0, 0x2c);
            this.label3.Name = "label3";
            this.label3.Size = new Size(100, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Размерность";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            this.tbDimV.Location = new Point(0x68, 0x2c);
            this.tbDimV.Name = "tbDimV";
            this.tbDimV.Size = new Size(50, 20);
            this.tbDimV.TabIndex = 5;
            this.tbDimV.Text = "0";
            this.tbDimV.TextAlign = HorizontalAlignment.Right;
            this.tbDimH.Location = new Point(180, 0x2c);
            this.tbDimH.Name = "tbDimH";
            this.tbDimH.Size = new Size(50, 20);
            this.tbDimH.TabIndex = 6;
            this.tbDimH.Text = "0";
            this.tbDimH.TextAlign = HorizontalAlignment.Right;
            this.label4.Location = new Point(0x9c, 0x2c);
            this.label4.Name = "label4";
            this.label4.Size = new Size(20, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "(в)";
            this.label4.TextAlign = ContentAlignment.MiddleLeft;
            this.label5.Location = new Point(0xe8, 0x2c);
            this.label5.Name = "label5";
            this.label5.Size = new Size(20, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "(г)";
            this.label5.TextAlign = ContentAlignment.MiddleLeft;
            this.btnSetDim.Location = new Point(0x10c, 0x2c);
            this.btnSetDim.Name = "btnSetDim";
            this.btnSetDim.Size = new Size(0x4b, 20);
            this.btnSetDim.TabIndex = 9;
            this.btnSetDim.Text = "Задать";
            this.btnSetDim.Click += new EventHandler(this.btnSetDim_Click);
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.hungTableControl);
            this.panel1.Location = new Point(0x68, 0x44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x164, 0xd8);
            this.panel1.TabIndex = 10;
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.btnSetDim);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.tbDimH);
            base.Controls.Add(this.tbDimV);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.tbName);
            base.Name = "CreateHungTaskObject";
            base.Size = new Size(460, 0x11c);
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}

