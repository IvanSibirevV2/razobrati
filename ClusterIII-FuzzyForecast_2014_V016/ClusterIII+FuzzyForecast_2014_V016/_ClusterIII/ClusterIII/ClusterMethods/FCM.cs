using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using ClusterIII.Model;
namespace ClusterIII.ClusterMethods
{
    public class UClass
    {
        public List<double> Ulist = new List<double>();
    }
    public static class FCMClass
    {

        public static double Distance(Cluster A, Cluster B)
        {
            double rez = 0;
            int i = 0;
            foreach (Group MyGpoup in A.CGroupList)
            {
                int j = 0;
                foreach (Param MyParam in MyGpoup.GParamList)
                {
                    rez = rez + Math.Pow((A.CGroupList[i].GParamList[j].P - B.CGroupList[i].GParamList[j].P), 2);
                    j = 0;
                }
                i++;
            }
            if (Math.Sqrt(rez) == 0) { rez = 0.00000000001; }
            return Math.Sqrt(rez);
        }
        
        /// <summary>
        /// Дописал вроде
        /// </summary>
        public static Cluster CRecord(List<UClass> MyUCluster, Cluster C, double q, Cluster MySuperCluster)
        {            
            Cluster rez= new Cluster();
            rez=C;
            //Перебераес кластеры

            int j = 0;
            foreach (Cluster MyCluster in rez.SCluster)
            {
                double zn = 0;
                // перебираем предприяьтия
                for (int k = 0; k < MyUCluster[j].Ulist.Count(); k++)
                {
                    zn = zn + Math.Pow(MyUCluster[j].Ulist[k], q);
                }                   
                int i1=0;
                //перебираем в кластерах группы
                foreach (Group MyGroup in MyCluster.CGroupList)
                {
                    int i2=0;
                    //перибираем в группах в кластерах параметры
                    foreach (Param MyParam in MyGroup.GParamList)
                    {
                        double ch = 0;
                        //перебираем предприятия
                        for (int k = 0; k < MyUCluster[j].Ulist.Count(); k++)
                        {
                            ch = ch + Math.Pow(MyUCluster[j].Ulist[k], q) * MySuperCluster.SCluster[k].CGroupList[i1].GParamList[i2].P;
                        }
                        MyCluster.CGroupList[i1].GParamList[i2].P = ch / zn;
                        
                       
                        i2++;
                    }
                    i1++;
                }                
                    j++;
            }            
              
            return rez;        
        }


        public static List<UClass> URecord(List<UClass> UCluster, Cluster C, double q, Cluster MySuperCluster)
        {
            List<UClass> rez = new List<UClass>();
            
            #region Задаём матриц U
            //зАДАЛИ КЛАСТЕРЫ
            for (int i = 0; i < UCluster.Count(); i++)
            {
                rez.Add(new UClass());
                //Задали все предприятия
                for (int j = 0; j < UCluster[i].Ulist.Count(); j++)                
                    rez[i].Ulist.Add(Convert.ToDouble(0));
            }
            #endregion
            
            //пробегаем кластеры
            for (int j = 0; j < UCluster.Count(); j++)
            {
                //Пробегаем предприятия
                for (int i = 0; i < UCluster[j].Ulist.Count(); i++)
                {            
                    double zn = 0;
                    for (int l = 0; l < UCluster.Count(); l++)
                    {
                        zn = zn + Math.Pow(Distance(MySuperCluster.SCluster[i], C.SCluster[j]) / Distance(MySuperCluster.SCluster[i], C.SCluster[l]), 2 / (q - 1));
                    
                    }
                    //Пробегаем вообще все предприятия ещё раз.
                    if (zn == 0) { zn = 0.0000001; }
                    rez[j].Ulist[i]=1/zn;
                    
                   
             
                }             
            }
           
                return rez;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="N"></param>
        /// <param name="q"></param>
        /// <param name="MyCluster"></param>
        /// <param name="MySuperCluster"></param>
        /// <returns></returns>
        public static DataTable FCM(int N, double q, Cluster MyCluster, Cluster MySuperCluster)
        {
            //<Шаг 1. Инициализация.>            
            Cluster C = new Cluster();
            List<UClass> UCluster = new List<UClass>();
            C = MyCluster.Copy();
            

            #region Этот цикл обрабатывает список кластерОВ ПРЕДОБРАБОТКА
            foreach (Cluster MyLocalcluster in C.SCluster)
            {
                //Берём и перепрошиваем наши данные, избавляясь от иерархической структуры
                List<Cluster> MyClusterList = new List<Cluster>();
                MyClusterList = MyLocalcluster.GetInClusterToListTurbo();
                MyLocalcluster.SCluster.Clear();
                MyLocalcluster.SCluster.AddRange(MyClusterList);

                //Если это кластер единичной мощьности, то делаем его видимым.(Своеоюразное хитроумное самодобавление)
                
                if (MyLocalcluster.SCluster.Count == 0)
                {
                    Cluster MyLocalcluster1 = new Cluster();
                    MyLocalcluster1 = MyLocalcluster;
                    MyLocalcluster.SCluster.Add(MyLocalcluster);
                } 
                 
            }
            //C.RecalculationClusterCenter();
            //C = C;
            #endregion

            #region Задаём матриц U
            //зАДАЛИ КЛАСТЕРЫ
            
            /*
            for (int i = 0; i < MyCluster.SCluster.Count; i++)                
            {
                UCluster.Add(new UClass());
                //Задали все предприятия
                foreach (Cluster MyLocalcluster1 in MySuperCluster.SCluster)
                    UCluster[i].Ulist.Add(0);
            }
            
            */
            int i1 = 0;                                   
            //Пробегаем кластеры.
            foreach (Cluster MyLocalcluster in C.SCluster)
            {
                UCluster.Add(new UClass());
                //Задали все предприятия
                int j = 0;
                foreach (Cluster MyLocalcluster1 in MySuperCluster.SCluster)
                {
                    Boolean flag=false;
                    //UCluster[i1].Ulist.Add(0);
                    //пробегаем предприятия в кластере
                    foreach (Cluster MyLocalcluster2 in MyLocalcluster.SCluster)
                    {
                        if (MyLocalcluster2.Name == MyLocalcluster1.Name)
                        {
                            flag = true;
                        }                        
                    }
                    if (flag)
                    {
                        UCluster[i1].Ulist.Add(0);
                    }
                    else
                    {
                        UCluster[i1].Ulist.Add(1);
                    }
                    j++;
                }

                i1++;
            }

            ;
            #endregion
            
            
            for (int i = 0; i < N;i++ )
            {
                //<Шаг 2. Вычисление центров кластера.>                
                C = CRecord(UCluster, C, q, MySuperCluster.Copy());                                
                //<Шаг 3. Формирование новой матрици принадлежности.>
                UCluster = URecord( UCluster, C, q, MySuperCluster.Copy());                
                
                 
                //</Шаг 3. Формирование новой матрици принадлежности.>                
                //</Шаг 2. Вычисление центров кластера.>
            }
            
            
            //Выводим на экран
            DataTable MyUDataTable = new DataTable();
            MyUDataTable.Columns.Add("Предприятия / кластеры", typeof(string));
            foreach (Cluster MyLocalcluster1 in MyCluster.SCluster)            
            {
                MyUDataTable.Columns.Add(MyLocalcluster1.Name, typeof(double));
            }
            
            i1 = 0;
            foreach (Cluster MyLocalcluster1 in MySuperCluster.SCluster)
            {
                List<object> MyObjectList = new List<object>();
                MyObjectList.Add(Convert.ToString(MyLocalcluster1.Name));
                //Перебираем все  кластеры
                int j = 0;
                foreach (Cluster MyLocalcluster2 in MyCluster.SCluster)
                {
                    MyObjectList.Add(Convert.ToDouble(UCluster[j].Ulist[i1]));
                        j++;
                }
                MyUDataTable.Rows.Add(MyObjectList.ToArray());
                i1++;
            }
            
            return MyUDataTable;            
        }
 
    }
}
