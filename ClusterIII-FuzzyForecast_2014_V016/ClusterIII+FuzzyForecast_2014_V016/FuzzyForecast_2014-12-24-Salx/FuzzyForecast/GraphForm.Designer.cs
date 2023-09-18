namespace FuzzyForecast {
  partial class GraphForm {
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
      this.components = new System.ComponentModel.Container();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.graphControl = new ZedGraph.ZedGraphControl();
      this.listViewPoints = new System.Windows.Forms.ListView();
      this.columnHeaderTime = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderValue = new System.Windows.Forms.ColumnHeader();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer.Location = new System.Drawing.Point(0, 0);
      this.splitContainer.Name = "splitContainer";
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.graphControl);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.listViewPoints);
      this.splitContainer.Size = new System.Drawing.Size(676, 421);
      this.splitContainer.SplitterDistance = 533;
      this.splitContainer.TabIndex = 0;
      // 
      // graphControl
      // 
      this.graphControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.graphControl.Location = new System.Drawing.Point(0, 0);
      this.graphControl.Name = "graphControl";
      this.graphControl.ScrollGrace = 0;
      this.graphControl.ScrollMaxX = 0;
      this.graphControl.ScrollMaxY = 0;
      this.graphControl.ScrollMaxY2 = 0;
      this.graphControl.ScrollMinX = 0;
      this.graphControl.ScrollMinY = 0;
      this.graphControl.ScrollMinY2 = 0;
      this.graphControl.Size = new System.Drawing.Size(533, 421);
      this.graphControl.TabIndex = 1;
      this.graphControl.Load += new System.EventHandler(this.graphControl_Load);
      // 
      // listViewPoints
      // 
      this.listViewPoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderValue});
      this.listViewPoints.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listViewPoints.GridLines = true;
      this.listViewPoints.Location = new System.Drawing.Point(0, 0);
      this.listViewPoints.Name = "listViewPoints";
      this.listViewPoints.Size = new System.Drawing.Size(139, 421);
      this.listViewPoints.TabIndex = 0;
      this.listViewPoints.UseCompatibleStateImageBehavior = false;
      this.listViewPoints.View = System.Windows.Forms.View.Details;
      // 
      // columnHeaderTime
      // 
      this.columnHeaderTime.Text = "Время";
      this.columnHeaderTime.Width = 63;
      // 
      // columnHeaderValue
      // 
      this.columnHeaderValue.Text = "Значение";
      this.columnHeaderValue.Width = 68;
      // 
      // GraphForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(676, 421);
      this.Controls.Add(this.splitContainer);
      this.Name = "GraphForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "GraphForm";
      this.Load += new System.EventHandler(this.graphControl_Load);
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      this.splitContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer;
    private ZedGraph.ZedGraphControl graphControl;
    private System.Windows.Forms.ListView listViewPoints;
    private System.Windows.Forms.ColumnHeader columnHeaderTime;
    private System.Windows.Forms.ColumnHeader columnHeaderValue;
  }
}