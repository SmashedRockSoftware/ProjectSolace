using UnityEngine;
using UnityEngine.UI;

public class TextNumberController : MonoBehaviour {

	private float number;
	private Text text;

	void Start() {
		//Get text component
		text = gameObject.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update() {
		text.text = number.ToString("0.00");
	}

	/// <summary>
	/// 	Set the number to be display.
	/// </summary>
	/// <param name="num">Number to be displayed.</param>
	public void SetNumber(float num) {
		number = num;
	}
}
