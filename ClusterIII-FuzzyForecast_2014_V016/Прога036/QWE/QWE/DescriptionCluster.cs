using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml;


namespace MyСlusterWorkingSpace
{
    #region Описание составных классов для класса "Cluster"
    /// <summary>
    /// Список параметров "центра" кластера
    /// </summary>
    public class IntList : List<int>{}
 
    /// <summary>
    /// Список кластеров
    /// </summary>
    public class ClusterList : List<Cluster> 
    {
        /// <summary>
        /// Метод возвращает список всевозможных подкластеров;
        /// </summary>      
        public ClusterList GetOllCluster(ClusterList MyStructureCluster)
        {
            ClusterList MyLocalStructureCluster = new ClusterList();
            MyLocalStructureCluster.Clear();
            if (MyLocalStructureCluster.Count == 0)
            {
                for (int i = 0; i < MyStructureCluster.Count; i++)
                {
                    MyLocalStructureCluster.Add(MyStructureCluster[i]);
                    MyLocalStructureCluster.AddRange(GetOllCluster(MyStructureCluster[i].StructureCluster));
                }
                
                /*for (int i = 0; i < MyLocalStructureCluster.Count; i++)
                {
                    MyLocalStructureCluster[i].StructureCluster.Clear();
                }
                 */ 
            }
            return MyLocalStructureCluster;
        }       
    }
   #endregion

    /// <summary>
    /// Описание кластера верхнего иерархического уровня
    /// </summary>
    public class Cluster
    {
        public string Name="NoName";
        /// <summary>
        /// Список параметров "центра" кластера верхнего иерархического уровня
        /// </summary>
        public IntList Center = new IntList();

        /// <summary>
        /// Список кластеров, входящих в состав, кластера верхнего иерархического уровня.
        /// </summary>
        public ClusterList StructureCluster = new ClusterList();

        #region Данная группа методов - некий предложенный стандарт обработки объектов класса "Cluster"

        
        /// <summary>
        /// Этот медод возвращает радиус кластера
        /// </summary>
        public double Radius()
        {
            BasicMethodsOfClusterСalсulations BMOCС= new BasicMethodsOfClusterСalсulations();            
            double max = 0;
            double dis = 0;

            if (StructureCluster.Count == 0)
            {
                max = 0; 
            }
            else            
                for (int i = 0; i < StructureCluster.Count; i++)
                {
                    //StructureCluster.ger
                    Cluster MyLocalCluster = new Cluster();
                    MyLocalCluster.Name = Name;
                    MyLocalCluster.Center = Center;
                    MyLocalCluster.StructureCluster = StructureCluster;
                    dis = BMOCС.Distance(MyLocalCluster, StructureCluster[i]);
                    if (dis >= max) max = dis;                                    
                }            
            return max;
        }

        /// <summary>
        /// Этот медод осуществляет пересчет центра если есть по чему пересчитывать. ,tp
        /// </summary>
        private void StandartCenterReloader()
        {            
            BasicMethodsOfClusterСalсulations MyLocalСalс = new BasicMethodsOfClusterСalсulations();
            IntList MyLocalCenter = new IntList();            
            if (StructureCluster.Count != 0)
            {
                for (int i = 0; i < StructureCluster[0].Center.Count; i++)                
                    MyLocalCenter.Add(0);                 
                for(int i=0;i<StructureCluster.Count;i++)                
                    MyLocalCenter = MyLocalСalс.CenterPlusCenter(MyLocalCenter, StructureCluster[i].Center);                
                MyLocalCenter = MyLocalСalс.CenterDivideNumber(MyLocalCenter, StructureCluster.Count);
            }
            Center = MyLocalCenter;

        }
        /// <summary>
        /// Этот медод добавления подкластера какбы незабыть переназвать.
        /// </summary>
        private void Add(Cluster MyCluster)
        {            
            StructureCluster.Add(MyCluster);
            StandartCenterReloader();            
        }
        /// <summary>
        /// Этот медод удаления подкластера какбы незабыть переназвать.
        /// </summary>
        private void RemoveAt(int i)
        {
            if ((i >= 0 )&&(i < StructureCluster.Count))
                    StructureCluster.RemoveAt(i);
            StandartCenterReloader();
        }

        /// <summary>
        /// Этот метод груперует два подкластера в один
        /// </summary>
        public void Grouping(int i, int j, string NewName)
        {
            if (
                (StructureCluster.Count>=2)&&
                (i >= 0)&&
                (j >= 0)&&
                (i != j)&&
                (i < StructureCluster.Count)&&
                (j < StructureCluster.Count)
                )
                            {
                                Cluster MyLocalClusterR = new Cluster();
                                MyLocalClusterR.Name = NewName;
                                MyLocalClusterR.Add(StructureCluster[i]);
                                MyLocalClusterR.Add(StructureCluster[j]);
                                Add(MyLocalClusterR);                                
                                if (i < j)
                                {
                                    RemoveAt(i);
                                    RemoveAt(j - 1);
                                }
                                else
                                {
                                    RemoveAt(j);
                                    RemoveAt(i - 1);
                                }
                            }
            StandartCenterReloader();           
        }
        #endregion   
    }         
}