using System;
using System.Windows.Forms;
using FuzzyLibrary;

namespace FuzzyForecast
{
    public partial class NeuralSettingForm : Form
    {
        public int Order
        {
            get { return (int)numericUpDownOrder.Value; }
            set { numericUpDownOrder.Value = (decimal)value; }
        }

        public int ForecastCount
        {
            get { return (int)numericUpDownCount.Value; }
            set { numericUpDownCount.Value = (decimal)value; } //Михаил
        }

        public int HiddenCount
        {
            get { return (int)numericUpDownHiddenCount.Value; }
        }

        public int ActualCount
        {
            get { return totalCount - (int)numericUpDownSplit.Value; }
            set { numericUpDownSplit.Value = (int)value; }
        }

        public bool UseAllPoints
        {
            get
            {
                return checkBoxUseAll.Checked;
            }
        }

        public ForecastModelType ExcessModelType
        {
            get
            {
                return (ForecastModelType)comboBox.SelectedIndex;
            }
        }

        public bool ManualSettings
        {
            get
            {
                return checkBoxSettings.Checked;
            }
        }

        public int Cycles
        {
            get
            {
                return (int)numericUpDownEpoch.Value;
            }
        }

        public double MSE
        {
            get
            {
                double mse;
                if (!double.TryParse(textBoxMSE.Text, out mse))
                    mse = 0.000001;
                return mse;
            }
        }

        private int totalCount;

        public NeuralSettingForm(int totalCount)
        {
            InitializeComponent();
            this.totalCount = totalCount;
            numericUpDownSplit.Value = (int)Math.Ceiling(0.1 * totalCount);
            comboBox.SelectedIndex = 0;
            numericUpDownEpoch.Value = NeuralForecastModel.CyclesDefault;
            textBoxMSE.Text = NeuralForecastModel.StopMSEDefault.ToString(Calc.DFormat);
        }

        public void Set(NeuralForecastModel nfm)
        {
            numericUpDownOrder.Value = nfm.Order;
            numericUpDownCount.Value = nfm.ExtraForecastCount;
            numericUpDownHiddenCount.Value = nfm.NumberHidden;
            totalCount = nfm.Actual.Count;
            numericUpDownSplit.Maximum = (int)Math.Ceiling(totalCount / 2.0);
            numericUpDownSplit.Value = totalCount - nfm.ActualCount;
            checkBoxUseAll.Checked = nfm.UsedAllActualCount;
            comboBox.SelectedIndex = (int)nfm.ExcessModelType;
            checkBoxSettings.Checked = nfm.ExcessManual;
            numericUpDownEpoch.Value = nfm.Cycles;
            textBoxMSE.Text = nfm.StopMSE.ToString(Calc.DFormat);
        }

        public bool NotChanged(NeuralForecastModel nfm)
        {
            return nfm.ExtraForecastCount == ForecastCount &&
                   nfm.NumberInput == Order &&
                   nfm.NumberHidden == HiddenCount &&
                   nfm.ActualCount == ActualCount &&
                   nfm.UsedAllActualCount == UseAllPoints &&
                   nfm.ExcessModelType == ExcessModelType &&
                   nfm.ExcessManual == ManualSettings &&
                   nfm.Cycles == Cycles &&
                   nfm.StopMSE == MSE;
        }

        public void FillModel(NeuralForecastModel nfm)
        {
            nfm.ExtraForecastCount = ForecastCount;
            nfm.NumberInput = Order;
            nfm.NumberHidden = HiddenCount;
            nfm.ActualCount = ActualCount;
            nfm.UsedAllActualCount = UseAllPoints;
            nfm.ExcessModelType = ExcessModelType;
            nfm.ExcessManual = ManualSettings;
            nfm.Cycles = Cycles;
            nfm.StopMSE = MSE;
        }

        public NeuralForecastModel GetNModel(SPointList spl)
        {
            return new NeuralForecastModel(spl, Order, HiddenCount, Cycles, MSE, ForecastCount, ActualCount, UseAllPoints,
                                           ExcessModelType, ManualSettings, false);
        }
    }
}
