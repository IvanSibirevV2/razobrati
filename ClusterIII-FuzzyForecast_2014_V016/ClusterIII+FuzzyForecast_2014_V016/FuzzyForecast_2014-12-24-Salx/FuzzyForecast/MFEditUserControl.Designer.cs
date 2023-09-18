namespace FuzzyForecast {
  partial class MFEdit {
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      this.groupBoxMain = new System.Windows.Forms.GroupBox();
      this.dataGridViewTerms = new System.Windows.Forms.DataGridView();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
      this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
      this.toolStripButtonDraw = new System.Windows.Forms.ToolStripButton();
      this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
      this.toolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnX1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnX2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnX3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnX4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.groupBoxMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize) (this.dataGridViewTerms)).BeginInit();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBoxMain
      // 
      this.groupBoxMain.Controls.Add(this.dataGridViewTerms);
      this.groupBoxMain.Controls.Add(this.toolStrip1);
      this.groupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBoxMain.Location = new System.Drawing.Point(0, 0);
      this.groupBoxMain.Name = "groupBoxMain";
      this.groupBoxMain.Size = new System.Drawing.Size(549, 266);
      this.groupBoxMain.TabIndex = 0;
      this.groupBoxMain.TabStop = false;
      this.groupBoxMain.Text = "Нечетике термы";
      // 
      // dataGridViewTerms
      // 
      this.dataGridViewTerms.AllowUserToAddRows = false;
      this.dataGridViewTerms.AllowUserToDeleteRows = false;
      this.dataGridViewTerms.BackgroundColor = System.Drawing.SystemColors.Window;
      this.dataGridViewTerms.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dataGridViewTerms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridViewTerms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnX1,
            this.ColumnX2,
            this.ColumnX3,
            this.ColumnX4});
      this.dataGridViewTerms.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridViewTerms.Location = new System.Drawing.Point(3, 41);
      this.dataGridViewTerms.MultiSelect = false;
      this.dataGridViewTerms.Name = "dataGridViewTerms";
      this.dataGridViewTerms.Size = new System.Drawing.Size(543, 222);
      this.dataGridViewTerms.TabIndex = 1;
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonDelete,
            this.toolStripButtonDraw,
            this.toolStripButtonSave,
            this.toolStripButtonLoad});
      this.toolStrip1.Location = new System.Drawing.Point(3, 16);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(543, 25);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip";
      // 
      // toolStripButtonAdd
      // 
      this.toolStripButtonAdd.Image = global::FuzzyForecast.Properties.Resources.Add;
      this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.White;
      this.toolStripButtonAdd.Name = "toolStripButtonAdd";
      this.toolStripButtonAdd.Size = new System.Drawing.Size(77, 22);
      this.toolStripButtonAdd.Text = "Добавить";
      this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
      // 
      // toolStripButtonDelete
      // 
      this.toolStripButtonDelete.Image = global::FuzzyForecast.Properties.Resources.Remove;
      this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.White;
      this.toolStripButtonDelete.Name = "toolStripButtonDelete";
      this.toolStripButtonDelete.Size = new System.Drawing.Size(71, 22);
      this.toolStripButtonDelete.Text = "Удалить";
      this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
      // 
      // toolStripButtonDraw
      // 
      this.toolStripButtonDraw.Image = global::FuzzyForecast.Properties.Resources.chart_line;
      this.toolStripButtonDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonDraw.Name = "toolStripButtonDraw";
      this.toolStripButtonDraw.Size = new System.Drawing.Size(65, 22);
      this.toolStripButtonDraw.Text = "График";
      this.toolStripButtonDraw.Click += new System.EventHandler(this.toolStripButtonDraw_Click);
      // 
      // toolStripButtonSave
      // 
      this.toolStripButtonSave.Image = global::FuzzyForecast.Properties.Resources.save;
      this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonSave.Name = "toolStripButtonSave";
      this.toolStripButtonSave.Size = new System.Drawing.Size(82, 22);
      this.toolStripButtonSave.Text = "Сохранить";
      this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
      // 
      // toolStripButtonLoad
      // 
      this.toolStripButtonLoad.Image = global::FuzzyForecast.Properties.Resources.open;
      this.toolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonLoad.Name = "toolStripButtonLoad";
      this.toolStripButtonLoad.Size = new System.Drawing.Size(79, 22);
      this.toolStripButtonLoad.Text = "Загрузить";
      this.toolStripButtonLoad.Click += new System.EventHandler(this.toolStripButtonLoad_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.Filter = "Xml Files|*.xml";
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.Filter = "Xml Files|*.xml";
      // 
      // ColumnName
      // 
      this.ColumnName.DataPropertyName = "Name";
      this.ColumnName.HeaderText = "Название";
      this.ColumnName.Name = "ColumnName";
      // 
      // ColumnX1
      // 
      this.ColumnX1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
      this.ColumnX1.DataPropertyName = "X1";
      dataGridViewCellStyle1.Format = "N4";
      dataGridViewCellStyle1.NullValue = null;
      this.ColumnX1.DefaultCellStyle = dataGridViewCellStyle1;
      this.ColumnX1.HeaderText = "X1";
      this.ColumnX1.Name = "ColumnX1";
      this.ColumnX1.ReadOnly = true;
      this.ColumnX1.Width = 5;
      // 
      // ColumnX2
      // 
      this.ColumnX2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
      this.ColumnX2.DataPropertyName = "X2";
      dataGridViewCellStyle2.Format = "N4";
      dataGridViewCellStyle2.NullValue = null;
      this.ColumnX2.DefaultCellStyle = dataGridViewCellStyle2;
      this.ColumnX2.HeaderText = "X2";
      this.ColumnX2.Name = "ColumnX2";
      this.ColumnX2.ReadOnly = true;
      this.ColumnX2.Width = 5;
      // 
      // ColumnX3
      // 
      this.ColumnX3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
      this.ColumnX3.DataPropertyName = "X3";
      dataGridViewCellStyle3.Format = "N4";
      dataGridViewCellStyle3.NullValue = null;
      this.ColumnX3.DefaultCellStyle = dataGridViewCellStyle3;
      this.ColumnX3.HeaderText = "X3";
      this.ColumnX3.Name = "ColumnX3";
      this.ColumnX3.ReadOnly = true;
      this.ColumnX3.Width = 5;
      // 
      // ColumnX4
      // 
      this.ColumnX4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
      this.ColumnX4.DataPropertyName = "X4";
      dataGridViewCellStyle4.Format = "N4";
      dataGridViewCellStyle4.NullValue = null;
      this.ColumnX4.DefaultCellStyle = dataGridViewCellStyle4;
      this.ColumnX4.HeaderText = "X4";
      this.ColumnX4.Name = "ColumnX4";
      this.ColumnX4.ReadOnly = true;
      this.ColumnX4.Width = 5;
      // 
      // MFEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBoxMain);
      this.Name = "MFEdit";
      this.Size = new System.Drawing.Size(549, 266);
      this.groupBoxMain.ResumeLayout(false);
      this.groupBoxMain.PerformLayout();
      ((System.ComponentModel.ISupportInitialize) (this.dataGridViewTerms)).EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBoxMain;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
    private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
    private System.Windows.Forms.DataGridView dataGridViewTerms;
    private System.Windows.Forms.ToolStripButton toolStripButtonDraw;
    private System.Windows.Forms.ToolStripButton toolStripButtonSave;
    private System.Windows.Forms.ToolStripButton toolStripButtonLoad;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX1;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX2;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX3;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX4;
  }
}
