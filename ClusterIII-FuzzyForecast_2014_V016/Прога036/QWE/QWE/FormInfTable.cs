using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyСlusterWorkingSpace;
using Microsoft;

namespace WindowsFormsApplication1
{
    public partial class FormInfTable : Form
    {
        private Cluster MyLocalCluster = new Cluster();
        /// <summary>
        /// Метод передачи данных в форму.
        /// </summary>
        /// <param name="MyCluster">Переменная локальная. Передаёт список кластеров для обработки.</param>
        /// <param name="S">Переменная локальная. Строка пути к XML файлу. Используется как загаловок таблици.</param>
        public FormInfTable(Cluster MyCluster, string S)
        {
            InitializeComponent();
            MyLocalCluster.StructureCluster = MyCluster.StructureCluster.GetOllCluster(MyCluster.StructureCluster);
            groupBox1.Text = S;
            строитьToolStripMenuItem.Visible = false;
            общихДанныхToolStripMenuItem.Visible = false;
        }

        /// <summary>
        /// Метод. Сценарий. Обработка и вывод таблици дистанций.
        /// </summary>
        public void ShowDistances()
        {
            Visible = true;
            строитьToolStripMenuItem.Visible = true;
            Text = "Таблица дистанций";

            BasicMethodsOfClusterСalсulations BMOCС = new BasicMethodsOfClusterСalсulations();            
            DataGridViewTextBoxColumn w = new DataGridViewTextBoxColumn();
            w.Name = "/";
            dataGridView1.Columns.Add(w);

            for (int i = 0; i < MyLocalCluster.StructureCluster.Count; i++)
            {
                DataGridViewTextBoxColumn q = new DataGridViewTextBoxColumn();
                q.Name = MyLocalCluster.StructureCluster[i].Name;
                dataGridView1.Columns.Add(q);
            }
            for (int i = 0; i < MyLocalCluster.StructureCluster.Count; i++)
            {
                DataGridViewTextBoxColumn p = new DataGridViewTextBoxColumn();
                p.Name = MyLocalCluster.StructureCluster[i].Name;
                dataGridView1.Rows.Add(p.Name);
            }

            for (int i = 0; i < MyLocalCluster.StructureCluster.Count; i++)
                for (int j = 0; j < MyLocalCluster.StructureCluster.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j + 1].Value = Convert.ToString(BMOCС.Distance(MyLocalCluster.StructureCluster[i], MyLocalCluster.StructureCluster[j]));
                    if (i == j)
                    {
                        dataGridView1.Rows[i].Cells[j + 1].Style.BackColor = Color.FromArgb(255, 255, 150, 150);
                        dataGridView1.Rows[i].Cells[j + 1].Style.ForeColor = Color.FromArgb(255, 0, 0, 255);
                    }
                }
            //Задаём начальные размеры формы и её элементов
            StartingFormSize();
        }

        
        /// <summary>
        /// Метод. Сценарий. Обработка и вывод таблици общих данных.
        /// </summary>
        public void ShowOll_Inf()
        {
            Visible = true;
            общихДанныхToolStripMenuItem.Visible = true;
            Text = "Таблица общих данных";

            BasicMethodsOfClusterСalсulations BMOCС = new BasicMethodsOfClusterСalсulations();
            DataGridViewTextBoxColumn w1 = new DataGridViewTextBoxColumn();
            w1.Name = "/";
            dataGridView1.Columns.Add(w1);
            DataGridViewTextBoxColumn w2 = new DataGridViewTextBoxColumn();
            w2.Name = "Радиус";
            dataGridView1.Columns.Add(w2);


            if (MyLocalCluster.StructureCluster.Count() != 0)
            {
                for (int i = 0; i < MyLocalCluster.StructureCluster[0].Center.Count; i++)
                {
                    DataGridViewTextBoxColumn q = new DataGridViewTextBoxColumn();
                    q.Name = "Center[" + Convert.ToString(i) + "]";
                    dataGridView1.Columns.Add(q);

                }
                for (int i = 0; i < MyLocalCluster.StructureCluster.Count; i++)
                {
                    DataGridViewTextBoxColumn p = new DataGridViewTextBoxColumn();
                    p.Name = MyLocalCluster.StructureCluster[i].Name;
                    dataGridView1.Rows.Add(p.Name);
                }
                for (int i = 0; i < MyLocalCluster.StructureCluster.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(MyLocalCluster.StructureCluster[i].Radius());
                }

                for (int i = 0; i < MyLocalCluster.StructureCluster.Count; i++)
                {
                    for (int j = 0; j < MyLocalCluster.StructureCluster[0].Center.Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j + 2].Value = Convert.ToString(MyLocalCluster.StructureCluster[i].Center[j]);
                    }
                }
                //Задаём начальные размеры формы и её элементов
                StartingFormSize();
            }
        }

        /// <summary>
        /// Метод обработки события изменения размера формы.
        /// </summary>
        private void FormDistancesTable_ClientSizeChanged(object sender, EventArgs e)
        {
            if (Width >= 225)
                if (Height >= 175)
                {
                    /*
                    groupBox1.Width = Width - groupBox1.Left - 20;
                    dataGridView1.Width = groupBox1.Width - (dataGridView1.Left - groupBox1.Left) - 15;

                    groupBox1.Height = Height - groupBox1.Top - 45;
                    dataGridView1.Height = groupBox1.Height - (dataGridView1.Top - groupBox1.Top) - 30;
                     */
                    groupBox1.Width = Width - groupBox1.Left - 20;
                    dataGridView1.Width = groupBox1.Width - (dataGridView1.Left - groupBox1.Left) - 25;

                    groupBox1.Height = Height - groupBox1.Top - 45;
                    dataGridView1.Height = groupBox1.Height - (dataGridView1.Top - groupBox1.Top) - 50;                    
                }
        }

        /// <summary>
        /// Метод присвоения начальных размеров элементов формы
        /// </summary>
        private void StartingFormSize()
        {
            Width = 325;
            Height = 375;
            menuStrip1.Top = 0;
            menuStrip1.Left = 0;

            groupBox1.Top = menuStrip1.Top + menuStrip1.Height;            
            groupBox1.Left = 5;

            dataGridView1.Top = groupBox1.Top + 15;
            dataGridView1.Left = groupBox1.Left + 5;
            FormDistancesTable_ClientSizeChanged(null, null);            
        }

        private void строитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInfDiagram MyFormDiagram = new FormInfDiagram(MyLocalCluster, groupBox1.Text);
            MyFormDiagram.ShowDistances();
        }

        private void FormInfTable_Load(object sender, EventArgs e)
        {

        }

        private void общихДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        



    }
}
