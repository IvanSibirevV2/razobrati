using System;
using System.Collections.Generic;
using FuzzyLibrary;

namespace FuzzyForecast {


  public class FTSPoint {
    public SPoint point;
    public FuzzyTerm Term;
    public double MF;
    public int Index;
    public double Mean;
    public Dictionary<int, double> Indexes;

    public FTSPoint() {
    }

    public FTSPoint(FuzzyScale scale, SPoint crisp) {
      point = crisp.Clone();
      Index = scale.GetTermIndexWithMaxMF(point.Y);
      Term = scale.Grades.Terms[Index];
      Indexes = scale.GetIndexesByX(point.Y);
      Mean = GenericFuzzySystem.Defuzzify(DefuzzificationMethod.Centroid,
                                          Term.MembershipFunction, scale.Min, scale.Max);
      MF = Term.MembershipFunction.GetValue(point.Y);
    }
  }

  public class FuzzyTimeSeries {
    /// <summary>
    /// Нечеткая шакала для временного ряда
    /// </summary>
    public FuzzyScale Scale;

    /// <summary>
    /// Четкие значения для нечеткого временного ряда??
    /// по идее, они могут отсутствовать
    /// </summary>
    public SPointList PointList;

    /// <summary>
    /// Принадлежность
    /// </summary>
    public SPointList MF;

    /// <summary>
    /// Ряд нечетких термов
    /// </summary>
    public List<FuzzyTerm> FuzzySeries = new List<FuzzyTerm>();

    /// <summary>
    /// Ряд индексов нечетких термов
    /// </summary>
    public List<int> IndexSeries = new List<int>();


    /// <summary>
    /// Ряд середин нечетких термов
    /// </summary>
    public List<double> MeanSeries = new List<double>();

    public List<FTSPoint> FTSPoints = new List<FTSPoint>();

    public FuzzyTimeSeries(FuzzyScale scale, SPointList pointList) {
      Scale = scale;
      PointList = pointList;
      Fuzzify();
    }

    /// <summary>
    /// Фазифицировать ряд. Нечетким значением будет терм с макс. ф.п. (Так у Сонга)
    /// По идее, значением должно быть объединение всех термов с положит ф.п.
    /// </summary>
    public void Fuzzify() {
      FuzzySeries = new List<FuzzyTerm>();
      IndexSeries = new List<int>();
      MeanSeries = new List<double>();
      MF = new SPointList { Name = "Принадлежность", YName = "Значение ФП", XName = PointList.XName };
      FTSPoints = new List<FTSPoint>();

      foreach (SPoint pt in PointList) {
        var ftsPoint = new FTSPoint(Scale, pt);
        FTSPoints.Add(ftsPoint);
        FuzzySeries.Add(ftsPoint.Term);
        IndexSeries.Add(ftsPoint.Index);
        MeanSeries.Add(ftsPoint.Mean);
        MF.Add(new SPoint(pt.X, ftsPoint.MF));
      }
    }

    public double GetMean(int index) {
      if (index < 0 || index >= FuzzySeries.Count) {
        throw new ArgumentException();
      }
      return GenericFuzzySystem.Defuzzify(DefuzzificationMethod.Centroid,
        FuzzySeries[index].MembershipFunction, Scale.Min, Scale.Max);
    }


  }
}
