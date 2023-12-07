namespace Test;

using Lib.Data;

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
}