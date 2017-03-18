using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class menu : MonoBehaviour {


	public InputField mainInputField;
	private string textInput;

	public void Start()
	{
		textInput = mainInputField.text;
	}

	void Update()
	{
	}

	public void setName()
	{
		Debug.Log(textInput);
	}
}
