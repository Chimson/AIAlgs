namespace Lib.Data;

public enum Author {
  Known, Unknown
}

public enum Thread {
  New, Followup
}

public enum Length {
  Long, Short
}

public enum WhereRead {
  Home, Work
}

public enum UserAction {
  Skips, Reads
}

// used for null like features
public enum None {
  None
}

public class UserData {

  public List<Feature> Features;
  
  public UserData() {
    Features = new List<Feature>();
  }

  public override string ToString() {
    String msg = "";
    foreach (Feature feature in Features) {
      msg += $"{feature.GetVal()}, ";
    }
    msg = msg.TrimEnd(' ');
    msg = msg.TrimEnd(',');
    return msg;
  }

  public UserData AddF(Feature feature) {
    Features.Add(feature);
    return this;
  }

  public List<Feature> GetFeatures() {
    return Features;
  } 

  public Feature GetFeature(Feature feat) {
    foreach (Feature f in Features) {
      if (f.Equals(feat)) {
        return f;
      }
    }
    return new Feature(None.None);
  }

}


public class ReadArticleChoiceData {
  public List<UserData> TrainingSet = new List<UserData>(); 
  
  public ReadArticleChoiceData() {
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.New)).AddF(new Feature(Length.Long))
      .AddF(new Feature(WhereRead.Home)).AddF(new Feature(UserAction.Skips)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Unknown)).AddF(new Feature(Thread.New)).AddF(new Feature(Length.Short))
      .AddF(new Feature(WhereRead.Work)).AddF(new Feature(UserAction.Reads)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Unknown)).AddF(new Feature(Thread.Followup)).AddF(new Feature(Length.Long))
      .AddF(new Feature(WhereRead.Work)).AddF(new Feature(UserAction.Skips)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.Followup)).AddF(new Feature(Length.Long))
      .AddF(new Feature(WhereRead.Home)).AddF(new Feature(UserAction.Skips)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.New)).AddF(new Feature(Length.Short))
      .AddF(new Feature(WhereRead.Home)).AddF(new Feature(UserAction.Reads)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.Followup)).AddF(new Feature(Length.Long))
      .AddF(new Feature(WhereRead.Work)).AddF(new Feature(UserAction.Skips)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Unknown)).AddF(new Feature(Thread.Followup)).AddF(new Feature(Length.Short))
      .AddF(new Feature(WhereRead.Work)).AddF(new Feature(UserAction.Skips)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Unknown)).AddF(new Feature(Thread.New)).AddF(new Feature(Length.Short))
      .AddF(new Feature(WhereRead.Work)).AddF(new Feature(UserAction.Reads)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.Followup)).AddF(new Feature(Length.Long))
      .AddF(new Feature(WhereRead.Home)).AddF(new Feature(UserAction.Skips)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.New)).AddF(new Feature(Length.Long))
      .AddF(new Feature(WhereRead.Work)).AddF(new Feature(UserAction.Skips)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Unknown)).AddF(new Feature(Thread.Followup)).AddF(new Feature(Length.Short))
      .AddF(new Feature(WhereRead.Home)).AddF(new Feature(UserAction.Skips)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.New)).AddF(new Feature(Length.Long))
      .AddF(new Feature(WhereRead.Work)).AddF(new Feature(UserAction.Skips)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.Followup)).AddF(new Feature(Length.Short))
      .AddF(new Feature(WhereRead.Home)).AddF(new Feature(UserAction.Reads)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.New)).AddF(new Feature(Length.Short))
      .AddF(new Feature(WhereRead.Work)).AddF(new Feature(UserAction.Reads)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.New)).AddF(new Feature(Length.Short))
      .AddF(new Feature(WhereRead.Home)).AddF(new Feature(UserAction.Reads)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.Followup)).AddF(new Feature(Length.Short))
      .AddF(new Feature(WhereRead.Work)).AddF(new Feature(UserAction.Reads)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Known)).AddF(new Feature(Thread.New)).AddF(new Feature(Length.Short))
      .AddF(new Feature(WhereRead.Home)).AddF(new Feature(UserAction.Reads)) );
    TrainingSet.Add( (new UserData()).AddF(new Feature(Author.Unknown)).AddF(new Feature(Thread.New)).AddF(new Feature(Length.Short))
      .AddF(new Feature(WhereRead.Work)).AddF(new Feature(UserAction.Reads)) );
  }

  public override string ToString() {
    string msg = "";
    foreach (UserData ex in TrainingSet) {
      msg += $"{ex.ToString()}\n";
    }
    msg = msg.TrimEnd('\n');
    return msg;
  }

}

