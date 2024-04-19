// This is a decision tree that is a linked list
// Generally decision trees have a condition function c(e) on example e
// Here the implied condition function is that if the example has the condition, i.e.
//   the enum value of the target feature, then c(e) returns true

namespace Lib; 


public class ConditionTree {

	private Node Root;


	public ConditionTree() {
		Root = new Node();
	}

	public ConditionTree(Enum cond) {
		Root = new Node(cond);
	}

	public static ConditionTree ConnectTrees(Enum cond, ConditionTree ttree, ConditionTree ftree) {
		ConditionTree maintree = new ConditionTree(cond);
		maintree.Root.AddT(ttree.Root);
		maintree.Root.AddF(ftree.Root);
		return maintree;
	}

	private Enum FindPredictor(Node curnode, Example conds) {
		if (curnode.GetCVal().Equals(Empty.None)) {
			return Empty.None;
		}
		else {
			if (curnode.GetT() == null && curnode.GetF() == null) {
				return curnode.GetCVal();
			}
			else {
        // Enum condsfeat = conds.Features[Example.GetFeature(curnode.GetCVal())];
        if (conds.FindFeatVal(curnode.GetCVal())) { 
					return FindPredictor(curnode.GetT(), conds);
				}
				else { 
					return FindPredictor(curnode.GetF(), conds);
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