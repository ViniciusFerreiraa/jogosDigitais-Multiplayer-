using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    public Enemy tempEnemy;
	public Guarda tempGuard;
	public EnemyAtack tempEnemyAtack;
	public Boss tempBoss;
    public Player player;
    public StartCombat startCombat;
    public GameObject[] Enemys, ClearEnemys;
    public List<int> type, life;
    public GameObject group2d, groupCombat;
    private int tempType, tempLife;
    public int persuers;
    public bool inCombat;
	private bool combateWitchEnemy;
	public bool DuelBoss;

	public GameObject TelaFinal;

	public SpawnerEnemys scriptSpaner;
	public Inventario scriptInventario;
	private float timer = 100;
	private bool invoke1 = false;
	private int contEnemy;
	public bool pegouEnemys = false;

    //void Awake()
    //{
    //    DontDestroyOnLoad(transform.gameObject);
    //}

	void Update(){
		if (!inCombat) {
			timer -= Time.deltaTime;
		}
		if (timer < 0) {
			timer = 100;
		}
	}

    public void GetEnemys()
    {
		contEnemy = 0;
		combateWitchEnemy = true;
        player.StartPlayer();
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject EnemyBody in Enemys)
		{
			if(contEnemy <= 3){
	            tempEnemy = EnemyBody.gameObject.GetComponent<Enemy>();
			    if (tempEnemy != null)
	            {
	                tempType = tempEnemy.type;
	            }
	            if (tempEnemy.playerInArea || tempEnemy.chasing)
	            {
					contEnemy++;
					Destroy(EnemyBody.gameObject);
	                type.Add(tempEnemy.type);
	                life.Add(tempEnemy.life);
				}
			}
        }
        Enemys = ClearEnemys;
        CombatMode();
    }

	public void GetEnemysAtack()
	{
		contEnemy = 0;
		combateWitchEnemy = false;
		player.StartPlayer();
		Enemys = GameObject.FindGameObjectsWithTag("EnemyAtacando");

		foreach (GameObject EnemyBody in Enemys)
		{
			if(contEnemy <= 3){
				tempEnemyAtack = EnemyBody.gameObject.GetComponent<EnemyAtack>();
				if (tempEnemyAtack != null)
				{
					tempType = tempEnemyAtack.type;
				}
				if (tempEnemyAtack.playerInArea || tempEnemyAtack.chasing)
				{
					contEnemy++;
					Destroy(EnemyBody.gameObject);
					type.Add(tempEnemyAtack.type);
					life.Add(tempEnemyAtack.life);

				}
			}
		}
		Enemys = ClearEnemys;
		CombatMode();
	}

	public void GetGuard()
	{
		combateWitchEnemy = false;
		player.StartPlayer();
		GameObject guardaContainer = GameObject.FindGameObjectWithTag("Guarda");
		tempGuard = guardaContainer.gameObject.GetComponent<Guarda>();
		type.Add(tempGuard.type);
		life.Add(tempGuard.life);
		CombatMode();
	}

    public void GetBoss()
    {
		DuelBoss = true;
		combateWitchEnemy = false;
        player.StartPlayer();
        GameObject bossContainer = GameObject.FindGameObjectWithTag("Boss");
        tempBoss = bossContainer.gameObject.GetComponent<Boss>();
        type.Add(tempBoss.type);
        life.Add(tempBoss.life);
        CombatMode();
    }

    void SearchEnemys()
    {
		if (combateWitchEnemy) {
			Enemys = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject EnemyBody in Enemys) {
				EnemyBody.gameObject.GetComponent<Enemy> ().startFunctions ();
			}
		}
		if(DuelBoss){
			TelaFinal.SetActive(true);
			group2d.SetActive(false);
		}
    }

    public void AbleCombat1()
    {
		scriptSpaner.CancelInvoke ();
        group2d.SetActive(false);
        groupCombat.SetActive(true);
    }

    public void Able2d()
    {
		if (scriptInventario.MatouGuarda) {
			if (!invoke1) {
				invoke1 = true;
				scriptSpaner.InvokeSpwanEnemys ();
			} else {
				scriptSpaner.Invoke ("InvokeSpwanEnemys", timer);
			}
		}
		pegouEnemys = false;
		group2d.SetActive(true);
        groupCombat.SetActive(false);
        inCombat = false;
        type.Clear();
        life.Clear();
        Invoke("SearchEnemys", 1);
    }
    
    public void CombatMode()
    {
        inCombat = true;
        AbleCombat1();
        startCombat.SpawnEnemys();
    }
}
