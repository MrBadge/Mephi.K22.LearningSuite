// Type: Mephi.K22.LearningSuite.Core.DictionaryButton
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Mephi.K22.LearningSuite.Core
{
  public class DictionaryButton : UserControl
  {
    private Container components = (Container) null;
    private DataRow _selectedRow = (DataRow) null;
    private string _memberId = string.Empty;
    private string _memberText = string.Empty;
    public BaseGridControl DictionaryControl = (BaseGridControl) null;
    private TextBox tbText;
    private Button btnSelect;
    private Button btnClear;
    private Guid _valueId;

    public bool EnabledBtnClear
    {
      get
      {
        return this.btnClear.Enabled;
      }
      set
      {
        this.btnClear.Enabled = value;
      }
    }

    public DataRow SelectedRow
    {
      get
      {
        return this._selectedRow;
      }
      set
      {
        this._selectedRow = value;
        this.tbText.Text = this.ValueText;
      }
    }

    public Guid ValueId
    {
      get
      {
        try
        {
          if (this._selectedRow[this._memberId] != null)
            return (Guid) this._selectedRow[this._memberId];
          else
            return this._valueId;
        }
        catch
        {
          return this._valueId;
        }
      }
      set
      {
        this.tbText.Tag = (object) value;
        this._valueId = value;
      }
    }

    public string ValueText
    {
      get
      {
        try
        {
          return (string) this._selectedRow[this._memberText];
        }
        catch
        {
          return (string) null;
        }
      }
      set
      {
        this.tbText.Text = value;
      }
    }

    public string MemberId
    {
      get
      {
        return this._memberId;
      }
      set
      {
        this._memberId = value;
      }
    }

    public string MemberText
    {
      get
      {
        return this._memberText;
      }
      set
      {
        this._memberText = value;
      }
    }

    public event EventHandler LetsLoadDictionary;

    public event EventHandler ValueChanged;

    public DictionaryButton()
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
      this.tbText = new TextBox();
      this.btnSelect = new Button();
      this.btnClear = new Button();
      this.SuspendLayout();
      this.tbText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbText.Location = new Point(0, 0);
      this.tbText.Name = "tbText";
      this.tbText.ReadOnly = true;
      this.tbText.Size = new Size(162, 20);
      this.tbText.TabIndex = 0;
      this.tbText.Text = "";
      this.btnSelect.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSelect.Location = new Point(164, 0);
      this.btnSelect.Name = "btnSelect";
      this.btnSelect.Size = new Size(24, 20);
      this.btnSelect.TabIndex = 1;
      this.btnSelect.Text = "...";
      this.btnSelect.Click += new EventHandler(this.btnSelect_Click);
      this.btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnClear.Location = new Point(190, 0);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new Size(24, 20);
      this.btnClear.TabIndex = 2;
      this.btnClear.Text = "X";
      this.btnClear.Click += new EventHandler(this.btnClear_Click);
      this.Controls.Add((Control) this.btnClear);
      this.Controls.Add((Control) this.btnSelect);
      this.Controls.Add((Control) this.tbText);
      this.Name = "DictionaryButton";
      this.Size = new Size(216, 20);
      this.Resize += new EventHandler(this.DictionaryButton_Resize);
      this.ResumeLayout(false);
    }

    private void DictionaryButton_Resize(object sender, EventArgs e)
    {
      this.Size = new Size(this.Size.Width, 20);
    }

    private void btnSelect_Click(object sender, EventArgs e)
    {
      if (this.LetsLoadDictionary == null)
        return;
      this.LetsLoadDictionary(sender, e);
      DictionaryDialogForm dictionaryDialogForm = new DictionaryDialogForm();
      if (this.DictionaryControl == null)
        return;
      dictionaryDialogForm.Size = new Size(this.DictionaryControl.Size.Width + 8, this.DictionaryControl.Size.Height + 63);
      dictionaryDialogForm.pnlGrid.Controls.Add((Control) this.DictionaryControl);
      this.DictionaryControl.Dock = DockStyle.Fill;
      dictionaryDialogForm.StartPosition = FormStartPosition.CenterParent;
      if (dictionaryDialogForm.ShowDialog() != DialogResult.OK)
        return;
      this.SelectedRow = this.DictionaryControl.SelectedRow;
      if (this.ValueChanged == null)
        return;
      this.ValueChanged(sender, e);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      this.SelectedRow = (DataRow) null;
      this.tbText.Text = "";
      this.tbText.Tag = (object) Guid.Empty;
      this._valueId = Guid.Empty;
      if (this.ValueChanged == null)
        return;
      this.ValueChanged(sender, e);
    }
  }
}
