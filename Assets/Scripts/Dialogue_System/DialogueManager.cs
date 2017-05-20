using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 	Manager component for dialogue flow and dialogue UI
/// </summary>
public class DialogueManager : MonoBehaviour, IPointerClickHandler {

	// Test dialog
	private readonly string[] names = {"Murderer", "Player", "DONALD TRUMP"};
	private readonly string[] dialogue = {"I will kill Alex Jones.", "&choice", "Well, that's all the text we've got. Click to repeat."};
	private readonly string[] choices = {"Execute Order 66", "Gas 'em", "Make sure it's painless.", "Make sure it's painful."};

	private const string ChoiceString = "&choice"; // Constant for marking a choice in dialogue

	private string currentDialog; // Current dialog of the system
	private int currentChar = 0; // Current char of the dialog
	private float lastTime; // The last time a char was added
	private bool addingChars = false; // Whether chars are currently being added

	private Text nameText; // Text component of name text
	private Text dialogueText; // Text component of dialog text

	public Text[] choiceText; // Text component of choice buttons, assigned in editor
	public Button[] choiceButtons; // Button component of choice buttons, assigned in editor

	private int currentFrame = -1;
	private float dialogSpeed = 0.03f; // In seconds per character
	private bool instantText = false; // Whether text should appear instantly.

	// Use this for initialization
	void Start() {

		// Getting Text components for name and dialog
		nameText = GameObject.FindGameObjectWithTag("NameText").GetComponent<Text>();
		dialogueText = GameObject.FindGameObjectWithTag("DialogText").GetComponent<Text>();

		// Adding button listeners
		choiceButtons[0].onClick.AddListener(() => ChoiceButtonCallback(0));
		choiceButtons[1].onClick.AddListener(() => ChoiceButtonCallback(1));
		choiceButtons[2].onClick.AddListener(() => ChoiceButtonCallback(2));
		choiceButtons[3].onClick.AddListener(() => ChoiceButtonCallback(3));

		if (gameObject.layer != 5) {
			Debug.LogWarning("Dialog UI Manager is applied to " + gameObject.name + ", which is not in UI layer, and will not function.");
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

		if (eventData.button == PointerEventData.InputButton.Right) { // Check if the player's going back
			if (currentFrame > 0 && !dialogue[currentFrame - 1].Equals("&choice")) {
				// Check if player is attempting to go back to a choice
				ChangeDialogueFrame(false);
			}
		} else if(!addingChars) { // If we're not already in the middle of a frame, and is a left click
			ChangeDialogueFrame(true);
		} else { // Finishing current text if we're in some

			dialogueText.text = currentDialog;
			addingChars = false;

		}

	}

	/// <summary>
	/// 	Changes the current dialogue frame forwards or backwards.
	/// </summary>
	/// <param name="forward">Whether to advance forwards or backwards.</param>
	private void ChangeDialogueFrame(bool forward) {
		if (forward) {
			currentFrame++; // Progress dialog
		} else {
			currentFrame--; // Regress dialog
		}

		// Resetting dialog, should be removed/made general later
		if (currentFrame > 2) {
			currentFrame = 0;
		}
		else if (currentFrame < 0) {
			currentFrame = 0;
		}

		nameText.text = names[currentFrame]; // Set new name text

		// Check if next dialogue node is a choice or not
		if (dialogue[currentFrame].Equals(ChoiceString)) { // If a choice

			SetChoiceButtonEnable(true, choices.Length); // Enable buttons
			dialogueText.text = ""; // Remove the previous text from the screen

			// Fill in choice text with choices and enable
			for (int i = 0; i < choices.Length; i++) {
				choiceText[i].text = choices[i];
			}

		} else { // Not a choice

			// Disable all choice buttons
			SetChoiceButtonEnable(false, 4);

			currentDialog = dialogue[currentFrame]; // Buffer new dialog text

			// Reset dialog box, lastTime, and currentChar
			dialogueText.text = "";
			lastTime = 0;
			currentChar = 0;

			addingChars = true; // We're adding chars now

		}

	}

	/// <summary>
	/// 	The callback function for the choice buttons.
	/// </summary>
	/// <param name="number">The number of the choice that was made.</param>
	private void ChoiceButtonCallback(int number) {

		ChangeDialogueFrame(true); // Advance the frame

		Debug.Log(number);

	}

	/// <summary>
	/// 	Sets the enable state of choice buttons from 0 to max - 1.
	/// </summary>
	/// <param name="enabled">Whether to enable or disable buttons.</param>
	/// <param name="max">The maximum button to change.</param>
	private void SetChoiceButtonEnable(bool enabled, int max) {
		for (int i = 0; i < max; i++) {
			choiceButtons[i].gameObject.SetActive(enabled);
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
