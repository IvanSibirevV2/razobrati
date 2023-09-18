using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FuzzyLibrary;

namespace FuzzyForecast
{

    public partial class ACLSettingsForm : Form
    {

        private SPointList points;

        private static ExtTerms extendedTerms;
        public static ExtTerms ExtendedTerms
        {
            get
            {
                return extendedTerms;
            }
        }
        public static double D = 0.0;
        public ACLScale ACL;
        public ACLTimeSeries ACLSeries;

        public void SetIntencityParams(int isp)
        {
            nudISP.Value = Convert.ToDecimal(isp);
        }

        //Уровень тенденции 'стабильность'
        public static double middleTendScale = 0.75;
        //Фактическое значение тенденции 'стабильность'
        public static double middleTendValue = 0.0;

        public ACLSettingsForm(SPointList points)
        {

            InitializeComponent();
            this.points = points;

            numericUpDown1.Value = Convert.ToDecimal((1.0 - middleTendScale) * 100);
            trackBar1.Value = Convert.ToInt32((1.0 - middleTendScale) * 100);
            //extendedTerms = new ExtTerms(Convert.ToInt32(upperExtTends.Value),
            //                 Convert.ToInt32(lowerExtTends.Value));

            if (ACL != null && ACL.BaseScale.MaxNotExp != 0 && ACL.BaseScale.MinNotExp != 0)
            {
                tbLowerBound.Text = ACL.BaseScale.MinNotExp.ToString();
                tbUpperBound.Text = ACL.BaseScale.MaxNotExp.ToString();

                cbAbsoluteD.Checked = ACL.AbsoluteScaleForTypes;
                nudISP.Value = Convert.ToDecimal(ACL.ISP);
                upperExtTends.Value = ACL.BaseScale.ExtendedTerms.UppreTerms;
                lowerExtTends.Value = ACL.BaseScale.ExtendedTerms.LowerTerms;
            }
            else
            {
                tbLowerBound.Text = points.FindMin().Y.ToString();
                tbUpperBound.Text = points.FindMax().Y.ToString();
            }

            Generate();

        }

        public ACLSettingsForm(ACLTimeSeries aclTS)
        {
            InitializeComponent();
            SetScale(aclTS);
            numericUpDown1.Value = Convert.ToDecimal((1.0 - middleTendScale) * 100);
            trackBar1.Value = Convert.ToInt32((1.0 - middleTendScale) * 100);
            //extendedTerms = new ExtTerms(Convert.ToInt32(upperExtTends.Value),
            //                 Convert.ToInt32(lowerExtTends.Value));

            if (aclTS.Scale.BaseScale.MaxNotExp != 0 && aclTS.Scale.BaseScale.MinNotExp != 0)
            {
                tbLowerBound.Text = aclTS.Scale.BaseScale.MinNotExp.ToString();
                tbUpperBound.Text = aclTS.Scale.BaseScale.MaxNotExp.ToString();
            }
            else
            {
                tbLowerBound.Text = aclTS.FTS.PointList.FindMin().Y.ToString();
                tbUpperBound.Text = aclTS.FTS.PointList.FindMax().Y.ToString();
            }

            nudISP.Value = Convert.ToDecimal(ACL.ISP);
            cbAbsoluteD.Checked = ACL.AbsoluteScaleForTypes;
            upperExtTends.Value = aclTS.Scale.BaseScale.ExtendedTerms.UppreTerms;
            lowerExtTends.Value = aclTS.Scale.BaseScale.ExtendedTerms.LowerTerms;

            tbDValue.Text = ACL.D.ToString("0.000");
            D = ACL.D;
            //Generate();
        }

        private void SetScale(ACLTimeSeries aclTS)
        {
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

        public void Generate()
        {
            extendedTerms = new ExtTerms(Convert.ToInt32(upperExtTends.Value),
                                         Convert.ToInt32(lowerExtTends.Value));
            middleTendScale = 1 - Convert.ToDouble(trackBar1.Value) / 100;

            //if (Convert.ToDouble(tbLowerBound.Text.Replace('.', ',')) != 0 && Convert.ToDouble(tbUpperBound.Text.Replace('.', ',')) != 0)
            ACL = new ACLScale("ACL шкала", Convert.ToDouble(tbLowerBound.Text.Replace('.', ',')), Convert.ToDouble(tbUpperBound.Text.Replace('.', ',')), ACLScale.typesNamesDefault);
            //else
            //    ACL = new ACLScale("ACL шкала", points.FindMin().Y, points.FindMax().Y, ACLScale.typesNamesDefault);


            ACL.BaseScale.ExtendedTerms = extendedTerms;
            ACL.AbsoluteScaleForTypes = cbAbsoluteD.Checked;
            ACL.ISP = Convert.ToInt32(nudISP.Value);
            ACL.MiddleTendScale = middleTendScale;
            FuzzificationMethod fm = radioButtonSimple.Checked ? FuzzificationMethod.Simple : FuzzificationMethod.Cluster;
            int countTerms;
            if (!int.TryParse(textBoxCountTerms.Text, out countTerms))
            {
                countTerms = 10;
            }

            double cross;
            if (!double.TryParse(textBoxCross.Text, out cross))
            {
                cross = 0.0;
            }
            double coefLengthTop;
            if (!double.TryParse(textBoxTopLength.Text, out coefLengthTop))
            {
                coefLengthTop = 0.0;
            }

            ACL.BaseScale.YInMaxXNextTerm = cross;
            ACL.BaseScale.CoefLengthTop = coefLengthTop;
            ACL.BaseScale.Fuzzification(points, fm, countTerms, true, extendedTerms);

            ACL.InnerSimpleFuzzification(points);
            ACLSeries = new ACLTimeSeries(ACL, points);

            tbDValue.Text = ACL.D.ToString("0.000");
            D = ACL.D;

            DrawAllTerms();
        }

        private void DrawAllTerms()
        {
            DrawHelper.CleanseGraph(graphControlBaseScale);
            DrawHelper.CleanseGraph(graphControlTTend);
            DrawHelper.CleanseGraph(graphControlRTend);
            DrawHelper.CleanseGraph(graphControlDiff);
            DrawHelper.CleanseGraph(graphControlPrecision);

            DrawHelper.DrawFuzzyVariable(graphControlBaseScale, ACL.BaseScale.Grades);
            DrawHelper.DrawFuzzyVariable(graphControlTTend, ACL.TendBaseTypesScale.Grades);
            DrawHelper.DrawFuzzyVariable(graphControlRTend, ACL.TendIntensityScale.Grades);
            DrawHelper.DrawFuzzyVariable(graphControlDiff, ACL.TendDiffScale.Grades);
            DrawHelper.DrawFuzzyVariable(graphControlPrecision, ACL.TendPrecisionScale.Grades);
        }

        private void ManualSetting()
        {
            FuzzyScale fs;
            bool editScale = true;
            if (tabControlScales.SelectedIndex == 0)
            {
                fs = ACL.BaseScale;
            }
            else if (tabControlScales.SelectedIndex == 1)
            {
                fs = ACL.TendBaseTypesScale;
                editScale = false;
            }
            else if (tabControlScales.SelectedIndex == 2)
            {
                fs = ACL.TendIntensityScale;
                editScale = false;
            }
            else if (tabControlScales.SelectedIndex == 3)
            {
                fs = ACL.TendDiffScale;
            }
            else if (tabControlScales.SelectedIndex == 4)
            {
                fs = ACL.TendPrecisionScale;
            }
            else
            {
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

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            middleTendScale = 1 - Convert.ToDouble(trackBar1.Value) / 100;
            ACLSeries.MakeModel();
        }
        private void buttonManual_Click(object sender, EventArgs e)
        {
            ManualSetting();
        }


        //private void CalcTermsCount() {
        //  double error;
        //  if (!double.TryParse(textBoxError.Text, out error)) {
        //    error = 1.0;
        //    textBoxError.Text = "1,0";
        //  }
        //  textBoxCountTerms.Text = Calc.CountMF(points, error / 100).ToString();
        //}

        //private void checkBoxTermCount_CheckedChanged(object sender, EventArgs e) {
        //  if (checkBoxTermCount.Checked) {
        //    textBoxCountTerms.Enabled = false;
        //    textBoxError.Enabled = true;
        //    buttonCalc.Enabled = true;
        //    CalcTermsCount();
        //  } else {
        //    textBoxCountTerms.Enabled = true;
        //    textBoxError.Enabled = false;
        //    buttonCalc.Enabled = false;
        //  }
        //}

        //private void buttonCalc_Click(object sender, EventArgs e) {
        //  CalcTermsCount();
        //}

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = Convert.ToDecimal(trackBar1.Value);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(numericUpDown1.Value);
        }

        private void tcParams_Click(object sender, EventArgs e)
        {
            if (tcParams.SelectedIndex == 2)
                tabControlScales.SelectedIndex = 1;
            if (tcParams.SelectedIndex == 0)
                tabControlScales.SelectedIndex = 0;
        }

        private void tabControlScales_Click(object sender, EventArgs e)
        {
            if (tabControlScales.SelectedIndex == 1)
                tcParams.SelectedIndex = 2;
            if (tabControlScales.SelectedIndex == 0)
                tcParams.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            middleTendScale = 1 - Convert.ToDouble(trackBar1.Value) / 100;
            Generate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 2 * (int)(ACL.Len / ACL.D) + 1;
            textBoxCountTerms.Text = (count < 5 ? 5 : count).ToString();
            //Generate();
        }
    }
}
