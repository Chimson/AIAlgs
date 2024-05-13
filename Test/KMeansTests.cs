namespace Test;

using Lib;

public class KMeansTests {
  
  [Test]
  public void CheckDecExample() {
    DecExample ex1 = new DecExample([0.7, 5.1]);
    Console.WriteLine(ex1);
  }

}

// dotnet test Test --filter "KMeansTests.CheckDecExample"