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
    public partial class DataImport : Form
    {
        public DataImport()
        {
            InitializeComponent();
        }

        private void DataImport_SizeChanged(object sender, EventArgs e)
        {
            FormSupport.SizeChanged.MasterSlave2(this, this.menuStrip1, this.groupBox1, 5, 5, 5, 5);
        }

        private void DataImport_Load(object sender, EventArgs e)
        {
            DataImport_SizeChanged(null, null);
        }

        private void подтвердитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void groupBox1_SizeChanged(object sender, EventArgs e)
        {
            FormSupport.SizeChanged.MasterSlave1(this.groupBox1, this.textBox1, 25, 5, 5, 5);
        }
    }
}
