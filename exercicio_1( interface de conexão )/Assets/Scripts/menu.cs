using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class menu : MonoBehaviour {

	public Controller scriptController;


	// ---------------------------------------------
	public Text inputName;
	public Text checkName;
	public Text errorName;

	private string nickNameTemp;
	private bool avaliableName;


	// ---------------------------------------------
	public Text inputServerIp;
	public Text inputPort;
	public Text errorServer;

	private string serverIpTemp;
	private string portTemp;

	// ---------------------------------------------
	public Text inputCodeCloud;
	public Text errorCloud;

	private string codeCloudTemp;

	// -----------------------------------
	public GameObject menuInitial;
	public GameObject menuServer;
	public GameObject menuCloud;
	public GameObject menuListLobs;


	void Start ()
	{
		if (scriptController.nickName != "") {
			nickNameTemp = scriptController.nickName;

			inputName.GetComponent<Text>().text = nickNameTemp.ToString ();
		}
	}

	void Update()
	{
	}


	// DEFINI O NOME DO JOGADOR --------------------
	// ---------------------------------------------
	public void setName()
	{
		nickNameTemp = inputName.GetComponent<Text>().text;

		if (nickNameTemp != "") {
			avaliableName = true;
			if (avaliableName) {
				checkName.GetComponent<Text> ().text = "Nick inserido com sucesso";
				checkName.GetComponent<Text> ().color = new Color (2, 158, 42, 1);

				scriptController.nickName = nickNameTemp;
				hideInsertName ();
			} else {
				checkName.GetComponent<Text> ().text = "Alguém já está usando este nick";
				checkName.GetComponent<Text> ().color = new Color (255, 0, 0, 1);
			}
		}
		else {
			emptyName ();
		}
	}


	// DEFINE O SERVIDOR ---------------------------
	// ---------------------------------------------
	public void setServer()	{
		serverIpTemp = inputServerIp.GetComponent<Text>().text;
		portTemp = inputPort.GetComponent<Text>().text;

		if (serverIpTemp == "") {
			errorServer.GetComponent<Text>().text = "você precisa inserir o IP do servidor desejado";
			errorServer.GetComponent<Text>().color = new Color(255, 255, 0, 1);
		}
		else if (portTemp == "") {
			errorServer.GetComponent<Text>().text = "você precisa inserir a porta desejada";
			errorServer.GetComponent<Text>().color = new Color (255, 255, 0, 1);
		}
		else {
			scriptController.serverIp = serverIpTemp;
			scriptController.port = portTemp;

			callListLobs ();
		}
	}


	// DEFINE O CÓDIGO PARA ENTRAR NA NUVEM --------
	// ---------------------------------------------
	public void setCloud() {
		codeCloudTemp = inputCodeCloud.GetComponent<Text>().text;

		if (codeCloudTemp != "") {
			scriptController.codeCloud = codeCloudTemp;
			callListLobs ();
		}
		else {
			errorCloud.GetComponent<Text>().text = "Você precisa inserir o código de coexão";
			errorCloud.GetComponent<Text>().color = new Color (255, 255, 0, 1);
		}
	}


	// CHAMA A TELA DE PARA CONECTAR AO SERVIDOR ---
	// ---------------------------------------------
	public void callConnectOnServer(){
		if (scriptController.nickName == "") {
			emptyName ();
		}
		else {
			menuServer.transform.position = new Vector3 ((Screen.width / 2 + 634 / 2), (Screen.height / 2 + 305 / 2), 0);
			menuInitial.transform.position = new Vector3 ((Screen.width*2), (Screen.height), 0);
		}
	}

	// CHAMA A TELA PARA CONECTAR EM NUVEM ---------
	// ---------------------------------------------
	public void callConnectCloud(){
		if (scriptController.nickName == "") {
			emptyName ();
		}
		else {
			menuCloud.transform.position = new Vector3 ((Screen.width / 2 + 634 / 2), (Screen.height / 2 + 305 / 2), 0);
			menuInitial.transform.position = new Vector3 ((Screen.width*2), (Screen.height), 0);
		}
	}

	// CHAMA A TELA DE LISTAGEM DE SERVIDORES ------
	// ---------------------------------------------
	public void callListLobs(){
		menuListLobs.transform.position = new Vector3((Screen.width / 2), (Screen.height / 2), 0);
		menuServer.transform.position = new Vector3((Screen.width*2), (Screen.height), 0);
		menuCloud.transform.position = new Vector3((Screen.width*2), (Screen.height), 0);

		scriptController.stats ();
	}


	// CHAMA A TELA INICIAL ------------------------
	// ---------------------------------------------
	public void backToStart(){
		menuInitial.transform.position = new Vector3((Screen.width / 2), (Screen.height / 2), 0);
		print (menuInitial.transform.position);

		menuListLobs.transform.position = new Vector3((Screen.width*2), (Screen.height), 0);
		menuServer.transform.position = new Vector3((Screen.width*2), (Screen.height), 0);
		menuCloud.transform.position = new Vector3((Screen.width*2), (Screen.height), 0);
	}


	// NOME DE JOGADOR NÃO INSERIDO ----------------
	// ---------------------------------------------
	private void emptyName(){
		errorName.GetComponent<Text> ().color = new Color (255, 255, 0, 1);		
	}

	// ESCONDE AVIDO DE NOME VAZIO -----------------
	public void hideInsertName(){
		errorName.GetComponent<Text> ().color = new Color (255, 255, 0, 0);
	}
	// ---------------------------------------------
}