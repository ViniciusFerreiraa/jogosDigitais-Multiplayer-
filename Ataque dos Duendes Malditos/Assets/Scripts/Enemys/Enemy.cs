using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour{
	private NavMeshAgent agent;
	public Animator anim;
	
	private Transform player;
	public int life, type;
	public GameObject[] PatrolPoints;
	public float patrolTime;
	public bool playerInArea, chasing, patrolling;
	
	public bool ponto_1, ponto_central, ponto_2;
	public int oldPoint;
	
	private GameObject containerGame;
	private GameObject containerScriptAudioAlert;
	private GameObject containerScriptMove;

	private MoveController scriptMove;
	private GameController gameController;
	private AudioAlert ScriptAuidoAlert;
	
	
	public GameObject alert;
	private Vector3 zero;
	
	
	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;

		zero = new Vector3(0, 0, 0);
		containerGame = GameObject.FindGameObjectWithTag("GameController");
		gameController = containerGame.GetComponent<GameController>();

		containerScriptMove = GameObject.FindGameObjectWithTag("Player");
		scriptMove = containerScriptMove.GetComponent<MoveController>();
		
		containerScriptAudioAlert = GameObject.FindGameObjectWithTag("GameController");
		ScriptAuidoAlert = containerScriptAudioAlert.GetComponent<AudioAlert>();
		
		agent = gameObject.GetComponent<NavMeshAgent>();
		ponto_1 = true;
		ponto_2 = false;
		ponto_central = false;
		
		if (PatrolPoints[0] == null)
		{
			ponto_1 = false;
			ponto_2 = false;
			ponto_central = true;
			anim.SetBool("iddle", true);
		}
		
		Patrol();
	}

	public void startFunctions()
	{
		ponto_1 = true;
		ponto_2 = false;
		ponto_central = false;
		
		if (PatrolPoints[0] == null)
		{
			ponto_1 = false;
			ponto_2 = false;
			ponto_central = true;
			anim.SetBool("iddle", true);
		}
		
		Patrol();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (!gameController.inCombat)
		{
			PursuePlayer();
			
			anim.SetFloat("posX", (agent.velocity.x));
			anim.SetFloat("posY", (agent.velocity.z));
			
			if (scriptMove.escondido)
			{
				chasing = false;
				playerInArea = false;
				patrolling = true;
				ponto_central = true;
				Patrol();
			}
		}
		
		if(agent.velocity.x > zero.x || agent.velocity.y > zero.y || agent.velocity.z > zero.z){
			anim.SetBool("iddle", false);
		}
	}
	
	public void InvokePatrol()
	{
		if (!playerInArea)
		{
			Invoke("Patrol", patrolTime);
		}
	}
	
	void DesactiveAlert()
	{
		alert.SetActive(false);
	}
	
	void Patrol()
	{
		if (!playerInArea && !gameController.inCombat)
		{
			if (ponto_1)
			{
				anim.SetBool("iddle", false);
				agent.SetDestination(PatrolPoints[0].transform.position);
				patrolling = true;
			}
			
			if (ponto_2)
			{
				anim.SetBool("iddle", false);
				agent.SetDestination(PatrolPoints[1].transform.position);
				patrolling = true;
			}
			
			if (ponto_central)
			{
				anim.SetBool("iddle", false);
				agent.SetDestination(PatrolPoints[2].transform.position);
				patrolling = true;
			}
			
			if (PatrolPoints[0] == null)
			{
				anim.SetBool("iddle", true);
			}
			
			ponto_1 = false;
			ponto_2 = false;
			ponto_central = false;
		}
	}
	
	public void Chase()
	{
		alert.SetActive(true);
		ScriptAuidoAlert.audioAlert ();
		Invoke("DesactiveAlert", 2);
		anim.SetBool("iddle", false);
		playerInArea = true;
		chasing = false;
	}
	
	public void Leave()
	{
		playerInArea = false;
	}
	
	public void ChaseGroup()
	{
		chasing = true;
	}
	
	public void LeaveGroup()
	{
		chasing = false;
	}
	
	void PursuePlayer()
	{
		if (playerInArea || chasing)
		{
			patrolling = false;
			agent.SetDestination(player.transform.position);
		}
		else if (!patrolling)
		{
			if (PatrolPoints[0] != null)
			{
				ponto_1 = true;
			}
			else
			{
				ponto_central = true;
			}
			patrolling = true;
			Patrol();
		}
	}
	
	
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player"){
			Chase();
		}
		if (other.tag == "Enemy" && playerInArea){
			GameObject otherEnemy = other.gameObject;
			if (!otherEnemy.GetComponent<Enemy>().chasing && !otherEnemy.GetComponent<Enemy>().playerInArea)
			{
				otherEnemy.GetComponent<Enemy>().Chase();
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
			if(!otherEnemy.GetComponent<Enemy>().playerInArea){
				otherEnemy.GetComponent<Enemy>().chasing = false;
				otherEnemy.GetComponent<Enemy>().Leave();
			}
		}
	}
}
