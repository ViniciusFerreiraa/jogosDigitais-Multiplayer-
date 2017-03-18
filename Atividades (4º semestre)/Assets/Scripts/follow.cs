using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	private float speed = 5;

	public Transform target;
	void Update() {
		transform.position = target.position;
	}
}
