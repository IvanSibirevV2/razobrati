namespace FuzzyForecast {
  partial class ACLSettingsForm {
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
        this.components = new System.ComponentModel.Container();
        this.buttonOk = new System.Windows.Forms.Button();
        this.buttonCancel = new System.Windows.Forms.Button();
        this.groupBoxFuzzy = new System.Windows.Forms.GroupBox();
        this.buttonCalc = new System.Windows.Forms.Button();
        this.textBoxError = new System.Windows.Forms.TextBox();
        this.labelError = new System.Windows.Forms.Label();
        this.checkBoxTermCount = new System.Windows.Forms.CheckBox();
        this.textBoxTopLength = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.textBoxCross = new System.Windows.Forms.TextBox();
        this.labelCross = new System.Windows.Forms.Label();
        this.radioButtonCluster = new System.Windows.Forms.RadioButton();
        this.radioButtonSimple = new System.Windows.Forms.RadioButton();
        this.textBoxCountTerms = new System.Windows.Forms.TextBox();
        this.labelCountTerms = new System.Windows.Forms.Label();
        this.groupBoxDeFuzzy = new System.Windows.Forms.GroupBox();
        this.radioButtonSong = new System.Windows.Forms.RadioButton();
        this.radioButtonCenter = new System.Windows.Forms.RadioButton();
        this.buttonGenerate = new System.Windows.Forms.Button();
        this.tabControlScales = new System.Windows.Forms.TabControl();
        this.tabPageBaseScale = new System.Windows.Forms.TabPage();
        this.graphControlBaseScale = new ZedGraph.ZedGraphControl();
        this.tabPageTTend = new System.Windows.Forms.TabPage();
        this.graphControlTTend = new ZedGraph.ZedGraphControl();
        this.tabPageRTend = new System.Windows.Forms.TabPage();
        this.graphControlRTend = new ZedGraph.ZedGraphControl();
        this.tabPageDiff = new System.Windows.Forms.TabPage();
        this.graphControlDiff = new ZedGraph.ZedGraphControl();
        this.buttonManual = new System.Windows.Forms.Button();
        this.trackBar1 = new System.Windows.Forms.TrackBar();
        this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.groupBoxFuzzy.SuspendLayout();
        this.groupBoxDeFuzzy.SuspendLayout();
        this.tabControlScales.SuspendLayout();
        this.tabPageBaseScale.SuspendLayout();
        this.tabPageTTend.SuspendLayout();
        this.tabPageRTend.SuspendLayout();
        this.tabPageDiff.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
        this.SuspendLayout();
        // 
        // buttonOk
        // 
        this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.buttonOk.Location = new System.Drawing.Point(416, 475);
        this.buttonOk.Name = "buttonOk";
        this.buttonOk.Size = new System.Drawing.Size(75, 23);
        this.buttonOk.TabIndex = 8;
        this.buttonOk.Text = "OK";
        this.buttonOk.UseVisualStyleBackColor = true;
        this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
        // 
        // buttonCancel
        // 
        this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.buttonCancel.Location = new System.Drawing.Point(497, 475);
        this.buttonCancel.Name = "buttonCancel";
        this.buttonCancel.Size = new System.Drawing.Size(75, 23);
        this.buttonCancel.TabIndex = 9;
        this.buttonCancel.Text = "Отмена";
        this.buttonCancel.UseVisualStyleBackColor = true;
        // 
        // groupBoxFuzzy
        // 
        this.groupBoxFuzzy.Controls.Add(this.label3);
        this.groupBoxFuzzy.Controls.Add(this.label2);
        this.groupBoxFuzzy.Controls.Add(this.numericUpDown1);
        this.groupBoxFuzzy.Controls.Add(this.trackBar1);
        this.groupBoxFuzzy.Controls.Add(this.buttonCalc);
        this.groupBoxFuzzy.Controls.Add(this.textBoxError);
        this.groupBoxFuzzy.Controls.Add(this.labelError);
        this.groupBoxFuzzy.Controls.Add(this.checkBoxTermCount);
        this.groupBoxFuzzy.Controls.Add(this.textBoxTopLength);
        this.groupBoxFuzzy.Controls.Add(this.label1);
        this.groupBoxFuzzy.Controls.Add(this.textBoxCross);
        this.groupBoxFuzzy.Controls.Add(this.labelCross);
        this.groupBoxFuzzy.Controls.Add(this.radioButtonCluster);
        this.groupBoxFuzzy.Controls.Add(this.radioButtonSimple);
        this.groupBoxFuzzy.Controls.Add(this.textBoxCountTerms);
        this.groupBoxFuzzy.Controls.Add(this.labelCountTerms);
        this.groupBoxFuzzy.Location = new System.Drawing.Point(12, 12);
        this.groupBoxFuzzy.Name = "groupBoxFuzzy";
        this.groupBoxFuzzy.Size = new System.Drawing.Size(402, 167);
        this.groupBoxFuzzy.TabIndex = 10;
        this.groupBoxFuzzy.TabStop = false;
        this.groupBoxFuzzy.Text = "Фазификация";
        // 
        // buttonCalc
        // 
        this.buttonCalc.Enabled = false;
        this.buttonCalc.Location = new System.Drawing.Point(233, 65);
        this.buttonCalc.Name = "buttonCalc";
        this.buttonCalc.Size = new System.Drawing.Size(82, 23);
        this.buttonCalc.TabIndex = 20;
        this.buttonCalc.Text = "Вычислить";
        this.buttonCalc.UseVisualStyleBackColor = true;
        this.buttonCalc.Click += new System.EventHandler(this.buttonCalc_Click);
        // 
        // textBoxError
        // 
        this.textBoxError.Enabled = false;
        this.textBoxError.Location = new System.Drawing.Point(306, 44);
        this.textBoxError.Name = "textBoxError";
        this.textBoxError.Size = new System.Drawing.Size(82, 20);
        this.textBoxError.TabIndex = 19;
        this.textBoxError.Text = "1,0";
        // 
        // labelError
        // 
        this.labelError.AutoSize = true;
        this.labelError.Location = new System.Drawing.Point(230, 44);
        this.labelError.Name = "labelError";
        this.labelError.Size = new System.Drawing.Size(58, 13);
        this.labelError.TabIndex = 18;
        this.labelError.Text = "Ошибка %";
        // 
        // checkBoxTermCount
        // 
        this.checkBoxTermCount.AutoSize = true;
        this.checkBoxTermCount.Location = new System.Drawing.Point(223, 20);
        this.checkBoxTermCount.Name = "checkBoxTermCount";
        this.checkBoxTermCount.Size = new System.Drawing.Size(153, 17);
        this.checkBoxTermCount.TabIndex = 17;
        this.checkBoxTermCount.Text = "Вычислять число термов";
        this.checkBoxTermCount.UseVisualStyleBackColor = true;
        this.checkBoxTermCount.CheckedChanged += new System.EventHandler(this.checkBoxTermCount_CheckedChanged);
        // 
        // textBoxTopLength
        // 
        this.textBoxTopLength.Location = new System.Drawing.Point(134, 94);
        this.textBoxTopLength.Name = "textBoxTopLength";
        this.textBoxTopLength.Size = new System.Drawing.Size(82, 20);
        this.textBoxTopLength.TabIndex = 16;
        this.textBoxTopLength.Text = "0,0";
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(9, 97);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(120, 13);
        this.label1.TabIndex = 15;
        this.label1.Text = "Длина единицы (доля)";
        // 
        // textBoxCross
        // 
        this.textBoxCross.Location = new System.Drawing.Point(135, 68);
        this.textBoxCross.Name = "textBoxCross";
        this.textBoxCross.Size = new System.Drawing.Size(82, 20);
        this.textBoxCross.TabIndex = 14;
        this.textBoxCross.Text = "0,1";
        // 
        // labelCross
        // 
        this.labelCross.AutoSize = true;
        this.labelCross.Location = new System.Drawing.Point(31, 71);
        this.labelCross.Name = "labelCross";
        this.labelCross.Size = new System.Drawing.Size(98, 13);
        this.labelCross.TabIndex = 13;
        this.labelCross.Text = "Пересечение [0;1)";
        // 
        // radioButtonCluster
        // 
        this.radioButtonCluster.AutoSize = true;
        this.radioButtonCluster.Location = new System.Drawing.Point(120, 19);
        this.radioButtonCluster.Name = "radioButtonCluster";
        this.radioButtonCluster.Size = new System.Drawing.Size(97, 17);
        this.radioButtonCluster.TabIndex = 12;
        this.radioButtonCluster.Text = "По класетрам";
        this.radioButtonCluster.UseVisualStyleBackColor = true;
        // 
        // radioButtonSimple
        // 
        this.radioButtonSimple.AutoSize = true;
        this.radioButtonSimple.Checked = true;
        this.radioButtonSimple.Location = new System.Drawing.Point(26, 19);
        this.radioButtonSimple.Name = "radioButtonSimple";
        this.radioButtonSimple.Size = new System.Drawing.Size(88, 17);
        this.radioButtonSimple.TabIndex = 11;
        this.radioButtonSimple.TabStop = true;
        this.radioButtonSimple.Text = "Равномерно";
        this.radioButtonSimple.UseVisualStyleBackColor = true;
        // 
        // textBoxCountTerms
        // 
        this.textBoxCountTerms.Location = new System.Drawing.Point(135, 42);
        this.textBoxCountTerms.Name = "textBoxCountTerms";
        this.textBoxCountTerms.Size = new System.Drawing.Size(82, 20);
        this.textBoxCountTerms.TabIndex = 11;
        this.textBoxCountTerms.Text = "10";
        // 
        // labelCountTerms
        // 
        this.labelCountTerms.AutoSize = true;
        this.labelCountTerms.Location = new System.Drawing.Point(50, 45);
        this.labelCountTerms.Name = "labelCountTerms";
        this.labelCountTerms.Size = new System.Drawing.Size(79, 13);
        this.labelCountTerms.TabIndex = 11;
        this.labelCountTerms.Text = "Число термов";
        // 
        // groupBoxDeFuzzy
        // 
        this.groupBoxDeFuzzy.Controls.Add(this.radioButtonSong);
        this.groupBoxDeFuzzy.Controls.Add(this.radioButtonCenter);
        this.groupBoxDeFuzzy.Location = new System.Drawing.Point(420, 12);
        this.groupBoxDeFuzzy.Name = "groupBoxDeFuzzy";
        this.groupBoxDeFuzzy.Size = new System.Drawing.Size(152, 167);
        this.groupBoxDeFuzzy.TabIndex = 11;
        this.groupBoxDeFuzzy.TabStop = false;
        this.groupBoxDeFuzzy.Text = "Дефазификация";
        // 
        // radioButtonSong
        // 
        this.radioButtonSong.AutoSize = true;
        this.radioButtonSong.Location = new System.Drawing.Point(12, 42);
        this.radioButtonSong.Name = "radioButtonSong";
        this.radioButtonSong.Size = new System.Drawing.Size(100, 17);
        this.radioButtonSong.TabIndex = 13;
        this.radioButtonSong.Text = "Метод \"Сонга\"";
        this.radioButtonSong.UseVisualStyleBackColor = true;
        // 
        // radioButtonCenter
        // 
        this.radioButtonCenter.AutoSize = true;
        this.radioButtonCenter.Checked = true;
        this.radioButtonCenter.Location = new System.Drawing.Point(12, 19);
        this.radioButtonCenter.Name = "radioButtonCenter";
        this.radioButtonCenter.Size = new System.Drawing.Size(101, 17);
        this.radioButtonCenter.TabIndex = 12;
        this.radioButtonCenter.TabStop = true;
        this.radioButtonCenter.Text = "Центр тяжести";
        this.radioButtonCenter.UseVisualStyleBackColor = true;
        // 
        // buttonGenerate
        // 
        this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.buttonGenerate.Location = new System.Drawing.Point(12, 475);
        this.buttonGenerate.Name = "buttonGenerate";
        this.buttonGenerate.Size = new System.Drawing.Size(113, 23);
        this.buttonGenerate.TabIndex = 15;
        this.buttonGenerate.Text = "Сгенерировать";
        this.buttonGenerate.UseVisualStyleBackColor = true;
        this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
        // 
        // tabControlScales
        // 
        this.tabControlScales.Controls.Add(this.tabPageBaseScale);
        this.tabControlScales.Controls.Add(this.tabPageTTend);
        this.tabControlScales.Controls.Add(this.tabPageRTend);
        this.tabControlScales.Controls.Add(this.tabPageDiff);
        this.tabControlScales.Location = new System.Drawing.Point(12, 185);
        this.tabControlScales.Name = "tabControlScales";
        this.tabControlScales.SelectedIndex = 0;
        this.tabControlScales.Size = new System.Drawing.Size(560, 284);
        this.tabControlScales.TabIndex = 16;
        // 
        // tabPageBaseScale
        // 
        this.tabPageBaseScale.Controls.Add(this.graphControlBaseScale);
        this.tabPageBaseScale.Location = new System.Drawing.Point(4, 22);
        this.tabPageBaseScale.Name = "tabPageBaseScale";
        this.tabPageBaseScale.Padding = new System.Windows.Forms.Padding(3);
        this.tabPageBaseScale.Size = new System.Drawing.Size(552, 258);
        this.tabPageBaseScale.TabIndex = 0;
        this.tabPageBaseScale.Text = "Базовая шкала";
        this.tabPageBaseScale.UseVisualStyleBackColor = true;
        // 
        // graphControlBaseScale
        // 
        this.graphControlBaseScale.Dock = System.Windows.Forms.DockStyle.Fill;
        this.graphControlBaseScale.Location = new System.Drawing.Point(3, 3);
        this.graphControlBaseScale.Name = "graphControlBaseScale";
        this.graphControlBaseScale.ScrollGrace = 0;
        this.graphControlBaseScale.ScrollMaxX = 0;
        this.graphControlBaseScale.ScrollMaxY = 0;
        this.graphControlBaseScale.ScrollMaxY2 = 0;
        this.graphControlBaseScale.ScrollMinX = 0;
        this.graphControlBaseScale.ScrollMinY = 0;
        this.graphControlBaseScale.ScrollMinY2 = 0;
        this.graphControlBaseScale.Size = new System.Drawing.Size(546, 252);
        this.graphControlBaseScale.TabIndex = 1;
        // 
        // tabPageTTend
        // 
        this.tabPageTTend.Controls.Add(this.graphControlTTend);
        this.tabPageTTend.Location = new System.Drawing.Point(4, 22);
        this.tabPageTTend.Name = "tabPageTTend";
        this.tabPageTTend.Padding = new System.Windows.Forms.Padding(3);
        this.tabPageTTend.Size = new System.Drawing.Size(552, 258);
        this.tabPageTTend.TabIndex = 1;
        this.tabPageTTend.Text = "Типы тенденций";
        this.tabPageTTend.UseVisualStyleBackColor = true;
        // 
        // graphControlTTend
        // 
        this.graphControlTTend.Dock = System.Windows.Forms.DockStyle.Fill;
        this.graphControlTTend.Location = new System.Drawing.Point(3, 3);
        this.graphControlTTend.Name = "graphControlTTend";
        this.graphControlTTend.ScrollGrace = 0;
        this.graphControlTTend.ScrollMaxX = 0;
        this.graphControlTTend.ScrollMaxY = 0;
        this.graphControlTTend.ScrollMaxY2 = 0;
        this.graphControlTTend.ScrollMinX = 0;
        this.graphControlTTend.ScrollMinY = 0;
        this.graphControlTTend.ScrollMinY2 = 0;
        this.graphControlTTend.Size = new System.Drawing.Size(546, 252);
        this.graphControlTTend.TabIndex = 2;
        // 
        // tabPageRTend
        // 
        this.tabPageRTend.Controls.Add(this.graphControlRTend);
        this.tabPageRTend.Location = new System.Drawing.Point(4, 22);
        this.tabPageRTend.Name = "tabPageRTend";
        this.tabPageRTend.Padding = new System.Windows.Forms.Padding(3);
        this.tabPageRTend.Size = new System.Drawing.Size(552, 258);
        this.tabPageRTend.TabIndex = 2;
        this.tabPageRTend.Text = "Шкала интенсивности";
        this.tabPageRTend.UseVisualStyleBackColor = true;
        // 
        // graphControlRTend
        // 
        this.graphControlRTend.Dock = System.Windows.Forms.DockStyle.Fill;
        this.graphControlRTend.Location = new System.Drawing.Point(3, 3);
        this.graphControlRTend.Name = "graphControlRTend";
        this.graphControlRTend.ScrollGrace = 0;
        this.graphControlRTend.ScrollMaxX = 0;
        this.graphControlRTend.ScrollMaxY = 0;
        this.graphControlRTend.ScrollMaxY2 = 0;
        this.graphControlRTend.ScrollMinX = 0;
        this.graphControlRTend.ScrollMinY = 0;
        this.graphControlRTend.ScrollMinY2 = 0;
        this.graphControlRTend.Size = new System.Drawing.Size(546, 252);
        this.graphControlRTend.TabIndex = 3;
        // 
        // tabPageDiff
        // 
        this.tabPageDiff.Controls.Add(this.graphControlDiff);
        this.tabPageDiff.Location = new System.Drawing.Point(4, 22);
        this.tabPageDiff.Name = "tabPageDiff";
        this.tabPageDiff.Padding = new System.Windows.Forms.Padding(3);
        this.tabPageDiff.Size = new System.Drawing.Size(552, 258);
        this.tabPageDiff.TabIndex = 3;
        this.tabPageDiff.Text = "Шкала разности";
        this.tabPageDiff.UseVisualStyleBackColor = true;
        // 
        // graphControlDiff
        // 
        this.graphControlDiff.Dock = System.Windows.Forms.DockStyle.Fill;
        this.graphControlDiff.Location = new System.Drawing.Point(3, 3);
        this.graphControlDiff.Name = "graphControlDiff";
        this.graphControlDiff.ScrollGrace = 0;
        this.graphControlDiff.ScrollMaxX = 0;
        this.graphControlDiff.ScrollMaxY = 0;
        this.graphControlDiff.ScrollMaxY2 = 0;
        this.graphControlDiff.ScrollMinX = 0;
        this.graphControlDiff.ScrollMinY = 0;
        this.graphControlDiff.ScrollMinY2 = 0;
        this.graphControlDiff.Size = new System.Drawing.Size(546, 252);
        this.graphControlDiff.TabIndex = 4;
        // 
        // buttonManual
        // 
        this.buttonManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.buttonManual.Location = new System.Drawing.Point(131, 475);
        this.buttonManual.Name = "buttonManual";
        this.buttonManual.Size = new System.Drawing.Size(113, 23);
        this.buttonManual.TabIndex = 17;
        this.buttonManual.Text = "Настройки шкалы";
        this.buttonManual.UseVisualStyleBackColor = true;
        this.buttonManual.Click += new System.EventHandler(this.buttonManual_Click);
        // 
        // trackBar1
        // 
        this.trackBar1.Location = new System.Drawing.Point(135, 116);
        this.trackBar1.Maximum = 100;
        this.trackBar1.Minimum = 1;
        this.trackBar1.Name = "trackBar1";
        this.trackBar1.Size = new System.Drawing.Size(181, 45);
        this.trackBar1.TabIndex = 21;
        this.trackBar1.TickFrequency = 10;
        this.trackBar1.Value = 1;
        this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
        // 
        // numericUpDown1
        // 
        this.numericUpDown1.Location = new System.Drawing.Point(329, 116);
        this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.numericUpDown1.Name = "numericUpDown1";
        this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
        this.numericUpDown1.TabIndex = 22;
        this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(62, 123);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(67, 13);
        this.label2.TabIndex = 23;
        this.label2.Text = "Значение d:";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(381, 118);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(15, 13);
        this.label3.TabIndex = 24;
        this.label3.Text = "%";
        // 
        // ACLSettingsForm
        // 
        this.AcceptButton = this.buttonOk;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.buttonCancel;
        this.ClientSize = new System.Drawing.Size(584, 510);
        this.Controls.Add(this.buttonManual);
        this.Controls.Add(this.tabControlScales);
        this.Controls.Add(this.buttonGenerate);
        this.Controls.Add(this.groupBoxDeFuzzy);
        this.Controls.Add(this.groupBoxFuzzy);
        this.Controls.Add(this.buttonCancel);
        this.Controls.Add(this.buttonOk);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Name = "ACLSettingsForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Настройки ACL-шкалы";
        this.groupBoxFuzzy.ResumeLayout(false);
        this.groupBoxFuzzy.PerformLayout();
        this.groupBoxDeFuzzy.ResumeLayout(false);
        this.groupBoxDeFuzzy.PerformLayout();
        this.tabControlScales.ResumeLayout(false);
        this.tabPageBaseScale.ResumeLayout(false);
        this.tabPageTTend.ResumeLayout(false);
        this.tabPageRTend.ResumeLayout(false);
        this.tabPageDiff.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.GroupBox groupBoxFuzzy;
    private System.Windows.Forms.Label labelCountTerms;
    private System.Windows.Forms.RadioButton radioButtonCluster;
    private System.Windows.Forms.RadioButton radioButtonSimple;
    private System.Windows.Forms.TextBox textBoxCountTerms;
    private System.Windows.Forms.TextBox textBoxCross;
    private System.Windows.Forms.Label labelCross;
    private System.Windows.Forms.GroupBox groupBoxDeFuzzy;
    private System.Windows.Forms.RadioButton radioButtonSong;
    private System.Windows.Forms.RadioButton radioButtonCenter;
    private System.Windows.Forms.TextBox textBoxTopLength;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button buttonGenerate;
    private System.Windows.Forms.TabControl tabControlScales;
    private System.Windows.Forms.TabPage tabPageBaseScale;
    private System.Windows.Forms.TabPage tabPageTTend;
    private System.Windows.Forms.TabPage tabPageRTend;
    private System.Windows.Forms.Button buttonManual;
    private ZedGraph.ZedGraphControl graphControlBaseScale;
    private ZedGraph.ZedGraphControl graphControlTTend;
    private ZedGraph.ZedGraphControl graphControlRTend;
    private System.Windows.Forms.TextBox textBoxError;
    private System.Windows.Forms.Label labelError;
    private System.Windows.Forms.CheckBox checkBoxTermCount;
    private System.Windows.Forms.Button buttonCalc;
    private System.Windows.Forms.TabPage tabPageDiff;
    private ZedGraph.ZedGraphControl graphControlDiff;
    private System.Windows.Forms.TrackBar trackBar1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.Label label3;
  }
}