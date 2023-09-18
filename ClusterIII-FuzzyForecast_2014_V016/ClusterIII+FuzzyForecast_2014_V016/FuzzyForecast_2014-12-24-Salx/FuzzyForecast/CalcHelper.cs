using System;
using System.Collections.Generic;
using FuzzyLibrary;

namespace FuzzyForecast
{
    /// <summary>
    /// Расчет ошибок предсказания
    /// </summary>
    public class Calc
    {
        // формат вывода вещественных чисел
        public const string DFormat = "G";

        // экспоненциальная запись
        public const string EFormat = "E";

        //уровень нуля
        public const double Zero = 0.00000001;

        /// <summary>
        /// проверка, является ли нулем
        /// </summary>
        /// <param name="val">проверяемое число</param>
        /// <returns>правда, если ноль</returns>
        public static bool IsZero(double val)
        {
            return Math.Abs(val) < Zero;
        }

        /// <summary>
        /// сравнение двух чисел double
        /// </summary>
        /// <param name="var1">первое число</param>
        /// <param name="var2">второе чилсло</param>
        /// <returns>результат сравнения</returns>
        public static int Compare(double var1, double var2)
        {
            var diff = var1 - var2;
            if (IsZero(diff))
                return 0;
            if (diff > 0)
                return 1;
            return -1;
        }

        /// <summary>
        /// проверка на равенство
        /// </summary>
        /// <param name="var1">первое число</param>
        /// <param name="var2">второе число</param>
        /// <returns>правда, если равны</returns>
        public static bool Equal(double var1, double var2)
        {
            return Compare(var1, var2) == 0;
        }

        /// <summary>
        /// Расчет выбросов
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="forecast"></param>
        /// <param name="omitCount"></param>
        /// <returns>D</returns>
        public static double D(SPointList actual, SPointList forecast, int omitCount)
        {
            int pointsCount = actual.Count;
            int actualValidatedPoints = 0;
            for (int i = 0; i < pointsCount; i++)
            {
                double crisp = Math.Abs(Convert.ToDouble(actual[i].Y - forecast[i].Y));
                double middle = ACLSettingsForm.D;
                if (middle <= crisp)
                {
                    actualValidatedPoints++;
                }
            }
            return (1.0 * actualValidatedPoints) / (1.0 * pointsCount);
        }
        /// <summary>
        /// Расчет дисперсии выбросов
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="forecast"></param>
        /// <param name="omitCount"></param>
        /// <returns>DS</returns>
        public static double DS(SPointList actual, SPointList forecast, int omitCount)
        {
            int pointsCount = actual.Count;
            double actualVPScuare = 0.0;
            double actualDiff = 0.0;
            for (int i = 0; i < pointsCount; i++)
            {
                double crisp = Math.Abs(Convert.ToDouble(actual[i].Y - forecast[i].Y));
                double middle = ACLSettingsForm.D;
                if (middle >= crisp)
                {
                    if (middle - crisp > 0)
                        actualVPScuare += Math.Pow(middle - crisp, 2);
                }
            }
            actualDiff = Math.Sqrt(actualVPScuare / pointsCount);
            return actualDiff;
        }
        /// <summary>
        /// Расчет средней квадратичной ошибки (Mean-Square Error)
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="forecast"></param>
        /// <param name="omitCount"></param>
        /// <returns>MSE</returns>
        public static double MSE(SPointList actual, SPointList forecast, int omitCount)
        {
            return (SSE(actual, forecast, omitCount) / (actual.Count - omitCount));
        }

        /// <summary>
        /// Расчет квадратного корня средней квадратичной ошибки (Root Mean-Square Error)
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="forecast"></param>
        /// <param name="omitCount"></param>
        /// <returns></returns>
        public static double RMSE(SPointList actual, SPointList forecast, int omitCount)
        {
            return Math.Sqrt(MSE(actual, forecast, omitCount));
        }

        /// <summary>
        /// Расчет Average Forecasting Error (MAPE)
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="forecast"></param>
        /// <param name="omitCount"></param>
        /// <returns>MAPE</returns>
        public static double MAPE_Сalculator(SPointList actual, SPointList forecast, int omitCount)
        {
            if (forecast.Count < actual.Count)
            {
                return -1;
            }
            double result = 0.0d;
            int zeroCount = 0;
            for (int i = omitCount; i < actual.Count; i++)
            {
                if (!IsZero(actual[i].Y))
                {
                    //TODO:вернуть определение mape
                    result += Math.Abs((forecast[i].Y - actual[i].Y) / actual[i].Y);
                    //TODO:SMAPE
                    //result += Math.Abs((forecast[i].Y - actual[i].Y) / ((forecast[i].Y - actual[i].Y) / 2));
                }
                else
                {
                    zeroCount++;
                }
            }
            return (result / (actual.Count - omitCount - zeroCount)) * 100;
        }

        /// <summary>
        /// Расчет (SMAPE)
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="forecast"></param>
        /// <param name="omitCount"></param>
        /// <returns>MAPE</returns>
        public static double SMAPE_Сalculator(SPointList actual, SPointList forecast, int omitCount)
        {
            if (forecast.Count < actual.Count)
                return -1;
            double result = 0.0d;
            int zeroCount = 0;
            for (int i = omitCount; i < actual.Count; i++)
                if (!IsZero(actual[i].Y))
                {
                    result += Math.Abs
                    (
                        (
                            forecast[i].Y - actual[i].Y
                        )
                        /
                        (
                            (
                                forecast[i].Y + actual[i].Y
                            )
                            /
                            2
                        )
                    );
                }
                else
                    zeroCount++;
            return (result / (actual.Count - omitCount - zeroCount)) * 100;
        }

        /// <summary>
        /// Расчет суммы квадратов ошибок (Sum of Square Errors)
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="forecast"></param>
        /// <param name="omitCount"></param>
        /// <returns>SSE</returns>
        public static double SSE(SPointList actual, SPointList forecast, int omitCount)
        {
            if (forecast.Count < actual.Count)
            {
                return -1;
            }

            double result = 0.0d;

            for (int i = omitCount; i < actual.Count; i++)
            {
                result += Math.Pow(forecast[i].Y - actual[i].Y, 2);
            }

            return result;
        }

        /// <summary>
        /// Расчет среднего арифметического
        /// </summary>
        /// <param name="points"></param>
        /// <param name="omitCount"></param>
        /// <returns>Average</returns>
        public static double Average(SPointList points, int omitCount)
        {
            double averageValue = 0;

            for (int i = omitCount; i < points.Count; i++)
            {
                averageValue += points[i].Y;
            }
            averageValue = averageValue / (points.Count - omitCount);

            return averageValue;
        }

        /// <summary>
        /// Расчет суммы квадратов отклонений от среднего (Sum of Square Totals)
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="omitCount"></param>
        /// <returns>SST</returns>
        public static double SST(SPointList actual, int omitCount)
        {
            double averageValue = Average(actual, omitCount);

            double result = 0.0d;

            for (int i = omitCount; i < actual.Count; i++)
            {
                result += Math.Pow(averageValue - actual[i].Y, 2);
            }

            return result;
        }

        /// <summary>
        /// Расчет суммы квадратов отклонений от среднего (Sum of Square Regression)
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="forecast"></param>
        /// <param name="omitCount"></param>
        /// <returns>SSR</returns>
        public static double SSR(SPointList actual, SPointList forecast, int omitCount)
        {
            double averageValue = Average(actual, omitCount);

            double result = 0.0d;

            for (int i = omitCount; i < forecast.Count; i++)
            {
                result += Math.Pow(averageValue - forecast[i].Y, 2);
            }

            return result;
        }


        /// <summary>
        /// Расчет коэффициента детерминации (ар-квадрат)
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="forecast"></param>
        /// <param name="omitCount"></param>
        /// <returns>R2</returns>
        public static double R2(SPointList actual, SPointList forecast, int omitCount)
        {
            return 1 - SSE(actual, forecast, omitCount) / SST(actual, omitCount);
            //return SSR(actual, forecast, omitCount) / SST(actual, omitCount);
        }

        /// <summary>
        /// Расчет дисперсии по генеральной совокупности
        /// </summary>
        /// <param name="points">точки</param>
        /// <returns>Dispersion</returns>
        public static double Dispersion(SPointList points)
        {
            var sst = SST(points, 0);
            return sst / points.Count;
        }

        /// <summary>
        /// Расчет количества нечетких множеств
        /// </summary>
        /// <param name="pointList">временной ряд - ряд четких значений</param>
        /// <param name="error">значение ошибки</param>
        /// <returns>количество нечетких множеств</returns>
        public static int CountMF(SPointList pointList, double error)
        {
            double sum = 0.0d;

            int zeroCount = 0;
            for (int i = 0; i < pointList.Count; i++)
            {
                if (!IsZero(pointList[i].Y))
                {
                    sum += Math.Abs(1 / pointList[i].Y);
                }
                else
                {
                    zeroCount++;
                }
            }

            double max = pointList.FindMax().Y;
            double min = pointList.FindMin().Y;

            var numerator = 0.5 * (max - min) * sum;
            var denominator = (pointList.Count - zeroCount) * error;
            var result = numerator / denominator;

            return (int)Math.Ceiling(result);
        }

        /// <summary>
        /// Расчет количества нечетких множеств
        /// </summary>
        /// <param name="pointList">временной ряд - ряд четких значений</param>
        /// <param name="error">значение ошибки</param>
        /// <returns>количество нечетких множеств</returns>
        public static int CountMFSimple(SPointList pointList, double error)
        {

            double max = pointList.FindMax().Y;
            double min = pointList.FindMin().Y;

            var sum = pointList.Count * (1 / ((max + min) / 2));

            var numerator = 0.5 * (max - min) * sum;
            var denominator = pointList.Count * error;
            var result = numerator / denominator;

            return (int)Math.Ceiling(result);
        }


        ///// <summary>
        ///// Количество ошибочных термов
        ///// </summary>
        ///// <param name="actual"></param>
        ///// <param name="forecast"></param>
        ///// <param name="omitCount"></param>
        ///// <returns></returns>
        //public static int CountErrors(List<FuzzyTerm> actual, List<FuzzyTerm> forecast, int omitCount) {
        //  if (forecast.Count < actual.Count) {
        //    return -1;
        //  }

        //  int result = 0;

        //  for (int i = omitCount; i < actual.Count; i++) {
        //    if (actual[i].Name != forecast[i].Name) {
        //      result++;
        //    }
        //  }
        //  return result;
        //}

        /// <summary>
        /// Количество ошибочных термов (для тенденции!)
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="forecast"></param>
        /// <param name="omitCount"></param>
        /// <returns></returns>
        public static double CountErrors(List<FuzzyTerm> actual, List<FuzzyTerm> forecast, int omitCount)
        {
            // расчитать количество ошибочных нечетких термов с учетом типа тенденции
            if (forecast.Count < actual.Count)
            {
                return -1;
            }

            double result = 0;

            //#warning заглушка
            for (int i = omitCount; i < actual.Count; i++)
            {
                if (actual[i].Name == forecast[i].Name)
                {
                    result += 0.0;
                }
                else if (actual[i].Name == "Стабильность" || forecast[i].Name == "Стабильность")
                {
                    result += 0.5;
                }
                else
                {
                    result += 1;
                }
            }

            return result;
        }

        /// <summary>
        /// Расчет ошибки в нечетких рядах
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="forecast"></param>
        /// <param name="omitCount"></param>
        /// <returns>доля ошибки</returns>
        public static double FuzzyPercentError(List<FuzzyTerm> actual, List<FuzzyTerm> forecast, int omitCount)
        {
            return ((double)CountErrors(actual, forecast, omitCount)) / (actual.Count - omitCount) * 100;
        }
    }
}
