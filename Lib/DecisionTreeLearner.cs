namespace Lib;

using Lib.Data;

public class DecisionTreeLearner {

  // public static Feature find_mode(ReadArticleChoiceData examples) {
    
    // int[] freq = new int[2];
    // foreach (UserData ex in examples.TrainingSet) {
      
      
    //   if (ex.UserAction == UserAction.Skips) {
    //     freq[0] += 1; 
    //   } 
    //   else {
    //     freq[1] += 1;
    //   }
    // }

    // if (freq[0] >= freq[1]) {
    //   return new Feature(UserAction.Skips);
    // }
    // else {
    //   return new Feature(UserAction.Reads);
    // }
  // }

  // public static double sum_loss(ReadArticleChoiceData examples) {

  //   // the optimal prediction for L0 Loss is the mode
  //   Feature mode = find_mode(examples);

  //   // extract the training set
  //   List<UserData> training = examples.TrainingSet;
  //   double sum = 0.0;

  //   foreach (UserData ex in training) {
  //     Feature actual = new Feature(ex.UserAction);
  //     sum += loss(actual, mode);
  //   }    

  //   return sum; 
  // }

  // public static double loss(Feature predicted, Feature actual) {
  //   // choosing a very simple L0 Loss

    
  //   bool bin =  predicted.GetVal() == actual.GetVal() && predicted.GetFeature() == actual.GetFeature();
  //   if (bin == true) { 
  //     return 0;
  //   }
  //   else {
  //     return 1;
  //   }
  // }

  // public static List<UserData> find_cond_true(ReadArticleChoiceData examples, Feature cond) {
  //   List<UserData> trues = new List<UserData>();   

  //   foreach (UserData ex in examples.TrainingSet) {
  //     Type condtype = cond.GetFeature();
  //     string exval = ex.GetVal(condtype);
  //     if (exval == cond.GetVal()) {
  //       trues.Add(ex);
  //     }
  //   }

  //   return trues;
  // }

  // public static Feature select_split(ReadArticleChoiceData examples, List<Feature> conds, 
  //   double min_improv) {
    
  //   double best_val = sum_loss(examples);

  //   Feature none = new Feature(None.None);

  //   foreach (Feature cond in conds) {

  //     List<UserData> cond_true_data = find_cond_true(examples, cond);
  //     // Finish with calling sum_loss
  //   }

  //   return new Feature(WhereRead.Home);  // REPLACE THIS
  // }

}

