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


// NEEDS ITS OWN FILE
public class Example {

  public Dictionary<String, Enum> Features;
  public List<Type> Types = new List<Type>();
  
  public Example() {
    Features = new Dictionary<String, Enum>();
  }

  public override string ToString() {
    String msg = "";
    foreach (KeyValuePair<String, Enum> kvp in Features) {
      msg += $"{kvp.Key}: {kvp.Value}, ";
    }  
    return msg.TrimEnd(' ').TrimEnd(',');
  }

  public Example Add(String ftype, Enum val) {
    // add to the dictionary and the Type list
    
    Features[ftype] = val;

    Types.Add(val.GetType());
  
    return this;
  }

  public Dictionary<string, Enum> GetFeatures() {
    return Features;
  } 

  public Enum GetFeature(String feat) {
    return Features[feat];
  }

  public Enum ConvertToEnum(string tval) {
    object? result;
    foreach (Type type in Types) {
      bool works = Enum.TryParse(type, tval, out result);
      if (works && result != null) {
        return (Enum) result;
      }
    }
    return None.None;
  }  

  public static string TrimTypeName(Type type) {
    string name = $"{type}";
    string[] namespaces = name.Split(".");
    return namespaces[namespaces.Count()-1];
  }

}



public class ReadArticleChoiceData {
  public List<Example> TrainingSet = new List<Example>(); 
  
  public ReadArticleChoiceData() {
    TrainingSet.Add((new Example())
      .Add("Author", Author.Known).Add("Thread", Thread.New).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Home).Add("UserAction", UserAction.Skips));
    TrainingSet.Add((new Example())
      .Add("Author", Author.Unknown).Add("Thread", Thread.New).Add("Length", Length.Short)
      .Add("WhereRead", WhereRead.Work).Add("UserAction", UserAction.Reads));
    TrainingSet.Add((new Example())
      .Add("Author", Author.Unknown).Add("Thread", Thread.Followup).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Work).Add("UserAction", UserAction.Skips));
    TrainingSet.Add((new Example())
      .Add("Author", Author.Known).Add("Thread", Thread.Followup).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Home).Add("UserAction", UserAction.Skips));  
    TrainingSet.Add((new Example())
      .Add("Author", Author.Known).Add("Thread", Thread.New).Add("Length", Length.Short)
      .Add("WhereRead", WhereRead.Home).Add("UserAction", UserAction.Reads));  
    TrainingSet.Add((new Example())
      .Add("Author", Author.Known).Add("Thread", Thread.Followup).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Work).Add("UserAction", UserAction.Skips)); 
    TrainingSet.Add((new Example())
      .Add("Author", Author.Unknown).Add("Thread", Thread.Followup).Add("Length", Length.Short)
      .Add("WhereRead", WhereRead.Work).Add("UserAction", UserAction.Skips)); 
    TrainingSet.Add((new Example())
      .Add("Author", Author.Unknown).Add("Thread", Thread.New).Add("Length", Length.Short)
      .Add("WhereRead", WhereRead.Work).Add("UserAction", UserAction.Reads)); 
    TrainingSet.Add((new Example())
      .Add("Author", Author.Known).Add("Thread", Thread.Followup).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Home).Add("UserAction", UserAction.Skips)); 
    TrainingSet.Add((new Example())
      .Add("Author", Author.Known).Add("Thread", Thread.New).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Work).Add("UserAction", UserAction.Skips));    
    TrainingSet.Add((new Example())
      .Add("Author", Author.Unknown).Add("Thread", Thread.Followup).Add("Length", Length.Short)
      .Add("WhereRead", WhereRead.Home).Add("UserAction", UserAction.Skips));
    TrainingSet.Add((new Example())
      .Add("Author", Author.Known).Add("Thread", Thread.New).Add("Length", Length.Long)
      .Add("WhereRead", WhereRead.Work).Add("UserAction", UserAction.Skips));
    TrainingSet.Add((new Example())
      .Add("Author", Author.Known).Add("Thread", Thread.Followup).Add("Length", Length.Short)
      .Add("WhereRead", WhereRead.Home).Add("UserAction", UserAction.Reads));
    TrainingSet.Add((new Example())
      .Add("Author", Author.Known).Add("Thread", Thread.New).Add("Length", Length.Short)
      .Add("WhereRead", WhereRead.Work).Add("UserAction", UserAction.Reads));
    TrainingSet.Add((new Example())
      .Add("Author", Author.Known).Add("Thread", Thread.New).Add("Length", Length.Short)
      .Add("WhereRead", WhereRead.Home).Add("UserAction", UserAction.Reads));
    TrainingSet.Add((new Example())
      .Add("Author", Author.Known).Add("Thread", Thread.Followup).Add("Length", Length.Short)
      .Add("WhereRead", WhereRead.Work).Add("UserAction", UserAction.Reads));
    TrainingSet.Add((new Example())
      .Add("Author", Author.Known).Add("Thread", Thread.New).Add("Length", Length.Short)
      .Add("WhereRead", WhereRead.Home).Add("UserAction", UserAction.Reads));
    TrainingSet.Add((new Example())
      .Add("Author", Author.Unknown).Add("Thread", Thread.New).Add("Length", Length.Short)
      .Add("WhereRead", WhereRead.Work).Add("UserAction", UserAction.Reads));
  }

  public override string ToString() {
    string msg = "";
    foreach (Example ex in TrainingSet) {
      msg += $"{ex.ToString()}\n";
    }
    msg = msg.TrimEnd('\n');
    return msg;
  }

}

