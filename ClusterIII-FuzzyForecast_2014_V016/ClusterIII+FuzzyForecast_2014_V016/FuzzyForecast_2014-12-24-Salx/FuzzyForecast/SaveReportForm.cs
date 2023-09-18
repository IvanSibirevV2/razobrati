using System.IO;
using System.Windows.Forms;

namespace FuzzyForecast {
  public partial class SaveReportForm : Form {

    public string ReportName { 
      get { return textBoxName.Text; }
      set { textBoxName.Text = value;}
    }

    public string ReportFolder {
      get { return textBoxFolder.Text; }
      set { 
        textBoxFolder.Text = value;
        folderBrowserDialog.SelectedPath = value;
      }
    }

    public bool ReportShow {
      get { return checkBoxShow.Checked; }
    }
    
    public SaveReportForm() {
      InitializeComponent();
      textBoxFolder.Text = folderBrowserDialog.SelectedPath;
    }

    private void textBox_TextChanged(object sender, System.EventArgs e) {
      buttonOK.Enabled = ((Control)sender).Text != "";
    }

    private void buttonBrowse_Click(object sender, System.EventArgs e) {
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK) {
        return;
      }
      textBoxFolder.Text = folderBrowserDialog.SelectedPath;
    }
  }
}
