using UnityEngine;
using System.Collections;

public class EnemyAtack : MonoBehaviour {
	private NavMeshAgent agent;
	private Animator anim;
	
	public int life, type;
	public bool playerInArea, chasing;
	
	public GameObject[] CasasViking,PosicaoDeAtack;
	
	private int rdm;
	private bool atirando, vazio;
	
	public Transform mira;
	private Vector3 lookTarget;
	private Vector3 zero;

	public GameObject tiro;
	public GameObject alert;

	private GameObject player;

	private GameObject containerScriptAudioAlert;
	private AudioAlert ScriptAuidoAlert;
	
	// Use this for initialization
	void Start(){
		vazio = false;
		containerScriptAudioAlert = GameObject.FindGameObjectWithTag ("GameController");
		ScriptAuidoAlert = containerScriptAudioAlert.GetComponent<AudioAlert> ();

		agent = gameObject.GetComponent<NavMeshAgent> ();
		anim = gameObject.GetComponent<Animator> ();
		
		atirando = false;
		
		rdm = Random.Range (0, 9);
		if (CasasViking [rdm] == null) {
			RandomNewHouse ();
		} else {
			agent.SetDestination (PosicaoDeAtack [rdm].transform.position);
		}
	
		life = Random.Range (40, 80);


	}
	
	// Update is called once per frame
	void Update () {
		vazio = true;
		foreach(GameObject TempCasas in CasasViking){
			if(TempCasas != null){
				vazio = false;
			}
		}
		if (!vazio) {
			if (CasasViking [rdm] == null) {
				RandomNewHouse ();
			} else {
				if (CasasViking [rdm] != null) {
					lookTarget = new Vector3 (CasasViking [rdm].transform.position.x, transform.position.y, CasasViking [rdm].transform.position.z);
					mira.transform.LookAt (lookTarget);
				} else {
					RandomNewHouse ();
				}
				if (playerInArea) {
					agent.SetDestination (player.transform.position);
				} else {
					agent.SetDestination (PosicaoDeAtack [rdm].transform.position);
				}
			}

			if (agent.velocity.x > zero.x || agent.velocity.y > zero.y || agent.velocity.z > zero.z) {
				anim.SetBool ("iddle", false);
			} else {
				anim.SetBool ("iddle", true);
			}

			if(player != null){
				if (player.GetComponent<MoveController>().escondido){
					chasing = false;
					playerInArea = false;
				}
			}
		}
	}

	void RandomNewHouse(){
		if (!vazio) {
			rdm = Random.Range (0, 9);
			if (CasasViking [rdm] != null) {
				agent.SetDestination (PosicaoDeAtack [rdm].transform.position);
			} else {
				RandomNewHouse ();
			}
		}
	}
	
	public void InvokeInvokeRepeating(){
		InvokeRepeating ("Atack", 0, 10);
		atirando = true;
	}
	
	public void CancelInvoke(){
		if(atirando){
			atirando = false;
			CancelInvoke ();
		}
	}
	
	void Atack(){
		GameObject newTiro = Instantiate (tiro, transform.position, Quaternion.identity)as GameObject;
		newTiro.transform.LookAt(lookTarget);
		Vector3 direcaoDisparo = mira.transform.forward;
		newTiro.GetComponent<Rigidbody>().AddForce(direcaoDisparo * 300);
	}

	void DesactiveAlert()
	{
		alert.SetActive(false);
	}

	public void Chase(){
		playerInArea = true;
		chasing = true;
		ScriptAuidoAlert.audioAlert ();
		alert.SetActive(true);
		Invoke("DesactiveAlert", 2);
	}

	public void Leave(){
		playerInArea = false;
		chasing = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player"){
			player = other.gameObject;
			if(!player.GetComponent<MoveController>().escondido){
				Chase();
			}
		}
		if (other.tag == "Enemy" && playerInArea){
			GameObject otherEnemy = other.gameObject;
			if (!otherEnemy.GetComponent<EnemyAtack>().chasing && !otherEnemy.GetComponent<EnemyAtack>().playerInArea){
				otherEnemy.GetComponent<EnemyAtack>().Chase();
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player"){
			Leave();
		}
		
		if (other.tag == "Enemy"){
			GameObject otherEnemy = other.gameObject;
			if(!otherEnemy.GetComponent<EnemyAtack>().playerInArea){
				otherEnemy.GetComponent<EnemyAtack>().chasing = false;
				otherEnemy.GetComponent<EnemyAtack>().Leave();
			}
		}
	}
}
