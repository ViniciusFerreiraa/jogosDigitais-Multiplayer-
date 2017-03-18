using UnityEngine;
using System.Collections;

public class Audios : MonoBehaviour {

    public AudioClip musicDuendes;
    public AudioClip musicViking;
	// Use this for initialization
	void Start () {
	}

    public void audioDuende()
    {
        GetComponent<AudioSource>().clip = musicDuendes;
        GetComponent<AudioSource>().Play();
    }

    public void audioViking()
    {
        GetComponent<AudioSource>().clip = musicViking;
        GetComponent<AudioSource>().Play();
    }
}
