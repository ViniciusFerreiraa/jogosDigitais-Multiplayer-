using UnityEngine;
using System.Collections;

public class DetectEnemyAtack : MonoBehaviour {

	public GameObject containerGame;
	public GameController gameController;
	
	void Start()
	{
		containerGame = GameObject.FindGameObjectWithTag ("GameController");
		gameController = containerGame.GetComponent<GameController> ();
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "PlayerCharacter") {
			if (!gameController.pegouEnemys){
				gameController.pegouEnemys = true;
				gameController.GetEnemysAtack ();
			}
		}
	}
}
