namespace FuzzyForecast
{
    partial class FForecastModelSettings
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbFuncScale = new System.Windows.Forms.Label();
            this.tbFuncScale = new System.Windows.Forms.TextBox();
            this.cbReplaceSource = new System.Windows.Forms.CheckBox();
            this.lblReplaceSource = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(120, 68);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(201, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbFuncScale
            // 
            this.lbFuncScale.AutoSize = true;
            this.lbFuncScale.Location = new System.Drawing.Point(12, 16);
            this.lbFuncScale.Name = "lbFuncScale";
            this.lbFuncScale.Size = new System.Drawing.Size(127, 13);
            this.lbFuncScale.TabIndex = 2;
            this.lbFuncScale.Text = "Шаг базисной функции:";
            // 
            // tbFuncScale
            // 
            this.tbFuncScale.Location = new System.Drawing.Point(176, 12);
            this.tbFuncScale.Name = "tbFuncScale";
            this.tbFuncScale.Size = new System.Drawing.Size(100, 20);
            this.tbFuncScale.TabIndex = 3;
            this.tbFuncScale.Text = "5";
            // 
            // cbReplaceSource
            // 
            this.cbReplaceSource.AutoSize = true;
            this.cbReplaceSource.Location = new System.Drawing.Point(176, 39);
            this.cbReplaceSource.Name = "cbReplaceSource";
            this.cbReplaceSource.Size = new System.Drawing.Size(15, 14);
            this.cbReplaceSource.TabIndex = 4;
            this.cbReplaceSource.UseVisualStyleBackColor = true;
            // 
            // lblReplaceSource
            // 
            this.lblReplaceSource.AutoSize = true;
            this.lblReplaceSource.Location = new System.Drawing.Point(12, 40);
            this.lblReplaceSource.Name = "lblReplaceSource";
            this.lblReplaceSource.Size = new System.Drawing.Size(158, 13);
            this.lblReplaceSource.TabIndex = 5;
            this.lblReplaceSource.Text = "Добавить результат в проект";
            // 
            // FForecastModelSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(288, 103);
            this.Controls.Add(this.lblReplaceSource);
            this.Controls.Add(this.cbReplaceSource);
            this.Controls.Add(this.tbFuncScale);
            this.Controls.Add(this.lbFuncScale);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FForecastModelSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "F - преобразования";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbFuncScale;
        private System.Windows.Forms.TextBox tbFuncScale;
        private System.Windows.Forms.CheckBox cbReplaceSource;
        private System.Windows.Forms.Label lblReplaceSource;
    }
}