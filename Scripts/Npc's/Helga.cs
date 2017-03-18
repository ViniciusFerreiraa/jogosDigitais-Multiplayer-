using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Helga : MonoBehaviour {
	
	private bool dialogueHelga, inCollision;
	private int meetsHelga, next;
	
	public Inventario scriptInventario;
	
	public GameObject Dialogue;
	public GameObject TextDialogue;
	public GameObject NomePersonagem;
	public GameObject TextButtom;
	public GameObject PersonagemFalando;
	public Texture Personagem;
	private bool upDialogue, downDialogue;
	// Use this for initialization
	void Start () {
		dialogueHelga = false;
		inCollision = false;
		next = 0;
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
			dialogueHelga = true;
			PersonagemFalando.GetComponent<RawImage>().texture = Personagem;
			upDialogue = true;
			
			if(scriptInventario.arma == 0){
				TextDialogue.GetComponent<Text>().text = "Olaf Querido,  parece que esta noite aqueles malditos duendes atacaram nossa caverna, levaram todo nosso tesouro! Estamos falidos.";
				TextButtom.GetComponent<Text>().text = "Próximo";
			}
			else{
				meetsHelga = 1;
			}
			
			if(meetsHelga == 1){
				if(scriptInventario.arma == 1)
					TextDialogue.GetComponent<Text>().text = "Você comprou uma Besta, ótimo agora tente reaver nossas riquezas, se estiver com problemas pode vir checar se floresceu bacon e cerveja da nossa plantação.";
				if(scriptInventario.arma == 2)
					TextDialogue.GetComponent<Text>().text = "Você comprou um Martelo, ótimo agora tente reaver nossas riquezas, se estiver com problemas pode vir checar se floresceu bacon e cerveja da nossa plantação.";
				meetsHelga = 2;
				TextButtom.GetComponent<Text>().text = "Sair";
			}
			else if(meetsHelga == 2){
				TextDialogue.GetComponent<Text>().text = "Olaf você está ferido? Cheque nossa plantação em busca de bacon e cerveja.";
				TextButtom.GetComponent<Text>().text = "Sair";
			}
			
			NomePersonagem.GetComponent<Text>().text = "Helga:";
		}
	}
	
	public void sair(){
		if (dialogueHelga) {
			if(meetsHelga == 0){
				next++;
				if(next == 1){
					TextDialogue.GetComponent<Text>().text = "Você precisa ir até o ferreiro e ver se consegue comprar alguma arma com o que sobrou das nossas economias!";
				}
				if(next == 2){
					TextDialogue.GetComponent<Text>().text = "Vou ficar cuidando da fazenda, se tiver problemas compre algumas sementes de bacon e cerveja com o velho. Assim vai poder plantá-las e colhe-las para recuperar suas energias.";
				}
				if(next >= 3){
					GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
					Time.timeScale = 1;
					dialogueHelga = false;
					downDialogue = true;
					next = 0;
					Invoke("IncollisionFalse", 2);
				}
			}
			else{
				GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
				Time.timeScale = 1;
				dialogueHelga = false;
				downDialogue = true;
				Invoke("IncollisionFalse", 2);
			}
		}
	}
	void IncollisionFalse(){
		inCollision = false;
	}
}
