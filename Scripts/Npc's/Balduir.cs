using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Balduir : MonoBehaviour {
	private bool dialogueBalduir, inCollision;
	private int contMeets, next;
	
	public GameObject loja;
	public GameObject Selected;
	public GameObject Info;
	public GameObject Bthover;
	
	public GameObject custo;
	public Inventario scriptInventario;
	
	
	public GameObject Dialogue;
	public GameObject TextDialogue, NomePersonagem, TextButtom;
	public GameObject PersonagemFalando;
	public Texture Personagem;
	private bool upDialogue, downDialogue;
	
	
	// Use this for initialization
	void Start () {
		contMeets = 0;
		next = 0;
		dialogueBalduir = false;
		inCollision = false;
		
		Selected.SetActive (true);
		custo.GetComponent<Text>().text = "40";
		
		Info.SetActive (false);
		Bthover.SetActive (false);
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
			dialogueBalduir = true;
			PersonagemFalando.GetComponent<RawImage>().texture = Personagem;
			upDialogue = true;
			
			if(scriptInventario.itemSuborno == false){
				loja.SetActive(true);
			}
			
			if(contMeets == 0)
			{
				TextDialogue.GetComponent<Text>().text = "Olá Olaf, se lembra que além dessa ponte havia uma floresta vasta e cheia de vida? agora a escuridão tomou conta do solo que sucumbe mais a cada dia. Malditos Duendes! além de destruírem a terra roubam nosso tesouro!";
				NomePersonagem.GetComponent<Text>().text = "Balduir:";
				if(scriptInventario.itemSuborno == false)
					TextButtom.GetComponent<Text>().text = "Próximo";
				else
					TextButtom.GetComponent<Text>().text = "Sair";
			}
			
			else{
				int rdm = Random.Range(1,4);
				if(rdm == 1){
					TextDialogue.GetComponent<Text>().text = "Algum guerreiro que honre sua barba precisa dar um jeito naqueles monstrinhos!";
					NomePersonagem.GetComponent<Text>().text = "Balduir:";
					if(scriptInventario.itemSuborno == false)
						TextButtom.GetComponent<Text>().text = "Próximo";
					else
						TextButtom.GetComponent<Text>().text = "Sair";
				}
				else if(rdm == 2){
					TextDialogue.GetComponent<Text>().text = "Olá Olaf, se lembra que além dessa ponte havia uma floresta vasta e cheia de vida? agora a escuridão tomou conta do solo que sucumbe mais a cada dia. Malditos Duendes! além de destruírem a terra roubam nosso tesouro!";
					NomePersonagem.GetComponent<Text>().text = "Balduir:";
					if(scriptInventario.itemSuborno == false)
						TextButtom.GetComponent<Text>().text = "Próximo";
					else
						TextButtom.GetComponent<Text>().text = "Sair";
				}
				
				else if(rdm == 3){
					TextDialogue.GetComponent<Text>().text = "Duendes Malditos!";
					NomePersonagem.GetComponent<Text>().text = "Balduir:";
					if(scriptInventario.itemSuborno == false)
						TextButtom.GetComponent<Text>().text = "Próximo";
					else
						TextButtom.GetComponent<Text>().text = "Sair";
				}
			}
			
			contMeets++;
		}
	}
	
	public void HoverEnterAgua(){
		Info.SetActive (true);
	}
	public void HoverEnterComprar(){
		Bthover.SetActive (true);
	}
	public void HoverExitAgua(){
		Info.SetActive (false);
	}
	public void HoverExitComprar(){
		Bthover.SetActive (false);
	}
	
	public void Comprar(){
		if (scriptInventario.gold >= 40 && scriptInventario.itemSuborno == false) {
			scriptInventario.gold -= 40;
			scriptInventario.itemSuborno = true;
			custo.GetComponent<Text> ().text = "0";
			Selected.SetActive (false);
		} else if (scriptInventario.itemSuborno == true) {
			TextDialogue.GetComponent<Text> ().text = "Me desculpe Olaf, mas esta era a única que eu tinha";
			custo.GetComponent<Text> ().text = "0";
			Selected.SetActive (false);
		} else if (scriptInventario.gold < 40) {
			TextDialogue.GetComponent<Text> ().text = "Você não possui gold suficiente para comprar isto!";
		}
	}
	
	public void proximo(){
		if (dialogueBalduir) {
			next++;
			if(next == 1){
				if(scriptInventario.itemSuborno == false){
					TextDialogue.GetComponent<Text>().text = "De uma olhada no que eu consegui encontrar, acho que sera muito útil para você";
					TextButtom.GetComponent<Text>().text = "Sair";
				}
				else{
					next++;
				}
			}
			if(next == 2){
				next = 0;
				GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
				Time.timeScale = 1;
				dialogueBalduir = false;
				downDialogue = true;
				Selected.SetActive (false);
				loja.SetActive(false);
				Invoke("IncollisionFalse", 2);
			}
		}
	}
	void IncollisionFalse(){
		inCollision = false;
	}
}