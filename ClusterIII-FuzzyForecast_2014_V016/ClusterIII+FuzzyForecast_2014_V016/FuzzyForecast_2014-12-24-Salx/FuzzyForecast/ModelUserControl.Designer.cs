namespace FuzzyForecast {
  partial class ModelUserControl {
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
        this.components = new System.ComponentModel.Container();
        System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Внутренние Ошибки", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Внешние ошибки", System.Windows.Forms.HorizontalAlignment.Left);
        this.tabResultTend = new System.Windows.Forms.TabControl();
        this.tabPageGraph = new System.Windows.Forms.TabPage();
        this.splitContainer = new System.Windows.Forms.SplitContainer();
        this.graphControlModel = new ZedGraph.ZedGraphControl();
        this.listViewErrors = new System.Windows.Forms.ListView();
        this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
        this.columnHeaderVal = new System.Windows.Forms.ColumnHeader();
        this.tabPageModelResult = new System.Windows.Forms.TabPage();
        this.tabControlResults = new System.Windows.Forms.TabControl();
        this.tabPageRulesCounts = new System.Windows.Forms.TabPage();
        this.groupBoxRulesCounts = new System.Windows.Forms.GroupBox();
        this.listViewRulesCounts = new System.Windows.Forms.ListView();
        this.columnHeaderNumber = new System.Windows.Forms.ColumnHeader();
        this.columnHeaderRule = new System.Windows.Forms.ColumnHeader();
        this.columnHeaderCount = new System.Windows.Forms.ColumnHeader();
        this.toolStripRulesCounts = new System.Windows.Forms.ToolStrip();
        this.comboBoxRulesCounts = new System.Windows.Forms.ToolStripComboBox();
        this.tabPageRules = new System.Windows.Forms.TabPage();
        this.groupBoxRules = new System.Windows.Forms.GroupBox();
        this.listViewRules = new System.Windows.Forms.ListView();
        this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
        this.toolStripRules = new System.Windows.Forms.ToolStrip();
        this.comboBoxRules = new System.Windows.Forms.ToolStripComboBox();
        this.tabResume = new System.Windows.Forms.TabPage();
        this.rtbStats = new System.Windows.Forms.RichTextBox();
        this.tabForecast = new System.Windows.Forms.TabPage();
        this.listViewForecast = new System.Windows.Forms.ListView();
        this.chNumber = new System.Windows.Forms.ColumnHeader();
        this.chTime = new System.Windows.Forms.ColumnHeader();
        this.chActual = new System.Windows.Forms.ColumnHeader();
        this.chForecast = new System.Windows.Forms.ColumnHeader();
        this.chTTend = new System.Windows.Forms.ColumnHeader();
        this.chTerm = new System.Windows.Forms.ColumnHeader();
        this.chForecastTerm = new System.Windows.Forms.ColumnHeader();
        this.tabResultTend.SuspendLayout();
        this.tabPageGraph.SuspendLayout();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        this.tabPageModelResult.SuspendLayout();
        this.tabControlResults.SuspendLayout();
        this.tabPageRulesCounts.SuspendLayout();
        this.groupBoxRulesCounts.SuspendLayout();
        this.toolStripRulesCounts.SuspendLayout();
        this.tabPageRules.SuspendLayout();
        this.groupBoxRules.SuspendLayout();
        this.toolStripRules.SuspendLayout();
        this.tabResume.SuspendLayout();
        this.tabForecast.SuspendLayout();
        this.SuspendLayout();
        // 
        // tabResultTend
        // 
        this.tabResultTend.Controls.Add(this.tabPageGraph);
        this.tabResultTend.Controls.Add(this.tabPageModelResult);
        this.tabResultTend.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabResultTend.Location = new System.Drawing.Point(0, 0);
        this.tabResultTend.Name = "tabResultTend";
        this.tabResultTend.SelectedIndex = 0;
        this.tabResultTend.Size = new System.Drawing.Size(665, 468);
        this.tabResultTend.TabIndex = 4;
        // 
        // tabPageGraph
        // 
        this.tabPageGraph.Controls.Add(this.splitContainer);
        this.tabPageGraph.ImageIndex = 1;
        this.tabPageGraph.Location = new System.Drawing.Point(4, 22);
        this.tabPageGraph.Name = "tabPageGraph";
        this.tabPageGraph.Padding = new System.Windows.Forms.Padding(3);
        this.tabPageGraph.Size = new System.Drawing.Size(657, 442);
        this.tabPageGraph.TabIndex = 0;
        this.tabPageGraph.Text = "Графики";
        this.tabPageGraph.UseVisualStyleBackColor = true;
        // 
        // splitContainer
        // 
        this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.splitContainer.Location = new System.Drawing.Point(3, 3);
        this.splitContainer.Name = "splitContainer";
        // 
        // splitContainer.Panel1
        // 
        this.splitContainer.Panel1.Controls.Add(this.graphControlModel);
        // 
        // splitContainer.Panel2
        // 
        this.splitContainer.Panel2.Controls.Add(this.listViewErrors);
        this.splitContainer.Size = new System.Drawing.Size(651, 436);
        this.splitContainer.SplitterDistance = 487;
        this.splitContainer.TabIndex = 1;
        // 
        // graphControlModel
        // 
        this.graphControlModel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.graphControlModel.Location = new System.Drawing.Point(0, 0);
        this.graphControlModel.Name = "graphControlModel";
        this.graphControlModel.ScrollGrace = 0;
        this.graphControlModel.ScrollMaxX = 0;
        this.graphControlModel.ScrollMaxY = 0;
        this.graphControlModel.ScrollMaxY2 = 0;
        this.graphControlModel.ScrollMinX = 0;
        this.graphControlModel.ScrollMinY = 0;
        this.graphControlModel.ScrollMinY2 = 0;
        this.graphControlModel.Size = new System.Drawing.Size(487, 436);
        this.graphControlModel.TabIndex = 0;
        // 
        // listViewErrors
        // 
        this.listViewErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderVal});
        this.listViewErrors.Dock = System.Windows.Forms.DockStyle.Fill;
        this.listViewErrors.FullRowSelect = true;
        this.listViewErrors.GridLines = true;
        listViewGroup1.Header = "Внутренние Ошибки";
        listViewGroup1.Name = "listViewGroupModelError";
        listViewGroup2.Header = "Внешние ошибки";
        listViewGroup2.Name = "listViewGroupExtModelError";
        this.listViewErrors.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
        this.listViewErrors.Location = new System.Drawing.Point(0, 0);
        this.listViewErrors.Name = "listViewErrors";
        this.listViewErrors.Size = new System.Drawing.Size(160, 436);
        this.listViewErrors.TabIndex = 0;
        this.listViewErrors.UseCompatibleStateImageBehavior = false;
        this.listViewErrors.View = System.Windows.Forms.View.Details;
        // 
        // columnHeaderName
        // 
        this.columnHeaderName.Text = "Функция";
        this.columnHeaderName.Width = 78;
        // 
        // columnHeaderVal
        // 
        this.columnHeaderVal.Text = "Значение";
        this.columnHeaderVal.Width = 70;
        // 
        // tabPageModelResult
        // 
        this.tabPageModelResult.Controls.Add(this.tabControlResults);
        this.tabPageModelResult.ImageIndex = 6;
        this.tabPageModelResult.Location = new System.Drawing.Point(4, 22);
        this.tabPageModelResult.Name = "tabPageModelResult";
        this.tabPageModelResult.Padding = new System.Windows.Forms.Padding(3);
        this.tabPageModelResult.Size = new System.Drawing.Size(657, 442);
        this.tabPageModelResult.TabIndex = 1;
        this.tabPageModelResult.Text = "Результаты";
        this.tabPageModelResult.UseVisualStyleBackColor = true;
        // 
        // tabControlResults
        // 
        this.tabControlResults.Controls.Add(this.tabPageRulesCounts);
        this.tabControlResults.Controls.Add(this.tabPageRules);
        this.tabControlResults.Controls.Add(this.tabResume);
        this.tabControlResults.Controls.Add(this.tabForecast);
        this.tabControlResults.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabControlResults.Location = new System.Drawing.Point(3, 3);
        this.tabControlResults.Name = "tabControlResults";
        this.tabControlResults.SelectedIndex = 0;
        this.tabControlResults.Size = new System.Drawing.Size(651, 436);
        this.tabControlResults.TabIndex = 2;
        // 
        // tabPageRulesCounts
        // 
        this.tabPageRulesCounts.Controls.Add(this.groupBoxRulesCounts);
        this.tabPageRulesCounts.Location = new System.Drawing.Point(4, 22);
        this.tabPageRulesCounts.Name = "tabPageRulesCounts";
        this.tabPageRulesCounts.Padding = new System.Windows.Forms.Padding(3);
        this.tabPageRulesCounts.Size = new System.Drawing.Size(643, 410);
        this.tabPageRulesCounts.TabIndex = 1;
        this.tabPageRulesCounts.Text = "Частота Правил";
        this.tabPageRulesCounts.UseVisualStyleBackColor = true;
        // 
        // groupBoxRulesCounts
        // 
        this.groupBoxRulesCounts.Controls.Add(this.listViewRulesCounts);
        this.groupBoxRulesCounts.Controls.Add(this.toolStripRulesCounts);
        this.groupBoxRulesCounts.Dock = System.Windows.Forms.DockStyle.Fill;
        this.groupBoxRulesCounts.Location = new System.Drawing.Point(3, 3);
        this.groupBoxRulesCounts.Name = "groupBoxRulesCounts";
        this.groupBoxRulesCounts.Size = new System.Drawing.Size(637, 404);
        this.groupBoxRulesCounts.TabIndex = 1;
        this.groupBoxRulesCounts.TabStop = false;
        this.groupBoxRulesCounts.Text = "Правила";
        // 
        // listViewRulesCounts
        // 
        this.listViewRulesCounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNumber,
            this.columnHeaderRule,
            this.columnHeaderCount});
        this.listViewRulesCounts.Dock = System.Windows.Forms.DockStyle.Fill;
        this.listViewRulesCounts.Location = new System.Drawing.Point(3, 41);
        this.listViewRulesCounts.Name = "listViewRulesCounts";
        this.listViewRulesCounts.Size = new System.Drawing.Size(631, 360);
        this.listViewRulesCounts.TabIndex = 0;
        this.listViewRulesCounts.UseCompatibleStateImageBehavior = false;
        this.listViewRulesCounts.View = System.Windows.Forms.View.Details;
        // 
        // columnHeaderNumber
        // 
        this.columnHeaderNumber.Text = "№";
        this.columnHeaderNumber.Width = 45;
        // 
        // columnHeaderRule
        // 
        this.columnHeaderRule.Text = "Правило";
        this.columnHeaderRule.Width = 294;
        // 
        // columnHeaderCount
        // 
        this.columnHeaderCount.Text = "Частота";
        // 
        // toolStripRulesCounts
        // 
        this.toolStripRulesCounts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboBoxRulesCounts});
        this.toolStripRulesCounts.Location = new System.Drawing.Point(3, 16);
        this.toolStripRulesCounts.Name = "toolStripRulesCounts";
        this.toolStripRulesCounts.Size = new System.Drawing.Size(631, 25);
        this.toolStripRulesCounts.TabIndex = 0;
        this.toolStripRulesCounts.Text = "toolStrip1";
        // 
        // comboBoxRulesCounts
        // 
        this.comboBoxRulesCounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBoxRulesCounts.Name = "comboBoxRulesCounts";
        this.comboBoxRulesCounts.Size = new System.Drawing.Size(121, 25);
        this.comboBoxRulesCounts.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxRules_SelectedIndexChanged);
        // 
        // tabPageRules
        // 
        this.tabPageRules.Controls.Add(this.groupBoxRules);
        this.tabPageRules.Location = new System.Drawing.Point(4, 22);
        this.tabPageRules.Name = "tabPageRules";
        this.tabPageRules.Padding = new System.Windows.Forms.Padding(3);
        this.tabPageRules.Size = new System.Drawing.Size(643, 410);
        this.tabPageRules.TabIndex = 2;
        this.tabPageRules.Text = "Правила";
        this.tabPageRules.UseVisualStyleBackColor = true;
        // 
        // groupBoxRules
        // 
        this.groupBoxRules.Controls.Add(this.listViewRules);
        this.groupBoxRules.Controls.Add(this.toolStripRules);
        this.groupBoxRules.Dock = System.Windows.Forms.DockStyle.Fill;
        this.groupBoxRules.Location = new System.Drawing.Point(3, 3);
        this.groupBoxRules.Name = "groupBoxRules";
        this.groupBoxRules.Size = new System.Drawing.Size(637, 404);
        this.groupBoxRules.TabIndex = 2;
        this.groupBoxRules.TabStop = false;
        this.groupBoxRules.Text = "Правила";
        // 
        // listViewRules
        // 
        this.listViewRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
        this.listViewRules.Dock = System.Windows.Forms.DockStyle.Fill;
        this.listViewRules.Location = new System.Drawing.Point(3, 41);
        this.listViewRules.Name = "listViewRules";
        this.listViewRules.Size = new System.Drawing.Size(631, 360);
        this.listViewRules.TabIndex = 0;
        this.listViewRules.UseCompatibleStateImageBehavior = false;
        this.listViewRules.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader1
        // 
        this.columnHeader1.Text = "№";
        this.columnHeader1.Width = 45;
        // 
        // columnHeader2
        // 
        this.columnHeader2.Text = "Правило";
        this.columnHeader2.Width = 294;
        // 
        // columnHeader3
        // 
        this.columnHeader3.Text = "Принадлежность";
        this.columnHeader3.Width = 119;
        // 
        // toolStripRules
        // 
        this.toolStripRules.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboBoxRules});
        this.toolStripRules.Location = new System.Drawing.Point(3, 16);
        this.toolStripRules.Name = "toolStripRules";
        this.toolStripRules.Size = new System.Drawing.Size(631, 25);
        this.toolStripRules.TabIndex = 0;
        this.toolStripRules.Text = "toolStrip1";
        // 
        // comboBoxRules
        // 
        this.comboBoxRules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBoxRules.Name = "comboBoxRules";
        this.comboBoxRules.Size = new System.Drawing.Size(121, 25);
        this.comboBoxRules.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxRules_SelectedIndexChanged);
        // 
        // tabResume
        // 
        this.tabResume.Controls.Add(this.rtbStats);
        this.tabResume.Location = new System.Drawing.Point(4, 22);
        this.tabResume.Name = "tabResume";
        this.tabResume.Padding = new System.Windows.Forms.Padding(3);
        this.tabResume.Size = new System.Drawing.Size(643, 410);
        this.tabResume.TabIndex = 3;
        this.tabResume.Text = "Общая тенденция";
        this.tabResume.UseVisualStyleBackColor = true;
        // 
        // rtbStats
        // 
        this.rtbStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.rtbStats.Location = new System.Drawing.Point(6, 6);
        this.rtbStats.Name = "rtbStats";
        this.rtbStats.Size = new System.Drawing.Size(631, 398);
        this.rtbStats.TabIndex = 0;
        this.rtbStats.Text = "";
        // 
        // tabForecast
        // 
        this.tabForecast.Controls.Add(this.listViewForecast);
        this.tabForecast.Location = new System.Drawing.Point(4, 22);
        this.tabForecast.Name = "tabForecast";
        this.tabForecast.Padding = new System.Windows.Forms.Padding(3);
        this.tabForecast.Size = new System.Drawing.Size(643, 410);
        this.tabForecast.TabIndex = 4;
        this.tabForecast.Text = "Прогноз";
        this.tabForecast.UseVisualStyleBackColor = true;
        // 
        // listViewForecast
        // 
        this.listViewForecast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNumber,
            this.chTime,
            this.chActual,
            this.chForecast,
            this.chTTend,
            this.chTerm,
            this.chForecastTerm});
        this.listViewForecast.Dock = System.Windows.Forms.DockStyle.Fill;
        this.listViewForecast.FullRowSelect = true;
        this.listViewForecast.GridLines = true;
        this.listViewForecast.Location = new System.Drawing.Point(3, 3);
        this.listViewForecast.Name = "listViewForecast";
        this.listViewForecast.Size = new System.Drawing.Size(637, 404);
        this.listViewForecast.TabIndex = 0;
        this.listViewForecast.UseCompatibleStateImageBehavior = false;
        this.listViewForecast.View = System.Windows.Forms.View.Details;
        // 
        // chNumber
        // 
        this.chNumber.Text = "№";
        // 
        // chTime
        // 
        this.chTime.Text = "Время";
        // 
        // chActual
        // 
        this.chActual.Text = "Ряд";
        // 
        // chForecast
        // 
        this.chForecast.Text = "Модель";
        // 
        // chTTend
        // 
        this.chTTend.Text = "TTend";
        // 
        // chTerm
        // 
        this.chTerm.Text = "НМ";
        // 
        // chForecastTerm
        // 
        this.chForecastTerm.Text = "Модель НМ";
        // 
        // ModelUserControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.tabResultTend);
        this.Name = "ModelUserControl";
        this.Size = new System.Drawing.Size(665, 468);
        this.tabResultTend.ResumeLayout(false);
        this.tabPageGraph.ResumeLayout(false);
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        this.splitContainer.ResumeLayout(false);
        this.tabPageModelResult.ResumeLayout(false);
        this.tabControlResults.ResumeLayout(false);
        this.tabPageRulesCounts.ResumeLayout(false);
        this.groupBoxRulesCounts.ResumeLayout(false);
        this.groupBoxRulesCounts.PerformLayout();
        this.toolStripRulesCounts.ResumeLayout(false);
        this.toolStripRulesCounts.PerformLayout();
        this.tabPageRules.ResumeLayout(false);
        this.groupBoxRules.ResumeLayout(false);
        this.groupBoxRules.PerformLayout();
        this.toolStripRules.ResumeLayout(false);
        this.toolStripRules.PerformLayout();
        this.tabResume.ResumeLayout(false);
        this.tabForecast.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabResultTend;
    private System.Windows.Forms.TabPage tabPageGraph;
    private System.Windows.Forms.SplitContainer splitContainer;
    private ZedGraph.ZedGraphControl graphControlModel;
    private System.Windows.Forms.ListView listViewErrors;
    private System.Windows.Forms.ColumnHeader columnHeaderName;
    private System.Windows.Forms.ColumnHeader columnHeaderVal;
    private System.Windows.Forms.TabPage tabPageModelResult;
    private System.Windows.Forms.GroupBox groupBoxRulesCounts;
    private System.Windows.Forms.ListView listViewRulesCounts;
    private System.Windows.Forms.ToolStrip toolStripRulesCounts;
    private System.Windows.Forms.ColumnHeader columnHeaderNumber;
    private System.Windows.Forms.ColumnHeader columnHeaderRule;
    private System.Windows.Forms.ColumnHeader columnHeaderCount;
    private System.Windows.Forms.ToolStripComboBox comboBoxRulesCounts;
    private System.Windows.Forms.TabControl tabControlResults;
    private System.Windows.Forms.TabPage tabPageRulesCounts;
    private System.Windows.Forms.TabPage tabPageRules;
    private System.Windows.Forms.GroupBox groupBoxRules;
    private System.Windows.Forms.ListView listViewRules;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ToolStrip toolStripRules;
    private System.Windows.Forms.ToolStripComboBox comboBoxRules;
    private System.Windows.Forms.TabPage tabResume;
    private System.Windows.Forms.RichTextBox rtbStats;
    private System.Windows.Forms.TabPage tabForecast;
    private System.Windows.Forms.ListView listViewForecast;
    private System.Windows.Forms.ColumnHeader chNumber;
    private System.Windows.Forms.ColumnHeader chTime;
    private System.Windows.Forms.ColumnHeader chActual;
    private System.Windows.Forms.ColumnHeader chForecast;
    private System.Windows.Forms.ColumnHeader chTTend;
    private System.Windows.Forms.ColumnHeader chTerm;
    private System.Windows.Forms.ColumnHeader chForecastTerm;
  }
}
