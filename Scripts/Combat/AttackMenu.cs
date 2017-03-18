using UnityEngine;
using System.Collections;

public class AttackMenu : MonoBehaviour{
    public Skills skills;
    public GameObject HammerTime, Thunderstruck, Martelada, HammerBlt;
    public GameObject Disparo, FlechaCg, FlechaTt, BowBlt;
    public GameObject HP, MP, Scream;
    private int effectCounter1, effectCounter2, effectCounter3;
    private bool hammer, bow, defense;
	// Use this for initialization
    void Start()
    {
        // HAMMER
        HammerTime.gameObject.SetActive(hammer);
        Thunderstruck.gameObject.SetActive(hammer);
        Martelada.gameObject.SetActive(hammer);
        HammerBlt.gameObject.SetActive(hammer);
        // BOW
        Disparo.gameObject.SetActive(bow);
        FlechaCg.gameObject.SetActive(bow);
        FlechaTt.gameObject.SetActive(bow);
        BowBlt.gameObject.SetActive(bow);
        // DEFENSE
        HP.gameObject.SetActive(defense);
        MP.gameObject.SetActive(defense);
        Scream.gameObject.SetActive(defense);
	}
	
    public void ActiveDefense()
    {
        if (!skills.atkMode)
        {
            defense = !defense;
            hammer = false;
            bow = false;
            OpenDefenseMenu();
            OpenHammerMenu();
            OpenBowMenu();            
        }
    }

    public void ActiveHammer()
    {
        if (!skills.defMode)
        {
            hammer = !hammer;
            defense = false;
            bow = false;
            OpenHammerMenu();
            OpenBowMenu();
            OpenDefenseMenu();
        }
    }

    public void ActiveBow()
    {
        if (!skills.defMode)
        {
            bow = !bow;
            hammer = false;
            defense = false;
            OpenBowMenu();
            OpenHammerMenu();
            OpenDefenseMenu();
        }
    }

    void OpenDefenseMenu()
    {
        effectCounter1++;
        if (effectCounter1 == 1)
        {
            HP.gameObject.SetActive(defense);
        }
        if (effectCounter1 == 2)
        {
            MP.gameObject.SetActive(defense);
        }
        if (effectCounter1 == 3)
        {
            Scream.gameObject.SetActive(defense);
        }
        if (effectCounter1 < 3)
        {
            Invoke("OpenDefenseMenu", .1f);
        }
        else
        {
            effectCounter1 = 0;
        }
    }

    void OpenBowMenu()
    {
        effectCounter2++;
        if (effectCounter2 == 1)
        {
            FlechaTt.gameObject.SetActive(bow);
        }
        if (effectCounter2 == 2)
        {
            FlechaCg.gameObject.SetActive(bow);
        }
        if (effectCounter2 == 3)
        {
            Disparo.gameObject.SetActive(bow);
        }
        if (effectCounter2 == 4)
        {
            BowBlt.gameObject.SetActive(bow);
        }
        if (effectCounter2 < 4)
        {
            Invoke("OpenBowMenu", .1f);
        }
        else
        {
            effectCounter2 = 0;
        }
    }

    void OpenHammerMenu()
    {
        effectCounter3++;
        if (effectCounter3 == 1)
        {
            HammerTime.gameObject.SetActive(hammer);
        }
        if (effectCounter3 == 2)
        {
            Thunderstruck.gameObject.SetActive(hammer);
        }
        if (effectCounter3 == 3)
        {
            Martelada.gameObject.SetActive(hammer);
        }
        if (effectCounter3 == 4)
        {
            HammerBlt.gameObject.SetActive(hammer);
        }
        if (effectCounter3 < 4)
        {
            Invoke("OpenHammerMenu", .1f);
        }
        else
        {
            effectCounter3 = 0;
        }
    }


}
