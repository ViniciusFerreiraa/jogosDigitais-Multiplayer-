using UnityEngine;
using System.Collections;

public class DefineGroupEnemys : MonoBehaviour {

	public GameObject EnemysNormal, EnemysRaiva;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SubornouGuarda(){
		EnemysNormal.SetActive (true);
	}

	public void MatouGuarda(){
		EnemysRaiva.SetActive (true);
	}
}
