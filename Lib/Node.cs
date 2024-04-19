namespace Lib;

public class Node {
	private Enum CVal;
  private Node? TNode;
	private Node? FNode;
	
	public Node() {
		CVal = Empty.None;
		TNode = null;
		FNode = null;
	}

	public Node(Enum other) {
		CVal = other;
	}

	public void AddT(Node node) {
		TNode = node;
	}

	public void AddF(Node node) {
		FNode = node;
	}

  public Node? GetT() {
    return TNode;
  }

  public Node? GetF() {
    return FNode;
  }

	public Enum GetCVal() {
		return CVal;
	}

	public override string ToString() {
		string msg = $"({CVal}, ";
	  if (TNode == null) {
			msg += "null, ";
		}
		else {
			msg += $"{TNode}, ";
		}
		if (FNode == null) {
		 	msg += "null)"; 
		}
		else {
			msg += $"{FNode})";
		}
		return msg;
	}

}