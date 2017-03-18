using UnityEngine;
using System.Collections;

public class ModifyLifeHouses : MonoBehaviour {

	public HousesLife ScriptHousesLife;
	public float life;

	private bool fire;

	public GameObject particleFogo;
	public GameObject casaDestruida;

	// Use this for initialization
	void Start () {
		life = 100;
		fire = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ModifyLife(){
		ScriptHousesLife.life = life;
		if(!fire && life < 30){
			fire = true;
			particleFogo.SetActive(true);
		}
		if(life <= 0){
			casaDestruida.SetActive(true);
			Destroy(this.gameObject);
		}
	}
}
