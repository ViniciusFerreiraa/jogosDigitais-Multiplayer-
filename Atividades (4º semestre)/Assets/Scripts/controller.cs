using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    private float speed = 5;
	public Transform myPrefab;

    void Update()
	{
		var x = Input.GetAxis ("Horizontal") * speed;
		var z = Input.GetAxis ("Vertical") * speed;
		GetComponent<CharacterController> ().SimpleMove (new Vector3 (x, 0, z));

		if(Input.GetButtonDown("Fire1")){
			Transform newObj = Instantiate(myPrefab,transform.position, transform.rotation) as Transform;
		}
	}

	private int count = 0;
	void OnCollisionEnter(Collision collision){
		count++;
		Debug.Log ("Total de colisoes: " + count);
	}
}
