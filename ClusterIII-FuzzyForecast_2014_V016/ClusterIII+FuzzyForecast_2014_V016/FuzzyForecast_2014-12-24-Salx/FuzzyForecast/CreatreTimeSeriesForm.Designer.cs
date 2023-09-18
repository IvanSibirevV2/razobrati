namespace FuzzyForecast {
  partial class CreatreTimeSeriesForm {
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
      this.groupBoxMethod = new System.Windows.Forms.GroupBox();
      this.radioButtonRand = new System.Windows.Forms.RadioButton();
      this.radioButtonNoise = new System.Windows.Forms.RadioButton();
      this.radioButtonPrec = new System.Windows.Forms.RadioButton();
      this.groupBoxFunc = new System.Windows.Forms.GroupBox();
      this.radioButtonCos = new System.Windows.Forms.RadioButton();
      this.radioButtonSin = new System.Windows.Forms.RadioButton();
      this.radioButtonLog = new System.Windows.Forms.RadioButton();
      this.radioButtonSquare = new System.Windows.Forms.RadioButton();
      this.radioButtonLinear = new System.Windows.Forms.RadioButton();
      this.labelStart = new System.Windows.Forms.Label();
      this.groupBoxAttr = new System.Windows.Forms.GroupBox();
      this.labelSpread = new System.Windows.Forms.Label();
      this.textBoxSpread = new System.Windows.Forms.TextBox();
      this.labelNoise = new System.Windows.Forms.Label();
      this.textBoxNoise = new System.Windows.Forms.TextBox();
      this.textBoxCount = new System.Windows.Forms.TextBox();
      this.textBoxStep = new System.Windows.Forms.TextBox();
      this.textBoxStart = new System.Windows.Forms.TextBox();
      this.labelCount = new System.Windows.Forms.Label();
      this.labelStep = new System.Windows.Forms.Label();
      this.groupBoxCoeff = new System.Windows.Forms.GroupBox();
      this.textBoxC = new System.Windows.Forms.TextBox();
      this.textBoxB = new System.Windows.Forms.TextBox();
      this.textBoxA = new System.Windows.Forms.TextBox();
      this.labelC = new System.Windows.Forms.Label();
      this.labelB = new System.Windows.Forms.Label();
      this.labelA = new System.Windows.Forms.Label();
      this.buttonOk = new System.Windows.Forms.Button();
      this.groupBoxMethod.SuspendLayout();
      this.groupBoxFunc.SuspendLayout();
      this.groupBoxAttr.SuspendLayout();
      this.groupBoxCoeff.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBoxMethod
      // 
      this.groupBoxMethod.Controls.Add(this.radioButtonRand);
      this.groupBoxMethod.Controls.Add(this.radioButtonNoise);
      this.groupBoxMethod.Controls.Add(this.radioButtonPrec);
      this.groupBoxMethod.Location = new System.Drawing.Point(12, 12);
      this.groupBoxMethod.Name = "groupBoxMethod";
      this.groupBoxMethod.Size = new System.Drawing.Size(156, 140);
      this.groupBoxMethod.TabIndex = 0;
      this.groupBoxMethod.TabStop = false;
      this.groupBoxMethod.Text = "Метод";
      // 
      // radioButtonRand
      // 
      this.radioButtonRand.AutoSize = true;
      this.radioButtonRand.Location = new System.Drawing.Point(6, 65);
      this.radioButtonRand.Name = "radioButtonRand";
      this.radioButtonRand.Size = new System.Drawing.Size(126, 17);
      this.radioButtonRand.TabIndex = 2;
      this.radioButtonRand.TabStop = true;
      this.radioButtonRand.Text = "Случайные функции";
      this.radioButtonRand.UseVisualStyleBackColor = true;
      this.radioButtonRand.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
      // 
      // radioButtonNoise
      // 
      this.radioButtonNoise.AutoSize = true;
      this.radioButtonNoise.Location = new System.Drawing.Point(6, 42);
      this.radioButtonNoise.Name = "radioButtonNoise";
      this.radioButtonNoise.Size = new System.Drawing.Size(143, 17);
      this.radioButtonNoise.TabIndex = 1;
      this.radioButtonNoise.TabStop = true;
      this.radioButtonNoise.Text = "Зашумленные функции";
      this.radioButtonNoise.UseVisualStyleBackColor = true;
      this.radioButtonNoise.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
      // 
      // radioButtonPrec
      // 
      this.radioButtonPrec.AutoSize = true;
      this.radioButtonPrec.Checked = true;
      this.radioButtonPrec.Location = new System.Drawing.Point(6, 19);
      this.radioButtonPrec.Name = "radioButtonPrec";
      this.radioButtonPrec.Size = new System.Drawing.Size(109, 17);
      this.radioButtonPrec.TabIndex = 0;
      this.radioButtonPrec.TabStop = true;
      this.radioButtonPrec.Text = "Точные функции";
      this.radioButtonPrec.UseVisualStyleBackColor = true;
      this.radioButtonPrec.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
      // 
      // groupBoxFunc
      // 
      this.groupBoxFunc.Controls.Add(this.radioButtonCos);
      this.groupBoxFunc.Controls.Add(this.radioButtonSin);
      this.groupBoxFunc.Controls.Add(this.radioButtonLog);
      this.groupBoxFunc.Controls.Add(this.radioButtonSquare);
      this.groupBoxFunc.Controls.Add(this.radioButtonLinear);
      this.groupBoxFunc.Location = new System.Drawing.Point(174, 12);
      this.groupBoxFunc.Name = "groupBoxFunc";
      this.groupBoxFunc.Size = new System.Drawing.Size(178, 140);
      this.groupBoxFunc.TabIndex = 1;
      this.groupBoxFunc.TabStop = false;
      this.groupBoxFunc.Text = "Выбор функции";
      // 
      // radioButtonCos
      // 
      this.radioButtonCos.AutoSize = true;
      this.radioButtonCos.Location = new System.Drawing.Point(6, 111);
      this.radioButtonCos.Name = "radioButtonCos";
      this.radioButtonCos.Size = new System.Drawing.Size(116, 17);
      this.radioButtonCos.TabIndex = 4;
      this.radioButtonCos.TabStop = true;
      this.radioButtonCos.Text = "Косинус a*cos(b*t)";
      this.radioButtonCos.UseVisualStyleBackColor = true;
      this.radioButtonCos.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
      // 
      // radioButtonSin
      // 
      this.radioButtonSin.AutoSize = true;
      this.radioButtonSin.Location = new System.Drawing.Point(6, 88);
      this.radioButtonSin.Name = "radioButtonSin";
      this.radioButtonSin.Size = new System.Drawing.Size(100, 17);
      this.radioButtonSin.TabIndex = 3;
      this.radioButtonSin.TabStop = true;
      this.radioButtonSin.Text = "Синус a*sin(b*t)";
      this.radioButtonSin.UseVisualStyleBackColor = true;
      this.radioButtonSin.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
      // 
      // radioButtonLog
      // 
      this.radioButtonLog.AutoSize = true;
      this.radioButtonLog.Location = new System.Drawing.Point(6, 65);
      this.radioButtonLog.Name = "radioButtonLog";
      this.radioButtonLog.Size = new System.Drawing.Size(165, 17);
      this.radioButtonLog.TabIndex = 2;
      this.radioButtonLog.TabStop = true;
      this.radioButtonLog.Text = "Логарифмическая a*log(b*t)";
      this.radioButtonLog.UseVisualStyleBackColor = true;
      this.radioButtonLog.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
      // 
      // radioButtonSquare
      // 
      this.radioButtonSquare.AutoSize = true;
      this.radioButtonSquare.Location = new System.Drawing.Point(6, 42);
      this.radioButtonSquare.Name = "radioButtonSquare";
      this.radioButtonSquare.Size = new System.Drawing.Size(162, 17);
      this.radioButtonSquare.TabIndex = 1;
      this.radioButtonSquare.TabStop = true;
      this.radioButtonSquare.Text = "Квадратичная a*t*t + b*t + c";
      this.radioButtonSquare.UseVisualStyleBackColor = true;
      this.radioButtonSquare.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
      // 
      // radioButtonLinear
      // 
      this.radioButtonLinear.AutoSize = true;
      this.radioButtonLinear.Checked = true;
      this.radioButtonLinear.Location = new System.Drawing.Point(6, 19);
      this.radioButtonLinear.Name = "radioButtonLinear";
      this.radioButtonLinear.Size = new System.Drawing.Size(103, 17);
      this.radioButtonLinear.TabIndex = 0;
      this.radioButtonLinear.TabStop = true;
      this.radioButtonLinear.Text = "Линейная a*t+b";
      this.radioButtonLinear.UseVisualStyleBackColor = true;
      this.radioButtonLinear.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
      // 
      // labelStart
      // 
      this.labelStart.AutoSize = true;
      this.labelStart.Location = new System.Drawing.Point(23, 16);
      this.labelStart.Name = "labelStart";
      this.labelStart.Size = new System.Drawing.Size(97, 13);
      this.labelStart.TabIndex = 2;
      this.labelStart.Text = "Начальное время";
      // 
      // groupBoxAttr
      // 
      this.groupBoxAttr.Controls.Add(this.labelSpread);
      this.groupBoxAttr.Controls.Add(this.textBoxSpread);
      this.groupBoxAttr.Controls.Add(this.labelNoise);
      this.groupBoxAttr.Controls.Add(this.textBoxNoise);
      this.groupBoxAttr.Controls.Add(this.textBoxCount);
      this.groupBoxAttr.Controls.Add(this.textBoxStep);
      this.groupBoxAttr.Controls.Add(this.textBoxStart);
      this.groupBoxAttr.Controls.Add(this.labelCount);
      this.groupBoxAttr.Controls.Add(this.labelStep);
      this.groupBoxAttr.Controls.Add(this.labelStart);
      this.groupBoxAttr.Location = new System.Drawing.Point(12, 158);
      this.groupBoxAttr.Name = "groupBoxAttr";
      this.groupBoxAttr.Size = new System.Drawing.Size(212, 155);
      this.groupBoxAttr.TabIndex = 3;
      this.groupBoxAttr.TabStop = false;
      this.groupBoxAttr.Text = "Параметры";
      // 
      // labelSpread
      // 
      this.labelSpread.AutoSize = true;
      this.labelSpread.Location = new System.Drawing.Point(19, 124);
      this.labelSpread.Name = "labelSpread";
      this.labelSpread.Size = new System.Drawing.Size(96, 13);
      this.labelSpread.TabIndex = 9;
      this.labelSpread.Text = "Модуль разброса";
      // 
      // textBoxSpread
      // 
      this.textBoxSpread.Location = new System.Drawing.Point(126, 121);
      this.textBoxSpread.Name = "textBoxSpread";
      this.textBoxSpread.Size = new System.Drawing.Size(66, 20);
      this.textBoxSpread.TabIndex = 8;
      this.textBoxSpread.Text = "1";
      // 
      // labelNoise
      // 
      this.labelNoise.AutoSize = true;
      this.labelNoise.Location = new System.Drawing.Point(40, 97);
      this.labelNoise.Name = "labelNoise";
      this.labelNoise.Size = new System.Drawing.Size(75, 13);
      this.labelNoise.TabIndex = 7;
      this.labelNoise.Text = "Модуль шума";
      // 
      // textBoxNoise
      // 
      this.textBoxNoise.Location = new System.Drawing.Point(126, 94);
      this.textBoxNoise.Name = "textBoxNoise";
      this.textBoxNoise.Size = new System.Drawing.Size(66, 20);
      this.textBoxNoise.TabIndex = 6;
      this.textBoxNoise.Text = "0";
      // 
      // textBoxCount
      // 
      this.textBoxCount.Location = new System.Drawing.Point(126, 68);
      this.textBoxCount.Name = "textBoxCount";
      this.textBoxCount.Size = new System.Drawing.Size(66, 20);
      this.textBoxCount.TabIndex = 5;
      this.textBoxCount.Text = "50";
      // 
      // textBoxStep
      // 
      this.textBoxStep.Location = new System.Drawing.Point(126, 42);
      this.textBoxStep.Name = "textBoxStep";
      this.textBoxStep.Size = new System.Drawing.Size(66, 20);
      this.textBoxStep.TabIndex = 4;
      this.textBoxStep.Text = "1";
      // 
      // textBoxStart
      // 
      this.textBoxStart.Location = new System.Drawing.Point(126, 16);
      this.textBoxStart.Name = "textBoxStart";
      this.textBoxStart.Size = new System.Drawing.Size(66, 20);
      this.textBoxStart.TabIndex = 4;
      this.textBoxStart.Text = "0";
      // 
      // labelCount
      // 
      this.labelCount.AutoSize = true;
      this.labelCount.Location = new System.Drawing.Point(15, 68);
      this.labelCount.Name = "labelCount";
      this.labelCount.Size = new System.Drawing.Size(100, 13);
      this.labelCount.TabIndex = 4;
      this.labelCount.Text = "Количество шагов";
      // 
      // labelStep
      // 
      this.labelStep.AutoSize = true;
      this.labelStep.Location = new System.Drawing.Point(41, 42);
      this.labelStep.Name = "labelStep";
      this.labelStep.Size = new System.Drawing.Size(74, 13);
      this.labelStep.TabIndex = 3;
      this.labelStep.Text = "Шаг времени";
      // 
      // groupBoxCoeff
      // 
      this.groupBoxCoeff.Controls.Add(this.textBoxC);
      this.groupBoxCoeff.Controls.Add(this.textBoxB);
      this.groupBoxCoeff.Controls.Add(this.textBoxA);
      this.groupBoxCoeff.Controls.Add(this.labelC);
      this.groupBoxCoeff.Controls.Add(this.labelB);
      this.groupBoxCoeff.Controls.Add(this.labelA);
      this.groupBoxCoeff.Location = new System.Drawing.Point(230, 158);
      this.groupBoxCoeff.Name = "groupBoxCoeff";
      this.groupBoxCoeff.Size = new System.Drawing.Size(122, 105);
      this.groupBoxCoeff.TabIndex = 6;
      this.groupBoxCoeff.TabStop = false;
      this.groupBoxCoeff.Text = "Коэффициенты";
      // 
      // textBoxC
      // 
      this.textBoxC.Location = new System.Drawing.Point(49, 68);
      this.textBoxC.Name = "textBoxC";
      this.textBoxC.Size = new System.Drawing.Size(66, 20);
      this.textBoxC.TabIndex = 5;
      this.textBoxC.Text = "1";
      // 
      // textBoxB
      // 
      this.textBoxB.Location = new System.Drawing.Point(49, 42);
      this.textBoxB.Name = "textBoxB";
      this.textBoxB.Size = new System.Drawing.Size(66, 20);
      this.textBoxB.TabIndex = 4;
      this.textBoxB.Text = "1";
      // 
      // textBoxA
      // 
      this.textBoxA.Location = new System.Drawing.Point(49, 16);
      this.textBoxA.Name = "textBoxA";
      this.textBoxA.Size = new System.Drawing.Size(66, 20);
      this.textBoxA.TabIndex = 4;
      this.textBoxA.Text = "1";
      // 
      // labelC
      // 
      this.labelC.AutoSize = true;
      this.labelC.Location = new System.Drawing.Point(30, 68);
      this.labelC.Name = "labelC";
      this.labelC.Size = new System.Drawing.Size(13, 13);
      this.labelC.TabIndex = 4;
      this.labelC.Text = "c";
      // 
      // labelB
      // 
      this.labelB.AutoSize = true;
      this.labelB.Location = new System.Drawing.Point(30, 42);
      this.labelB.Name = "labelB";
      this.labelB.Size = new System.Drawing.Size(13, 13);
      this.labelB.TabIndex = 3;
      this.labelB.Text = "b";
      // 
      // labelA
      // 
      this.labelA.AutoSize = true;
      this.labelA.Location = new System.Drawing.Point(30, 16);
      this.labelA.Name = "labelA";
      this.labelA.Size = new System.Drawing.Size(13, 13);
      this.labelA.TabIndex = 2;
      this.labelA.Text = "a";
      // 
      // buttonOk
      // 
      this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOk.Location = new System.Drawing.Point(277, 290);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 7;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
      // 
      // CreatreTimeSeriesForm
      // 
      this.AcceptButton = this.buttonOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(366, 328);
      this.Controls.Add(this.buttonOk);
      this.Controls.Add(this.groupBoxCoeff);
      this.Controls.Add(this.groupBoxAttr);
      this.Controls.Add(this.groupBoxFunc);
      this.Controls.Add(this.groupBoxMethod);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "CreatreTimeSeriesForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Формирование временного ряда";
      this.groupBoxMethod.ResumeLayout(false);
      this.groupBoxMethod.PerformLayout();
      this.groupBoxFunc.ResumeLayout(false);
      this.groupBoxFunc.PerformLayout();
      this.groupBoxAttr.ResumeLayout(false);
      this.groupBoxAttr.PerformLayout();
      this.groupBoxCoeff.ResumeLayout(false);
      this.groupBoxCoeff.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBoxMethod;
    private System.Windows.Forms.GroupBox groupBoxFunc;
    private System.Windows.Forms.RadioButton radioButtonRand;
    private System.Windows.Forms.RadioButton radioButtonNoise;
    private System.Windows.Forms.RadioButton radioButtonPrec;
    private System.Windows.Forms.RadioButton radioButtonCos;
    private System.Windows.Forms.RadioButton radioButtonSin;
    private System.Windows.Forms.RadioButton radioButtonLog;
    private System.Windows.Forms.RadioButton radioButtonSquare;
    private System.Windows.Forms.RadioButton radioButtonLinear;
    private System.Windows.Forms.Label labelStart;
    private System.Windows.Forms.GroupBox groupBoxAttr;
    private System.Windows.Forms.Label labelStep;
    private System.Windows.Forms.TextBox textBoxCount;
    private System.Windows.Forms.TextBox textBoxStep;
    private System.Windows.Forms.TextBox textBoxStart;
    private System.Windows.Forms.Label labelCount;
    private System.Windows.Forms.GroupBox groupBoxCoeff;
    private System.Windows.Forms.TextBox textBoxC;
    private System.Windows.Forms.TextBox textBoxB;
    private System.Windows.Forms.TextBox textBoxA;
    private System.Windows.Forms.Label labelC;
    private System.Windows.Forms.Label labelB;
    private System.Windows.Forms.Label labelA;
    private System.Windows.Forms.Label labelSpread;
    private System.Windows.Forms.TextBox textBoxSpread;
    private System.Windows.Forms.Label labelNoise;
    private System.Windows.Forms.TextBox textBoxNoise;
    private System.Windows.Forms.Button buttonOk;

  }
}