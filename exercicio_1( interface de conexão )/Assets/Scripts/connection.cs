using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("1.0");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// PADRÕES PHONTON --------------------------------------------------------
	void OnConnectedToPhoton(){
		Debug.Log("conectado");
	}
	void OnDisconnectedFromPhoton(){
		Debug.Log("a conexão foi perdida");
	}



	// CONECTAR A UM SERVIDOR -------------------------------------------------
	//void conectToServer(string server, int port, string id){
	//	PhotonNetwork.ConnectToMaster ( server, port, id, "1.0");
	//}


	// CONECTAR A NUVEM -------------------------------------------------------
	void connectToCloud(){
		PhotonNetwork.ConnectToBestCloudServer("1.0");
	}


	// LISTA DE SALAS ---------------------------------------------------------
	void getRoomList(){
		PhotonNetwork.GetRoomList ();
	}
}
