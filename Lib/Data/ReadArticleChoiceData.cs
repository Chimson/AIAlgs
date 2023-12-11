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

public class UserData {

  public Author Author;
  public Thread Thread;
  public Length Length;
  public WhereRead WhereRead;

  // target feature
  public UserAction UserAction;
  
  public UserData(Author auth, Thread thread, Length len, WhereRead wr, UserAction ua) {
    this.Author = auth;
    this.Thread = thread;
    this.Length = len;
    this.WhereRead = wr;
    this.UserAction = ua;
  }

  public override string ToString() {
    return $"Author:{this.Author}, Thread:{this.Thread}, Length:{this.Length}, WhereRead:{this.WhereRead}";
  }
}


public class ReadArticleChoiceData {
  public List<UserData> TrainingSet = new List<UserData>(); 
  
  public ReadArticleChoiceData() {
    TrainingSet.Add(new UserData(Author.Known,   Thread.New,      Length.Long,  WhereRead.Home, UserAction.Skips));
    TrainingSet.Add(new UserData(Author.Unknown, Thread.New,      Length.Short, WhereRead.Work, UserAction.Reads));
    TrainingSet.Add(new UserData(Author.Unknown, Thread.Followup, Length.Long,  WhereRead.Work, UserAction.Skips));
    TrainingSet.Add(new UserData(Author.Known,   Thread.Followup, Length.Long,  WhereRead.Home, UserAction.Skips));
    TrainingSet.Add(new UserData(Author.Known,   Thread.New,      Length.Short, WhereRead.Home, UserAction.Reads));
    TrainingSet.Add(new UserData(Author.Known,   Thread.Followup, Length.Long,  WhereRead.Work, UserAction.Skips));
    TrainingSet.Add(new UserData(Author.Unknown, Thread.Followup, Length.Short, WhereRead.Work, UserAction.Skips));
    TrainingSet.Add(new UserData(Author.Unknown, Thread.New,      Length.Short, WhereRead.Work, UserAction.Reads));
    TrainingSet.Add(new UserData(Author.Known,   Thread.Followup, Length.Long,  WhereRead.Home, UserAction.Skips));
    TrainingSet.Add(new UserData(Author.Known,   Thread.New,      Length.Long,  WhereRead.Work, UserAction.Skips));
    TrainingSet.Add(new UserData(Author.Unknown, Thread.Followup, Length.Short, WhereRead.Home, UserAction.Skips));
    TrainingSet.Add(new UserData(Author.Known,   Thread.New,      Length.Long,  WhereRead.Work, UserAction.Skips));
    TrainingSet.Add(new UserData(Author.Known,   Thread.Followup, Length.Short, WhereRead.Home, UserAction.Reads));
    TrainingSet.Add(new UserData(Author.Known,   Thread.New,      Length.Short, WhereRead.Work, UserAction.Reads));
    TrainingSet.Add(new UserData(Author.Known,   Thread.New,      Length.Short, WhereRead.Home, UserAction.Reads));
    TrainingSet.Add(new UserData(Author.Known,   Thread.Followup, Length.Short, WhereRead.Work, UserAction.Reads));
    TrainingSet.Add(new UserData(Author.Known,   Thread.New,      Length.Short, WhereRead.Home, UserAction.Reads));
    TrainingSet.Add(new UserData(Author.Unknown, Thread.New,      Length.Short, WhereRead.Work, UserAction.Reads));
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

