using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing;


namespace MyСlusterWorkingSpace
{

    /// <summary>
    /// Базовые методы создания и визуализации кластера
    /// </summary>
    public class BasicMethodsOfCreationAndVisualizationCluster
    {
        /// <summary>
        /// Промежеточная переменная. Используется при создание кластера и его заполнения произвольными данными.
        /// </summary>
        public int CenterCount=5;        

        #region Методы програмного построения иерархической структуры кластера
        /// <summary>
        /// Создание "центра" кластера и его заполнения произвольными данными
        /// </summary>         
        public IntList CenterRandomCreater()
        {
            IntList MyLocalCenter = new IntList();
            Random rand = new Random();
            for (int i = 0; i < CenterCount; i++)
            {
                MyLocalCenter.Add(rand.Next(255));
            }    
            return MyLocalCenter;
        }
        
        /// <summary>
        /// Обьединение 2 групп кластеров нижнего иерархического уровня
        /// </summary>
        public ClusterList DualClusterList(Cluster ACluster, Cluster BCluster) 
        {
            ClusterList MyLocalStructureCluster=new ClusterList();            
            MyLocalStructureCluster.Add(ACluster);
            MyLocalStructureCluster.Add(BCluster);
            return MyLocalStructureCluster;        
        }

        /// <summary>
        /// Создание кластера, сотоящего из многих обьектов("центр" кластера + кластеры нижнего иерархического уровня)
        /// </summary>
        public Cluster ClusterCreater(IntList MyCenter, ClusterList MyStructureCluster)
        { 
            Cluster MyLocalCluster = new Cluster();
            MyLocalCluster.Center = MyCenter;
            MyLocalCluster.StructureCluster = MyStructureCluster;            
            return MyLocalCluster;        
        }

        /// <summary>
        /// Создание кластера, сотоящего из одного обьекта(данные заносятся в "центр" кластера)
        /// </summary>        
        public Cluster ClusterCreater(IntList MyCenter)
        {
            Cluster MyLocalCluster = new Cluster();
            MyLocalCluster.Center = MyCenter;            
            return MyLocalCluster;
        }
        #endregion

        #region Методы визуализации кластерного рабочего стола
        //Эта группа методов позволяет создать в окне формы визуализацию кластера с помощью вызова метода  treeView1.Nodes.Add(MCT.ClusterTreeNode(MyCluster));     

        /// <summary>
        /// Создание TreeNode на основе "центра" кластера
        /// </summary>
        private TreeNode CenterTreeNode(IntList MyLocalCenter)
        {
            TreeNode[] TreeNodeArray = new TreeNode[MyLocalCenter.Count];
            MyColors Palette = new MyColors();
            for (int i = 0; i < MyLocalCenter.Count; i++)
            {
                TreeNodeArray[i] = new TreeNode();
                TreeNodeArray[i].Text =
                        Convert.ToString(MyLocalCenter[i]);
                TreeNodeArray[i].ForeColor = Palette.MyForeGround.CenterValue;
            }
            return new TreeNode("Центр(Center)", TreeNodeArray);//MyLocalTreeNode;//MyLocalTreeNode;//Node
        }

        /// <summary>
        /// Создание TreeNode на основе кластеров нижнего иерархического уровня
        /// </summary>
        private TreeNode StructureClusterTreeNode(ClusterList MyStructureCluster)
        {
            TreeNode[] TreeNodeArray = new TreeNode[MyStructureCluster.Count];
            for (int i = 0; i < MyStructureCluster.Count; i++)
            {
                TreeNodeArray[i] = new TreeNode();
                TreeNodeArray[i] = ClusterTreeNode(MyStructureCluster[i]);                    
            }
            return new TreeNode("Содержимое", TreeNodeArray);//MyLocalTreeNode;//MyLocalTreeNode;//Node
        }

        /// <summary>
        /// Создание TreeNode на основе кластеров нижнего иерархического уровня
        /// </summary>
        private TreeNode ClusterCalculatedValueTreeNode(Cluster MyLocalCluster)
        {
            TreeNode[] TreeNodeArray = new TreeNode[1];
            MyColors Palette = new MyColors();
            TreeNodeArray[0] = new TreeNode();
            TreeNodeArray[0].Text = "R=" + Convert.ToString(MyLocalCluster.Radius());
            TreeNodeArray[0].ForeColor = Palette.MyForeGround.CenterValue;            
            return new TreeNode("Прочее", TreeNodeArray);//MyLocalTreeNode;//MyLocalTreeNode;//Node
        }
        
        /// <summary>
        /// Создание TreeNode на основе  кластера
        /// </summary>
        public TreeNode ClusterTreeNode(Cluster MyLocalCluster)
        {
            MyColors Palette = new MyColors();

            TreeNode[] TreeNodeArray = new TreeNode[3];
            TreeNodeArray[0] = new TreeNode();
            TreeNodeArray[0] = CenterTreeNode(MyLocalCluster.Center);
            TreeNodeArray[0].ForeColor = Palette.MyForeGround.Center; // System.Drawing.Color.FromArgb(175, 75, 75);

            TreeNodeArray[1] = new TreeNode();
            TreeNodeArray[1] = ClusterCalculatedValueTreeNode(MyLocalCluster);
            TreeNodeArray[1].ForeColor = Palette.MyForeGround.Center; //System.Drawing.Color.FromArgb(75, 75, 175);
            
            TreeNodeArray[2] = new TreeNode();
            TreeNodeArray[2] = StructureClusterTreeNode(MyLocalCluster.StructureCluster);
            TreeNodeArray[2].ForeColor = Palette.MyForeGround.StructureCluster; //System.Drawing.Color.FromArgb(75, 75, 175);

            

            TreeNode TreeNodeRez = new TreeNode();
            TreeNodeRez = new TreeNode("Кластер(Cluster)", TreeNodeArray);
            TreeNodeRez.Text = MyLocalCluster.Name;

            TreeNodeRez.ForeColor = Palette.MyForeGround.Cluster;//System.Drawing.Color.FromArgb(75, 175, 75);
            //TreeNodeRez.Checked;
            return TreeNodeRez;
        }

   

        #endregion

        #region Методы визуализации таблици расстояний подкластеров.

        #endregion


    }

}