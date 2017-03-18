using UnityEngine;
using System.Collections;

public class NPCsAnim : MonoBehaviour {

	public Animator anim;
	public GameObject player;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("PosX", (player.transform.position.x - transform.position.x));
		anim.SetFloat("PosY", (player.transform.position.z - transform.position.z));
	}
}
