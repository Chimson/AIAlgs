namespace Lib;

using Lib.Data;

public class DecisionTree {

  public static Enum find_mode(List<Example> examples, string target_feature) {
    
    Dictionary<string, int> counts = new Dictionary<string, int>();
 
    // take first examples target feature value, and retrieve's all feature's possible values
    Enum testval = examples[0].Features[target_feature];
    string[] tvals = Enum.GetNames(testval.GetType());

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

  public static List<List<Example>> find_cond(ReadArticleChoiceData examples, Enum cond) {
    List<Example> true_results = new List<Example>();
    List<Example> false_results = new List<Example>();
    string target = Example.TrimTypeName(cond.GetType());
    foreach (Example ex in examples.TrainingSet) {
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

  public static Enum select_split(ReadArticleChoiceData examples, Example conds, 
    double min_improv, string target_feature) {
    
    double best_val = sum_loss(examples.TrainingSet, target_feature) - min_improv;

    Enum best_split = None.None;

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

  public static void Learner(Example conds, string target_feature, ReadArticleChoiceData examples, 
    double min_improv ) {

      Enum cond = select_split(examples, conds, min_improv, target_feature);

      if (cond is None.None) {
        // complete this block
      }
      else {
        List<List<Example>> true_and_false = find_cond(examples, cond);
        List<Example> true_exs = true_and_false[0];
        List<Example> false_exs = true_and_false[1];

      }

  }

}



