using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FuzzyLibrary;

namespace FuzzyForecast
{
    public class ForecastHelper
    {

        public static string GetExtModelName(IForecastModel model)
        {
            return model.Name + "(" + model.Order + ", " + model.ActualCount + ")";
        }

        public static int GetActualCount(int count, double splitPercent)
        {
            double fraction = (100.0 - splitPercent) / 100;
            var actualCount = (int)Math.Floor(fraction * count);
            return actualCount;
        }

        public static int GetExternalCount(int count, double splitPercent)
        {
            return count - GetActualCount(count, splitPercent);
        }

        public static double GetSplitPercent(int count, int actualCount)
        {
            return 100.0 - ((double)actualCount) / count * 100.0;
        }

        public static SPointList GetExternalPoints(SPointList spl, int aCount)
        {
            var points = new SPointList { Name = spl.Name + " Ext", XName = spl.XName, YName = spl.YName };
            for (int i = aCount; i < spl.Count; i++)
            {
                points.Add(spl[i].Clone());
            }
            return points;
        }

        public static SPointList GetInternalPoints(SPointList spl, int aCount)
        {
            var points = new SPointList { Name = spl.Name + " Int", XName = spl.XName, YName = spl.YName };
            for (int i = 0; i < aCount; i++)
            {
                points.Add(spl[i].Clone());
            }
            return points;
        }

        public static List<T> GetExternal<T>(List<T> list, int aCount)
        {
            var newList = new List<T>();
            for (int i = aCount; i < list.Count; i++)
            {
                newList.Add(list[i]);
            }
            return newList;
        }

        public static List<T> GetInternal<T>(List<T> list, int aCount)
        {
            var newList = new List<T>();
            for (int i = 0; i < aCount; i++)
            {
                newList.Add(list[i]);
            }
            return newList;
        }


        public static SPointList GetForecastSeries(IForecastModel model, bool ignoreExcess)
        {
            return GetForecastSeries(model, null, null, ignoreExcess);
        }

        public static List<string> GetForecastSeries(List<CompositeMembershipFunction> forecastList, FuzzyScale fs)
        {
            var strings = new List<string>();
            foreach (var mf in forecastList)
            {
                strings.Add(fs.GetStringResult(mf));
            }
            return strings;
        }

        public static List<FuzzyTerm> GetForecastFSeries(List<CompositeMembershipFunction> forecastList, FuzzyScale fs)
        {
            var result = new List<FuzzyTerm>();
            foreach (var mf in forecastList)
            {
                result.Add(fs.GetTermByMF(mf));
            }
            return result;
        }

        public static double[] GetInputValues(IForecastModel model, int step, List<double> forecast)
        {
            var order = model.Order;
            var actual = model.Actual;
            var actualCount = model.ActualCount;

            var inputValues = new double[order];
            if (step < actualCount)
            {
                for (int j = 0; j < order; j++)
                {
                    inputValues[j] = actual[j + step - order].Y;
                }
                return inputValues;
            }
            for (int j = 0; j < order; j++)
            {
                int index = j + step - order;
                inputValues[j] = index < actualCount ? actual[index].Y : forecast[index];
            }
            return inputValues;
        }

        public static T[] GetInputValues<T>(IBaseForecastModel<T> model, int step, List<T> forecast, int order)
        {
            var actual = model.ActualList;
            var actualCount = model.ActualCount;

            var inputValues = new T[order];
            if (step < actualCount)
            {
                for (int j = 0; j < order; j++)
                {
                    inputValues[j] = actual[j + step - order];
                }
                return inputValues;
            }
            for (int j = 0; j < order; j++)
            {
                int index = j + step - order;
                inputValues[j] = index < actualCount ? actual[index] : forecast[index];
            }
            return inputValues;
        }

        public static List<T> GetForecastList<T>(IBaseForecastModel<T> model, int order)
        {
            var forecast = new List<T>();

            var forecastCount = model.ExtraForecastCount;
            var actual = model.ActualList;
            var actualCount = model.ActualCount;

            for (int i = 0; i < order; i++)
            {
                forecast.Add(actual[i]);
            }

            int current = order;

            for (int i = order; i < actualCount; i++)
            {
                var inputValues = GetInputValues(model, current, forecast, order);

                T nextPoint = model.ForecastNextPoint(inputValues);
                forecast.Add(nextPoint);

                current++;
            }

            int totalFCount = forecastCount + actual.Count - actualCount;

            for (int i = 0; i < totalFCount; i++)
            {
                var inputValues = GetInputValues(model, current, forecast, order);

                T nextPoint = model.ForecastNextPoint(inputValues);
                forecast.Add(nextPoint);

                current++;
            }
            return forecast;
        }

        public static SPointList GetForecastSeries(IForecastModel model, IFuzzyForecastModel fModel, List<CompositeMembershipFunction> forecastList, bool ignoreExcess)
        {
            var order = model.Order;
            var forecastCount = model.ExtraForecastCount;
            var actual = model.Actual;

            var actualCount = model.ActualCount;

            var forecastPointList = new SPointList { Name = actual.Name + " (" + model.Name + ")", XName = actual.XName, YName = actual.YName };
            var forecast = new List<double>();
            var excessForecast = new List<double>();

            if (forecastList != null)
                forecastList.Clear();

            for (int i = 0; i < order; i++)
            {
                forecastPointList.Add(actual[i].Clone());
                forecast.Add(actual[i].Y);
            }

            if (model.ExcessModelType != ForecastModelType.None && !ignoreExcess)
            {
                for (int i = 0; i < model.ExcessModel.ExcessModel.Order; i++)
                {
                    excessForecast.Add(0);
                }
            }

            int current = order;
            int eCurrent = current;
            if (model.ExcessModelType != ForecastModelType.None && !ignoreExcess)
            {
                eCurrent = model.ExcessModel.ExcessModel.Order;
            }
            for (int i = order; i < actualCount; i++)
            {
                //var inputValues = new double[order];
                //for (int j = 0; j < order; j++) {
                //  inputValues[j] = actual[j + i - order].Y;
                //}
                var inputValues = GetInputValues(model, current, forecast);

                var excess = 0.0;
                if (model.ExcessModelType != ForecastModelType.None && !ignoreExcess)
                {
                    excess = model.ExcessModel.ForecastNextExcess(GetInputValues(model.ExcessModel.ExcessModel, eCurrent, excessForecast));
                    excessForecast.Add(excess);
                }

                double nextPoint = model.ForecastNextPoint(inputValues) - excess;

                forecastPointList.Add(new SPoint(actual[i].X, nextPoint));
                forecast.Add(nextPoint);

                current++;
                eCurrent++;
                // нечеткий результат, если есть
                var nextFuzzy = fModel != null ? fModel.ForecastNextPointFuzzy(inputValues) : null;
                if (forecastList != null)
                {
                    forecastList.Add(nextFuzzy);
                }
            }

            //предсказываем на несколько значений вперед
            double step = actual[1].X - actual[0].X;
            double xValue = actual[actualCount - 1].X;

            int totalFCount = forecastCount + actual.Count - actualCount;

            for (int i = 0; i < totalFCount; i++)
            {
                //var inputValues = new double[order];
                //for (int j = 0; j < order; j++) {
                //  int index = actualCount + j + i - order;
                //  inputValues[j] = index < actualCount ? actual[index].Y : forecastPointList[index].Y;
                //}
                var inputValues = GetInputValues(model, current, forecast);

                var excess = 0.0;
                if (model.ExcessModelType != ForecastModelType.None && !ignoreExcess)
                {
                    excess = model.ExcessModel.ForecastNextExcess(GetInputValues(model.ExcessModel.ExcessModel, eCurrent, excessForecast));
                    excessForecast.Add(excess);
                }

                double nextPoint = model.ForecastNextPoint(inputValues) - excess;
                xValue += step;

                forecastPointList.Add(new SPoint(xValue, nextPoint));
                forecast.Add(nextPoint);

                current++;
                eCurrent++;
                // нечеткий результат, если есть
                var nextFuzzy = fModel != null ? fModel.ForecastNextPointFuzzy(inputValues) : null;
                if (forecastList != null)
                {
                    forecastList.Add(nextFuzzy);
                }
            }
            //TODO:Расчет значений для графика
            return forecastPointList;
        }
    }

    public class ExcessForecastModel
    {
        public IForecastModel BaseModel;
        public SPointList ExcessList;
        public IForecastModel ExcessModel;
        public ForecastModelType modelType;

        public ExcessForecastModel(IForecastModel baseModel, ForecastModelType type, bool ManualSetting)
        {
            BaseModel = baseModel;
            modelType = type;
            MakeExcessModel(ManualSetting);
        }

        public static ACLTimeSeries GetACLSeries(SPointList pointList, bool getDefault)
        {
            var asf = new ACLSettingsForm(pointList);
            if (!getDefault)
            {
                asf.Text += " - Модель остатков";
                if (asf.ShowDialog() != DialogResult.OK)
                    return null;
            }
            var ats = asf.ACLSeries;
            return ats;
        }

        private void SetSongModel(bool defaultModel)
        {
            var aclSeries = GetACLSeries(ExcessList, defaultModel);
            var ssf = new ModelSettingForm(ExcessList.Count, typeof(SongForecastModel));
            ssf.Text += " - Модель остатков";

            var model = ExcessModel as SongForecastModel == null
                          ?
                            new SongForecastModel(aclSeries.FTS, 2, 0, BaseModel.ActualCount, BaseModel.UsedAllActualCount,
                                                  ForecastModelType.None, false,
                                                  true)
                          : (SongForecastModel)ExcessModel;

            ssf.Set(model);
            if (!defaultModel)
            {
                if (ssf.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            ExcessModel = ssf.GetSongModel(aclSeries.FTS);
        }

        private void SetDModel(bool defaultModel)
        {
            var aclSeries = GetACLSeries(ExcessList, defaultModel);
            var ssf = new ModelSettingForm(ExcessList.Count, typeof(DForecastModel));
            ssf.Text += " - Модель остатков";

            var model = ExcessModel as DForecastModel == null
                          ?
                            new DForecastModel(aclSeries, 2, 0, BaseModel.ActualCount, BaseModel.UsedAllActualCount,
                                                  ForecastModelType.None, false,
                                                  true)
                          : (DForecastModel)ExcessModel;

            ssf.Set(model);
            if (!defaultModel)
            {
                if (ssf.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            ExcessModel = ssf.GetDModel(aclSeries);
        }

        private void SetNeuralModel(bool defaultModel)
        {
            var nsf = new NeuralSettingForm(ExcessList.Count);
            nsf.Text += " - Модель остатков";

            var model = ExcessModel as NeuralForecastModel == null
                          ?
                            new NeuralForecastModel(ExcessList, 2, 5, 0, BaseModel.ActualCount, BaseModel.UsedAllActualCount, ForecastModelType.None, false, true)
                          : (NeuralForecastModel)ExcessModel;

            nsf.Set(model);
            if (!defaultModel)
            {
                if (nsf.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            ExcessModel = nsf.GetNModel(ExcessList);
        }

        private void SetTendModel(bool defaultModel)
        {
            var aclSeries = GetACLSeries(ExcessList, defaultModel);
            var ssf = new ModelSettingForm(ExcessList.Count, typeof(TendForecastModel));
            ssf.Text += " - Модель остатков";
            var model = ExcessModel as TendForecastModel == null
                          ?
                            new TendForecastModel(aclSeries, 3, 0, BaseModel.ActualCount, BaseModel.UsedAllActualCount,
                                                  ForecastModelType.None, false,
                                                  true)
                          : (TendForecastModel)ExcessModel;

            ssf.Set(model);
            if (!defaultModel)
            {
                if (ssf.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            ExcessModel = ssf.GetTendModel(aclSeries); ;
        }

        public void SetModel(bool defaultModel)
        {
            switch (modelType)
            {
                case ForecastModelType.None:
                    break;
                case ForecastModelType.Song:
                    SetSongModel(defaultModel);
                    break;
                case ForecastModelType.Neural:
                    SetNeuralModel(defaultModel);
                    break;
                case ForecastModelType.D:
                    SetDModel(defaultModel);
                    break;
                case ForecastModelType.Tend:
                    SetTendModel(defaultModel);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void MakeExcessModel(bool ManualSetting)
        {
            ExcessList = new SPointList();
            var baseForecast = BaseModel.GetForecastSeries(true);
            //var iActual = ForecastHelper.GetInternalPoints(BaseModel.Actual, BaseModel.ActualCount);
            //var iForecast = ForecastHelper.GetInternalPoints(baseForecast, BaseModel.ActualCount);
            for (int i = 0; i < BaseModel.Actual.Count; i++)
            {
                double excess = baseForecast[i].Y - BaseModel.Actual[i].Y;
                ExcessList.Add(new SPoint(BaseModel.Actual[i].X, excess));
            }
            SetModel(!ManualSetting);
        }

        public double ForecastNextExcess(double[] input)
        {
            return ExcessModel.ForecastNextPoint(input);
        }
    }
}
