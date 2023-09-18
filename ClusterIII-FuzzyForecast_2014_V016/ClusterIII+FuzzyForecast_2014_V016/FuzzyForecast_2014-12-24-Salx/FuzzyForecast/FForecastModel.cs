using System;
using System.Collections.Generic;
using System.Text;
using FuzzyLibrary;

namespace FuzzyForecast
{
    public class FForecastModel : IForecastModel
    {
        public ACLTimeSeries ACLSeries;
        private double scale;
        SPointList res = new SPointList();
        //*****************************
        List<List<double>> A = new List<List<double>>();
        List<double> F = new List<double>();
        List<double> f = new List<double>();

        public

            FForecastModel(ModelSeries ats, double scale)
        {
            ACLSeries = ats.ACLSeries;
            this.scale = scale;
            //Заглушки
            Order = 1;
            Name = "F Модель";
            //Глубина прогноза
            ExtraForecastCount = 0;
            //Количество точек для прогноза 
            ActualCount = ACLSeries.FTS.PointList.Count;
            //Использовать все точки для прогноза
            UsedAllActualCount = true;
            ExcessModelType = ForecastModelType.F;
            //*******************************************
            FillBasicFunction();
        }

        protected void FillBasicFunction()
        {
            //Вычисляем длинну временной оси
            double width = Math.Abs(ACLSeries.FTS.PointList[ActualCount - 1].X - ACLSeries.FTS.PointList[0].X);
            //Вычисляем половину области определения базисной функции
            double halfScale = scale / 2;
            //Вычисляем количество базисных функций
            int basicFuncCount = (width % halfScale) >= 1.0 ? (int)(width / halfScale) + 2 : (int)(width / halfScale) + 1;
            //Вычисляем базовые функции. Для каждой базисной функции...
            for (int i = 0; i < basicFuncCount; i++)
            {
                //...мы создаём массив, в котором будут храниться временные результаты
                List<double> row = new List<double>();
                //Для каждой точки исходного временного ряда вычисляем значение треугольной базисной функции
                for (int j = 0; j < ActualCount; j++)
                {
                    //Так как первая базисная функция является половиной треугольника, описываем её отдельно
                    if (i == 0)
                    {
                        if (ACLSeries.FTS.PointList[j].X <= halfScale + ACLSeries.FTS.PointList[0].X)
                            row.Add(1.0 - (ACLSeries.FTS.PointList[j].X - ACLSeries.FTS.PointList[0].X) / halfScale);
                        else
                            row.Add(0.0);
                    }
                    else
                    {
                        double x1 = ((double)(i - 1)) * (halfScale) + ACLSeries.FTS.PointList[0].X;
                        double x2 = ((double)(i)) * (halfScale) + ACLSeries.FTS.PointList[0].X;
                        double x3 = ((double)(i + 1)) * (halfScale) + ACLSeries.FTS.PointList[0].X;
                        if (ACLSeries.FTS.PointList[j].X >= x1 && ACLSeries.FTS.PointList[j].X <= x2)
                            row.Add((ACLSeries.FTS.PointList[j].X - x1) / halfScale);
                        else if (ACLSeries.FTS.PointList[j].X > x2 && ACLSeries.FTS.PointList[j].X <= x3)
                            row.Add(1.0 - (ACLSeries.FTS.PointList[j].X - x2) / halfScale);
                        else
                            row.Add(0.0);
                    }
                }
                //Записываем полученный результат в массив базисных функций
                A.Add(row);
            }
            //Вычисляем F функции
            for (int i = 0; i < basicFuncCount; i++)
            {
                double a = 0;
                double b = 0;
                for (int j = 0; j < ActualCount; j++)
                {
                    a += ACLSeries.FTS.PointList[j].Y * A[i][j];
                    b += A[i][j];
                }
                F.Add(a / b);
            }

            //Вычисляем f функции
            for (int i = 0; i < ActualCount; i++)
            {
                double a = 0;
                for (int j = 0; j < basicFuncCount; j++)
                {
                    a += F[j] * A[j][i];
                }
                f.Add(a);
            }
            //Записываем результат
            for (int i = 0; i < ActualCount; i++)
            {
                res.Add(new SPoint(ACLSeries.FTS.PointList[i].X, f[i]));
            }
        }
        public void delta()
        {
            ExcessModelType = ForecastModelType._F;
            var _res = new SPointList();
            for (int i = 0; i < this.Actual.Count; i++)
            {
                _res.Add(new SPoint() { X = i + 1, Y = f[i] - Actual[i].Y });
            }
            res = _res;
        }

        public bool UsedAllActualCount { get; set; }
        public int Order { get; set; }
        public int ExtraForecastCount { get; set; }
        public int ActualCount { get; set; }
        public string Name { get; private set; }
        public string ModelInfo { get; set; }
        public string ModelInfoFlat { get; set; }
        public ForecastModelType ExcessModelType { get; set; }
        public SPointList Actual { get { return ACLSeries.FTS.PointList; } }
        public ExcessForecastModel ExcessModel { get; set; }
        public bool UseFTransform { get; set; }

        public SPointList GetForecastSeries(bool ignoreExcessModel)
        {
            return GetForecastSeries();
        }
        public SPointList GetForecastSeries()
        {
            return res;
        }
        public double ForecastNextPoint(double[] inputs) { return 10.0; }

        //#warning F - ЗАГЛУШКА!!!
        public void FillCrispRows(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillCrispRowsBase(ACLSeries, aclForecast, report);
        }

        public void FillFuzzyRows(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillFuzzyRowsBase(ACLSeries, aclForecast, report);

            for (int i = 0; i < Actual.Count; i++)
            {
                var row = report.ResultFuzzy[i];

                row.ModelFT = "не вычисляется";
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
            report.ModelInfo = ModelInfo;
            report.ACLInfo = ACLSeries.Scale.ScaleInfo;
            return report;
        }
    }
}
