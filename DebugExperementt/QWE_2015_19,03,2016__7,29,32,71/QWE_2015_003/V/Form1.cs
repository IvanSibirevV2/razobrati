using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QWE_2015_003{
    public partial class Form1 : Form{
        List<List<string>> LLS = new List<List<string>>();
        private int LWidth=0;
        private int LHeight = 0;
        public Form1(List<List<string>> L_L_S, string qwe, string PLog)
        {
            string Log = PLog + ".DT_LLLS";//,string PLog
            C.Log.Go(PLog, "DT_LLLS");
            InitializeComponent();
            this.LWidth=this.Width;
            this.LHeight=this.Height;
            LLS = C.COPY.LLS(L_L_S);
            System.Data.DataTable DT= new System.Data.DataTable();
            for (int j = 0; j < L_L_S[0].Count(); j++) DT.Columns.Add(L_L_S[0][j]);
            for (int i = 0; i < L_L_S.Count(); i++){
                List<string> LS =new List<string>();
                for (int j = 0; j < L_L_S[0].Count(); j++) LS.Add(Convert.ToString(L_L_S[i][j]));
                DT.Rows.Add(LS.ToArray());
            }
            this.dataGridView1.DataSource = DT;
            this.Text = qwe;            
        }
        private void Form1_Load(object sender, EventArgs e){
            for (int j = 0; j < dataGridView1.Rows[0].Cells.Count; j++)
            {
                Double max = -999999999999999999;
                Double min = 999999999999999999;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    try
                    {
                        Double q = Convert.ToDouble(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value));
                        if (q > max) max = q;
                        if (q < min) min = q;
                    }
                    catch { }
                }
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    Boolean f= true;
                    dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Gray;
                    if (f) { try { Double q = Convert.ToDouble(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value)); } catch { dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Cyan; f = false; } }
                    if (f) if (Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) == "NaN") { dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Black; f = false; }
                    if (f) {
                        try{
                        string s = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                        Double q = Convert.ToDouble(s);
                        byte c = (byte)((int)q * 255 / (max - min));
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(250, 255 *  2/ 3 + (255 - c) / 3, 255  * 2/ 3 + (255 - c) / 3);
                            f = false; 
                        }catch{}                        
                    }
                }
                max = -999999999999999999;
                min = 999999999999999999;
            }
        }
        public void GO() {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(this);
            if (this.ShowDialog(/*this*/) == DialogResult.OK){}else { }
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Width += 0-this.LWidth + this.Width;
            this.dataGridView1.Height += 0 - this.LHeight + this.Height;
            this.LWidth = this.Width;
            this.LHeight = this.Height;
        }
        private void dataGridView2_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e){}
    }
}
