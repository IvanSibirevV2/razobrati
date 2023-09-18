using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FuzzyLibrary;

namespace FuzzyForecast {
  public partial class ACLSettingsForm :Form {

    private SPointList points;

    public ACLScale ACL;
    public ACLTimeSeries ACLSeries;

  //Уровень тенденции 'стабильность'
    public static double middleTendScale = 0.75;
  //Фактическое значение тенденции 'стабильность'
    public static double middleTendValue = 0.0;

    public ACLSettingsForm(SPointList points) {
      InitializeComponent();
      this.points = points;
      Generate();
      numericUpDown1.Value = Convert.ToDecimal((1.0 - middleTendScale) * 100);
      trackBar1.Value = Convert.ToInt32((1.0 - middleTendScale) * 100);
    }

    public ACLSettingsForm(ACLTimeSeries aclTS) {
      InitializeComponent();
      SetScale(aclTS);
      numericUpDown1.Value = Convert.ToDecimal((1.0 - middleTendScale) * 100);
      trackBar1.Value = Convert.ToInt32((1.0 - middleTendScale) * 100);
    }

    private void SetScale(ACLTimeSeries aclTS) {
      ACL = aclTS.Scale;
      ACLSeries = aclTS;
      points = aclTS.FTS.PointList;

      radioButtonSimple.Checked = ACL.BaseScale.FMethod == FuzzificationMethod.Simple;
      radioButtonCluster.Checked = ACL.BaseScale.FMethod == FuzzificationMethod.Cluster;

      textBoxCountTerms.Text = ACL.BaseScale.CountTerms.ToString();
      textBoxCross.Text = ACL.BaseScale.YInMaxXNextTerm.ToString(Calc.DFormat);
      textBoxTopLength.Text = ACL.BaseScale.CoefLengthTop.ToString();

      DrawAllTerms();
    }

    private void Generate() {

      ACL = new ACLScale("ACL шкала", points.FindMin().Y, points.FindMax().Y, ACLScale.typesNamesDefault);
      FuzzificationMethod fm = radioButtonSimple.Checked ? FuzzificationMethod.Simple : FuzzificationMethod.Cluster;
      int countTerms;
      if (!int.TryParse(textBoxCountTerms.Text, out countTerms)) {
        countTerms = 10;
      }
      double cross;
      if (!double.TryParse(textBoxCross.Text, out cross)) {
        cross = 0.0;
      }
      double coefLengthTop;
      if (!double.TryParse(textBoxTopLength.Text, out coefLengthTop)) {
        coefLengthTop = 0.0;
      }

      ACL.BaseScale.YInMaxXNextTerm = cross;
      ACL.BaseScale.CoefLengthTop = coefLengthTop;
      ACL.BaseScale.Fuzzification(points, fm, countTerms, true);

      ACL.InnerSimpleFuzzification(points);
      ACLSeries = new ACLTimeSeries(ACL, points);

      DrawAllTerms();
    }

    private void DrawAllTerms() {
      DrawHelper.CleanseGraph(graphControlBaseScale);
      DrawHelper.CleanseGraph(graphControlTTend);
      DrawHelper.CleanseGraph(graphControlRTend);
      DrawHelper.CleanseGraph(graphControlDiff);

      DrawHelper.DrawFuzzyVariable(graphControlBaseScale, ACL.BaseScale.Grades);
      DrawHelper.DrawFuzzyVariable(graphControlTTend, ACL.TendBaseTypesScale.Grades);
      DrawHelper.DrawFuzzyVariable(graphControlRTend, ACL.TendIntensityScale.Grades);
      DrawHelper.DrawFuzzyVariable(graphControlDiff, ACL.TendDiffScale.Grades);
    }

    private void ManualSetting() {
      FuzzyScale fs;
      bool editScale = true;
      if (tabControlScales.SelectedIndex == 0) {
        fs = ACL.BaseScale;
      } else if (tabControlScales.SelectedIndex == 1) {
        fs = ACL.TendBaseTypesScale;
        editScale = false;
      } else if (tabControlScales.SelectedIndex == 2) {
        fs = ACL.TendIntensityScale;
        editScale = false;
      } else if (tabControlScales.SelectedIndex == 3) {
        fs = ACL.TendDiffScale;
      } else {
        return;
      }

      var fssFrom = new FuzzyScaleSettingForm(fs.Name, fs.Grades.Terms, editScale);

      if (fssFrom.ShowDialog() != DialogResult.OK)
        return;

      List<FuzzyTerm> terms = fssFrom.GetTerms();
      fs.Grades.Terms.Clear();
      fs.Grades.Terms.AddRange(terms);

      DrawAllTerms();
    }

    private void buttonGenerate_Click(object sender, EventArgs e) {
      middleTendScale =1 - Convert.ToDouble(trackBar1.Value) / 100;
      Generate();
    }

    private void buttonOk_Click(object sender, EventArgs e) {
      middleTendScale = 1 - Convert.ToDouble(trackBar1.Value) / 100;
      ACLSeries.MakeModel();
    }

    private void buttonManual_Click(object sender, EventArgs e) {
      ManualSetting();
    }


    private void CalcTermsCount() {
      double error;
      if (!double.TryParse(textBoxError.Text, out error)) {
        error = 1.0;
        textBoxError.Text = "1,0";
      }
      textBoxCountTerms.Text = Calc.CountMF(points, error / 100).ToString();
    }

    private void checkBoxTermCount_CheckedChanged(object sender, EventArgs e) {
      if (checkBoxTermCount.Checked) {
        textBoxCountTerms.Enabled = false;
        textBoxError.Enabled = true;
        buttonCalc.Enabled = true;
        CalcTermsCount();
      } else {
        textBoxCountTerms.Enabled = true;
        textBoxError.Enabled = false;
        buttonCalc.Enabled = false;
      }
    }

    private void buttonCalc_Click(object sender, EventArgs e) {
      CalcTermsCount();
    }

    private void trackBar1_ValueChanged(object sender, EventArgs e)
    {
        numericUpDown1.Value = Convert.ToDecimal(trackBar1.Value);
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        trackBar1.Value = Convert.ToInt32 (numericUpDown1.Value);
    }
  }
}
