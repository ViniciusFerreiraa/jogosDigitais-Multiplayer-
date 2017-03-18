using UnityEngine;
using System.Collections;

public class Skills : MonoBehaviour {
    public Player player;
    public StartCombat startCombat;
    public AttackMenu attackMenu;
    public GameObject HUD, enemy;
    public CombatEnemy combatEnemy;
    public CombatBoss combatBoss;
    public Camera CombatCamera, LoopCamera;
    public GameObject[] contDescriptions;
    public GameObject arrow, iceSkill, HammerSkill, StunSkill;
    public CombatEnemy tempEnemy;

    public AudioSource audio;
    public AudioClip adHT, adTd, adHA, adFN, adFS, adFG;

    public bool hammerTime, thunderstruck, hammerAttack;
    public bool iceArrow, stunArrow, normalArrow;
    public bool selectEnemy;
    public bool defMode, atkMode;

    private bool commonEnemy;

    public float selectTime;

    private CombatBoss tempBoss;
    public GameObject thunderPt;
    
    private int coldown;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        EnemySelect();
        if (Input.GetKeyDown("space"))
        {
            player.life += 1000;
            player.actionPoints += 1000;
            player.magic += 1000;
        }

		if (player.life > 100)
		{
			player.life = 100;
			player.itensRefresh();
		}
		if (player.magic > 100)
		{
			player.magic = 100;
			player.itensRefresh();
		}
    }

    public void UseHP()
    {
        if (player.actionPoints >= 2 && player.potionsHP > 0 && player.life < 100)
        {
				Debug.Log("2");
            //AttackMode();
            defMode = true;
            player.life += 50;
			if (player.life > 100)
			{
				player.life = 100;
			}
			player.actionPoints -= 1;
            player.potionsHP--;
            player.pointsRefresh();
			player.itensRefresh();
        }
    }
    public void UseMP()
    {
        if (player.actionPoints >= 2 && player.potionsMP > 0 && player.magic < 100)
        {
            defMode = true;
            player.magic += 50;
			if (player.magic > 100)
			{
				player.magic = 100;
			}
			player.actionPoints -= 1;
            player.potionsMP--;
            player.pointsRefresh();
            player.itensRefresh();
        }
    }

    public void Scream()
    {
        if (player.actionPoints >= 2)
        {
            //AttackMode();
            defMode = true;
            player.def += 20;
            player.actionPoints -= 2;
            player.pointsRefresh();
        }
    }

    public void SelectActions()
    {
        CombatCamera.enabled = false;
        LoopCamera.gameObject.SetActive(true);
        HUD.SetActive(true);
    }

    void newArrow()
    {
        GameObject tempArrow = Instantiate(arrow, new Vector3(player.transform.position.x + .31f, player.transform.position.y + .65f, player.transform.position.z), Quaternion.Euler(180, 30, 0)) as GameObject;
    }
    // HAMMER
    #region Ataques de machado
    public void HammerTime()
    {
        if (player.actionPoints >= 3)
        {
            audio.clip = adHT;
            player.anim.SetBool("hammer", true);
            hammerTime = true;
            player.actionPoints -= 3;
            consumeMP(40);
            player.pointsRefresh();
            AttackMode();
        }
    }
    public void Thunderstruck()
    {
        if (player.actionPoints >= 4)
        {
            audio.clip = adTd;
            player.anim.SetBool("hammer", true);
            thunderstruck = true;
            player.actionPoints -= 4;
            consumeMP(60);
            player.pointsRefresh();
            AttackMode();
        }
    }
    public void HammerAttack()
    {
        if (player.actionPoints >= 2)
        {
            audio.clip = adHA;
            player.anim.SetBool("hammer", true);
            hammerAttack = true;
            player.actionPoints -= 2;
            player.pointsRefresh();
            AttackMode();
        }
    }
    #endregion
    // BOW
    #region Ataques de besta

    void IceEffectSkill()
    {
        GameObject particleEffect = Instantiate(iceSkill, new Vector3(tempEnemy.transform.position.x + .5f, tempEnemy.transform.position.y + .5f, tempEnemy.transform.position.z), Quaternion.Euler(270, 0, 0)) as GameObject;
    }

    void StunEffectSkill()
    {
        GameObject particleEffect = Instantiate(StunSkill, new Vector3(StunSkill.transform.position.x, tempEnemy.transform.position.y + .5f, tempEnemy.transform.position.z), Quaternion.Euler(270, 0, 0)) as GameObject;
    }

    void ThunderEffect()
    {
        GameObject particleEffect = Instantiate(thunderPt, new Vector3(tempEnemy.transform.position.x + 0.7f, tempEnemy.transform.position.y + 0.4f, tempEnemy.transform.position.z), Quaternion.Euler(270, 0, 0)) as GameObject;
    }

    void HammerEffect()
    {
        GameObject particleEffect = Instantiate(HammerSkill, new Vector3(tempEnemy.transform.position.x + 0.7f, tempEnemy.transform.position.y + 0.3f, tempEnemy.transform.position.z), Quaternion.Euler(270, 0, 0)) as GameObject;
    }
    public void IceArrow()
    {
        if (player.actionPoints >= 3)
        {
            audio.clip = adFG;
            player.anim.SetBool("bow", true);
            iceArrow = true;
            player.actionPoints -= 3;
            consumeMP(20);
            player.pointsRefresh();
            AttackMode();
        }
    }
    public void StunArrow()
    {
        if (player.actionPoints >= 2 && coldown <= 0)
        {
            audio.clip = adFS;
            player.anim.SetBool("bow", true);
            stunArrow = true;
            player.actionPoints -= 2;
            coldown = 2;
            consumeMP(20);
            player.pointsRefresh();
            AttackMode();
        }
    }
    public void NormalArrow()
    {
        if (player.actionPoints >= 2)
        {
            audio.clip = adFN;
            player.anim.SetBool("bow", true);
            normalArrow = true;
            player.actionPoints -= 2;
            player.pointsRefresh();
            AttackMode();
        }
    }
    #endregion
    void consumeMP(int qnt)
    {
        player.magic -= qnt;
        if (player.magic < 0)
        {
            player.magic = 0;
        }
        player.itensRefresh();
    }

    public void EnemySelect()
    {
        if (selectEnemy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    if (hit.transform.gameObject.tag == "EnemyCombat")
                    {
                        enemy = hit.transform.gameObject;
                        Attack();
                    }
                }
            }
        }
    }

    void Attack()
    {
        selectEnemy = false;
        atkMode = true;
        tempEnemy = enemy.GetComponent<CombatEnemy>();
        if (tempEnemy == null)
        {
            commonEnemy = false;
            tempBoss = enemy.GetComponent<CombatBoss>();
        }
        #region Hammer
        if (hammerTime)
        {
            player.anim.SetTrigger("hammerAttack");
            hammerTime = false;
            Invoke("HammerEffect", 1.2f);            
            Invoke("SelectActions", selectTime);
            for (int i = 0; i < startCombat.Enemys.Length; i++)
            {
                tempEnemy = startCombat.Enemys[i].GetComponent<CombatEnemy>();    
                #region Damages
                if (tempEnemy.type == 1)
                    tempEnemy.TakeDamage(90);
                if (tempEnemy.type == 2)
                    tempEnemy.TakeDamage(60);
                if (tempEnemy.type == 3)
                    tempEnemy.TakeDamage(30);
                if (tempEnemy.type == 4)
                    tempEnemy.TakeDamage(60);
                if (tempEnemy.type == 5)
                    tempEnemy.TakeDamage(40);
                #endregion                            
            }
        }
        if (thunderstruck)
        {
            player.anim.SetTrigger("thunderstruck");
            thunderstruck = false;
            Invoke("SelectActions", selectTime);
            Invoke("ThunderEffect", 2f);
            #region Damages
            if (tempEnemy.type == 1)
                tempEnemy.TakeDamage(100);
            if (tempEnemy.type == 2)
                tempEnemy.TakeDamage(150);
            if (tempEnemy.type == 3)
                tempEnemy.TakeDamage(20);
            if (tempEnemy.type == 4)
                tempEnemy.TakeDamage(100);
            if (tempEnemy.type == 5)
                tempEnemy.TakeDamage(100);
            #endregion
        }
        if (hammerAttack)
        {
            player.anim.SetTrigger("hammerAttack");
            hammerAttack = false;
            Invoke("SelectActions", selectTime);
            tempEnemy.TakeDamage(20);
            if (Random.Range(-1F, 1F) > 0)
            {                
                for (int i = 0; i < startCombat.Enemys.Length; i++)
                {
                    tempEnemy = startCombat.Enemys[i].GetComponent<CombatEnemy>();    
                    tempEnemy.TakeDamage(20);                            
                }
            }
            else
            {
                tempEnemy.TakeDamage(20);
            }
        }
        #endregion
        #region Bow

        if (iceArrow)
        {
            player.anim.SetTrigger("bowAttack");
            iceArrow = false;
            Invoke("SelectActions", selectTime);
            Invoke("newArrow", 1.9f);
            Invoke("IceEffectSkill", 3f);
            #region Damages            
            if (Random.Range(-1F, 1F) > 0)
            {
                if (tempEnemy.type == 1)
                    tempEnemy.TakeDamage(100);
                if (tempEnemy.type == 2)
                    tempEnemy.TakeDamage(60);
                if (tempEnemy.type == 3)
                    tempEnemy.TakeDamage(20);
                if (tempEnemy.type == 4)
                    tempEnemy.TakeDamage(60);
                if (tempEnemy.type == 5)
                    tempEnemy.TakeDamage(60);
            }
            else
            {
                if (tempEnemy.type == 1)
                    tempEnemy.TakeDamage(200);
                if (tempEnemy.type == 2)
                    tempEnemy.TakeDamage(120);
                if (tempEnemy.type == 3)
                    tempEnemy.TakeDamage(40);
                if (tempEnemy.type == 4)
                    tempEnemy.TakeDamage(120);
                if (tempEnemy.type == 5)
                    tempEnemy.TakeDamage(100);
            }
            #endregion    
        }
        if (stunArrow)
        {
            Invoke("StunEffectSkill", 2.2f);
            player.anim.SetTrigger("bowAttack");
            stunArrow = false;
            Invoke("newArrow", 1.5f);
            Invoke("SelectActions", selectTime);
            enemy.GetComponent<CombatEnemy>().Stun();
            
        }
        if (normalArrow)
        {
            player.anim.SetTrigger("bowAttack");
            normalArrow = false;
            Invoke("newArrow", 1.5f);
            Invoke("SelectActions", selectTime);
            #region Damages
            if (Random.Range(-1F, 1F) > 0)
            {
                if (tempEnemy.type == 1)
                    tempEnemy.TakeDamage(40);
                if (tempEnemy.type == 2)
                    tempEnemy.TakeDamage(40);
                if (tempEnemy.type == 3)
                    tempEnemy.TakeDamage(40);
                if (tempEnemy.type == 4)
                    tempEnemy.TakeDamage(40);
                if (tempEnemy.type == 5)
                    tempEnemy.TakeDamage(40);
            }
            else
            {
                if (tempEnemy.type == 1)
                    tempEnemy.TakeDamage(80);
                if (tempEnemy.type == 2)
                    tempEnemy.TakeDamage(80);
                if (tempEnemy.type == 3)
                    tempEnemy.TakeDamage(80);
                if (tempEnemy.type == 4)
                    tempEnemy.TakeDamage(80);
                if (tempEnemy.type == 5)
                    tempEnemy.TakeDamage(80);
            }
            #endregion    
        }
        #endregion
        Invoke("PlayEffect", 1f);
    }

    void PlayEffect()
    {
        audio.Play();
    }

    void AttackMode()
    {
        CloseAll();
        selectEnemy = true;
        enemy = null;
        CombatCamera.enabled = true;
        LoopCamera.gameObject.SetActive(false);
        HUD.SetActive(false);
    }

    public void endTurn()
    {
        atkMode = false;
        defMode = false;
        CombatCamera.enabled = true;
        LoopCamera.gameObject.SetActive(false);
        HUD.SetActive(false);
        coldown--;
        startCombat.DeathVerify();
        startCombat.Enemys[0].GetComponent<CombatEnemy>().Attack();
    }
    public void CloseAll()
    {
        contDescriptions = GameObject.FindGameObjectsWithTag("Description");
        for (int i = 0; i < contDescriptions.Length; i++)
        {
            contDescriptions[i].gameObject.SetActive(false);
        }
    }
	
}
