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
    List<List<Example>> results = DecisionTree.find_cond(data.TrainingSet, cond);
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
    Feature result = new Feature(DecisionTree.select_split(data.TrainingSet, conds, 1.0, "UserAction"));
    Console.WriteLine($"{result.GetFeature()}: {result.GetVal()}");
  }


	[Test]
	public void CheckNode() {
		Node empty = new Node();
		Console.WriteLine(empty);
		Node n = new Node(UserAction.Reads);
		Console.WriteLine(n);
		Node l = new Node(Length.Long);
		Node r = new Node(Thread.New);
		n.AddT(l);
		n.AddF(r);
		Console.WriteLine(n);
		
	}


  [Test]
  public void CheckLearner1() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Known).Add("Thread", Thread.New).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Home);
    ConditionTree result = DecisionTree.Learner(conds , "UserAction", data.TrainingSet, 5);
		Console.WriteLine(result);
  }

	[Test]
	public void CheckPredict1() {
		// conds does not include UserAction, since it is the target feature
		ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Known).Add("Thread", Thread.New).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Home);
		DecisionTree.SetConditionTree(conds, "UserAction", data.TrainingSet, 0);
		Console.WriteLine(DecisionTree.CT);
    Console.WriteLine(data);
		Console.WriteLine(DecisionTree.Predict(conds));

	}

  [Test]
  public void CheckPredict2() {
    // predict on the "Thread" feature
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Known).Add("Length", Length.Long).Add("WhereRead", WhereRead.Home)
      .Add("UserAction", UserAction.Reads);
    DecisionTree.SetConditionTree(conds, "Thread", data.TrainingSet, 0);
    Console.WriteLine(DecisionTree.CT);
    Console.WriteLine(DecisionTree.Predict(conds));
  }  

}

// dotnet test -warnAsMessage:NUnit2005 Test --filter "DecisionTreeTests.CheckSelectSplit1"
