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


  [Test]
  public void CheckSelectSplit1() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Unknown).Add("Thread", Thread.New)
         .Add("Length", Length.Long).Add("WhereRead", WhereRead.Work);
    Enum result = DecisionTree.select_split(data.TrainingSet, conds, 1.0, "UserAction");
    Assert.That(result, Is.EqualTo(Length.Long));
    Console.WriteLine($"{conds} splits on {Example.GetFeature(result)}: {result}, for target UserAction");
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
    Assert.Pass();
	}

  [Test]
  public void CheckConditionTree1() {
    ConditionTree at = new ConditionTree(Thread.New);
    ConditionTree af = new ConditionTree(Length.Long);
    ConditionTree tree1 = ConditionTree.ConnectTrees(Author.Known, at, af);
    ConditionTree bt = new ConditionTree(WhereRead.Home);
    ConditionTree bf = new ConditionTree(UserAction.Skips);
    ConditionTree tree2 = ConditionTree.ConnectTrees(Author.Unknown, bt, bf);
    ConditionTree root = ConditionTree.ConnectTrees(Thread.Followup, tree1, tree2);
    Console.WriteLine($"{root}");
    Assert.Pass();
  }
  /*
    (Followup, 
      (Known,   
        (New, null, null),
        (Long, null, null)),
      (Unknown, 
        (Home, null, null), 
        (Skips, null, null)))
  */

  [Test]
  public void CheckExFindFeatVal() {
    Example conds = new Example();
    conds.Add("Author", Author.Unknown).Add("Thread", Thread.New)
         .Add("Length", Length.Long).Add("WhereRead", WhereRead.Work);
    Assert.That(conds.FindFeatVal(Author.Unknown), Is.EqualTo(true));
    Assert.That(conds.FindFeatVal(Author.Known), Is.EqualTo(false));
    Assert.That(conds.FindFeatVal(Thread.New), Is.EqualTo(true));
    Assert.That(conds.FindFeatVal(Thread.Followup), Is.EqualTo(false));
  }

  [Test]
  public void CheckFindPredictor1() {
    Example conds = new Example();
    conds.Add("Author", Author.Unknown).Add("Thread", Thread.New)
         .Add("Length", Length.Long).Add("WhereRead", WhereRead.Work);
    ConditionTree at = new ConditionTree(Thread.New);
    ConditionTree af = new ConditionTree(Length.Long);
    ConditionTree tree1 = ConditionTree.ConnectTrees(Author.Known, at, af);
    ConditionTree bt = new ConditionTree(WhereRead.Home);
    ConditionTree bf = new ConditionTree(UserAction.Skips);
    ConditionTree tree2 = ConditionTree.ConnectTrees(Author.Unknown, bt, bf);
    ConditionTree root = ConditionTree.ConnectTrees(Thread.Followup, tree1, tree2);

    Enum result = root.Predict(conds);
    Assert.That(result, Is.EqualTo(WhereRead.Home));
    Console.WriteLine($"{result}");    
  }
  /*
    (Followup,                      // False
      (Known,   
        (New, null, null),
        (Long, null, null)),
      (Unknown,                     // True
      (Home, null, null),           // return 
        (Skips, null, null)))
  */

  [Test]
  public void CheckFindPredictor2() {
    Example conds = new Example();
    conds.Add("Author", Author.Known).Add("Thread", Thread.Followup)
         .Add("Length", Length.Long).Add("WhereRead", WhereRead.Work);
    ConditionTree at = new ConditionTree(Thread.New);
    ConditionTree af = new ConditionTree(Length.Long);
    ConditionTree tree1 = ConditionTree.ConnectTrees(Author.Known, at, af);
    ConditionTree bt = new ConditionTree(WhereRead.Home);
    ConditionTree bf = new ConditionTree(UserAction.Skips);
    ConditionTree tree2 = ConditionTree.ConnectTrees(Author.Unknown, bt, bf);
    ConditionTree root = ConditionTree.ConnectTrees(Thread.Followup, tree1, tree2);

    Enum result = root.Predict(conds);
    Assert.That(result, Is.EqualTo(Thread.New));
    Console.WriteLine($"{result}");    
  }

  /*
    (Followup,                    // True                  
      (Known,                     // True
        (New, null, null),        // return    
        (Long, null, null)),
      (Unknown,                     
        (Home, null, null),       
        (Skips, null, null)))
  */

  // this only prints the tree
  [Test]
  public void CheckLearnerTree() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Known).Add("Thread", Thread.New).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Home);
    DecisionTree d = new DecisionTree();
    d.SetConditionTree(conds , "UserAction", data.TrainingSet, 0);
		Console.WriteLine(d);
    Assert.Pass();
  }



	[Test]
	public void CheckPredict1() {
		// predict on UserAction
		ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Known).Add("Thread", Thread.New).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Home);
		DecisionTree d = new DecisionTree();
    d.SetConditionTree(conds, "UserAction", data.TrainingSet, 0);
		Console.WriteLine(d);
		Console.WriteLine(d.Predict(conds));
	}
  /*
  (Long, 
    (Skips, null, null), 
    (Reads, null, null))
  */

  [Test]
  public void CheckPredict2() {
    // predict on the "Thread" feature
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Known).Add("Length", Length.Long).Add("WhereRead", WhereRead.Home)
      .Add("UserAction", UserAction.Reads);
    DecisionTree d = new DecisionTree();
    d.SetConditionTree(conds, "Thread", data.TrainingSet, 0);
    Console.WriteLine(d);
    Console.WriteLine(d.Predict(conds));
  }  
  /*
  (Reads, 
    (New, null, null), 
    (New, null, null))
  */

  [Test]
  public void CheckPredict3() {
    // Predict on Length
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Unknown).Add("Thread", Thread.Followup).Add("WhereRead", WhereRead.Work)
      .Add("UserAction", UserAction.Reads);
    DecisionTree d = new DecisionTree();
    d.SetConditionTree(conds, "Length", data.TrainingSet, 0);
    Console.WriteLine(d);
    Console.WriteLine(d.Predict(conds));
  }  
  /*
    (Reads, 
      (Short, null, null), 
      (Unknown, 
        (Long, null, null), 
        (Long, null, null)))
  */
  [Test]
  public void CheckPredict4() {
    // Predict on Author
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Thread", Thread.Followup).Add("Length", Length.Long).Add("WhereRead", WhereRead.Work)
      .Add("UserAction", UserAction.Reads);
    DecisionTree d = new DecisionTree();
    d.SetConditionTree(conds, "Author", data.TrainingSet, 0);
    Console.WriteLine(d);
    Console.WriteLine(d.Predict(conds));
  }  

  [Test]
  public void CheckPredict5() {
    // Predict on Author
    // same as above but with the opposite values on the conditions
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Thread", Thread.New).Add("Length", Length.Short).Add("WhereRead", WhereRead.Home)
      .Add("UserAction", UserAction.Skips);
    DecisionTree d = new DecisionTree();
    d.SetConditionTree(conds, "Author", data.TrainingSet, 0);
    Console.WriteLine(d);
    Console.WriteLine(d.Predict(conds));
  }  

  [Test]
  public void CheckPredict6() {
    // Predict on Author
    // same as above two but with not all conditions
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Thread", Thread.New).Add("Length", Length.Short);
    DecisionTree d = new DecisionTree();
    d.SetConditionTree(conds, "Author", data.TrainingSet, 0);
    Console.WriteLine(d);
    Console.WriteLine(d.Predict(conds));
  }  

  [Test]
  public void CheckPredict7() {
    // Predict on UserAction
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Known).Add("Thread", Thread.Followup)
      .Add("Length", Length.Short);
    DecisionTree d = new DecisionTree();
    d.SetConditionTree(conds, "UserAction", data.TrainingSet, 0);
    Console.WriteLine(d);
    Console.WriteLine(d.Predict(conds));
  } 
  
  [Test]
  public void CheckPredict8() {
    // Predict on UserAction
    // similar to above, but should give opposite UserAction value
    //    this can be seen in the data
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    Example conds = new Example();
    conds.Add("Author", Author.Known).Add("Thread", Thread.Followup)
      .Add("Length", Length.Long);
    DecisionTree d = new DecisionTree();
    d.SetConditionTree(conds, "UserAction", data.TrainingSet, 0);
    Console.WriteLine(d);
    Console.WriteLine(d.Predict(conds));
  } 
}

// dotnet test Test --filter "DecisionTreeTests.CheckSelectSplit1"
