using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClusterIII.Model;
using System.Windows.Forms;
using System.Data;
using ClusterIII.View;
using ClusterIII.ClusterMethods.CH;
using ClusterIII.Converts;
using SavingLoadingNameSpace;

namespace ClusterIII.ImportsScrolls.ProgramScrolls.FuzzyForecastImportScroll
{
    public class ClassScroll2
    {
        /// <summary>
        /// Свиток второй
        /// </summary>
        /// <param name="listViewStatisticCrisp">Попробуем получить всю предметную область</param>
        /// <param name="NameText"></param>
        public void Run(List<List<double>> DataSet, List<string> DataNameSet, List<string> DataTypeSet, List<string> DataKSet)
        {            
            //Заранее спрашиваем куда сохранять будем            
            int emax = 1;
            string Pach = "";
            {
                string Pach3 = SLSerializableService.SaveFileDialogString();
                for (int i = 0; i < Pach3.Split('\\').Count() - 1; i++)
                {
                    Pach = Pach + Pach3.Split('\\')[i] + '\\';
                }
            }
            FormProgressBar Progress = new FormProgressBar(0, 0);
            Progress.progressBar1.Maximum = (int)DataSet.Count;
            Progress.Show();
            //Перибераем все ряды
            for (int i = 0; i < DataSet.Count; i++)
                if (DataSet[i].Count >= 50)
                {
                    Progress.progressBar1.Value = (int)i;
                    Progress.Text = DataNameSet[i]+" ^_^";
                    //Получаем Ряд и конвертируем в формат Cluster
                    Cluster RowCluster = GenClusters(DataSet[i], DataNameSet[i]);
                    #region Кластеризация и сглаживание аномалий
                    for (int E = 0; E < emax; E++)
                    {                        
                        #region Получаем результаты кластеризации в таблицу                        
                        DataTable MyDataTableGridView1 = new DataTable();
                        CHclassV000 CH = new CHclassV000();
                        /*
                        Cluster cht = CH.TurboWeighedGroups
                                (
                                    RowCluster.FaceClone(),
                                    2
                                );
                        */
                        
                        MyDataTableGridView1 = ViewConvert.ClusterToDataTableV1
                            (                                
                                CH.WeighedGroups
                                //CH.TurboWeighedGroups
                                (                                   
                                    RowCluster.FaceClone(),                                 
                                    2
                                )
                                ,
                                RowCluster.FaceClone()
                            );
                        
                        #endregion
                        // Выбираем наименьший кластер
                        List<string> ListCMinCount = GetListCMinCount(MyDataTableGridView1);
                        // Сглаживаем аномали
                        ;
                        RemoveAnomalies( DataSet[i], ListCMinCount ) ;
                    }
                    #endregion
                    // Сохранение в файл
                    this.StreamSaver(Pach, DataSet[i], DataNameSet[i], DataTypeSet[i], DataKSet[i], "_RemoveAnomalies1.txt");                    
                }
            Progress.Close();
        }

        /// <summary>
        /// Сохранение в файл ряда
        /// </summary>
        private void StreamSaver(string Pach, List<double> DataSetI, string DataNameSetI, string DataTypeSetI, string DataKSetI, string AddName) 
        {
            var sw = new System.IO.StreamWriter(Pach + DataNameSetI.Split('.')[0] + AddName);
            sw.WriteLine(Convert.ToString(DataKSetI) + " " + DataTypeSetI);
            sw.WriteLine(Convert.ToString(DataSetI.Count) + " " + DataTypeSetI);
            for (int j = 0; j < DataSetI.Count; j++)
                sw.WriteLine(Convert.ToString(j) + "\t" + Convert.ToString(DataSetI[j]));
            sw.Close();            
        }

        /// <summary>
        /// Конвертируем ряд в формат Cluster
        /// </summary>
        /// <param name="DataSetI"></param>
        /// <param name="DataNameSetI"></param>
        /// <returns></returns>
        private Cluster GenClusters(List<double> DataSetI, string DataNameSetI)
        {
            //Формируем шапку данных
            Cluster RowCluster = new Cluster();
            RowCluster.Name = DataNameSetI;
            RowCluster.CGroupList.Add(new Group("Group", new List<Param>()));
            RowCluster.CGroupList[0].GParamList.Add(new Param("Point", 0));
            // Пишем пустые объекты дынных (Предприятия) и клонируем в них стиль шапки
            RowCluster.SCluster.Clear();
            foreach (double YPoint in DataSetI)
            {
                RowCluster.SCluster.Add(new Cluster());
            }
            //Клонируем стиль шапки
            RowCluster.SameFaceClone();
            // Пишем Параметры дынных (Предприятия)
            {
                int j = 0;
                foreach (double YPoint in DataSetI)
                {
                    RowCluster.SCluster[j].Name = Convert.ToString(j);
                    RowCluster.SCluster[j].CGroupList[0].GParamList[0].P = YPoint;
                    j++;
                }
            }
            //По идее мы получили список точек ряда. Данные готовы, можно отжигать...
            return RowCluster;            
        }

        /// <summary>
        /// Выбираем наименьший кластер
        /// </summary>
        private List<string> GetListCMinCount(DataTable MyDataTableGridView1)
        {
            #region Выбираем наименьший кластер
            //Генерируем 2 списка имён точек
            List<string> ListC1 = new List<string>();
            List<string> ListC2 = new List<string>();
            //Перибераем
            foreach (DataRow ThisRow in MyDataTableGridView1.Rows)
            {
                //Записываем названия точек
                if (Convert.ToDouble(ThisRow[1]) == 1)
                {
                    ListC1.Add(Convert.ToString(ThisRow[0]));
                }
                else
                {
                    ListC2.Add(Convert.ToString(ThisRow[0]));
                }
            }
            //Выбираем наименьший список 
            List<string> ListCMinCount = new List<string>();
            if (ListC1.Count <= ListC2.Count)
            {
                ListCMinCount.AddRange(ListC1);
            }
            else
            {
                ListCMinCount.AddRange(ListC2);
            }
            #endregion
            return ListCMinCount;
        }

        private void RemoveAnomalies( List<double> DataSetI, List<string> ListCMinCount ) 
        {
         #region Сглаживаем аномали
            //сРЕДНЕЕ АРИФМЕТИЧЕСКОЕ
            double mid = 0;
            foreach (double d in DataSetI)
            {
                mid = mid + d;
            }
            mid = mid / DataSetI.Count;
            //Перибираем исходные ряды
            for (int j = 0; j < DataSetI.Count; j++)
            {
                Boolean Flag = false;
                //Сравниваем их со списком аномалий
                for (int k = 0; k < ListCMinCount.Count; k++)
                {
                    if (ListCMinCount[k] == Convert.ToString(j))
                    {
                        Flag = true;
                    }
                }

                if (Flag)//Ура аномалия
                {
                    //Действуем если не край
                    if (
                            (j > 3) &&
                            (j < DataSetI.Count - 3)
                        )
                    {
                        ;
                        DataSetI[j] =
                            (Int64)
                            (
                                DataSetI[j - 3] +
                                DataSetI[j - 2] +
                                DataSetI[j - 1] +
                            //mid+
                                DataSetI[j - 1] +
                                DataSetI[j - 2] +
                                DataSetI[j + 3]
                            ) / (2 * 3);
                    }
                    //То ради чего всё это писалось - сглаживание
                }
            }
            #endregion
        }
    }
}
