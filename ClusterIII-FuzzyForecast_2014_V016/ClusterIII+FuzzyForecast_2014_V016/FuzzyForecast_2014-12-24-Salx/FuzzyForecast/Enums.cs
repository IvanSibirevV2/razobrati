namespace FuzzyForecast
{
    /// <summary>
    /// Базовые типы тенденции
    /// </summary>
    public enum BaseTendType
    {
        Increase,
        Decrease,
        Stability
    } ;

    /// <summary>
    /// Метод фазификации
    /// </summary>
    public enum FuzzificationMethod
    {
        Simple,
        Cluster,
        User
    } ;

    /// <summary>
    /// Методы прогнозирвоания
    /// </summary>
    public enum ForecastModelType
    {
        /// <summary>
        /// Модель отсутствует
        /// </summary>
        None,
        /// <summary>
        /// Нейросетевая модель
        /// </summary>
        Neural,
        /// <summary>
        /// Модель Сонга
        /// </summary>
        Song,
        /// <summary>
        /// Модель Шаха-Дегтярева
        /// </summary>
        D,
        /// <summary>
        /// Модель на основе Тенденций
        /// </summary>
        Tend,
        /// <summary>
        /// F-модель
        /// </summary>
        F,
        /// <summary>
        /// Остаток F-модели
        /// </summary>
        _F
    } ;
}
