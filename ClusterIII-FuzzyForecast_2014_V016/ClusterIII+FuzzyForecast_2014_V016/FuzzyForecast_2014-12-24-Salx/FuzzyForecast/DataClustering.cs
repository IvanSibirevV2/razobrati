using System;
using System.Collections.Generic;
using FuzzyLibrary;

namespace FuzzyForecast {

  /// <summary>
  /// Кластер
  /// </summary>
  public class Cluster {
    /// <summary>
    /// точки кластера
    /// </summary>
    public SPointList points;

    /// <summary>
    /// Центр кластера по Y
    /// </summary>
    public double Mean;

    /// <summary>
    /// Установка точек кластера
    /// </summary>
    /// <param name="indexes">индексы устанавливаемых точек</param>
    /// <param name="pts">массив, из которого берутся точки для установки</param>
    public void SetPoints(List<int> indexes, List<SPoint> pts) {
      points = new SPointList();
      foreach (int ind in indexes) {
        points.Add(pts[ind].Clone());
      }
    }

    /// <summary>
    /// Центр массива точек (по Y)
    /// </summary>
    /// <param name="pts">массив точек</param>
    /// <returns></returns>
    public static double YCenter(List<SPoint> pts) {
      double sum = 0.0;
      foreach (SPoint pt in pts) {
        sum += pt.Y;
      }
      return sum/pts.Count;
    }

    /// <summary>
    /// Центр массива точек (по Y)
    /// </summary>
    /// <returns>массив точек</returns>
    public double YCenter() {
      double sum = 0.0;
      foreach (SPoint pt in points) {
        sum += pt.Y;
      }
      return sum / points.Count;
    }

    /// <summary>
    /// Вычисление диаметра кластера
    /// </summary>
    /// <returns>диаметр кластера</returns>
    public double Diameter() {
      throw new NotImplementedException();
    }
  }
  
  public class DataClustering {

    public static double EuclidDistance(SPoint pt1, SPoint pt2) {
      return Math.Sqrt(Math.Pow(pt1.X - pt2.X, 2) + Math.Pow(pt1.Y - pt2.Y, 2));
    }

    public static double YDistance(SPoint pt1, SPoint pt2) {
      return Math.Abs(pt1.Y - pt2.Y);
    }

    
    private static int GetNearestCluster(double[] means, SPoint pt) {
      // ищем кластер, от центра которого до точки минимальное расстояние

      int clusterIndex = 0;
      double minDistance = Math.Abs(means[clusterIndex] - pt.Y);
      
      for (int j = 0; j < means.Length ; j++) {
        double yDistanse = Math.Abs(means[j] - pt.Y);
        if (yDistanse < minDistance) {
          minDistance = yDistanse;
          clusterIndex = j;
        }
      }

      return clusterIndex;
    }

    public static List<Cluster> YKMeansClustering(int numberClusters, SPointList points, int NumberIterations) {
      SPoint maxValue = points.FindMax();
      SPoint minValue = points.FindMin();

      double lengthInterval = (maxValue.Y - minValue.Y)/numberClusters;

      // массив центров кластеров
      var means = new double[numberClusters];

      var clusterMap = new int[points.Count];

      var clusters = new List<Cluster>();

      // инициализация центров кластеров
      means[0] = minValue.Y + lengthInterval/2;
      for (int i = 1; i < numberClusters; i++) {
        means[i] = means[i - 1] + lengthInterval;
      }

      //инициализация карты кластеров
      /*for (int i = 0; i < points.Count; i++) {
        clusterMap[i] = 0;
      }*/


      int iteration = 0;
      bool wasChange = true;
      while (iteration < NumberIterations && wasChange) {
        wasChange = false;
        for (int i = 0; i < points.Count; i++) {
          SPoint pt = points[i];

          //ищем кластер, от центра которого до точки минимальное расстояние
          int clusterIndex = GetNearestCluster(means, pt);

          //в карту кластеров записываем новый индекс, если он изменился
          if (clusterIndex != clusterMap[i]) {
            clusterMap[i] = clusterIndex;
            wasChange = true;
          } 
        }

        if (!wasChange)
          break;

        clusters.Clear();
        for (int i = 0; i < numberClusters; i++) {

          var clusterPoints = new List<SPoint>();

          // вычисляем для i кластера его центр по Y!!! только
          double sum = 0.0;
          for (int j = 0; j < points.Count; j++) {
            if (clusterMap[j] == i) {
              clusterPoints.Add(points[j].Clone());
              sum += points[j].Y;
            }
          }

        //#warning возникает случай, когда кластеру не принадлежит ни одна точка
          if (clusterPoints.Count != 0) {
            means[i] = sum / clusterPoints.Count;
          }

          var cl = new Cluster {points = new SPointList(clusterPoints), Mean = means[i]};
          clusters.Add(cl);
        }
        iteration++;
      }


      return clusters;
    }
  }
}
