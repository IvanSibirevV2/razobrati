namespace FuzzyForecast {
  partial class SaveReportForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.buttonOK = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.labelFolder = new System.Windows.Forms.Label();
      this.textBoxFolder = new System.Windows.Forms.TextBox();
      this.buttonBrowse = new System.Windows.Forms.Button();
      this.textBoxName = new System.Windows.Forms.TextBox();
      this.labelName = new System.Windows.Forms.Label();
      this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.checkBoxShow = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // buttonOK
      // 
      this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOK.Location = new System.Drawing.Point(117, 140);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 0;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      // 
      // buttonCancel
      // 
      this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(197, 140);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "Отмена";
      this.buttonCancel.UseVisualStyleBackColor = true;
      // 
      // labelFolder
      // 
      this.labelFolder.AutoSize = true;
      this.labelFolder.Location = new System.Drawing.Point(12, 19);
      this.labelFolder.Name = "labelFolder";
      this.labelFolder.Size = new System.Drawing.Size(69, 13);
      this.labelFolder.TabIndex = 4;
      this.labelFolder.Text = "Дериктория";
      // 
      // textBoxFolder
      // 
      this.textBoxFolder.Location = new System.Drawing.Point(12, 35);
      this.textBoxFolder.Name = "textBoxFolder";
      this.textBoxFolder.ReadOnly = true;
      this.textBoxFolder.Size = new System.Drawing.Size(180, 20);
      this.textBoxFolder.TabIndex = 5;
      this.textBoxFolder.TextChanged += new System.EventHandler(this.textBox_TextChanged);
      // 
      // buttonBrowse
      // 
      this.buttonBrowse.Location = new System.Drawing.Point(198, 35);
      this.buttonBrowse.Name = "buttonBrowse";
      this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
      this.buttonBrowse.TabIndex = 6;
      this.buttonBrowse.Text = "Обзор";
      this.buttonBrowse.UseVisualStyleBackColor = true;
      this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
      // 
      // textBoxName
      // 
      this.textBoxName.Location = new System.Drawing.Point(12, 84);
      this.textBoxName.Name = "textBoxName";
      this.textBoxName.Size = new System.Drawing.Size(260, 20);
      this.textBoxName.TabIndex = 7;
      this.textBoxName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
      // 
      // labelName
      // 
      this.labelName.AutoSize = true;
      this.labelName.Location = new System.Drawing.Point(12, 68);
      this.labelName.Name = "labelName";
      this.labelName.Size = new System.Drawing.Size(93, 13);
      this.labelName.TabIndex = 8;
      this.labelName.Text = "Название отчета";
      // 
      // folderBrowserDialog
      // 
      this.folderBrowserDialog.Description = "Выберите директорию";
      // 
      // checkBoxShow
      // 
      this.checkBoxShow.AutoSize = true;
      this.checkBoxShow.Checked = true;
      this.checkBoxShow.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBoxShow.Location = new System.Drawing.Point(12, 110);
      this.checkBoxShow.Name = "checkBoxShow";
      this.checkBoxShow.Size = new System.Drawing.Size(124, 17);
      this.checkBoxShow.TabIndex = 9;
      this.checkBoxShow.Text = "Просмотреть отчет";
      this.checkBoxShow.UseVisualStyleBackColor = true;
      // 
      // SaveReportForm
      // 
      this.AcceptButton = this.buttonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(284, 175);
      this.Controls.Add(this.checkBoxShow);
      this.Controls.Add(this.labelName);
      this.Controls.Add(this.textBoxName);
      this.Controls.Add(this.buttonBrowse);
      this.Controls.Add(this.textBoxFolder);
      this.Controls.Add(this.labelFolder);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOK);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "SaveReportForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Сохранение отчета";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Label labelFolder;
    private System.Windows.Forms.TextBox textBoxFolder;
    private System.Windows.Forms.Button buttonBrowse;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    private System.Windows.Forms.CheckBox checkBoxShow;
  }
}