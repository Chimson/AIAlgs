namespace Lib;

using System.Numerics;

public class DecExample {
  public Vector<double> Features {get;}


  public DecExample (double[] arr) {
    Features = new Vector<double>(arr);
  }

  public override string ToString() {
    return Features.ToString();
  }
}