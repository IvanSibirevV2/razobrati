namespace FuzzyForecast
{
    partial class ExtendedTerms
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
            this.upperExtTends = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lowerExtTends = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.upperExtTends)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerExtTends)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(155, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(69, 64);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // upperExtTends
            // 
            this.upperExtTends.Location = new System.Drawing.Point(193, 12);
            this.upperExtTends.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upperExtTends.Name = "upperExtTends";
            this.upperExtTends.Size = new System.Drawing.Size(37, 20);
            this.upperExtTends.TabIndex = 10;
            this.upperExtTends.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upperExtTends.ValueChanged += new System.EventHandler(this.upperExtTends_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Дополнительные верхние термы:";
            // 
            // lowerExtTends
            // 
            this.lowerExtTends.Location = new System.Drawing.Point(193, 38);
            this.lowerExtTends.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lowerExtTends.Name = "lowerExtTends";
            this.lowerExtTends.Size = new System.Drawing.Size(37, 20);
            this.lowerExtTends.TabIndex = 12;
            this.lowerExtTends.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lowerExtTends.ValueChanged += new System.EventHandler(this.lowerExtTends_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Дополнительные нижние термы:";
            // 
            // ExtendedTerms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(242, 97);
            this.Controls.Add(this.lowerExtTends);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.upperExtTends);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExtendedTerms";
            this.Text = "Расширение термов";
            ((System.ComponentModel.ISupportInitialize)(this.upperExtTends)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerExtTends)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.NumericUpDown upperExtTends;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown lowerExtTends;
        private System.Windows.Forms.Label label2;
    }
}