using System.Windows.Forms;

namespace FuzzyForecast {
  public partial class ShowTableForm : Form {

    private readonly ModelResult modelResult;

    public ShowTableForm(ModelResult mr) {
      InitializeComponent();
      modelResult = mr;
      ShowModelInfo(modelResult);
    }

    private void ShowModelInfo(ModelResult mr) {
      if (mr == null)
        return;

      listViewStatistic.Columns.Clear();
      listViewStatistic.Items.Clear();

      listViewStatistic.Columns.Add("№");

      foreach (var columnName in mr.ColumnNamesCrisp) {
        listViewStatistic.Columns.Add(columnName, columnName);
      }

      int i = 0;
      foreach (var list in mr.ResultsCrisp) {
        var lvi = listViewStatistic.Items.Add(i.ToString(), i.ToString());
        foreach (var s in list) {
          lvi.SubItems.Add(s);
        }
        i++;
      }
    }
  }


}
