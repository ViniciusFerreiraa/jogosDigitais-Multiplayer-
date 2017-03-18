using UnityEngine;
using System.Collections;

public class EnemyPoints : MonoBehaviour
{
	public Enemy scriptEnemy;

	void Start () {
	}
	
	void Update () {
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "EnemyPonit1") {
			scriptEnemy.anim.SetBool("iddle", true);
			scriptEnemy.ponto_central = true;
			scriptEnemy.oldPoint = 1;
			scriptEnemy.SendMessage("InvokePatrol");
		}
		if (other.tag == "EnemyPonit2") {
			scriptEnemy.anim.SetBool("iddle", true);
			scriptEnemy.ponto_central = true;
			scriptEnemy.oldPoint = 2;
			scriptEnemy.SendMessage("InvokePatrol");
		}
		if (other.tag == "EnemyPonitCentro") {
			scriptEnemy.anim.SetBool("iddle", true);
			
			if(scriptEnemy.oldPoint == 1){
				scriptEnemy.ponto_2 = true;
			}
			if(scriptEnemy.oldPoint == 2){
				scriptEnemy.ponto_1 = true;
			}
			scriptEnemy.oldPoint = 0;
			scriptEnemy.SendMessage("InvokePatrol");
		}
	}
}
