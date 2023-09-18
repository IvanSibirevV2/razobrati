using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyСlusterWorkingSpace;

//using System.Drawing;

namespace WindowsFormsApplication1
{
    public partial class FormInfDiagram : Form
    {

        private Cluster MyLocalCluster = new Cluster();
        /// <summary>
        /// Метод передачи данных в форму.
        /// </summary>
        /// <param name="MyCluster">Переменная локальная. Передаёт список кластеров для обработки.</param>
        /// <param name="S">Переменная локальная. Строка пути к XML файлу. Используется как загаловок таблици.</param>
        public FormInfDiagram(Cluster MyCluster, string S)
        {
            InitializeComponent();
             MyLocalCluster.StructureCluster = MyCluster.StructureCluster.GetOllCluster(MyCluster.StructureCluster);
            groupBox1.Text = S;
        }

        public void ShowDistances()
        {
            BasicMethodsOfClusterСalсulations BMOCС = new BasicMethodsOfClusterСalсulations();
            //BMOCС.Distance(MyLocalCluster.StructureCluster[i], MyLocalCluster.StructureCluster[j]));
            Visible = true;
            //chart1.Series.Clear();            
            
            
            if (MyLocalCluster.StructureCluster.Count!=0)
                for( int i = 0 ; i < MyLocalCluster.StructureCluster.Count ; i ++ )
                {
                    chart1.Series.Add(MyLocalCluster.StructureCluster[i].Name);
                    
                    chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                    chart1.Series[i].Color = Color.FromArgb(255, Convert.ToInt32(i*255 / MyLocalCluster.StructureCluster.Count), 0, 150);
                    //double[] d = new double[MyLocalCluster.StructureCluster[i].Center.Count];
                    for (int j = 0; j < MyLocalCluster.StructureCluster[i].Center.Count; j++)
                    {
                        // chart1.Series[i].Points.AddXY(,null);//i,MyLocalCluster.StructureCluster[i].Center[j]);
                        //chart1.Series[i].Points.Add(i);                        
                        chart1.Series[i].Points.AddXY( j , BMOCС.Distance( MyLocalCluster.StructureCluster[ i ] , MyLocalCluster.StructureCluster[ j ] ) );
                    }
              //      chart1.Series[i].s;
                    
                }
            

        }

        private void FormDiagram_ClientSizeChanged(object sender, EventArgs e)
        {
            if (Width >= 225)
                if (Height >= 175)
                {
                    groupBox1.Width = Width - groupBox1.Left - 20;
                    chart1.Width = groupBox1.Width - (chart1.Left - groupBox1.Left) - 25;

                    groupBox1.Height = Height - groupBox1.Top - 45;
                    chart1.Height = groupBox1.Height - (chart1.Top - groupBox1.Top) - 50;
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

            chart1.Top = groupBox1.Top + 15;
            chart1.Left = groupBox1.Left + 5;
            FormDiagram_ClientSizeChanged(null, null);
        }


        private void FormDiagram_Load(object sender, EventArgs e)
        {
           /*
            chart1.Series.Clear();
            chart1.Series.Add("TestName");

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline; // тут сами поизменяет/повыбирайте тип вывода графика
 

            for (int i = 0; i < 10; i++)
                chart1.Series[0].Points.AddXY(i, i+1);
            //this.chart1.
            * */
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }


    }
}
