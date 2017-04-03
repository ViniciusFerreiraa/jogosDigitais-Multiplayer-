using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class connect : MonoBehaviour {

	// ---------------------------------------------
	public Text inputNickName;
	public Text checkName;
	public Text connectionFail;
	public Text connectionInfo;
	private string nickName;

	// -----------------------------------
	public GameObject firstStep;
	public GameObject cloudLobby;
	public GameObject roomInfos;

	// Use this for initialization
	void Start () {
	}

	/*
	public void EntrarNaSala() {
		texto.text = "Conectando...";
		PhotonNetwork.ConnectUsingSettings("1.0");
		GetComponent<Button>().enabled = false;
	}

	void OnConnectedToMaster()
	{
		PhotonNetwork.JoinOrCreateRoom("SalaDoFausto", new RoomOptions() { IsVisible = true },  TypedLobby.Default);
	}
	void OnJoinedRoom()
	{
		texto.text = "Conectou!";
		CriarJogador();
	}
	private void OnFailedToConnect(NetworkConnectionError error)
	{
		Debug.Log(error.ToString());
		GetComponent<Button>().enabled = true;
		texto.text = "Entrar";
	}
	void CriarJogador()
	{
		PhotonNetwork.Instantiate("Jogador", new Vector3(0.0f, 1.5f, 0.0f), Quaternion.identity, 0);
	}
	*/



	// FIRST STEP -------------------------------------------------------------------------------
	// ------------------------------------------------------------------------------------------
	// DEFINI O NOME DO JOGADOR --------------------
	public void setName()
	{
		nickName = inputNickName.GetComponent<Text>().text;
	}

	// CHAMA A TELA PARA CONECTAR EM NUVEM ---------
	public void callCloudLobby(){
		if (nickName == "") {
			emptyName ();
		}
		else {
			PhotonNetwork.ConnectUsingSettings("1.0");
			connectionInfo.GetComponent<Text> ().color = new Color (255, 255, 255, 1);
		}
	}
		void OnConnectedToMaster()
		{
			cloudLobby.transform.position = new Vector3 ((Screen.width / 2), (Screen.height / 2), 0);

			checkName.GetComponent<Text> ().color = new Color (255, 0, 0, 0);
			connectionFail.GetComponent<Text> ().color = new Color (255, 0, 0, 0);
			connectionInfo.GetComponent<Text> ().color = new Color (255, 255, 255, 0);
		}
		void OnFailedToConnect(NetworkConnectionError error)
		{
			connectionFail.GetComponent<Text> ().color = new Color (255, 0, 0, 1);
		}

	// NOME DE JOGADOR NÃO INSERIDO ----------------
	private void emptyName(){
		checkName.GetComponent<Text> ().color = new Color (255, 0, 0, 1);		
	}




	// SECOND STEP ------------------------------------------------------------------------------
	// ------------------------------------------------------------------------------------------
	// CRIA / SE CONECTA A UMA SALA ----------------
	public void createRoom()
	{
		//PhotonNetwork.JoinOrCreateRoom("SalaDoFausto", new RoomOptions() { IsVisible = true },  TypedLobby.Default);
	}
	public void connectRandonRoom()
	{
		//PhotonNetwork.JoinOrCreateRoom("SalaDoFausto", new RoomOptions() { IsVisible = true },  TypedLobby.Default);
	}




	// THIRD STEP -------------------------------------------------------------------------------
	// ------------------------------------------------------------------------------------------
	// ENTRAR NO GAME UMA SALA ---------------------
	public void joinRoom()
	{
		//PhotonNetwork.JoinOrCreateRoom("SalaDoFausto", new RoomOptions() { IsVisible = true },  TypedLobby.Default);
	}

	// ENTROU NO GAME ------------------------------
	void OnJoinedRoom()
	{
		CriarJogador();
	}

	// INSTACIA O PLAYER ---------------------------
	void CriarJogador()
	{
		//PhotonNetwork.Instantiate("Jogador", new Vector3(0.0f, 1.5f, 0.0f), Quaternion.identity, 0);
	}
}
