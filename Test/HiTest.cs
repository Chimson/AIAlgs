namespace Test;

using Lib;

public class HiTest {
    
  [SetUp]
  public void Setup() {}

  [Test]
  public void Test1() {
    Lib.Hello.Hi();
    Assert.Pass();
  }
}