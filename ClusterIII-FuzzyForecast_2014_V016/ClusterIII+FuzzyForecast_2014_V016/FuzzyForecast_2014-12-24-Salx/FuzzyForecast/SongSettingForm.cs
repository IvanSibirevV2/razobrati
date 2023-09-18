using System;
using System.Windows.Forms;

namespace FuzzyForecast {
  public partial class SongSettingForm :Form {
    public int Order {
      get { return (int) numericUpDownOrder.Value; } 
    }

    public int ForecastCount {
      get { return (int) numericUpDownCount.Value; }
    }

    public int ActualCount {
      get { return totalCount - (int) numericUpDownSplit.Value; }
    }

    public bool SelectRules {
      get {
        return checkBoxSelect.Checked;
      }
    }

    public bool ModelEscess {
      get {
        return checkBoxExcess.Checked;
      }
    }

    public bool UseAllPoints {
      get {
        return checkBoxUseAll.Checked;
      }
    }

    private int totalCount;

    public SongSettingForm(int totalCount) {
      InitializeComponent();
      this.totalCount = totalCount;
      numericUpDownSplit.Value = (int) Math.Ceiling(0.1 * totalCount);
    }

    public void Set(SongForecastModel sfm) {
      numericUpDownOrder.Value = sfm.Order;
      numericUpDownCount.Value = sfm.ExtraForecastCount;
      totalCount = sfm.Actual.Count;
      numericUpDownSplit.Maximum = (int) Math.Ceiling(totalCount / 2.0);
      numericUpDownSplit.Value = totalCount - sfm.ActualCount;
      checkBoxSelect.Checked = sfm.SelectRules;
      checkBoxExcess.Checked = sfm.HasExcessModel;
      checkBoxUseAll.Checked = sfm.UsedAllActualCount;
    }

    public void FillModel(SongForecastModel sfm) {
      sfm.ExtraForecastCount = ForecastCount;
      sfm.ActualCount = ActualCount;
      sfm.SelectRules = SelectRules;
      sfm.HasExcessModel = ModelEscess;
      sfm.UsedAllActualCount = UseAllPoints;
    }
  }
}
