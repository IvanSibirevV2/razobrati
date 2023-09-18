using System.Windows.Forms;

namespace FuzzyForecast {
  public partial class SeriesSettingsForm : Form {

    public string SeriesName { 
      get { return textBoxName.Text; }
      set { textBoxName.Text = value;}
    }

    public string XName {
      get { return textBoxXName.Text; }
      set { textBoxXName.Text = value; }
    }
 
    public string YName {
      get { return textBoxYName.Text; }
      set { textBoxYName.Text = value; }
    }

    public SeriesSettingsForm() {
      InitializeComponent();
    }

    public SeriesSettingsForm(Series s) {
      InitializeComponent();
      SetInfo(s);
    }

    private void SetInfo(Series s) {
      if (s.PointList == null)
        return;
      SeriesName = (s.PointList.Name != "") ? s.PointList.Name : SeriesName;
      XName = (s.PointList.XName != "") ? s.PointList.XName : XName;
      YName = (s.PointList.YName != "") ? s.PointList.YName : YName;
    }
  }
}
