using FuzzyLibrary;

namespace FuzzyForecast {
  public class TFuzzyTermInfo {

    public string Name { get; set; }

    public double X1 { get; set; }

    public double X2 { get; set; }

    public double X3 { get; set; }

    public double X4 { get; set; }

    public TFuzzyTermInfo() {
    }

    public TFuzzyTermInfo(FuzzyTerm term) {
      var tmf = (TrapezoidMembershipFunction) term.MembershipFunction;
      Name = term.Name;
      X1 = tmf.X1;
      X2 = tmf.X2;
      X3 = tmf.X3;
      X4 = tmf.X4;
    }

    public FuzzyTerm CreateTerm() {
      return new FuzzyTerm(Name, new TrapezoidMembershipFunction(X1, X2, X3, X4));
    }
  }
}
