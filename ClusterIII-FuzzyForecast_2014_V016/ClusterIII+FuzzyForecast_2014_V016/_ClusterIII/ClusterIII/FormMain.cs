using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClusterIII.View;
using ClusterIII.Model;
using ClusterIII.Converts;
using SavingLoadingNameSpace;
using ClusterIII.ClusterMethods;


namespace ClusterIII
{
    public partial class FormMain : Form
    {
        public Cluster ProjectsCluster= new Cluster();

        /// <summary>
        /// Подключение источника данных для таблици
        /// </summary>
        //BindingSource MyBindingSource = new BindingSource();
        
        public FormMain()
        {
            InitializeComponent();
            this.propertyGrid1.SelectedObject = ProjectsCluster;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormMain_SizeChanged(null, null);
            this.MySuperWriter();
            this.toolStripButton3_Click( null, null);
            DataTable MyDataTable = new DataTable();
            
            //this.dataGridView1.DataSource = MyBindingSource;
            /*
            #region Это заглушка
                    #warning 000 Это заглушка.(FormMain.Загрузить)
                    toolStripButton1_Click(null, null);
                    #warning 001 Это заглушка.(FormMain.Центройдный метод)
                    центройдныйМетодToolStripMenuItem_Click(null, null);
                    #warning 003 Это заглушка.(FormMain.Close)
                    this.Close();
            
            #endregion
             */ 
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            FormSupport.SizeChanged.MasterSlave2(this,this.toolStrip1,this.groupBox1,5,5,5,5);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.treeView1.Visible = true;
            this.propertyGrid1.Visible = false;
            this.dataGridView1.Visible=false;            
            groupBox1_SizeChanged(null, null);
            this.MySuperReader();
            this.MySuperWriter();
           
        }

        private void groupBox1_SizeChanged(object sender, EventArgs e)
        {
            FormSupport.SizeChanged.MasterSlave1(this.groupBox1, this.treeView1, 25, 5,5,5);
            FormSupport.SizeChanged.MasterSlave1(this.groupBox1, this.propertyGrid1, 25, 5,5,5);
            FormSupport.SizeChanged.MasterSlave1(this.groupBox1, this.dataGridView1, 25, 5,5,5);      
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.treeView1.Visible = false;
            this.propertyGrid1.Visible = true;
            this.dataGridView1.Visible = false;            
            groupBox1_SizeChanged(null, null);
            this.MySuperReader();
            this.MySuperWriter();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.treeView1.Visible = false;
            this.propertyGrid1.Visible = false;
            this.dataGridView1.Visible = true;            
            groupBox1_SizeChanged(null, null);
            this.MySuperReader();
            this.MySuperWriter();
        }


        /// <summary>
        /// Метод перезаписи данных на форме
        /// </summary>
        private void MySuperWriter()
        {
            this.propertyGrid1.SelectedObject = ProjectsCluster;
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(ViewConvert.ClusterTreeNode(ProjectsCluster));

            DataTable MyDataTable =ViewConvert.ClusterToDataTableV0(this.ProjectsCluster);
            this.dataGridView1.DataSource = MyDataTable;

                        
        }

        /// <summary>
        /// Метод чтения данных с формы. В частности таблици.
        /// </summary>
        private void MySuperReader()
        {
            this.propertyGrid1.SelectedObject = ProjectsCluster;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            
            DataImport MyForm1 = new DataImport();
            
            MyForm1.Owner = this;
            MyForm1.ShowDialog();
            if (MyForm1.DialogResult == DialogResult.OK)
            {
                this.ProjectsCluster = Iimport.Text_To_Cluster(MyForm1.textBox1.Text, this.ProjectsCluster);
                this.MySuperWriter();
            }
            MyForm1.Close();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.MySuperReader();
            this.ProjectsCluster.SameFaceClone();
            this.MySuperWriter();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.ProjectsCluster=SLSerializableService.StreamLoader();
            this.groupBox1.Text = "Название проэкта:   "+this.ProjectsCluster.Name;
            this.MySuperWriter();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.MySuperReader();
            SLSerializableService.StreamSaver(this.ProjectsCluster);
        }

        private void fCMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Вызаваем форму запроса параметров кластеризации            
            ClusterPlan MyPlanForm = new ClusterPlan(this.ProjectsCluster.FaceClone());
            MyPlanForm.Text = "FCM метод";
            MyPlanForm.ShowDialog();
            if (MyPlanForm.DialogResult == DialogResult.OK)
            {
                //Форма результата               
                FormResult MyFormResult = new FormResult
                    (                        
                        MyPlanForm.MyRealCluster,
                        Convert.ToInt16(MyPlanForm.toolStripTextBox1.Text),
                        2
                    );                                
                MyPlanForm.Close();                
                MyFormResult.ShowDialog();
            }              
        }

        private void центройдныйМетодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ;
            ClusterPlan MyPlanForm = new ClusterPlan(this.ProjectsCluster.FaceClone());
            MyPlanForm.Text = "Центроидный метод";
            MyPlanForm.ShowDialog();
            if (MyPlanForm.DialogResult == DialogResult.OK)
            {                
                ;
                //Форма кластер плана
                Cluster Cluster1 = new Cluster();
                Cluster Cluster2 = new Cluster();
                FormResult FormResult = new FormResult
                    (                        
                        MyPlanForm.MyRealCluster,
                        Convert.ToInt32(MyPlanForm.toolStripTextBox1.Text),
                        1                       
                    );                
                MyPlanForm.Close();

                FormResult.ShowDialog();//Это будет форма результата
            }            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }        
    }
}
