using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using FuzzyLibrary;

namespace FuzzyForecast {
  public partial class GraphForm :Form {
    private readonly SPointList points;
    public GraphForm(SPointList points) {
      InitializeComponent();
      this.points = points;
    }

    private void LoadPoints() {
      for (int i = 0; i < points.Count; i++) {
        ListViewItem lvi = listViewPoints.Items.Add(points[i].X.ToString(Calc.DFormat));
        lvi.SubItems.Add(points[i].Y.ToString(Calc.DFormat));
      }
    }

    private void DrawGraph() {
      DrawHelper.CleanseGraph(graphControl);
      graphControl.GraphPane.Title.Text = points.Name;
      DrawHelper.DrawPointList(graphControl, points, Color.Blue, SymbolType.Default, true);
    }

    private void graphControl_Load(object sender, EventArgs e) {
      Text = points.Name;
      LoadPoints();
      DrawGraph();
    }
  }
}
