// This is a decision tree that is a linked list
// Generally decision trees have a condition function c(e) on example e
// Here the implied condition function is that if the example has the condition, i.e.
//   the enum value of the target feature, then c(e) returns true

namespace Lib; 


public class Node {
	public Enum CVal;
  public Node? TNode;
	public Node? FNode;
	
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

	public Enum GetCond() {
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

public class ConditionTree {

	public Node Root;

	public ConditionTree() {
		Root = new Node();
	}

	public ConditionTree(Node node) {
		Root = node;
	}

	public void AddToLeaf(Node curnode, Example ex, Enum cond) {
		Feature cnfeat = new Feature(curnode.GetCond());
		Feature exfeat = new Feature(ex.GetFeatureVal(cnfeat.GetFeature()));
		if (cnfeat.GetVal() == exfeat.GetVal()) {
			if (curnode.TNode == null) {
				curnode.AddT(new Node(cond));
			}
			else {
			  AddToLeaf(curnode.TNode, ex, cond);
			}
		}
		else {
			if (curnode.FNode == null) {
				curnode.AddF(new Node(cond));
			}
			else {
			  AddToLeaf(curnode.FNode, ex, cond);
			}
		}
	}

	public void Add(Example conds, Enum cond) {

		if (Root.GetCond().Equals(Empty.None)) {
			Root = new Node(cond);
		}
		else {
			AddToLeaf(Root, conds, cond);
		}
	}

	public override string ToString() {
		return $"{Root}";
	}

}