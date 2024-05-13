namespace Lib.Data;

using System.Numerics;

public class KMeansData {
  public List<DecExample> TrainingSet {get;}

  public KMeansData() {
    TrainingSet = new List<DecExample>();
    // TrainingSet
  }
}