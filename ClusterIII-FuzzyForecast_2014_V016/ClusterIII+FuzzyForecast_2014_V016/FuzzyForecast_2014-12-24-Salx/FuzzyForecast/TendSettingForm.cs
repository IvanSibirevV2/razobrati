using System;
using System.Windows.Forms;

namespace FuzzyForecast {
  public partial class TendSettingForm :Form {
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

    public TendSettingForm(int totalCount) {
      InitializeComponent();
      this.totalCount = totalCount;
      numericUpDownSplit.Value = (int) Math.Ceiling(0.1 * totalCount);
    }

    public void Set(DForecastModel tfm) {
      numericUpDownOrder.Value = tfm.Order - 1;
      numericUpDownCount.Value = tfm.ExtraForecastCount;
      totalCount = tfm.Actual.Count;
      numericUpDownSplit.Maximum = (int) Math.Ceiling(totalCount / 2.0);
      numericUpDownSplit.Value = totalCount - tfm.ActualCount;
      checkBoxSelect.Checked = tfm.SelectRules;
      checkBoxExcess.Checked = tfm.HasExcessModel;
      checkBoxUseAll.Checked = tfm.UsedAllActualCount;
    }

    public void Set(TendForecastModel tfm) {
      numericUpDownOrder.Value = tfm.Order - 1;
      numericUpDownCount.Value = tfm.ExtraForecastCount;
      totalCount = tfm.Actual.Count;
      numericUpDownSplit.Maximum = (int) Math.Ceiling(totalCount / 2.0);
      numericUpDownSplit.Value = totalCount - tfm.ActualCount;
      checkBoxSelect.Checked = tfm.SelectRules;
      checkBoxExcess.Checked = tfm.HasExcessModel;
      checkBoxUseAll.Checked = tfm.UsedAllActualCount;
    }

    public void FillModel(DForecastModel dfm) {
      dfm.ExtraForecastCount = ForecastCount;
      dfm.ActualCount = ActualCount;
      dfm.SelectRules = SelectRules;
      dfm.HasExcessModel = ModelEscess;
      dfm.UsedAllActualCount = UseAllPoints;
    }

    public void FillModel(TendForecastModel tfm) {
      tfm.ExtraForecastCount = ForecastCount;
      tfm.ActualCount = ActualCount;
      tfm.SelectRules = SelectRules;
      tfm.HasExcessModel = ModelEscess;
      tfm.UsedAllActualCount = UseAllPoints;
    }
  }
}
