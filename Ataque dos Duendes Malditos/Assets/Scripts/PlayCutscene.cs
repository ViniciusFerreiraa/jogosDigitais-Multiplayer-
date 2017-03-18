using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayCutscene : MonoBehaviour {
    public MovieTexture Filme;

    // Use this for initialization
	void Start () {
        transform.GetComponent<RawImage>().texture = Filme;
        Filme.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}