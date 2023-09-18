using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FuzzyForecast {
  public partial class ReportForm : Form {
    public ReportForm(string url) {
      InitializeComponent();
      webBrowser.Url = new Uri(url);
    }
  }
}
