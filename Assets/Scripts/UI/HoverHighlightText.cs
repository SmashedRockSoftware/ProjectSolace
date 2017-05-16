using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverHighlightText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Color HighlightColor; // The color to change to on highlight
	private Text text; // The text component to change
	private Color originalColor; // The original color of thix text

	// Use this for initialization
	void Start () {

		text = gameObject.GetComponent<Text>(); // Initialize Text

		if (text == null) {
			Debug.LogError(gameObject.name + " has Hover Highlight Text, but no Text component!");
		} else {
			originalColor = text.color; // If there is a text, get it's color for restoring later
		}

	}

	void OnDisable() {
		// Cleanup of highlight
		text.color = originalColor;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		// Changing color on mouse enter
		text.color = HighlightColor;
	}

	public void OnPointerExit(PointerEventData eventData) {
		// Reset color on mouse exit
		text.color = originalColor;
	}
}
