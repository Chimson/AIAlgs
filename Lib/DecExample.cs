namespace Lib;

using System.Numerics;

public class DecExample {
  public List<double> Features {get;}


  public DecExample (double[] arr) {
    Features = new List<double>(arr);
  }

  public override string ToString() {
    string msg = "(";
    foreach (double val in Features) {
      msg += $"{val}, ";
    }
    msg = msg.TrimEnd(' ').TrimEnd(',');
    return msg + ')';
  }
}