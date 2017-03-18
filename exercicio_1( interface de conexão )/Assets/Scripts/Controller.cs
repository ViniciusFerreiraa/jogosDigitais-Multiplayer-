using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public string userName;

	public GameObject connectOnServer;
	public GameObject connectCloud;
	public GameObject listLobs;

	private Vector2 centerCanvas;

	// Use this for initialization
	void Start () {
		centerCanvas = new Vector2((Screen.width / 2), (Screen.height / 2));
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void callConnectOnServer(){
		RectTransform rectSize = (RectTransform)connectOnServer.transform;
		Debug.Log (rectSize.rect.width / 2);
		Debug.Log (rectSize.rect.height / 2);

		connectOnServer.transform.position.x = centerCanvas.x;
		connectOnServer.transform.position.y = centerCanvas.y;
	}

	public void callConnectCloud(){
	}

	public void callListLobs(){
	}
}
