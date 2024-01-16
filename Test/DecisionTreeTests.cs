namespace Test;

using Lib.Data;
using Lib;

public class DecisionTreeTests {

  [Test]
  public void CheckExampleData1() {
    Example ex1 = new Example();
    ex1.Add("Author", Author.Known).Add("Thread", Thread.Followup).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Home).Add("UserAction", UserAction.Reads);
    Console.WriteLine(ex1);
    Assert.Pass();
  }

  [Test]
  public void CheckExampleData2() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Console.WriteLine(data);
    Assert.Pass();
  }


  [Test]
  public void CheckFindMode1() {
    ReadArticleChoiceData init = new ReadArticleChoiceData();
    List<Example> data = init.TrainingSet;
    Console.WriteLine($"{DecisionTree.find_mode(data, "Author")}");
    Console.WriteLine($"{DecisionTree.find_mode(data, "Thread")}");
    Console.WriteLine($"{DecisionTree.find_mode(data, "Length")}");
    Console.WriteLine($"{DecisionTree.find_mode(data, "WhereRead")}");
    Console.WriteLine($"{DecisionTree.find_mode(data, "UserAction")}");
    Assert.Pass();
  }



  [Test]
  public void CheckSumLoss1() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    
    double sum_loss = DecisionTree.sum_loss(data.TrainingSet, "UserAction");
    Console.WriteLine($"sum_loss = {sum_loss}");
    Assert.AreEqual(sum_loss, 9.0);    // there are 9 Reads and 9 Skips for target feature User_Action

  }

  [Test]
  public void CheckFindCondTrue1() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Enum cond = WhereRead.Home;
    List<List<Example>> results = DecisionTree.find_cond(data, cond);
    List<Example> trues = results[0];
    foreach (Example ex in trues) {
      Console.WriteLine($"{ex}");
    }
  }

  [Test]
  public void CheckSelectSplit1() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Unknown).Add("Thread", Thread.New).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Work);
    Enum result = DecisionTree.select_split(data, conds, 1.0, "UserAction");
    Console.WriteLine($"{Example.TrimTypeName(result.GetType())}: {result}");
  }

  [Test]
  public void CheckLearner1() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Known).Add("Thread", Thread.New).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Home);
    DecisionTree.Learner(conds, "UserAction", data, 0);
   
  }

}

// dotnet test -warnAsMessage:NUnit2005 Test --filter "DecisionTreeTests.CheckSelectSplit1"
