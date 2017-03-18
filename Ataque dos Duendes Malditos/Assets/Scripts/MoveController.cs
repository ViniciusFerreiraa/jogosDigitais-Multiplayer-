using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {
	
	private NavMeshAgent agent;
	public Animator anim;
	
	public bool escondido, canHidde;
	
	public int persuers;
	public int[] EnemyType; 
	private Vector3 posicaoRaio ;
	private Vector3 direcaoRaio ;
	private Vector3 posicaoDoMouse ;
	private RaycastHit hit;
	public GameObject Arrow;
	
	public Camera  cameraPrincipal;
	
	private Vector3 destino, zero;
	private bool segueMouse, walking;
	
	public GameObject[] AllCamposVisaoInimigos;
	public GameObject PaiCampoVisaoInimigo, CampoVisaoInimigo;
	
	public Inventario ScriptInventario;
	public Audios scriptAudios;
	
	public GameObject containerGuarda;
	public Guarda scriptGuarda;
	
	void Start () {
		containerGuarda = GameObject.FindGameObjectWithTag("Guarda");
		scriptGuarda = containerGuarda.GetComponent<Guarda>();

		ScriptInventario = this.gameObject.GetComponent<Inventario> ();

		ScriptInventario.level = 1;
		segueMouse = true;
		escondido = false;
		canHidde = false;
		agent = GetComponent<NavMeshAgent> ();
		zero = new Vector3(0, 0, 0);

		scriptAudios.audioViking();
	}
	
	void Update () {
		posicaoDoMouse = Input.mousePosition;
		posicaoRaio = cameraPrincipal.ScreenToWorldPoint(posicaoDoMouse);
		posicaoDoMouse.z += 1;
		direcaoRaio = cameraPrincipal.ScreenToWorldPoint(posicaoDoMouse) - posicaoRaio;
		
		if (Physics.Raycast(posicaoRaio, direcaoRaio, out hit, 1000f)){
			Debug.DrawRay(posicaoRaio, direcaoRaio*1000f, Color.red);
			
			//INICIO CLICK
			if (Input.GetMouseButtonDown(0)){
				canHidde = false;
				if(hit.transform.tag == "Barril"){
					canHidde = true;
					segueMouse = false;
					anim.SetBool("iddle", false);
					agent.SetDestination(new Vector3(hit.point.x, hit.point.y, hit.point.z));
					destino = new Vector3(hit.point.x, hit.point.y, hit.point.z);
					DestroyArrows();
				}
				if(hit.transform.tag == "EnemyCharacter") {
					PaiCampoVisaoInimigo = hit.transform.gameObject;
					AllCamposVisaoInimigos = GameObject.FindGameObjectsWithTag("CampoVisao");
					foreach (GameObject campoAuxiliar in AllCamposVisaoInimigos) {
						campoAuxiliar.SetActive(false);
					}
					PaiCampoVisaoInimigo.transform.GetChild(0).gameObject.SetActive(true);
				}
				else if (hit.transform.tag == "GuardaTrigger") {
					segueMouse = false;
					anim.SetBool("iddle", false);
					agent.SetDestination(new Vector3(-33.78f, 5.137f, -17.91f));
					destino = new Vector3(-33.78f, 5.137f, -17.91f);
					DestroyArrows();
					GameObject newArrow = Instantiate(Arrow, new Vector3(-33.78f, 5.137f, -17.91f), Quaternion.identity) as GameObject;
					newArrow.transform.Rotate(90f, 0f, 0f);
					if(!scriptGuarda.subornou){
						scriptGuarda.DialogueGuard();
					}
				}
				else
				{
					segueMouse = false;
					anim.SetBool("iddle", false);
					agent.SetDestination(new Vector3(hit.point.x, hit.point.y, hit.point.z));
					destino = new Vector3(hit.point.x, hit.point.y, hit.point.z);
					DestroyArrows();
					GameObject newArrow = Instantiate(Arrow, new Vector3(hit.point.x, 5.137f, hit.point.z), Quaternion.identity) as GameObject;
					newArrow.transform.Rotate(90f, 0f, 0f);
				}
			}
			//FIM CLICK
			
			if (segueMouse){
				anim.SetFloat("posIddleX", (hit.point.x - transform.position.x));
				anim.SetFloat("posIddleY", (hit.point.z - transform.position.z));
			}else{
				anim.SetFloat("posX", (agent.velocity.x));
				anim.SetFloat("posY", (agent.velocity.z));
				if (agent.velocity != zero){
					walking = true;
				}
			}
		}
		
		if (walking && agent.velocity == zero) {
			agent.SetDestination(transform.position);
			DestroyArrows();
			PlayerStop();
		}
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Boss") {
			ScriptInventario.level = 3;
		}
		
		if (other.tag == "PortaoViking")
		{
			if (ScriptInventario.level != 1) {
				ScriptInventario.level = 1;
				scriptAudios.audioViking();
			}
		}
		
		if (other.tag == "PortaoDuende")
		{
			if (ScriptInventario.level != 2) {
				ScriptInventario.level = 2;
				scriptAudios.audioDuende();
			}
		}
	}
	
	public void DestroyArrows() {
		Destroy(GameObject.FindWithTag("Arrow"));
	}
	
	public void PlayerStop() {
		agent.SetDestination(transform.position);
		anim.SetBool("iddle", true);
		anim.SetFloat("posX", 0);
		anim.SetFloat("posY", 0);
		segueMouse = true;
		walking = false;
	}
}
