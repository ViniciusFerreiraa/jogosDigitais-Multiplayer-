using UnityEngine;
using System.Collections;

public class CombatController : MonoBehaviour {
    public Canvas ChooseMode, AttackMode, ProtectMode;
	
    void Start () {
        AttackMode.enabled = false;
        ProtectMode.enabled = false;
        ChooseMode.enabled = true;
	}

    public void EnterAttack()
    {
        AttackMode.enabled = true;
        ProtectMode.enabled = false;
        ChooseMode.enabled = false;
    }
    
    public void EnterProtect()
    {
        AttackMode.enabled = false;
        ProtectMode.enabled = true;
        ChooseMode.enabled = false;
    }

    public void EnterChoose()
    {
        AttackMode.enabled = false;
        ProtectMode.enabled = false;
        ChooseMode.enabled = true;
    }
}
