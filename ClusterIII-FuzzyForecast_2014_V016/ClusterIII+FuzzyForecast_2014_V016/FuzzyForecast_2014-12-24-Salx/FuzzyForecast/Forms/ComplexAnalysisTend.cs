using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FuzzyForecast
{
    public partial class ComplexAnalysisTend : Form
    {
        public ComplexAnalysisTend()
        {
            InitializeComponent();
            comboBoxBestResult.SelectedItem = "Внешние ошибки";
        }

        public bool UseMSE()
        {
            return cbMSE.Checked;
        }

        public bool UseMAPE()
        {
            return cbMAPE.Checked;
        }

        public bool UseRTend()
        {
            return cbRTend.Checked;
        }

        public bool UseTTend()
        {
            return cbTTend.Checked;
        }

        public bool SelectRules()
        {
            return cbSelectRules.Checked;
        }

        public int Range()
        {
            return Convert.ToInt32(nudRange.Value);
        }

        public int MaxISP()
        {
            return Convert.ToInt32(tbMaxISP.Text);
        }

        public int ErrorType()
        {
            return comboBoxBestResult.SelectedItem == "Внешние ошибки" ? 1 : 0;
        }

        public int ForecastPointsCount()
        {
            return (int)numericUpDownSplit.Value;
        }
    }
}
