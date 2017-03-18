using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Vikerson : MonoBehaviour {
	
	private bool dialogueVikerson, inCollision;
	
	public GameObject Dialogue;
	public GameObject TextDialogue;
	public GameObject NomePersonagem;
	public GameObject TextButtom;
	public GameObject PersonagemFalando;
	public Texture Personagem;
	private bool upDialogue, downDialogue;
	// Use this for initialization
	void Start () {
		dialogueVikerson = false;
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
			dialogueVikerson = true;
			PersonagemFalando.GetComponent<RawImage>().texture = Personagem;
			upDialogue = true;
			
			TextDialogue.GetComponent<Text>().text = "Aqueles malditos Duendes, além de nos roubarem, trancaram a porta da caverna pelo lado de dentro! Se eu ainda estivesse em forma iria atrás deles...";
			NomePersonagem.GetComponent<Text>().text = "Vikerson:";
			TextButtom.GetComponent<Text>().text = "Sair";
		}
	}
	
	public void sair(){
		if (dialogueVikerson) {
			GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
			Time.timeScale = 1;
			dialogueVikerson = false;
			downDialogue = true;
			Invoke("IncollisionFalse", 2);
		}
	}
	void IncollisionFalse(){
		inCollision = false;
	}
}
