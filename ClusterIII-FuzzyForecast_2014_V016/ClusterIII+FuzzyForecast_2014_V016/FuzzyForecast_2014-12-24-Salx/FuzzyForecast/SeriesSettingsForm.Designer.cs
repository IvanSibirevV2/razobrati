namespace FuzzyForecast {
  partial class SeriesSettingsForm {
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
      this.labelName = new System.Windows.Forms.Label();
      this.labelXName = new System.Windows.Forms.Label();
      this.labelYName = new System.Windows.Forms.Label();
      this.textBoxName = new System.Windows.Forms.TextBox();
      this.textBoxXName = new System.Windows.Forms.TextBox();
      this.textBoxYName = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // buttonOK
      // 
      this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOK.Location = new System.Drawing.Point(117, 120);
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
      this.buttonCancel.Location = new System.Drawing.Point(197, 120);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "Отмена";
      this.buttonCancel.UseVisualStyleBackColor = true;
      // 
      // labelName
      // 
      this.labelName.AutoSize = true;
      this.labelName.Location = new System.Drawing.Point(16, 21);
      this.labelName.Name = "labelName";
      this.labelName.Size = new System.Drawing.Size(84, 13);
      this.labelName.TabIndex = 2;
      this.labelName.Text = "Название ряда";
      // 
      // labelXName
      // 
      this.labelXName.AutoSize = true;
      this.labelXName.Location = new System.Drawing.Point(12, 49);
      this.labelXName.Name = "labelXName";
      this.labelXName.Size = new System.Drawing.Size(88, 13);
      this.labelXName.TabIndex = 3;
      this.labelXName.Text = "Название оси X";
      // 
      // labelYName
      // 
      this.labelYName.AutoSize = true;
      this.labelYName.Location = new System.Drawing.Point(12, 75);
      this.labelYName.Name = "labelYName";
      this.labelYName.Size = new System.Drawing.Size(88, 13);
      this.labelYName.TabIndex = 4;
      this.labelYName.Text = "Название оси Y";
      // 
      // textBoxName
      // 
      this.textBoxName.Location = new System.Drawing.Point(106, 18);
      this.textBoxName.Name = "textBoxName";
      this.textBoxName.Size = new System.Drawing.Size(166, 20);
      this.textBoxName.TabIndex = 5;
      this.textBoxName.Text = "Новый ряд";
      // 
      // textBoxXName
      // 
      this.textBoxXName.Location = new System.Drawing.Point(106, 46);
      this.textBoxXName.Name = "textBoxXName";
      this.textBoxXName.Size = new System.Drawing.Size(166, 20);
      this.textBoxXName.TabIndex = 6;
      this.textBoxXName.Text = "Время";
      // 
      // textBoxYName
      // 
      this.textBoxYName.Location = new System.Drawing.Point(106, 72);
      this.textBoxYName.Name = "textBoxYName";
      this.textBoxYName.Size = new System.Drawing.Size(166, 20);
      this.textBoxYName.TabIndex = 7;
      this.textBoxYName.Text = "Значения ряда";
      // 
      // SeriesSettingsForm
      // 
      this.AcceptButton = this.buttonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(284, 155);
      this.Controls.Add(this.textBoxYName);
      this.Controls.Add(this.textBoxXName);
      this.Controls.Add(this.textBoxName);
      this.Controls.Add(this.labelYName);
      this.Controls.Add(this.labelXName);
      this.Controls.Add(this.labelName);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOK);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "SeriesSettingsForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Свойства ряда";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Label labelXName;
    private System.Windows.Forms.Label labelYName;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.TextBox textBoxXName;
    private System.Windows.Forms.TextBox textBoxYName;
  }
}