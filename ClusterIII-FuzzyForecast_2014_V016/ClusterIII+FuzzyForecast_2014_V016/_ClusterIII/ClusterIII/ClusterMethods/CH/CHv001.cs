using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClusterIII.Model;
using ClusterIII.Converts;
using System.Windows.Forms;

namespace ClusterIII.ClusterMethods.CH
{
    public class CHclassV001
    {
        private List<List<double>> DistanceList = new List<List<double>>();
        /// <summary>
        /// Данный метод возвращает номера кластеров с минимальным расстоянием
        /// </summary>        
        private List<int> GetMinDistance(Cluster MyCluster)
        {
            List<int> REZ = new List<int>();
            int ii = 0, jj = 0;
            double min = 999999999;
            Cluster MyLocalCluster = new Cluster();
            MyLocalCluster = MyCluster.FaceClone();
            for (int i = 0; i < MyLocalCluster.SCluster.Count; i++)
            {
                for (int j = 0; j < MyLocalCluster.SCluster.Count; j++)
                {
                    if (i != j)
                    {
                        Cluster q1 = MyLocalCluster.SCluster[i].FaceClone();
                        Cluster q2 = MyLocalCluster.SCluster[j].FaceClone();
                        double QWE = Distance(q1, q2);
                        if (min > QWE)
                        {
                            min = QWE;
                            ii = i;
                            jj = j;
                        }
                    }
                }
            }
            REZ.Add(ii);
            REZ.Add(jj);
            return REZ;
        }
        private List<int> TurboGetMinDistance()
        {
            List<int> REZ = new List<int>();
            int ii = -1, jj = -1;
            double min = 999999999;
            for (int i = 0; i < DistanceList.Count; i++)
            {
                for (int j = 0; j < DistanceList[i].Count; j++)
                {
                    if (i != j)
                    {
                        double QWE = DistanceList[i][j];
                        if (min > QWE)
                        {
                            min = QWE;
                            ii = i;
                            jj = j;
                        }
                    }
                }
            }
            REZ.Add(ii);
            REZ.Add(jj);
            return REZ;
        }
        /// <summary>
        /// Данный метод заполняет лист дистанций с нуля
        /// </summary>        
        private void SetOllDistanceList(Cluster MyCluster)
        {
            Cluster MyLocalCluster = MyCluster.FaceClone();
            DistanceList.Clear();
            for (int i = 0; i < MyLocalCluster.SCluster.Count; i++)
            {
                DistanceList.Add(new List<double>());
                for (int j = 0; j < MyLocalCluster.SCluster.Count; j++)
                {
                    DistanceList[i].Add(0);
                    if (i != j)
                    {
                        DistanceList[i][j] = Distance(MyLocalCluster.SCluster[i], MyLocalCluster.SCluster[j]);
                    }
                }
            }
        }
        /// <summary>
        /// Данный метод удаляет из листа дистанций запись о кластере
        /// </summary>        
        private void DellDistanceList(int del)
        {
#warning eror
            if (del == -1)
                MessageBox.Show("Удалялка нагнулась", "Фатальная ошибка", MessageBoxButtons.OK);

            
            DistanceList.RemoveAt(del);
            for (int i = 0; i < DistanceList.Count; i++)            
                DistanceList[i].RemoveAt(del);            
        }
        /// <summary>
        /// Данный метод добавляет из листа дистанций запись о кластере
        /// </summary>        
        private void AddDistanceList(Cluster MyCluster, Cluster AddCluster)
        {
            //Строим расстояние
            List<double> DoubleList = new List<double>();
            foreach (Cluster LocalCluster in MyCluster.SCluster)
                DoubleList.Add(Distance(LocalCluster, AddCluster));
            //Дорбавляем новые  анные
            for (int i = 0; i < DistanceList.Count; i++)            
                DistanceList[i].Add(DoubleList[i]);            
            DoubleList.Add(0);
            DistanceList.Add(DoubleList);
        }
        /// <summary>
        /// Метод - Метрика, расстояние между двумя кластерами. Евклидовое расстояние.
        /// </summary>
        /// <param name="A">Кластер А</param>
        /// <param name="B">Кластер В</param>
        /// <returns>Расстояние между двумя кластерами</returns>
        public double Distance(Cluster A, Cluster B)
        {
            double rez = 0;            
            for (int i = 0; i < A.CGroupList.Count; i++)                            
                for (int j = 0; j < A.CGroupList[i].GParamList.Count; j++)                
                    rez = rez + Math.Pow((A.CGroupList[i].GParamList[j].P - B.CGroupList[i].GParamList[j].P), 2);                                            
            return Math.Sqrt(rez);
        }
       
        /// <summary>
        /// Центроидный метод.( метод взвешенных групп)
        /// </summary>        
        /// <param name="MyCluster">Обрабатываемые данные</param>
        /// <param name="FinCount">Кнечное количество кластеров</param>
        /// <returns>Результат обработки</returns>        
        public Cluster TurboWeighedGroups(Cluster MyCluster, int FinCount)
        {
            ;
            double min = 999999999;
            int jj = 0, ii = 0, counter = 0;
            Cluster MyLocalCluster = new Cluster();
            MyLocalCluster = ClusterConvertTo.NormCluster(MyCluster.FaceClone());
            FormProgressBar Progres = new FormProgressBar(0, 0);
            Progres.Show();
            Progres.progressBar1.Maximum = (int)MyLocalCluster.SCluster.Count;
            //Находим все расстояния
            SetOllDistanceList(MyLocalCluster);
            //Внимание если в начале последнего цикла кластеров на один больше, это так и надо.  В конце их будет нужное кол-во
            while ((MyLocalCluster.SCluster.Count >= 2) && (MyLocalCluster.SCluster.Count > FinCount))
            {
                min = 99999999;
                jj = -1;
                ii = -1;
                Progres.progressBar1.Value = (int)Progres.progressBar1.Maximum - MyLocalCluster.SCluster.Count;
                Progres.Text = " CHclass V001 (" + Convert.ToString(FinCount) + ") " + Convert.ToString(MyLocalCluster.SCluster.Count - 1) + "_";
                List<int> l = TurboGetMinDistance();
                ii = l[0];
                jj = l[1];                
                if (ii < jj)
                {
                    DellDistanceList(ii);
                    DellDistanceList(jj - 1);
                }
                else
                {
                    DellDistanceList(jj);
                    DellDistanceList(ii - 1);
                }
                Cluster NewCluster = new Cluster();
                if ((ii == -1) || (jj == -1))
                    MessageBox.Show("Не найден минимальный элемент", "Фатальная ошибка", MessageBoxButtons.OK);

                NewCluster = MyLocalCluster.RezGrouping(ii, jj, "CHName№" + Convert.ToString(counter));
                //Удаляем устаревшие записи о дистанциях
                AddDistanceList(MyLocalCluster, NewCluster);
                MyLocalCluster.SCluster.Add(NewCluster);
                //MyLocalCluster.Grouping(ii, jj, "CHName№" + Convert.ToString(counter));
                counter++;
            }
            Progres.Close();
            return MyLocalCluster;
        }
    }
}
