// Type: Mephi.K22.LearningSuite.Core.DictionaryDialogForm
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Core
{
  public class DictionaryDialogForm : Form
  {
    private Container components = (Container) null;
    internal Panel pnlGrid;
    private Panel pnlButtons;
    private Button btnCancel;
    private Button btnOk;

    public DictionaryDialogForm()
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
      this.pnlGrid = new Panel();
      this.pnlButtons = new Panel();
      this.btnOk = new Button();
      this.btnCancel = new Button();
      this.pnlButtons.SuspendLayout();
      this.SuspendLayout();
      this.pnlGrid.Dock = DockStyle.Fill;
      this.pnlGrid.Location = new Point(0, 0);
      this.pnlGrid.Name = "pnlGrid";
      this.pnlGrid.Size = new Size(492, 337);
      this.pnlGrid.TabIndex = 0;
      this.pnlButtons.Controls.Add((Control) this.btnOk);
      this.pnlButtons.Controls.Add((Control) this.btnCancel);
      this.pnlButtons.Dock = DockStyle.Bottom;
      this.pnlButtons.Location = new Point(0, 337);
      this.pnlButtons.Name = "pnlButtons";
      this.pnlButtons.Size = new Size(492, 36);
      this.pnlButtons.TabIndex = 1;
      this.btnOk.Anchor = AnchorStyles.Right;
      this.btnOk.Location = new Point(412, 8);
      this.btnOk.Name = "btnOk";
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "Выбор";
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.btnCancel.Anchor = AnchorStyles.Right;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(328, 8);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.TabIndex = 0;
      this.btnCancel.Text = "Отмена";
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(492, 373);
      this.Controls.Add((Control) this.pnlGrid);
      this.Controls.Add((Control) this.pnlButtons);
      this.Name = "DictionaryDialogForm";
      this.Text = "Выберите значение из справочника";
      this.pnlButtons.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      this.Close();
      this.DialogResult = DialogResult.OK;
    }
  }
}
