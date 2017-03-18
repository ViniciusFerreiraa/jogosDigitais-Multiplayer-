using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public Animator anim;
    public Inventario inventario;
    public int maxPoints = 4;
    public int actionPoints, def, potionsHP, potionsMP;
    public float life, magic;
    public Text lifeTxt, magicTxt, txtHP, txtMP, actionTxt, hudHP, hudMP;
    public GameObject playerBow, playerHammer;
    public GameObject BkgMana, BkgVida;
    public GameObject HammerWp, HammerSks, BowWp, BowSks;
    public GameObject gameOver;
    public Button btPw1H, btPw2H, btPw1B, btPw2B;
	void Start () {
	}

    void AbleSkills()
    {
        if (inventario.poder_1_Ok)
        {
            btPw2H.interactable = true;
            btPw2B.interactable = true;
        }
        else
        {
            btPw2H.interactable = false;
            btPw2B.interactable = false;
        }
        if (inventario.poder_2_Ok)
        {
            btPw1H.interactable = true;
            btPw1B.interactable = true;
        }
        else
        {
            btPw1H.interactable = false;
            btPw1B.interactable = false;
        }

        if (inventario.arma == 1)
        {
            playerBow.SetActive(true);
            playerHammer.SetActive(false);
            anim = playerBow.GetComponent<Animator>();
            BowSks.SetActive(true);
            BowWp.SetActive(true);
            HammerWp.SetActive(false);
            HammerSks.SetActive(false);
        }
        else if (inventario.arma == 2)
        {
            playerBow.SetActive(false);
            playerHammer.SetActive(true);
            anim = playerHammer.GetComponent<Animator>();
            HammerWp.SetActive(true);
            HammerSks.SetActive(true);
            BowWp.SetActive(false);
            BowSks.SetActive(false);
        }
        else
        {
            HammerWp.SetActive(false);
            HammerSks.SetActive(false);
            BowWp.SetActive(false);
            BowSks.SetActive(false);
        }
    }

    public void GameOver(){
        gameOver.SetActive(true);
    }

    public void StartPlayer()
    {
        maxPoints = 2;
        actionPoints = maxPoints;
        life = inventario.vida;
        magic = inventario.mana;
        potionsHP = inventario.pocoesVida;
        potionsMP = inventario.pocoesMana;
        itensRefresh();
        pointsRefresh();
        AbleSkills();
    }

    public void itensRefresh()
    {
        BkgMana.GetComponent<Image>().fillAmount = magic / 100;
        BkgVida.GetComponent<Image>().fillAmount = life / 100;
        txtMP.text = "x " + potionsMP;
        txtHP.text = "x " + potionsHP;
        hudMP.text = potionsMP.ToString();
        hudHP.text = potionsHP.ToString();
        lifeTxt.text = life.ToString();
        magicTxt.text = magic.ToString();
        actionTxt.text = actionPoints.ToString();
        SendStatus();
    }

    public void TakeDamage(int attack){
        if (attack > def)
        {            
            life -= (attack - def);
        }
        if (life > 0)
        {
            Invoke("Damage", 2f);
        }
        else {
            Invoke("DeathVerify",2f);
        }
        itensRefresh();
    }

    void Damage() {
        if (inventario.arma == 1)
        {
            anim.SetTrigger("damageBow");
        }
        else
        {
            anim.SetTrigger("damageHammer");
        }
    }

    public void DeathVerify()
    {
        if (life <= 0) 
        {
            if (inventario.arma == 1)
            {
                anim.SetTrigger("deathBow");
            }
            else
            {
                anim.SetTrigger("deathHammer");
            }
            Invoke("GameOver", 2.5f);
        }
    }

    public void SendStatus()
    {
        inventario.vida = life;
        inventario.mana = magic;
        inventario.pocoesVida = potionsHP;
        inventario.pocoesMana = potionsMP;
    }

    public void pointsRefresh()
    {
        actionTxt.text = actionPoints.ToString();
    }
}
