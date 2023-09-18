namespace FuzzyForecast
{
    partial class ComplexAnalysis
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.comboBoxBestResult = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.cb4 = new System.Windows.Forms.CheckBox();
            this.cb3 = new System.Windows.Forms.CheckBox();
            this.cb2 = new System.Windows.Forms.CheckBox();
            this.cb1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudRange = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSplit = new System.Windows.Forms.NumericUpDown();
            this.labelSplit = new System.Windows.Forms.Label();
            this.qpParams = new System.Windows.Forms.GroupBox();
            this.cbTTend = new System.Windows.Forms.CheckBox();
            this.cbRTend = new System.Windows.Forms.CheckBox();
            this.cbMAPE = new System.Windows.Forms.CheckBox();
            this.cbMSE = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.cbSeparateResult = new System.Windows.Forms.CheckBox();
            this.cbUseAllSeries = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbUseFTransform = new System.Windows.Forms.CheckBox();
            this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
            this.labelCount = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplit)).BeginInit();
            this.qpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(220, 419);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(139, 419);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
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
            this.comboBoxBestResult.Size = new System.Drawing.Size(125, 21);
            this.comboBoxBestResult.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Тип анализируемой ошибки:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Перебор порядка моделей:";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.cb4);
            this.groupBox.Controls.Add(this.cb3);
            this.groupBox.Controls.Add(this.cb2);
            this.groupBox.Controls.Add(this.cb1);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Location = new System.Drawing.Point(12, 119);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(280, 116);
            this.groupBox.TabIndex = 12;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Используемые модели";
            // 
            // cb4
            // 
            this.cb4.AutoSize = true;
            this.cb4.Checked = true;
            this.cb4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb4.Location = new System.Drawing.Point(259, 92);
            this.cb4.Name = "cb4";
            this.cb4.Size = new System.Drawing.Size(15, 14);
            this.cb4.TabIndex = 7;
            this.cb4.UseVisualStyleBackColor = true;
            // 
            // cb3
            // 
            this.cb3.AutoSize = true;
            this.cb3.Checked = true;
            this.cb3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb3.Location = new System.Drawing.Point(259, 70);
            this.cb3.Name = "cb3";
            this.cb3.Size = new System.Drawing.Size(15, 14);
            this.cb3.TabIndex = 6;
            this.cb3.UseVisualStyleBackColor = true;
            // 
            // cb2
            // 
            this.cb2.AutoSize = true;
            this.cb2.Checked = true;
            this.cb2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb2.Location = new System.Drawing.Point(259, 47);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(15, 14);
            this.cb2.TabIndex = 5;
            this.cb2.UseVisualStyleBackColor = true;
            // 
            // cb1
            // 
            this.cb1.AutoSize = true;
            this.cb1.Checked = true;
            this.cb1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb1.Location = new System.Drawing.Point(259, 25);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(15, 14);
            this.cb1.TabIndex = 4;
            this.cb1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Модель на основе тенденций:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Модель Шаха-Дегтярёва:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Модель Сонга:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Нейросетевая модель:";
            // 
            // nudRange
            // 
            this.nudRange.Location = new System.Drawing.Point(170, 41);
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
            this.nudRange.TabIndex = 13;
            this.nudRange.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownSplit
            // 
            this.numericUpDownSplit.Location = new System.Drawing.Point(170, 93);

            //TODO: Попытка расширить максимальное кол-во значений ряда до 1000
            this.numericUpDownSplit.Maximum = new decimal(new int[] {
            //50,
            1000,
            0,
            0,
            0});
            this.numericUpDownSplit.Name = "numericUpDownSplit";
            this.numericUpDownSplit.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSplit.TabIndex = 18;
            this.numericUpDownSplit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // labelSplit
            // 
            this.labelSplit.AutoSize = true;
            this.labelSplit.Location = new System.Drawing.Point(12, 95);
            this.labelSplit.Name = "labelSplit";
            this.labelSplit.Size = new System.Drawing.Size(129, 13);
            this.labelSplit.TabIndex = 19;
            this.labelSplit.Text = "Разбиение ряда (точки):";
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
            this.qpParams.Location = new System.Drawing.Point(12, 241);
            this.qpParams.Name = "qpParams";
            this.qpParams.Size = new System.Drawing.Size(280, 99);
            this.qpParams.TabIndex = 20;
            this.qpParams.TabStop = false;
            this.qpParams.Text = "Оценивыемые параметры";
            // 
            // cbTTend
            // 
            this.cbTTend.AutoSize = true;
            this.cbTTend.Checked = true;
            this.cbTTend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTTend.Location = new System.Drawing.Point(259, 79);
            this.cbTTend.Name = "cbTTend";
            this.cbTTend.Size = new System.Drawing.Size(15, 14);
            this.cbTTend.TabIndex = 7;
            this.cbTTend.UseVisualStyleBackColor = true;
            // 
            // cbRTend
            // 
            this.cbRTend.AutoSize = true;
            this.cbRTend.Checked = true;
            this.cbRTend.CheckState = System.Windows.Forms.CheckState.Checked;
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
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(18, 344);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(223, 13);
            this.lbl.TabIndex = 8;
            this.lbl.Text = "Вывести результат по каждому критерию:";
            // 
            // cbSeparateResult
            // 
            this.cbSeparateResult.AutoSize = true;
            this.cbSeparateResult.Location = new System.Drawing.Point(271, 344);
            this.cbSeparateResult.Name = "cbSeparateResult";
            this.cbSeparateResult.Size = new System.Drawing.Size(15, 14);
            this.cbSeparateResult.TabIndex = 9;
            this.cbSeparateResult.UseVisualStyleBackColor = true;
            this.cbSeparateResult.CheckStateChanged += new System.EventHandler(this.cbSeparateResult_CheckStateChanged);
            // 
            // cbUseAllSeries
            // 
            this.cbUseAllSeries.AutoSize = true;
            this.cbUseAllSeries.Location = new System.Drawing.Point(271, 366);
            this.cbUseAllSeries.Name = "cbUseAllSeries";
            this.cbUseAllSeries.Size = new System.Drawing.Size(15, 14);
            this.cbUseAllSeries.TabIndex = 24;
            this.cbUseAllSeries.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 366);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Использовать все ряды:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 390);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(162, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Использовать F сглаживание:";
            // 
            // cbUseFTransform
            // 
            this.cbUseFTransform.AutoSize = true;
            this.cbUseFTransform.Location = new System.Drawing.Point(271, 390);
            this.cbUseFTransform.Name = "cbUseFTransform";
            this.cbUseFTransform.Size = new System.Drawing.Size(15, 14);
            this.cbUseFTransform.TabIndex = 26;
            this.cbUseFTransform.UseVisualStyleBackColor = true;
            // 
            // numericUpDownCount
            // 
            this.numericUpDownCount.Location = new System.Drawing.Point(170, 67);
            this.numericUpDownCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownCount.Name = "numericUpDownCount";
            this.numericUpDownCount.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCount.TabIndex = 28;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 69);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(98, 13);
            this.labelCount.TabIndex = 27;
            this.labelCount.Text = "Глубина прогноза";
            // 
            // ComplexAnalysis
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(304, 453);
            this.Controls.Add(this.numericUpDownCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.cbUseFTransform);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbUseAllSeries);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbSeparateResult);
            this.Controls.Add(this.qpParams);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.labelSplit);
            this.Controls.Add(this.numericUpDownSplit);
            this.Controls.Add(this.nudRange);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxBestResult);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ComplexAnalysis";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Комплекный анализ";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplit)).EndInit();
            this.qpParams.ResumeLayout(false);
            this.qpParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.NumericUpDown numericUpDownCount;

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox comboBoxBestResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb1;
        private System.Windows.Forms.CheckBox cb4;
        private System.Windows.Forms.CheckBox cb3;
        private System.Windows.Forms.CheckBox cb2;
        private System.Windows.Forms.NumericUpDown nudRange;
        private System.Windows.Forms.NumericUpDown numericUpDownSplit;
        private System.Windows.Forms.Label labelSplit;
        private System.Windows.Forms.GroupBox qpParams;
        private System.Windows.Forms.CheckBox cbTTend;
        private System.Windows.Forms.CheckBox cbRTend;
        private System.Windows.Forms.CheckBox cbMAPE;
        private System.Windows.Forms.CheckBox cbMSE;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbSeparateResult;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.CheckBox cbUseAllSeries;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbUseFTransform;
    }
}