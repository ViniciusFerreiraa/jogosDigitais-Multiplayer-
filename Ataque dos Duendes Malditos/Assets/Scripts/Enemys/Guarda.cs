using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Guarda : MonoBehaviour {
	private bool dialogueGuarda, inCollision;
	
	public bool colidindo, subornou;
	public int type, life; 
	
	
	public GameObject Dialogue;
	public GameObject TextDialogue;
	public GameObject NomePersonagem;
	public GameObject bt1, bt2;
	
	private bool upDialogue, downDialogue;
	
	private GameObject containerGame;
	private GameController gameController;
	
	public Inventario scriptInventario;
	public DefineGroupEnemys scriptDefineGroupEnemys;

	public SpawnerEnemys scriptSpaw;
	// Use this for initialization
	void Start () {
		containerGame = GameObject.FindGameObjectWithTag("GameController");
		gameController = containerGame.GetComponent<GameController>();
		
		dialogueGuarda = false;
		inCollision = false;
		subornou = false;
		
		colidindo = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(upDialogue){
			if (Dialogue.transform.position.y < 100) {
				Dialogue.transform.Translate (0f, 15f, 0f);
			}
			else{
				upDialogue = false;
			}
		}
		
		if(downDialogue){
			if (Dialogue.transform.position.y > -117) {
				Dialogue.transform.Translate (0f, -15f, 0f);
			}
			else{
				downDialogue = false;
				if (subornou) {
					Destroy(this.gameObject);
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && !inCollision){
			DialogueGuard();
		}
	}
	
	public void DialogueGuard(){
		GameObject.Find("Player").GetComponent<MoveController>().enabled = false;
		Time.timeScale = 0;
		
		bt1.SetActive(true);
		bt2.SetActive(true);
		
		colidindo = true;
		
		if(scriptInventario.itemSuborno == false){
			bt1.SetActive(false);
		}
		else{
			bt1.SetActive(true);
		}
		
		inCollision = true;
		dialogueGuarda = true;
		upDialogue = true;
		
		TextDialogue.GetComponent<Text>().text = "Parado, você não vai passar por mim, a não ser é claro que tenha algo especial com você… nosso chefe não me deu nenhuma parte do que roubamos da sua vila…";
		NomePersonagem.GetComponent<Text>().text = "Guarda:";
	}
	
	public void Subornar(){
		if (dialogueGuarda) {
			scriptDefineGroupEnemys.SubornouGuarda();
			TextDialogue.GetComponent<Text>().text = "Água da Jamaica, como você sabia? Eu adoro isso!";
			bt1.SetActive(false);
			bt2.SetActive(false);
			subornou = true;
		}
	}
	
	public void Batalhar(){
		if (dialogueGuarda) {
			GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
			Time.timeScale = 1;
			scriptDefineGroupEnemys.MatouGuarda();
			scriptSpaw.InvokeSpwanEnemys();
			scriptInventario.MatouGuarda = true;
			Dialogue.SetActive(false);
			dialogueGuarda = false;
			gameController.GetGuard();
			Destroy(this.gameObject);
		}
	}
	
	public void sair(){
		GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
		Time.timeScale = 1;
		dialogueGuarda = false;
		downDialogue = true;
		Invoke("IncollisionFalse", 2);
	} 
	
	void IncollisionFalse(){
		inCollision = false;
	}
}
