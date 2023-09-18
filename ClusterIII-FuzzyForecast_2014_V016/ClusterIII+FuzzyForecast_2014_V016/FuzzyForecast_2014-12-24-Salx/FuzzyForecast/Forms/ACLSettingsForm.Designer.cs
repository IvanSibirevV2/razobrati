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
        this.label5 = new System.Windows.Forms.Label();
        this.cbAbsoluteD = new System.Windows.Forms.CheckBox();
        this.label4 = new System.Windows.Forms.Label();
        this.tbDValue = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        this.trackBar1 = new System.Windows.Forms.TrackBar();
        this.textBoxTopLength = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.textBoxCross = new System.Windows.Forms.TextBox();
        this.labelCross = new System.Windows.Forms.Label();
        this.radioButtonCluster = new System.Windows.Forms.RadioButton();
        this.radioButtonSimple = new System.Windows.Forms.RadioButton();
        this.textBoxCountTerms = new System.Windows.Forms.TextBox();
        this.labelCountTerms = new System.Windows.Forms.Label();
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
        this.tabPrecisionScale = new System.Windows.Forms.TabPage();
        this.graphControlPrecision = new ZedGraph.ZedGraphControl();
        this.buttonManual = new System.Windows.Forms.Button();
        this.tabPage3 = new System.Windows.Forms.TabPage();
        this.tabPage1 = new System.Windows.Forms.TabPage();
        this.nudISP = new System.Windows.Forms.NumericUpDown();
        this.label11 = new System.Windows.Forms.Label();
        this.tbLowerBound = new System.Windows.Forms.TextBox();
        this.tbUpperBound = new System.Windows.Forms.TextBox();
        this.label9 = new System.Windows.Forms.Label();
        this.label8 = new System.Windows.Forms.Label();
        this.lowerExtTends = new System.Windows.Forms.NumericUpDown();
        this.label6 = new System.Windows.Forms.Label();
        this.upperExtTends = new System.Windows.Forms.NumericUpDown();
        this.label7 = new System.Windows.Forms.Label();
        this.btnTermCount = new System.Windows.Forms.Button();
        this.tcParams = new System.Windows.Forms.TabControl();
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.button1 = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
        this.tabControlScales.SuspendLayout();
        this.tabPageBaseScale.SuspendLayout();
        this.tabPageTTend.SuspendLayout();
        this.tabPageRTend.SuspendLayout();
        this.tabPageDiff.SuspendLayout();
        this.tabPrecisionScale.SuspendLayout();
        this.tabPage3.SuspendLayout();
        this.tabPage1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudISP)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lowerExtTends)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.upperExtTends)).BeginInit();
        this.tcParams.SuspendLayout();
        this.tabPage2.SuspendLayout();
        this.SuspendLayout();
        // 
        // buttonOk
        // 
        this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.buttonOk.Location = new System.Drawing.Point(412, 456);
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
        this.buttonCancel.Location = new System.Drawing.Point(493, 456);
        this.buttonCancel.Name = "buttonCancel";
        this.buttonCancel.Size = new System.Drawing.Size(75, 23);
        this.buttonCancel.TabIndex = 9;
        this.buttonCancel.Text = "Отмена";
        this.buttonCancel.UseVisualStyleBackColor = true;
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(6, 80);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(129, 13);
        this.label5.TabIndex = 28;
        this.label5.Text = "Фактическое значение:";
        // 
        // cbAbsoluteD
        // 
        this.cbAbsoluteD.AutoSize = true;
        this.cbAbsoluteD.Checked = true;
        this.cbAbsoluteD.CheckState = System.Windows.Forms.CheckState.Checked;
        this.cbAbsoluteD.Location = new System.Drawing.Point(163, 49);
        this.cbAbsoluteD.Name = "cbAbsoluteD";
        this.cbAbsoluteD.Size = new System.Drawing.Size(15, 14);
        this.cbAbsoluteD.TabIndex = 27;
        this.cbAbsoluteD.UseVisualStyleBackColor = true;
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(6, 46);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(151, 13);
        this.label4.TabIndex = 26;
        this.label4.Text = "Абсолютное значение d в %:";
        // 
        // tbDValue
        // 
        this.tbDValue.Location = new System.Drawing.Point(163, 77);
        this.tbDValue.Name = "tbDValue";
        this.tbDValue.Size = new System.Drawing.Size(47, 20);
        this.tbDValue.TabIndex = 25;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(216, 14);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(15, 13);
        this.label3.TabIndex = 24;
        this.label3.Text = "%";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(6, 14);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(67, 13);
        this.label2.TabIndex = 23;
        this.label2.Text = "Значение d:";
        // 
        // numericUpDown1
        // 
        this.numericUpDown1.Location = new System.Drawing.Point(163, 12);
        this.numericUpDown1.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
        this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.numericUpDown1.Name = "numericUpDown1";
        this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
        this.numericUpDown1.TabIndex = 22;
        this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
        this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
        // 
        // trackBar1
        // 
        this.trackBar1.BackColor = System.Drawing.SystemColors.ControlLightLight;
        this.trackBar1.Location = new System.Drawing.Point(237, 12);
        this.trackBar1.Maximum = 99;
        this.trackBar1.Minimum = 1;
        this.trackBar1.Name = "trackBar1";
        this.trackBar1.Size = new System.Drawing.Size(181, 45);
        this.trackBar1.TabIndex = 21;
        this.trackBar1.TickFrequency = 10;
        this.trackBar1.Value = 20;
        this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
        // 
        // textBoxTopLength
        // 
        this.textBoxTopLength.Location = new System.Drawing.Point(132, 82);
        this.textBoxTopLength.Name = "textBoxTopLength";
        this.textBoxTopLength.Size = new System.Drawing.Size(83, 20);
        this.textBoxTopLength.TabIndex = 16;
        this.textBoxTopLength.Text = "0,0";
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(7, 85);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(120, 13);
        this.label1.TabIndex = 15;
        this.label1.Text = "Длина единицы (доля)";
        // 
        // textBoxCross
        // 
        this.textBoxCross.Location = new System.Drawing.Point(133, 56);
        this.textBoxCross.Name = "textBoxCross";
        this.textBoxCross.Size = new System.Drawing.Size(82, 20);
        this.textBoxCross.TabIndex = 14;
        this.textBoxCross.Text = "0,1";
        // 
        // labelCross
        // 
        this.labelCross.AutoSize = true;
        this.labelCross.Location = new System.Drawing.Point(29, 59);
        this.labelCross.Name = "labelCross";
        this.labelCross.Size = new System.Drawing.Size(98, 13);
        this.labelCross.TabIndex = 13;
        this.labelCross.Text = "Пересечение [0;1)";
        // 
        // radioButtonCluster
        // 
        this.radioButtonCluster.AutoSize = true;
        this.radioButtonCluster.Location = new System.Drawing.Point(100, 6);
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
        this.radioButtonSimple.Location = new System.Drawing.Point(6, 6);
        this.radioButtonSimple.Name = "radioButtonSimple";
        this.radioButtonSimple.Size = new System.Drawing.Size(88, 17);
        this.radioButtonSimple.TabIndex = 11;
        this.radioButtonSimple.TabStop = true;
        this.radioButtonSimple.Text = "Равномерно";
        this.radioButtonSimple.UseVisualStyleBackColor = true;
        // 
        // textBoxCountTerms
        // 
        this.textBoxCountTerms.Location = new System.Drawing.Point(133, 30);
        this.textBoxCountTerms.Name = "textBoxCountTerms";
        this.textBoxCountTerms.Size = new System.Drawing.Size(82, 20);
        this.textBoxCountTerms.TabIndex = 11;
        this.textBoxCountTerms.Text = "10";
        // 
        // labelCountTerms
        // 
        this.labelCountTerms.AutoSize = true;
        this.labelCountTerms.Location = new System.Drawing.Point(48, 33);
        this.labelCountTerms.Name = "labelCountTerms";
        this.labelCountTerms.Size = new System.Drawing.Size(79, 13);
        this.labelCountTerms.TabIndex = 11;
        this.labelCountTerms.Text = "Число термов";
        // 
        // radioButtonSong
        // 
        this.radioButtonSong.AutoSize = true;
        this.radioButtonSong.Location = new System.Drawing.Point(6, 29);
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
        this.radioButtonCenter.Location = new System.Drawing.Point(6, 6);
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
        this.buttonGenerate.Location = new System.Drawing.Point(12, 456);
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
        this.tabControlScales.Controls.Add(this.tabPrecisionScale);
        this.tabControlScales.Location = new System.Drawing.Point(12, 153);
        this.tabControlScales.Name = "tabControlScales";
        this.tabControlScales.SelectedIndex = 0;
        this.tabControlScales.Size = new System.Drawing.Size(560, 284);
        this.tabControlScales.TabIndex = 16;
        this.tabControlScales.Click += new System.EventHandler(this.tabControlScales_Click);
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
        // tabPrecisionScale
        // 
        this.tabPrecisionScale.Controls.Add(this.graphControlPrecision);
        this.tabPrecisionScale.Location = new System.Drawing.Point(4, 22);
        this.tabPrecisionScale.Name = "tabPrecisionScale";
        this.tabPrecisionScale.Padding = new System.Windows.Forms.Padding(3);
        this.tabPrecisionScale.Size = new System.Drawing.Size(552, 258);
        this.tabPrecisionScale.TabIndex = 4;
        this.tabPrecisionScale.Text = "Шкала точности";
        this.tabPrecisionScale.UseVisualStyleBackColor = true;
        // 
        // graphControlPrecision
        // 
        this.graphControlPrecision.Dock = System.Windows.Forms.DockStyle.Fill;
        this.graphControlPrecision.Location = new System.Drawing.Point(3, 3);
        this.graphControlPrecision.Name = "graphControlPrecision";
        this.graphControlPrecision.ScrollGrace = 0;
        this.graphControlPrecision.ScrollMaxX = 0;
        this.graphControlPrecision.ScrollMaxY = 0;
        this.graphControlPrecision.ScrollMaxY2 = 0;
        this.graphControlPrecision.ScrollMinX = 0;
        this.graphControlPrecision.ScrollMinY = 0;
        this.graphControlPrecision.ScrollMinY2 = 0;
        this.graphControlPrecision.Size = new System.Drawing.Size(546, 252);
        this.graphControlPrecision.TabIndex = 5;
        // 
        // buttonManual
        // 
        this.buttonManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.buttonManual.Location = new System.Drawing.Point(131, 456);
        this.buttonManual.Name = "buttonManual";
        this.buttonManual.Size = new System.Drawing.Size(113, 23);
        this.buttonManual.TabIndex = 17;
        this.buttonManual.Text = "Настройки шкалы";
        this.buttonManual.UseVisualStyleBackColor = true;
        this.buttonManual.Click += new System.EventHandler(this.buttonManual_Click);
        // 
        // tabPage3
        // 
        this.tabPage3.Controls.Add(this.radioButtonSong);
        this.tabPage3.Controls.Add(this.radioButtonCenter);
        this.tabPage3.Location = new System.Drawing.Point(4, 22);
        this.tabPage3.Name = "tabPage3";
        this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage3.Size = new System.Drawing.Size(552, 109);
        this.tabPage3.TabIndex = 2;
        this.tabPage3.Text = "Дефаззификация";
        this.tabPage3.UseVisualStyleBackColor = true;
        // 
        // tabPage1
        // 
        this.tabPage1.Controls.Add(this.nudISP);
        this.tabPage1.Controls.Add(this.label11);
        this.tabPage1.Controls.Add(this.tbLowerBound);
        this.tabPage1.Controls.Add(this.tbUpperBound);
        this.tabPage1.Controls.Add(this.label9);
        this.tabPage1.Controls.Add(this.label8);
        this.tabPage1.Controls.Add(this.lowerExtTends);
        this.tabPage1.Controls.Add(this.label6);
        this.tabPage1.Controls.Add(this.upperExtTends);
        this.tabPage1.Controls.Add(this.label7);
        this.tabPage1.Controls.Add(this.btnTermCount);
        this.tabPage1.Controls.Add(this.radioButtonSimple);
        this.tabPage1.Controls.Add(this.labelCountTerms);
        this.tabPage1.Controls.Add(this.textBoxCountTerms);
        this.tabPage1.Controls.Add(this.radioButtonCluster);
        this.tabPage1.Controls.Add(this.textBoxTopLength);
        this.tabPage1.Controls.Add(this.labelCross);
        this.tabPage1.Controls.Add(this.label1);
        this.tabPage1.Controls.Add(this.textBoxCross);
        this.tabPage1.Location = new System.Drawing.Point(4, 22);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1.Size = new System.Drawing.Size(552, 109);
        this.tabPage1.TabIndex = 0;
        this.tabPage1.Text = "Фаззификация";
        this.tabPage1.UseVisualStyleBackColor = true;
        // 
        // nudISP
        // 
        this.nudISP.Location = new System.Drawing.Point(257, 57);
        this.nudISP.Name = "nudISP";
        this.nudISP.Size = new System.Drawing.Size(45, 20);
        this.nudISP.TabIndex = 33;
        // 
        // label11
        // 
        this.label11.AutoSize = true;
        this.label11.Location = new System.Drawing.Point(221, 59);
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.Size(27, 13);
        this.label11.TabIndex = 32;
        this.label11.Text = "ISP:";
        // 
        // tbLowerBound
        // 
        this.tbLowerBound.Location = new System.Drawing.Point(429, 31);
        this.tbLowerBound.Name = "tbLowerBound";
        this.tbLowerBound.Size = new System.Drawing.Size(100, 20);
        this.tbLowerBound.TabIndex = 29;
        this.tbLowerBound.Text = "0,0";
        this.tbLowerBound.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        // 
        // tbUpperBound
        // 
        this.tbUpperBound.Location = new System.Drawing.Point(429, 6);
        this.tbUpperBound.Name = "tbUpperBound";
        this.tbUpperBound.Size = new System.Drawing.Size(100, 20);
        this.tbUpperBound.TabIndex = 28;
        this.tbUpperBound.Text = "0,0";
        this.tbUpperBound.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        // 
        // label9
        // 
        this.label9.AutoSize = true;
        this.label9.Location = new System.Drawing.Point(308, 9);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(96, 13);
        this.label9.TabIndex = 27;
        this.label9.Text = "Верхняя граница:";
        // 
        // label8
        // 
        this.label8.AutoSize = true;
        this.label8.Location = new System.Drawing.Point(308, 34);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(94, 13);
        this.label8.TabIndex = 26;
        this.label8.Text = "Нижняя граница:";
        // 
        // lowerExtTends
        // 
        this.lowerExtTends.Location = new System.Drawing.Point(492, 83);
        this.lowerExtTends.Name = "lowerExtTends";
        this.lowerExtTends.Size = new System.Drawing.Size(37, 20);
        this.lowerExtTends.TabIndex = 25;
        this.lowerExtTends.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(308, 85);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(175, 13);
        this.label6.TabIndex = 24;
        this.label6.Text = "Дополнительные нижние термы:";
        // 
        // upperExtTends
        // 
        this.upperExtTends.Location = new System.Drawing.Point(492, 57);
        this.upperExtTends.Name = "upperExtTends";
        this.upperExtTends.Size = new System.Drawing.Size(37, 20);
        this.upperExtTends.TabIndex = 23;
        this.upperExtTends.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // label7
        // 
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(308, 59);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(178, 13);
        this.label7.TabIndex = 22;
        this.label7.Text = "Дополнительные верхние термы:";
        // 
        // btnTermCount
        // 
        this.btnTermCount.Location = new System.Drawing.Point(221, 30);
        this.btnTermCount.Name = "btnTermCount";
        this.btnTermCount.Size = new System.Drawing.Size(81, 23);
        this.btnTermCount.TabIndex = 21;
        this.btnTermCount.Text = "Вычислить";
        this.btnTermCount.UseVisualStyleBackColor = true;
        this.btnTermCount.Click += new System.EventHandler(this.button2_Click);
        // 
        // tcParams
        // 
        this.tcParams.Controls.Add(this.tabPage1);
        this.tcParams.Controls.Add(this.tabPage3);
        this.tcParams.Controls.Add(this.tabPage2);
        this.tcParams.Location = new System.Drawing.Point(12, 12);
        this.tcParams.Name = "tcParams";
        this.tcParams.SelectedIndex = 0;
        this.tcParams.Size = new System.Drawing.Size(560, 135);
        this.tcParams.TabIndex = 18;
        this.tcParams.Click += new System.EventHandler(this.tcParams_Click);
        // 
        // tabPage2
        // 
        this.tabPage2.Controls.Add(this.button1);
        this.tabPage2.Controls.Add(this.label5);
        this.tabPage2.Controls.Add(this.trackBar1);
        this.tabPage2.Controls.Add(this.cbAbsoluteD);
        this.tabPage2.Controls.Add(this.numericUpDown1);
        this.tabPage2.Controls.Add(this.label4);
        this.tabPage2.Controls.Add(this.label2);
        this.tabPage2.Controls.Add(this.tbDValue);
        this.tabPage2.Controls.Add(this.label3);
        this.tabPage2.Location = new System.Drawing.Point(4, 22);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2.Size = new System.Drawing.Size(552, 109);
        this.tabPage2.TabIndex = 3;
        this.tabPage2.Text = "Настройки d";
        this.tabPage2.UseVisualStyleBackColor = true;
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(237, 69);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(101, 23);
        this.button1.TabIndex = 29;
        this.button1.Text = "Сгенерировать";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // ACLSettingsForm
        // 
        this.AcceptButton = this.buttonOk;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.buttonCancel;
        this.ClientSize = new System.Drawing.Size(580, 491);
        this.Controls.Add(this.tcParams);
        this.Controls.Add(this.buttonManual);
        this.Controls.Add(this.tabControlScales);
        this.Controls.Add(this.buttonGenerate);
        this.Controls.Add(this.buttonCancel);
        this.Controls.Add(this.buttonOk);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Name = "ACLSettingsForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Настройки ACL-шкалы";
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
        this.tabControlScales.ResumeLayout(false);
        this.tabPageBaseScale.ResumeLayout(false);
        this.tabPageTTend.ResumeLayout(false);
        this.tabPageRTend.ResumeLayout(false);
        this.tabPageDiff.ResumeLayout(false);
        this.tabPrecisionScale.ResumeLayout(false);
        this.tabPage3.ResumeLayout(false);
        this.tabPage3.PerformLayout();
        this.tabPage1.ResumeLayout(false);
        this.tabPage1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudISP)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lowerExtTends)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.upperExtTends)).EndInit();
        this.tcParams.ResumeLayout(false);
        this.tabPage2.ResumeLayout(false);
        this.tabPage2.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Label labelCountTerms;
    private System.Windows.Forms.RadioButton radioButtonCluster;
    private System.Windows.Forms.RadioButton radioButtonSimple;
    private System.Windows.Forms.TextBox textBoxCountTerms;
    private System.Windows.Forms.TextBox textBoxCross;
    private System.Windows.Forms.Label labelCross;
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
    private System.Windows.Forms.TabPage tabPageDiff;
    private ZedGraph.ZedGraphControl graphControlDiff;
    private System.Windows.Forms.TrackBar trackBar1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbDValue;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.CheckBox cbAbsoluteD;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabControl tcParams;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button btnTermCount;
    private System.Windows.Forms.NumericUpDown lowerExtTends;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown upperExtTends;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox tbLowerBound;
    private System.Windows.Forms.TextBox tbUpperBound;
    private System.Windows.Forms.NumericUpDown nudISP;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TabPage tabPrecisionScale;
    private ZedGraph.ZedGraphControl graphControlPrecision;
  }
}