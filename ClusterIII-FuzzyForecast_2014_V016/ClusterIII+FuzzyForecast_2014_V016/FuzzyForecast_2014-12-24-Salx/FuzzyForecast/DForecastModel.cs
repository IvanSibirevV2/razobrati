using System.Collections.Generic;
using FuzzyLibrary;



using System.Windows.Forms;

namespace FuzzyForecast
{
    public class DForecastModel : IForecastModel
    {
        /// <summary>
        /// Порядок модели
        /// </summary>
        private int order = 2;

        public int Order { get { return order; } }

        public int ExtraForecastCount { get; set; }

        /// <summary>
        /// Число точек, по котрым модель обучается
        /// </summary>
        public int ActualCount { get; set; }

        public string Name { get; private set; }

        public SPointList Actual
        {
            get { return ACLSeries.FTS.PointList; }
        }

        public List<FuzzyTerm> ActualFuzzy
        {
            get { return ACLSeries.FTS.FuzzySeries; }
        }

        public ACLTimeSeries ACLSeries;

        public bool UseFTransform { get; set; }

        //public SongForecastModel STTendModel;
        public SongForecastModel SRTendModel;

        public string ModelInfo
        {
            get
            {
                var modelStr = Name +
                            ",\nПорядок: " + (Order - 1) +
                            ",\nРазбиение ряда (точки): " + (Actual.Count - ActualCount) +
                            ",\nГлубина прогноза: " + ExtraForecastCount +
                            ",\nF преобразование: " + (UseFTransform ? "Есть" : "Нет");
                var excessStr = ",\nМодель остатков: ";
                if (ExcessModelType != ForecastModelType.None)
                {
                    excessStr += ExcessModel.ExcessModel.ModelInfo;
                }
                else
                {
                    excessStr += "отсутсвует";
                }
                return modelStr + excessStr;
            }
        }
        public void delta()
        {

        }
        public string ModelInfoFlat
        {
            get
            {
                var modelStr = Name +
                            ",Порядок: " + (Order - 1) +
                            ",Разбиение ряда (точки): " + (Actual.Count - ActualCount) +
                            ",Глубина прогноза: " + ExtraForecastCount +
                            ",F преобразование: " + (UseFTransform ? "Есть" : "Нет");
                var excessStr = ",Модель остатков: ";
                if (ExcessModelType != ForecastModelType.None)
                {
                    excessStr += ExcessModel.ExcessModel.ModelInfo;
                }
                else
                {
                    excessStr += "отсутсвует";
                }
                return modelStr + excessStr;
            }
        }

        public ForecastModelType ExcessModelType { get; set; }

        public bool SelectRules { get; set; }

        public bool UsedAllActualCount { get; set; }

        public ExcessForecastModel ExcessModel { get; set; }

        public bool ExcessManual;

        public DForecastModel(ACLTimeSeries ats, int _order, int forecastCount, int actualCount, bool useAll, ForecastModelType excessModelType, bool excessManual, bool selectRules)
        {
            ACLSeries = ats;
            order = _order;
            if (order < 0)
                order = 2;
            Name = "D Модель";
            ExtraForecastCount = forecastCount;
            ActualCount = actualCount;
            UsedAllActualCount = useAll;
            ExcessModelType = excessModelType;
            ExcessManual = excessManual;
            SelectRules = selectRules;
            MakeModel();
        }

        private void MakeModel()
        {
            var RTends = new FuzzyTimeSeries(ACLSeries.Scale.TendDiffScale, ACLSeries.DiffPointList);
            //var TTends = new FuzzyTimeSeries(ACLSeries.Scale.TendBaseTypesScale, ACLSeries.DiffPointList);
            var RTendActualCount = ActualCount - 1;
            SRTendModel = new SongForecastModel(RTends, order - 1, ExtraForecastCount, RTendActualCount, UsedAllActualCount,
                                                ForecastModelType.None, false, SelectRules);
            //STTendModel = new SongForecastModel(TTends, order - 1, ForecastCount);
            if (ExcessModelType != ForecastModelType.None)
            {
                ExcessModel = new ExcessForecastModel(this, ExcessModelType, ExcessManual);
            }
        }


        public void Remake(ACLTimeSeries ats)
        {
            ACLSeries = ats;
            MakeModel();
        }

        public void Remake(int _order)
        {
            order = _order;
            if (order < 0)
                order = 2;
            MakeModel();
        }

        public SPointList GetForecastSeries(bool ignoreExcessModel)
        {
            return ForecastHelper.GetForecastSeries(this, ignoreExcessModel);
        }

        public SPointList GetForecastSeries()
        {
            return ForecastHelper.GetForecastSeries(this, false);
        }

        public List<FuzzyTerm> GetFuzzyForecastSeries()
        {
            var forecast = GetForecastSeries();
            var result = new List<FuzzyTerm>();
            foreach (var point in forecast)
            {
                result.Add(ACLSeries.Scale.BaseScale.GetTermWithMaxMF(point.Y));
            }
            return result;
        }

        public double ForecastNextPoint(double[] inputs)
        {
            var inputDiffs = new double[inputs.Length - 1];
            for (int i = 1; i < inputs.Length; i++)
            {
                inputDiffs[i - 1] = inputs[i] - inputs[i - 1];
            }
            double endPoint = inputs[inputs.Length - 1];
            //double TTend = STTendModel.ForecastNextPoint(inputDiffs);
            double RTend = SRTendModel.ForecastNextPoint(inputDiffs);

            return endPoint + RTend;
        }

        public void FillCrispRows(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillCrispRowsBase(ACLSeries, aclForecast, report);

            var diffs = SRTendModel.GetForecastSeries();
            diffs.Name = "Ряд разностей Модель";

            for (int i = 0; i < Actual.Count; i++)
            {
                var row = report.ResultCrisp[i];
                row.ModelDiff = i < ACLSeries.DiffPointList.Count ? diffs[i].Y.ToString(Calc.DFormat) : "нет";
            }

            report.PointLists.Add(diffs);
        }

        public void FillFuzzyRows(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillFuzzyRowsBase(ACLSeries, aclForecast, report);

            var diffs = SRTendModel.GetForecastSeries();
            var TActual = new FuzzyTimeSeries(ACLSeries.Scale.TendBaseTypesScale, ACLSeries.DiffPointList);
            var RActual = new FuzzyTimeSeries(ACLSeries.Scale.TendIntensityScale, ACLSeries.DiffPointList);
            var TForecast = new FuzzyTimeSeries(ACLSeries.Scale.TendBaseTypesScale, diffs);
            var RForecast = new FuzzyTimeSeries(ACLSeries.Scale.TendIntensityScale, diffs);

            for (int i = 0; i < Actual.Count; i++)
            {
                var row = report.ResultFuzzy[i];
                if (i < TForecast.FuzzySeries.Count

                    //говнокод, но все же
                    && i < TActual.FuzzySeries.Count)
                {
                    row.ModelTTend = TForecast.FuzzySeries[i].Name;
                    row.ModelRTend = RForecast.FuzzySeries[i].Name;
                    row.TTend = TActual.FuzzySeries[i].Name;
                    row.RTend = RActual.FuzzySeries[i].Name;
                    row.TError = ModelResult.GetTError(row.TTend, row.ModelTTend).ToString();
                    row.RError = (row.RTend == row.ModelRTend ? 0 : 1).ToString();
                }
                row.FTError = (row.FT == row.ModelFT ? 0 : 1).ToString();
            }

            report.FErrors = ModelResult.GetFuzzyErrors(ACLSeries.FTS.FuzzySeries, TActual.FuzzySeries, RActual.FuzzySeries,
                                                        aclForecast.FTS.FuzzySeries, TForecast.FuzzySeries,
                                                        RForecast.FuzzySeries, ActualCount, Order);
        }

        public void FillCrispErrors(Report<CrispResultRow, FuzzyResultRow> report, SPointList forecast)
        {
            report.Errors = ModelResult.GetErrors(Actual, forecast, Order, ActualCount);
        }

        public Report<CrispResultRow, FuzzyResultRow> GetReport()
        {
            var report = new Report<CrispResultRow, FuzzyResultRow> { PointLists = new List<SPointList>() };
            var forecast = GetForecastSeries();
            var aclForecast = new ACLTimeSeries(ACLSeries.Scale, forecast);
            FillCrispRows(report, aclForecast);
            FillCrispErrors(report, aclForecast.FTS.PointList);
            FillFuzzyRows(report, aclForecast);

            report.RuleRTend = ModelResult.GetRules(SRTendModel.RulesCounts);
            report.RuleMFRTend = ModelResult.GetRules(SRTendModel.Rules);
            report.ModelInfo = ModelInfo;
            report.ACLInfo = ACLSeries.Scale.ScaleInfo;
            return report;
        }

        public Report<CrispResultRow, FuzzyResultRow> GetReport(SPointList forecast)
        {
            var report = new Report<CrispResultRow, FuzzyResultRow> { PointLists = new List<SPointList>() };
            //var forecast = GetForecastSeries();
            var aclForecast = new ACLTimeSeries(ACLSeries.Scale, forecast);
            FillCrispRows(report, aclForecast);
            FillCrispErrors(report, aclForecast.FTS.PointList);
            FillFuzzyRows(report, aclForecast);

            report.RuleRTend = ModelResult.GetRules(SRTendModel.RulesCounts);
            report.RuleMFRTend = ModelResult.GetRules(SRTendModel.Rules);
            report.ModelInfo = ModelInfo;
            report.ACLInfo = ACLSeries.Scale.ScaleInfo;
            return report;
        }
    }
}
