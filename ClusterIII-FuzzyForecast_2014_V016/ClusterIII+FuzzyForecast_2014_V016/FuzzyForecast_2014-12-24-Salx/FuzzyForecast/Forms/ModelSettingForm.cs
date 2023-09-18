using System;
using System.Windows.Forms;

namespace FuzzyForecast
{
    public partial class ModelSettingForm : Form
    {
        public int Order
        {
            get { return (int)numericUpDownOrder.Value; }
            set { numericUpDownOrder.Value = (decimal)value; }
        }

        public int ForecastCount
        {
            get { return (int)numericUpDownCount.Value; }
            set { numericUpDownCount.Value = (decimal)value; }//Михаил
        }

        public int ActualCount
        {
            get { return totalCount - (int)numericUpDownSplit.Value; }
            set { numericUpDownSplit.Value = (int)value; }
        }

        public bool SelectRules
        {
            get
            {
                return checkBoxSelect.Checked;
            }
            set
            {
                checkBoxSelect.Checked = value;
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

        public bool UseAllPoints
        {
            get
            {
                return checkBoxUseAll.Checked;
            }
        }

        public int SetMethodType
        {
            set
            {
                comboBoxType.SelectedIndex = value;
            }
        }

        public TendForecastModel.TFMType TMFType
        {
            get
            {
                return (TendForecastModel.TFMType)comboBoxType.SelectedIndex;
            }
        }

        private int totalCount;

        public ModelSettingForm(int totalCount, Type modelType)
        {
            InitializeComponent();
            this.totalCount = totalCount;
            numericUpDownSplit.Value = (int)Math.Ceiling(0.1 * totalCount);
            comboBox.SelectedIndex = 0;
            groupBoxType.Enabled = modelType == typeof(TendForecastModel);
            if (groupBoxType.Enabled)
            {
                comboBoxType.Enabled = true;
                comboBoxType.Items.Clear();
                comboBoxType.Items.Add("F2S");
                comboBoxType.Items.Add("F1N");
                comboBoxType.Items.Add("F3N1S");
                comboBoxType.SelectedIndex = 0;
            }
        }

        public void Set(DForecastModel tfm)
        {
            numericUpDownOrder.Value = tfm.Order - 1;
            numericUpDownCount.Value = tfm.ExtraForecastCount;
            totalCount = tfm.Actual.Count;
            numericUpDownSplit.Maximum = (int)Math.Ceiling(totalCount / 2.0);
            numericUpDownSplit.Value = totalCount - tfm.ActualCount;
            checkBoxSelect.Checked = tfm.SelectRules;
            comboBox.SelectedIndex = (int)tfm.ExcessModelType;
            checkBoxUseAll.Checked = tfm.UsedAllActualCount;
            checkBoxSettings.Checked = tfm.ExcessManual;
        }

        public void Set(TendForecastModel tfm)
        {
            numericUpDownOrder.Value = tfm.Order - 1;
            numericUpDownCount.Value = tfm.ExtraForecastCount;
            totalCount = tfm.Actual.Count;
            numericUpDownSplit.Maximum = (int)Math.Ceiling(totalCount / 2.0);
            numericUpDownSplit.Value = totalCount - tfm.ActualCount;
            checkBoxSelect.Checked = tfm.SelectRules;
            comboBox.SelectedIndex = (int)tfm.ExcessModelType;
            checkBoxUseAll.Checked = tfm.UsedAllActualCount;
            checkBoxSettings.Checked = tfm.ExcessManual;
            comboBoxType.SelectedIndex = (int)tfm.ModelType;
        }

        public void Set(SongForecastModel sfm)
        {
            numericUpDownOrder.Value = sfm.Order;
            numericUpDownCount.Value = sfm.ExtraForecastCount;
            totalCount = sfm.Actual.Count;
            numericUpDownSplit.Maximum = (int)Math.Ceiling(totalCount / 2.0);
            numericUpDownSplit.Value = totalCount - sfm.ActualCount;
            checkBoxSelect.Checked = sfm.SelectRules;
            comboBox.SelectedIndex = (int)sfm.ExcessModelType;
            checkBoxUseAll.Checked = sfm.UsedAllActualCount;
            checkBoxSettings.Checked = sfm.ExcessManual;
        }

        public void FillModel(SongForecastModel sfm)
        {
            sfm.ExtraForecastCount = ForecastCount;
            sfm.ActualCount = ActualCount;
            sfm.SelectRules = SelectRules;
            sfm.ExcessModelType = ExcessModelType;
            sfm.UsedAllActualCount = UseAllPoints;
            sfm.ExcessManual = ManualSettings;
        }

        public void FillModel(DForecastModel dfm)
        {
            dfm.ExtraForecastCount = ForecastCount;
            dfm.ActualCount = ActualCount;
            dfm.SelectRules = SelectRules;
            dfm.ExcessModelType = ExcessModelType;
            dfm.UsedAllActualCount = UseAllPoints;
            dfm.ExcessManual = ManualSettings;
        }

        public void FillModel(TendForecastModel tfm)
        {
            tfm.ExtraForecastCount = ForecastCount;
            tfm.ActualCount = ActualCount;
            tfm.SelectRules = SelectRules;
            tfm.ExcessModelType = ExcessModelType;
            tfm.UsedAllActualCount = UseAllPoints;
            tfm.ExcessManual = ManualSettings;
            tfm.ModelType = TMFType;
        }

        public SongForecastModel GetSongModel(FuzzyTimeSeries fts)
        {
            return new SongForecastModel(fts, Order, ForecastCount, ActualCount, UseAllPoints, ExcessModelType, ManualSettings, SelectRules);
        }

        public DForecastModel GetDModel(ACLTimeSeries acl)
        {
            return new DForecastModel(acl, Order + 1, ForecastCount, ActualCount, UseAllPoints, ExcessModelType, ManualSettings, SelectRules);
        }

        public TendForecastModel GetTendModel(ACLTimeSeries acl)
        {
            if (comboBoxType.SelectedIndex < 0)
            {
                comboBoxType.SelectedIndex = 1;
            }
            return new TendForecastModel(acl, Order + 1, ForecastCount, ActualCount, UseAllPoints, ExcessModelType, ManualSettings, SelectRules, TMFType);
        }

    }
}
