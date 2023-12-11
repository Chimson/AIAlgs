// class used to take enums and represent them as features
// for categorical features in supervised learning

namespace Lib;

public class Feature {

  private Enum Val;
  
  public Feature(Enum val) {
    Val = val;
  }

  public Type GetFeature() {
    return Val.GetType();
  } 

  public string GetVal() {
    string? msg =  Enum.GetName(Val.GetType(), Val);
    if (msg is null) {return "null";}
    return msg;
  }

}