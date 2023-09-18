using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FuzzyLibrary;
using ZedGraph;

namespace FuzzyForecast
{
    public partial class ModelUserControl : UserControl
    {

        public ModelResult Result;
        public ModelSeries MSeries;

        public ZedGraphControl GraphControl
        {
            get { return graphControlModel; }
        }

        public ModelUserControl(ModelResult result, ModelSeries series)
        {
            InitializeComponent();
            Result = result;
            MSeries = series;
            DrawHelper.CleanseGraph(graphControlModel);
        }

        /// <summary>
        /// Вывод на экран ошибок и графиков, "преддверье"
        /// </summary>
        public void ShowModel()
        {
            var actual = new Series(Result.ForecastModel.Actual);
            var forecast = new Series(Result.ForecastModel.GetForecastSeries());
            int order = Result.ForecastModel.Order;
            ShowModel(actual, forecast, order);
        }

        public void ShowGraphs()
        {
            tabResultTend.SelectTab(0);
        }

        public void ShowResult()
        {
            tabResultTend.SelectTab(1);
        }

        /// <summary>
        /// Вывод на экран ошибок и графиков...
        /// </summary>
        private void ShowModel(Series actual, Series forecast, int order)
        {
            DrawHelper.CleanseGraph(graphControlModel);
            //Строим ts1- исходный ряд
            DrawHelper.DrawCraph(graphControlModel, actual, Color.Red, true);

            //Если есть результат , то выводим на экран
            //ts1(N Модель) Int
            //ts1(N Модель) Ext
            if (forecast != null)
            {
                //ts1(N Модель) Int
                var iForecast = ForecastHelper.GetInternalPoints(forecast.PointList, Result.ForecastModel.ActualCount);
                DrawHelper.DrawPointList(graphControlModel, iForecast, Color.Blue, SymbolType.Star, false);                
                //ts1(N Модель) Ext
                var eForecast = ForecastHelper.GetExternalPoints(forecast.PointList, Result.ForecastModel.ActualCount);
                DrawHelper.DrawPointList(graphControlModel, eForecast, Color.DarkGreen, SymbolType.Triangle, false);                 
            }          

            SPointList pts = actual.PointList;

            graphControlModel.GraphPane.Title.IsVisible = true;
            graphControlModel.GraphPane.Title.Text = pts.Name + Result.FillGeneralTendInline();

            graphControlModel.Invalidate();

            
            if (forecast != null)
            {
                FillCrispErrors();
                FillFuzzyErrors();
                FillRules();
            }
            rtbStats.Clear();
            rtbStats.Text = Result.Resume();
            Result.FillForecast(listViewForecast);
        }

        private void FillCrispErrors()
        {
            #warning 0.0.0 Тот самый вывод на экран
            listViewErrors.Items.Clear();
            //Внутренние ошибки
            FillErrorsGroup(Result.ModelReport.Errors[0], 0);
            //Внешние ошибки
            FillErrorsGroup(Result.ModelReport.Errors[1], 1);
        }

        private void FillErrorsGroup(ErrorRow row, int groupId)
        {
            double MSE = row.MSE;
            //SMAPE
            double SMAPE = row.SMAPE;

            double MAPE = row.MAPE;
            double R2 = row.R2;
            double RMSE = row.RMSE;
            
            double D = row.D;
            double Dispersion = row.Dispersion;
                
            //Вывод на экран названия ошибки
            var lvi = listViewErrors.Items.Add("MSE");
            //Вывод на экран значения
            //lvi.SubItems.Add(MSE.ToString("0.###E-000"));
            lvi.SubItems.Add(MSE.ToString(Calc.DFormat));
            //Вывод на экран не в "дефолт"
            lvi.Group = listViewErrors.Groups[groupId];

            //Вывод на экран названия ошибки
            lvi = listViewErrors.Items.Add("SMAPE");
            //Вывод на экран значения
            //lvi.SubItems.Add(MSE.ToString("0.###E-000"));
            lvi.SubItems.Add(SMAPE.ToString(Calc.DFormat));
            //Вывод на экран не в "дефолт"
            lvi.Group = listViewErrors.Groups[groupId];
                
            lvi = listViewErrors.Items.Add("MAPE");
            lvi.SubItems.Add(MAPE.ToString(Calc.DFormat));
            lvi.Group = listViewErrors.Groups[groupId];
            lvi = listViewErrors.Items.Add("R2");
            lvi.SubItems.Add(R2.ToString(Calc.DFormat));
            lvi.Group = listViewErrors.Groups[groupId];
            lvi = listViewErrors.Items.Add("RMSE");
            lvi.SubItems.Add(RMSE.ToString(Calc.DFormat));
            lvi.Group = listViewErrors.Groups[groupId];

            lvi = listViewErrors.Items.Add("Da");
            lvi.SubItems.Add(D.ToString(Calc.DFormat));
            lvi.Group = listViewErrors.Groups[groupId];
            lvi = listViewErrors.Items.Add("Dispersion");
            lvi.SubItems.Add(Dispersion.ToString(Calc.DFormat));
            lvi.Group = listViewErrors.Groups[groupId];
        }
        
        private void FillFuzzyErrors()
        {
            //Внутренние ошибки
            FillFuzzyErrorsGroup(Result.ModelReport.FErrors[0], 0);
            //Внешние ошибки
            FillFuzzyErrorsGroup(Result.ModelReport.FErrors[1], 1);
        }

        private void FillFuzzyErrorsGroup(FuzzyErrorRow row, int groupId)
        {
            var lvi = listViewErrors.Items.Add("FPE");
            lvi.SubItems.Add(row.FPE.ToString("F"));
            lvi.Group = listViewErrors.Groups[groupId];
            lvi = listViewErrors.Items.Add("FCE");
            lvi.SubItems.Add(row.FCE);
            lvi.Group = listViewErrors.Groups[groupId];
            lvi = listViewErrors.Items.Add("TTend FPE");
            lvi.SubItems.Add(row.TTendFPE.ToString("F"));
            lvi.Group = listViewErrors.Groups[groupId];
            lvi = listViewErrors.Items.Add("TTend FCE");
            lvi.SubItems.Add(row.TTendFCE);
            lvi.Group = listViewErrors.Groups[groupId];
            lvi = listViewErrors.Items.Add("RTend FPE");
            lvi.SubItems.Add(row.RTendFPE.ToString("F"));
            lvi.Group = listViewErrors.Groups[groupId];
            lvi = listViewErrors.Items.Add("RTend FCE");
            lvi.SubItems.Add(row.RTendFCE);
            lvi.Group = listViewErrors.Groups[groupId];
        }

        private void FillRules()
        {
            comboBoxRulesCounts.Items.Clear();
            comboBoxRules.Items.Clear();
            switch (Result.ModelType)
            {
                case ForecastModelType.None:
                    break;
                case ForecastModelType.Neural:
                    break;
                case ForecastModelType.Song:
                    FillRulesSong();
                    break;
                case ForecastModelType.D:
                    FillRulesD();
                    break;
                case ForecastModelType.Tend:
                    FillRulesTend();
                    break;
                case ForecastModelType.F:
                    break;
                case ForecastModelType._F:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void FillRulesSong()
        {
            comboBoxRulesCounts.Items.Add("Ряд");
            comboBoxRulesCounts.SelectedIndex = 0;

            comboBoxRules.Items.Add("Ряд");
            comboBoxRules.SelectedIndex = 0;
        }

        private void FillRulesTend()
        {
            comboBoxRulesCounts.Items.Add("Тенденции");
            comboBoxRulesCounts.Items.Add("Интенсивности");
            comboBoxRulesCounts.SelectedIndex = 0;

            comboBoxRules.Items.Add("Тенденции");
            comboBoxRules.Items.Add("Интенсивности");
            comboBoxRules.SelectedIndex = 0;
        }

        private void FillRulesD()
        {
            comboBoxRulesCounts.Items.Add("Разность");
            comboBoxRulesCounts.SelectedIndex = 0;

            comboBoxRules.Items.Add("Разность");
            comboBoxRules.SelectedIndex = 0;
        }

        private void ShowRulesCounts(Dictionary<string, int> rulesCounts)
        {
            listViewRulesCounts.Items.Clear();
            int i = 1;
            foreach (KeyValuePair<string, int> valuePair in rulesCounts)
            {
                var lvi = listViewRulesCounts.Items.Add(i.ToString());
                lvi.SubItems.Add(valuePair.Key);
                lvi.SubItems.Add(valuePair.Value.ToString());
                i++;
            }
        }

        private void ShowRules(IEnumerable<MamdaniFuzzyRule> rules)
        {
            listViewRules.Items.Clear();
            int i = 0;
            foreach (var r in rules)
            {
                var lvi = listViewRules.Items.Add(i.ToString());
                lvi.SubItems.Add(r.ToString());
                lvi.SubItems.Add(r.MF.ToString(Calc.DFormat));
                i++;
            }
        }

        private void ShowTendRules()
        {
            var model = (TendForecastModel)Result.ForecastModel;
            switch (model.ModelType)
            {
                case TendForecastModel.TFMType.F2S:
                    if (comboBoxRulesCounts.SelectedIndex == 0)
                    {
                        ShowRulesCounts(model.STTendModel.RulesCounts);
                    }
                    else if (comboBoxRulesCounts.SelectedIndex == 1)
                    {
                        ShowRulesCounts(model.SRTendModel.RulesCounts);
                    }
                    if (comboBoxRules.SelectedIndex == 0)
                    {
                        ShowRules(model.STTendModel.Rules);
                    }
                    else
                    {
                        ShowRules(model.SRTendModel.Rules);
                    }
                    break;
                case TendForecastModel.TFMType.FN:
                    break;
                case TendForecastModel.TFMType.F3N:
                    ShowRulesCounts(model.SRTendModel.RulesCounts);
                    ShowRules(model.SRTendModel.Rules);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        private void ShowRules()
        {
            switch (Result.ModelType)
            {
                case ForecastModelType.None:
                case ForecastModelType.Neural:
                    return;
                case ForecastModelType.Song:
                    ShowRulesCounts(((SongForecastModel)Result.ForecastModel).RulesCounts);
                    ShowRules(((SongForecastModel)Result.ForecastModel).Rules);
                    break;
                case ForecastModelType.D:
                    ShowRulesCounts(((DForecastModel)Result.ForecastModel).SRTendModel.RulesCounts);
                    ShowRules(((DForecastModel)Result.ForecastModel).SRTendModel.Rules);
                    break;
                case ForecastModelType.Tend:
                    ShowTendRules();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void toolStripComboBoxRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowRules();
        }
    }


}
