using UnityEngine;
using System.Collections;

public class RandomEnemy : MonoBehaviour {
		
	public GameObject[] animacoesGameObject;
	private int typeEnemy;

	// Use this for initialization
	void Start () {
		typeEnemy = Random.Range (0,4);
		if (typeEnemy != 0) {Destroy(animacoesGameObject[0]);}
		if (typeEnemy != 1) {Destroy(animacoesGameObject[1]);}
		if (typeEnemy != 2) {Destroy(animacoesGameObject[2]);}
		if (typeEnemy != 3) {Destroy(animacoesGameObject[3]);}
		animacoesGameObject[typeEnemy].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
