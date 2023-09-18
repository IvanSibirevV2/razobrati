using System;
using System.Collections.Generic;
using FuzzyLibrary;

namespace FuzzyForecast {
  /// <summary>
  /// Нечеткий временной ряд
  /// </summary>
  public class ACLTimeSeries {

    /// <summary>
    /// ACL шкала для нечеткого временного ряда
    /// </summary>
    public ACLScale Scale;

    /// <summary>
    /// Нечеткий временной ряд
    /// </summary>
    public FuzzyTimeSeries FTS;

    /// <summary>
    /// Тенденции
    /// </summary>
    public List<FuzzyTend> Tends;

    /// <summary>
    /// Ряд разностей
    /// </summary>
    public SPointList DiffPointList; 

    /// <summary>
    /// Ряд разностей между индексами нечетких термов
    /// </summary>
    public List<int> DiffIndexList = new List<int>();

    /// <summary>
    /// Четкое значение максимальной разности (по абс. значению)
    /// </summary>
    public double MaxTendCrisp {
      get { return DiffPointList[DiffPointList.FindIndexAbsMax()].Y;  }
    }

    public List<FuzzyTerm> TTends { get; private set; }
    public List<FuzzyTerm> RTends { get; private set; }

    public ACLTimeSeries(ACLScale scale, SPointList pointList) 
      : this(scale, new FuzzyTimeSeries(scale.BaseScale, pointList)) {
    }

    public ACLTimeSeries(ACLScale scale, FuzzyTimeSeries fts) {
      Scale = scale;
      FTS = fts;
      MakeModel();
    }

    public void MakeModel() {
      FTS.Fuzzify();
      SetDiffLists();
      MakeTends();
    }

    /// <summary>
    /// Сформировать ряд разностей значений четкого временного ряда
    /// </summary>
    private void SetDiffLists() {
      if (FTS.PointList.Count == 0)
        return;

      DiffPointList = new SPointList {Name = "Ряд разностей", XName = FTS.PointList.XName, YName = "Разности"};

      //DiffPointList.Add(new SPoint(FTS.PointList[0].X, 0));
      //DiffIndexList = new List<int> { 0 };

      for (int i = 1; i < FTS.PointList.Count; i++) {
        var newPt = new SPoint(FTS.PointList[i].X, FTS.PointList[i].Y - FTS.PointList[i - 1].Y);
        int diff = FTS.IndexSeries[i] - FTS.IndexSeries[i - 1];
        DiffPointList.Add(newPt);
        DiffIndexList.Add(diff);
      }
    }


    //Сформировать тенденции
    private void MakeTends() {
      Tends = new List<FuzzyTend>();
      TTends = new List<FuzzyTerm>();
      RTends = new List<FuzzyTerm>();

      //Tends.Add(new FuzzyTend(Scale, null, FTS.FTSPoints[0]));
      for (int i = 1; i < FTS.FTSPoints.Count; i++) {
        var tend = new FuzzyTend(Scale, FTS.FTSPoints[i - 1], FTS.FTSPoints[i]);
        Tends.Add(tend);
        TTends.Add(tend.FBaseType);
        RTends.Add(tend.Intensity);
      }
    }

    public Report<CrispNResultRow, FuzzyNResultRow> GetReport() {
      var report = new Report<CrispNResultRow, FuzzyNResultRow>();
      ModelResult.FillCrispRowsNone(this, report);
      ModelResult.FillFuzzyRowsNone(this, report);
      return report;
    }
  }
}
