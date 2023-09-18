using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FuzzyForecast
{
    public partial class ExtendedTerms : Form
    {
        public ExtendedTerms()
        {
            InitializeComponent();
            lowerExtTends.Value = Convert.ToDecimal(MainForm.lowerExtraTerms);
            upperExtTends.Value = Convert.ToDecimal(MainForm.upperExtraTerms);
        }

        private void lowerExtTends_ValueChanged(object sender, EventArgs e)
        {
            MainForm.lowerExtraTerms = Convert.ToInt32(lowerExtTends.Value);
        }

        private void upperExtTends_ValueChanged(object sender, EventArgs e)
        {
            MainForm.upperExtraTerms = Convert.ToInt32(upperExtTends.Value);
        }
    }
}
