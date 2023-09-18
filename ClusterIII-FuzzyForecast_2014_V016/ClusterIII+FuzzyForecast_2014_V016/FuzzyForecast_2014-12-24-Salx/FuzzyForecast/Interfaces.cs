using System.Collections.Generic;
using FuzzyLibrary;

namespace FuzzyForecast
{
    /// <summary>
    /// Интерфейс для нечеткой шкалы
    /// </summary>
    public interface IFuzzyScale
    {
        /// <summary>
        ///  название шкалы
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Получить нечеткие термы по четкому значению
        /// </summary>
        /// <param name="x">четкое значение</param>
        /// <returns>нечеткие термы</returns>
        Dictionary<FuzzyTerm, double> GetTermsByX(double x);

        /// <summary>
        /// Получить дефазифицированное значение терма
        /// </summary>
        /// <param name="termName">имя терма</param>
        /// <returns>значение</returns>
        double Defuzzify(string termName);
    }

    public interface IBaseForecastModel<T>
    {
        int Order { get; }
        int ExtraForecastCount { get; }
        int ActualCount { get; }
        T ForecastNextPoint(T[] inputs);
        List<T> ActualList { get; }
        List<T> GetForecastSeries();
    }


    /// <summary>
    /// Интерфейс для модели прогнозирования
    /// </summary>
    public interface IForecastModel
    {
        int Order { get; }
        int ExtraForecastCount { get; }
        string Name { get; }
        string ModelInfo { get; }
        string ModelInfoFlat { get; }
        int ActualCount { get; }
        bool UseFTransform { get; set; }
        ForecastModelType ExcessModelType { get; }
        bool UsedAllActualCount { get; }
        SPointList Actual { get; }
        SPointList GetForecastSeries(bool ignoreExcessModel);
        SPointList GetForecastSeries();
        double ForecastNextPoint(double[] inputs);
        ExcessForecastModel ExcessModel { get; }
        Report<CrispResultRow, FuzzyResultRow> GetReport();
        Report<CrispResultRow, FuzzyResultRow> GetReport(SPointList forecast);
        /// <summary>
        /// получения отсатка от основного ряда
        /// реализованно только для F-модели
        /// </summary>
        void delta();
    }

    public interface IFuzzyForecastModel : IForecastModel
    {
        CompositeMembershipFunction ForecastNextPointFuzzy(double[] inputs);
        List<CompositeMembershipFunction> GetForecastSeriesFuzzy();
    }
}
