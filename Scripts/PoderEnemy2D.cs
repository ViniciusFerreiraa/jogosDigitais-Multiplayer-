using UnityEngine;
using System.Collections;

public class PoderEnemy2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "CasasVikings"){
			GameObject CasaTemporaria = other.gameObject;
			CasaTemporaria.GetComponent<ModifyLifeHouses>().life -= 2;
			CasaTemporaria.GetComponent<ModifyLifeHouses>().ModifyLife();
			Destroy(this.gameObject);
		}
	}
}
