namespace FuzzyForecast {
  partial class ProgressForm {
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
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.buttonStop = new System.Windows.Forms.Button();
      this.labelMSE = new System.Windows.Forms.Label();
      this.labelIteration = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(12, 12);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(319, 23);
      this.progressBar.TabIndex = 0;
      // 
      // buttonStop
      // 
      this.buttonStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonStop.Location = new System.Drawing.Point(134, 69);
      this.buttonStop.Name = "buttonStop";
      this.buttonStop.Size = new System.Drawing.Size(75, 23);
      this.buttonStop.TabIndex = 1;
      this.buttonStop.Text = "Стоп";
      this.buttonStop.UseVisualStyleBackColor = true;
      this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
      // 
      // labelMSE
      // 
      this.labelMSE.Location = new System.Drawing.Point(9, 38);
      this.labelMSE.Name = "labelMSE";
      this.labelMSE.Size = new System.Drawing.Size(322, 13);
      this.labelMSE.TabIndex = 2;
      this.labelMSE.Text = "MSE";
      // 
      // labelIteration
      // 
      this.labelIteration.AutoSize = true;
      this.labelIteration.Location = new System.Drawing.Point(9, 51);
      this.labelIteration.Name = "labelIteration";
      this.labelIteration.Size = new System.Drawing.Size(37, 13);
      this.labelIteration.TabIndex = 3;
      this.labelIteration.Text = "Эпоха";
      // 
      // ProgressForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonStop;
      this.ClientSize = new System.Drawing.Size(343, 104);
      this.Controls.Add(this.labelIteration);
      this.Controls.Add(this.labelMSE);
      this.Controls.Add(this.buttonStop);
      this.Controls.Add(this.progressBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ProgressForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Обучение нейронной сети";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgressForm_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Button buttonStop;
    private System.Windows.Forms.Label labelMSE;
    private System.Windows.Forms.Label labelIteration;
  }
}