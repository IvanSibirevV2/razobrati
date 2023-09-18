using System.Collections.Generic;
using FuzzyLibrary;
using NeuronDotNet.Core;
using NeuronDotNet.Core.Backpropagation;
using NeuronDotNet.Core.Initializers;

namespace FuzzyForecast
{

    public class NeuralTendForecastModel : IBaseForecastModel<TendMF>
    {
        public int NumberInput = 2;
        public readonly int NumberOutput = 3;
        public int NumberHidden = 5;

        public double LearningRate = 0.5;

        public const int CyclesDefault = 20000;
        public const double StopMSEDefault = 0.000001;

        public int Cycles = CyclesDefault;
        public double StopMSE = StopMSEDefault;

        public BackpropagationNetwork Network;
        public int WindowLength;

        public SPointList Actual
        {
            get { return ACLSeries.FTS.PointList; }
        }

        public List<TendMF> ActualList { get; private set; }

        public int Order
        {
            get { return NumberInput; }
        }

        public int ExtraForecastCount { get; set; }
        public int ActualCount { get; set; }

        private double minInput;
        private double maxInput;


        public string Name { get; private set; }

        public string ModelInfo
        {
            get
            {
                return Name + ", Порядок: " + Order + ", Разбиение: " + ActualCount + ", Глубина прогноза: " + ExtraForecastCount;
            }
        }

        public bool UsedAllActualCount { get; set; }

        public ACLTimeSeries ACLSeries;

        public NeuralTendForecastModel(ACLTimeSeries aclSeries, int numberInput, int numberHidden, int forecastCount, int actualCount, bool useAll)
            : this(aclSeries, numberInput, numberHidden, NeuralForecastModel.CyclesDefault, NeuralForecastModel.StopMSEDefault, forecastCount, actualCount, useAll)
        {
        }

        public NeuralTendForecastModel(ACLTimeSeries aclSeries, int numberInput, int numberHidden, int cycles, double stop, int forecastCount, int actualCount, bool useAll)
        {
            ACLSeries = aclSeries;
            NumberInput = numberInput;
            NumberHidden = numberHidden;
            ExtraForecastCount = forecastCount;
            ActualCount = actualCount;
            UsedAllActualCount = useAll;
            Cycles = cycles;
            StopMSE = stop;


            Name = "3N Модель";

            ActualList = new List<TendMF>();
            foreach (var tend in aclSeries.Tends)
            {
                ActualList.Add(tend.TendTypeMFs);
            }

            Remake();
        }

        private void NormInput()
        {
            minInput = Actual.FindMin().Y;
            maxInput = Actual.FindMax().Y;
        }

        public double NormInput(double value)
        {
            return (value - minInput) / (maxInput - minInput);
        }

        public double DeNormInput(double value)
        {
            return value * (maxInput - minInput) + minInput;
        }

        public void Remake()
        {
            SetNetwork();
            NormInput();
            Learn();
        }

        public void SetNetwork()
        {
            var inputLayer = new LinearLayer(NumberInput);
            var hiddenLayer = new SigmoidLayer(NumberHidden);
            var outputLayer = new SigmoidLayer(NumberOutput);
            new BackpropagationConnector(inputLayer, hiddenLayer).Initializer = new RandomFunction(0d, 0.5d);
            new BackpropagationConnector(hiddenLayer, outputLayer).Initializer = new RandomFunction(0d, 0.5d);
            Network = new BackpropagationNetwork(inputLayer, outputLayer);
            Network.SetLearningRate(LearningRate);
            //Network.JitterEpoch = 0;
            if (WindowLength == 0)
                WindowLength = 1;
            Network.Stop = StopMSE;
        }

        public void Learn()
        {
            //количество точек, исп для обучения
            var actualCount = UsedAllActualCount ? Actual.Count : ActualCount;

            var trainingSet = new TrainingSet(NumberInput, 3);
            for (int i = NumberInput; i < actualCount; i += WindowLength)
            {
                var inputValues = new double[NumberInput];
                for (int j = 0; j < inputValues.Length; j++)
                {
                    inputValues[j] = NormInput(Actual[j + i - NumberInput].Y);
                }

                var pt1 = new FTSPoint(ACLSeries.Scale.BaseScale, new SPoint(i - 1, Actual[i - 1].Y));
                var pt2 = new FTSPoint(ACLSeries.Scale.BaseScale, new SPoint(i, Actual[i].Y));
                var tend = new FuzzyTend(ACLSeries.Scale, pt1, pt2);

                trainingSet.Add(new TrainingSample(inputValues, tend.TendTypeMFs.ToArray()));
            }

            if (MainForm.ShowProgress)
            {
                //var pf = new ProgressForm(Network, Cycles, trainingSet);
                //pf.ShowDialog();
            }
            else
            {
                Network.Learn(trainingSet, Cycles);
            }
        }

        private double[] NormInput(double[] input)
        {
            var inputNorm = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                inputNorm[i] = NormInput(input[i]);
            }
            return inputNorm;
        }

        private double[] DeNormInput(double[] input)
        {
            var inputNorm = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                inputNorm[i] = DeNormInput(input[i]);
            }
            return inputNorm;
        }

        public TendMF ForecastNextPoint(double[] input)
        {
            if (input.Length != NumberInput)
                return null;

            var inputNorm = NormInput(input);

            double[] output = Network.Run(inputNorm);

            if (output != null)
            {
                //output = DeNorm(output);
                var t = new TendMF { Dec = output[0], Stab = output[1], Inc = output[2] };
                return t;
            }

            return null;
        }

        public TendMF ForecastNextPoint(TendMF[] input)
        {
            if (input.Length + 1 != NumberInput)
                return null;

            var doubleInput = new double[input.Length + 1];
            for (int i = 0; i < input.Length; i++)
            {
                doubleInput[i] = input[i].Begin;
            }
            doubleInput[input.Length] = input[input.Length - 1].End;

            var inputNorm = NormInput(doubleInput);

            double[] output = Network.Run(inputNorm);

            if (output != null)
            {
                //output = DeNorm(output);
                var t = new TendMF { Dec = output[0], Stab = output[1], Inc = output[2] };
                return t;
            }

            return null;
        }

        public List<TendMF> GetForecastSeries()
        {
            return ForecastHelper.GetForecastList(this, Order - 1);
        }
    }

    public class NeuralForecastModel : IForecastModel
    {
        public int NumberInput = 2;
        public readonly int NumberOutput = 1;
        public int NumberHidden = 5;

        public double LearningRate = 0.5;

        public const int CyclesDefault = 20000;
        public const double StopMSEDefault = 0.000001;

        public int Cycles = CyclesDefault;
        public double StopMSE = StopMSEDefault;

        public BackpropagationNetwork Network;
        public int WindowLength;

        public SPointList Actual
        {
            get;
            private set;
        }
        public void delta()
        {

        }
        public int Order
        {
            get { return NumberInput; }
        }

        public bool UseFTransform { get; set; }

        public int ExtraForecastCount { get; set; }
        public int ActualCount { get; set; }

        private double min;
        private double max;

        public string Name { get; private set; }

        public string ModelInfo
        {
            get
            {
                var modelStr = Name +
                            ",\nПорядок: " + (Order - 1) +
                            ",\nРазбиение ряда (точки): " + (Actual.Count - ActualCount) +
                            ",\nГлубина прогноза: " + ExtraForecastCount +
                            ",\nF преобразование: " + (UseFTransform ? "Есть" : "Нет");
                var excessStr = ",\nМодель остатков: ";
                if (ExcessModelType != ForecastModelType.None)
                {
                    excessStr += ExcessModel.ExcessModel.ModelInfo;
                }
                else
                {
                    excessStr += "отсутсвует";
                }
                return modelStr + excessStr;
            }
        }

        public string ModelInfoFlat
        {
            get
            {
                var modelStr = Name +
                            ",Порядок: " + (Order - 1) +
                            ",Разбиение ряда (точки): " + (Actual.Count - ActualCount) +
                            ",Глубина прогноза: " + ExtraForecastCount +
                            ",F преобразование: " + (UseFTransform ? "Есть" : "Нет");
                var excessStr = ",Модель остатков: ";
                if (ExcessModelType != ForecastModelType.None)
                {
                    excessStr += ExcessModel.ExcessModel.ModelInfo;
                }
                else
                {
                    excessStr += "отсутсвует";
                }
                return modelStr + excessStr;
            }
        }

        public bool UsedAllActualCount { get; set; }

        public ForecastModelType ExcessModelType { get; set; }

        public ExcessForecastModel ExcessModel { get; set; }

        public bool ExcessManual;

        public ACLTimeSeries ACLSeries;

        public NeuralForecastModel(SPointList actual, int numberInput, int numberHidden, int forecastCount, int actualCount) :
            this(actual, numberInput, numberHidden, forecastCount, actualCount, false, ForecastModelType.None, false)
        {
        }

        public NeuralForecastModel(SPointList actual, int numberInput, int numberHidden, int forecastCount, int actualCount, bool useAll, ForecastModelType excessModelType, bool excessManual)
            : this(actual, numberInput, numberHidden, forecastCount, actualCount, useAll, excessModelType, excessManual, false)
        {
        }

        public NeuralForecastModel(SPointList actual, int numberInput, int numberHidden, int forecastCount, int actualCount, bool useAll, ForecastModelType excessModelType, bool excessManual, bool notMake)
            : this(actual, numberInput, numberHidden, CyclesDefault, StopMSEDefault, forecastCount, actualCount, useAll, excessModelType, excessManual, notMake)
        {
        }

        public NeuralForecastModel(SPointList actual, int numberInput, int numberHidden, int cycles, double stop, int forecastCount, int actualCount, bool useAll, ForecastModelType excessModelType, bool excessManual, bool notMake)
        {
            Actual = actual;
            NumberInput = numberInput;
            NumberHidden = numberHidden;
            ExtraForecastCount = forecastCount;
            ExcessManual = excessManual;
            ActualCount = actualCount;
            UsedAllActualCount = useAll;
            ExcessModelType = excessModelType;
            Cycles = cycles;
            StopMSE = stop;

            Name = "N Модель";

            if (!notMake)
            {
                Remake();
            }
        }

        private void Norm()
        {
            min = Actual.FindMin().Y;
            max = Actual.FindMax().Y;
        }

        public double Norm(double value)
        {
            return (value - min) / (max - min);
        }

        public double DeNorm(double value)
        {
            return value * (max - min) + min;
        }

        public void Remake()
        {
            SetNetwork();
            Norm();
            Learn();
            if (ExcessModelType != ForecastModelType.None)
            {
                ExcessModel = new ExcessForecastModel(this, ExcessModelType, ExcessManual);
            }
        }

        public void SetNetwork()
        {
            var inputLayer = new LinearLayer(NumberInput);
            var hiddenLayer = new SigmoidLayer(NumberHidden);
            var outputLayer = new SigmoidLayer(NumberOutput);
            new BackpropagationConnector(inputLayer, hiddenLayer).Initializer = new RandomFunction(0d, 0.5d);
            new BackpropagationConnector(hiddenLayer, outputLayer).Initializer = new RandomFunction(0d, 0.5d);
            Network = new BackpropagationNetwork(inputLayer, outputLayer);
            Network.SetLearningRate(LearningRate);
            //Network.JitterEpoch = 0;
            if (WindowLength == 0)
                WindowLength = 1;
            Network.Stop = StopMSE;
        }

        public void Learn()
        {
            //количество точек, исп для обучения
            var actualCount = UsedAllActualCount ? Actual.Count : ActualCount;

            var trainingSet = new TrainingSet(NumberInput, 1);
            for (int i = NumberInput; i < actualCount; i += WindowLength)
            {
                var inputValues = new double[NumberInput];
                for (int j = 0; j < inputValues.Length; j++)
                {
                    inputValues[j] = Norm(Actual[j + i - NumberInput].Y);
                }
                trainingSet.Add(new TrainingSample(inputValues, new[] { Norm(Actual[i].Y) }));
            }

            if (MainForm.ShowProgress)
            {
                //var pf = new ProgressForm(Network, Cycles, trainingSet);
                //pf.ShowDialog();
            }
            else
            {
                Network.Learn(trainingSet, Cycles);
            }
        }

        private double[] Norm(double[] input)
        {
            var inputNorm = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                inputNorm[i] = Norm(input[i]);
            }
            return inputNorm;
        }

        public double ForecastNextPoint(double[] input)
        {
            if (input.Length != NumberInput)
                return 0;

            var inputNorm = Norm(input);
            double[] output = Network.Run(inputNorm);

            if (output != null)
                return output[0] * (max - min) + min;
            return 0;
        }

        public SPointList GetForecastSeries()
        {
            return ForecastHelper.GetForecastSeries(this, false);
        }

        public SPointList GetForecastSeries(bool ignoreExcessModel)
        {
            return ForecastHelper.GetForecastSeries(this, ignoreExcessModel);
        }

        public void FillCrispRows(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillCrispRowsBase(ACLSeries, aclForecast, report);
        }

        public void FillFuzzyRows(Report<CrispResultRow, FuzzyResultRow> report, ACLTimeSeries aclForecast)
        {
            ModelResult.FillFuzzyRowsBase(ACLSeries, aclForecast, report);
        }

        public void FillCrispErrors(Report<CrispResultRow, FuzzyResultRow> report, SPointList forecast)
        {
            report.Errors = ModelResult.GetErrors(Actual, forecast, Order, ActualCount);
        }

        public Report<CrispResultRow, FuzzyResultRow> GetReport()
        {
            var report = new Report<CrispResultRow, FuzzyResultRow> { PointLists = new List<SPointList>() };
            var forecast = GetForecastSeries();
            var aclForecast = new ACLTimeSeries(ACLSeries.Scale, forecast);
            FillCrispRows(report, aclForecast);
            FillCrispErrors(report, aclForecast.FTS.PointList);
            FillFuzzyRows(report, aclForecast);
            report.FErrors = ModelResult.GetFuzzyErrors(ACLSeries, aclForecast, ActualCount, Order);
            report.ModelInfo = ModelInfo;
            report.ACLInfo = ACLSeries.Scale.ScaleInfo;
            return report;
        }

        public Report<CrispResultRow, FuzzyResultRow> GetReport(SPointList forecast)
        {
            var report = new Report<CrispResultRow, FuzzyResultRow> { PointLists = new List<SPointList>() };
            //var forecast = GetForecastSeries();
            var aclForecast = new ACLTimeSeries(ACLSeries.Scale, forecast);
            FillCrispRows(report, aclForecast);
            FillCrispErrors(report, aclForecast.FTS.PointList);
            FillFuzzyRows(report, aclForecast);
            report.FErrors = ModelResult.GetFuzzyErrors(ACLSeries, aclForecast, ActualCount, Order);
            report.ModelInfo = ModelInfo;
            report.ACLInfo = ACLSeries.Scale.ScaleInfo;
            return report;
        }

    }
}
