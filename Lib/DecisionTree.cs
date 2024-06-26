namespace Lib;

// assumes that the target feature is categorical for classification
// this also produces a tree, dependent on the given conditions

public class DecisionTree {

  private ConditionTree CT;

  public DecisionTree() {
    CT = new ConditionTree();
  }


  public static Enum find_mode(List<Example> examples, string target_feature) {

    // TODO: deal with the case where the list of examples is empty
    if (examples.Count == 0) {
      return Empty.None;
    }

    Dictionary<string, int> counts = new Dictionary<string, int>();

 
    // take first examples target feature value, and retrieve's all feature's possible values
    string[] tvals = examples[0].AllPossValsForFeat(target_feature);

    // Initialize the dictionary for the counts
    foreach (string s in tvals) {
      counts[s] = 0;
    }

    foreach (Example ex in examples) {
      Enum ex_target_val = ex.Features[target_feature];
      counts[$"{ex_target_val}"] += 1;
    }

    // find the target value that appears the most
    int max = 0;
    string tval = "";
    foreach (KeyValuePair<string, int> kvp in counts) {
      if (kvp.Value >= max) {
        tval = $"{kvp.Key}";
        max = kvp.Value;
      }
    } 

    // convert the string into an enum, using one of the examples
    Enum result = examples[0].ConvertToEnum(tval);
    return result;
  }

  public static double sum_loss(List<Example> examples, string target_feature) {

    // the optimal prediction for L0 Loss is the mode
    Enum mode = find_mode(examples, target_feature);

    double sum = 0.0;

    foreach (Example ex in examples) {
      Enum actual = ex.Features[target_feature];
      sum += loss(mode, actual);
    }    

    return sum;  

  }

  public static double loss(Enum predicted, Enum actual) {
    // choosing a very simple L0 Loss

    if (predicted.Equals(actual)) { 
      return 0;
    }
    else {
      return 1;
    }
  }

  // returns two lists, one of examples thats contains the condition
  // thw other where it doesn't
  public static List<List<Example>> find_cond(List<Example> examples, Enum cond) {
    List<Example> true_results = new List<Example>();
    List<Example> false_results = new List<Example>();
    string target = Example.GetFeature(cond);
    foreach (Example ex in examples) {
      if (ex.Features[target].Equals(cond)) {
        true_results.Add(ex);
      }
      else {
        false_results.Add(ex);
      }
    } 
    List<List<Example>> results = new List<List<Example>>();
    results.Add(true_results);
    results.Add(false_results);
    return results;
  }


  // min_improv is a minimum threshold that allows a split
  public static Enum select_split(List<Example> examples, Example conds, 
    double min_improv, string target_feature) {
    
    double best_val = sum_loss(examples, target_feature) - min_improv;

    Enum best_split = Empty.None;

    foreach (Enum cond in conds.Features.Values) {

      // first list is when cond is true, second is when false
      List<List<Example>> cond_data = find_cond(examples, cond);
      
      double val = sum_loss(cond_data[0], target_feature);
      val += sum_loss(cond_data[1], target_feature);
      if (val < best_val) {
        best_val = val;
        best_split = cond;
      }
    }
    
    return best_split;
  }

  private ConditionTree Learner(Example conds, string target_feature, List<Example> examples, 
    double min_improv) {

      Enum cond = select_split(examples, conds, min_improv, target_feature);
			if (cond.Equals(Empty.None)) {
				ConditionTree one_node = 
          new ConditionTree(examples[0].Features[target_feature]);
				return one_node;
      }
      else {
        List<List<Example>> true_and_false = find_cond(examples, cond);
        List<Example> true_exs = true_and_false[0];
				List<Example> false_exs = true_and_false[1];
				
				Example remconds = conds.Clone();
				remconds.RemoveCond(cond);

				ConditionTree t1 = Learner(remconds, target_feature, true_exs, min_improv);
				ConditionTree t2 = Learner(remconds, target_feature, false_exs, min_improv);

				return ConditionTree.ConnectTrees(cond, t1, t2);

      }

  }

	public void SetConditionTree(Example conds, string target_feature, List<Example> examples, 
    double min_impro) {
		// needs called before Predict
		CT = Learner(conds, target_feature, examples, min_impro);

	}

	public Enum Predict(Example conds) {
		return CT.Predict(conds);
	}

  public override string ToString() {
    return $"{CT}";
  }

}



