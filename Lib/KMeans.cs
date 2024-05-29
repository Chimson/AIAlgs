namespace Lib;

public class KMeans {

  // this is the k-means() function 
  public static void Predict(List<DecExample> examples, int k) {

    // set the number of features 
    // FIX: can throw an exception when examples is empty
    int NumFeatures = examples[0].Features.Count;

    // count per cluster, for example, cc[0] =  10, 10 in cluster 0
    // fs[j, c] is sum of feature values per cluster, of j feature, c cluster
    int[] cc = new int[k];
    double[][] fs = {new double[NumFeatures], new double[k]};

    RandomInit(cc, fs, examples);
  }

  public static void RandomInit(int[] cc, double[][] fs, List<DecExample> exs) {
    
  }

}