namespace Lib.Data;

public class KMeansData {
  public List<DecExample> TrainingSet {get;}


  public KMeansData() {
    TrainingSet = new List<DecExample>();
    this
      .Add(new DecExample([0.7, 5.1]))
      .Add(new DecExample([1.5, 6.1]))
      .Add(new DecExample([2.1, 4.5]))
      .Add(new DecExample([2.4, 5.5]))
      .Add(new DecExample([3.1, 4.4]))
      .Add(new DecExample([3.5, 5.1]))
      .Add(new DecExample([4.5, 1.5]))
      .Add(new DecExample([5.2, 0.7]))
      .Add(new DecExample([5.3, 1.8]))
      .Add(new DecExample([6.2, 1.7]))
      .Add(new DecExample([6.7, 2.5]))
      .Add(new DecExample([8.5, 9.2]))
      .Add(new DecExample([9.1, 9.7]))
      .Add(new DecExample([9.5, 8.5]));
  
  }



  public KMeansData Add(DecExample ex) {
    TrainingSet.Add(ex);
    return this;
  }

  public override string ToString() {
    string msg = "";
    foreach(DecExample ex in TrainingSet) {
      msg += $"{ex}\n";
    }
    return msg.TrimEnd('\n');
  }

}