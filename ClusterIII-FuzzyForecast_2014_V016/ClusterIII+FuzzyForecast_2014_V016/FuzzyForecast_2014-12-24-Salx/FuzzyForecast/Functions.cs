using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ZedGraph;
using System.IO;
using FuzzyLibrary;

namespace FuzzyForecast
{

    public enum FunctionsTypes { Linear, Square, Log, Sin, Cos, Random, User }
    public enum IntervalBorderTypes { Inclusive, NotInclusive }

    /// <summary>
    /// Атрибуты функции
    /// </summary>
    public class FuncAttr
    {
        public double start;
        public double step;
        public double count;
        public double noise;
        public double spread = 1;

        public FuncAttr() { }

        public FuncAttr(double start, double step, double count, double noise, double spread)
        {
            this.start = start;
            this.step = step;
            this.count = count;
            this.noise = noise;
            this.spread = spread;
        }

        public FuncAttr(double start, double step, double count)
        {
            this.start = start;
            this.step = step;
            this.count = count;
        }

        public XmlElement ToXmlElement(XmlDocument xmlDocument)
        {
            var xmlElement = xmlDocument.CreateElement("Attr");
            xmlElement.SetAttribute("start", start.ToString());
            xmlElement.SetAttribute("step", step.ToString());
            xmlElement.SetAttribute("count", count.ToString());
            xmlElement.SetAttribute("noise", noise.ToString());
            xmlElement.SetAttribute("spread", spread.ToString());
            return xmlElement;
        }

        public void FormXmlElement(XmlElement xmlElement)
        {
            double.TryParse(xmlElement.GetAttribute("start"), out start);
            double.TryParse(xmlElement.GetAttribute("step"), out step);
            double.TryParse(xmlElement.GetAttribute("count"), out count);
            double.TryParse(xmlElement.GetAttribute("noise"), out noise);
            double.TryParse(xmlElement.GetAttribute("spread"), out spread);
        }
    }

    /// <summary>
    /// Интервал на четком ряде чисел (вещественных)
    /// </summary>
    public class Interval
    {
        public IntervalBorderTypes StartType = IntervalBorderTypes.Inclusive;
        public IntervalBorderTypes EndType = IntervalBorderTypes.Inclusive;
        public double Start;
        public double Lenght
        {
            get { return End - Start; }
        }
        public double End;
        public double Mean
        {
            get
            {
                return (End + Start) / 2;
            }
        }

        public Interval(IntervalBorderTypes startType, double start, IntervalBorderTypes endType, double end)
        {
            Start = start;
            StartType = startType;
            End = end;
            EndType = endType;
        }

        public bool InInterval(double point)
        {
            if (StartType == IntervalBorderTypes.Inclusive && EndType == IntervalBorderTypes.Inclusive)
            {
                return (point >= Start && point <= End);
            }
            if (StartType == IntervalBorderTypes.Inclusive && EndType == IntervalBorderTypes.NotInclusive)
            {
                return (point >= Start && point < End);
            }
            if (StartType == IntervalBorderTypes.NotInclusive && EndType == IntervalBorderTypes.Inclusive)
            {
                return (point > Start && point <= End);
            }
            if (StartType == IntervalBorderTypes.NotInclusive && EndType == IntervalBorderTypes.NotInclusive)
            {
                return (point > Start && point < End);
            }
            return false;
        }

        public override string ToString()
        {
            string result = "";
            if (StartType == IntervalBorderTypes.Inclusive)
            {
                result += "[";
            }
            else if (StartType == IntervalBorderTypes.NotInclusive)
            {
                result += "(";
            }
            result += Start.ToString(Calc.DFormat) + " ; " + End.ToString(Calc.DFormat);
            if (EndType == IntervalBorderTypes.Inclusive)
            {
                result += "]";
            }
            else if (EndType == IntervalBorderTypes.NotInclusive)
            {
                result += ")";
            }
            return result;
        }
    }

    /// <summary>
    /// Временной ряд
    /// </summary>
    public class Series
    {

        public FuncAttr Attr = new FuncAttr(0, 1, 100);
        public FunctionsTypes Type = FunctionsTypes.Linear;
        public List<double> Coeffs = new List<double>(new double[] { 0, 0, 0 });
        //TODO:Временные переменные
        /// <summary>
        /// тип ряда
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// прогноз
        /// </summary>
        public int ForecastCount { get; set; }

        public SPointList pointList;

        public SPointList PointList
        {
            get { return pointList; }
            set
            {
                pointList = value;
                Attr.count = pointList.Count;
                if (pointList.Count > 0)
                {
                    Attr.start = pointList[0].X;
                }
                if (pointList.Count > 1)
                {
                    Attr.step = Math.Abs(pointList[1].X - pointList[0].X);
                }
            }
        }

        public object Tag { get; set; }

        public Series() { }

        public Series(SPointList points)
        {
            Type = FunctionsTypes.User;
            PointList = points;
        }

        public static double Noise(Random r, double noiseModule)
        {
            double noise = noiseModule * (r.NextDouble() - r.NextDouble());
            return noise;
        }

        public void CalcFunction()
        {
            if (Type == FunctionsTypes.User)
                return;
            var newPointList = CalcFunction(Type, Attr, Coeffs);
            if (pointList != null)
            {
                newPointList.Name = pointList.Name;
                newPointList.XName = pointList.XName;
                newPointList.YName = pointList.YName;
            }
            PointList = newPointList;
        }

        public static SPointList CalcFunction(FunctionsTypes type, FuncAttr fattr, IList<double> coeffs)
        {
            var list = new SPointList();
            double x = fattr.start;
            var r = new Random();

            for (int i = 0; i < fattr.count; i++)
            {
                double y;
                switch (type)
                {
                    case FunctionsTypes.Linear:
                        y = coeffs[0] * x + coeffs[1] + Noise(r, fattr.noise);
                        break;
                    case FunctionsTypes.Square:
                        y = coeffs[0] * x * x + coeffs[1] * x + coeffs[2] + Noise(r, fattr.noise);
                        break;
                    case FunctionsTypes.Log:
                        y = coeffs[0] * Math.Log(coeffs[1] * x) + Noise(r, fattr.noise);
                        break;
                    case FunctionsTypes.Sin:
                        y = coeffs[0] * Math.Sin(coeffs[1] * x) + Noise(r, fattr.noise);
                        break;
                    case FunctionsTypes.Cos:
                        y = coeffs[0] * Math.Cos(coeffs[1] * x) + Noise(r, fattr.noise);
                        break;
                    case FunctionsTypes.Random:
                        y = fattr.spread * (r.NextDouble() - r.NextDouble());
                        break;
                    default:
                        y = 0;
                        break;
                }

                list.Add(new SPoint(x, y));
                x = x + fattr.step;
            }
            return list;
        }
        /// <summary>
        /// Загрузка данных из файла
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool LoadFormFile(string FileName)
        {
#warning qweqweqweqwe

            ;

            PointList = new SPointList();

            Type = FunctionsTypes.User;

            if (!File.Exists(FileName))
                return false;

            var sr = new StreamReader(FileName);
            string src;
            try
            {
                src = sr.ReadToEnd();
            }
            catch
            {
                return false;
            }
            var strR = new StringReader(src);

            string line;
            //первая строчка файла
            if (strR.Peek() >= 0)
                line = strR.ReadLine();
            else
                return false;
            this.ForecastCount = int.Parse(line.Split(' ')[0]);
            if (line.Split(' ').Length > 1)
                this.type = line.Split(new char[] { ' ' }, 2)[1].Trim();
            double dim = 0;
            //double.TryParse(line, out dim);

            //вторая строчка файла
            if (strR.Peek() >= 0)
                line = strR.ReadLine();
            else
                return false;

            double countPoints;
            double.TryParse(line, out countPoints);
            Attr.count = countPoints;

            int i = 0;
            while (strR.Peek() >= 0)
            {
                line = strR.ReadLine();
                line = line.Replace('.', ',');
                string[] splitStrings = line.Split('\t', ' ');

                var strings = new List<string>(splitStrings);
                strings.RemoveAll(s => (s == ""));

                if (strings.Count >= 2)
                {
                    double x;
                    double y;
                    double.TryParse(strings[0], out x);
                    double.TryParse(strings[1], out y);

                    PointList.Add(new SPoint(x, y));
                    if (i == 0)
                    {
                        Attr.start = x;
                    }
                    else if (i == 1)
                    {
                        Attr.step = x - Attr.start;
                    }
                    i++;
                }
                else if ((dim == 1) && (strings.Count >= 1))
                {
                    double y;
                    double.TryParse(strings[0], out y);
                    PointList.Add(new SPoint(i, y));
                    if (i == 0)
                    {
                        Attr.start = i;
                    }
                    else if (i == 1)
                    {
                        Attr.step = i - Attr.start;
                    }
                    i++;
                }
            }
            Attr.count = i;
            PointList.Name = Path.GetFileNameWithoutExtension(FileName);
            return true;
        }

        public static bool Save(SPointList sPointList, string fileName)
        {
            try
            {
                var sw = new StreamWriter(fileName, false, Encoding.Default);
                sw.WriteLine("2");
                sw.WriteLine(sPointList.Count);
                foreach (var point in sPointList)
                {
                    var xStr = point.X.ToString(Calc.DFormat);
                    var yStr = point.Y.ToString(Calc.DFormat);
                    xStr = xStr.Replace(",", ".");
                    yStr = yStr.Replace(",", ".");
                    sw.WriteLine(xStr + "\t" + yStr);
                }
                sw.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            string result = "";
            if (PointList == null)
                return result;
            foreach (SPoint p in PointList)
            {
                result += p.Y.ToString(Calc.DFormat) + " ";
            }
            return result;
        }

        public static PointPairList ToPointPairList(SPointList list)
        {
            var ppList = new PointPairList();
            foreach (SPoint pt in list)
            {
                ppList.Add(pt.X, pt.Y);
            }
            return ppList;
        }

        public static SPointList ToSpointList(PointPairList list)
        {
            var spList = new SPointList();
            if (list == null)
                return spList;
            foreach (PointPair pt in list)
            {
                spList.Add(new SPoint(pt.X, pt.Y));
            }
            return spList;
        }

        public XmlElement ToXmlElement(XmlDocument xmlDocument)
        {
            var xmlElement = xmlDocument.CreateElement("Series");
            xmlElement.SetAttribute("Name", pointList.Name);
            xmlElement.SetAttribute("XName", pointList.XName);
            xmlElement.SetAttribute("YName", pointList.YName);
            foreach (var point in pointList)
            {
                var xmlElementPoint = xmlDocument.CreateElement("Point");
                xmlElementPoint.SetAttribute("X", point.X.ToString());
                xmlElementPoint.SetAttribute("Y", point.Y.ToString());
                xmlElement.AppendChild(xmlElementPoint);
            }
            return xmlElement;
        }

        public void FromXmlElement(XmlElement xmlElement)
        {
            var pList = new SPointList();
            Type = FunctionsTypes.User;
            pList.Name = xmlElement.GetAttribute("Name");
            pList.XName = xmlElement.GetAttribute("XName");
            pList.YName = xmlElement.GetAttribute("YName");
            XmlNodeList xmlNodePoints = xmlElement.GetElementsByTagName("Point");
            foreach (XmlElement xmlNodePoint in xmlNodePoints)
            {
                var sPoint = new SPoint();
                double.TryParse(xmlNodePoint.GetAttribute("X"), out sPoint.X);
                double.TryParse(xmlNodePoint.GetAttribute("Y"), out sPoint.Y);
                pList.Add(sPoint);
            }
            PointList = pList;
        }
    }
}
