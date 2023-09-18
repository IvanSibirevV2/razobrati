using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FuzzyForecast
{
    public partial class ComplexAnalysis : Form
    {
        //TODO:delete
        public void Setting(int ActualCount, int ForecastCount, int Order)
        {
            nudRange.Value = Order;
            numericUpDownCount.Value = ActualCount;
            numericUpDownSplit.Value = ForecastCount;
            cbMSE.Checked = false;
            cbRTend.Checked = false;
            cbTTend.Checked = false;
        }
        public ComplexAnalysis()
        {
            InitializeComponent();
            comboBoxBestResult.SelectedItem = "Внешние ошибки";
        }

        /// <summary>
        /// Тип ошибки
        /// </summary>
        /// <returns> Возращает либо 0  либо 1, почему не знаю </returns>
        public int ErrorType()
        {   
            return Convert.ToString(comboBoxBestResult.SelectedItem) == "Внешние ошибки" ? 1 : 0;
        }

        public int ForecastPointsCount()
        {
            return (int)numericUpDownSplit.Value;
        }

        public int ModelRangeDepth()
        {
            return (int)nudRange.Value;
        }

        public bool UseNetworks()
        {
            return cb1.Checked;
        }

        public bool UseSong()
        {
            return cb2.Checked;
        }

        public bool UseSD()
        {
            return cb3.Checked;
        }

        public bool UseT()
        {
            return cb4.Checked;
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

        public bool UseSeparatedResults()
        {
            return cbSeparateResult.Checked;
        }

        public bool UseAllSeries() {
            return cbUseAllSeries.Checked;
        }

        public bool UseFTransform()
        {
            return cbUseFTransform.Checked;
        }
        
        
        
        //
        public int ForecastCount
        {
            get { return (int)numericUpDownCount.Value; }
        }
        
        
        
        

        private void cbSeparateResult_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbSeparateResult.Checked == true)
            {
                cbMSE.Checked = true;
                cbMAPE.Checked = true;
                cbRTend.Checked = true;
                cbTTend.Checked = true;
                qpParams.Enabled = false;
            }
            else
            {
                qpParams.Enabled = true;
            }
        }
    }
}
