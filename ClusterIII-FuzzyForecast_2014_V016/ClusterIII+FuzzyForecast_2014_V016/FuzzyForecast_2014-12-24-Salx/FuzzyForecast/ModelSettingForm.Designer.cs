namespace FuzzyForecast {
  partial class ModelSettingForm {
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
        this.buttonCancel = new System.Windows.Forms.Button();
        this.buttonOK = new System.Windows.Forms.Button();
        this.labelOrder = new System.Windows.Forms.Label();
        this.numericUpDownOrder = new System.Windows.Forms.NumericUpDown();
        this.labelCount = new System.Windows.Forms.Label();
        this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
        this.numericUpDownSplit = new System.Windows.Forms.NumericUpDown();
        this.labelSplit = new System.Windows.Forms.Label();
        this.checkBoxSelect = new System.Windows.Forms.CheckBox();
        this.checkBoxUseAll = new System.Windows.Forms.CheckBox();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.checkBoxSettings = new System.Windows.Forms.CheckBox();
        this.comboBox = new System.Windows.Forms.ComboBox();
        this.groupBoxType = new System.Windows.Forms.GroupBox();
        this.comboBoxType = new System.Windows.Forms.ComboBox();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrder)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplit)).BeginInit();
        this.groupBox1.SuspendLayout();
        this.groupBoxType.SuspendLayout();
        this.SuspendLayout();
        // 
        // buttonCancel
        // 
        this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.buttonCancel.Location = new System.Drawing.Point(193, 291);
        this.buttonCancel.Name = "buttonCancel";
        this.buttonCancel.Size = new System.Drawing.Size(75, 23);
        this.buttonCancel.TabIndex = 9;
        this.buttonCancel.Text = "Отмена";
        this.buttonCancel.UseVisualStyleBackColor = true;
        // 
        // buttonOK
        // 
        this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.buttonOK.Location = new System.Drawing.Point(112, 291);
        this.buttonOK.Name = "buttonOK";
        this.buttonOK.Size = new System.Drawing.Size(75, 23);
        this.buttonOK.TabIndex = 8;
        this.buttonOK.Text = "OK";
        this.buttonOK.UseVisualStyleBackColor = true;
        // 
        // labelOrder
        // 
        this.labelOrder.AutoSize = true;
        this.labelOrder.Location = new System.Drawing.Point(12, 18);
        this.labelOrder.Name = "labelOrder";
        this.labelOrder.Size = new System.Drawing.Size(51, 13);
        this.labelOrder.TabIndex = 10;
        this.labelOrder.Text = "Порядок";
        // 
        // numericUpDownOrder
        // 
        this.numericUpDownOrder.Location = new System.Drawing.Point(148, 16);
        this.numericUpDownOrder.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
        this.numericUpDownOrder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.numericUpDownOrder.Name = "numericUpDownOrder";
        this.numericUpDownOrder.Size = new System.Drawing.Size(120, 20);
        this.numericUpDownOrder.TabIndex = 11;
        this.numericUpDownOrder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // labelCount
        // 
        this.labelCount.AutoSize = true;
        this.labelCount.Location = new System.Drawing.Point(12, 47);
        this.labelCount.Name = "labelCount";
        this.labelCount.Size = new System.Drawing.Size(98, 13);
        this.labelCount.TabIndex = 12;
        this.labelCount.Text = "Глубина прогноза";
        // 
        // numericUpDownCount
        // 
        this.numericUpDownCount.Location = new System.Drawing.Point(148, 47);
        this.numericUpDownCount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
        this.numericUpDownCount.Name = "numericUpDownCount";
        this.numericUpDownCount.Size = new System.Drawing.Size(120, 20);
        this.numericUpDownCount.TabIndex = 13;
        // 
        // numericUpDownSplit
        // 
        this.numericUpDownSplit.Location = new System.Drawing.Point(148, 78);
        this.numericUpDownSplit.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
        this.numericUpDownSplit.Name = "numericUpDownSplit";
        this.numericUpDownSplit.Size = new System.Drawing.Size(120, 20);
        this.numericUpDownSplit.TabIndex = 17;
        this.numericUpDownSplit.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
        // 
        // labelSplit
        // 
        this.labelSplit.AutoSize = true;
        this.labelSplit.Location = new System.Drawing.Point(12, 80);
        this.labelSplit.Name = "labelSplit";
        this.labelSplit.Size = new System.Drawing.Size(126, 13);
        this.labelSplit.TabIndex = 16;
        this.labelSplit.Text = "Разбиение ряда (точки)";
        // 
        // checkBoxSelect
        // 
        this.checkBoxSelect.AutoSize = true;
        this.checkBoxSelect.Location = new System.Drawing.Point(15, 183);
        this.checkBoxSelect.Name = "checkBoxSelect";
        this.checkBoxSelect.Size = new System.Drawing.Size(96, 17);
        this.checkBoxSelect.TabIndex = 18;
        this.checkBoxSelect.Text = "Отбор правил";
        this.checkBoxSelect.UseVisualStyleBackColor = true;
        // 
        // checkBoxUseAll
        // 
        this.checkBoxUseAll.AutoSize = true;
        this.checkBoxUseAll.Location = new System.Drawing.Point(15, 206);
        this.checkBoxUseAll.Name = "checkBoxUseAll";
        this.checkBoxUseAll.Size = new System.Drawing.Size(151, 17);
        this.checkBoxUseAll.TabIndex = 20;
        this.checkBoxUseAll.Text = "Использовать все точки";
        this.checkBoxUseAll.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.checkBoxSettings);
        this.groupBox1.Controls.Add(this.comboBox);
        this.groupBox1.Location = new System.Drawing.Point(15, 104);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(253, 73);
        this.groupBox1.TabIndex = 23;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Модель остатков";
        // 
        // checkBoxSettings
        // 
        this.checkBoxSettings.AutoSize = true;
        this.checkBoxSettings.Location = new System.Drawing.Point(6, 46);
        this.checkBoxSettings.Name = "checkBoxSettings";
        this.checkBoxSettings.Size = new System.Drawing.Size(124, 17);
        this.checkBoxSettings.TabIndex = 23;
        this.checkBoxSettings.Text = "Настроить вручную";
        this.checkBoxSettings.UseVisualStyleBackColor = true;
        // 
        // comboBox
        // 
        this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox.FormattingEnabled = true;
        this.comboBox.Items.AddRange(new object[] {
            "Нет модели",
            "N-Модель",
            "S-Модель",
            "D-Модель",
            "T-Модель"});
        this.comboBox.Location = new System.Drawing.Point(6, 19);
        this.comboBox.Name = "comboBox";
        this.comboBox.Size = new System.Drawing.Size(241, 21);
        this.comboBox.TabIndex = 19;
        // 
        // groupBoxType
        // 
        this.groupBoxType.Controls.Add(this.comboBoxType);
        this.groupBoxType.Location = new System.Drawing.Point(12, 229);
        this.groupBoxType.Name = "groupBoxType";
        this.groupBoxType.Size = new System.Drawing.Size(253, 55);
        this.groupBoxType.TabIndex = 24;
        this.groupBoxType.TabStop = false;
        this.groupBoxType.Text = "Тип модели";
        // 
        // comboBoxType
        // 
        this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBoxType.FormattingEnabled = true;
        this.comboBoxType.Items.AddRange(new object[] {
            "Нет модели",
            "N-Модель",
            "S-Модель",
            "D-Модель",
            "T-Модель"});
        this.comboBoxType.Location = new System.Drawing.Point(6, 19);
        this.comboBoxType.Name = "comboBoxType";
        this.comboBoxType.Size = new System.Drawing.Size(241, 21);
        this.comboBoxType.TabIndex = 19;
        // 
        // ModelSettingForm
        // 
        this.AcceptButton = this.buttonOK;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.buttonCancel;
        this.ClientSize = new System.Drawing.Size(280, 326);
        this.Controls.Add(this.groupBoxType);
        this.Controls.Add(this.groupBox1);
        this.Controls.Add(this.checkBoxUseAll);
        this.Controls.Add(this.checkBoxSelect);
        this.Controls.Add(this.numericUpDownSplit);
        this.Controls.Add(this.labelSplit);
        this.Controls.Add(this.numericUpDownCount);
        this.Controls.Add(this.labelCount);
        this.Controls.Add(this.numericUpDownOrder);
        this.Controls.Add(this.labelOrder);
        this.Controls.Add(this.buttonCancel);
        this.Controls.Add(this.buttonOK);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "ModelSettingForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Настройки модели";
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrder)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplit)).EndInit();
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.groupBoxType.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.Label labelOrder;
    private System.Windows.Forms.NumericUpDown numericUpDownOrder;
    private System.Windows.Forms.Label labelCount;
    private System.Windows.Forms.NumericUpDown numericUpDownCount;
    private System.Windows.Forms.NumericUpDown numericUpDownSplit;
    private System.Windows.Forms.Label labelSplit;
    private System.Windows.Forms.CheckBox checkBoxSelect;
    private System.Windows.Forms.CheckBox checkBoxUseAll;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox checkBoxSettings;
    private System.Windows.Forms.ComboBox comboBox;
    private System.Windows.Forms.GroupBox groupBoxType;
    private System.Windows.Forms.ComboBox comboBoxType;
  }
}