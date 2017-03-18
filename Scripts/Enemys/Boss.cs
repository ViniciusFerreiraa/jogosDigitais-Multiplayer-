using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public GameObject containerGame;
    public GameController gameController;
    public int life, type;
	// Use this for initialization
    void Start()
    {
        containerGame = GameObject.FindGameObjectWithTag("GameController");
        gameController = containerGame.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PlayerCharacter")
        {
            gameController.GetBoss();
            Destroy(this.gameObject);
        }
    }
}
