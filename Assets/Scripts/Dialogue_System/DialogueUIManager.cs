using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueUIManager : MonoBehaviour, IPointerClickHandler {

	// Test dialog
	private readonly string[] names = new string[]{"Murderer", "Player", "DONALD TRUMP"};
	private readonly string[] dialogue = new string[]{"I will kill Alex Jones.", "Sounds good bro.", "Well, that's all the text we've got. Click to repeat."};

	private string currentDialog; // Current dialog of the system
	private int currentChar = 0; // Current char of the dialog
	private float lastTime; // The last time a char was added
	private bool addingChars = false; // Whether chars are currently being added

	private Text nameText; // Text component of name text
	private Text dialogueText; // Text component of dialog text

	private int currentFrame = -1;
	private float dialogSpeed = 0.03f; // In seconds per character
	private bool instantText = false; // Whether text should appear instantly.

	// Use this for initialization
	void Start() {

		// Getting Text components for name and dialog
		nameText = GameObject.FindGameObjectWithTag("NameText").GetComponent<Text>();
		dialogueText = GameObject.FindGameObjectWithTag("DialogText").GetComponent<Text>();


		if (gameObject.layer != 5) {
			Debug.LogWarning("Dialog UI Manager is applied to an object not in UI layer, and will not function.");
		}
	}

	// Dialog speed control in update
	void Update() {

		// Check if we're displaying text instantly or not
		if (instantText) {

			dialogueText.text = currentDialog;
			addingChars = false;

		} else {

			// Check for adding chars to text
			if (addingChars && currentChar < currentDialog.Length && Time.time - lastTime > dialogSpeed) {
				dialogueText.text += currentDialog[currentChar]; // Add a new char
				currentChar++; // Move to next char
				lastTime = Time.time;
			}
			else if (currentDialog != null && currentChar >= currentDialog.Length) {
				addingChars = false; // Keep addingChars false for as long as chars aren't being added
			}
		}

	}

	// Dialog progression on clicks
	public void OnPointerClick(PointerEventData eventData) {

		// Check to see if we're already in some dialog or player is attempting to go back
		if (!addingChars || eventData.button == PointerEventData.InputButton.Right) {
			if (eventData.button == PointerEventData.InputButton.Left) {
				currentFrame++; // Progress dialog on left click
			}
			else if (eventData.button == PointerEventData.InputButton.Right) {
				currentFrame--; // Regress dialog on right click
			}


			// Resetting dialog
			if (currentFrame > 2) {
				currentFrame = 0;
			}
			else if (currentFrame < 0) {
				currentFrame = 0;
			}

			// Set new name text and buffer new dialog text
			nameText.text = names[currentFrame];
			currentDialog = dialogue[currentFrame];

			// Reset dialog box, lastTime, and currentChar
			dialogueText.text = "";
			lastTime = 0;
			currentChar = 0;

			addingChars = true; // We're adding chars now

		} else { // Finishing current text if we're in some

			dialogueText.text = currentDialog;
			addingChars = false;

		}

	}

	/// <summary>
	/// 	Sets the speed of the text to a value.
	/// </summary>
	/// <param name="speed">Speed in seconds per char.</param>
	public void SetTextSpeed (float speed) {
		dialogSpeed = speed;
	}

	/// <summary>
	/// 	Toggles instant text on or off.
	/// </summary>
	public void ToggleInstantText() {
		instantText = !instantText;
	}

}
