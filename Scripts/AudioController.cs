using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	public bool ligado;
	public GameObject MainCamera;

	// Use this for initialization
	void Awake()
	{
	    DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		MainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		if(ligado){
			MainCamera.GetComponent<AudioListener>().enabled = true;
		}
		else{
			MainCamera.GetComponent<AudioListener>().enabled = false;
		}
	}
}
