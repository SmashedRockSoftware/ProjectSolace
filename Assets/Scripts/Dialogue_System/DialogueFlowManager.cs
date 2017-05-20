using UnityEngine;

public class DialogueFlowManager : MonoBehaviour {

	private DialogueNode currentNode; // The current dialogue node that the manager is processing

	private DialogueUIManager currentUI; // The current UI manager, fetched at runtime

	// Use this for initialization
	void Start () {

		currentUI = GetComponent<DialogueUIManager>();

		// Currently, the flow and UI managers must be placed on the same gameobject
		// This might have to be changed later
		if (currentUI == null) {
			Debug.LogError(gameObject.name + " has DialogueFlowManager, but no DialogueUIManager!");
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
