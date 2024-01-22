namespace Lib;

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