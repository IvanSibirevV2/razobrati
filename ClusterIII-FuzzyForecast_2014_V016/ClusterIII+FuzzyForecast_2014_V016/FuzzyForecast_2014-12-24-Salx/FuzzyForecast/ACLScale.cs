using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using FuzzyLibrary;

namespace FuzzyForecast
{
    /// <summary>
    /// ACL-шкала для работы с тенденциями
    /// </summary>
    public class ACLScale
    {
        public static List<string> typesNamesDefault = new List<string> { "Падение", "Стабильность", "Рост" };
        public static List<string> intensityNamesDefault = new List<string> { "Слабо", "Сильно", "Средне" };
        public const double expCoef = 0.0;

        //Использовать значение тенденции "Стабильность" относительно модуля области значения ряда
        private bool absoluteScaleForTypes;
        public bool AbsoluteScaleForTypes
        {
            get
            {
                return absoluteScaleForTypes;
            }
            set
            {
                if (absoluteScaleForTypes == value)
                    return;
                absoluteScaleForTypes = value;
            }
        }

        //Сдвиг позиции шкалы интенсивностей
        private int IntensityScalePosition = 0;
        public int ISP
        {
            get
            {
                return IntensityScalePosition;
            }
            set
            {
                IntensityScalePosition = value;
            }
        }

        //Процентное значение тенденции стабильность
        private double middleTendScale;
        public double MiddleTendScale
        {
            get
            {
                return middleTendScale;
            }
            set
            {
                if (middleTendScale == value)
                    return;
                middleTendScale = value;
            }
        }

        //Значение тенденции "Стабильность"
        private double d;
        public double D
        {
            get
            {
                return d;
            }
        }

        private double len;
        public double Len
        {
            get
            {
                return len;
            }
        }

        public string Name = "";

        public string ScaleInfo
        {
            //get { return "Количество нечетких термов: " + BaseScale.CountTerms + " Точность:"; }
            get { return "Количество нечетких термов: " + BaseScale.CountTerms; }
        
        }

        public FuzzyScale BaseScale;
        //public FuzzyScale TendTypesScale;
        public FuzzyScale TendBaseTypesScale;
        public FuzzyScale TendIntensityScale;
        public FuzzyScale TendPrecisionScale;

        public FuzzyScale TendDiffScale;

        public List<string> typesNames = new List<string>();
        //public List<string> intensityNames = new List<string>();

        public MamdaniFuzzySystem MFSTTends = new MamdaniFuzzySystem();
        public MamdaniFuzzySystem MFSRTends = new MamdaniFuzzySystem();

        public List<FuzzyVariable> fvInputsTTend = new List<FuzzyVariable>();
        public FuzzyVariable fvOutputTTend;

        public List<FuzzyVariable> fvInputsRTend = new List<FuzzyVariable>();
        public FuzzyVariable fvOutputRTend;

        public ACLScale(string name, double min, double max, List<string> typesNames)
        {
            Name = name;
            BaseScale = new FuzzyScale("Основная шкала", min, max, expCoef);
            this.typesNames = typesNames;
            //this.intensityNames = intensityNames;
        }

        /// <summary>
        /// Четкая разность нечетких термов
        /// </summary>
        /// <param name="lTerm">левый терм</param>
        /// <param name="rTerm">правый терм</param>
        /// <param name="min">минимальное четкое значение</param>
        /// <param name="max">максимальное четкое значение</param>
        /// <returns>четкая разность</returns>
        public static double CrispDifference(FuzzyTerm lTerm, FuzzyTerm rTerm, double min, double max)
        {
            double lCrispVal = GenericFuzzySystem.Defuzzify(DefuzzificationMethod.Centroid,
              lTerm.MembershipFunction, min, max);

            double rCrispVal = GenericFuzzySystem.Defuzzify(DefuzzificationMethod.Centroid,
              rTerm.MembershipFunction, min, max);

            return lCrispVal - rCrispVal;
        }

        public static double GetMaxTendCrisp(SPointList points)
        {
            double maxDiff = 0;
            for (int i = 1; i < points.Count; i++)
            {
                var diff = Math.Abs(points[i].Y - points[i - 1].Y);
                if (diff > maxDiff)
                {
                    maxDiff = diff;
                }
            }
            return maxDiff;
        }

        public static double GetMaxDiff(SPointList points)
        {
            double maxDiff = 0;
            for (int i = 1; i < points.Count; i++)
            {
                var diff = Math.Abs(points[i].Y - points[i - 1].Y);
                if (diff > maxDiff)
                {
                    maxDiff = diff;
                }
            }
            return maxDiff;
        }

        public static double GetMinDiff(SPointList points)
        {
            double minDiff = Math.Abs(points[1].Y - points[0].Y);
            for (int i = 1; i < points.Count; i++)
            {
                var diff = Math.Abs(points[i].Y - points[i - 1].Y);
                if (diff < minDiff)
                {
                    minDiff = diff;
                }
            }
            return minDiff;
        }

        /// <summary>
        /// Максимальная разность для шкалы
        /// </summary>
        /// <returns></returns>
        public double MaxCripsDiff()
        {
            if (BaseScale.Grades.Terms.Count < 2)
            {
                return 0;
            }

            FuzzyTerm lTerm = BaseScale.Grades.Terms[0];
            FuzzyTerm rTerm = BaseScale.Grades.Terms[BaseScale.Grades.Terms.Count - 1];

            return CrispDifference(lTerm, rTerm, BaseScale.Min, BaseScale.Max);
        }

        public BaseTendType GetBaseTendType(double tTend)
        {
            var iZero = TendBaseTypesScale.GetTermIndexWithMaxMF(0);
            var iTTend = TendBaseTypesScale.GetTermIndexWithMaxMF(tTend);
            return FuzzyTend.GetTendType(iTTend - iZero);
        }

        public void InnerSimpleFuzzification(SPointList points)
        {
            var maxTend = GetMaxDiff(points);
            var minTend = GetMinDiff(points);

            //#warning Получение разностей без модулей
            //#warning Замена диапазона для оценок типов на область значения ряда
            //maxTend = Math.Abs(maxTend); // must be positive
            //TendTypesScale = new FuzzyScale("Типы тенденций", -maxTend, maxTend, expCoef);
            //TendTypesScale.SimpleFuzzification(typesNames);

            len = BaseScale.MaxNotExp - BaseScale.MinNotExp;
            TendBaseTypesScale = new FuzzyScale("Типы тенденций", -len, len, 0.0);

            TendBaseTypesScale.Fuzzification(FuzzyTend.GetBaseTTendTerms(-maxTend, maxTend, len, absoluteScaleForTypes, middleTendScale, out d));
            double iLenght = 2 * maxTend / TendBaseTypesScale.CountTerms;
            TendBaseTypesScale.Grades.Max += iLenght;
            TendBaseTypesScale.Grades.Min -= iLenght;

            //TendIntensityScale = new FuzzyScale("Интенсивность", 0, len + maxTend, 0.0);
            //TendIntensityScale = new FuzzyScale("Интенсивность", -Math.Abs(ISM), Math.Abs(ISM), 0.0);
            //TendIntensityScale = new FuzzyScale("Интенсивность", 0.0, Math.Abs(ISM), 0.0);
            TendIntensityScale = new FuzzyScale("Интенсивность", 0.0, len, 0.0);

            //TendIntensityScale = new FuzzyScale("Интенсивность", BaseScale.MinNotExp, BaseScale.MaxNotExp, 0.0);

            var iNames = new List<string>();
            for (int i = 0; i < BaseScale.CountTerms - 2; i++)
            {
                iNames.Add("R" + i);
            }
            TendIntensityScale.SimpleFuzzification(iNames, true);


            /*
            ----Шкала точности-------------------------------------------------
             */
            TendPrecisionScale = new FuzzyScale("Точность", 0.0, 100.0, 0.0);
            TendPrecisionScale.ExtendedTerms = new ExtTerms(0, 0);
            var precisionTerms = new List<string>();
                 
            precisionTerms.Add("Очень высокая");
            precisionTerms.Add("Высокая");
            precisionTerms.Add("Средняя");
            precisionTerms.Add("Низкая");
            precisionTerms.Add("Очень низкая");
            
            TendPrecisionScale.SimpleFuzzification(precisionTerms, true);
            /*
            -------------------------------------------------------------------
             */


            TendDiffScale = new FuzzyScale("Разность", minTend, maxTend, 0.0);

            var dNames = new List<string>();
            for (int i = 0; i < BaseScale.CountTerms; i++)
            {
                dNames.Add("D" + i);
            }
            TendDiffScale.YInMaxXNextTerm = BaseScale.YInMaxXNextTerm;
            TendDiffScale.CoefLengthTop = BaseScale.CoefLengthTop;

            var diffPointList = new SPointList();
            for (int i = 1; i < points.Count; i++)
            {
                var newPt = new SPoint(points[i].X, points[i].Y - points[i - 1].Y);
                diffPointList.Add(newPt);
            }

            TendDiffScale.Fuzzification(diffPointList, BaseScale.FMethod, dNames, true);

            MakeTTendMFS();
            MakeRTendMFS();
        }

        public void MakeTTendMFS()
        {
            MFSTTends = new MamdaniFuzzySystem();
            fvInputsTTend = new List<FuzzyVariable>();

            for (int i = 0; i < 2; i++)
            {
                var fvInput = new FuzzyVariable("Input" + i, BaseScale.Min, BaseScale.Max);
                foreach (FuzzyTerm ft in BaseScale.Grades.Terms)
                {
                    fvInput.Terms.Add(ft);
                }
                fvInputsTTend.Add(fvInput);
            }

            fvOutputTTend = new FuzzyVariable("TTend", TendBaseTypesScale.Min, TendBaseTypesScale.Max);

            foreach (FuzzyTerm ft in TendBaseTypesScale.Grades.Terms)
            {
                fvOutputTTend.Terms.Add(ft);
            }

            MFSTTends.Input.AddRange(fvInputsTTend);
            MFSTTends.Output.Add(fvOutputTTend);

            var totalCount = BaseScale.Grades.Terms.Count;
            var countNotExp = BaseScale.CountTerms;
            var countExtra = BaseScale.CountExtraTerms;

            for (int i = 0; i < totalCount; i++)
            {
                for (int j = 0; j < totalCount; j++)
                {
                    MamdaniFuzzyRule rule = MFSTTends.EmptyRule();
                    rule.Condition.Op = OperatorType.And;

                    FuzzyCondition fc1 = rule.CreateCondition(fvInputsTTend[0], fvInputsTTend[0].Terms[i]);
                    rule.Condition.ConditionsList.Add(fc1);

                    FuzzyCondition fc2 = rule.CreateCondition(fvInputsTTend[1], fvInputsTTend[1].Terms[j]);
                    rule.Condition.ConditionsList.Add(fc2);

                    if (i > j)
                    {
                        rule.Conclusion.Term = fvOutputTTend.Terms[0];
                    }
                    else if (i == j)
                    {
                        rule.Conclusion.Term = fvOutputTTend.Terms[1];
                    }
                    else if (i < j)
                    {
                        rule.Conclusion.Term = fvOutputTTend.Terms[2];
                    }

                    rule.Conclusion.Var = fvOutputTTend;
                    MFSTTends.Rules.Add(rule);
                }
            }
        }

        public void MakeRTendMFS()
        {
            MFSRTends = new MamdaniFuzzySystem();
            fvInputsRTend = new List<FuzzyVariable>();

            for (int i = 0; i < 2; i++)
            {
                var fvInput = new FuzzyVariable("Input" + i, BaseScale.Min, BaseScale.Max);
                foreach (FuzzyTerm ft in BaseScale.Grades.Terms)
                {
                    fvInput.Terms.Add(ft);
                }
                fvInputsRTend.Add(fvInput);
            }

            fvOutputRTend = new FuzzyVariable("RTend", TendIntensityScale.Min, TendIntensityScale.Max);

            foreach (FuzzyTerm ft in TendIntensityScale.Grades.Terms)
            {
                fvOutputRTend.Terms.Add(ft);
            }

            MFSRTends.Input.AddRange(fvInputsRTend);
            MFSRTends.Output.Add(fvOutputRTend);

            var totalCount = BaseScale.Grades.Terms.Count;
            var countNotExp = BaseScale.CountTerms;
            var countExtra = BaseScale.CountExtraTerms;

            for (int i = countExtra; i < countNotExp; i++)
            {
                for (int j = countExtra; j < countNotExp; j++)
                {
                    MamdaniFuzzyRule rule = MFSRTends.EmptyRule();
                    rule.Condition.Op = OperatorType.And;

                    FuzzyCondition fc1 = rule.CreateCondition(fvInputsRTend[0], fvInputsRTend[0].Terms[i]);
                    rule.Condition.ConditionsList.Add(fc1);

                    FuzzyCondition fc2 = rule.CreateCondition(fvInputsRTend[1], fvInputsRTend[1].Terms[j]);
                    rule.Condition.ConditionsList.Add(fc2);

                    int diff = Math.Abs(j - i);
                    rule.Conclusion.Term = fvOutputRTend.Terms[diff];
                    rule.Conclusion.Var = fvOutputRTend;
                    MFSRTends.Rules.Add(rule);
                }
            }
        }

        /*public void Fuzzification(List<FuzzyTerm> baseTerms, double maxTend) {
          BaseScale.Fuzzification(baseTerms);
          InnerSimpleFuzzification(maxTend);
        }


        public void SimpleFuzzification(List<string> baseTermsNames, double maxTend) {
          BaseScale.SimpleFuzzification(baseTermsNames);
          InnerSimpleFuzzification(maxTend);
        }

        public void ClusterFuzzification(SPointList pointList, List<string> baseTermsNames, double YInNextMaxX, double maxTend) {
          BaseScale.ClusterFuzzification(pointList, baseTermsNames, YInNextMaxX);
          InnerSimpleFuzzification(maxTend);
        }*/

        public XmlElement ToXmlElement(XmlDocument xmlDocument)
        {
            var xmlElement = xmlDocument.CreateElement("ACLScale");
            Project.AddFieldElement(xmlDocument, xmlElement, "Name", Name);
            xmlElement.AppendChild(BaseScale.ToXmlElement(xmlDocument));
            xmlElement.AppendChild(TendBaseTypesScale.ToXmlElement(xmlDocument));
            xmlElement.AppendChild(TendIntensityScale.ToXmlElement(xmlDocument));
            xmlElement.AppendChild(TendDiffScale.ToXmlElement(xmlDocument));
            return xmlElement;
        }

        public void FromXmlElement(XmlElement xmlElement)
        {
            Name = Project.GetFieldElement(xmlElement, "Name");
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName("FuzzyScale");
            IEnumerator i = xmlNodeList.GetEnumerator();
            if (i.MoveNext())
            {
                BaseScale = new FuzzyScale();
                BaseScale.FromXmlElement((XmlElement)i.Current);
            }
            if (i.MoveNext())
            {
                TendBaseTypesScale = new FuzzyScale();
                TendBaseTypesScale.FromXmlElement((XmlElement)i.Current);
            }
            if (i.MoveNext())
            {
                TendIntensityScale = new FuzzyScale();
                TendIntensityScale.FromXmlElement((XmlElement)i.Current);
            }
            if (i.MoveNext())
            {
                TendDiffScale = new FuzzyScale();
                TendDiffScale.FromXmlElement((XmlElement)i.Current);
                MakeTTendMFS();
                MakeRTendMFS();
            }
        }
    }
}
