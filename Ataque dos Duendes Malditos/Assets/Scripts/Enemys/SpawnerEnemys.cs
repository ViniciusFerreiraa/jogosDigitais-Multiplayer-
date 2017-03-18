using UnityEngine;
using System.Collections;

public class SpawnerEnemys : MonoBehaviour {

	public GameObject Duende, HousesLife, CameraVilage;
	private GameObject DuendesAtack;
	private GameObject[] CasasViking, EnemysAtack;

	// Use this for initialization
	void Start () {
		//InvokeSpwanEnemys ();
	}
	
	// Update is called once per frame
	void Update () {
		CasasViking = GameObject.FindGameObjectsWithTag ("CasasVikings");
		if (CasasViking.Length == 0) {
			Destroy(this.gameObject);
		}

		EnemysAtack = GameObject.FindGameObjectsWithTag ("EnemyAtack");
		if(EnemysAtack.Length == 0){
			DesactiveLifeHouses();
		}
	}

	public void InvokeSpwanEnemys(){
		InvokeRepeating ("SpawEnemys", 0, 100);
		HousesLife.SetActive (true);
		CameraVilage.SetActive (true);
		Invoke ("DesactiveCamera", 8);
	}

	public void AtiveCamera(){
		CameraVilage.SetActive (true);
		Invoke ("DesactiveCamera", 8);
	}

	void DesactiveCamera(){
		CameraVilage.SetActive (false);
	}

	public void DesactiveLifeHouses(){
		HousesLife.SetActive (false);
	}

	void SpawEnemys(){
		CameraVilage.SetActive (true);
		Invoke ("DesactiveCamera", 8);
		for(int i=0; i<10;i++){
			DuendesAtack = Instantiate (Duende, transform.position, Quaternion.identity)as GameObject;
			DuendesAtack.SetActive(true);
		}
	}
}
