using System;
using System.Windows.Forms;

namespace FuzzyForecast {
  public partial class CreatreTimeSeriesForm : Form {
  
    public Series series = new Series();

    public CreatreTimeSeriesForm() {
      InitializeComponent();
      SetMethodEnable();
      SetFuncEnable();
    }

    public void SetParams(Series f) {
      series = f;

      textBoxStart.Text = series.Attr.start.ToString();
      textBoxStep.Text = series.Attr.step.ToString();
      textBoxCount.Text = series.Attr.count.ToString();
      textBoxNoise.Text = series.Attr.noise.ToString();
      textBoxSpread.Text = series.Attr.spread.ToString();

      textBoxA.Text = series.Coeffs[0].ToString();
      textBoxB.Text = series.Coeffs[1].ToString();
      textBoxC.Text = series.Coeffs[2].ToString();

      switch (series.Type) {
        case FunctionsTypes.Linear:
          radioButtonLinear.Checked = true;
          break;
        case FunctionsTypes.Square:
          radioButtonSquare.Checked = true;
          break;
        case FunctionsTypes.Log:
          radioButtonLog.Checked = true;
          break;
        case FunctionsTypes.Sin:
          radioButtonSin.Checked = true;
          break;
        case FunctionsTypes.Cos:
          radioButtonCos.Checked = true;
          break;
        case FunctionsTypes.Random:
          radioButtonRand.Checked = true;
          break;
        default:
          break;
      }

      SetMethodEnable();
      SetFuncEnable();
    }
    
    
    private void SetMethodEnable() {
      textBoxNoise.Enabled = radioButtonNoise.Checked;
      textBoxSpread.Enabled = radioButtonRand.Checked;
      groupBoxFunc.Enabled = !radioButtonRand.Checked;
      groupBoxCoeff.Enabled = !radioButtonRand.Checked;
    }

    private void SetFuncEnable() {
      textBoxC.Enabled = radioButtonSquare.Checked;
    }

    private void SetUserChoise() {
      double.TryParse(textBoxStart.Text, out series.Attr.start);
      double.TryParse(textBoxStep.Text, out series.Attr.step);
      double.TryParse(textBoxCount.Text, out series.Attr.count);
      if (textBoxNoise.Enabled)
        double.TryParse(textBoxNoise.Text, out series.Attr.noise);
      if (textBoxSpread.Enabled)
        double.TryParse(textBoxSpread.Text, out series.Attr.spread);
      if (series.Attr.spread == 0) {
        series.Attr.spread = 1;
      }

      double coeff;
      double.TryParse(textBoxA.Text, out coeff);
      series.Coeffs[0] = coeff;
      double.TryParse(textBoxB.Text, out coeff);
      series.Coeffs[1] = coeff;
      double.TryParse(textBoxC.Text, out coeff);
      series.Coeffs[2] = coeff;


      if (radioButtonRand.Checked) {
        series.Type = FunctionsTypes.Random;
      } else if (radioButtonPrec.Checked || radioButtonNoise.Checked) {
        if (radioButtonLinear.Checked) {
          series.Type = FunctionsTypes.Linear;
        } else if (radioButtonSquare.Checked) {
          series.Type = FunctionsTypes.Square;
        } else if (radioButtonLog.Checked) {
          series.Type = FunctionsTypes.Log;
        } else if (radioButtonSin.Checked) {
          series.Type = FunctionsTypes.Sin;
        } else if (radioButtonCos.Checked) {
          series.Type = FunctionsTypes.Cos;
        }
      }
    }

    private void buttonOk_Click(object sender, EventArgs e) {
      SetUserChoise();
    }

    private void radioButtons_CheckedChanged(object sender, EventArgs e) {
      SetMethodEnable();
      SetFuncEnable();
    }
  }
}
