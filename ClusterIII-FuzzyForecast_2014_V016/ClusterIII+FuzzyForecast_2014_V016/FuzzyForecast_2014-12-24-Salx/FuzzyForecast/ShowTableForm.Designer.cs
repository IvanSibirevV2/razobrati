namespace FuzzyForecast {
  partial class ShowTableForm {
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
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.listViewStatistic = new System.Windows.Forms.ListView();
      this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
      this.toolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip
      // 
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave});
      this.toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(617, 25);
      this.toolStrip.TabIndex = 0;
      this.toolStrip.Text = "toolStrip1";
      // 
      // listViewStatistic
      // 
      this.listViewStatistic.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listViewStatistic.GridLines = true;
      this.listViewStatistic.Location = new System.Drawing.Point(0, 25);
      this.listViewStatistic.Name = "listViewStatistic";
      this.listViewStatistic.Size = new System.Drawing.Size(617, 370);
      this.listViewStatistic.TabIndex = 1;
      this.listViewStatistic.UseCompatibleStateImageBehavior = false;
      this.listViewStatistic.View = System.Windows.Forms.View.Details;
      // 
      // toolStripButtonSave
      // 
      this.toolStripButtonSave.Image = global::FuzzyForecast.Properties.Resources.table_save;
      this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonSave.Name = "toolStripButtonSave";
      this.toolStripButtonSave.Size = new System.Drawing.Size(82, 22);
      this.toolStripButtonSave.Text = "Сохранить";
      // 
      // ShowTableForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(617, 395);
      this.Controls.Add(this.listViewStatistic);
      this.Controls.Add(this.toolStrip);
      this.Name = "ShowTableForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Результаты применеия модели";
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ListView listViewStatistic;
    private System.Windows.Forms.ToolStripButton toolStripButtonSave;
  }
}