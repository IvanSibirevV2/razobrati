namespace WindowsFormsApplication1
{
    partial class FormInfTable
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скороБудетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.диаграммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.строитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.общихДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(17, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(340, 224);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 37);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(320, 171);
            this.dataGridView1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.диаграммыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(433, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скороБудетToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // скороБудетToolStripMenuItem
            // 
            this.скороБудетToolStripMenuItem.Name = "скороБудетToolStripMenuItem";
            this.скороБудетToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.скороБудетToolStripMenuItem.Text = "Скоро будет";
            // 
            // диаграммыToolStripMenuItem
            // 
            this.диаграммыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.строитьToolStripMenuItem,
            this.общихДанныхToolStripMenuItem});
            this.диаграммыToolStripMenuItem.Name = "диаграммыToolStripMenuItem";
            this.диаграммыToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.диаграммыToolStripMenuItem.Text = "Диаграммы";
            // 
            // строитьToolStripMenuItem
            // 
            this.строитьToolStripMenuItem.Name = "строитьToolStripMenuItem";
            this.строитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.строитьToolStripMenuItem.Text = "дистанций";
            this.строитьToolStripMenuItem.Click += new System.EventHandler(this.строитьToolStripMenuItem_Click);
            // 
            // общихДанныхToolStripMenuItem
            // 
            this.общихДанныхToolStripMenuItem.Name = "общихДанныхToolStripMenuItem";
            this.общихДанныхToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.общихДанныхToolStripMenuItem.Text = "общих данных";
            this.общихДанныхToolStripMenuItem.Click += new System.EventHandler(this.общихДанныхToolStripMenuItem_Click);
            // 
            // FormInfTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 273);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormInfTable";
            this.Text = "Универсальная таблица";
            this.Load += new System.EventHandler(this.FormInfTable_Load);
            this.ClientSizeChanged += new System.EventHandler(this.FormDistancesTable_ClientSizeChanged);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скороБудетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem диаграммыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem строитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem общихДанныхToolStripMenuItem;



    }
}