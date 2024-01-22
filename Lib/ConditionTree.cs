// This is a decision tree that is a linked list
// Generally decision trees have a condition function c(e) on example e
// Here the implied condition function is that if the example has the condition, i.e.
//   the enum value of the target feature, then c(e) returns true

namespace Lib; 


public class Node {
	public Enum CVal {get; set;} = Empty.None;
	public Node(Enum other) {
		CVal = other;
	}
	public OptionalNode TNode {get; set;} = new OptionalNode();
	public OptionalNode FNode {get; set;} = new OptionalNode();
}

public class OptionalNode {
	public Node? Node {set; get;} = null;
	public OptionalNode() {;}
	public OptionalNode(Node node) {
		Node = node;
	}
	public bool IsEnd() {
		return Node == null;
	}
	
}

public class ConditionTree {

	public OptionalNode Root;

	public ConditionTree() {
		Root = new OptionalNode();
	}

	public ConditionTree Add(Enum cond, bool truth) {

		if (Root.IsEnd()) {
			Root = new OptionalNode(new Node(cond));
		}
		else {
			
		}
    
		return this;
	}

}	