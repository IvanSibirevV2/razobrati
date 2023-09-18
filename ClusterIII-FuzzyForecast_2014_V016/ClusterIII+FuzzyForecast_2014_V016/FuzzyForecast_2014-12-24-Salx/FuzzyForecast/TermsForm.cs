using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FuzzyLibrary;


namespace FuzzyForecast {
  public partial class TermsForm : Form {
    private readonly List<FuzzyTerm> terms;
    private readonly string ScaleName;

    public TermsForm(List<FuzzyTerm> terms, string name) {
      this.terms = terms;
      ScaleName = name;
      InitializeComponent();
      DrawHelper.CleanseGraph(graphControl);
      DrawHelper.DrawFuzzyTerms(graphControl, ScaleName, terms);
    }
  }
}
