using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LagnarRothbrok : MonoBehaviour {
	
	private bool dialogueLagnar, inCollision;
	
	public GameObject Dialogue;
	public GameObject TextDialogue;
	public GameObject NomePersonagem;
	public GameObject TextButtom;
	public GameObject PersonagemFalando;
	public Texture Personagem;
	private bool upDialogue, downDialogue;
	// Use this for initialization
	void Start () {
		dialogueLagnar = false;
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
			dialogueLagnar = true;
			PersonagemFalando.GetComponent<RawImage>().texture = Personagem;
			upDialogue = true;
			
			TextDialogue.GetComponent<Text>().text = "Eu até poderia ir atrás desse Duendes malditos, pois costumava ser um aventureiro como você, mas aí tomei uma flechada no joelho.";
			NomePersonagem.GetComponent<Text>().text = "Lagnar Rothbrok:";
			TextButtom.GetComponent<Text>().text = "Sair";
		}
	}
	
	public void sair(){
		if (dialogueLagnar) {
			GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
			Time.timeScale = 1;
			dialogueLagnar = false;
			downDialogue = true;
			Invoke("IncollisionFalse", 2);
		}
	}
	void IncollisionFalse(){
		inCollision = false;
	}
}
