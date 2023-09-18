namespace FuzzyForecast
{
    partial class ComplexAnalysisTend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelSplit = new System.Windows.Forms.Label();
            this.numericUpDownSplit = new System.Windows.Forms.NumericUpDown();
            this.nudRange = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMaxISP = new System.Windows.Forms.TextBox();
            this.cbTTend = new System.Windows.Forms.CheckBox();
            this.cbRTend = new System.Windows.Forms.CheckBox();
            this.cbMAPE = new System.Windows.Forms.CheckBox();
            this.cbMSE = new System.Windows.Forms.CheckBox();
            this.qpParams = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxBestResult = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSelectRules = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).BeginInit();
            this.qpParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(135, 252);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(216, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // labelSplit
            // 
            this.labelSplit.AutoSize = true;
            this.labelSplit.Location = new System.Drawing.Point(12, 40);
            this.labelSplit.Name = "labelSplit";
            this.labelSplit.Size = new System.Drawing.Size(129, 13);
            this.labelSplit.TabIndex = 21;
            this.labelSplit.Text = "Разбиение ряда (точки):";
            // 
            // numericUpDownSplit
            // 
            this.numericUpDownSplit.Location = new System.Drawing.Point(170, 38);
            this.numericUpDownSplit.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownSplit.Name = "numericUpDownSplit";
            this.numericUpDownSplit.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSplit.TabIndex = 20;
            this.numericUpDownSplit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudRange
            // 
            this.nudRange.Location = new System.Drawing.Point(170, 64);
            this.nudRange.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRange.Name = "nudRange";
            this.nudRange.Size = new System.Drawing.Size(120, 20);
            this.nudRange.TabIndex = 23;
            this.nudRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Порядок моделей:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Max ISP:";
            // 
            // tbMaxISP
            // 
            this.tbMaxISP.Location = new System.Drawing.Point(170, 90);
            this.tbMaxISP.Name = "tbMaxISP";
            this.tbMaxISP.Size = new System.Drawing.Size(120, 20);
            this.tbMaxISP.TabIndex = 27;
            this.tbMaxISP.Text = "10";
            // 
            // cbTTend
            // 
            this.cbTTend.AutoSize = true;
            this.cbTTend.Location = new System.Drawing.Point(259, 79);
            this.cbTTend.Name = "cbTTend";
            this.cbTTend.Size = new System.Drawing.Size(15, 14);
            this.cbTTend.TabIndex = 7;
            this.cbTTend.UseVisualStyleBackColor = true;
            // 
            // cbRTend
            // 
            this.cbRTend.AutoSize = true;
            this.cbRTend.Location = new System.Drawing.Point(259, 59);
            this.cbRTend.Name = "cbRTend";
            this.cbRTend.Size = new System.Drawing.Size(15, 14);
            this.cbRTend.TabIndex = 6;
            this.cbRTend.UseVisualStyleBackColor = true;
            // 
            // cbMAPE
            // 
            this.cbMAPE.AutoSize = true;
            this.cbMAPE.Checked = true;
            this.cbMAPE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMAPE.Location = new System.Drawing.Point(259, 39);
            this.cbMAPE.Name = "cbMAPE";
            this.cbMAPE.Size = new System.Drawing.Size(15, 14);
            this.cbMAPE.TabIndex = 5;
            this.cbMAPE.UseVisualStyleBackColor = true;
            // 
            // cbMSE
            // 
            this.cbMSE.AutoSize = true;
            this.cbMSE.Checked = true;
            this.cbMSE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMSE.Location = new System.Drawing.Point(259, 19);
            this.cbMSE.Name = "cbMSE";
            this.cbMSE.Size = new System.Drawing.Size(15, 14);
            this.cbMSE.TabIndex = 4;
            this.cbMSE.UseVisualStyleBackColor = true;
            // 
            // qpParams
            // 
            this.qpParams.Controls.Add(this.cbTTend);
            this.qpParams.Controls.Add(this.cbRTend);
            this.qpParams.Controls.Add(this.cbMAPE);
            this.qpParams.Controls.Add(this.cbMSE);
            this.qpParams.Controls.Add(this.label10);
            this.qpParams.Controls.Add(this.label9);
            this.qpParams.Controls.Add(this.label8);
            this.qpParams.Controls.Add(this.label7);
            this.qpParams.Location = new System.Drawing.Point(13, 146);
            this.qpParams.Name = "qpParams";
            this.qpParams.Size = new System.Drawing.Size(278, 99);
            this.qpParams.TabIndex = 30;
            this.qpParams.TabStop = false;
            this.qpParams.Text = "Оценивыемые параметры";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "TTendFPE:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "RTendFPE:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "MAPE:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "MSE:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Тип анализируемой ошибки:";
            // 
            // comboBoxBestResult
            // 
            this.comboBoxBestResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBestResult.DropDownWidth = 121;
            this.comboBoxBestResult.FormattingEnabled = true;
            this.comboBoxBestResult.Items.AddRange(new object[] {
            "Внешние ошибки",
            "Внутренние ошибки"});
            this.comboBoxBestResult.Location = new System.Drawing.Point(170, 12);
            this.comboBoxBestResult.Name = "comboBoxBestResult";
            this.comboBoxBestResult.Size = new System.Drawing.Size(120, 21);
            this.comboBoxBestResult.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Отбор правил";
            // 
            // cbSelectRules
            // 
            this.cbSelectRules.AutoSize = true;
            this.cbSelectRules.Location = new System.Drawing.Point(170, 116);
            this.cbSelectRules.Name = "cbSelectRules";
            this.cbSelectRules.Size = new System.Drawing.Size(15, 14);
            this.cbSelectRules.TabIndex = 34;
            this.cbSelectRules.UseVisualStyleBackColor = true;
            // 
            // ComplexAnalysisTend
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(303, 288);
            this.Controls.Add(this.cbSelectRules);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxBestResult);
            this.Controls.Add(this.qpParams);
            this.Controls.Add(this.tbMaxISP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelSplit);
            this.Controls.Add(this.numericUpDownSplit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ComplexAnalysisTend";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Компл. анализ тенденций";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).EndInit();
            this.qpParams.ResumeLayout(false);
            this.qpParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelSplit;
        private System.Windows.Forms.NumericUpDown numericUpDownSplit;
        private System.Windows.Forms.NumericUpDown nudRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaxISP;
        private System.Windows.Forms.CheckBox cbTTend;
        private System.Windows.Forms.CheckBox cbRTend;
        private System.Windows.Forms.CheckBox cbMAPE;
        private System.Windows.Forms.CheckBox cbMSE;
        private System.Windows.Forms.GroupBox qpParams;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxBestResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbSelectRules;
    }
}