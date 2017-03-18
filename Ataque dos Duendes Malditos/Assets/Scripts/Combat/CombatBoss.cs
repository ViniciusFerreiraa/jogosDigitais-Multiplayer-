using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatBoss : MonoBehaviour {
    public Skills skills;
    public Animator anim;
    public Player player;
    public StartCombat startCombat;
    public Light selectedLight;
    public GameObject containerSkills, containerPlayer;
    public GameObject BkgVida;
    public GameObject spellBall;
    public bool dead;
    public int attack, type;
    public float life, maxLife;
    private bool stuned;
    public Text txtDamage;
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
    void Update()
    {
        if (life <= 0)
        {
            Invoke("Death", 1.5f);
            dead = true;
        }

        if (skills != null)
        {
            if (skills.hammerTime)
            {
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
        if (!skills.hammerTime)
        {
            selectedLight.enabled = false;
        }
    }

    public void Attack()
    {
        startCombat.enemyCounter++;
        if (!dead && !stuned)
        {
            anim.SetTrigger("attack");
            GameObject particleEffect = Instantiate(spellBall, new Vector3(this.transform.position.x + 0.5f, this.transform.position.y + 0.3f, this.transform.position.z), Quaternion.Euler(0, 0, 0)) as GameObject;
            //player.anim.SetTrigger("damage");
            player.life -= attack;
            player.itensRefresh();
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
        anim.SetBool("stuned", false);
        stuned = false;
    }

    void Death()
    {
        anim.SetTrigger("death");
        startCombat.DeathVerify();
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
    }

    public void Stun()
    {
        stuned = true;
        anim.SetBool("stuned", true);
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        txtDamage.text = damage.ToString();
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
