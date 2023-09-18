namespace FuzzyForecast {
  partial class NeuralSettingForm {
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
        this.numericUpDownHiddenCount = new System.Windows.Forms.NumericUpDown();
        this.labelHiddenCount = new System.Windows.Forms.Label();
        this.numericUpDownSplit = new System.Windows.Forms.NumericUpDown();
        this.labelSplit = new System.Windows.Forms.Label();
        this.checkBoxUseAll = new System.Windows.Forms.CheckBox();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.checkBoxSettings = new System.Windows.Forms.CheckBox();
        this.comboBox = new System.Windows.Forms.ComboBox();
        this.numericUpDownEpoch = new System.Windows.Forms.NumericUpDown();
        this.labelEpoch = new System.Windows.Forms.Label();
        this.labelMSE = new System.Windows.Forms.Label();
        this.textBoxMSE = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrder)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHiddenCount)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplit)).BeginInit();
        this.groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEpoch)).BeginInit();
        this.SuspendLayout();
        // 
        // buttonCancel
        // 
        this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.buttonCancel.Location = new System.Drawing.Point(213, 306);
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
        this.buttonOK.Location = new System.Drawing.Point(132, 306);
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
        this.numericUpDownOrder.Location = new System.Drawing.Point(168, 16);
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
            2,
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
        this.numericUpDownCount.Location = new System.Drawing.Point(168, 47);
        this.numericUpDownCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
        this.numericUpDownCount.Name = "numericUpDownCount";
        this.numericUpDownCount.Size = new System.Drawing.Size(120, 20);
        this.numericUpDownCount.TabIndex = 13;
        // 
        // numericUpDownHiddenCount
        // 
        this.numericUpDownHiddenCount.Location = new System.Drawing.Point(168, 78);
        this.numericUpDownHiddenCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
        this.numericUpDownHiddenCount.Name = "numericUpDownHiddenCount";
        this.numericUpDownHiddenCount.Size = new System.Drawing.Size(120, 20);
        this.numericUpDownHiddenCount.TabIndex = 15;
        this.numericUpDownHiddenCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
        // 
        // labelHiddenCount
        // 
        this.labelHiddenCount.AutoSize = true;
        this.labelHiddenCount.Location = new System.Drawing.Point(12, 78);
        this.labelHiddenCount.Name = "labelHiddenCount";
        this.labelHiddenCount.Size = new System.Drawing.Size(139, 13);
        this.labelHiddenCount.TabIndex = 14;
        this.labelHiddenCount.Text = "Кол-во скрытых нейронов";
        // 
        // numericUpDownSplit
        // 
        this.numericUpDownSplit.Location = new System.Drawing.Point(168, 107);

        //TODO: Попытка расширить максимальное кол-во значений ряда до 1000
        this.numericUpDownSplit.Maximum = new decimal(new int[] {
            //50,
            1000,
            0,
            0,
            0});
        this.numericUpDownSplit.Name = "numericUpDownSplit";
        this.numericUpDownSplit.Size = new System.Drawing.Size(120, 20);
        this.numericUpDownSplit.TabIndex = 17;
        this.numericUpDownSplit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
        // 
        // labelSplit
        // 
        this.labelSplit.AutoSize = true;
        this.labelSplit.Location = new System.Drawing.Point(12, 107);
        this.labelSplit.Name = "labelSplit";
        this.labelSplit.Size = new System.Drawing.Size(126, 13);
        this.labelSplit.TabIndex = 16;
        this.labelSplit.Text = "Разбиение ряда (точки)";
        // 
        // checkBoxUseAll
        // 
        this.checkBoxUseAll.AutoSize = true;
        this.checkBoxUseAll.Location = new System.Drawing.Point(15, 271);
        this.checkBoxUseAll.Name = "checkBoxUseAll";
        this.checkBoxUseAll.Size = new System.Drawing.Size(151, 17);
        this.checkBoxUseAll.TabIndex = 21;
        this.checkBoxUseAll.Text = "Использовать все точки";
        this.checkBoxUseAll.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.checkBoxSettings);
        this.groupBox1.Controls.Add(this.comboBox);
        this.groupBox1.Location = new System.Drawing.Point(15, 192);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(273, 73);
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
        this.comboBox.Size = new System.Drawing.Size(261, 21);
        this.comboBox.TabIndex = 19;
        // 
        // numericUpDownEpoch
        // 
        this.numericUpDownEpoch.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
        this.numericUpDownEpoch.Location = new System.Drawing.Point(168, 136);
        this.numericUpDownEpoch.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
        this.numericUpDownEpoch.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
        this.numericUpDownEpoch.Name = "numericUpDownEpoch";
        this.numericUpDownEpoch.Size = new System.Drawing.Size(120, 20);
        this.numericUpDownEpoch.TabIndex = 25;
        this.numericUpDownEpoch.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
        // 
        // labelEpoch
        // 
        this.labelEpoch.AutoSize = true;
        this.labelEpoch.Location = new System.Drawing.Point(12, 136);
        this.labelEpoch.Name = "labelEpoch";
        this.labelEpoch.Size = new System.Drawing.Size(65, 13);
        this.labelEpoch.TabIndex = 24;
        this.labelEpoch.Text = "Число эпох";
        // 
        // labelMSE
        // 
        this.labelMSE.AutoSize = true;
        this.labelMSE.Location = new System.Drawing.Point(12, 166);
        this.labelMSE.Name = "labelMSE";
        this.labelMSE.Size = new System.Drawing.Size(80, 13);
        this.labelMSE.TabIndex = 26;
        this.labelMSE.Text = "Точноть (MSE)";
        // 
        // textBoxMSE
        // 
        this.textBoxMSE.Location = new System.Drawing.Point(168, 166);
        this.textBoxMSE.Name = "textBoxMSE";
        this.textBoxMSE.Size = new System.Drawing.Size(120, 20);
        this.textBoxMSE.TabIndex = 27;
        this.textBoxMSE.Text = "0,000001";
        // 
        // NeuralSettingForm
        // 
        this.AcceptButton = this.buttonOK;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.buttonCancel;
        this.ClientSize = new System.Drawing.Size(300, 341);
        this.Controls.Add(this.textBoxMSE);
        this.Controls.Add(this.labelMSE);
        this.Controls.Add(this.numericUpDownEpoch);
        this.Controls.Add(this.labelEpoch);
        this.Controls.Add(this.groupBox1);
        this.Controls.Add(this.checkBoxUseAll);
        this.Controls.Add(this.numericUpDownSplit);
        this.Controls.Add(this.labelSplit);
        this.Controls.Add(this.numericUpDownHiddenCount);
        this.Controls.Add(this.labelHiddenCount);
        this.Controls.Add(this.numericUpDownCount);
        this.Controls.Add(this.labelCount);
        this.Controls.Add(this.numericUpDownOrder);
        this.Controls.Add(this.labelOrder);
        this.Controls.Add(this.buttonCancel);
        this.Controls.Add(this.buttonOK);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "NeuralSettingForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Настройка модели";
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrder)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHiddenCount)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplit)).EndInit();
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEpoch)).EndInit();
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
    private System.Windows.Forms.NumericUpDown numericUpDownHiddenCount;
    private System.Windows.Forms.Label labelHiddenCount;
    private System.Windows.Forms.NumericUpDown numericUpDownSplit;
    private System.Windows.Forms.Label labelSplit;
    private System.Windows.Forms.CheckBox checkBoxUseAll;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox checkBoxSettings;
    private System.Windows.Forms.ComboBox comboBox;
    private System.Windows.Forms.NumericUpDown numericUpDownEpoch;
    private System.Windows.Forms.Label labelEpoch;
    private System.Windows.Forms.Label labelMSE;
    private System.Windows.Forms.TextBox textBoxMSE;
  }
}