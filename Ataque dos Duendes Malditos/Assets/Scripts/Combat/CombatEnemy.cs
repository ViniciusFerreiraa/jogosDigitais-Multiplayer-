using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatEnemy : MonoBehaviour {
    public Skills skills;
    public Animator anim;
    public Player player;
    public StartCombat startCombat;
    public Light selectedLight;
    public GameObject containerSkills, containerPlayer;
    public GameObject BkgVida;
    public GameObject spellBall;
    public GameObject minion1, minion2;
    public GameObject born;
    public bool dead;
    public int attack, type, gold;
    public float life, maxLife;
    private bool stuned;
    public Text txtDamage;
    public bool boss;
    private bool summoned;
	// Use this for initialization
    void Start()
    {
        containerSkills = GameObject.FindGameObjectWithTag("CombatController");
        containerPlayer = GameObject.FindGameObjectWithTag("Player");
        skills = containerSkills.GetComponent<Skills>();
        startCombat = containerSkills.GetComponent<StartCombat>();
        player = containerPlayer.GetComponent<Player>();
        maxLife = life;
        BkgVida.GetComponent<Image>().fillAmount = life / maxLife;
	}
	
	// Update is called once per frame
	void Update () {
        if (skills != null)
        {            
		    if(skills.hammerTime){
			    selectedLight.enabled = true;
		    }
        }
	}
    void OnMouseEnter()
    {
        if (skills.selectEnemy && !dead)
        {
            selectedLight.enabled = true;
        }
    }
    void OnMouseExit()
    {
		if(!skills.hammerTime){
        	selectedLight.enabled = false;
		}
	}

    void Summon()
    {
        summoned = true;
        GameObject newGnome1 = Instantiate(startCombat.earthGnome, new Vector3(minion1.transform.position.x, minion1.transform.position.y, minion1.transform.position.z), Quaternion.Euler(0, 6f, 0)) as GameObject;
        newGnome1.GetComponent<CombatEnemy>().life = Random.Range(50, 110);

        GameObject newGnome2 = Instantiate(startCombat.physicalGnome, new Vector3(minion2.transform.position.x, minion2.transform.position.y, minion2.transform.position.z), Quaternion.Euler(0, 6f, 0)) as GameObject;
        newGnome2.GetComponent<CombatEnemy>().life = Random.Range(50, 110);

        startCombat.Enemys = GameObject.FindGameObjectsWithTag("EnemyCombat");
        if (startCombat.Enemys.Length > startCombat.enemyCounter)
        {
            Invoke("NextEnemy", 3);
        }
        else
        {
            Invoke("PlayerTurn", 4);
            startCombat.enemyCounter = 0;
        }
    }

    public void Attack()
    {
        startCombat.enemyCounter ++;
        if (boss)
        {
            if (Random.Range(-1F, 1F) > 0 && !summoned && !stuned)
            {
                GameObject newBorn2 = Instantiate(born, new Vector3(minion2.transform.position.x, minion2.transform.position.y, minion2.transform.position.z), Quaternion.Euler(0, 6f, 0)) as GameObject;
                GameObject newBorn1 = Instantiate(born, new Vector3(minion1.transform.position.x, minion1.transform.position.y, minion1.transform.position.z), Quaternion.Euler(0, 6f, 0)) as GameObject;
                anim.SetTrigger("spawn");
                Invoke("Summon", 1);
            }
            else
            {
                NormalAttack();
            }
        }
        else
        {
            NormalAttack();
        }
        if (stuned)
        {
            stuned = false;
            Invoke("DisableStun", 2f);
        }
    }

    void DisableStun()
    {
        anim.SetBool("stuned", false);
    }

    void NormalAttack()
    {
        if (!dead && !stuned)
        {
            anim.SetTrigger("attack");
            if (boss)
            {
                GameObject particleEffect = Instantiate(spellBall, new Vector3(this.transform.position.x - .8f, this.transform.position.y + .8f, this.transform.position.z), Quaternion.Euler(0, 0, 0)) as GameObject;
            }
            else
            {
                GameObject particleEffect = Instantiate(spellBall, new Vector3(this.transform.position.x + 0.5f, this.transform.position.y + 0.3f, this.transform.position.z), Quaternion.Euler(0, 0, 0)) as GameObject;
            }
                //player.anim.SetTrigger("damage");
            player.TakeDamage(attack);
        }
        if (startCombat.Enemys.Length > startCombat.enemyCounter)
        {
            Invoke("NextEnemy", 3);
        }
        else
        {
            Invoke("PlayerTurn", 4);
            startCombat.enemyCounter = 0;
        }
    }

    void Death()
    {
        anim.SetTrigger("death");
    }

    void verifyDeath()
    {
        startCombat.DeathVerify();
    }

    void CallDeath()
    {
        Invoke("Death", 3);
        Invoke("verifyDeath", 6);
    }


    void NextEnemy()
    {
        startCombat.Enemys[startCombat.enemyCounter].GetComponent<CombatEnemy>().Attack();
    }

    void PlayerTurn()
    {
        skills.SelectActions();
        player.maxPoints++;
        player.actionPoints = player.maxPoints;
        player.pointsRefresh();
        player.def = 0;
    }

    public void Stun()
    {
        stuned = true;
        Invoke("StunEffect", 2.2f);
    }

    void StunEffect()
    {
        anim.SetBool("stuned", true);
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        txtDamage.text = damage.ToString();
        Invoke("effectDamage", 2.5f);
        if (life <= 0)
        {
            CallDeath();
            dead = true;
        }
    }

    void effectDamage()
    {
        txtDamage.gameObject.SetActive(true);
        Invoke("DisableTxt", 1);
        anim.SetTrigger("damage");
        BkgVida.GetComponent<Image>().fillAmount = life / maxLife;
    }
    void DisableTxt()
    {
        txtDamage.gameObject.SetActive(false);
    }
}
