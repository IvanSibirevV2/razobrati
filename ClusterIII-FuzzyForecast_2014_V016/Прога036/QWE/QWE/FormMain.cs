using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyСlusterWorkingSpace;


namespace WindowsFormsApplication1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public BasicMethodsOfCreationAndVisualizationCluster /*BasicMethodsCreationAndVisualizationCluster*/VisualizerCluster = new BasicMethodsOfCreationAndVisualizationCluster();
        public BasicMethodsOfSavingLoadingClusterFile /*BasicMethodsOfSavingLoadingClusterFile*/ SavingLoadingCluster = new BasicMethodsOfSavingLoadingClusterFile();
        public BasicMethodsOfClusterСalсulations ClusterСalсulations = new BasicMethodsOfClusterСalсulations();
        public Cluster MyCluster = new Cluster();
        public String FileName="";
        public TreeNode MyLastTreeNode = new TreeNode();

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(VisualizerCluster.ClusterTreeNode(MyCluster));
            сохранитьToolStripMenuItem.Visible = false;
                        
            //Задаём начальные размеры формы и её элементов
            Width = 325;
            Height = 375;
            groupBox1.Top = menuStrip1.Top + menuStrip1.Height;
            treeView1.Top = groupBox1.Top+15;
            groupBox1.Left = 5;
            treeView1.Left =groupBox1.Left +5;            
            Form1_ClientSizeChanged(null, null);
         }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            if (Width >= 225)
                if (Height >= 175)
                {
                    groupBox1.Width = Width - groupBox1.Left - 20;
                    treeView1.Width = groupBox1.Width - (treeView1.Left - groupBox1.Left) - 25;

                    groupBox1.Height = Height - groupBox1.Top - 45;
                    treeView1.Height = groupBox1.Height - (treeView1.Top - groupBox1.Top) - 50;
                }
        }



        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem.Visible = true;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML files|*.xml";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;
            FileName = fileDialog.FileName;
            MyCluster=SavingLoadingCluster.LoadingClusterFromXml(fileDialog.FileName);
            treeView1.Nodes.Clear();
            ClusterСalсulations.ClusterCenterReloading(MyCluster);
            treeView1.Nodes.Add(VisualizerCluster.ClusterTreeNode(MyCluster));
            groupBox1.Text =FileName;
            
            //uheggbhjdrfToolStripMenuItem.Text=
            //Form1.
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "XML files|*.xml";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;
            SavingLoadingCluster.SavingClusterToXml(MyCluster, fileDialog.FileName);            
            /*filename = fileDialog.FileName;
            SaveProject();
             * */
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            /*
             * if (FileName == "")
                сохранитьКакToolStripMenuItem_Click(null, null);
            else
                SavingLoadingCluster.SavingClusterToXml(MyCluster, FileName); 
             */ 
            Application.Exit();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavingLoadingCluster.SavingClusterToXml(MyCluster, FileName);                  
        }
        
        private void Form1_Exit(object sender, EventArgs e)
        {            
                сохранитьКакToolStripMenuItem_Click(null, null);                     
        }

        private void центроидныйМетодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            MyCluster = ClusterСalсulations.WeighedGroups(MyCluster);                        
            ClusterСalсulations.ClusterCenterReloading(MyCluster);
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(VisualizerCluster.ClusterTreeNode(MyCluster));
            сохранитьКакToolStripMenuItem_Click(null, null);
             */
        }




        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int i = 0;
            MyColors Palette = new MyColors();
            if (treeView1.SelectedNode.ForeColor == Palette.MyForeGround.Cluster)            
                for (i=0; i < treeView1.SelectedNode.Nodes.Count; i++)
                    treeView1.SelectedNode.Nodes[i].BackColor = Palette.MyBackGround.Cluster;

            if (treeView1.SelectedNode.ForeColor == Palette.MyForeGround.Center)
                for (i = 0; i < treeView1.SelectedNode.Nodes.Count; i++)
                    treeView1.SelectedNode.Nodes[i].BackColor = Palette.MyBackGround.Center;

            if (treeView1.SelectedNode.ForeColor == Palette.MyForeGround.StructureCluster)
                for (i = 0; i < treeView1.SelectedNode.Nodes.Count; i++)
                    treeView1.SelectedNode.Nodes[i].BackColor = Palette.MyBackGround.StructureCluster;            

            for (i = 0; i < MyLastTreeNode.Nodes.Count; i++)            
                MyLastTreeNode.Nodes[i].BackColor = Palette.MyBackGround.NoSelected;
            //MyLastTreeNode.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            
            /*treeView1.SelectedNode.
                TreeNodeArray[0].ForeColor = System.Drawing.Color.FromArgb(175, 75, 75);
            TreeNodeArray[1].ForeColor = System.Drawing.Color.FromArgb(75, 75, 175);
            TreeNodeRez.ForeColor = System.Drawing.Color.FromArgb(75, 175, 75);
             * */
            MyLastTreeNode = treeView1.SelectedNode;    
        }

        private void таблицаДистанцийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInfTable MyFormDistancesTable = new FormInfTable(MyCluster, groupBox1.Text);                       
            MyFormDistancesTable.Visible = true;
            MyFormDistancesTable.ShowDistances();
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            int f;
            try 
            {
                toolStripTextBox1.BackColor = Color.FromArgb(255, 255, 255, 255);
                стартToolStripMenuItem.Visible = true;

                f = Convert.ToInt32(toolStripTextBox1.Text); 
            }
            catch
            {
                стартToolStripMenuItem.Visible = false;
                toolStripTextBox1.BackColor = Color.FromArgb(255, 255, 150, 150);
            }
            if (toolStripTextBox1.BackColor == Color.FromArgb(255, 255, 255, 255))             
                if (Convert.ToInt32(toolStripTextBox1.Text) < 1) toolStripTextBox1.Text = "1";            

        }


        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MyCluster = ClusterСalсulations.WeighedGroups(MyCluster, Convert.ToInt32(toolStripTextBox1.Text));
            ClusterСalсulations.ClusterCenterReloading(MyCluster);
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(VisualizerCluster.ClusterTreeNode(MyCluster));
            сохранитьКакToolStripMenuItem_Click(null, null);
        }

        private void таблицаРадиусовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInfTable MyFormDistancesTable = new FormInfTable(MyCluster, groupBox1.Text);
            MyFormDistancesTable.ShowOll_Inf();
        }


    }
}
