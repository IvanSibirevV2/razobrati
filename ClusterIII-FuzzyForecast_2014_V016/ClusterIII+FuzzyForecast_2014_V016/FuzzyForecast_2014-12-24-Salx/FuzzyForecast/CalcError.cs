using System;
using FuzzyLibrary;

namespace FuzzyForecast {
  /// <summary>
  /// Расчет ошибок предсказания
  /// </summary>
  public class Calc {
    /// <summary>
    /// Расчет средней квадратичной ошибки (Mean-Square Error)
    /// </summary>
    /// <param name="actual"></param>
    /// <param name="forecast"></param>
    /// <param name="omitCount"></param>
    /// <returns>MSE</returns>
    public static double MSE(SPointList actual, SPointList forecast, int omitCount) {
      return (SSE(actual, forecast, omitCount) / (actual.Count - omitCount));
    }

    /// <summary>
    /// Расчет квадратного корня средней квадратичной ошибки (Root Mean-Square Error)
    /// </summary>
    /// <param name="actual"></param>
    /// <param name="forecast"></param>
    /// <param name="omitCount"></param>
    /// <returns></returns>
    public static double RMSE(SPointList actual, SPointList forecast, int omitCount) {
      return Math.Sqrt(MSE(actual, forecast, omitCount));
    }

    /// <summary>
    /// Расчет Average Forecasting Error (MAPE)
    /// </summary>
    /// <param name="actual"></param>
    /// <param name="forecast"></param>
    /// <param name="omitCount"></param>
    /// <returns>MAPE</returns>
    public static double MAPE(SPointList actual, SPointList forecast, int omitCount) {
      if (forecast.Count < actual.Count) {
        return -1;
      }

      double result = 0.0d;

      int zeroCount = 0;
      for (int i = omitCount; i < actual.Count; i++) {
        if (Math.Abs(actual[i].Y) >= 0.00000001) {
          result += Math.Abs((forecast[i].Y - actual[i].Y)/actual[i].Y);
        } else {
          zeroCount++;
        }
      }

      return (result/(actual.Count - omitCount - zeroCount))*100;
    }

    /// <summary>
    /// Расчет суммы квадратов ошибок (Sum of Square Errors)
    /// </summary>
    /// <param name="actual"></param>
    /// <param name="forecast"></param>
    /// <param name="omitCount"></param>
    /// <returns>SSE</returns>
    public static double SSE(SPointList actual, SPointList forecast, int omitCount) {
      if (forecast.Count < actual.Count) {
        return -1;
      }

      double result = 0.0d;

      for (int i = omitCount; i < actual.Count; i++) {
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
    public static double Average(SPointList points, int omitCount) {
      double averageValue = 0;

      for (int i = omitCount; i < points.Count; i++) {
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
    public static double SST(SPointList actual, int omitCount) {
      double averageValue = Average(actual, omitCount);

      double result = 0.0d;

      for (int i = omitCount; i < actual.Count; i++) {
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
    public static double SSR(SPointList actual, SPointList forecast, int omitCount) {
      double averageValue = Average(actual, omitCount);

      double result = 0.0d;

      for (int i = omitCount; i < forecast.Count; i++) {
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
    public static double R2(SPointList actual, SPointList forecast, int omitCount) {
      return 1 - SSE(actual, forecast, omitCount) / SST(actual, omitCount);
      //return SSR(actual, forecast, omitCount) / SST(actual, omitCount);
    }

    /// <summary>
    /// Расчет дисперсии по генеральной совокупности
    /// </summary>
    /// <param name="points">точки</param>
    /// <returns>Dispersion</returns>
    public static double Dispersion(SPointList points) {
      var sst = SST(points, 0);
      return sst / points.Count;
    }

    /// <summary>
    /// Расчет количества нечетких множеств
    /// </summary>
    /// <param name="pointList">временной ряд - ряд четких значений</param>
    /// <param name="error">значение ошибки</param>
    /// <returns>количество нечетких множеств</returns>
    public static int CountMF(SPointList pointList, double error) {
      double sum = 0.0d;

      int zeroCount = 0;
      for (int i = 0; i < pointList.Count; i++) {
        if (Math.Abs(pointList[i].Y) >= 0.00000001) {
          sum += Math.Abs(1 / pointList[i].Y);
        } else {
          zeroCount++;
        }
      }

      double max = pointList.FindMax().Y;
      double min = pointList.FindMin().Y;

      var numerator = 0.5 * (max - min) * sum;
      var denominator = (pointList.Count - zeroCount) * error;
      var result = numerator / denominator;

      return (int) Math.Ceiling(result);
    }
  }
}
