using System;
using System.Collections.Generic;


namespace FuzzyLibrary {
  /// <summary>
  /// Mamdani fuzzy inference system
  /// </summary>
  public class MamdaniFuzzySystem :GenericFuzzySystem {
    public const double SelectionRulesBoundZero = 0.0000001;

    /// <summary>
    /// отображение строки правила на правила 
    /// </summary>
    public Dictionary<string, List<MamdaniFuzzyRule>> ConditionMap;

    List<FuzzyVariable> _output = new List<FuzzyVariable>();
    List<MamdaniFuzzyRule> _rules = new List<MamdaniFuzzyRule>();

    ImplicationMethod _implMethod = ImplicationMethod.Min;
    AggregationMethod _aggrMethod = AggregationMethod.Max;
    DefuzzificationMethod _defuzzMethod = DefuzzificationMethod.Centroid;

    private double selectionRulesBound = SelectionRulesBoundZero;
    public double SelectionRulesBound {
      get {
        return selectionRulesBound;
      }
      set {
        selectionRulesBound = value < SelectionRulesBoundZero ? SelectionRulesBoundZero : value;
      }
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public MamdaniFuzzySystem() {
    }

    /// <summary>
    /// Output linguistic variables
    /// </summary>
    public List<FuzzyVariable> Output {
      get { return _output; }
    }

    /// <summary>
    /// Fuzzy rules
    /// </summary>
    public List<MamdaniFuzzyRule> Rules {
      get { return _rules; }
    }

    /// <summary>
    /// Implication method
    /// </summary>
    public ImplicationMethod ImplicationMethod {
      get { return _implMethod; }
      set { _implMethod = value; }
    }

    /// <summary>
    /// Aggregation method
    /// </summary>
    public AggregationMethod AggregationMethod {
      get { return _aggrMethod; }
      set { _aggrMethod = value; }
    }

    /// <summary>
    /// Defuzzification method
    /// </summary>
    public DefuzzificationMethod DefuzzificationMethod {
      get { return _defuzzMethod; }
      set { _defuzzMethod = value; }
    }

    /// <summary>
    /// Get output linguistic variable by its name
    /// </summary>
    /// <param name="name">Variable's name</param>
    /// <returns>Found variable</returns>
    public FuzzyVariable OutputByName(string name) {
      foreach (FuzzyVariable var in _output) {
        if (var.Name == name) {
          return var;
        }
      }

      throw new KeyNotFoundException();
    }

    /// <summary>
    /// Create new empty rule
    /// </summary>
    /// <returns></returns>
    public MamdaniFuzzyRule EmptyRule() {
      return new MamdaniFuzzyRule();
    }

    /// <summary>
    /// Parse rule from the string
    /// </summary>
    /// <param name="rule">String containing the rule</param>
    /// <returns></returns>
    public MamdaniFuzzyRule ParseRule(string rule) {
      return RuleParser<MamdaniFuzzyRule, FuzzyVariable, FuzzyTerm>.Parse(rule, EmptyRule(), Input, Output);
    }

    /// <summary>
    /// Calculate output values
    /// </summary>
    /// <param name="inputValues">Input values (format: variable - value)</param>
    /// <returns>Output values (format: variable - value)</returns>
    public Dictionary<FuzzyVariable, double> Calculate(Dictionary<FuzzyVariable, double> inputValues) {
      //
      // There should be one rule as minimum
      //
      if (_rules.Count == 0) {
        throw new Exception("There should be one rule as minimum.");
      }

      //
      // Fuzzification step
      //
      Dictionary<FuzzyVariable, Dictionary<FuzzyTerm, double>> fuzzifiedInput =
          Fuzzify(inputValues);

      //
      // Evaluate the conditions
      //
      Dictionary<MamdaniFuzzyRule, double> evaluatedConditions = EvaluateConditions(fuzzifiedInput);

      //
      // Do implication for each rule
      //
      Dictionary<MamdaniFuzzyRule, IMembershipFunction> implicatedConclusions = Implicate(evaluatedConditions);

      //
      // Aggrerate the results
      //
      Dictionary<FuzzyVariable, IMembershipFunction> fuzzyResult = Aggregate(implicatedConclusions);

      //
      // Defuzzify the result
      //
      Dictionary<FuzzyVariable, double> result = Defuzzify(fuzzyResult);

      return result;
    }

    /// <summary>
    /// Calculate output values without Defuzzify
    /// </summary>
    /// <param name="inputValues">Input values (format: variable - value)</param>
    /// <returns></returns>
    public Dictionary<FuzzyVariable, IMembershipFunction> CalculateFuzzy(Dictionary<FuzzyVariable, double> inputValues) {
      //
      // There should be one rule as minimum
      //
      if (_rules.Count == 0) {
        throw new Exception("There should be one rule as minimum.");
      }

      //
      // Fuzzification step
      //
      Dictionary<FuzzyVariable, Dictionary<FuzzyTerm, double>> fuzzifiedInput =
          Fuzzify(inputValues);

      //
      // Evaluate the conditions
      //
      Dictionary<MamdaniFuzzyRule, double> evaluatedConditions = EvaluateConditions(fuzzifiedInput);

      //
      // Do implication for each rule
      //
      Dictionary<MamdaniFuzzyRule, IMembershipFunction> implicatedConclusions = Implicate(evaluatedConditions);

      //
      // Aggrerate the results
      //
      Dictionary<FuzzyVariable, IMembershipFunction> fuzzyResult = Aggregate(implicatedConclusions);

      return fuzzyResult;
    }


    #region Intermidiate calculations

    /// <summary>
    /// Evaluate conditions 
    /// </summary>
    /// <param name="fuzzifiedInput">Input in fuzzified form</param>
    /// <returns>Result of evaluation</returns>
    public Dictionary<MamdaniFuzzyRule, double> EvaluateConditions(Dictionary<FuzzyVariable, Dictionary<FuzzyTerm, double>> fuzzifiedInput) {
      Dictionary<MamdaniFuzzyRule, double> result = new Dictionary<MamdaniFuzzyRule, double>();
      foreach (MamdaniFuzzyRule rule in Rules) {
        result.Add(rule, EvaluateCondition(rule.Condition, fuzzifiedInput));
      }

      return result;
    }


    public static MamdaniFuzzyRule SelectRule(IList<MamdaniFuzzyRule> rulesList, double val) {
      double minDiff = 1;
      MamdaniFuzzyRule selectedRule = null;
      for (int i = 0; i < rulesList.Count; i++) {
        var fuzzyRule = rulesList[i];
        var diff = Math.Abs(val - fuzzyRule.MF);
        if (diff <= minDiff) {
          selectedRule = fuzzyRule;
          minDiff = diff;
        }
      }
      return selectedRule;
    }
    
    /// <summary>
    /// Implicate rule results
    /// </summary>
    /// <param name="conditions">Rule conditions</param>
    /// <returns>Implicated conclusion</returns>
    public Dictionary<MamdaniFuzzyRule, IMembershipFunction> Implicate(Dictionary<MamdaniFuzzyRule, double> conditions) {
      Dictionary<MamdaniFuzzyRule, IMembershipFunction> conclusions = new Dictionary<MamdaniFuzzyRule, IMembershipFunction>();
      var addedRulesConditions = new List<string>();
      foreach (MamdaniFuzzyRule rule in conditions.Keys) {
        MfCompositionType compType;
        switch (_implMethod) {
          case ImplicationMethod.Min:
            compType = MfCompositionType.Min;
            break;
          case ImplicationMethod.Production:
            compType = MfCompositionType.Prod;
            break;
          default:
            throw new Exception("Internal error.");
        }

        var conStr = rule.Condition.ToString();
        var ruleStr = rule.ToString();
        
        //задает способ отбора нечетких правил
        var selectedStr = ConditionMap != null ? conStr : ruleStr;

        if (conditions[rule] >= SelectionRulesBound
          && !addedRulesConditions.Contains(selectedStr)) {
          var selected = rule;
          if (ConditionMap != null) {
            var list = ConditionMap[selectedStr];
            selected = SelectRule(list, conditions[rule]);
          }
          var resultMf = new CompositeMembershipFunction(
              compType,
              new ConstantMembershipFunction(conditions[selected]),
              selected.Conclusion.Term.MembershipFunction);
          conclusions.Add(selected, resultMf);

          addedRulesConditions.Add(selectedStr);
        }
      }

      return conclusions;
    }


    /// <summary>
    /// Aggregate results
    /// </summary>
    /// <param name="conclusions">Rules' results</param>
    /// <returns>Aggregated fuzzy result</returns>
    public Dictionary<FuzzyVariable, IMembershipFunction> Aggregate(Dictionary<MamdaniFuzzyRule, IMembershipFunction> conclusions) {
      Dictionary<FuzzyVariable, IMembershipFunction> fuzzyResult = new Dictionary<FuzzyVariable, IMembershipFunction>();
      foreach (FuzzyVariable var in Output) {
        List<IMembershipFunction> mfList = new List<IMembershipFunction>();
        foreach (MamdaniFuzzyRule rule in conclusions.Keys) {
          if (rule.Conclusion.Var == var) {
            mfList.Add(conclusions[rule]);
          }
        }

        MfCompositionType composType;
        switch (_aggrMethod) {
          case AggregationMethod.Max:
            composType = MfCompositionType.Max;
            break;
          case AggregationMethod.Sum:
            composType = MfCompositionType.Sum;
            break;
          default:
            throw new Exception("Internal exception.");
        }
        fuzzyResult.Add(var, new CompositeMembershipFunction(composType, mfList));
      }

      return fuzzyResult;
    }

    /// <summary>
    /// Calculate crisp result for each rule
    /// </summary>
    /// <param name="fuzzyResult"></param>
    /// <returns></returns>
    public Dictionary<FuzzyVariable, double> Defuzzify(Dictionary<FuzzyVariable, IMembershipFunction> fuzzyResult) {
      Dictionary<FuzzyVariable, double> crispResult = new Dictionary<FuzzyVariable, double>();
      foreach (FuzzyVariable var in fuzzyResult.Keys) {
        crispResult.Add(var, Defuzzify(fuzzyResult[var], var.Min, var.Max));
      }

      return crispResult;
    }

    #endregion


    #region Helpers

    public double Defuzzify(IMembershipFunction mf, FuzzyVariable var) {
      return Defuzzify(_defuzzMethod, mf, var.Min, var.Max);
    }

    public double Defuzzify(IMembershipFunction mf, double min, double max) {
      return Defuzzify(_defuzzMethod, mf, min, max);
    }

    #endregion
  }
}
