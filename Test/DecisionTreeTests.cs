namespace Test;

using Lib.Data;
using Lib;

public class DecisionTreeTests {

  [Test]
  public void CheckUserData1() {
    UserData ex1 = new UserData(Author.Known, Thread.New, Length.Long, WhereRead.Home, UserAction.Skips);
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

  [Test]
  public void CheckSelectSplit1() {
    ReadArticleChoiceData data = new ReadArticleChoiceData();
    
    // I gave it dummy UserAction dummy val, that is unread from conds
    UserData conds = new UserData(Author.Unknown, Thread.New, Length.Long, WhereRead.Work, );
  }
}

