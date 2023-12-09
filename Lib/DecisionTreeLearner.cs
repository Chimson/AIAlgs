namespace Lib;

using Lib.Data;

public class DecisionTreeLearner {

  /*
  select_split(Exs, Conds, y)
    Exs is the set of examples
    Conds is the set of conditions to predict the target on
    y is the minimum improvement needed to expand a node
  */

  // TODO: hard code the target and predictor features for now
  private static void select_split(ReadArticleChoiceData examples, UserData conds, double min_improve) {  
    // examples contains the training data
    // conds is one data point of feature values, those that are used for prediction
    // min_improve is a threshold used to determine when to expand a node   
    
    // double best_val = sum_loss(examples.TrainingSet - min_improve);
  }

  public static double MeanLogLoss(ReadArticleChoiceData examples) {
    // assume the target feature takes on v1,...,vk values
    // need the number of occurences, ni, of each value of the target feature vi
    // need p[vi] = ni/n, n is the total number of examples
    
    int n = examples.TrainingSet.Count;
    
    int[] occurences = find_occurs_target_vals(examples); 
    
    return 0.0;
  }

  private static int[] find_occurs_target_vals(ReadArticleChoiceData examples) {
    
    UserAction val = UserAction.Skips;
    int[] occurs = new int[ 
  
  }

}