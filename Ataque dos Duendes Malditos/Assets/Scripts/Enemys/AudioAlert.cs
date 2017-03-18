using UnityEngine;
using System.Collections;

public class AudioAlert : MonoBehaviour {
	
	public AudioClip somAlert;
	
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().clip = somAlert;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void DesactiveAudio(){
		GetComponent<AudioSource>().Stop();
	}
	
	public void audioAlert()
	{
		GetComponent<AudioSource>().Play();
		
		Invoke ("DesactiveAudio", 1);
	}
}
