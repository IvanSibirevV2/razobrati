using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FuzzyForecast
{
    public partial class ProgressFormForTend : Form
    {
        public ProgressFormForTend(int max)
        {
            InitializeComponent();
            pb.Step = 1;
            pb.Maximum = max;
        }

        public void Incremet()
        {
            pb.Value += 1;
        }

        public void SetText(string s)
        {
            this.Text = s;
        }

        public string currentValue()
        {
            return pb.Value.ToString();
        }

        public string maxValue()
        {
            return pb.Maximum.ToString();
        }
    }
}
