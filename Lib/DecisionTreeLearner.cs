namespace Lib;

using Lib.Data;

public class DecisionTreeLearner {

  public static Feature select_split(ReadArticleChoiceData examples, UserData conds, 
    double min_improv) {
    
    double best_val = sum_loss(examples);

    return new Feature(WhereRead.Home);  // REPLACE THIS
  }


  public static double sum_loss(ReadArticleChoiceData examples) {
    // this is the sum of the loss function values on each 
    //   categorical feature


    return 0.0;  // REPLACE THIS
  }

}