using UnityEngine;
using System.Collections;

public class ColliderPontosAtaque : MonoBehaviour {
	
	public EnemyAtack ScriptEnemyAtack;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "PontoAtaque") {
			ScriptEnemyAtack.InvokeInvokeRepeating();
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "PontoAtaque") {
			ScriptEnemyAtack.CancelInvoke();
		}
	}
}
