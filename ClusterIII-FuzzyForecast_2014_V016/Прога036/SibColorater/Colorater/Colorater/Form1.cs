using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Colorater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String s;
            s=Convert.ToString(trackBar1.Value)+",";
            s=s+Convert.ToString(trackBar2.Value)+",";
            s=s+Convert.ToString(trackBar3.Value);
            textBox1.Text = "Фон("+s+")"+";   ";
            s = Convert.ToString(trackBar4.Value) + ",";
            s = s + Convert.ToString(trackBar5.Value) + ",";
            s = s + Convert.ToString(trackBar6.Value) ;
            textBox1.Text = textBox1.Text + "Цвет(" + s + ")" + ";   ";            
            textBox1.Text = textBox1.Text + "Размер(" + Convert.ToString(textBox1.Font.Size) + ")" + ";   ";
            textBox1.BackColor = Color.FromArgb(255, trackBar1.Value, trackBar2.Value,trackBar3.Value);
            textBox1.ForeColor = Color.FromArgb(255, trackBar4.Value, trackBar5.Value, trackBar6.Value);
        }


        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void trackBar6_ValueChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
            button1.Visible=false;
        }

      
    }
}
