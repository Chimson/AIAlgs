namespace Test;

using Lib;
using Lib.Data;

public class KMeansTests {
  
  [Test]
  public void CheckDecExample() {
    DecExample ex1 = new DecExample([0.7, 5.1]);
    Console.WriteLine(ex1);
  }

  [Test]
  public void CheckKMeansData() {
    KMeansData kmd = new KMeansData();  
    Console.WriteLine(kmd);
  }

  [Test]
  public void CheckRandomInit() {
    KMeansData kmd = new KMeansData();
    KMeans.Predict(kmd.TrainingSet, 2);
  }


}

// dotnet test Test --filter "KMeansTests.CheckRandomInit()"