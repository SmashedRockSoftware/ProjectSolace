using System.Collections.Generic;

public class DialogueNode {

	public string text { get; set; } //The text shown to the player.
	public List<string> replies { get; set;} //List of possible reponses for the player.
	public List<DialogueNode> nextDialogue { get; set; } //List of the next dialogue nodes depending on those responses.

	/// <summary>Initializes a dialogue node.</summary>
	/// <param name="t">Node text.</param>
	/// <param name="re">List of possible replies.</param>
	/// <param name="d">List of branching DialogueNodes.</param>
	public DialogueNode(string t, List<string> re, List<DialogueNode> d) {
		text = t;
		replies = re;
		nextDialogue = d;
	}
	
	/// <summary>Initializes a dialogue node with no arguments.</summary>
	public DialogueNode() {
		text = "";
		replies = new List<string>();
		nextDialogue = new List<DialogueNode>();
	}

	/// <summary>Adds a node to the nextDialogue List.</summary>
	/// <param name="node">Node to be added</param>
	public void AddNodes(DialogueNode node) {
		nextDialogue.Add(node);
	}

	/// <summary>Adds a reply to the replies List.</summary>
	/// <param name="reply">Reply to be added</param>
	public void AddReplies(string reply) {
		replies.Add(reply);
	}

	/// <summary>Returns the next DialogueNode based on choice.</summary>
	/// <param name="choice">The choice of reply, or the next dialogue to display.</param>
	public DialogueNode GetNext(int choice) {
		return nextDialogue[choice];
	}

	/// <summary>Returns the number of possible replies.</summary>
	public int GetNumberOfReplies() {
		return replies.Count;
	}

	/// <summary>Returns the number of possible branches.</summary>
	public int GetNumberOfBranches() {
		return nextDialogue.Count;
	}

	/// <summary>Returns a reply.</summary>
	/// <param name="index">Index of reply.</param>
	public string GetReplyAt(int index) {
		return replies[index];
	}
}
