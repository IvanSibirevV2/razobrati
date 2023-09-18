using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClusterIII.Model;

namespace ClusterIII.Converts
{
    public static class ClusterConvertTo
    {
        /// <summary>
        /// Метод нормирования параметров кластера        
        /// </summary>
        /// <param name="RezCluster">Нормируемый кластер</param>
        /// <returns>Нормированный кластер</returns>
        public static Cluster NormCluster(Cluster InputCluster)
        {            
            #region Комментарий
            //___a___k1___b_____ - ось ox с точками a, k1, b.
            //___0___k1-a___b-a_____ - по аналогии
            //___0___(k1-a)/(b-a)___(b-a)/(b-a)_____ - ...
            //___0___k2___1_____
            //k2=(k1-a)/(b-a); - формула нормирования
            //1=(b-a)/(b-a)
            //MaxCluster = b;
            //MinCluster = a;
            #endregion

            //1) Поиск максимального и минимального значения параметра
            Cluster RezCluster = InputCluster.FaceClone();
            //Создадим переменную, в которую будем записывать максимальные значения параметра
            Cluster MaxCluster = RezCluster.FaceClone();
            MaxCluster.SCluster.Clear();
            //Создадим переменную, в которую будем записывать минимальные значения параметра
            Cluster MinCluster = RezCluster.FaceClone();
            MinCluster.SCluster.Clear();
            //Перибераем параметры кластера
            //перибераемы группы 
            for (int i = 0; i < MaxCluster.CGroupList.Count(); i++)
            {
                //перибераем параметры
                for (int j = 0; j < MaxCluster.CGroupList[i].GParamList.Count(); j++)
                {
                    //последовательность значений
                    List<double> DoubleList = new List<double>();
                    DoubleList.Clear();
                    //Перибераем подкластеры (Предприятия)
                    for (int k = 0; k < RezCluster.SCluster.Count; k++)
                    {
                        //Тот самый перибераемый параметр, формируем последовательность его значений
                        DoubleList.Add(RezCluster.SCluster[k].CGroupList[i].GParamList[j].P);
                    }                    
                    //Сохраняем найденые минимальные и максимальные значения
                    MaxCluster.CGroupList[i].GParamList[j].P=Enumerable.Max(DoubleList);
                    MinCluster.CGroupList[i].GParamList[j].P = Enumerable.Min(DoubleList);
                }
            }
            //2) Нормирование каждого параметра отдельно
            //Перибераем параметры кластера
            //перибераемы группы 
            for (int i = 0; i < MaxCluster.CGroupList.Count(); i++)
            {
                //перибераем параметры
                for (int j = 0; j < MaxCluster.CGroupList[i].GParamList.Count(); j++)
                {
                    //последовательность значений                    
                    //Перибераем подкластеры (Предприятия)
                    for (int k = 0; k < RezCluster.SCluster.Count; k++)
                    {
                        //k2=(k1-a)/(b-a); - формула нормирования
                        //MaxCluster = b;
                        //MinCluster = a;
                        //Как получилось смотри в начале метода в комментариях
                        RezCluster.SCluster[k].CGroupList[i].GParamList[j].P=
                            (
                                RezCluster.SCluster[k].CGroupList[i].GParamList[j].P -
                                MinCluster.CGroupList[i].GParamList[j].P
                            )/
                            (
                                MaxCluster.CGroupList[i].GParamList[j].P-
                                MinCluster.CGroupList[i].GParamList[j].P
                            );// - формула нормирования
                    }
                    //Сохраняем найденые минимальные и максимальные значения                    
                }
            }
            return RezCluster;            
        }
    }
}
