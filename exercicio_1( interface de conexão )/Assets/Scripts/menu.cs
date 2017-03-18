using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class menu : MonoBehaviour {

	public Controller scriptController;

	public Text inputName;
	private string nickname;

	void Start ()
	{
		if (scriptController.userName != "") {
			nickname = scriptController.userName;

			Debug.Log ("teste = " + nickname);
			inputName.GetComponent<Text>().text = nickname.ToString ();
		}
	}

	void Update()
	{
	}

	public void setName()
	{
		nickname = inputName.GetComponent<Text>().text;
		scriptController.userName = nickname;
		Debug.Log(nickname);
	}
}


/*
using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class menu : MonoBehaviour {

	public Text textInputName;
	public Text textVerification;

	private string nickname;
	private bool disponivel;

	void Start ()
	{
		nickname = textInputName.GetComponent<Text>().ToString() ;
	}

	void Update()
	{
	}

	public void setName()
	{
		nickname = textInputName.GetComponent<Text>().text;
		Debug.Log(nickname);

		if (disponivel) {
			//textVerification.text = 'Nome de usuário disponivel';
		}
		else {
			//textVerification.text = 'Nome de usuário indisponivel';
		}
	}
}
*/