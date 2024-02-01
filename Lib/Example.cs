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

	// maybe change to GetFeatureEnum
  public Enum GetFeatureVal(String feat) {
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
    return Empty.None;
  }  

	public void RemoveCond(Enum cond) {
		Feature cfeat = new Feature(cond);
		Features.Remove(cfeat.GetFeature());
	}

	public Example Clone() {
		Example newex = new Example();
		newex.Features = new Dictionary<string, Enum>(this.Features);
		newex.Types = new List<Type>(this.Types);
		return newex;
	}

}


public class Examples {
	public static string ListExamplesStr(List<Example> exs) {
		string msg = "";
    foreach (Example ex in exs) {
      msg += $"{ex.ToString()}\n";
    }
    msg = msg.TrimEnd('\n');
    return msg;
	}
}