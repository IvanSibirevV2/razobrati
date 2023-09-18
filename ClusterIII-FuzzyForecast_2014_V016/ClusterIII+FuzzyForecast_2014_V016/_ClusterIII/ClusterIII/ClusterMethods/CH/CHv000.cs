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
    public class CHclassV000
    {
        /// <summary>
        /// Метод - Метрика, расстояние между двумя кластерами. Евклидовое расстояние.
        /// </summary>
        /// <param name="A">Кластер А</param>
        /// <param name="B">Кластер В</param>
        /// <returns>Расстояние между двумя кластерами</returns>
        public double Distance(Cluster A, Cluster B)
        {
            double rez=0;
            //int i = 0;
            //foreach(Group MyGpoup in A.CGroupList)
            for(int i=0; i<A.CGroupList.Count;i++)
            {
                //int j = 0;
                //foreach (Param MyParam in A.CGroupList[i].GParamList)
                for (int j = 0; j < A.CGroupList[i].GParamList.Count; j++)
                {
                    rez = rez + Math.Pow((A.CGroupList[i].GParamList[j].P - B.CGroupList[i].GParamList[j].P),2);

                     //j j;
                }
                //i++;
            }
            return Math.Sqrt(rez);      
        }
        /// <summary>
        /// Центроидный метод.( метод взвешенных групп)
        /// </summary>        
        /// <param name="MyCluster">Обрабатываемые данные</param>
        /// <param name="FinCount">Кнечное количество кластеров</param>
        /// <returns>Результат обработки</returns>
        public Cluster WeighedGroups(Cluster MyCluster, int FinCount)
        {
            ;
            double min = 999999999;
            int jj = 0, ii = 0, counter = 0;
            Cluster MyLocalCluster = new Cluster();
            MyLocalCluster = ClusterConvertTo.NormCluster(MyCluster);

            FormProgressBar Progres = new FormProgressBar(0,0);            
            Progres.Show();
           
            Progres.progressBar1.Maximum = (int)MyLocalCluster.SCluster.Count;
            //Внимание если в начале последнего цикла кластеров на один больше, это так и надо.  В конце их будет нужное кол-во
            while ((MyLocalCluster.SCluster.Count >= 2) && (MyLocalCluster.SCluster.Count > FinCount))
            {
                min = 99999999;
                jj = -1;
                ii = -1;
                Progres.progressBar1.Value = (int)Progres.progressBar1.Maximum - MyLocalCluster.SCluster.Count;
                
                for (int i = 0; i < MyLocalCluster.SCluster.Count; i++)
                {
                    Progres.Text = " CHclass V000 (" + Convert.ToString(FinCount) + ") " + Convert.ToString(MyLocalCluster.SCluster.Count - 1) + "_"+Convert.ToString(i);
                    for (int j = 0; j < MyLocalCluster.SCluster.Count; j++)
                    {
                        if (i != j)
                        {
                            Cluster q1=MyLocalCluster.SCluster[i].FaceClone();
                            Cluster q2=MyLocalCluster.SCluster[j].FaceClone();
                            double QWE = Distance( q1, q2);
                            if (min > QWE)
                            {
                                min = QWE;
                                ii = i;
                                jj = j;
                            }
                        }
                    }
                }   
                if((ii==-1)||(jj==-1))
                    MessageBox.Show("Не найден минимальный элемент", "Фатальная ошибка", MessageBoxButtons.OK);
                MyLocalCluster.Grouping(ii, jj, "CHName№" + Convert.ToString(counter));
                counter++;
            }            
            Progres.Close();            
            return MyLocalCluster;
        }
    }
}