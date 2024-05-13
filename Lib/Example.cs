
namespace Lib;

public class Example {

  public Dictionary<String, Enum> Features {get;}
  public List<Type> Types {get;}
  
  public Example() {
    Features = new Dictionary<String, Enum>();
    Types = new List<Type>();
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

  public string[] AllPossValsForFeat(string feature) {
    Enum val = this.Features[feature];
    return Enum.GetNames(val.GetType());
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
		Features.Remove(Example.GetFeature(cond));
	}

	public Example Clone() {
		Example newex = new Example();
    foreach (KeyValuePair<String, Enum> kvp in Features) {
      newex.Add(kvp.Key, kvp.Value);  
    }
		return newex;
	}


  public static string TrimTypeName(Type type) {
    string name = $"{type}";
    string[] namespaces = name.Split(".");
    return namespaces[namespaces.Count()-1];
  }

  public static string GetFeature(Enum val) {
    return TrimTypeName(val.GetType());
  } 

  public bool FindFeatVal(Enum val) {
    return Features.ContainsValue(val);
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

