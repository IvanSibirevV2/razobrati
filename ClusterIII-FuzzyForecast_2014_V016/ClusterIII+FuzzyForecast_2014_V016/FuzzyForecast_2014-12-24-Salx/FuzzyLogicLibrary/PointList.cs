using System;
using System.Collections.Generic;

namespace FuzzyLibrary {
  ///<summary>
  /// Точка ряда
  ///</summary>
  public class SPoint : ICloneable {

    /// <summary>
    /// Сравнение двух точек
    /// </summary>
    public class SPointComparer : IComparer<SPoint> {

      public int Compare(SPoint l, SPoint r) {
        if (l == null && r == null)
          return 0;
        if (l == null)
          return -1;
        if (r == null)
          return 1;

        double lVal = l.X;
        double rVal = r.X;

        if (Double.IsInfinity(lVal) || Double.IsNaN(lVal))
          l = null;
        if (Double.IsInfinity(rVal) || Double.IsNaN(rVal))
          r = null;

        if ((l == null && r == null) || (Math.Abs(lVal - rVal) < 1e-100))
          return 0;
        if (l == null)
          return -1;
        if (r == null)
          return 1;
        return lVal < rVal ? -1 : 1;
      }
    }

    public double X;
    public double Y;

    public const string DefaultFormat = "G";

    public bool IsInvalid {
      get {
        return Double.IsInfinity(X) ||
               Double.IsInfinity(Y) ||
               Double.IsNaN(X) ||
               Double.IsNaN(Y);
      }
    }

    public SPoint()
      : this(0, 0) {
    }

    public SPoint(double x, double y) {
      X = x;
      Y = y;
    }

    public SPoint(SPoint point) {
      X = point.X;
      Y = point.Y;
    }

    public override bool Equals(object obj) {
      var rhs = obj as SPoint;
      if (rhs == null)
        return false;
      return X == rhs.X && Y == rhs.Y;
    }

    public override int GetHashCode() {
      return base.GetHashCode();
    }

    public override string ToString() {
      return ToString(DefaultFormat);
    }

    public string ToString(string format) {
      return "( " + X.ToString(format) +
                    ", " + Y.ToString(format) +
                    " )";
    }

    object ICloneable.Clone() {
      return Clone();
    }

    public SPoint Clone() {
      return new SPoint(this);
    }
  }

  public interface IPointList {
    SPoint this[int index] { get; }
    int Count { get; }
  }

  public class SPointList : List<SPoint>, IPointList {
    public string Name = "";
    public string XName = "";
    public string YName = ""; 
    
    private bool _sorted = true;

    public bool Sorted {
      get { return _sorted; }
    }

    public SPointList() {
    }

    public SPointList(double[] x, double[] y) {
      Add(x, y);
      _sorted = false;
    }

    public SPointList(IPointList list) {
      int count = list.Count;
      for (int i = 0; i < count; i++)
        Add(list[i]);

      _sorted = false;
    }

    public SPointList(IList<SPoint> list) {
      int count = list.Count;
      for (int i = 0; i < count; i++)
        Add(list[i]);

      _sorted = false;
    }


    public int FindIndexAbsMax() {
      if (Count == 0) {
        return -1;
      }
      int indMax = 0;
      for (int i = 0; i < Count; i++) {
        if (Math.Abs(this[i].Y) > Math.Abs(this[indMax].Y)) {
          indMax = i;
        }
      }
      return indMax;
    }
    
    
    public int FindIndexMax() {
      if (Count == 0) {
        return -1;
      }
      int indMax = 0;
      for (int i = 0; i < Count; i++) {
        if (this[i].Y > this[indMax].Y) {
          indMax = i;
        }
      }
      return indMax;
    }

    public SPoint FindMax() {
      int indMax = FindIndexMax();
      if (indMax < 0)
        return null;

      return this[indMax].Clone();
    }

    public int FindIndexMin() {
      if (Count == 0) {
        return -1;
      }
      int indMin = 0;
      for (int i = 0; i < Count; i++) {
        if (this[i].Y < this[indMin].Y) {
          indMin = i;
        }
      }
      return indMin;
    }

    public int FindIndexAbsMin() {
      if (Count == 0) {
        return -1;
      }
      int indMin = 0;
      for (int i = 0; i < Count; i++) {
        if (Math.Abs(this[i].Y) < Math.Abs(this[indMin].Y)) {
          indMin = i;
        }
      }
      return indMin;
    }

    public SPoint FindMin() {
      int indMin = FindIndexMin();
      if (indMin < 0)
        return null;

      return this[indMin].Clone();
    }

    public void Add(double[] x, double[] y) {

      if (x == null || y == null)
        return;

      int len = Math.Min(x.Length, y.Length);

      for (int i = 0; i < len; i++) {
        var point = new SPoint(x[i], y[i]);
        Add(point);
      }
    }
    public new void Add(SPoint point) {
      _sorted = false;

      SPoint newPoint = point.Clone();

      base.Add(newPoint);
    }

    public new bool Sort() {
      if (_sorted)
        return true;

      Sort(new SPoint.SPointComparer());
      return false;
    }

    /// <summary>
    /// Linearly interpolate the data to find an arbitraty Y value that corresponds to the specified X value.
    /// </summary>
    /// <remarks>
    /// This method uses linear interpolation with a binary search algorithm.  It therefore
    /// requires that the x data be monotonically increasing.  Missing values are not allowed.  This
    /// method will extrapolate outside the range of the PointPairList if necessary.
    /// </remarks>
    /// <param name="xTarget">The target X value on which to interpolate</param>
    /// <returns>The Y value that corresponds to the <see paramref="xTarget"/> value.</returns>
    public double InterpolateX(double xTarget) {
      int lo;
      int hi;
      if (Count < 2)
        throw new Exception("Error: Not enough points in curve to interpolate");

      if (xTarget <= this[0].X) {
        lo = 0;
        hi = 1;
      } else if (xTarget >= this[Count - 1].X) {
        lo = Count - 2;
        hi = Count - 1;
      } else {
        // if x is within the bounds of the x table, then do a binary search
        // in the x table to find table entries that bound the x value
        lo = 0;
        hi = Count - 1;

        // limit to 1000 loops to avoid an infinite loop problem
        int j;
        for (j = 0; j < 1000 && hi > lo + 1; j++) {
          int mid = (hi + lo) / 2;
          if (xTarget > this[mid].X)
            lo = mid;
          else
            hi = mid;
        }

        if (j >= 1000)
          throw new Exception("Error: Infinite loop in interpolation");
      }

      return (xTarget - this[lo].X) / (this[hi].X - this[lo].X) *
              (this[hi].Y - this[lo].Y) + this[lo].Y;

    }


    public SPointList LinearRegression(IPointList points, int pointCount) {
      double minX = double.MaxValue;
      double maxX = double.MinValue;

      for (int i = 0; i < points.Count; i++) {
        SPoint pt = points[i];

        if (!pt.IsInvalid) {
          minX = pt.X < minX ? pt.X : minX;
          maxX = pt.X > maxX ? pt.X : maxX;
        }
      }

      return LinearRegression(points, pointCount, minX, maxX);
    }

    public SPointList LinearRegression(IPointList points, int pointCount,
        double minX, double maxX) {
      double x = 0, y = 0, xx = 0, xy = 0, count = 0;
      for (int i = 0; i < points.Count; i++) {
        SPoint pt = points[i];
        if (!pt.IsInvalid) {
          x += points[i].X;
          y += points[i].Y;
          xx += points[i].X * points[i].X;
          xy += points[i].X * points[i].Y;
          count++;
        }
      }

      if (count < 2 || maxX - minX < 1e-20)
        return null;

      double slope = (count * xy - x * y) / (count * xx - x * x);
      double intercept = (y - slope * x) / count;

      var newPoints = new SPointList();
      double stepSize = (maxX - minX) / pointCount;
      double value = minX;
      for (int i = 0; i < pointCount; i++) {
        newPoints.Add(new SPoint(value, value * slope + intercept));
        value += stepSize;
      }

      return newPoints;
    }

    public override string ToString() {
      return Name;
    }

  }
}
