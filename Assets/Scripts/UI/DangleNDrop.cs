using UnityEngine;
using UnityEngine.EventSystems;

public class DangleNDrop : MonoBehaviour, IDragHandler {
	/// <summary>
	/// A component for UI elements that makes them pullable. Pullable components can be dragged around by the mouse,
	///  but are not dragged to the mouse itself.
	/// </summary>
	[SerializeField] float Mult = 1;
	// Constant multiplier for drag speed

	private RectTransform panel;
	// RectTransform of this GUI object

	// Initialization, getting RectTransform
	void Awake() {
		panel = GetComponent<RectTransform>();

		if (panel == null) {
			Debug.LogError (gameObject.name + " has Pullable, but no RectTransform!");
		}
	}

	// Unity Method for detecting mouse dragging on a component
	public void OnDrag (PointerEventData pointerData) {
		// Add mouse position delta onto panel position
		panel.position += Mult * new Vector3 (pointerData.delta.x, pointerData.delta.y);
	}
}
