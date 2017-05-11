using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogUIManager : MonoBehaviour, IPointerClickHandler {

	// Test dialog
	private string[] name = new string[]{"Murderer", "Player", "DONALD TRUMP"};
	private string[] dialog = new string[]{"I will kill Alex Jones.", "Sounds good bro.", "Well, that's all the text we've got. Click to repeat."};

	private Text nameText; // Text component of name text
	private Text dialogText; // Text component of dialog text

	private int currentFrame = -1; // The current dialog set of the system

	// Use this for initialization
	void Start (){

		nameText = GameObject.FindGameObjectWithTag("NameText").GetComponent<Text>();
		dialogText = GameObject.FindGameObjectWithTag("DialogText").GetComponent<Text>();


		if (gameObject.layer != 5){
			Debug.LogWarning("Dialog UI Manager is applied to an object not in UI layer, and will not function.");
		}
	}

	// Dialog progression on clicks
	public void OnPointerClick(PointerEventData eventData){

		currentFrame++; // Progress current dialog frame

		// Resetting dialog
		if (currentFrame > 2){
			currentFrame = 0;
		}

		// Set new text
		nameText.text = name[currentFrame];
		dialogText.text = dialog[currentFrame];

	}
}
