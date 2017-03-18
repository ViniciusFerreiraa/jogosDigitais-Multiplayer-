using UnityEngine;
using System.Collections;

public class EscolhaDeFinal : MonoBehaviour {

	public GameObject cut1, cut2, cut3;
	public AudioClip musicDuendes;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AtivaCut1(){
		GetComponent<AudioSource>().clip = musicDuendes;
		GetComponent<AudioSource>().Play();
		cut1.SetActive (true);
		Invoke ("GoToMenu", 16);
		Cursor.visible = false; 
	}

	public void AtivaCut2(){
		GetComponent<AudioSource>().clip = musicDuendes;
		GetComponent<AudioSource>().Play();
		cut2.SetActive (true);
		Invoke ("GoToMenu", 14);
		Cursor.visible = false; 
	}

	public void AtivaCut3(){
		GetComponent<AudioSource>().clip = musicDuendes;
		GetComponent<AudioSource>().Play();
		cut3.SetActive (true);
		Invoke ("GoToMenu", 14);
		Cursor.visible = false; 
	}

	void GoToMenu(){
		Cursor.visible = true; 
		Application.LoadLevel ("Menu inicial");
	}
}
