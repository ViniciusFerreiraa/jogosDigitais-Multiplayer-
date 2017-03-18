using UnityEngine;
using System.Collections;

public class Barril : MonoBehaviour {

	public MoveController scriptMove;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "PlayerBarril" && scriptMove.canHidde) {
			scriptMove.escondido = true;
			GameObject.Find ("Char").GetComponent<Animator>().enabled = false;
			GameObject.Find ("Char").GetComponent<SpriteRenderer>().sprite = null;
			GameObject.Find ("Char/Shadow").GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "PlayerBarril") {
			scriptMove.escondido = false;
			GameObject.Find ("Char").GetComponent<Animator>().enabled = true;
			GameObject.Find ("Char/Shadow").GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}
