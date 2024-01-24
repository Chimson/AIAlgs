// class used to take enums and represent them as features
// for categorical features in supervised learning

namespace Lib;

public enum None {
  None
}

public class Feature {

  private Enum Val;
  
  public Feature(Enum val) {
    Val = val;
  }

  public string GetFeature() {
    return TrimTypeName(Val.GetType());
  } 

  public string GetVal() {
    string? msg =  Enum.GetName(Val.GetType(), Val);
    if (msg is null) {return "null";}
    return msg;
  }

  public bool Equals(Feature other) {
    return 
      this.GetFeature() == other.GetFeature() &&
      this.GetVal() == other.GetVal();
  }

	public static string TrimTypeName(Type type) {
    string name = $"{type}";
    string[] namespaces = name.Split(".");
    return namespaces[namespaces.Count()-1];
  }

	

}

