// This is a decision tree that is a linked list
// Generally decision trees have a condition function c(e) on example e
// Here the implied condition function is that if the example has the condition, i.e.
//   the enum value of the target feature, then c(e) returns true

namespace Lib; 


public class Node {
	public Enum CVal;
	public OptionalNode TNode {get; set;} = new OptionalNode();
	public OptionalNode FNode {get; set;} = new OptionalNode();
	
	public Node() {
		CVal = Empty.None;
	}

	public Node(Enum other) {
		CVal = other;
	}
	public override string ToString() {
		return $"({CVal} {TNode} {FNode})";
	}
	public void AddTNode(Enum cond) {
		TNode = new OptionalNode(cond);
	}

	public void AddFNode(Enum cond) {
		FNode = new OptionalNode(cond);
	}
}

public class OptionalNode {
	public Node? Node;
	public OptionalNode() {
		Node = null;
	}
	public OptionalNode(Enum cond) {
		Node = new Node(cond);
	}
	public bool IsNull() {
		return Node == null;
	}

	public override string ToString() {
		if (Node is null) {
			return "Null";
		}
		else {
			return $"{Node}";
		}
	}
	public void AddTNode(Enum cond) {
		if (Node is not null) {
			Node.AddTNode(cond);	
		}
	}
	public void AddFNode(Enum cond) {
		if (Node is not null) {
			Node.AddFNode(cond);	
		}
	}

	
}

public class ConditionTree {

	public OptionalNode Root;

	public ConditionTree() {
		Root = new OptionalNode();
	}

	public void FindLeaf(Example conds, Enum cond, bool addbook) {
		OptionalNode curnode = Root;
	}

	public ConditionTree Add(Example conds, Enum cond, bool addbool) {

		if (Root.IsNull()) {
			Root = new OptionalNode(cond);
		}
		else {
			FindLeaf(conds, cond, addbool);
		}
    
		return this;
	}

}	