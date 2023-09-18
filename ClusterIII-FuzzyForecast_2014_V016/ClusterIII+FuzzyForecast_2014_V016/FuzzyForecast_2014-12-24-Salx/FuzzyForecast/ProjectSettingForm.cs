using System.Windows.Forms;

namespace FuzzyForecast {
  public partial class ProjectSettingForm :Form {
    
    public string ProjectName {
      get { return textBoxName.Text; }
      set { textBoxName.Text = value; }
    }

    public ProjectSettingForm() {
      InitializeComponent();
    }

    public void Set(Project prj) {
      textBoxName.Text = prj.Name;
    }

    private void textBoxName_TextChanged(object sender, System.EventArgs e) {
      buttonOK.Enabled = !(textBoxName.Text == "");
    }
  }
}
