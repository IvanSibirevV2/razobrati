using System;
using System.Collections.Generic;
using FuzzyLibrary;

namespace FuzzyForecast
{

    /// <summary>
    /// Характеристики типа тенденции
    /// </summary>
    public class TendMF
    {
        public double Begin;
        public double End;

        public double Inc;
        public double Dec;
        public double Stab;

        public TendMF() { }

        public double[] ToArray()
        {
            var array = new[] { Dec, Stab, Inc };
            return array;
        }

        public int ToTendType()
        {
            if (Inc >= Dec && Inc >= Stab)
            {
                return +1;
            }
            if (Dec >= Inc && Dec >= Stab)
            {
                return -1;
            }
            return 0;
        }

        public double MF
        {
            get { return Math.Max(Math.Max(Inc, Dec), Stab); }
        }

        public FuzzyTerm GetFuzzyTerm(FuzzyScale tendScale)
        {
            var index = ToTendType() + 1;
            return tendScale.Grades.Terms[index];
        }

        public string ToString(FuzzyScale tendScale)
        {
            var index = ToTendType() + 1;
            return tendScale.Grades.Terms[index].Name + "(" + MF.ToString("F") + ")";
        }

        public TendMF(FTSPoint pt1, FTSPoint pt2)
        {
            if (pt1 == null)
                pt1 = pt2;

            Begin = pt1.point.Y;
            End = pt2.point.Y;

            var indexes1 = pt1.Indexes;
            var indexes2 = pt2.Indexes;
            var incMFs = new List<double>();
            var decMFs = new List<double>();
            var stabMFs = new List<double>();

            //минимумы
            foreach (var pair1 in indexes1)
            {
                foreach (var pair2 in indexes2)
                {
                    //#warning может быть лучше среднее арифметическое?
                    var mf = Math.Min(pair1.Value, pair2.Value);
                    if (pair1.Key == pair2.Key)
                    {
                        stabMFs.Add(mf);
                    }
                    else if (pair1.Key < pair2.Key)
                    {
                        incMFs.Add(mf);
                    }
                    else
                    {
                        decMFs.Add(mf);
                    }
                }
            }

            //максимумы
            incMFs.Sort();
            decMFs.Sort();
            stabMFs.Sort();
            Inc = incMFs.Count > 0 ? incMFs[incMFs.Count - 1] : 0.0;
            Dec = decMFs.Count > 0 ? decMFs[decMFs.Count - 1] : 0.0;
            Stab = stabMFs.Count > 0 ? stabMFs[stabMFs.Count - 1] : 0.0;
        }
    }
    /// <summary>
    /// Нечеткая тенденция
    /// </summary>
    public class FuzzyTend
    {

        /// <summary>
        /// Базовый тип тенденции
        /// </summary>
        public BaseTendType BaseType;

        /// <summary>
        /// Нечеткая метка базового типа
        /// </summary>
        public FuzzyTerm FBaseType;

        /// <summary>
        /// тип тенденции, то есть нечеткая метка для типа тенденции
        /// </summary>
        public FuzzyTerm Type;

        /// <summary>
        /// Интенсивность, нечеткая метка
        /// </summary>
        public FuzzyTerm Intensity;

        /// <summary>
        /// Принадлежность временному ряду, ограниченному dt
        /// </summary>
        public double MF;

        /// <summary>
        /// Интенсивность, степень изменения тенденции (тоже принадлежность)
        /// </summary>
        public double IntensityMF;

        /// <summary>
        /// Продолжительность (по времени, зависит от единицы изм в исходном ряду)
        /// </summary>
        public double Duration = 1;

        /// <summary>
        /// Индекс начальной точки тенденции в массиве точек
        /// </summary>
        public int Start;

        /// <summary>
        /// Индекс конечной точки тенденции в массиве точек, основная точка
        /// </summary>
        public int End;

        /// <summary>
        /// Четкое значение тенденции, может отсутствовать
        /// </summary>
        public double CrispValue;

        /// <summary>
        /// Вычисленное четкое значение для вывода по мамдами (Интенсивность).
        /// </summary>
        public double RTendCrisp;

        /// <summary>
        /// Дефазифицированное четкое значение разности.
        /// </summary>
        public double DefuzzyCrisp;

        /// <summary>
        /// Вычисленное четкое значение для вывода по мамдами (тип).
        /// </summary>
        public double TTendCrisp;

        //функции прин для трех типов тенденций
        public TendMF TendTypeMFs;

        public FuzzyTend(BaseTendType baseType, FuzzyTerm type, FuzzyTerm intensity, double mf, double intensityMF, double duration, int start, int end, double crispValue)
        {
            BaseType = baseType;
            Type = type;
            MF = mf;
            Intensity = intensity;
            IntensityMF = intensityMF;
            Duration = duration;
            Start = start;
            End = end;
            CrispValue = crispValue;
        }

        public FuzzyTend(BaseTendType baseType, FuzzyTerm type, FuzzyTerm intensity, double mf, double intensityMF, double duration, int start, int end)
            : this(baseType, type, intensity, mf, intensityMF, duration, start, end, 0)
        {
        }

        public FuzzyTend(FuzzyTend tend)
        {
            BaseType = tend.BaseType;
            FBaseType = tend.FBaseType;
            Type = tend.Type;
            MF = tend.MF;
            Intensity = tend.Intensity;
            IntensityMF = tend.IntensityMF;
            Duration = tend.Duration;
            Start = tend.Start;
            End = tend.End;
            CrispValue = tend.CrispValue;
            TendTypeMFs = tend.TendTypeMFs;
        }

        public static BaseTendType GetTendType(int diffIndex)
        {
            if (diffIndex == 0)
            {
                return BaseTendType.Stability;
            }
            return diffIndex > 0 ? BaseTendType.Increase : BaseTendType.Decrease;
        }

        public static FuzzyTerm GetTendType(int indexDiff, FuzzyScale scale)
        {
            if (indexDiff == 0)
            {
                return scale.Grades.Terms[1];
            }
            return indexDiff > 0 ? scale.Grades.Terms[2] : scale.Grades.Terms[0];
        }

        public static FuzzyTerm GetTendInt(int diffIndex, FuzzyScale scale, int ISP)
        {
            var iIndex = Math.Abs(diffIndex) + ISP;// +scale.CountExtraTerms;
            if (iIndex >= scale.Grades.Terms.Count)
            {
                iIndex = scale.Grades.Terms.Count - 1;
            }
            return scale.Grades.Terms[iIndex];
        }

        public double GetSign(BaseTendType tendType)
        {
            switch (tendType)
            {
                case BaseTendType.Increase:
                    return +1;
                case BaseTendType.Decrease:
                    return -1;
                case BaseTendType.Stability:
                    return 0;
                default:
                    throw new ArgumentOutOfRangeException("tendType");
            }
        }

        public FuzzyTend(ACLScale scale, FTSPoint pt1, FTSPoint pt2)
        {
            if (pt1 == null)
                pt1 = pt2;
            CrispValue = pt2.point.Y - pt1.point.Y;

            MF = Math.Min(pt2.MF, pt1.MF);
            //var minMF = Math.Min(pt2.MF, pt1.MF);

            TendTypeMFs = new TendMF(pt1, pt2);

            ////формируем входные данные для вывода типа тенденции по мамдами
            //var inputValuesTTend = new Dictionary<FuzzyVariable, double>();
            //inputValuesTTend.Add(scale.fvInputsTTend[0], scale.fvInputsTTend[0].GetCorrectValue(pt1.point.Y));
            //inputValuesTTend.Add(scale.fvInputsTTend[1], scale.fvInputsTTend[1].GetCorrectValue(pt2.point.Y));

            ////применяем вывод по мамдами для получения типа тенденции
            //var tCmf = scale.MFSTTends.CalculateFuzzy(inputValuesTTend)[scale.fvOutputTTend];
            //var tResult = scale.TendBaseTypesScale.GetResult((CompositeMembershipFunction)tCmf);
            //var tendCrisp = scale.MFSTTends.Calculate(inputValuesTTend)[scale.fvOutputTTend];

            ////формируем входные данные для вывода интенсивности тенденции по мамдами
            //var inputValuesRTend = new Dictionary<FuzzyVariable, double>();
            //inputValuesRTend.Add(scale.fvInputsRTend[0], scale.fvInputsRTend[0].GetCorrectValue(pt1.point.Y));
            //inputValuesRTend.Add(scale.fvInputsRTend[1], scale.fvInputsRTend[1].GetCorrectValue(pt2.point.Y));

            ////применяем вывод по мамдами для получения интенсивности тенденции 
            //var rCmf = scale.MFSRTends.CalculateFuzzy(inputValuesRTend)[scale.fvOutputRTend];
            //var rResult = scale.TendIntensityScale.GetResult((CompositeMembershipFunction)rCmf);
            //var iCrisp = scale.MFSRTends.Calculate(inputValuesRTend)[scale.fvOutputRTend];

            //var maxMF = 0.0;
            //foreach (var pair in rResult)
            //{
            //    if (pair.Value > maxMF)
            //        maxMF = pair.Value;
            //}

            //var intF = scale.TendIntensityScale.GetTermWithMaxMF(iCrisp);

            ////принадлежность интенсивности - выбирается максимальная
            //IntensityMF = maxMF;

            //получаем базовый тип тенденции по разности индексов НМ
            var diffIndex = pt2.Index - pt1.Index;
            BaseType = GetTendType(diffIndex);
            FBaseType = GetTendType(diffIndex, scale.TendBaseTypesScale);

            //еще один тип тенденции - терм с макс фуркцией принадлежности
            Type = scale.TendBaseTypesScale.GetTermWithMaxMF(CrispValue);

            //#warning Спорный вопрос!!!
            //IntensityMF = 2 * MF - 1;
            //получаем нечетк интенсиность по разности индексов НМ
            Intensity = GetTendInt(diffIndex, scale.TendIntensityScale, scale.ISP);
            IntensityMF = scale.TendIntensityScale.GetMaxMembership(Math.Abs(CrispValue));
            //RTendCrisp = scale.TendIntensityScale.GetMaxMembership(diffCrisp);
            List<double> valuesRTend = ((IMembershipFunctionExt)Intensity.MembershipFunction).GetCrisp(IntensityMF);
            RTendCrisp = Math.Max(valuesRTend[0], valuesRTend[1]);

            List<double> valuesTTend = ((IMembershipFunctionExt)FBaseType.MembershipFunction).GetCrisp(MF);
            TTendCrisp = Math.Max(valuesTTend[0], valuesTTend[1]);

            //получаем дефазиф значение разности (интенсивности) (со знаком)
            DefuzzyCrisp = GetSign(BaseType) * GenericFuzzySystem.Defuzzify(DefuzzificationMethod.Centroid,
                                                        Intensity.MembershipFunction, scale.TendIntensityScale.Min,
                                                        scale.TendIntensityScale.Max);
            Start = pt1.Index;
            End = pt2.Index;
        }

        public static List<FuzzyTerm> GetBaseTTendTerms(
            double min, 
            double max, 
            double len, 
            bool isAbsolute, 
            double middleTendScale, 
            out double d)
        {
            const int count = 3;

            //(3.0 / 4)
            double iLength = 0.0;

            if (!isAbsolute)
            {
                iLength = Math.Abs(max - min) / (count - 1);
                max = max + iLength / 2;
                min = min - iLength / 2;
            }
            else
            {
                iLength = len / 6;
                max = len / 2;// len * 1.5;
                min = -len / 2;// -len * 1.5;
            }

            var intervals = FuzzyScale.MakeIntervals(count, min, max);

            double x1,x2,x3,x4;

            if (!isAbsolute)
            {
                x1 = intervals[0].Mean + middleTendScale * iLength;
                x2 = intervals[1].Mean;
                x3 = intervals[1].Mean;
                x4 = intervals[2].Mean - middleTendScale * iLength;
            }
            else
            {
                x1 = intervals[0].Mean + (3 * middleTendScale - 1) * iLength;
                x2 = intervals[1].Mean;
                x3 = intervals[1].Mean;
                x4 = intervals[2].Mean - (3 * middleTendScale - 1) * iLength;
            }

            double bx1 = x1;
            double bx4 = x4;

            d = Math.Abs(x1 - x4);

            var stab = new FuzzyTerm("Стабильность",
              new TrapezoidMembershipFunction(x1, x2, x3, x4));

            x3 = bx1;
            x2 = -len;
            x1 = x2;
            x4 = intervals[1].Mean;

            var dec = new FuzzyTerm("Падение",
              new TrapezoidMembershipFunction(x1, x2, x3, x4));

            x2 = bx4;
            x1 = intervals[1].Mean;
            x3 = +len;
            x4 = x3;

            var inc = new FuzzyTerm("Рост",
              new TrapezoidMembershipFunction(x1, x2, x3, x4));

            var terms = new List<FuzzyTerm> { dec, stab, inc };
            return terms;
        }

        public string GetBaseType()
        {
            switch (BaseType)
            {
                case BaseTendType.Increase:
                    return "Рост";
                case BaseTendType.Decrease:
                    return "Падение";
                case BaseTendType.Stability:
                    return "Стабильность";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
