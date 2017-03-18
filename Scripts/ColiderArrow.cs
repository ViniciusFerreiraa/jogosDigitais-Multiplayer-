using UnityEngine;
using System.Collections;

public class ColiderArrow : MonoBehaviour {

	public MoveController scriptMoveController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Arrow"){
			scriptMoveController.DestroyArrows();
			scriptMoveController.PlayerStop();
		}
	}
}
