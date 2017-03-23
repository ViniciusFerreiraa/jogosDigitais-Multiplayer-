using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class Controller : MonoBehaviour {

	// -----------------------------------
	public string nickName;

	// -----------------------------------
	public string serverIp;
	public string port;


	// -----------------------------------
	public string codeCloud;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// status do game --------------------
	// -----------------------------------
	public void stats(){
		Debug.Log ("nome do jogador = " + PhotonNetwork.playerName);
		Debug.Log ("IP do servidor = " + serverIp);
		Debug.Log ("Porta = " + port);
		Debug.Log ("Código da nuvem = " + codeCloud);
	}
}
