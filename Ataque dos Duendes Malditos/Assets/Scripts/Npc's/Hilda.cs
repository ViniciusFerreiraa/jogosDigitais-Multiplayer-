using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hilda : MonoBehaviour {
	
	private bool dialogueHilda, inCollision;
	
	public GameObject Dialogue;
	public GameObject TextDialogue;
	public GameObject NomePersonagem;
	public GameObject TextButtom;
	public GameObject PersonagemFalando;
	public Texture Personagem;
	private bool upDialogue, downDialogue;
	// Use this for initialization
	void Start () {
		dialogueHilda = false;
		inCollision = false;
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
			}
		}
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && !inCollision){
			GameObject.Find("Player").GetComponent<MoveController>().enabled = false;
			Time.timeScale = 0;
			
			inCollision = true;
			dialogueHilda = true;
			PersonagemFalando.GetComponent<RawImage>().texture = Personagem;
			upDialogue = true;
			
			int rdm = Random.Range(1,4);
			if(rdm == 1){
				TextDialogue.GetComponent<Text>().text = "Este totem representa nossos Deuses, ele também é ótimo para preencher este espaço vazio na vila.";
			}
			else if(rdm == 2){
				TextDialogue.GetComponent<Text>().text = "Notou que todos te contam coisas que você deveria saber já que vive aqui?";
			}
			else if(rdm == 3){
				TextDialogue.GetComponent<Text>().text = "O pessoal da vila gosta de falar o nome do jogo nos seus diálogos, eles acham que isso é engraçado.";
			}
			
			NomePersonagem.GetComponent<Text>().text = "Hilda:";
			TextButtom.GetComponent<Text>().text = "Sair";
		}
	}
	
	public void sair(){
		if (dialogueHilda) {
			GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
			Time.timeScale = 1;
			dialogueHilda = false;
			downDialogue = true;
			Invoke("IncollisionFalse", 2);
		}
	}
	void IncollisionFalse(){
		inCollision = false;
	}
}
