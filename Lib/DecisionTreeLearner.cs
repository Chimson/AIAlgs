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

/*
     Age Sex | Race
ex1  32   M  | White
ex2  44   F  | Black
ex3  31   F  | White
ex4  43   M  | ?

Features are functions from examples to feature values
  has exactly one value for each example
Race is the target feature
Age is an input feature
  Age(ex1) = 32
Domain of a feature is the range of its feature function
  domain of Age is 32 and 44
Bag of training examples where each example
  contains a value recieved from each target feature function
  and input feature function, given that example
Given bag of examples E and target feature Y, Y(e) is 
  the ground truth
A predictor Y^ for target feature Y is a function from
  an example of input feature values into the domain of Y
  Y*(43, M) = White
A point estimate for target feature Y is a prediction of Y^(e)
Loss for example e on target feature Y is a measure of how close Y^(e)
  is to Y(e)
  loss(Y(e), Y^(e))
sum of losses or mean of losses is a sum or average of the loss function values
  loss(Y(e), Y^(e))
sum_loss example
  find the frequencies for target feature Race
    Race has feature domain of White and Black
    p1 = p(white) = 2/3
    p2 = p(black) = 1/3 
  sum_loss = - ( (2/3)*log(2/3) + (1/3)*log(1/3) )


*/