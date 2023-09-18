using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QWE_2015_003
{
    
    public partial class TextDataSaveLoadForm : Form
    {
        
        
        private int LWidth=0;
        private int LHeight=0;
        /// <summary>Конструктор формы текстовых табличных данных</summary><param name="TextData">текстовые табличные данные</param><param name="path"> путь к файлу для записи данных</param>
        public TextDataSaveLoadForm(string path)
        {
            string PLog = "";
            string Log = PLog + "Form1_TDSLF";//,string PLog
            C.Log.Go(PLog, "Form1_TextDataSaveLoadForm");
            InitializeComponent();
            this.LWidth=this.Width;
            this.LHeight = this.Height;
            textBox2.Text = path;
            textBox1.Text = PreProInpDat.ConverD.ListListStringToInputData((new SaveLoadTextDataTableModel()).LoadTextDataTable(textBox2.Text, Log), Log);
        }
        public List<List<string>> GO(string PLog)
        {            
            string Log = PLog + "F1G";//,string PLog
            C.Log.Go(PLog, "Form1_GO");
            List<List<string>> rez_ = new List<List<string>>();
            if (this.ShowDialog(/*this*/) == DialogResult.OK) { textBox1.Text = PreProInpDat.ConverD.ListListStringToInputData((new SaveLoadTextDataTableModel()).LoadTextDataTable(textBox2.Text, Log), Log); rez_ = PreProInpDat.ConverD.InputDataToListListString(textBox1.Text, Log); } else { MessageBox.Show("TextDataSaveLoadForm.GO() -неудача"); }
            return rez_;
        }
        private void Form1_Load(object sender, EventArgs e){}
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            string PLog = "";
            string Log = PLog + "F1_SC";
            C.Log.Go(PLog, "Form1_SizeChanged");
            this.textBox1.Width += 0 - this.LWidth + this.Width;
            this.button1.Width += 0 - this.LWidth + this.Width;                        
            this.LWidth = this.Width;
            this.LHeight = this.Height;
        }
        private void textBox2_TextChanged(object sender, EventArgs e){}
        private void button1_Click(object sender, EventArgs e)
        {
            string PLog = "";
            string Log = PLog + "F1_b1C";
            C.Log.Go(PLog, "Form1_button1_Click");
            new SaveLoadTextDataTableModel(this.textBox1.Text, Log).SaveTextDataTable(this.textBox2.Text, Log);
            this.DialogResult =  DialogResult.OK;
        }
        private void textBox1_TextChanged(object sender, EventArgs e){}
    }
}
