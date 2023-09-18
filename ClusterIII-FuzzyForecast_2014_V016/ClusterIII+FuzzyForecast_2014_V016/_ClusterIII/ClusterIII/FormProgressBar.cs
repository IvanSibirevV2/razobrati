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

namespace ClusterIII
{
    public partial class FormProgressBar : Form
    {
        public FormProgressBar(int A, int B)
        {
            InitializeComponent();
            this.Top=A;
            this.Left=B;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            FormSupport.SizeChanged.MasterSlave1(this, this.progressBar1, 5, 45, 5, 20);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1_SizeChanged(null, null);
        }
    }
}
