using System.Collections.Generic;
using System.Windows.Forms;
using FuzzyLibrary;

namespace FuzzyForecast {
  public partial class FuzzyScaleSettingForm : Form {

    public FuzzyScaleSettingForm(string scaleName, List<FuzzyTerm> terms, bool editScale) {
      InitializeComponent();
      mfEdit.Set(scaleName, terms, editScale);
    }

    public List<FuzzyTerm> GetTerms() {
      return mfEdit.GetTerms();
    }
  }
}
