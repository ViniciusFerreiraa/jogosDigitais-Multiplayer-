using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Eir : MonoBehaviour {
	
	private bool dialogueEir, inCollision;
	private int selecionado;
	
	public GameObject[] poder; 
	
	public GameObject loja;
	public GameObject Selected_1, Selected_2;
	public GameObject InfoMana, InfoVida;
	public GameObject Bthover;
	
	public GameObject custo;
	public Inventario scriptInventario;
	

	public GameObject comprarPoderes;
	public GameObject nomePoder;
	private int poderComprado;

	public GameObject Dialogue;
	public GameObject TextDialogue, NomePersonagem, TextButtom;
	public GameObject PersonagemFalando;
	public Texture Personagem;
	private bool upDialogue, downDialogue;
	
	// Use this for initialization
	void Start () {
		selecionado = 0;
		dialogueEir = false;
		inCollision = false;
		custo.GetComponent<Text>().text = "0";
		
		InfoMana.SetActive (false);
		InfoVida.SetActive (false);
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
			/*if(scriptInventario.poder_1_Ok == false && scriptInventario.poder_1_Ok == false && scriptInventario.arma != 0){
				int rdm = Random.Range(1,3);
				if(scriptInventario.arma == 1){
					if(rdm == 1){
						scriptInventario.poder_1_Ok = true;
						poder[0].SetActive(true);
						Invoke("desativeCaixa", 5);
					}
					else{
						scriptInventario.poder_2_Ok = true;
						poder[1].SetActive(true);
						Invoke("desativeCaixa", 5);
					}
				}
				if(scriptInventario.arma == 2){
					if(rdm == 1){
						scriptInventario.poder_1_Ok = true;
						poder[2].SetActive(true);
						Invoke("desativeCaixa", 5);
					}
					else{
						scriptInventario.poder_2_Ok = true;
						poder[3].SetActive(true);
						Invoke("desativeCaixa", 5);
					}
				}
			}*/
			GameObject.Find("Player").GetComponent<MoveController>().enabled = false;
			Time.timeScale = 0;
			
			inCollision = true;
			dialogueEir = true;
			PersonagemFalando.GetComponent<RawImage>().texture = Personagem;
			upDialogue = true;
			loja.SetActive(true);
			
			TextDialogue.GetComponent<Text>().text = "Olá Olaf, do que você precisa? ";
			NomePersonagem.GetComponent<Text>().text = "Eir:";
			TextButtom.GetComponent<Text>().text = "Sair";

			comprarPoderes.SetActive(true);

			if(scriptInventario.arma == 1){
				if(scriptInventario.poder_1_Ok){
					nomePoder.GetComponent<Text>().text = "Flecha Gelida";
					poderComprado = 2;
				}
				if(scriptInventario.poder_2_Ok){
					nomePoder.GetComponent<Text>().text = "Flecha Tranquilizante";
					poderComprado = 1;
				}
			}

			if(scriptInventario.arma == 2){
				if(scriptInventario.poder_1_Ok){
					nomePoder.GetComponent<Text>().text = "Thuntherstruck";
					poderComprado = 3;
				}
				if(scriptInventario.poder_2_Ok){
					nomePoder.GetComponent<Text>().text = "Humer Time";
					poderComprado = 4;
				}
			}
		}
	}
	
	private void desativeCaixa(){
		poder[0].SetActive(false);
		poder[1].SetActive(false);
		poder[2].SetActive(false);
		poder[3].SetActive(false);
	}

	public void comprarPoder(){
		if (poderComprado == 1 && scriptInventario.gold >= 70) {
			poder [0].SetActive (true);
			scriptInventario.poder_1_Ok = true;
			scriptInventario.gold -= 70;
			comprarPoderes.SetActive(false);
			Invoke("desativeCaixa", 5);
		} else {
			TextDialogue.GetComponent<Text>().text = "Você não possui gold suficiente para comprar este poder!";
		}
		if(poderComprado == 2 && scriptInventario.gold >= 70){
			poder[1].SetActive(true);
			scriptInventario.poder_2_Ok = true;
			scriptInventario.gold -= 70;
			comprarPoderes.SetActive(false);
			Invoke("desativeCaixa", 5);
		}
		else {
			TextDialogue.GetComponent<Text>().text = "Você não possui gold suficiente para comprar este poder!";
		}
		if(poderComprado == 3 && scriptInventario.gold >= 70){
			poder[3].SetActive(true);
			scriptInventario.poder_2_Ok = true;
			scriptInventario.gold -= 70;
			comprarPoderes.SetActive(false);
			Invoke("desativeCaixa", 5);
		}
		else {
			TextDialogue.GetComponent<Text>().text = "Você não possui gold suficiente para comprar este poder!";
		}
		if(poderComprado == 4 && scriptInventario.gold >= 70){
			poder[2].SetActive(true);
			scriptInventario.poder_1_Ok = true;
			scriptInventario.gold -= 70;
			comprarPoderes.SetActive(false);
			Invoke("desativeCaixa", 5);
		}
		else {
			TextDialogue.GetComponent<Text>().text = "Você não possui gold suficiente para comprar este poder!";
		}
	}
	
	public void HoverEnterMana(){
		InfoMana.SetActive (true);
	}
	public void HoverEnterVida(){
		InfoVida.SetActive (true);
	}
	public void HoverEnterComprar(){
		Bthover.SetActive (true);
	}
	public void HoverExitMana(){
		InfoMana.SetActive (false);
	}
	public void HoverExitVida(){
		InfoVida.SetActive (false);
	}
	public void HoverExitComprar(){
		Bthover.SetActive (false);
	}
	
	public void Mana(){
		Selected_1.SetActive (true);
		Selected_2.SetActive (false);
		selecionado = 1;
		custo.GetComponent<Text>().text = "40";
	}
	public void Vida(){
		Selected_1.SetActive (false);
		Selected_2.SetActive (true);
		selecionado = 2;
		custo.GetComponent<Text>().text = "40";
	}
	public void Comprar(){
		if (selecionado == 1) {
			if(scriptInventario.gold >= 40){
				scriptInventario.gold -= 40;
				scriptInventario.pocoesMana++;
			}
			else if(scriptInventario.gold < 40){
				TextDialogue.GetComponent<Text>().text = "Você não possui gold suficiente para comprar mais poções!";
			}
		}
		
		if (selecionado == 2) {
			if(scriptInventario.gold >= 40){
				scriptInventario.gold -= 40;
				scriptInventario.pocoesVida++;
			}
			else if(scriptInventario.gold < 40){
				TextDialogue.GetComponent<Text>().text = "Você não possui gold suficiente para comprar mais poções!";
			}
		}
	}
	
	public void Sair(){
		if (dialogueEir) {
			GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
			Time.timeScale = 1;
			dialogueEir = false;
			downDialogue = true;
			Selected_1.SetActive (false);
			Selected_2.SetActive (false);
			loja.SetActive(false);
			Invoke("IncollisionFalse", 2);
		}
	}
	void IncollisionFalse(){
		inCollision = false;
	}
}
