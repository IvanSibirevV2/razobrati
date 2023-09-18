using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using FuzzyLibrary;

namespace FuzzyForecast {
    /// <summary>
    /// Расширение термов
    /// </summary>
    public class ExtTerms
    {
        public ExtTerms()
        {
            uppreTerms = 1;
            lowerTerms = 1;
            extendedTerms = 2;
        }

        public ExtTerms(int _upperTerms, int _lowerTerms)
        {
            uppreTerms = _upperTerms;
            lowerTerms = _lowerTerms;
            extendedTerms = uppreTerms + lowerTerms;
        }


        public int UppreTerms
        {
            set
            {
                uppreTerms = value;
            }
            get
            {
                return uppreTerms;
            }
        }

        public int LowerTerms
        {
            set
            {
                lowerTerms = value;
            }
            get
            {
                return lowerTerms;
            }
        }

        public int ExtendedTerms
        {
            //set
            //{
            //    extendedTends = value;
            //}
            get
            {
                return lowerTerms + uppreTerms;
            }
        }

        private int uppreTerms;
        private int lowerTerms;
        private int extendedTerms;
    }

  /// <summary>
  /// Нечеткая шкала
  /// </summary>
  public class FuzzyScale : IFuzzyScale {
    public const int numberIterationsDefault = 10000;
    public const double YInMaxXNextTermDefault = 0.0;
    public const double coefLengthTopDefault = 0.0; 

    private string name = "";
    private ExtTerms extendedTerms = new ExtTerms(1, 1);

    public int CountExtraTerms {
        get {
            return extendedTerms.ExtendedTerms;
        }
    }

    public ExtTerms ExtendedTerms
    {
        get
        {
            return extendedTerms;
        }
        set
        {
            extendedTerms = value;
        }
    }

    public string Name {
      set {
        name = value;
        Grades.Name = name;
      }
      get {
        return name;
      }
    }

    public double Min {
      get {
              return Grades.Min;
      }
    }

    public double Max {
      get {
              return Grades.Max;
      }
    }

    public double MinNotExp { get; set; }
    public double MaxNotExp { get; set; }

    public double CoefLengthTop = coefLengthTopDefault;
    public double YInMaxXNextTerm = YInMaxXNextTermDefault;
    public int NumberIterations = numberIterationsDefault;

    public FuzzificationMethod FMethod { get; private set; }

    /// <summary>
    /// Лингвистическая переменная, значения которой - значения шкалы
    /// </summary>
    public FuzzyVariable Grades { get; private set; }

    public int CountTerms {
        get {
            return Grades.Terms.Count - extendedTerms.ExtendedTerms;
        }
    }

    public double CrossPoint {
      get {
        
        if (Grades.Terms.Count == 0)
          return 0.0;
        var mf = Grades.Terms[extendedTerms.ExtendedTerms].MembershipFunction as TrapezoidMembershipFunction;
        if (mf != null) {
          var centerNext = mf.GetCrisp(YInMaxXNextTerm)[1];
          return mf.GetValue((mf.X3 + centerNext) / 2);
        } else {
          return 0.0;
        }
      }
    }

    
    public FuzzyScale() {}

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">имя шкалы</param>
    /// <param name="min">минимальое четкое значение</param>
    /// <param name="max">максимальное четкое значение</param>
    public FuzzyScale(string name, double min, double max)
        : this(name, min, max, 0.0)
    {
    }


    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">имя шкалы</param>
    /// <param name="min">минимальое четкое значение</param>
    /// <param name="max">максимальное четкое значение</param>
    /// <param name="expCoef">коэффициент расширения шкалы</param>
    public FuzzyScale(string name, double min, double max, double expCoef) {
      
      if(name != "Типы тенденций")
        extendedTerms = ACLSettingsForm.ExtendedTerms;

      if (Calc.Equal(min, max)) {
        var mean = min / 2;
        if (Calc.IsZero(mean))
          mean = 1;
        max = max + mean;
      }
      MinNotExp = min;
      MaxNotExp = max;
      min -= expCoef * (max - min);
      max += expCoef * (max - min);
      Grades = new FuzzyVariable(name, min, max);
      this.name = name;
    }

    /// <summary>
    /// Разбиение на интервалы
    /// </summary>
    /// <param name="count">количество интервалов</param>
    /// <param name="min">минимальное значение (для первого интервала)</param>
    /// <param name="max">максимальное значение (для последнего интервала)</param>
    /// <returns>список интервалов</returns>
    public static List<Interval> MakeIntervals(int count, double min, double max) {
      var ints = new List<Interval>();
      double start = min;
      double iLength = Math.Abs(max - min) / count;
      IntervalBorderTypes startType = IntervalBorderTypes.Inclusive;
      for (int i = 0; i < count; i++) {
        var interval = new Interval(startType, start, IntervalBorderTypes.Inclusive, start + iLength);
        start = interval.End;
        startType = IntervalBorderTypes.NotInclusive;
        ints.Add(interval);
      }
      return ints;
    }

    /// <summary>
    /// Получение списка середин интервалов
    /// </summary>
    /// <param name="intervals">список интервалов</param>
    /// <returns>список середин интевалов</returns>
    public static List<double> GetIntervlasMeans(List<Interval> intervals) {
      var means = new List<double>();
      foreach (var interval in intervals) {
        means.Add(interval.Mean);
      }
      return means;
    }

    public static List<FuzzyTerm> Fuzzify(double min, double max,
      List<string> termsNames, List<double> means, double yInMaxXNextTerm, double lengthTop) {

      if (yInMaxXNextTerm >= 1) {
        throw new ArgumentException();
      }

      var terms = new List<FuzzyTerm>();
      double count = termsNames.Count;

      if (count == 0)
        return terms;

      double iLenght = Math.Abs(max - min) / (count);

      if (iLenght < lengthTop) {
        throw new ArgumentException();
      }

      for (int i = 0; i < count; i++) {
        double x2 = means[i] - lengthTop / 2;
        double x3 = means[i] + lengthTop / 2;

        double k;
        if (i - 1 >= 0) {
          k = (1 - yInMaxXNextTerm) / (x2 - means[i - 1]);
        } else {
          k = (1 - yInMaxXNextTerm) / (iLenght);
        }

        double x1 = x2 - 1 / k;

        if (i + 1 < means.Count) {
          k = (1 - yInMaxXNextTerm) / (x3 - means[i + 1]);
        } else {
          k = (1 - yInMaxXNextTerm) / (-iLenght);
        }

        double x4 = x3 - 1 / k;

        //создаем нечеткие термы с трапецевидной функцией принадлежности
        var ft = new FuzzyTerm(termsNames[i], new TrapezoidMembershipFunction(x1, x2, x3, x4));
        terms.Add(ft);
      }

      return terms;
    }

    public void Fuzzification(List<FuzzyTerm> terms) {
      Grades.Terms.Clear();
      foreach (FuzzyTerm term in terms) {
        Grades.Terms.Add(term);
      }
      extendedTerms = new ExtTerms(0,0);
    }

    public void Fuzzification(SPointList pointList, FuzzificationMethod fmethod, int countTerms, bool isExpand, ExtTerms extTerms) {
      var baseScaleNames = new List<string>();
      extendedTerms = extTerms;
      for (int i = 0; i < countTerms; i++) {
        baseScaleNames.Add("A" + i);
      }

      Fuzzification(pointList, fmethod, baseScaleNames, isExpand);
    }

    public void Fuzzification(SPointList pointList, FuzzificationMethod fmethod, List<string> termsNames, bool isExpand) {
      FMethod = fmethod;

      switch (fmethod) {
        case FuzzificationMethod.Simple:
          SimpleFuzzification(termsNames, isExpand);
          break;
        case FuzzificationMethod.Cluster:
          ClusterFuzzification(pointList, termsNames, YInMaxXNextTermDefault);
          break;
        default:
          break;
      }
    }

    public void ClusterFuzzification(SPointList pointList, List<string> termsNames, double yInMaxXNextTerm) {
      if (termsNames.Count == 0)
        return;

      if (yInMaxXNextTerm >= 1) {
        throw new ArgumentException();
      }

      var clusters = DataClustering.YKMeansClustering(termsNames.Count, pointList, NumberIterations);

      if (clusters.Count < termsNames.Count) {
        SimpleFuzzification(termsNames, true);
        return;
      }

      var means = new List<double>();

      foreach (var cluster in clusters) {
        means.Add(cluster.Mean);
      }
      means.Sort();

      //расширяем шкалу
      var newTermsNames = Expand(termsNames, means);

      List<FuzzyTerm> terms = Fuzzify(Min, Max, newTermsNames, means, yInMaxXNextTerm, 0);

      Grades.Terms.Clear();
      Grades.Terms.AddRange(terms);
    }

    /// <summary>
    /// Простая фазификация
    /// </summary>
    /// <param name="termsNames">имена нечетких термов</param>
    /// <param name="isExpand"></param>
    public void SimpleFuzzification(List<string> termsNames, bool isExpand) {
      SimpleFuzzification(termsNames, YInMaxXNextTerm, isExpand);
    }

    public List<string> Expand(List<string> termsNames) {
      return Expand(termsNames, null);
    }

    public List<string> Expand(List<string> termsNames, List<double> means) {
      double min = MinNotExp;
      double max = MaxNotExp;

      var countTerms = termsNames.Count;

      // чтобы середины интервалов приходились на начало и конец шкалы
      // так как предполагается, что для начала и для конца шкалы 
      // функции принадлежности должны быть максимальны, то есть 1.
      // расширяем шкалу:
      // min - iLenght / 2 ... max + iLenght / 2;

      if (countTerms > 1) {
        double iLenght = Math.Abs(max - min) / (countTerms - 1);
        max = max + iLenght / 2;
        min = min - iLenght / 2;
      }

      double iLength = Math.Abs(max - min) / (countTerms);
      //Grades.Max = max + iLength * countExtraTerms;
      //Grades.Min = min - iLength * countExtraTerms;
      Grades.Max = max + iLength * extendedTerms.UppreTerms;
      Grades.Min = min - iLength * extendedTerms.LowerTerms;

      var expTermNames = new List<string>(termsNames);

      //for (int i = 0; i < countExtraTerms; i++) {
      //  expTermNames.Insert(0, expTermNames[0] + " - " + (i + 1));
      //  expTermNames.Add(expTermNames[expTermNames.Count - 1] + " + " + (i + 1));
      //  if (means != null) {
      //    means.Insert(0, MinNotExp - (i + 1) * iLength);
      //    means.Add(MaxNotExp + (i + 1) * iLength);
      //  }
      //}

      for (int i = 0; i < extendedTerms.UppreTerms; i++)
      {
          expTermNames.Add(expTermNames[expTermNames.Count - 1] + " + " + (i + 1));
          if (means != null)
          {
              means.Add(MaxNotExp + (i + 1) * iLength);
          }
      }

      for (int i = 0; i < extendedTerms.LowerTerms; i++)
      {
          expTermNames.Insert(0, expTermNames[0] + " - " + (i + 1));
          if (means != null)
          {
              means.Insert(0, MinNotExp - (i + 1) * iLength);
          }
      }

      return expTermNames;
    }
    
    /// <summary>
    /// Простая фазификация
    /// </summary>
    /// <param name="termsNames">имена нечетких термов</param>
    /// <param name="yInMaxXNextTerm">значение текущей ФП в точке, в которой следующая фукция имеет максимум</param>
    /// <param name="isExpand"></param>
    public void SimpleFuzzification(List<string> termsNames, double yInMaxXNextTerm, bool isExpand) {
      if (termsNames.Count == 0) {
        return;
      }

      if (!isExpand) {
          extendedTerms = new ExtTerms(0,0);
      }

      //расширяем шкалу
      var newTermsNames = Expand(termsNames);
      
      double min = Min;
      double max = Max;

      //получаем списко интервалов
      List<Interval> intervals = MakeIntervals(newTermsNames.Count, min, max);

      List<double> means = GetIntervlasMeans(intervals);

      double lengthTop = CoefLengthTop * Math.Abs(max - min) / (newTermsNames.Count);
      List<FuzzyTerm> terms = Fuzzify(min, max, newTermsNames, means, yInMaxXNextTerm, lengthTop);

      Grades.Terms.Clear();
      Grades.Terms.AddRange(terms);
    }

    
    /// <summary>
    /// Получить индекс терма по значению
    /// </summary>
    /// <param name="term">нечеткий терм</param>
    /// <returns>индекс</returns>
    public int GetTermIndex(FuzzyTerm term) {
      return Grades.Terms.IndexOf(term);
    }

    /// <summary>
    /// Получить нечеткие термы по четкому значению (все, для которых функция принадлежности больше 0)
    /// </summary>
    /// <param name="x">четкое значение</param>
    /// <returns>нечеткие термы</returns>
    public Dictionary<FuzzyTerm, double> GetTermsByX(double x) {
      var terms = new Dictionary<FuzzyTerm, double>();
      foreach (FuzzyTerm term in Grades.Terms) {
        double val = term.MembershipFunction.GetValue(x);
        if (!Calc.IsZero(val) && val > 0) {
          terms.Add(term, val);
        }
      }
      return terms;
    }

    /// <summary>
    /// Получить индексы нечетких термов по четкому значению (все, для которых функция принадлежности больше 0)
    /// </summary>
    /// <param name="x">четкое значение</param>
    /// <returns>нечеткие термы</returns>
    public Dictionary<int, double> GetIndexesByX(double x) {
      var terms = new Dictionary<int, double>();
      int index = 0;
      foreach (FuzzyTerm term in Grades.Terms) {
        double val = term.MembershipFunction.GetValue(x);
        if (!Calc.IsZero(val) && val > 0) {
          terms.Add(index, val);
        }
        index++;
      }
      return terms;
    }

    /// <summary>
    /// Получить нечеткий терм с минимальным значением функции принадлежности
    /// </summary>
    /// <param name="x">четкое значение</param>
    /// <returns>нечеткий терм</returns>
    public FuzzyTerm GetTermWithMinMF(double x) {
      if (Grades.Terms.Count == 0)
        return null;

      return Grades.Terms[GetTermIndexWithMinMF(x)];
    }

    /// <summary>
    /// Получить индекс нечеткого терма с минимальным значением функции принадлежности
    /// </summary>
    /// <param name="x">четкое значение</param>
    /// <returns>индекс</returns>
    public int GetTermIndexWithMinMF(double x) {
      if (Grades.Terms.Count == 0)
        return -1;

      FuzzyTerm minTerm = Grades.Terms[0];
      double min = minTerm.MembershipFunction.GetValue(x);
      int minIndex = 0;

      for (int i = 0; i < Grades.Terms.Count; i++) {
        FuzzyTerm term = Grades.Terms[i];
        double val = term.MembershipFunction.GetValue(x);
        if (val < min) {
          min = val;
          minIndex = i;
        }
      }
      return minIndex;
    }

    /// <summary>
    /// Получить нечеткий терм с максимальным значением функции принадлежнсти
    /// </summary>
    /// <param name="x">четкое значение</param>
    /// <returns>нечеткий терм</returns>
    public FuzzyTerm GetTermWithMaxMF(double x) {
      if (Grades.Terms.Count == 0)
        return null;
      return Grades.Terms[GetTermIndexWithMaxMF(x)];
    }

    /// <summary>
    /// Получить индекс нечеткого терма с максималным значением функции принадлежности
    /// </summary>
    /// <param name="x">четкое значение</param>
    /// <returns>индекс</returns>
    public int GetTermIndexWithMaxMF(double x) {
      if (Grades.Terms.Count == 0)
        return -1;

      FuzzyTerm maxTerm = Grades.Terms[0];
      double max = maxTerm.MembershipFunction.GetValue(x);
      int maxIndex = 0;

      for (int i = 0; i < Grades.Terms.Count; i++) {
        FuzzyTerm term = Grades.Terms[i];
        double val = term.MembershipFunction.GetValue(x);
        if (val > max) {
          max = val;
          maxIndex = i;
        }
      }
      return maxIndex;
    }

    /// <summary>
    /// Получить минимальное значение для функции принадлежности
    /// </summary>
    /// <param name="x">четкое значение</param>
    /// <returns>значение фукции принадлежнсти</returns>
    public double GetMinMembership(double x) {
      double min = 1;
      foreach (FuzzyTerm term in Grades.Terms) {
        double val = term.MembershipFunction.GetValue(x);
        if (val < min) {
          min = val;
        }
      }
      return min;
    }

    /// <summary>
    /// Получить максимальное значение для функции принадлежности
    /// </summary>
    /// <param name="x">четкое значение</param>
    /// <returns>значение фукции принадлежнсти</returns>
    public double GetMaxMembership(double x) {
      double max = 0;
      foreach (FuzzyTerm term in Grades.Terms) {
        double val = term.MembershipFunction.GetValue(x);
        if (val > max) {
          max = val;
        }
      }
      return max;
    }

    public FuzzyTerm GetTermByMF(IMembershipFunction mf) {
      var term = Grades.GetTermByMF(mf);
      if (term != null)
        return term;
      var crisp = GenericFuzzySystem.Defuzzify(DefuzzificationMethod.Centroid, mf, Grades.Min, Grades.Max);
      return GetTermWithMaxMF(crisp);
    }

    public Dictionary<FuzzyTerm, double> GetResult(CompositeMembershipFunction mf) {
      var result = new Dictionary<FuzzyTerm, double>();
      foreach (var membershipFunction in mf.MembershipFunctions) {
        var cmf = membershipFunction as CompositeMembershipFunction;
        if (cmf != null) {
          var constMF = cmf.MembershipFunctions[0] as ConstantMembershipFunction;
          var termMF = cmf.MembershipFunctions[1];
          var ft = GetTermByMF(termMF);
          if (!result.ContainsKey(ft)) {
            if (constMF != null) 
              result.Add(ft, constMF.GetValue(0));
          } else {
            if (constMF != null && constMF.GetValue(0) > result[ft]) {
              result[ft] = constMF.GetValue(0);
            }
          }
        }
      }

      return result;
    }

    public string GetStringResult(CompositeMembershipFunction mf) {
      var result = GetResult(mf);
      string resultString = "";
      foreach (var resultPair in result) {
        resultString += resultPair.Key.Name + "(" + resultPair.Value.ToString("F") + ") ";
      }
      return resultString;
    }

    /// <summary>
    /// Дефазификация - центроидный метод
    /// </summary>
    /// <param name="termName">имя нечеткого терма</param>
    /// <returns>четкое значение</returns>
    public double Defuzzify(string termName) {
      FuzzyTerm ft = Grades.GetTermByName(termName);
      return GenericFuzzySystem.Defuzzify(DefuzzificationMethod.Centroid,
        ft.MembershipFunction, Grades.Min, Grades.Max);
    }

    public XmlElement ToXmlElement(XmlDocument xmlDocument) {
      var xmlElement = xmlDocument.CreateElement("FuzzyScale");

      Project.AddFieldElement(xmlDocument, xmlElement, "Name", Name);
      Project.AddFieldElement(xmlDocument, xmlElement, "Min", Min.ToString());
      Project.AddFieldElement(xmlDocument, xmlElement, "Max", Max.ToString());
      Project.AddFieldElement(xmlDocument, xmlElement, "MinNotExp", MinNotExp.ToString());
      Project.AddFieldElement(xmlDocument, xmlElement, "MaxNotExp", MaxNotExp.ToString());

      Project.AddFieldElement(xmlDocument, xmlElement, "CoefLengthTop", CoefLengthTop.ToString());
      Project.AddFieldElement(xmlDocument, xmlElement, "YInMaxXNextTerm", YInMaxXNextTerm.ToString());

      var xmlElementGrades = xmlDocument.CreateElement("Grades");
      foreach (var term in Grades.Terms) {
        var xmlElementTerm = xmlDocument.CreateElement("Term");     
        var tmf = (TrapezoidMembershipFunction)term.MembershipFunction;
        Project.AddFieldElement(xmlDocument, xmlElementTerm, "Name", term.Name);
        Project.AddFieldElement(xmlDocument, xmlElementTerm, "X1", tmf.X1.ToString());
        Project.AddFieldElement(xmlDocument, xmlElementTerm, "X2", tmf.X2.ToString());
        Project.AddFieldElement(xmlDocument, xmlElementTerm, "X3", tmf.X3.ToString());
        Project.AddFieldElement(xmlDocument, xmlElementTerm, "X4", tmf.X4.ToString());

        xmlElementGrades.AppendChild(xmlElementTerm);
      }
      xmlElement.AppendChild(xmlElementGrades);

      return xmlElement;
    }

    public void FromXmlElement(XmlElement xmlElement) {
      name = Project.GetFieldElement(xmlElement, "Name");
      double min = double.Parse(Project.GetFieldElement(xmlElement, "Min"));
      double max = double.Parse(Project.GetFieldElement(xmlElement, "Max"));
      MinNotExp = double.Parse(Project.GetFieldElement(xmlElement, "MinNotExp"));
      MaxNotExp = double.Parse(Project.GetFieldElement(xmlElement, "MaxNotExp"));

      CoefLengthTop = double.Parse(Project.GetFieldElement(xmlElement, "CoefLengthTop"));
      YInMaxXNextTerm = double.Parse(Project.GetFieldElement(xmlElement, "YInMaxXNextTerm"));

      Grades = new FuzzyVariable(name, min, max);

      var xmlElementGrades = Project.GetXmlElement(xmlElement, "Grades");
      XmlNodeList xmlNodeList = xmlElementGrades.GetElementsByTagName("Term");
      IEnumerator i = xmlNodeList.GetEnumerator();
      while (i.MoveNext()) {
        var xmlElementTerm = (XmlElement) i.Current;
        var termName = Project.GetFieldElement(xmlElementTerm, "Name");
        double X1 = double.Parse(Project.GetFieldElement(xmlElementTerm, "X1"));
        double X2 = double.Parse(Project.GetFieldElement(xmlElementTerm, "X2"));
        double X3 = double.Parse(Project.GetFieldElement(xmlElementTerm, "X3"));
        double X4 = double.Parse(Project.GetFieldElement(xmlElementTerm, "X4"));
        var tmf = new TrapezoidMembershipFunction(X1, X2, X3, X4);
        var ft = new FuzzyTerm(termName, tmf);
        Grades.Terms.Add(ft);
      }
    }
  }
}
