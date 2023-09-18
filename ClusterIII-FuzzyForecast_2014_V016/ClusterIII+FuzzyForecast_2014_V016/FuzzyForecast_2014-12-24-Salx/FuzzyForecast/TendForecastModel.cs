using System;
using System.Collections.Generic;
using FuzzyLibrary;

namespace FuzzyForecast
{
    public class TendForecastModel : IForecastModel
    {

        public enum TFMType
        {
            F2S,
            FN,
            F3N
        }
        /// <summary>
        /// Порядок модели
        /// </summary>
        private int order = 2;

        public int Order { get { return order; } }

        public int ExtraForecastCount { get; set; }

        private string name;

        public bool UseFTransform { get; set; }

        public string Name
        {
            get
            {
                return name + " (" + MType + ")";
            }
        }

        /// <summary>
        /// Число точек, по которым модель обучается
        /// </summary>
        public int ActualCount { get; set; }

        public string MType
        {
            get
            {
                var mtype = "";
                switch (ModelType)
                {
                    case TFMType.F2S:
                        mtype = "F2S";
                        break;
                    case TFMType.FN:
                        mtype = "F1N";
                        break;
                    case TFMType.F3N:
                        mtype = "F3N1S";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                return mtype;
            }
        }

        public string ModelInfo
        {
            get
            {
                var mtype = "";
                string WarningShield = mtype.ToString();
                
                switch (ModelType)
                {
                    case TFMType.F2S:
                        mtype = "F2S";
                        break;
                    case TFMType.FN:
                        mtype = "F1N";
                        break;
                    case TFMType.F3N:
                        mtype = "F3N1S";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
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

        public string ModelInfoFlat
        {
            get
            {
                var mtype = "";
                string WarningShield = mtype.ToString();
                switch (ModelType)
                {
                    case TFMType.F2S:
                        mtype = "F2S";
                        break;
                    case TFMType.FN:
                        mtype = "F1N";
                        break;
                    case TFMType.F3N:
                        mtype = "F3N1S";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
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

        public void delta()
        {

        }
        public SPointList Actual
        {
            get { return ACLSeries.FTS.PointList; }
        }

        public List<FuzzyTerm> ActualFuzzy
        {
            get { return ACLSeries.FTS.FuzzySeries; }
        }

        public ACLTimeSeries ACLSeries;

        public SongForecastModel STTendModel;
        public SongForecastModel SRTendModel;
        public NeuralForecastModel NTendModel;

        /// <summary>
        /// Модель для прогнозирования типа тенденций нейронной сетью.
        /// </summary>
        public NeuralTendForecastModel N3TendModel;

        public ForecastModelType ExcessModelType { get; set; }

        public bool SelectRules { get; set; }

        public bool UsedAllActualCount { get; set; }

        public ExcessForecastModel ExcessModel { get; set; }

        public bool ExcessManual;

        public TFMType ModelType;

        public TendForecastModel(ACLTimeSeries ats, int _order, int forecastCount, int actualCount, bool useAll, ForecastModelType excessModelType, bool excessManual, bool selectRules)
            : this(ats, _order, forecastCount, actualCount, useAll, excessModelType, excessManual, selectRules, TFMType.F2S)
        {
        }

        public TendForecastModel(ACLTimeSeries ats, int _order, int forecastCount, int actualCount, bool useAll, ForecastModelType excessModelType, bool excessManual, bool selectRules, TFMType type)
        {
            ACLSeries = ats;
            order = _order;
            if (order < 0)
                order = 2;
            name = "T Модель";
            ExtraForecastCount = forecastCount;
            ActualCount = actualCount;
            UsedAllActualCount = useAll;
            ExcessModelType = excessModelType;
            ExcessManual = excessManual;
            SelectRules = selectRules;
            ModelType = type;

            MakeModel();
        }

        private void MakeModel()
        {
            switch (ModelType)
            {
                case TFMType.F2S:
                    MakeModelF2S();
                    break;
                case TFMType.FN:
                    MakeModelFN();
                    break;
                case TFMType.F3N:
                    MakeModelF3N();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MakeModelF2S()
        {
            var RTendsList = new SPointList { Name = "Ряд четких значений для инт.", XName = ACLSeries.DiffPointList.XName, YName = ACLSeries.DiffPointList.YName };
            int i = 0;
            foreach (var tend in ACLSeries.Tends)
            {
                RTendsList.Add(new SPoint(ACLSeries.FTS.PointList[i].X, tend.RTendCrisp));
                i++;
            }

            var TTendsList = new SPointList { Name = "Ряд четких значений для тенд.", XName = ACLSeries.DiffPointList.XName, YName = ACLSeries.DiffPointList.YName };
            i = 0;
            foreach (var tend in ACLSeries.Tends)
            {
                TTendsList.Add(new SPoint(ACLSeries.FTS.PointList[i].X, tend.TTendCrisp));
                i++;
            }

            var RTends = new FuzzyTimeSeries(ACLSeries.Scale.TendIntensityScale, RTendsList);
            var TTends = new FuzzyTimeSeries(ACLSeries.Scale.TendBaseTypesScale, TTendsList);

            var actualCount = ActualCount - 1;

            SRTendModel = new SongForecastModel(RTends, order - 1, ExtraForecastCount, actualCount, UsedAllActualCount, ForecastModelType.None, false,
                                                SelectRules);
            STTendModel = new SongForecastModel(TTends, order - 1, ExtraForecastCount, actualCount, UsedAllActualCount, ForecastModelType.None, false,
                                                SelectRules);

            if (ExcessModelType != ForecastModelType.None)
            {
                ExcessModel = new ExcessForecastModel(this, ExcessModelType, ExcessManual);
            }
        }

        private void MakeModelFN()
        {
            var TendsList = new SPointList { Name = "Ряд четких значений для инт.", XName = ACLSeries.DiffPointList.XName, YName = ACLSeries.DiffPointList.YName };
            int i = 0;
            foreach (var tend in ACLSeries.Tends)
            {
                TendsList.Add(new SPoint(ACLSeries.FTS.PointList[i].X, tend.DefuzzyCrisp));
                i++;
            }
            var actualCount = ActualCount - 1;
            NTendModel = new NeuralForecastModel(TendsList, order - 1, 5, ExtraForecastCount, actualCount, UsedAllActualCount, ForecastModelType.None, false);
            if (ExcessModelType != ForecastModelType.None)
            {
                ExcessModel = new ExcessForecastModel(this, ExcessModelType, ExcessManual);
            }
        }

        private void MakeModelF3N()
        {
            N3TendModel = new NeuralTendForecastModel(ACLSeries, order, 6, 20000, 0.00001, ExtraForecastCount, ActualCount, UsedAllActualCount);

            var RTendsList = new SPointList { Name = "Ряд четких значений для инт.", XName = ACLSeries.DiffPointList.XName, YName = ACLSeries.DiffPointList.YName };
            int i = 0;
            foreach (var tend in ACLSeries.Tends)
            {
                RTendsList.Add(new SPoint(ACLSeries.FTS.PointList[i].X, tend.RTendCrisp));
                i++;
            }

            var RTends = new FuzzyTimeSeries(ACLSeries.Scale.TendIntensityScale, RTendsList);

            var actualCount = ActualCount - 1;

            SRTendModel = new SongForecastModel(RTends, order - 1, ExtraForecastCount, actualCount, UsedAllActualCount, ForecastModelType.None, false,
                                                SelectRules);

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


        public double CalcDiff1(double RTend, double TTend)
        {
            var btt = ACLSeries.Scale.GetBaseTendType(TTend);
            switch (btt)
            {
                case BaseTendType.Increase:
                    return TTend > 0 ? +Math.Abs(RTend) : 0;
                case BaseTendType.Decrease:
                    return TTend < 0 ? -Math.Abs(RTend) : 0;
                case BaseTendType.Stability:
                    return 0;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public double CalcDiff2(double RTend, double TTend)
        {
            if (TTend == 0)
            {
                return 0;
            }
            if (TTend > 0)
            {
                return +Math.Abs(RTend);
            }
            return -Math.Abs(RTend);
        }

        /// <summary>
        /// Нивелирование выбросов
        /// </summary>
        /// <param name="forecastPoint"></param>
        /// <returns></returns>
        public double StabilizeResult(double forecastPoint)
        {
            if (forecastPoint > ACLSeries.FTS.PointList.FindMax().Y)
            {
                return ACLSeries.FTS.PointList.FindMax().Y;
            }
            else if (forecastPoint < ACLSeries.FTS.PointList.FindMin().Y)
            {
                return ACLSeries.FTS.PointList.FindMin().Y;
            }
            else
            {
                return forecastPoint;
            }
        }

        public double ForecastNextPointF2S(double[] inputs)
        {
            var inputT = new double[inputs.Length - 1];
            var inputR = new double[inputs.Length - 1];
            for (int i = 1; i < inputs.Length; i++)
            {
                var pt1 = new FTSPoint(ACLSeries.Scale.BaseScale, new SPoint(i - 1, inputs[i - 1]));
                var pt2 = new FTSPoint(ACLSeries.Scale.BaseScale, new SPoint(i, inputs[i]));
                var tend = new FuzzyTend(ACLSeries.Scale, pt1, pt2);
                inputR[i - 1] = tend.RTendCrisp;
                inputT[i - 1] = tend.TTendCrisp;
            }

            double endPoint = inputs[inputs.Length - 1];
            double TTend = STTendModel.ForecastNextPoint(inputT);
            double RTend = SRTendModel.ForecastNextPoint(inputR);
            var diff = CalcDiff1(RTend, TTend);


            return StabilizeResult(endPoint + diff);
        }

        public double ForecastNextPointFN(double[] inputs)
        {
            var inputR = new double[inputs.Length - 1];
            for (int i = 1; i < inputs.Length; i++)
            {
                var pt1 = new FTSPoint(ACLSeries.Scale.BaseScale, new SPoint(i - 1, inputs[i - 1]));
                var pt2 = new FTSPoint(ACLSeries.Scale.BaseScale, new SPoint(i, inputs[i]));
                var tend = new FuzzyTend(ACLSeries.Scale, pt1, pt2);
                inputR[i - 1] = tend.DefuzzyCrisp;
            }

            double endPoint = inputs[inputs.Length - 1];
            double diff = NTendModel.ForecastNextPoint(inputR);
            return StabilizeResult(endPoint + diff);
        }

        public double ForecastNextPointF3N(double[] inputs)
        {
            var inputR = new double[inputs.Length - 1];
            for (int i = 1; i < inputs.Length; i++)
            {
                var pt1 = new FTSPoint(ACLSeries.Scale.BaseScale, new SPoint(i - 1, inputs[i - 1]));
                var pt2 = new FTSPoint(ACLSeries.Scale.BaseScale, new SPoint(i, inputs[i]));
                var tend = new FuzzyTend(ACLSeries.Scale, pt1, pt2);
                inputR[i - 1] = tend.RTendCrisp;
            }

            double endPoint = inputs[inputs.Length - 1];

            double RTend = SRTendModel.ForecastNextPoint(inputR);

            var tendMF = N3TendModel.ForecastNextPoint(inputs);
            var TTend = tendMF.ToTendType();

            var diff = CalcDiff2(RTend, TTend);

            return StabilizeResult(endPoint + diff);
        }

        public double ForecastNextPoint(double[] inputs)
        {
            switch (ModelType)
            {
                case TFMType.F2S:
                    return ForecastNextPointF2S(inputs);
                case TFMType.FN:
                    return ForecastNextPointFN(inputs);
                case TFMType.F3N:
                    return ForecastNextPointF3N(inputs);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public List<string> GetTTendsStrings()
        {
            var strs = new List<string>();
            var forecast = N3TendModel.GetForecastSeries();
            foreach (var mf in forecast)
            {
                strs.Add(mf.ToString(ACLSeries.Scale.TendBaseTypesScale));
            }
            return strs;
        }

        public List<double> GetTTendsCrisp()
        {
            var tends = new List<double>();
            var forecast = N3TendModel.GetForecastSeries();
            foreach (var mf in forecast)
            {
                tends.Add(mf.ToTendType());
            }
            return tends;
        }

        public List<FuzzyTerm> GetTTendsFuzzy()
        {
            var tends = new List<FuzzyTerm>();
            var forecast = N3TendModel.GetForecastSeries();
            foreach (var mf in forecast)
            {
                tends.Add(mf.GetFuzzyTerm(ACLSeries.Scale.TendBaseTypesScale));
            }
            return tends;
        }

        public void FillCrispRowsF2S(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillCrispRowsBase(ACLSeries, aclForecast, report);

            var TForecast = STTendModel.GetForecastSeries();
            TForecast.Name = "Тенденции Модель";
            var RForecast = SRTendModel.GetForecastSeries();
            RForecast.Name = "Интенсивности Модель";

            var diffs =
             new SPointList { Name = "Ряд разностей Модель", XName = Actual.XName, YName = "Значение Разности" };

            for (int i = 0; i < Actual.Count; i++)
            {
                var row = report.ResultCrisp[i];
                if (i < ACLSeries.Tends.Count)
                {
                    var diff = CalcDiff1(RForecast[i].Y, TForecast[i].Y);
                    row.ModelDiff = diff.ToString(Calc.DFormat);
                    diffs.Add(new SPoint(Actual[i].X, diff));
                    //var diff = Convert.ToDouble(row.ModelDiff);
                    //diffs.Add(new SPoint(Actual[i].X, diff));
                }
                else
                {
                    row.ModelDiff = "нет";
                }
            }

            report.PointLists.Add(diffs);
            report.PointLists.Add(TForecast);
            report.PointLists.Add(RForecast);
        }

        public void FillFuzzyRowsF2S(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillFuzzyRowsBase(ACLSeries, aclForecast, report);

            var TForecast = STTendModel.GetFuzzyForecastSeries();
            var TForecastString = STTendModel.GetStringResult();
            var RForecast = SRTendModel.GetFuzzyForecastSeries();
            var RForecastString = SRTendModel.GetStringResult();

            for (int i = 0; i < Actual.Count; i++)
            {
                var row = report.ResultFuzzy[i];
                if (i < STTendModel.ActualFuzzy.Count)
                {
                    row.TTend = STTendModel.ActualFuzzy[i].Name;
                    row.RTend = SRTendModel.ActualFuzzy[i].Name;
                    if (i >= STTendModel.Order)
                    {
                        row.ModelTTend = TForecastString[i - STTendModel.Order];
                        row.ModelRTend = RForecastString[i - SRTendModel.Order];
                    }
                    row.TError = ModelResult.GetTError(row.TTend, TForecast[i].Name).ToString();
                    row.RError = (row.RTend == RForecast[i].Name ? 0 : 1).ToString();
                }

                row.FTError = (row.FT == row.ModelFT ? 0 : 1).ToString();
            }

            report.FErrors = ModelResult.GetFuzzyErrors(ACLSeries.FTS.FuzzySeries, STTendModel.ActualFuzzy, SRTendModel.ActualFuzzy,
                                                        aclForecast.FTS.FuzzySeries, TForecast,
                                                        RForecast, ActualCount, Order);
        }

        public void FillCrispErrorsF2S(Report<CrispResultRow, FuzzyResultRow> report, SPointList forecast)
        {
            report.Errors = ModelResult.GetErrors(Actual, forecast, Order, ActualCount);
        }

        public Report<CrispResultRow, FuzzyResultRow> GetReportF2S()
        {
            var report = new Report<CrispResultRow, FuzzyResultRow> { PointLists = new List<SPointList>() };
            var forecast = GetForecastSeries();
            var aclForecast = new ACLTimeSeries(ACLSeries.Scale, forecast);
            FillCrispRowsF2S(report, aclForecast);
            FillCrispErrorsF2S(report, aclForecast.FTS.PointList);
            FillFuzzyRowsF2S(report, aclForecast);

            report.RuleRTend = ModelResult.GetRules(SRTendModel.RulesCounts);
            report.RuleTTend = ModelResult.GetRules(STTendModel.RulesCounts);

            report.RuleMFRTend = ModelResult.GetRules(SRTendModel.Rules);
            report.RuleMFTTend = ModelResult.GetRules(STTendModel.Rules);

            report.ModelInfo = ModelInfo;
            report.ACLInfo = ACLSeries.Scale.ScaleInfo;
            return report;
        }

        public Report<CrispResultRow, FuzzyResultRow> GetReportF2S(SPointList forecast)
        {
            var report = new Report<CrispResultRow, FuzzyResultRow> { PointLists = new List<SPointList>() };
            //var forecast = GetForecastSeries();
            var aclForecast = new ACLTimeSeries(ACLSeries.Scale, forecast);
            FillCrispRowsF2S(report, aclForecast);
            FillCrispErrorsF2S(report, aclForecast.FTS.PointList);
            FillFuzzyRowsF2S(report, aclForecast);

            report.RuleRTend = ModelResult.GetRules(SRTendModel.RulesCounts);
            report.RuleTTend = ModelResult.GetRules(STTendModel.RulesCounts);

            report.RuleMFRTend = ModelResult.GetRules(SRTendModel.Rules);
            report.RuleMFTTend = ModelResult.GetRules(STTendModel.Rules);

            report.ModelInfo = ModelInfo;
            report.ACLInfo = ACLSeries.Scale.ScaleInfo;
            return report;
        }

        public void FillCrispRowsF1N(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillCrispRowsBase(ACLSeries, aclForecast, report);

            var diffs = NTendModel.GetForecastSeries();
            diffs.Name = "Ряд разностей Модель";

            var diffs1 = NTendModel.GetForecastSeries();
            diffs.Name = "Тенденции Модель";

            var diffs2 = NTendModel.GetForecastSeries();
            diffs.Name = "Интенсивности Модель";

            for (int i = 0; i < Actual.Count; i++)
            {
                var row = report.ResultCrisp[i];
                row.ModelDiff = i < ACLSeries.Tends.Count
                                  ? diffs[i].Y.ToString(Calc.DFormat)
                                  : "нет";
            }

            report.PointLists.Add(diffs);
            report.PointLists.Add(diffs1);
            report.PointLists.Add(diffs2);
        }

        public void FillFuzzyRowsF1N(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillFuzzyRowsBase(ACLSeries, aclForecast, report);

            var diffs = NTendModel.GetForecastSeries();
            var TActual = new FuzzyTimeSeries(ACLSeries.Scale.TendBaseTypesScale, NTendModel.Actual);
            var RActual = new FuzzyTimeSeries(ACLSeries.Scale.TendIntensityScale, NTendModel.Actual);
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

        public void FillCrispErrorsF1N(Report<CrispResultRow, FuzzyResultRow> report, SPointList forecast)
        {
            report.Errors = ModelResult.GetErrors(Actual, forecast, Order, ActualCount);
        }

        public Report<CrispResultRow, FuzzyResultRow> GetReportF1N()
        {
            var report = new Report<CrispResultRow, FuzzyResultRow> { PointLists = new List<SPointList>() };
            var forecast = GetForecastSeries();
            var aclForecast = new ACLTimeSeries(ACLSeries.Scale, forecast);
            FillCrispRowsF1N(report, aclForecast);
            FillCrispErrorsF1N(report, aclForecast.FTS.PointList);
            FillFuzzyRowsF1N(report, aclForecast);
            report.ModelInfo = ModelInfo;
            report.ACLInfo = ACLSeries.Scale.ScaleInfo;
            return report;
        }

        public Report<CrispResultRow, FuzzyResultRow> GetReportF1N(SPointList forecast)
        {
            var report = new Report<CrispResultRow, FuzzyResultRow> { PointLists = new List<SPointList>() };
            //var forecast = GetForecastSeries();
            var aclForecast = new ACLTimeSeries(ACLSeries.Scale, forecast);
            FillCrispRowsF1N(report, aclForecast);
            FillCrispErrorsF1N(report, aclForecast.FTS.PointList);
            FillFuzzyRowsF1N(report, aclForecast);
            report.ModelInfo = ModelInfo;
            report.ACLInfo = ACLSeries.Scale.ScaleInfo;
            return report;
        }

        public void FillCrispRowsF3N(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillCrispRowsBase(ACLSeries, aclForecast, report);

            var TForecastCrisp = GetTTendsCrisp();

            var TForecast = GetTTendsFuzzy();

            var RForecast = SRTendModel.GetForecastSeries();
            RForecast.Name = "Интенсивности Модель";

            var diffs =
             new SPointList { Name = "Ряд разностей Модель", XName = Actual.XName, YName = "Значение Разности" };

            var tends =
             new SPointList { Name = "Тенденции Модель", XName = Actual.XName, YName = "Значение Разности" };

            for (int i = 0; i < Actual.Count; i++)
            {
                var row = report.ResultCrisp[i];
                if (i < ACLSeries.Tends.Count)
                {
                    var diff = CalcDiff2(RForecast[i].Y, TForecastCrisp[i]);
                    row.ModelDiff = diff.ToString(Calc.DFormat);
                    diffs.Add(new SPoint(Actual[i].X, diff));
                    var tend = GenericFuzzySystem.Defuzzify(DefuzzificationMethod.Centroid, TForecast[i].MembershipFunction,
                                                            ACLSeries.Scale.TendBaseTypesScale.Min,
                                                            ACLSeries.Scale.TendBaseTypesScale.Max);
                    tends.Add(new SPoint(Actual[i].X, tend));
                }
            }

            report.PointLists.Add(diffs);
            report.PointLists.Add(RForecast);
            report.PointLists.Add(tends);
        }

        public void FillFuzzyRowsF3N(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillFuzzyRowsBase(ACLSeries, aclForecast, report);

            var TForecast = GetTTendsFuzzy();
            var TForecastString = GetTTendsStrings();

            var RForecast = SRTendModel.GetFuzzyForecastSeries();
            var RForecastString = SRTendModel.GetStringResult();

            for (int i = 0; i < Actual.Count; i++)
            {
                var row = report.ResultFuzzy[i];
                if (i < ACLSeries.Tends.Count)
                {
                    row.RTend = SRTendModel.ActualFuzzy[i].Name;
                    row.ModelTTend = TForecastString[i];
                    if (i >= SRTendModel.Order)
                    {
                        row.ModelRTend = RForecastString[i - SRTendModel.Order];
                    }

                    row.TError = ModelResult.GetTError(row.TTend, TForecast[i].Name).ToString();
                    row.RError = (row.RTend == RForecast[i].Name ? 0 : 1).ToString();
                }
                row.FTError = (row.FT == row.ModelFT ? 0 : 1).ToString();
            }

            report.FErrors = ModelResult.GetFuzzyErrors(ACLSeries.FTS.FuzzySeries, ACLSeries.TTends, SRTendModel.ActualFuzzy,
                                                        aclForecast.FTS.FuzzySeries, TForecast,
                                                        RForecast, ActualCount, Order);
        }

        public void FillCrispErrorsF3N(Report<CrispResultRow, FuzzyResultRow> report, SPointList forecast)
        {
            report.Errors = ModelResult.GetErrors(Actual, forecast, Order, ActualCount);
        }

        public Report<CrispResultRow, FuzzyResultRow> GetReportF3N()
        {
            var report = new Report<CrispResultRow, FuzzyResultRow> { PointLists = new List<SPointList>() };
            var forecast = GetForecastSeries();
            var aclForecast = new ACLTimeSeries(ACLSeries.Scale, forecast);
            FillCrispRowsF3N(report, aclForecast);
            FillCrispErrorsF3N(report, aclForecast.FTS.PointList);
            FillFuzzyRowsF3N(report, aclForecast);

            report.RuleRTend = ModelResult.GetRules(SRTendModel.RulesCounts);
            report.RuleMFRTend = ModelResult.GetRules(SRTendModel.Rules);

            report.ModelInfo = ModelInfo;
            report.ACLInfo = ACLSeries.Scale.ScaleInfo;
            return report;
        }

        public Report<CrispResultRow, FuzzyResultRow> GetReportF3N(SPointList forecast)
        {
            var report = new Report<CrispResultRow, FuzzyResultRow> { PointLists = new List<SPointList>() };
            //var forecast = GetForecastSeries();
            var aclForecast = new ACLTimeSeries(ACLSeries.Scale, forecast);
            FillCrispRowsF3N(report, aclForecast);
            FillCrispErrorsF3N(report, aclForecast.FTS.PointList);
            FillFuzzyRowsF3N(report, aclForecast);

            report.RuleRTend = ModelResult.GetRules(SRTendModel.RulesCounts);
            report.RuleMFRTend = ModelResult.GetRules(SRTendModel.Rules);

            report.ModelInfo = ModelInfo;
            report.ACLInfo = ACLSeries.Scale.ScaleInfo;
            return report;
        }

        public Report<CrispResultRow, FuzzyResultRow> GetReport()
        {
            switch (ModelType)
            {
                case TFMType.F2S:
                    return GetReportF2S();
                case TFMType.FN:
                    return GetReportF1N();
                case TFMType.F3N:
                    return GetReportF3N();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Report<CrispResultRow, FuzzyResultRow> GetReport(SPointList forecast)
        {
            switch (ModelType)
            {
                case TFMType.F2S:
                    return GetReportF2S(forecast);
                case TFMType.FN:
                    return GetReportF1N(forecast);
                case TFMType.F3N:
                    return GetReportF3N(forecast);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
