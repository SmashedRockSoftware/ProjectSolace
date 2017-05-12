using System.Collections.Generic;

public class Node {

	//Node test class
	public List<Node> nodes { get; set; }
	public string name { get; set; }

	public Node() {
		nodes = new List<Node>();
		name = "";
	}

	public void Add(Node n) {
		nodes.Add(n);
	}
}
