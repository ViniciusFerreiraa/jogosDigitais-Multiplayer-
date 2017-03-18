using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartCombat : MonoBehaviour {
    public GameController gameController;
    public GameObject controller;
    public GameObject[] SpawnPoints;
    public GameObject[] Enemys;
    public GameObject WinScreen;
    public Player player;
    public AudioSource audio;
    public Inventario inventario;
    public Text red, blue, purple, green, totalGold;
    public Text goldR, goldB, goldP, goldG;
    public GameObject Scene1, Scene2, Scene3;
    private int countR, countB, countP, countG;
    public int enemyCounter;
    private int deadCount;

	public SpawnerEnemys scriptSpaw;
	public Audios scriptAudios;
	public Inventario scriptInventario;

    public GameObject earthGnome, iceGnome, physicalGnome, fireGnome, boss;
	// Use this for initialization
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        gameController = controller.GetComponent<GameController>();
	}

    public void SpawnEnemys()
    {
		if (gameController.life.Count > 4) {
			for (int i = 0; i < gameController.type.Count; i++)
			{
				if(i > 2){
					gameController.life.RemoveAt(i);
					gameController.type.RemoveAt(i);
				}
			}
		}
        audio.Play();
        player.StartPlayer();
        countR = 0;
        countB = 0;
        countP = 0;
        countG = 0;
        if (inventario.level == 1)
        {
            Scene1.SetActive(true);
        }
        else if (inventario.level == 2)
        {
            Scene2.SetActive(true);
        }
        else
        {
            Scene3.SetActive(true);
        }
        for (int i = 0; i < gameController.type.Count; i++)
        {
            if (gameController.type[i] == 1)
            {
                GameObject newGnome = Instantiate(fireGnome, new Vector3(SpawnPoints[i].transform.position.x, SpawnPoints[i].transform.position.y, SpawnPoints[i].transform.position.z), Quaternion.Euler(0, 6f, 0)) as GameObject;
                newGnome.GetComponent<CombatEnemy>().life = gameController.life[i];
                countR++;
            }
            if (gameController.type[i] == 2)
            {
                GameObject newGnome = Instantiate(iceGnome, new Vector3(SpawnPoints[i].transform.position.x, SpawnPoints[i].transform.position.y, SpawnPoints[i].transform.position.z), Quaternion.Euler(0, 6f, 0)) as GameObject;
                newGnome.GetComponent<CombatEnemy>().life = gameController.life[i];
                countB++;
            }
            if (gameController.type[i] == 3)
            {
                GameObject newGnome = Instantiate(earthGnome, new Vector3(SpawnPoints[i].transform.position.x, SpawnPoints[i].transform.position.y, SpawnPoints[i].transform.position.z), Quaternion.Euler(0, 6f, 0)) as GameObject;
                newGnome.GetComponent<CombatEnemy>().life = gameController.life[i];
                countP++;
            }
            if (gameController.type[i] == 4)
            {
                GameObject newGnome = Instantiate(physicalGnome, new Vector3(SpawnPoints[i].transform.position.x, SpawnPoints[i].transform.position.y, SpawnPoints[i].transform.position.z), Quaternion.Euler(0, 6f, 0)) as GameObject;
                newGnome.GetComponent<CombatEnemy>().life = gameController.life[i];
                countG++;
            }
            if (gameController.type[i] == 5)
            {
                GameObject newGnome = Instantiate(boss, new Vector3(SpawnPoints[i].transform.position.x, SpawnPoints[i].transform.position.y, SpawnPoints[i].transform.position.z), Quaternion.Euler(0, 6f, 0)) as GameObject;
                newGnome.GetComponent<CombatEnemy>().life = gameController.life[i];
            }
        }

        Enemys = GameObject.FindGameObjectsWithTag("EnemyCombat");
    }

    public void DeathVerify()
    {
        deadCount = 0;
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Enemys[i].GetComponent<CombatEnemy>().dead)
            {
                deadCount++;
            }
        }
        if (deadCount == Enemys.Length && gameController.inCombat)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                Destroy(Enemys[i].gameObject);
            }
            Invoke("Result", 0);
        }
    }

    void Result()
    {
        red.text = countR.ToString();
        blue.text = countB.ToString();
        purple.text = countP.ToString();
        green.text = countG.ToString();
        int qntR = (countR * 20);
        int qntB = (countB * 20);
        int qntP = (countP * 15);
        int qntG = (countG * 10);
        int tempTotal = qntR + qntB + qntP + qntG;

        goldR.text = qntR.ToString();
        goldB.text = qntB.ToString();
        goldP.text = qntP.ToString();
        goldG.text = qntG.ToString();

        totalGold.text = tempTotal.ToString();
        inventario.gold += tempTotal;
        WinScreen.SetActive(true);
    }

	public void reset(){
		Application.LoadLevel ("Game");
	}

    public void Able2d()
    {
        WinScreen.SetActive(false);
        gameController.Able2d();
		if (scriptInventario.MatouGuarda) {
			scriptSpaw.AtiveCamera ();
		}
		if (scriptInventario.level == 1) {
			scriptAudios.audioViking();
		}
		if (scriptInventario.level == 2) {
			scriptAudios.audioDuende();
		}
    }
}
