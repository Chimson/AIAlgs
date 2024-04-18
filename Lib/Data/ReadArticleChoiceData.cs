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
  public List<Example> TrainingSet {get;}
  
  public ReadArticleChoiceData() {
    TrainingSet = new List<Example>();
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

/*
(18 Examples total)
AUTHOR   THREAD    LENGTH WHEREREAD USERACTION
Known    New       Long   Home      Skips
Unknown  New       Short  Work      Reads
Unknown  Followup  Long   Work      Skips
Known    Followup  Long   Home      Skips
Known    New       Short  Home      Reads
Known    Followup  Long   Work      Skips
Unknown  Followup  Short  Work      Skips
Unknown  New       Short  Work      Reads
Known    Followup  Long   Home      Skips
Known    New       Long   Work      Skips
Unknown  Followup  Short  Home      Skips
Known    New       Long   Work      Skips
Known    Followup  Short  Home      Reads
Known    New       Short  Work      Reads
Known    New       Short  Home      Reads
Known    Followup  Short  Work      Reads
Known    New       Short  Home      Reads
Unknown  New       Short  Work      Reads
*/