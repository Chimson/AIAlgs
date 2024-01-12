namespace Lib;

using Lib.Data;

public class DecisionTreeLearner {

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

  public static List<Example> find_cond_true(ReadArticleChoiceData examples, Enum cond) {
    List<Example> result = new List<Example>();
    string target = Example.TrimTypeName(cond.GetType());
    foreach (Example ex in examples.TrainingSet) {
      if (ex.Features[target].Equals(cond)) {
        result.Add(ex);
      }
    }
    return result;  
  }

  public static Feature select_split(ReadArticleChoiceData examples, Example conds, 
    double min_improv, string target_feature) {
    
    double best_val = sum_loss(examples.TrainingSet, target_feature) - min_improv;


    foreach (Enum cond in conds.Features.Values) {

      List<Example> cond_true_data = find_cond_true(examples, cond);
      double val = sum_loss(cond_true_data, target_feature);
      Console.WriteLine(val);
    }

    return new Feature(WhereRead.Home);  // REPLACE THIS
  }

}

