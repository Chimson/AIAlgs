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
    Enum amode = DecisionTree.find_mode(data, "Author");
    Enum tmode = DecisionTree.find_mode(data, "Thread");
    Enum lmode = DecisionTree.find_mode(data, "Length");
    Enum wmode = DecisionTree.find_mode(data, "WhereRead");
    Enum umode = DecisionTree.find_mode(data, "UserAction");
    Assert.That(amode, Is.EqualTo(Author.Known));
    Assert.That(tmode, Is.EqualTo(Thread.New));
    Assert.That(lmode, Is.EqualTo(Length.Short));
    Assert.That(wmode, Is.EqualTo(WhereRead.Work));
    Assert.That(umode, Is.EqualTo(UserAction.Reads));
    Console.WriteLine($"Author mode: {amode}");
    Console.WriteLine($"Thread mode: {tmode}");
    Console.WriteLine($"Length mode: {lmode}");
    Console.WriteLine($"WhereRead mode: {wmode}");
    Console.WriteLine($"UserAction mode: {umode}");
  }



  [Test]
  public void CheckSumLoss1() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    
    double sum_loss = DecisionTree.sum_loss(data.TrainingSet, "UserAction");
    Console.WriteLine($"sum_loss on UserAction = {sum_loss}");
    Assert.That(sum_loss, Is.EqualTo(9.0));    
  }

  [Test]
  public void CheckSumLoss2() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    
    double sum_loss = DecisionTree.sum_loss(data.TrainingSet, "WhereRead");
    Console.WriteLine($"sum_loss on WhereRead = {sum_loss}");
    Assert.That(sum_loss, Is.EqualTo(8.0));    
  }

  [Test]
  public void CheckSumLoss3() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    
    double sum_loss = DecisionTree.sum_loss(data.TrainingSet, "Length");
    Console.WriteLine($"sum_loss on Length = {sum_loss}");
    Assert.That(sum_loss, Is.EqualTo(7.0));    
  }

  [Test]
  public void CheckSumLoss4() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    
    double sum_loss = DecisionTree.sum_loss(data.TrainingSet, "Thread");
    Console.WriteLine($"sum_loss on Thread = {sum_loss}");
    Assert.That(sum_loss, Is.EqualTo(8.0));    
  }

  [Test]
  public void CheckSumLoss5() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    
    double sum_loss = DecisionTree.sum_loss(data.TrainingSet, "Author");
    Console.WriteLine($"sum_loss on Author = {sum_loss}");
    Assert.That(sum_loss, Is.EqualTo(6.0));    
  }

  [Test]
  public void CheckFindCondTrue1() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Enum cond = WhereRead.Home;
    List<List<Example>> results = DecisionTree.find_cond(data.TrainingSet, cond);
    List<Example> trues = results[0];
    Console.WriteLine($"All of the examples should have WhereRead: Home");
    foreach (Example ex in trues) {
      Console.WriteLine($"{ex}");
      Assert.That(ex.Features["WhereRead"], Is.EqualTo(WhereRead.Home));
    }
  }

  [Test]
  public void CheckFindCondTrue2() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Enum cond = WhereRead.Home;
    List<List<Example>> results = DecisionTree.find_cond(data.TrainingSet, cond);
    List<Example> falses = results[1];
    Console.WriteLine($"All of the examples should not have WhereRead: Home");
    foreach (Example ex in falses) {
      Console.WriteLine($"{ex}");
      Assert.That(ex.Features["WhereRead"], Is.Not.EqualTo(WhereRead.Home));
    }
  }


  // STOPPED HERE ON REVIEW
  [Test]
  public void CheckSelectSplit1() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Unknown).Add("Thread", Thread.New)
         .Add("Length", Length.Long).Add("WhereRead", WhereRead.Work);
    Enum result = DecisionTree.select_split(data.TrainingSet, conds, 1.0, "UserAction");
    Console.WriteLine($"{Example.GetFeature(result)}: {result}");
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
    Console.WriteLine(data);
    Console.WriteLine(DecisionTree.CT);
    Console.WriteLine(DecisionTree.Predict(conds));
  }  

  [Test]
  public void CheckPredict3() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Unknown).Add("Thread", Thread.Followup).Add("WhereRead", WhereRead.Work)
      .Add("UserAction", UserAction.Reads);
    DecisionTree.SetConditionTree(conds, "Length", data.TrainingSet, 0);
    Console.WriteLine(data);
    Console.WriteLine(DecisionTree.CT);
    Console.WriteLine(DecisionTree.Predict(conds));
  }  

}

// dotnet test -warnAsMessage:NUnit2005 Test --filter "DecisionTreeTests.CheckSelectSplit1"
