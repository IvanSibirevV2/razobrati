namespace FuzzyForecast {
  partial class TendSettingForm {
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
      this.checkBoxExcess = new System.Windows.Forms.CheckBox();
      this.checkBoxSelect = new System.Windows.Forms.CheckBox();
      this.checkBoxUseAll = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrder)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplit)).BeginInit();
      this.SuspendLayout();
      // 
      // buttonCancel
      // 
      this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(193, 192);
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
      this.buttonOK.Location = new System.Drawing.Point(112, 192);
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
      // checkBoxExcess
      // 
      this.checkBoxExcess.AutoSize = true;
      this.checkBoxExcess.Location = new System.Drawing.Point(15, 134);
      this.checkBoxExcess.Name = "checkBoxExcess";
      this.checkBoxExcess.Size = new System.Drawing.Size(156, 17);
      this.checkBoxExcess.TabIndex = 19;
      this.checkBoxExcess.Text = "Моделирование остатков";
      this.checkBoxExcess.UseVisualStyleBackColor = true;
      // 
      // checkBoxSelect
      // 
      this.checkBoxSelect.AutoSize = true;
      this.checkBoxSelect.Location = new System.Drawing.Point(15, 111);
      this.checkBoxSelect.Name = "checkBoxSelect";
      this.checkBoxSelect.Size = new System.Drawing.Size(96, 17);
      this.checkBoxSelect.TabIndex = 18;
      this.checkBoxSelect.Text = "Отбор правил";
      this.checkBoxSelect.UseVisualStyleBackColor = true;
      // 
      // checkBoxUseAll
      // 
      this.checkBoxUseAll.AutoSize = true;
      this.checkBoxUseAll.Location = new System.Drawing.Point(15, 157);
      this.checkBoxUseAll.Name = "checkBoxUseAll";
      this.checkBoxUseAll.Size = new System.Drawing.Size(151, 17);
      this.checkBoxUseAll.TabIndex = 20;
      this.checkBoxUseAll.Text = "Использовать все точки";
      this.checkBoxUseAll.UseVisualStyleBackColor = true;
      // 
      // TendSettingForm
      // 
      this.AcceptButton = this.buttonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(280, 227);
      this.Controls.Add(this.checkBoxUseAll);
      this.Controls.Add(this.checkBoxExcess);
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
      this.Name = "TendSettingForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Настройка модели";
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrder)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplit)).EndInit();
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
    private System.Windows.Forms.CheckBox checkBoxExcess;
    private System.Windows.Forms.CheckBox checkBoxSelect;
    private System.Windows.Forms.CheckBox checkBoxUseAll;
  }
}