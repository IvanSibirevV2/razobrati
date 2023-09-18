using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FuzzyForecast
{
    public partial class FForecastModelSettings : Form
    {
        private double scale = 0;
        private ModelSeries series;

        public FForecastModelSettings(ModelSeries series)
        {
            this.series = series;
            InitializeComponent();
        }

        public bool AddResultToProject
        {
            get
            {
                return cbReplaceSource.Checked;
            }
            set
            {
                cbReplaceSource.Checked = value;
            }
        }


        public FForecastModel GetFModel(double _scale = 0)
        {
            if (_scale == 0)
            {
                if (lbFuncScale.Text != "")
                {
                    scale = Convert.ToDouble(tbFuncScale.Text);
                    this.Close();
                }
                else
                    return null;
            }
            else
            {
                scale = _scale;
            }
            FForecastModel fModel = new FForecastModel(series, scale);
            //fModel
            return fModel;
        }
    }
}
