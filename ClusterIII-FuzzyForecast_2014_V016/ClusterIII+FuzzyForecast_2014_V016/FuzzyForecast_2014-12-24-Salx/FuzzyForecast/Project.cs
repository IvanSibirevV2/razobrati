using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using FuzzyLibrary;

namespace FuzzyForecast
{
    public class Project
    {
        public string Name;
        public string FileName;

        public bool WasChanged = false;

        public List<ModelSeries> seriesList = new List<ModelSeries>();

        public bool IsEmpty
        {
            get { return seriesList.Count == 0; }
        }

        public Project(string name)
        {
            Name = name;
        }

        private XmlElement ToXmlElement(XmlDocument xmlDocument)
        {
            XmlElement xmlElementProject = xmlDocument.CreateElement("Project");

            xmlElementProject.SetAttribute("Name", Name);

            XmlElement xmlElementSeries = xmlDocument.CreateElement("SeriesList");
            foreach (var ms in seriesList)
            {
                xmlElementSeries.AppendChild(ms.ToXmlElement(xmlDocument));
            }
            xmlElementProject.AppendChild(xmlElementSeries);

            return xmlElementProject;
        }

        private void FromXmlElement(XmlElement xmlElement)
        {
            seriesList.Clear();
            Name = xmlElement.GetAttribute("Name");

            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName("ModelSeries");
            IEnumerator ie = xmlNodeList.GetEnumerator();
            while (ie.MoveNext())
            {
                var ms = new ModelSeries();
                ms.FromXmlElement((XmlElement)ie.Current);
                ms.Set();
                seriesList.Add(ms);
            }
        }

        private XmlDocument CreateXmlDocument()
        {
            var xmlDoc = new XmlDocument();
            XmlElement rootElement = xmlDoc.CreateElement("ProjectInformation");
            xmlDoc.AppendChild(rootElement);
            rootElement.SetAttribute("Source", FileName);
            return xmlDoc;
        }

        public void SaveXmlDocument()
        {
            XmlTextWriter xmlWriter = null;
            FileStream fout = null;
            XmlDocument xmlDoc;
            try
            {
                xmlDoc = SaveInformation();
                fout = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                xmlWriter = new XmlTextWriter(fout, Encoding.UTF8) { Formatting = Formatting.Indented };
                xmlDoc.Save(xmlWriter);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка обработки файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (xmlWriter != null)
                {
                    xmlWriter.Close();
                }
                if (fout != null)
                {
                    fout.Close();
                }
            }
        }

        public bool LoadXmlDocument()
        {
            XmlTextReader xmlTextReader = null;
            FileStream fin = null;
            bool result = true;
            try
            {
                if (!File.Exists(FileName))
                {
                    SaveXmlDocument();
                }
                fin = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                xmlTextReader = new XmlTextReader(fin);
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlTextReader);
                LoadInformation(xmlDoc);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка обработки файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            finally
            {
                if (xmlTextReader != null)
                {
                    xmlTextReader.Close();
                }
                if (fin != null)
                {
                    fin.Close();
                }
            }
            return result;
        }

        private XmlDocument SaveInformation()
        {
            XmlDocument xmlDoc = CreateXmlDocument();
            if (xmlDoc.DocumentElement != null)
                xmlDoc.DocumentElement.AppendChild(ToXmlElement(xmlDoc));
            return xmlDoc;
        }

        private void LoadInformation(XmlDocument xmlDoc)
        {
            if (xmlDoc.DocumentElement != null)
            {
                XmlNodeList xmlNodeList = xmlDoc.DocumentElement.GetElementsByTagName("Project");
                IEnumerator i = xmlNodeList.GetEnumerator();
                i.MoveNext();
                FromXmlElement((XmlElement)i.Current);
            }
        }

        public static void AddFieldElement(XmlDocument xmlDocument, XmlNode parentNode, string name, string innerText)
        {
            XmlElement xmlElement = xmlDocument.CreateElement(name);
            xmlElement.InnerText = innerText;
            parentNode.AppendChild(xmlElement);
        }

        public static string GetFieldElement(XmlElement parent, string name)
        {
            string innerText = "";
            XmlNodeList xmlNodeList = parent.GetElementsByTagName(name);
            IEnumerator i = xmlNodeList.GetEnumerator();
            i.MoveNext();
            if (i.Current as XmlElement != null)
            {
                innerText = ((XmlElement)i.Current).InnerText;
            }
            return innerText;
        }

        public static XmlElement GetXmlElement(XmlElement parent, string name)
        {
            XmlNodeList xmlNodeList = parent.GetElementsByTagName(name);
            IEnumerator i = xmlNodeList.GetEnumerator();
            i.MoveNext();
            if (i.Current as XmlElement != null)
            {
                return (XmlElement)i.Current;
            }
            return null;
        }

        public bool CheckFileName()
        {
            return !string.IsNullOrEmpty(FileName);
        }

        /*public static void SaveTableToHTML<T>(string fileName, string styleLoc, List<T> ResultRows) {
          TextWriter writer = null;
          try {
            writer = new StreamWriter(fileName, false, Encoding.Default);
            var msS = new MemoryStream();
            var xs = new XmlSerializer(typeof(List<T>));
            xs.Serialize(new StreamWriter(msS, Encoding.Default), ResultRows);
            msS.Flush();
            msS.Position = 0;
            var xslt = new XslCompiledTransform();
            xslt.Load(styleLoc);
            var xmlWriterSettings = new XmlWriterSettings {
              Encoding = Encoding.Default,
              Indent = true,
              OmitXmlDeclaration = true
            };
            var xmlWriter = XmlWriter.Create(writer, xmlWriterSettings);
            if (xmlWriter != null)
              xslt.Transform(XmlReader.Create(new StreamReader(msS, Encoding.Default)), xmlWriter);
          } catch (Exception ex) {
            MessageBox.Show("Ошибка обработки файла\r\n" + ex.Message);
          } finally {
            if (writer != null) {
              writer.Close();
            }
          }
        }*/

        public static void SaveToXML<T>(string fileName, T Report)
        {
            TextWriter writer = null;
            try
            {
                writer = new StreamWriter(fileName, false, Encoding.Default);
                var xs = new XmlSerializer(typeof(T));
                xs.Serialize(writer, Report);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обработки файла\r\n" + ex.Message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public static void SaveToHTML<T>(string fileName, string styleLoc, T Report)
        {
            TextWriter writer = null;
            try
            {
                writer = new StreamWriter(fileName, false, Encoding.Default);
                var msS = new MemoryStream();
                var xs = new XmlSerializer(typeof(T));
                xs.Serialize(new StreamWriter(msS, Encoding.Default), Report);
                msS.Flush();
                msS.Position = 0;
                var xslt = new XslCompiledTransform();
                xslt.Load(styleLoc);
                var xmlWriterSettings = new XmlWriterSettings
                {
                    Encoding = Encoding.Default,
                    Indent = true,
                    OmitXmlDeclaration = true
                };
                var xmlWriter = XmlWriter.Create(writer, xmlWriterSettings);
                if (xmlWriter != null)
                    xslt.Transform(XmlReader.Create(new StreamReader(msS, Encoding.Default)), xmlWriter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обработки файла\r\n" + ex.Message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }

    public class ModelSeries
    {
        public Series series = new Series();
        public ACLTimeSeries ACLSeries;
        public List<ModelResult> Results = new List<ModelResult>();

        public ModelSeries()
        {
        }

        public void Set()
        {
            if (Results.Count == 0)
            {
                var mr = new ModelResult(ACLSeries, ForecastModelType.None, null);
                Results.Add(mr);
            }
        }

        public ModelSeries(Series series, ACLTimeSeries ats)
        {
            this.series = series;
            ACLSeries = ats;
            Set();
        }

        public void Update(ACLTimeSeries ats)
        {
            ACLSeries = ats;
            foreach (var modelResult in Results)
            {
                modelResult.Update(ats);
            }
        }

        public override string ToString()
        {
            return series.PointList.Name;
        }

        public List<CompareRow> CompareModels()
        {
            var comrareTable = new List<CompareRow>();

            foreach (var result in Results)
            {
                var row = new CompareRow();

                if (result.ForecastModel == null)
                    continue;

                row.Model = ForecastHelper.GetExtModelName(result.ForecastModel);
                row.iMSE = result.ModelReport.Errors[0].MSE;
                row.iMAPE = result.ModelReport.Errors[0].MAPE;
                row.eMSE = result.ModelReport.Errors[1].MSE;
                row.eMAPE = result.ModelReport.Errors[1].MAPE;
                row.iFPE = result.ModelReport.FErrors[0].FPE;
                row.iTFPE = result.ModelReport.FErrors[0].TTendFPE;
                row.iRFPE = result.ModelReport.FErrors[0].RTendFPE;
                row.eFPE = result.ModelReport.FErrors[1].FPE;
                row.eTFPE = result.ModelReport.FErrors[1].TTendFPE;
                row.eRFPE = result.ModelReport.FErrors[1].RTendFPE;

                comrareTable.Add(row);
            }

            return comrareTable;
        }

        public XmlElement ToXmlElement(XmlDocument xmlDocument)
        {
            var xmlElementMS = xmlDocument.CreateElement("ModelSeries");

            var xmlElementSeries = series.ToXmlElement(xmlDocument);
            xmlElementMS.AppendChild(xmlElementSeries);

            var xmlElementACLInfo = ACLSeries.Scale.ToXmlElement(xmlDocument);
            xmlElementMS.AppendChild(xmlElementACLInfo);

            var xmlElementModels = xmlDocument.CreateElement("Models");
            foreach (var result in Results)
            {
                var xmlElementModel = result.ToXmlElement(xmlDocument);
                xmlElementModels.AppendChild(xmlElementModel);
            }

            xmlElementMS.AppendChild(xmlElementModels);

            return xmlElementMS;
        }

        public void FromXmlElement(XmlElement xmlElement)
        {
            XmlElement xmlElementSeries = Project.GetXmlElement(xmlElement, "Series");
            var s = new Series();
            s.FromXmlElement(xmlElementSeries);
            series = s;

            var aclScale = new ACLScale("ACL шкала", s.PointList.FindMin().Y, s.PointList.FindMax().Y,
                                             ACLScale.typesNamesDefault);
            XmlElement xmlElementScale = Project.GetXmlElement(xmlElement, "ACLScale");

            aclScale.FromXmlElement(xmlElementScale);
            //aclScale.InnerSimpleFuzzification(s.PointList);
            ACLSeries = new ACLTimeSeries(aclScale, s.PointList);
            Set();
            var xmlElementModels = Project.GetXmlElement(xmlElement, "Models");
            XmlNodeList xmlNodeList = xmlElementModels.GetElementsByTagName("ForecastModel");
            IEnumerator ie = xmlNodeList.GetEnumerator();
            while (ie.MoveNext())
            {
                var xmlElementModel = (XmlElement)ie.Current;
                var mr = new ModelResult(ACLSeries, ForecastModelType.None, null);
                mr.FromXmlElement(xmlElementModel);
                Results.Add(mr);
            }
        }
    }

    public class CompareRow
    {
        public string Model;
        public double iMSE;
        public double iMAPE;
        public double iFPE;
        public double iTFPE;
        public double iRFPE;
        public double eMSE;
        public double eMAPE;
        public double eFPE;
        public double eTFPE;
        public double eRFPE;
    }

    public class CrispResultRow
    {
        public string Time;
        public string Series;
        public string Model;
        public string Error;
        public string RError;
        public string Diff;
        public string ModelDiff;
    }

    public class FuzzyResultRow
    {
        public string Time;
        public string Series;
        public string MF;
        public string FT;
        public string ModelFT;
        public string FTError;
        public string TTend;
        public string ModelTTend;
        public string TError;
        public string RTend;
        public string ModelRTend;
        public string RError;
    }

    public class CrispNResultRow
    {
        public string Time;
        public string Series;
        public string Diff;
    }

    public class FuzzyNResultRow
    {
        public string Time;
        public string Series;
        public string MF;
        public string FT;
        public string TTend;
        public string RTend;
    }

    public class ErrorRow
    {
        #warning Модель Ошибки
        public double MSE;
        public double RMSE;
        public double MAPE;
        public double SMAPE;
        public double R2;
        public double D;
        public double Dispersion;
    }

    public class FuzzyErrorRow
    {
        public double FPE;
        public string FCE;
        public double TTendFPE;
        public string TTendFCE;
        public double RTendFPE;
        public string RTendFCE;
    }

    public class RuleRow
    {
        public string Number;
        public string Rule;
        public string Count;
    }

    public class RuleMFRow
    {
        public string Number;
        public string Rule;
        public string MF;
    }

    public class Report<TC, TF>
    {
        public List<TC> ResultCrisp = new List<TC>();
        public List<TF> ResultFuzzy = new List<TF>();
        public List<ErrorRow> Errors = new List<ErrorRow>();
        public List<FuzzyErrorRow> FErrors = new List<FuzzyErrorRow>();
        public List<RuleRow> RuleSeries = new List<RuleRow>();
        public List<RuleRow> RuleTTend = new List<RuleRow>();
        public List<RuleRow> RuleRTend = new List<RuleRow>();

        public List<RuleMFRow> RuleMFSeries = new List<RuleMFRow>();
        public List<RuleMFRow> RuleMFTTend = new List<RuleMFRow>();
        public List<RuleMFRow> RuleMFRTend = new List<RuleMFRow>();
        public string ModelInfo;
        public string ACLInfo;
        public List<SPointList> PointLists = new List<SPointList>();
    }

    /// <summary>
    /// Представление результатов применения моделей прогнозирования
    /// </summary>
    public class ModelResult
    {
        

        public static string[] ColumnNameAllModelC = {
                                                   "Время", "Ряд", "Модель", "Ошибка", "Отн. Ошибка", "Разность", "Модель Разность"
                                                 };

        public static string[] ColumnNameAllModelF = {
                                                   "Время", "Ряд", "ФП", "НМ", "Модель НМ", "Ошибка", "TTend",
                                                   "Модель TTend", "Ошибка", "RTend", "Модель RTend", "Ошибка"
                                                 };

        public static string[] ColumnNameNoneModelC = { "Время", "Ряд", "Разность" };


        public static string[] ColumnNameNoneModelF = { "Время", "Ряд", "ФП", "НМ", "TTend", "RTend" };

        public ForecastModelType ModelType = ForecastModelType.None;

        public string NameOfModel
        {
            get { return GetModelName(ModelType); }
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

        public Report<CrispResultRow, FuzzyResultRow> ModelReport;
        public Report<CrispNResultRow, FuzzyNResultRow> SeriesReport;

        public List<string> ColumnNamesCrisp
        {
            get
            {
                switch (ModelType)
                {
                    case ForecastModelType.None:
                        return new List<string>(ColumnNameNoneModelC);
                    case ForecastModelType.Song:
                        return new List<string>(ColumnNameAllModelC);
                    case ForecastModelType.Neural:
                        return new List<string>(ColumnNameAllModelC);
                    case ForecastModelType.D:
                        return new List<string>(ColumnNameAllModelC);
                    case ForecastModelType.Tend:
                        return new List<string>(ColumnNameAllModelC);
                    case ForecastModelType.F:
                        return new List<string>(ColumnNameAllModelC);
                    case ForecastModelType._F:
                        return new List<string>(ColumnNameAllModelC);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public List<string> ColumnNamesFuzzy
        {
            get
            {
                switch (ModelType)
                {
                    case ForecastModelType.None:
                        return new List<string>(ColumnNameNoneModelF);
                    case ForecastModelType.Song:
                        return new List<string>(ColumnNameAllModelF);
                    case ForecastModelType.Neural:
                        return new List<string>(ColumnNameAllModelF);
                    case ForecastModelType.D:
                        return new List<string>(ColumnNameAllModelF);
                    case ForecastModelType.Tend:
                        return new List<string>(ColumnNameAllModelF);
                    case ForecastModelType.F:
                        return new List<string>(ColumnNameAllModelF);
                    case ForecastModelType._F:
                        return new List<string>(ColumnNameAllModelF);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public IForecastModel ForecastModel;

        public ACLTimeSeries aclSeries;

        public List<SPointList> PointLists
        {
            get
            {
                if (ModelReport != null)
                    return ModelReport.PointLists;
                return SeriesReport.PointLists;
            }
        }

        public List<List<string>> ResultsCrisp
        {
            get
            {
                if (ModelReport != null)
                    return GetResultsCrisp(ModelReport);
                return GetResultsCrisp(SeriesReport);
            }
        }

        public List<List<string>> ResultsFuzzy
        {
            get
            {
                if (ModelReport != null)
                    return GetResultsFuzzy(ModelReport);
                return GetResultsFuzzy(SeriesReport);
            }
        }

        public static string GetModelName(ForecastModelType forecastModel)
        {
            switch (forecastModel)
            {
                case ForecastModelType.None:
                    return "Модель отсутствует";
                case ForecastModelType.Song:
                    return "Модель Сонга";
                case ForecastModelType.Neural:
                    return "Нейросетевая модель";
                case ForecastModelType.D:
                    return "Модель Шаха-Дегтярева";
                case ForecastModelType.F:
                    return "F - модель";
                case ForecastModelType._F:
                    return "F - модель - остаток";
                case ForecastModelType.Tend:
                    return "Модель на основе Тенденций";
                default:
                    throw new ArgumentOutOfRangeException("forecastModel");
            }
        }

        public ModelResult(ACLTimeSeries ats, ForecastModelType modelType, IForecastModel fModel)
        {
            aclSeries = ats;
            ForecastModel = fModel;
            ModelType = modelType;
            Refresh();
        }

        //Изменение в модели
        public void Update(ACLTimeSeries ats)
        {
            aclSeries = ats;
            switch (ModelType)
            {
                case ForecastModelType.None:
                    break;
                case ForecastModelType.Song:
                    ((SongForecastModel)ForecastModel).Remake(ats);
                    break;
                case ForecastModelType.Neural:
                    break;
                case ForecastModelType.D:
                    ((DForecastModel)ForecastModel).Remake(ats);
                    break;
                case ForecastModelType.Tend:
                    ((TendForecastModel)ForecastModel).Remake(ats);
                    break;
                default:
                    throw new Exception("unknown ModelType");
            }
            Refresh();
        }

        public void Refresh()
        {
            SeriesReport = aclSeries.GetReport();
            if (ForecastModel != null)
            {
                ModelReport = ForecastModel.GetReport();
            }
        }

        public void FillForecast(ListView forecastList)
        {
            int aCount = ForecastModel.Actual.Count - ForecastModel.ActualCount;
            for (int i = 0; i < aCount; i++)
            {
                var lvi = forecastList.Items.Add(i.ToString(), i.ToString());
                var listCrisp = ResultsCrisp[ForecastModel.ActualCount + i];
                var listFuzzy = ResultsFuzzy[ForecastModel.ActualCount + i];
                lvi.SubItems.Add(listCrisp[0]);
                lvi.SubItems.Add(listCrisp[1]);
                lvi.SubItems.Add(listCrisp[2]);
                lvi.SubItems.Add(listFuzzy[6]);
                lvi.SubItems.Add(listFuzzy[3]);
                lvi.SubItems.Add(listFuzzy[4]);
            }
        }

        public string Resume()
        {
            StringBuilder result = new StringBuilder();
            int dominateTend = 0;
            int totalTend = 0;
            int lastTend = 0;
            int sum = 0;
            FuzzyForecast.FuzzyTend penultTend = aclSeries.Tends[aclSeries.Tends.Count - 2];

            //---------------------------------------------------------------------
            //Информация о модели
            result.Append("Информация о модели:\n\n");
            result.Append(ModelReport.ModelInfo + "\n");
            result.Append(aclSeries.Scale.ScaleInfo + "\n");
            result.Append("d = " + aclSeries.Scale.D + "\n\n");

            //---------------------------------------------------------------------
            //Доминирующая тенденция
            int[] tendSignificance = { 0, 0, 0 };
            int[] tendCount = { 0, 0, 0 };
            IDictionary<string, int> openWith = new Dictionary<string, int>();

            foreach (FuzzyForecast.FuzzyTend tend in aclSeries.Tends)
            {
                if (tend.BaseType == BaseTendType.Increase)
                {
                    tendSignificance[0] += tend.End - tend.Start;
                    tendCount[0]++;
                }
                else if (tend.BaseType == BaseTendType.Decrease)
                {
                    tendSignificance[1] += tend.End - tend.Start;
                    tendCount[1]++;
                }
                else
                {
                    tendSignificance[2] += tend.End - tend.Start;
                    tendCount[2]++;
                }
            }
            sum = tendSignificance[0] + tendSignificance[1] + tendSignificance[2];

            result.Append("Сводная информация:\n");

            result.Append("\nТипичная элементарная тенденция:");
            if (tendSignificance[0] > tendSignificance[1] && tendSignificance[0] > tendSignificance[2])
            {
                result.Append("\n\tРост");
            }
            else if (tendSignificance[1] > tendSignificance[0] && tendSignificance[1] > tendSignificance[2])
            {
                result.Append("\n\tПадение");
            }
            else
            {
                result.Append("\n\tСтабилизация");
            }

            result.Append("\nДоминирующая элементарная тенденция:");

            if (sum == 0 && tendSignificance[0] == 0 && tendSignificance[1] == 0 && tendSignificance[2] == 0)
            {
                result.Append("\n\tСтабилизация");
                dominateTend = 2;
            }
            else if (Math.Abs(tendSignificance[0]) > Math.Abs(tendSignificance[1]) && (Math.Abs(tendSignificance[0]) - Math.Abs(tendSignificance[1])) >= 0.5 * Math.Abs(tendSignificance[0]))
            {
                result.Append("\n\tРост");
                dominateTend = 0;
            }
            else if (Math.Abs(tendSignificance[0]) < Math.Abs(tendSignificance[1]) && (Math.Abs(tendSignificance[1]) - Math.Abs(tendSignificance[0])) >= 0.5 * Math.Abs(tendSignificance[0]))
            {
                result.Append("\n\tПадение");
                dominateTend = 1;
            }
            else if (((Math.Abs(Math.Abs(tendSignificance[0]) - Math.Abs(tendSignificance[1])) <= Math.Abs(tendSignificance[0]) * 0.1) ||
                  (Math.Abs(Math.Abs(tendSignificance[1]) - Math.Abs(tendSignificance[0])) <= Math.Abs(tendSignificance[1]) * 0.1))
                  && (tendSignificance[0] != 0) && (tendSignificance[1] != 0))
            {
                result.Append("\n\tКолебание");
                dominateTend = 3;
            }

            else
            {
                result.Append("\n\tХаос");
                dominateTend = 4;
            }

            //---------------------------------------------------------------------
            //Общая тенденция ряда
            totalTend = dominateTend;
            int tmp = penultTend.End - penultTend.Start;
            if (tmp > 0)
                lastTend = 0;
            else if (tmp < 0)
                lastTend = 1;
            else
                lastTend = 2;

            if (lastTend == dominateTend || dominateTend > 2)
                totalTend = dominateTend;
            else
                if (lastTend != 2)
                    totalTend = lastTend;

            result.Append("\nРяд характеризуется общей тенденцией:");

            switch (totalTend)
            {
                case 0: result.Append("\n\tРост"); break;
                case 1: result.Append("\n\tПадение"); break;
                case 2: result.Append("\n\tСтабилизация"); break;
                case 3: result.Append("\n\tКолебание"); break;
                case 4: result.Append("\n\tХаос"); break;
            }

            //result.Append("\nСуммарные интенсивности тенденций");
            //result.Append("\n\tРост: " + tendSignificance[0].ToString());
            //result.Append("\n\tПадение: " + tendSignificance[1].ToString());
            //result.Append("\n\tСтабильность: " + tendSignificance[2].ToString());

            int mostCommonRule = -1;
            int maxRuleFrequency = -1;
            for (int i = 0; i < ModelReport.RuleTTend.Count; i++)
            {
                if (maxRuleFrequency < Convert.ToInt32(ModelReport.RuleTTend[i].Count))
                {
                    mostCommonRule = Convert.ToInt32(ModelReport.RuleTTend[i].Number);
                    maxRuleFrequency = Convert.ToInt32(ModelReport.RuleTTend[i].Count);
                }
            }
            if (mostCommonRule >= 0)
            {
                result.Append("\nТипичные правила следования элементарных тенденций: ");
                result.Append("\n\t" + ModelReport.RuleTTend[mostCommonRule].Rule);
            }

            //---------------------------------------------------------------------
            //Адекватность модели
            Dictionary<int, double> precisionFunctions;
            precisionFunctions = aclSeries.Scale.TendPrecisionScale.GetIndexesByX(
                ModelReport.Errors[0].D * 100.0);
            double maxFunctionMF = -1.0;
            int maxFunctionIndex = -1;
            foreach (KeyValuePair<int, double> pair in precisionFunctions)
            {
                if (pair.Value > maxFunctionMF)
                {
                    maxFunctionMF = pair.Value;
                    maxFunctionIndex = pair.Key;
                }
            }

            result.Append("\nАдекватность внутренней модели: ");
            result.Append("\n\t" + aclSeries.Scale.TendPrecisionScale.Grades.Terms[maxFunctionIndex].Name);
            result.Append(" (" + (ModelReport.Errors[0].D * 100.0).ToString("0.00") + "%)");

            precisionFunctions = aclSeries.Scale.TendPrecisionScale.GetIndexesByX(
                ModelReport.Errors[1].D * 100.0);
            maxFunctionMF = -1.0;
            maxFunctionIndex = -1;
            foreach (KeyValuePair<int, double> pair in precisionFunctions)
            {
                if (pair.Value > maxFunctionMF)
                {
                    maxFunctionMF = pair.Value;
                    maxFunctionIndex = pair.Key;
                }
            }

            if (maxFunctionIndex >= 0)
            {
                result.Append("\nАдекватность внешней модели: ");
                result.Append("\n\t" + aclSeries.Scale.TendPrecisionScale.Grades.Terms[maxFunctionIndex].Name);
                result.Append(" (" + (ModelReport.Errors[1].D * 100.0).ToString("0.00") + "%)");
            }
            //---------------------------------------------------------------------
            //Точность модели
            precisionFunctions = aclSeries.Scale.TendPrecisionScale.GetIndexesByX(
                ModelReport.Errors[0].MAPE > 100.0 ? 100.0 : ModelReport.Errors[0].MAPE);
            maxFunctionMF = -1.0;
            maxFunctionIndex = -1;
            foreach (KeyValuePair<int, double> pair in precisionFunctions)
            {
                if (pair.Value > maxFunctionMF)
                {
                    maxFunctionMF = pair.Value;
                    maxFunctionIndex = pair.Key;
                }
            }

            if (maxFunctionIndex >= 0)
            {
                result.Append("\nТочность внутренней модели: ");
                result.Append("\n\t" + aclSeries.Scale.TendPrecisionScale.Grades.Terms[maxFunctionIndex].Name);
                result.Append(" (" + (ModelReport.Errors[0].MAPE).ToString("0.00") + ")");
            }

            precisionFunctions = aclSeries.Scale.TendPrecisionScale.GetIndexesByX(
                ModelReport.Errors[1].MAPE > 100.0 ? 100.0 : ModelReport.Errors[1].MAPE);
            maxFunctionMF = -1.0;
            maxFunctionIndex = -1;
            foreach (KeyValuePair<int, double> pair in precisionFunctions)
            {
                if (pair.Value > maxFunctionMF)
                {
                    maxFunctionMF = pair.Value;
                    maxFunctionIndex = pair.Key;
                }
            }

            if (maxFunctionIndex >= 0)
            {
                result.Append("\nТочность внешней модели: ");
                result.Append("\n\t" + aclSeries.Scale.TendPrecisionScale.Grades.Terms[maxFunctionIndex].Name);
                result.Append(" (" + (ModelReport.Errors[1].MAPE).ToString("0.00") + ")");
            }
            return result.ToString();
        }

        public string FillGeneralTendInline()
        {
            string result = String.Empty;
            int dominateTend = 0;
            int totalTend = 0;
            int lastTend = 0;
            int sum = 0;
            FuzzyForecast.FuzzyTend penultTend = aclSeries.Tends[aclSeries.Tends.Count - 2];

            int[] tendSignificance = { 0, 0, 0 };
            foreach (FuzzyForecast.FuzzyTend tend in aclSeries.Tends)
            {
                if (tend.BaseType == BaseTendType.Increase)
                {
                    tendSignificance[0] += tend.End - tend.Start;
                }
                else if (tend.BaseType == BaseTendType.Decrease)
                {
                    tendSignificance[1] += tend.End - tend.Start;
                }
                else
                {
                    tendSignificance[2] += tend.End - tend.Start;
                }
            }
            sum = tendSignificance[0] + tendSignificance[1] + tendSignificance[2];

            if (sum == 0 && tendSignificance[0] == 0 && tendSignificance[1] == 0 && tendSignificance[2] == 0)
            {
                dominateTend = 2;
            }
            else if (Math.Abs(tendSignificance[0]) > Math.Abs(tendSignificance[1]) && (Math.Abs(tendSignificance[0]) - Math.Abs(tendSignificance[1])) >= 0.5 * Math.Abs(tendSignificance[0]))
            {
                dominateTend = 0;
            }
            else if (Math.Abs(tendSignificance[0]) < Math.Abs(tendSignificance[1]) && (Math.Abs(tendSignificance[1]) - Math.Abs(tendSignificance[0])) >= 0.5 * Math.Abs(tendSignificance[0]))
            {
                dominateTend = 1;
            }
            else if (((Math.Abs(Math.Abs(tendSignificance[0]) - Math.Abs(tendSignificance[1])) <= Math.Abs(tendSignificance[0]) * 0.1) ||
                  (Math.Abs(Math.Abs(tendSignificance[1]) - Math.Abs(tendSignificance[0])) <= Math.Abs(tendSignificance[1]) * 0.1))
                  && (tendSignificance[0] != 0) && (tendSignificance[1] != 0))
            {
                dominateTend = 3;
            }
            else
            {
                dominateTend = 4;
            }

            //Общая тенденция ряда
            totalTend = dominateTend;
            int tmp = penultTend.End - penultTend.Start;
            if (tmp > 0)
                lastTend = 0;
            else if (tmp < 0)
                lastTend = 1;
            else
                lastTend = 2;

            if (lastTend == dominateTend || dominateTend > 2)
                totalTend = dominateTend;
            else
                if (lastTend != 2)
                    totalTend = lastTend;

            result += "\nОбщая тенденция:";

            switch (totalTend)
            {
                case 0: result += "\tРост"; break;
                case 1: result += "\tПадение"; break;
                case 2: result += "\tСтабилизация"; break;
                case 3: result += "\tКолебание"; break;
                case 4: result += "\tХаос"; break;
            }

            return result;
        }

        public static List<List<string>> GetResultsCrisp(Report<CrispNResultRow, FuzzyNResultRow> report)
        {
            var result = new List<List<string>>();
            foreach (CrispNResultRow row in report.ResultCrisp)
            {
                var list = new List<string>();
                list.Add(row.Time);
                list.Add(row.Series);
                list.Add(row.Diff);
                result.Add(list);
            }
            return result;
        }

        public static List<List<string>> GetResultsFuzzy(Report<CrispNResultRow, FuzzyNResultRow> report)
        {
            var result = new List<List<string>>();
            foreach (FuzzyNResultRow row in report.ResultFuzzy)
            {
                var list = new List<string>();
                list.Add(row.Time);
                list.Add(row.Series);
                list.Add(row.MF);
                list.Add(row.FT);
                list.Add(row.TTend);
                list.Add(row.RTend);
                result.Add(list);
            }
            return result;
        }


        public static List<List<string>> GetResultsCrisp(Report<CrispResultRow, FuzzyResultRow> report)
        {
            var result = new List<List<string>>();
            foreach (CrispResultRow row in report.ResultCrisp)
            {
                var list = new List<string>();
                list.Add(row.Time);
                list.Add(row.Series);
                list.Add(row.Model);
                list.Add(row.Error);
                list.Add(row.RError);
                list.Add(row.Diff);
                list.Add(row.ModelDiff);
                result.Add(list);
            }
            return result;
        }

        public static List<List<string>> GetResultsFuzzy(Report<CrispResultRow, FuzzyResultRow> report)
        {
            var result = new List<List<string>>();
            foreach (FuzzyResultRow row in report.ResultFuzzy)
            {
                var list = new List<string>();
                list.Add(row.Time);
                list.Add(row.Series);
                list.Add(row.MF);
                list.Add(row.FT);
                list.Add(row.ModelFT);
                list.Add(row.FTError);
                list.Add(row.TTend);
                list.Add(row.ModelTTend);
                list.Add(row.TError);
                list.Add(row.RTend);
                list.Add(row.ModelRTend);
                list.Add(row.RError);
                result.Add(list);
            }
            return result;
        }

        public static void FillCrispRowsNone(ACLTimeSeries acl, Report<CrispNResultRow, FuzzyNResultRow> report)
        {
            var actual = acl.FTS.PointList;

            var meansSPL =
              new SPointList { Name = "Ряд центров НМ", XName = actual.XName, YName = "Центры НМ" };


            for (int i = 0; i < actual.Count; i++)
            {
                var row = new CrispNResultRow
                {
                    Time = actual[i].X.ToString(Calc.DFormat),
                    Series = actual[i].Y.ToString(Calc.DFormat),
                };

                if (i < acl.DiffPointList.Count)
                {
                    row.Diff = acl.DiffPointList[i].Y.ToString(Calc.DFormat);
                }
                else
                {
                    row.Diff = "нет";
                }

                meansSPL.Add(new SPoint(actual[i].X, acl.FTS.MeanSeries[i]));
                report.ResultCrisp.Add(row);
            }

            report.PointLists.Add(acl.FTS.MF);
            report.PointLists.Add(meansSPL);
            report.PointLists.Add(acl.DiffPointList);
        }

        public static void FillFuzzyRowsNone(ACLTimeSeries acl, Report<CrispNResultRow, FuzzyNResultRow> report)
        {
            var actual = acl.FTS.PointList;

            for (int i = 0; i < actual.Count; i++)
            {
                var row = new FuzzyNResultRow
                {
                    Time = actual[i].X.ToString(Calc.DFormat),
                    Series = actual[i].Y.ToString(Calc.DFormat),
                    FT = acl.FTS.FuzzySeries[i].Name,
                    MF = acl.FTS.MF[i].Y.ToString("F")
                };
                if (i < acl.Tends.Count)
                {
                    row.TTend = acl.TTends[i].Name;
                    row.RTend = acl.RTends[i].Name;
                }
                report.ResultFuzzy.Add(row);
            }
        }

        public static void FillCrispRowsBase(ACLTimeSeries acl, ACLTimeSeries aclForecast, Report<CrispResultRow, FuzzyResultRow> report)
        {
            var forecast = aclForecast.FTS.PointList;
            var actual = acl.FTS.PointList;

            var meansSPL =
              new SPointList { Name = "Ряд центров НМ", XName = actual.XName, YName = "Центры НМ" };

            var errors =
             new SPointList { Name = "Ряд ошибок", XName = actual.XName, YName = "Значение ошибки" };

            var rErrors =
              new SPointList { Name = "Ряд относительных ошибок", XName = actual.XName, YName = "Значение ошибки" };


            for (int i = 0; i < actual.Count; i++)
            {
                var row = new CrispResultRow
                {
                    Time = actual[i].X.ToString(Calc.DFormat),
                    Series = actual[i].Y.ToString(Calc.DFormat),
                    Model = forecast[i].Y.ToString(Calc.DFormat),
                };

                double error = forecast[i].Y - actual[i].Y;
                errors.Add(new SPoint(actual[i].X, error));
                row.RError = error.ToString(Calc.DFormat);

                double rError = actual[i].Y != 0 ? Math.Abs((forecast[i].Y - actual[i].Y) / actual[i].Y) : -1;
                rErrors.Add(new SPoint(actual[i].X, rError));
                row.Error = rError.ToString(Calc.DFormat);

                if (i < acl.DiffPointList.Count)
                {
                    row.Diff = acl.DiffPointList[i].Y.ToString(Calc.DFormat);
                    row.ModelDiff = aclForecast.DiffPointList[i].Y.ToString(Calc.DFormat);
                }
                else
                {
                    row.Diff = "нет";
                    row.ModelDiff = "нет";
                }

                meansSPL.Add(new SPoint(actual[i].X, acl.FTS.MeanSeries[i]));
                report.ResultCrisp.Add(row);
            }

            report.PointLists.Add(acl.FTS.MF);
            report.PointLists.Add(meansSPL);
            report.PointLists.Add(acl.DiffPointList);
            report.PointLists.Add(errors);
            report.PointLists.Add(rErrors);
            aclForecast.DiffPointList.Name = "Модель Разность";
            report.PointLists.Add(aclForecast.DiffPointList);
        }


        public static double GetTError(string actualName, string forecastName)
        {
            if (actualName == forecastName)
                return 0;
            if (actualName == "Стабильность" || forecastName == "Стабильность")
                return 0.5;
            return 1;
        }

        public static void FillFuzzyRowsBase(ACLTimeSeries acl, ACLTimeSeries aclForecast, Report<CrispResultRow, FuzzyResultRow> report)
        {
            var forecast = aclForecast.FTS.PointList;
            var actual = acl.FTS.PointList;

            for (int i = 0; i < actual.Count; i++)
            {
                var row = new FuzzyResultRow
                {
                    Time = actual[i].X.ToString(Calc.DFormat),
                    Series = actual[i].Y.ToString(Calc.DFormat),
                    MF = acl.FTS.MF[i].Y.ToString("F"),
                    FT = acl.FTS.FuzzySeries[i].Name,
                    ModelFT = aclForecast.FTS.FuzzySeries[i].Name,
                };
                row.FTError = (row.FT == row.ModelFT ? 0 : 1).ToString();
                if (i < acl.Tends.Count)
                {
                    row.TTend = acl.TTends[i].Name;
                    row.ModelTTend = aclForecast.TTends[i].Name;
                    row.RTend = acl.RTends[i].Name;
                    row.ModelRTend = aclForecast.RTends[i].Name;
                    row.TError = GetTError(row.TTend, row.ModelTTend).ToString();
                    row.RError = (row.RTend == row.ModelRTend ? 0 : 1).ToString();
                }

                report.ResultFuzzy.Add(row);
            }
        }


        public static ErrorRow GetErrorRow(SPointList actual, SPointList forecast, int omitCount)
        {
            #warning Расчёт всех ошибок
            var er = new ErrorRow();
            er.MSE = Calc.MSE(actual, forecast, omitCount);
            er.MAPE = Calc.MAPE_Сalculator(actual, forecast, omitCount);
            er.SMAPE = Calc.SMAPE_Сalculator(actual, forecast, omitCount);
            er.R2 = Calc.R2(actual, forecast, omitCount);
            er.RMSE = Calc.RMSE(actual, forecast, omitCount);
            er.D = Calc.D(actual, forecast, omitCount);
            er.Dispersion = Calc.Dispersion(actual);
            return er;
        }

        private static FuzzyErrorRow GetFuzzyErrorRowI(ACLTimeSeries acl, ACLTimeSeries aclForecast, int actualCount, int omitCount)
        {
            var er = new FuzzyErrorRow();

            var actual = acl.FTS.FuzzySeries;
            var forecast = aclForecast.FTS.FuzzySeries;
            var actualT = acl.TTends;
            var forecastT = aclForecast.TTends;
            var actualR = acl.RTends;
            var forecastR = aclForecast.RTends;

            return GetFuzzyErrorRowI(actual, actualT, actualR, forecast, forecastT, forecastR, actualCount, omitCount);
        }

        private static FuzzyErrorRow GetFuzzyErrorRowI(List<FuzzyTerm> actual, List<FuzzyTerm> actualT, List<FuzzyTerm> actualR, List<FuzzyTerm> forecast, List<FuzzyTerm> forecastT, List<FuzzyTerm> forecastR, int actualCount, int omitCount)
        {
            var er = new FuzzyErrorRow();

            var iActual = ForecastHelper.GetInternal(actual, actualCount);
            var iForecast = ForecastHelper.GetInternal(forecast, actualCount);
            er.FPE = Calc.FuzzyPercentError(iActual, iForecast, omitCount);
            var FCE = Calc.CountErrors(iActual, iForecast, omitCount);
            er.FCE = FCE + "/" + (iActual.Count - omitCount);

            actualCount--;
            omitCount--;
            var iActualT = ForecastHelper.GetInternal(actualT, actualCount);
            var iForecastT = ForecastHelper.GetInternal(forecastT, actualCount);
            er.TTendFPE = Calc.FuzzyPercentError(iActualT, iForecastT, omitCount);
            var TTendFCE = Calc.CountErrors(iActualT, iForecastT, omitCount);
            er.TTendFCE = TTendFCE + "/" + (iActual.Count - omitCount);

            var iActualR = ForecastHelper.GetInternal(actualR, actualCount);
            var iForecastR = ForecastHelper.GetInternal(forecastR, actualCount);
            er.RTendFPE = Calc.FuzzyPercentError(iActualR, iForecastR, omitCount);
            var RTendFCE = Calc.CountErrors(iActualR, iForecastR, omitCount);
            er.RTendFCE = RTendFCE + "/" + (iActual.Count - omitCount);
            return er;
        }

        private static FuzzyErrorRow GetFuzzyErrorRowE(List<FuzzyTerm> actual, List<FuzzyTerm> actualT, List<FuzzyTerm> actualR, List<FuzzyTerm> forecast, List<FuzzyTerm> forecastT, List<FuzzyTerm> forecastR, int actualCount)
        {
            var er = new FuzzyErrorRow();

            var eActual = ForecastHelper.GetExternal(actual, actualCount);
            var eForecast = ForecastHelper.GetExternal(forecast, actualCount);
            er.FPE = Calc.FuzzyPercentError(eActual, eForecast, 0);
            var FCE = Calc.CountErrors(eActual, eForecast, 0);
            er.FCE = FCE + "/" + (eActual.Count);


            actualCount = actualCount - 1;
            var eActualT = ForecastHelper.GetExternal(actualT, actualCount);
            var eForecastT = ForecastHelper.GetExternal(forecastT, actualCount);
            er.TTendFPE = Calc.FuzzyPercentError(eActualT, eForecastT, 0);
            var TTendFCE = Calc.CountErrors(eActualT, eForecastT, 0);
            er.TTendFCE = TTendFCE + "/" + (eActual.Count);

            var eActualR = ForecastHelper.GetExternal(actualR, actualCount);
            var eForecastR = ForecastHelper.GetExternal(forecastR, actualCount);
            er.RTendFPE = Calc.FuzzyPercentError(eActualR, eForecastR, 0);
            var RTendFCE = Calc.CountErrors(eActualR, eForecastR, 0);
            er.RTendFCE = RTendFCE + "/" + (eActual.Count);

            return er;
        }

        private static FuzzyErrorRow GetFuzzyErrorRowE(ACLTimeSeries acl, ACLTimeSeries aclForecast, int actualCount)
        {
            var er = new FuzzyErrorRow();

            var actual = acl.FTS.FuzzySeries;
            var forecast = aclForecast.FTS.FuzzySeries;
            var actualT = acl.TTends;
            var forecastT = aclForecast.TTends;
            var actualR = acl.RTends;
            var forecastR = aclForecast.RTends;

            return GetFuzzyErrorRowE(actual, actualT, actualR, forecast, forecastT, forecastR, actualCount);
        }

        public static List<FuzzyErrorRow> GetFuzzyErrors(List<FuzzyTerm> actual, List<FuzzyTerm> actualT, List<FuzzyTerm> actualR, List<FuzzyTerm> forecast, List<FuzzyTerm> forecastT, List<FuzzyTerm> forecastR, int actualCount, int omitCount)
        {
            var errors = new List<FuzzyErrorRow>();
            var ier = GetFuzzyErrorRowI(actual, actualT, actualR, forecast, forecastT, forecastR, actualCount, omitCount);
            errors.Add(ier);
            var eer = GetFuzzyErrorRowE(actual, actualT, actualR, forecast, forecastT, forecastR, actualCount);
            errors.Add(eer);
            return errors;
        }

        public static List<FuzzyErrorRow> GetFuzzyErrors(ACLTimeSeries acl, ACLTimeSeries aclForecast, int actualCount, int omitCount)
        {
            var errors = new List<FuzzyErrorRow>();
            var ier = GetFuzzyErrorRowI(acl, aclForecast, actualCount, omitCount);
            errors.Add(ier);
            var eer = GetFuzzyErrorRowE(acl, aclForecast, actualCount);
            errors.Add(eer);
            return errors;
        }

        public static List<ErrorRow> GetErrors(SPointList actual, SPointList forecast, int omitCount, int actualCount)
        {
            var errors = new List<ErrorRow>();
            var iActual = ForecastHelper.GetInternalPoints(actual, actualCount);
            var iForecast = ForecastHelper.GetInternalPoints(forecast, actualCount);
            var ier = GetErrorRow(iActual, iForecast, omitCount);
            errors.Add(ier);
            var eActual = ForecastHelper.GetExternalPoints(actual, actualCount);
            var eForecast = ForecastHelper.GetExternalPoints(forecast, actualCount);
            var eer = GetErrorRow(eActual, eForecast, 0);
            errors.Add(eer);
            return errors;
        }

        public static List<RuleRow> GetRules(Dictionary<string, int> rules)
        {
            var rulesRows = new List<RuleRow>();
            int i = 0;
            foreach (KeyValuePair<string, int> valuePair in rules)
            {
                var rr = new RuleRow();
                rr.Number = i.ToString();
                rr.Rule = valuePair.Key;
                rr.Count = valuePair.Value.ToString();
                rulesRows.Add(rr);
                i++;
            }
            return rulesRows;
        }

        public static List<RuleMFRow> GetRules(IEnumerable<MamdaniFuzzyRule> rules)
        {
            var rulesRows = new List<RuleMFRow>();
            int i = 0;
            foreach (var rule in rules)
            {
                var rr = new RuleMFRow();
                rr.Number = i.ToString();
                rr.Rule = rule.ToString();
                rr.MF = rule.MF.ToString("F");
                rulesRows.Add(rr);
                i++;
            }
            return rulesRows;
        }

        public XmlElement ToXmlElement(XmlDocument xmlDocument)
        {
            var xmlElement = xmlDocument.CreateElement("ForecastModel");
            xmlElement.SetAttribute("Type", ((int)ModelType).ToString());

            if (ForecastModel != null)
            {
                Project.AddFieldElement(xmlDocument, xmlElement, "Order", ForecastModel.Order.ToString());
                Project.AddFieldElement(xmlDocument, xmlElement, "FCount", ForecastModel.ExtraForecastCount.ToString());
                Project.AddFieldElement(xmlDocument, xmlElement, "ActualCount", ForecastModel.ActualCount.ToString());
                Project.AddFieldElement(xmlDocument, xmlElement, "ExcessModelType", ForecastModel.ExcessModelType.ToString());
                Project.AddFieldElement(xmlDocument, xmlElement, "UsedAllActualCount", ForecastModel.UsedAllActualCount.ToString());
            }

            switch (ModelType)
            {
                case ForecastModelType.None:
                    break;
                case ForecastModelType.Song:
                    if (ForecastModel != null)
                        Project.AddFieldElement(xmlDocument, xmlElement, "SelectRules",
                                                ((SongForecastModel)ForecastModel).SelectRules.ToString());
                    break;
                case ForecastModelType.Neural:
                    if (ForecastModel != null)
                        Project.AddFieldElement(xmlDocument, xmlElement, "Hidden",
                                                ((NeuralForecastModel)ForecastModel).NumberHidden.ToString());
                    break;
                case ForecastModelType.D:
                    if (ForecastModel != null)
                        Project.AddFieldElement(xmlDocument, xmlElement, "SelectRules",
                                                ((DForecastModel)ForecastModel).SelectRules.ToString());
                    break;
                case ForecastModelType.Tend:
                    if (ForecastModel != null)
                        Project.AddFieldElement(xmlDocument, xmlElement, "SelectRules",
                                                ((TendForecastModel)ForecastModel).SelectRules.ToString());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return xmlElement;
        }

        public void FromXmlElement(XmlElement xmlElement)
        {
            string type = xmlElement.GetAttribute("Type");
            ModelType = (ForecastModelType)int.Parse(type);

            string orderStr = Project.GetFieldElement(xmlElement, "Order");
            int order;
            if (!int.TryParse(orderStr, out order))
                order = 1;

            string fCountStr = Project.GetFieldElement(xmlElement, "FCount");
            int fCount;
            if (!int.TryParse(fCountStr, out fCount))
                fCount = 1;

            string aCountStr = Project.GetFieldElement(xmlElement, "ActualCount");
            int aCount;
            if (!int.TryParse(aCountStr, out aCount))
                aCount = 10;

            string excessModelStr = Project.GetFieldElement(xmlElement, "ExcessModelType");
            int excessModel;
            if (!int.TryParse(excessModelStr, out excessModel))
                excessModel = (int)ForecastModelType.None;
            var excessModelType = (ForecastModelType)excessModel;

            string useAllStr = Project.GetFieldElement(xmlElement, "UsedAllActualCount");
            bool useAll;
            if (!bool.TryParse(useAllStr, out useAll))
                useAll = false;

            switch (ModelType)
            {
                case ForecastModelType.None:
                    ForecastModel = null;
                    break;
                case ForecastModelType.Song:
                    string selectRulesStr = Project.GetFieldElement(xmlElement, "SelectRules");
                    bool selectRules;
                    if (!bool.TryParse(selectRulesStr, out selectRules))
                        selectRules = false;
                    ForecastModel = new SongForecastModel(aclSeries.FTS, order, fCount, aCount, useAll, excessModelType, false, selectRules);
                    break;
                case ForecastModelType.Neural:
                    string hiddenStr = Project.GetFieldElement(xmlElement, "Hidden");
                    int hidden;
                    if (!int.TryParse(hiddenStr, out hidden))
                        hidden = 5;
                    ForecastModel = new NeuralForecastModel(aclSeries.FTS.PointList, order, hidden, fCount, aCount, useAll, excessModelType, false);
                    break;
                case ForecastModelType.D:
                    selectRulesStr = Project.GetFieldElement(xmlElement, "SelectRules");
                    if (!bool.TryParse(selectRulesStr, out selectRules))
                        selectRules = false;
                    ForecastModel = new DForecastModel(aclSeries, order, fCount, aCount, useAll, excessModelType, false, selectRules);
                    break;
                case ForecastModelType.Tend:
                    selectRulesStr = Project.GetFieldElement(xmlElement, "SelectRules");
                    if (!bool.TryParse(selectRulesStr, out selectRules))
                        selectRules = false;
                    ForecastModel = new TendForecastModel(aclSeries, order, fCount, aCount, useAll, excessModelType, false, selectRules);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Refresh();
        }
    }

}
