namespace Test;

using Lib.Data;
using Lib;

public class DecisionTreeTests {

  [Test]
  public void CheckUserData1() {
    UserData ex1 = (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.New)).AddF(new Feature(Length.Long))
      .AddF(new Feature(WhereRead.Home)).AddF(new Feature(UserAction.Skips));
    Console.WriteLine($"CheckTrainingData: {ex1}");
    Assert.Pass();
  }

  [Test]
  public void CheckUserData2() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Console.WriteLine(data);
    Assert.Pass();
  }

  [Test]
  public void CheckFeature1() {
    WhereRead fval = WhereRead.Home;
    Feature f1 = new Feature(fval); 
    Console.WriteLine(f1.GetFeature());  // Lib.Data.WhereRead
    Console.WriteLine(f1.GetVal());     // Home
    Assert.Pass();
  }

  // [Test]
  // public void CheckSumLoss1() {
  //   ReadArticleChoiceData data = new ReadArticleChoiceData();
    
  //   // I gave it dummy UserAction dummy val, that is unread from conds
  //   UserData conds = (new UserData()).AddF(new Feature(Author.Unknown)).AddF(new Feature(Thread.New)).AddF(new Feature(Length.Long))
  //     .AddF(new Feature(WhereRead.Work)).AddF(new Feature(UserAction.Skips));
    
  //   double sum_loss = DecisionTreeLearner.sum_loss(data);
  //   Console.WriteLine($"sum_loss = {sum_loss}");
  //   Assert.Equals(sum_loss, 9.0);    // there are 9 Reads and 9 Skips for target feature User_Action

  // }

  // [Test]
  // public void CheckFindCondTrue1() {
  //   ReadArticleChoiceData data = new ReadArticleChoiceData();
  //   Feature cond = new Feature(WhereRead.Home);
  //   List<UserData> trues = DecisionTreeLearner.find_cond_true(data, cond);
  //   foreach (UserData ex in trues) {
  //     Console.WriteLine($"{ex}");
  //   }
  // }

}

// dotnet test -warnAsMessage:NUnit2005 Test --filter "DecisionTreeTests.CheckSelectSplit1"

/*
TODO: get the tests to work, basically rewrite the DecisionTreeLearner
      UserData is now a List<Feature>, and the changes in each method needs adjusted
      UserData needs its own dedicated file, seperate from ReadArticleChoiceData
      
*/