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

