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

	public void AddRoot(Enum cond) {

		if (Root.GetCond().Equals(Empty.None)) {
			Root = new Node(cond);
		}
	}

	public static ConditionTree ConnectTrees(Enum cond, ConditionTree ttree, ConditionTree ftree) {
		ConditionTree maintree = new ConditionTree(new Node(cond));
		maintree.Root.AddT(ttree.Root);
		maintree.Root.AddF(ftree.Root);
		return maintree;
	}

	public Enum FindPredictor(Node curnode, Example conds) {
		if (curnode.CVal.Equals(Empty.None)) {
			return Empty.None;
		}
		else {
	    Feature curfeat = new Feature(curnode.CVal);
			if (curnode.TNode == null && curnode.FNode == null) {
				return curfeat.Val;
			}
			else {
				Feature condsfeat = new Feature(conds.GetFeatures()[curfeat.GetFeature()]);
				if (curfeat.Equals(condsfeat)) { 
					return FindPredictor(curnode.TNode, conds);
				}
				else { 
					return FindPredictor(curnode.FNode, conds);
				}
			}
		}
	}

	public Enum Predict(Example conds) {
		return FindPredictor(Root, conds);
	}

	public override string ToString() {
		return $"{Root}";
	}

}