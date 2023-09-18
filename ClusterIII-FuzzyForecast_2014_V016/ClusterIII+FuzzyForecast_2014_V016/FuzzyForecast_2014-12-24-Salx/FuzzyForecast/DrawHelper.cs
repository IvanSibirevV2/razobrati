using System;
using System.Collections.Generic;
using System.Drawing;
using FuzzyLibrary;
using ZedGraph;

namespace FuzzyForecast {
  public class DrawHelper {

    public static Color[] colors = new Color[20] {
                                     Color.Red,
                                     Color.Blue,
                                     Color.Black,
                                     Color.Green,
                                     Color.DarkRed,
                                     Color.DarkBlue,
                                     Color.DarkGreen,
                                     Color.DarkOrange,
                                     Color.DarkViolet,
                                     Color.Cyan,
                                     Color.Gold, 
                                     Color.Orange, 
                                     Color.Violet, 
                                     Color.Aqua, 
                                     Color.Gray,
                                     Color.Yellow,
                                     Color.Brown,
                                     Color.Magenta,
                                     Color.Teal,
                                     Color.Tomato
                                   };

    public static void CleanseGraph(ZedGraphControl zgc) {
      zgc.GraphPane.Chart.Fill = new Fill(Color.AntiqueWhite, Color.Honeydew, -45F);
      zgc.GraphPane.Legend.IsVisible = true;
      zgc.GraphPane.CurveList.Clear();
      zgc.Invalidate();
    }
    
    public static void DrawCraph(ZedGraphControl zgc, Series s, Color color, bool editNames) {
      DrawPointList(zgc, s.PointList, color, SymbolType.Default, editNames);
    }
    
    public static void DrawPointList(ZedGraphControl graphControl, SPointList sPointList, Color color, SymbolType symbolType, bool editNames) {
      if (sPointList == null || sPointList.Count == 0)
        return;

      PointPairList pointList = Series.ToPointPairList(sPointList);

      GraphPane pane = graphControl.GraphPane;

      int maxCount = pointList.Count;
      foreach (var curveItem in pane.CurveList) {
        if (curveItem.Points.Count > maxCount) {
          maxCount = curveItem.Points.Count;
        }
      }

      var _symbolType = (maxCount > 100) ? SymbolType.None : symbolType;
      pane.AddCurve(sPointList.Name, pointList, color, _symbolType);

      double count = pointList.Count;
      double start = count > 0 ? pointList[0].X : 0;
      double step = count > 1 ? Math.Abs(pointList[1].X - pointList[0].X) : 0;

      var min = sPointList.FindMin();
      var max = sPointList.FindMax();

      var len = max.Y - min.Y;
      if (len == 0)
        len = 1;

      //расширим шкалу
      min.Y -= (len) * 0.1;
      max.Y += (len) * 0.1;

      if (pane.CurveList.Count > 1) {
        pane.XAxis.Scale.Min = Math.Min(start, pane.XAxis.Scale.Min);
        pane.XAxis.Scale.Max = Math.Max(start + count * step, pane.XAxis.Scale.Max);
        pane.YAxis.Scale.Max = Math.Max(max.Y, pane.YAxis.Scale.Max);
        pane.YAxis.Scale.Min = Math.Min(min.Y, pane.YAxis.Scale.Min);
      } else {
        pane.XAxis.Scale.Min = start;
        pane.XAxis.Scale.Max = start + count * step;
        pane.YAxis.Scale.Max = max.Y;
        pane.YAxis.Scale.Min = min.Y;
      }

      pane.XAxis.MinorGrid.IsVisible = true;
      pane.XAxis.MajorGrid.IsVisible = true;
      pane.YAxis.MinorGrid.IsVisible = true;
      pane.YAxis.MajorGrid.IsVisible = true;

      if (editNames) {
        pane.XAxis.Title.Text = sPointList.XName;
        pane.YAxis.Title.Text = sPointList.YName;
      }

      pane.AxisChange();
      graphControl.Invalidate();
    }

    public static void DrawFuzzyVariable(ZedGraphControl gc, FuzzyVariable fv) {
      DrawFuzzyTerms(gc, fv.Name, fv.Terms);
    }

    public static void DrawFuzzyTerms(ZedGraphControl gc, string name, List<FuzzyTerm> terms) {
      if (terms == null || terms.Count == 0)
        return;

      double min = ((IMembershipFunctionExt) terms[0].MembershipFunction).GetLeftBoundX();
      double max = ((IMembershipFunctionExt) terms[0].MembershipFunction).GetRightBoundX();

      foreach (var term in terms) {
        var mf = (IMembershipFunctionExt) term.MembershipFunction;
        if (mf.GetLeftBoundX() < min) {
          min = mf.GetLeftBoundX();
        }
        if (mf.GetRightBoundX() > max) {
          max = mf.GetRightBoundX();
        }
      }

      DrawFuzzyTerms(gc, name, terms, min, max);
    }

    public static void DrawFuzzyTerms(ZedGraphControl gc, string name, List<FuzzyTerm> terms, double min, double max) {
      double step = (max - min) / terms.Count;
      step = step / 20;
      int index = 0;
      foreach (var term in terms) {
        DrawMF(gc, term, min, max, step, colors[index]);
        index++;
        if (index >= colors.Length) {
          index = 0;
        }
      }
      gc.GraphPane.Title.IsVisible = true;
      gc.GraphPane.Title.Text = name;
    }

    public static void DrawMF(ZedGraphControl gc, FuzzyTerm ft, double min, double max, double step, Color color) {
      var pointList = new SPointList();
      if (Calc.IsZero(step)) {
        var ptY = (max + min) / 2;
        pointList.Add(new SPoint(ptY, ft.MembershipFunction.GetValue(ptY)));
      } else {
        for (double i = min; i < max; i += step) {
          pointList.Add(new SPoint(i, ft.MembershipFunction.GetValue(i)));
        }
      }
      pointList.Name = ft.Name;
      pointList.YName = "Значение ФП";
      pointList.XName = "Унииверсальное множество для ФП";
      DrawPointList(gc, pointList, color, SymbolType.None, true);
    }
  }
}
