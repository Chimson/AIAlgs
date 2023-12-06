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

public class UserTraining {
  // does not include target feature UserAction

  private Author Author;
  private Thread Thread;
  private Length Length;
  private WhereRead WhereRead;
  public UserTraining(Author auth, Thread thread, Length len, WhereRead wr) {
    this.Author = auth;
    this.Thread = thread;
    this.Length = len;
    this.WhereRead = wr;
  }
  public override string ToString() {
    return $"Author:{this.Author}, Thread:{this.Thread}, Length:{this.Length}, WhereRead:{this.WhereRead}";
  }
}

// TODO: write some objs in Test 

public class ReadArticleChoiceData {

    

  public ReadArticleChoiceData() {

  }
}