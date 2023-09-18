using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyСlusterWorkingSpace
{
    /// <summary>
    /// Класс , в котором описываются математические методы обработки и группировки кластера.
    /// </summary>
    public class BasicMethodsOfClusterСalсulations
    {
        #region Обновление центра кластера
        /// <summary>
        /// Метод сложения "центров" кластеров
        /// </summary>
        public IntList CenterPlusCenter(IntList MyCenterA, IntList MyCenterB)
        {
            ;
            IntList MyLocalCenter = new IntList();
            if (MyCenterA.Count == MyCenterB.Count)
                for (int i = 0; i < MyCenterA.Count; i++)
                    MyLocalCenter.Add(MyCenterA[i] + MyCenterB[i]);
            return MyLocalCenter;
        }
        /// <summary>
        /// Метод деления "центра" кластера на число
        /// </summary>
        public IntList CenterDivideNumber(IntList MyCenterA, int c)
        {
            IntList MyLocalCenter = new IntList();
            for (int i = 0; i < MyCenterA.Count; i++)
                if(c==0)
                    MyLocalCenter.Add(Convert.ToInt32(MyCenterA[i]));    
                    else
                    MyLocalCenter.Add(Convert.ToInt32(MyCenterA[i]/c));
            return MyLocalCenter;
        }
        /// <summary>
        /// Метод пересчёта "центров" кластеров верхнего и нижнего иерархических уровней 
        /// </summary>
        public void ClusterCenterReloading(Cluster MyCluster)
        {            
            //IntList MyLocalCenter = new IntList();

            if (MyCluster.StructureCluster.Count >0)
            {
                for (int i = 0; i < MyCluster.Center.Count; i++)
                {
                    MyCluster.Center[i]=0;
                }                
                for (int i = 0; i < MyCluster.StructureCluster.Count; i++)
                {
                    ClusterCenterReloading(MyCluster.StructureCluster[i]);
                    MyCluster.Center = CenterPlusCenter(MyCluster.Center, MyCluster.StructureCluster[i].Center);
                }
                MyCluster.Center = CenterDivideNumber(MyCluster.Center, MyCluster.StructureCluster.Count);
            }
        }
        #endregion

        #region Определение расстояния между двумя точками (центрами кластеров)
        /// <summary>
        /// Метод возвращает дистанцию(расстояние) между двумя точками (центрами кластеров)
        /// </summary>
        private double EuclideanDistance(IntList MyCenterA, IntList MyCenterB)
        {
            IntList MyLocalCenterA = new IntList();
            IntList MyLocalCenterB = new IntList();
            IntList MyLocalCenterCalc = new IntList();
            MyLocalCenterA = MyCenterA;
            MyLocalCenterB = MyCenterB;

            double rez=0;
            if (MyLocalCenterA.Count == MyLocalCenterB.Count)
            {
                for (int i = 0; i < MyLocalCenterA.Count; i++)
                {
                    MyLocalCenterCalc.Add(0);
                    MyLocalCenterCalc[i] = (MyLocalCenterA[i] - MyLocalCenterB[i]) * (MyLocalCenterA[i] - MyLocalCenterB[i]);
                }
                for (int i = 0; i < MyLocalCenterA.Count; i++)
                    rez = rez + MyLocalCenterCalc[i];
            }
            rez =Math.Sqrt(rez);
            return rez;
        }
        /// <summary>
        /// Метод возвращает l1 норму между двумя точками (центрами кластеров)
        /// </summary>
        private double EuclideanNorm(IntList MyCenterA, IntList MyCenterB)
        {
            double rez = 0;
            if (MyCenterA.Count == MyCenterB.Count)
                for (int i = 0; i < MyCenterA.Count; i++)
                    MyCenterA[i] = Convert.ToInt32(Math.Sqrt((MyCenterA[i] - MyCenterB[i]) * (MyCenterA[i] - MyCenterB[i])));
            for (int i = 0; i < MyCenterA.Count; i++)
                rez = rez + MyCenterA[i];            
            return rez;
        }
        /// <summary>
        /// Метод возвращает сюпремум-норма между двумя точками (центрами кластеров)
        /// </summary>        
        private double SyupremumNorm(IntList MyCenterA, IntList MyCenterB)
        {            
            double max;
            if (MyCenterA.Count == MyCenterB.Count)
                for (int i = 0; i < MyCenterA.Count; i++)
                    MyCenterA[i] = Convert.ToInt32(Math.Sqrt((MyCenterA[i] - MyCenterB[i]) * (MyCenterA[i] - MyCenterB[i])));
            max = MyCenterA[0];
            for (int i = 0; i < MyCenterA.Count; i++)
                if (max <= MyCenterA[i]) max = MyCenterA[i];
            return max;
        }
        /// <summary>
        /// Метод возвращает lp - норма между двумя точками (центрами кластеров)
        /// </summary>
        private double EuclideanNormP(IntList MyCenterA, IntList MyCenterB,int p)
        {
            double rez = 0;
            if (MyCenterA.Count == MyCenterB.Count)
                for (int i = 0; i < MyCenterA.Count; i++)
                    MyCenterA[i] = Convert.ToInt32(Math.Pow(((MyCenterA[i] - MyCenterB[i]) * (MyCenterA[i] - MyCenterB[i])),p));
            for (int i = 0; i < MyCenterA.Count; i++)
                rez = rez + MyCenterA[i];
            rez = Math.Pow(rez,1/p);
            return rez;
        }
        /// <summary>
        /// Метод возвращает дистанцию(расстояние) между двумя точками (центрами кластеров).
        /// </summary>      
        public double Distance(Cluster MyClusterA, Cluster MyClusterB)
        {            
            //return EuclideanNormP(MyClusterA.Center, MyClusterB.Center,8);
            //return SyupremumnNorm(MyClusterA.Center, MyClusterB.Center);
            //return EuclideanNorm(MyClusterA.Center, MyClusterB.Center);
            ClusterCenterReloading(MyClusterA);
            ClusterCenterReloading(MyClusterB);
            return EuclideanDistance(MyClusterA.Center, MyClusterB.Center);
        }

        

        #endregion

        #region Группировка кластера
     
        /// <summary>
        /// Центроидный метод.( метод взвешенных групп)
        /// </summary>
        public Cluster WeighedGroups(Cluster MyCluster, int FinCount)
        {
            double min = 999999999;
            int jj=0, ii=0, counter=0;
           
            Cluster MyLocalCluster = new Cluster();
            MyLocalCluster=MyCluster;
            while ((MyLocalCluster.StructureCluster.Count>=2)&&(MyLocalCluster.StructureCluster.Count>FinCount))
            {
                min = 99999999;
                jj = -1;
                ii = -1;
                for (int i = 0; i < MyLocalCluster.StructureCluster.Count; i++)
                    for (int j = 0; j < MyLocalCluster.StructureCluster.Count; j++)
                    {
                        if ((i != j) && (min >= Distance(MyLocalCluster.StructureCluster[i], MyLocalCluster.StructureCluster[j])))
                        {
                            min = Distance(MyLocalCluster.StructureCluster[i], MyLocalCluster.StructureCluster[j]);
                            ii = i;
                            jj = j;
                        }
                    }
                MyLocalCluster.Grouping(ii, jj, "Name№"+Convert.ToString(counter));
                counter++;
            }
            return MyLocalCluster;
        }

        #endregion


    }


}