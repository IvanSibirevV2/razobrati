namespace FuzzyForecast {
  partial class SFMForm {
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
      this.buttonOk = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.groupBoxFuzzy = new System.Windows.Forms.GroupBox();
      this.labelCountTerms = new System.Windows.Forms.Label();
      this.textBoxCountTerms = new System.Windows.Forms.TextBox();
      this.radioButtonSimple = new System.Windows.Forms.RadioButton();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.labelCross = new System.Windows.Forms.Label();
      this.groupBoxDeFuzzy = new System.Windows.Forms.GroupBox();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.radioButton3 = new System.Windows.Forms.RadioButton();
      this.groupBoxFuzzy.SuspendLayout();
      this.groupBoxDeFuzzy.SuspendLayout();
      this.SuspendLayout();
      // 
      // buttonOk
      // 
      this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOk.Location = new System.Drawing.Point(70, 212);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 8;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      // 
      // buttonCancel
      // 
      this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(151, 212);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 9;
      this.buttonCancel.Text = "Отмена";
      this.buttonCancel.UseVisualStyleBackColor = true;
      // 
      // groupBoxFuzzy
      // 
      this.groupBoxFuzzy.Controls.Add(this.textBox1);
      this.groupBoxFuzzy.Controls.Add(this.labelCross);
      this.groupBoxFuzzy.Controls.Add(this.radioButton2);
      this.groupBoxFuzzy.Controls.Add(this.radioButtonSimple);
      this.groupBoxFuzzy.Controls.Add(this.textBoxCountTerms);
      this.groupBoxFuzzy.Controls.Add(this.labelCountTerms);
      this.groupBoxFuzzy.Location = new System.Drawing.Point(12, 12);
      this.groupBoxFuzzy.Name = "groupBoxFuzzy";
      this.groupBoxFuzzy.Size = new System.Drawing.Size(211, 108);
      this.groupBoxFuzzy.TabIndex = 10;
      this.groupBoxFuzzy.TabStop = false;
      this.groupBoxFuzzy.Text = "Фазификация";
      // 
      // labelCountTerms
      // 
      this.labelCountTerms.AutoSize = true;
      this.labelCountTerms.Location = new System.Drawing.Point(33, 45);
      this.labelCountTerms.Name = "labelCountTerms";
      this.labelCountTerms.Size = new System.Drawing.Size(79, 13);
      this.labelCountTerms.TabIndex = 11;
      this.labelCountTerms.Text = "Число термов";
      // 
      // textBoxCountTerms
      // 
      this.textBoxCountTerms.Location = new System.Drawing.Point(118, 42);
      this.textBoxCountTerms.Name = "textBoxCountTerms";
      this.textBoxCountTerms.Size = new System.Drawing.Size(82, 20);
      this.textBoxCountTerms.TabIndex = 11;
      this.textBoxCountTerms.Text = "10";
      // 
      // radioButtonSimple
      // 
      this.radioButtonSimple.AutoSize = true;
      this.radioButtonSimple.Location = new System.Drawing.Point(12, 19);
      this.radioButtonSimple.Name = "radioButtonSimple";
      this.radioButtonSimple.Size = new System.Drawing.Size(88, 17);
      this.radioButtonSimple.TabIndex = 11;
      this.radioButtonSimple.TabStop = true;
      this.radioButtonSimple.Text = "Равномерно";
      this.radioButtonSimple.UseVisualStyleBackColor = true;
      // 
      // radioButton2
      // 
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new System.Drawing.Point(103, 19);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(97, 17);
      this.radioButton2.TabIndex = 12;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "По класетрам";
      this.radioButton2.UseVisualStyleBackColor = true;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(118, 68);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(82, 20);
      this.textBox1.TabIndex = 14;
      this.textBox1.Text = "0.5";
      // 
      // labelCross
      // 
      this.labelCross.AutoSize = true;
      this.labelCross.Location = new System.Drawing.Point(14, 71);
      this.labelCross.Name = "labelCross";
      this.labelCross.Size = new System.Drawing.Size(98, 13);
      this.labelCross.TabIndex = 13;
      this.labelCross.Text = "Пересечение [0;1)";
      // 
      // groupBoxDeFuzzy
      // 
      this.groupBoxDeFuzzy.Controls.Add(this.radioButton3);
      this.groupBoxDeFuzzy.Controls.Add(this.radioButton1);
      this.groupBoxDeFuzzy.Location = new System.Drawing.Point(12, 126);
      this.groupBoxDeFuzzy.Name = "groupBoxDeFuzzy";
      this.groupBoxDeFuzzy.Size = new System.Drawing.Size(211, 72);
      this.groupBoxDeFuzzy.TabIndex = 11;
      this.groupBoxDeFuzzy.TabStop = false;
      this.groupBoxDeFuzzy.Text = "Дефазификация";
      // 
      // radioButton1
      // 
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new System.Drawing.Point(12, 19);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(101, 17);
      this.radioButton1.TabIndex = 12;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "Центр тяжести";
      this.radioButton1.UseVisualStyleBackColor = true;
      // 
      // radioButton3
      // 
      this.radioButton3.AutoSize = true;
      this.radioButton3.Location = new System.Drawing.Point(12, 42);
      this.radioButton3.Name = "radioButton3";
      this.radioButton3.Size = new System.Drawing.Size(100, 17);
      this.radioButton3.TabIndex = 13;
      this.radioButton3.TabStop = true;
      this.radioButton3.Text = "Метод \"Сонга\"";
      this.radioButton3.UseVisualStyleBackColor = true;
      // 
      // SFMForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(238, 247);
      this.Controls.Add(this.groupBoxDeFuzzy);
      this.Controls.Add(this.groupBoxFuzzy);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOk);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "SFMForm";
      this.ShowInTaskbar = false;
      this.Text = "Настройки ACL-шкалы";
      this.groupBoxFuzzy.ResumeLayout(false);
      this.groupBoxFuzzy.PerformLayout();
      this.groupBoxDeFuzzy.ResumeLayout(false);
      this.groupBoxDeFuzzy.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.GroupBox groupBoxFuzzy;
    private System.Windows.Forms.Label labelCountTerms;
    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.RadioButton radioButtonSimple;
    private System.Windows.Forms.TextBox textBoxCountTerms;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label labelCross;
    private System.Windows.Forms.GroupBox groupBoxDeFuzzy;
    private System.Windows.Forms.RadioButton radioButton3;
    private System.Windows.Forms.RadioButton radioButton1;
  }
}