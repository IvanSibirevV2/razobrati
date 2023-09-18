using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing;
using ClusterIII.Model;

using System.Data;
//using System.Web.UI.WebControls;

namespace ClusterIII.View
{

    public static  class ViewConvert
    {
        #region Методы визуализации дерева
        //Эта группа методов позволяет создать в окне формы визуализацию кластера с помощью вызова метода  treeView1.Nodes.Add(MCT.ClusterTreeNode(MyCluster));     
        /// <summary>
        /// Метод визуализации списка кластеров
        /// </summary>
        /// <param name="MyLocalStructureCluster">Список кластеров</param>
        /// <returns>Возвращаемый результат. (TreeNode)</returns>
        public static TreeNode StructureClusterTreeNode(List<Cluster> MyLocalStructureCluster)
        {
            
            TreeNode[] TreeNodeArray = new TreeNode[MyLocalStructureCluster.Count];
            for (int i = 0; i < MyLocalStructureCluster.Count; i++)
            {
                TreeNodeArray[i] = new TreeNode();
                TreeNodeArray[i] = ClusterTreeNode(MyLocalStructureCluster[i]);                    
            }
            return new TreeNode("Содержимое", TreeNodeArray);//MyLocalTreeNode;//MyLocalTreeNode;//Node           
        }
        /// <summary>
        /// Метод визуализации параметров
        /// </summary>
        /// <param name="MyLocalParam">Параметр</param>
        /// <returns>Возвращаемый результат. (TreeNode)</returns>
        public static TreeNode ParamTreeNode(Param MyLocalParam)
        {
            TreeNode[] TreeNodeArray = new TreeNode[1];
                TreeNodeArray[0] = new TreeNode();
                TreeNodeArray[0].Text = Convert.ToString(Convert.ToDouble(MyLocalParam.P));
                return new TreeNode(MyLocalParam.Name, TreeNodeArray);//MyLocalTreeNode;//MyLocalTreeNode;//Node            
        }
        /// <summary>
        /// Метод визуализации группы
        /// </summary>
        /// <param name="MyLocalGroop">Группа</param>
        /// <returns>Возвращаемый результат. (TreeNode)</returns>
        public static TreeNode GroopTreeNode(Group MyLocalGroop)
        {
            TreeNode[] TreeNodeArray = new TreeNode[MyLocalGroop.GParamList.Count];
            for (int i = 0; i < MyLocalGroop.GParamList.Count; i++)
            {
                TreeNodeArray[i] = new TreeNode();                                
                TreeNodeArray[i] = ParamTreeNode(MyLocalGroop.GParamList[i]);
            }
            return new TreeNode(MyLocalGroop.Name, TreeNodeArray);//MyLocalTreeNode;//MyLocalTreeNode;//Node            
        }
        /// <summary>
        /// Метод визуализации списка групп
        /// </summary>
        /// <param name="MyLocalClusterCenter">Список групп</param>
        /// <returns>Возвращаемый результат. (TreeNode)</returns>
        public static TreeNode CenterTreeNode(List<Group> MyLocalClusterCenter)
        {
            TreeNode[] TreeNodeArray = new TreeNode[MyLocalClusterCenter.Count];
            for (int i = 0; i < MyLocalClusterCenter.Count; i++)
            {
                TreeNodeArray[i] = new TreeNode();
                //TreeNodeArray[i].Text = MyLocalClusterCenter[i].Name;
                TreeNodeArray[i] = GroopTreeNode(MyLocalClusterCenter[i]);
            }
            return new TreeNode("Группы(Center)", TreeNodeArray);//MyLocalTreeNode;//MyLocalTreeNode;//Node            
        }
        /// <summary>
        /// Создание TreeNode на основе  кластера
        /// </summary>
        /// <param name="MyLocalCluster">Кластер</param>
        /// <returns>Возвращаемый результат. (TreeNode)</returns>
        public static TreeNode ClusterTreeNode(Cluster MyLocalCluster)
        {
            MyColors Palette = new MyColors();            
            TreeNode[] TreeNodeArray = new TreeNode[2];
            TreeNodeArray[0] = new TreeNode();
            TreeNodeArray[0] = CenterTreeNode(MyLocalCluster.CGroupList);
            TreeNodeArray[0].ForeColor = Palette.MyForeGround.Center;
            TreeNodeArray[1] = new TreeNode();
            TreeNodeArray[1] = StructureClusterTreeNode(MyLocalCluster.SCluster);
            TreeNodeArray[1].ForeColor = Palette.MyForeGround.Center;
            TreeNode TreeNodeRez = new TreeNode();
            TreeNodeRez = new TreeNode("Кластер(Cluster)", TreeNodeArray);
            TreeNodeRez.Text = MyLocalCluster.Name;
            TreeNodeRez.ForeColor = Palette.MyForeGround.Cluster;
            return TreeNodeRez;
        }
        #endregion
        #region Методы визуализации таблици
        /// <summary>
        /// Метод преобразования Cluster => ToDataTable(Предприятия и параметры)
        /// </summary>
        /// <param name="MyCluster">Кластер</param>
        /// <returns>Возвращаемый результат. (DataTable)</returns>
        public static DataTable ClusterToDataTableV0(Cluster MyCluster)
        {
            DataTable rez = new DataTable();
            rez.Columns.Add("Предприятия / параметры",typeof(string));
            //Вводим название колонок
            foreach(Group MyGroup in MyCluster.CGroupList)            
                foreach (Param MyParam in MyGroup.GParamList)
                    rez.Columns.Add(MyGroup.Name+" "+MyParam.Name, typeof(double));
            //Вводим название предприятий            
            int i = 0;
            foreach (Cluster MyLocalCluster in MyCluster.SCluster)
            {                
                //А теперь вводим название предприятий оставшиеся данные
                List<object> MyObjectList = new List<object>();
                //MyObjectList.Add(MyLocalCluster.Name.Split(')')[0] );
                MyObjectList.Add(MyLocalCluster.Name);                
                foreach (Group MyGroup in MyLocalCluster.CGroupList) 
                {
                    foreach (Param MuParam in MyGroup.GParamList) 
                    {
                        MyObjectList.Add(Convert.ToDouble(MuParam.P));
                    }
                }
                rez.Rows.Add(MyObjectList.ToArray());
                i++;
            }
                return rez;            
        }

        /// <summary>
        /// Метод преобразования Cluster => ToDataTable(Предприятия и параметры)
        /// </summary>
        /// <param name="MyCluster">Кластер</param>
        /// <returns>Возвращаемый результат. (DataTable)</returns>
        public static Cluster ReGetInCluster(Cluster MyCluster)
        {
            Cluster MyLocalCluster = new Cluster();
            List<Cluster> MySCluster = new List<Cluster>();            
            MyLocalCluster = MyCluster;
            foreach (Cluster MySuperLocalCluster in MyLocalCluster.SCluster)
            {
                MyLocalCluster.SCluster.AddRange(MySuperLocalCluster.SCluster);
            }
            return MyLocalCluster;
        }


        /// <summary>
        /// Cluster => ToDataTable(Кластеры и Предприятия)
        /// </summary>
        /// <param name="MyCluster">тут 2 кластера, один исходный, а другой изменённый</param>
        /// <param name="MySuperCluster">тут 2 кластера, один исходный, а другой изменённый</param>
        /// <returns>Результат - таблица</returns>
        public static DataTable ClusterToDataTableV1(Cluster MyCluster, Cluster MySuperCluster)
        {
            
            DataTable rez = new DataTable();
            Cluster MyRezCluster = new Cluster();
            MyRezCluster = MyCluster.FaceClone();
            //Добавляем колонки предприятий
            rez.Columns.Add("Предприятия / Кластеры", typeof(string));            
            //foreach(Cluster MyLocalcluster in MyRezCluster.SCluster)
            ;
            for (int i = 0; i < MyRezCluster.SCluster.Count; i++)
            {
                List<Cluster> MyList = MyRezCluster.SCluster[i].GetInClusterToListTurbo();
                //List<Cluster> MyList = ReGetInCluster(MyLocalcluster).SCluster;
                //ReGetInCluster
                MyRezCluster.SCluster[i].SCluster.Clear();
                MyRezCluster.SCluster[i].SCluster.AddRange(MyList);
                //rez.Columns.Add(MyRezCluster.SCluster[i].Name, typeof(double));
                rez.Columns.Add("C"+Convert.ToString(i+1), typeof(double));
            }
            ;
            /*
            
            foreach (Cluster MyLocalcluster in MyRezCluster.SCluster)
            {
                //Если это кластер единичной мощьности, то делаем его видимым.(Своеобразное хитроумное самодобавление)
                if (MyLocalcluster.SCluster.Count == 0)
                {
                    Cluster MyLocalcluster1 = new Cluster();
                    MyLocalcluster1 = MyLocalcluster;
                    MyLocalcluster.SCluster.Add(MyLocalcluster);
                }
                //Разворачиваем весь страшный список подкластеров   
                for (int j = 0; j < MyLocalcluster.SCluster.Count; j++)
                {
                    Cluster t1 = new Cluster();
                    Cluster t2 = new Cluster();
                    t1.SCluster = MyLocalcluster.TurboGetInClusterToList();
                    t2.SCluster = MyLocalcluster.GetInClusterToList();
                    if (t1.SCluster.Count == t2.SCluster.Count)
                    {
                        ;
                    }
                    else 
                    {
                        ; 
                    }
                    //MyLocalcluster.SCluster = MyLocalcluster.TurboGetInClusterToList();
                    //MyLocalcluster.SCluster = MyLocalcluster.TurboGetInClusterToList();
                    //GetInClusterToList
                }
            }

            

            //-----------------------------------------------------------------

            
            //Добавляем астрала кусок
            //int i = 0;
            //Перибераем предприятия
            foreach(Cluster MyLocalcluster in MySuperCluster.SCluster)
            {
                List<object> MyObjectList = new List<object>();
                    MyObjectList.Add(Convert.ToString(MyLocalcluster.Name));                
                //Перибераем раскластеризованные предприятия
                foreach (Cluster MyLocalcluster2 in MyRezCluster.SCluster)
                {
                    Boolean flag = false;
                    foreach (Cluster LocalCluster in MyLocalcluster2.SCluster)
                    {
                        if (LocalCluster.Name == MyLocalcluster.Name)
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag)
                    {
                        MyObjectList.Add(Convert.ToDouble(1));
                    }
                    else
                    {
                        MyObjectList.Add(Convert.ToDouble(0));
                    }
                    
                }

                //MyObjectList.Add(Convert.ToDouble(1));
                //
                
                //if (MyLocalcluster1.Name[0]!= 'C')
                rez.Rows.Add(MyObjectList.ToArray());                
                
                //i++;
                
            }
             */ 
             
    
            return rez;
             
        }


        /// <summary>
        /// Cluster => ToDataTable(Кластеры и параметры)
        /// </summary>        
        /// <returns>Результат - таблица</returns>
        public static DataTable ClusterToDataTableV2(Cluster MyCluster)
        {
            DataTable rez = new DataTable();            
            //Добавляем колонки
            rez.Columns.Add("Параметры / Кластеры", typeof(string));
            foreach (Cluster MyLocalcluster in MyCluster.SCluster)
            {
                List<Cluster> MyList = MyLocalcluster.GetInClusterToListTurbo();
                //List<Cluster> MyList = ReGetInCluster(MyLocalcluster).SCluster;
                //ReGetInCluster
                MyLocalcluster.SCluster.Clear();
                MyLocalcluster.SCluster.AddRange(MyList);
                rez.Columns.Add(MyLocalcluster.Name, typeof(double));
            }

            //MyCluster .RecalculationClusterCenter();

            //Добавляем астрала кусок
            int i = 0;
            foreach(Group MyGroup in MyCluster.CGroupList) 
            {
                int j = 0;
                foreach (Param MyParam in MyGroup.GParamList)
                {
                    List<Object> MyObjectList = new List<Object>();
                    MyObjectList.Add(/*MyGroup.Name + */MyParam.Name);
                    foreach(Cluster MyLocalCluster in  MyCluster.SCluster)
                    {
                        MyObjectList.Add(MyLocalCluster.CGroupList[i].GParamList[j].P);
                    }
                    rez.Rows.Add(MyObjectList.ToArray());       
                    j++;
                }
                i++;
            }
            return rez;
        }
        #endregion
    }
}