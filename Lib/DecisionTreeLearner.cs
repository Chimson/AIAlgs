namespace Lib;

using Lib.Data;

public class DecisionTreeLearner {

  public static double sum_loss(ReadArticleChoiceData examples, ReadArticleChoiceData predicts) {

    List<UserData> training = examples.TrainingSet;
    double sum = 0.0;

    foreach (UserData ex in training) {
      Feature actual = new Feature(ex.UserAction);
      Feature predict = new Feature(ex.UserAction);
      sum += loss(actual, predict);
    }    

    return sum; 
  }

  public static double loss(Feature predicted, Feature actual) {
    // choosing a very simple L0 Loss

    
    bool bin =  predicted.GetVal() == actual.GetVal() && predicted.GetFeature() == actual.GetFeature();
    if (bin == true) { 
      return 0;
    }
    else {
      return 1;
    }
  }

  public static Feature select_split(ReadArticleChoiceData examples, UserData conds, 
    double min_improv) {
    
    double best_val = sum_loss(examples, examples);

    return new Feature(WhereRead.Home);  // REPLACE THIS
  }

// TODO: still confused on why sum loss in the pseudocode is only given the examples

}

