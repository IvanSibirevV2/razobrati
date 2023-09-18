using System;
using System.Collections.Generic;
using FuzzyLibrary;

namespace FuzzyForecast
{
    /// <summary>
    /// Модель Сонга для прогнозирования значений нечеткого временного ряда
    /// </summary>
    public class SongForecastModel : IFuzzyForecastModel
    {

        private MamdaniFuzzySystem mfs;


        public ACLTimeSeries ACLSeries;

        /// <summary>
        /// Нечеткий временной ряд, который предсказывается
        /// </summary>
        public FuzzyTimeSeries FTS;

        /// <summary>
        /// Четкие значения временного ряда, который предсказывается 
        /// </summary>
        public SPointList Actual
        {
            get { return FTS.PointList; }
        }

        public List<FuzzyTerm> ActualFuzzy
        {
            get { return FTS.FuzzySeries; }
        }

        /// <summary>
        /// отображение строки правила на правила 
        /// </summary>
        public Dictionary<string, List<MamdaniFuzzyRule>> RulesMap;

        /// <summary>
        /// отображение строки условия на правила
        /// </summary>
        public Dictionary<string, List<MamdaniFuzzyRule>> ConditionMap;

        /// <summary>
        /// Отображение строки правила на количество правил
        /// </summary>
        public Dictionary<string, int> RulesCounts;

        /// <summary>
        /// Правила в порядке появления
        /// </summary>
        public List<MamdaniFuzzyRule> Rules
        {
            get { return mfs.Rules; }
        }

        /// <summary>
        /// Число точек, по котрым модель обучается
        /// </summary>
        public int ActualCount { get; set; }

        /// <summary>
        /// Порядок модели
        /// </summary>
        private int order = 1;

        public int Order { get { return order; } }

        public bool UseFTransform { get; set; }

        /// <summary>
        /// Число точек, на которые будет прогнозироваться...(> Actual.Count)
        /// </summary>
        public int ExtraForecastCount { get; set; }

        public string Name { get; private set; }

        public void delta()
        {

        }
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

        public List<FuzzyVariable> fvInputs = new List<FuzzyVariable>();
        public FuzzyVariable fvOutput;

        public ExcessForecastModel ExcessModel { get; set; }

        public ForecastModelType ExcessModelType { get; set; }

        public bool UsedAllActualCount { get; set; }

        public bool SelectRules { get; set; }

        public bool ExcessManual;

        public SongForecastModel(FuzzyTimeSeries fts, int order, int forecastCount, int actualCount, bool useAll, ForecastModelType excessModelType, bool excessManual, bool selectRules)
        {
            ExtraForecastCount = forecastCount;
            FTS = fts;
            ActualCount = actualCount;
            ExcessModelType = excessModelType;

            ExcessManual = excessManual;
            SelectRules = selectRules;

            UsedAllActualCount = useAll;

            Remake(order);
            Name = "S Модель";
        }

        public void Remake(ACLTimeSeries aclTimeSeries)
        {
            ACLSeries = aclTimeSeries;
            Remake(order);
        }

        public void Remake(int _order)
        {
            order = _order;

            if (order <= 0)
                order = 1;

            mfs = new MamdaniFuzzySystem();
            RulesMap = new Dictionary<string, List<MamdaniFuzzyRule>>();
            RulesCounts = new Dictionary<string, int>();
            ConditionMap = new Dictionary<string, List<MamdaniFuzzyRule>>();

            MakeModel();
        }

        public static int RulesIndexOf(IList<MamdaniFuzzyRule> rulesList, MamdaniFuzzyRule rule)
        {
            for (int i = 0; i < rulesList.Count; i++)
            {
                var fuzzyRule = rulesList[i];
                if (fuzzyRule.IsEqual(rule))
                    return i;
            }
            return -1;
        }

        private void MakeModel()
        {
            //количество точек, исп для обучения
            var actualCount = UsedAllActualCount ? Actual.Count : ActualCount;

            if (actualCount == 0)
                return;

            mfs.SelectionRulesBound = FTS.Scale.CrossPoint;

            fvInputs = new List<FuzzyVariable>();

            for (int i = 0; i < order; i++)
            {
                var fvInput = new FuzzyVariable("Input" + i, FTS.Scale.Min, FTS.Scale.Max);
                foreach (FuzzyTerm ft in FTS.Scale.Grades.Terms)
                {
                    fvInput.Terms.Add(ft);
                }
                fvInputs.Add(fvInput);
            }

            fvOutput = new FuzzyVariable("Output", FTS.Scale.Min, FTS.Scale.Max);

            foreach (FuzzyTerm ft in FTS.Scale.Grades.Terms)
            {
                fvOutput.Terms.Add(ft);
            }

            mfs.Input.AddRange(fvInputs);
            mfs.Output.Add(fvOutput);

            for (int i = order; i < actualCount; i++)
            {
                MamdaniFuzzyRule rule = mfs.EmptyRule();
                rule.Condition.Op = OperatorType.And;

                double minMF = 1;
                for (int j = 0; j < order; j++)
                {
                    minMF = Math.Min(FTS.FTSPoints[i + j - order].MF, minMF);
                    FuzzyCondition fc = rule.CreateCondition(fvInputs[j], FTS.FuzzySeries[i + j - order]);
                    rule.Condition.ConditionsList.Add(fc);
                }

                rule.Conclusion.Term = FTS.FuzzySeries[i];
                rule.Conclusion.Var = fvOutput;

                //принадлежность правил, нужна для отбора повторяющихся правил
                rule.MF = Math.Min(FTS.FTSPoints[i].MF, minMF);

                string conditionString = rule.Condition.ToString();
                if (ConditionMap.ContainsKey(conditionString))
                {
                    var list = ConditionMap[conditionString];
                    if (RulesIndexOf(list, rule) < 0)
                    {
                        list.Add(rule);
                        mfs.Rules.Add(rule);
                    }
                }
                else
                {
                    var ruleList = new List<MamdaniFuzzyRule> { rule };
                    ConditionMap.Add(conditionString, ruleList);
                    mfs.Rules.Add(rule);
                }

                string ruleString = rule.ToString();
                if (RulesMap.ContainsKey(ruleString))
                {
                    RulesCounts[ruleString]++;
                    var list = RulesMap[ruleString];
                    if (RulesIndexOf(list, rule) < 0)
                    {
                        list.Add(rule);
                    }
                }
                else
                {
                    var ruleList = new List<MamdaniFuzzyRule> { rule };
                    RulesMap.Add(ruleString, ruleList);
                    RulesCounts.Add(ruleString, 1);
                }
            }
            if (SelectRules)
            {
                mfs.ConditionMap = ConditionMap;
            }
            if (ExcessModelType != ForecastModelType.None)
            {
                ExcessModel = new ExcessForecastModel(this, ExcessModelType, ExcessManual);
            }
        }

        public SPointList GetForecastSeries(bool ignoreExcessModel)
        {
            return ForecastHelper.GetForecastSeries(this, ignoreExcessModel);
        }

        public SPointList GetForecastSeries()
        {
            return ForecastHelper.GetForecastSeries(this, false);
        }

        public List<CompositeMembershipFunction> GetForecastSeriesFuzzy()
        {
            var list = new List<CompositeMembershipFunction>();
            ForecastHelper.GetForecastSeries(this, this, list, false);
            return list;
        }

        public List<string> GetStringResult()
        {
            return ForecastHelper.GetForecastSeries(GetForecastSeriesFuzzy(), FTS.Scale);
        }

        public List<FuzzyTerm> GetFuzzyForecastSeries()
        {
            var list = ForecastHelper.GetForecastFSeries(GetForecastSeriesFuzzy(), FTS.Scale);
            for (int i = 0; i < Order; i++)
            {
                list.Insert(i, ActualFuzzy[i]);
            }
            return list;
        }

        public double ForecastNextPoint(double[] inputs)
        {
            var mf = ForecastNextPointFuzzy(inputs);
            return mfs.Defuzzify(mf, fvOutput);
        }

        public CompositeMembershipFunction ForecastNextPointFuzzy(double[] inputs)
        {
            var inputValues = new Dictionary<FuzzyVariable, double>();
            for (int i = 0; i < order; i++)
            {
                var input = fvInputs[i].GetCorrectValue(inputs[i]);
                inputValues.Add(fvInputs[i], input);
            }
            var result = mfs.CalculateFuzzy(inputValues)[fvOutput];
            return result as CompositeMembershipFunction;
        }

        public void FillCrispRows(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillCrispRowsBase(ACLSeries, aclForecast, report);
        }

        public void FillFuzzyRows(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillFuzzyRowsBase(ACLSeries, aclForecast, report);

            var stringResult = GetStringResult();

            for (int i = 0; i < Actual.Count; i++)
            {
                var row = report.ResultFuzzy[i];

                row.ModelFT = i >= Order ? stringResult[i - Order] : "не вычисляется";
            }
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
            report.FErrors = ModelResult.GetFuzzyErrors(ACLSeries, aclForecast, ActualCount, Order);
            report.RuleSeries = ModelResult.GetRules(RulesCounts);
            report.RuleMFSeries = ModelResult.GetRules(Rules);
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
            report.FErrors = ModelResult.GetFuzzyErrors(ACLSeries, aclForecast, ActualCount, Order);
            report.RuleSeries = ModelResult.GetRules(RulesCounts);
            report.RuleMFSeries = ModelResult.GetRules(Rules);
            report.ModelInfo = ModelInfo;
            report.ACLInfo = ACLSeries.Scale.ScaleInfo;
            return report;
        }
    }


}
