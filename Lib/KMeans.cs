namespace Lib;

public class KMeans {

  // this is the k-means() function 
  public static void Predict(List<DecExample> examples, int k) {

    // set the number of features 
    // FIX: can throw an exception when examples is empty
    int num_features = examples[0].Features.Count;

    // count per cluster, for example, cc[0] =  10, 10 in cluster 0
    // clusters are numbered from 0 to k - 1
    // fs[j, c] is sum of feature values per cluster, of j feature, c cluster
    int[] cc = new int[k];
    double[][] fs = {new double[num_features], new double[k]};

    RandomInit(cc, fs, examples, k);
  }

  public static void RandomInit(int[] cc, double[][] fs, List<DecExample> exs, int k) {
    Random rand = new Random();
    int num_exs = exs.Count;
    int feat_nums = cc.Length;

    // array to temporarily hold an initial assignment of clusters
    // indices enumerate each example, value is the cluster assignent
    int[] cluster_map = new int[num_exs];

    for (int e = 0; e < num_exs; ++e) {
      // get a random number from 0 to k-1, same as clusters
      cluster_map[e] = rand.Next(k);
    }

    // calculate count per cluster cc
    /*
      cluster_map[ex] = cluster
      cc[cluster] = count
    */
    for (int e = 0; e < num_exs; ++e) {
      cc[cluster_map[e]] += 1; 
    }

    // calculate fs, the sum of the feature values for cluster c
    /*
      fs[feature, cluster]
    */
    for (int e = 0; e < num_exs; ++e) {
      for (int f = 0; f < feat_nums; ++f) {
        fs[f][cluster_map[e]] += exs[e].Val(f);
      }
    }






    Console.WriteLine(ArrIndexValString(cluster_map, "cluster map"));
    Console.WriteLine(ArrIndexValString(cc, "cluster counts cc"));
    // TODO: create a print function to print the fs matrix

  }

  // TODO: move this to another class or abstract it
  public static string ArrIndexValString(int[] arr, string title) {
    int size = arr.Length;
    string msg = $"{title}:\n";
    for (int i = 0; i < size; ++i) {
      msg += $"{i}: {arr[i]}\n";
    }
    return msg;
  }



}