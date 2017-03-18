using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ferreiro : MonoBehaviour {
	private bool dialogueFerreito, inCollision;
	private int selecionado;
	
	public GameObject loja;
	public GameObject Selected_1, Selected_2;
	public GameObject InfoBesta, InfoMartelo;
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
		selecionado = 0;
		dialogueFerreito = false;
		inCollision = false;
		custo.GetComponent<Text>().text = "0";
		
		InfoBesta.SetActive (false);
		InfoMartelo.SetActive (false);
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
			dialogueFerreito = true;
			PersonagemFalando.GetComponent<RawImage>().texture = Personagem;
			upDialogue = true;
			loja.SetActive(true);
			
			TextDialogue.GetComponent<Text>().text = "Olá olaf, o que posso fazer por você?";
			NomePersonagem.GetComponent<Text>().text = "Thordin:";
			TextButtom.GetComponent<Text>().text = "Sair";
		}
	}
	
	public void HoverEnterBesta(){
		InfoBesta.SetActive (true);
	}
	public void HoverEnterMartelo(){
		InfoMartelo.SetActive (true);
	}
	public void HoverEnterComprar(){
		Bthover.SetActive (true);
	}
	public void HoverExitBesta(){
		InfoBesta.SetActive (false);
	}
	public void HoverExitMartelo(){
		InfoMartelo.SetActive (false);
	}
	public void HoverExitComprar(){
		Bthover.SetActive (false);
	}
	
	public void Besta(){
		Selected_1.SetActive (true);
		Selected_2.SetActive (false);
		selecionado = 1;
		custo.GetComponent<Text>().text = "50";
	}
	public void Martelo(){
		Selected_1.SetActive (false);
		Selected_2.SetActive (true);
		selecionado = 2;
		custo.GetComponent<Text>().text = "80";
	}
	public void Comprar(){
		if (selecionado == 1) {
			if(scriptInventario.gold >= 50 && scriptInventario.arma == 0){
				scriptInventario.gold -= 50;
				scriptInventario.arma = 1;
			}
			else if(scriptInventario.gold < 50){
				TextDialogue.GetComponent<Text>().text = "Você não possui gold suficiente para comprar esta arma!";
			}
			else if(scriptInventario.arma != 0){
				TextDialogue.GetComponent<Text>().text = "Você já possui uma arma!";
			}
		}
		
		if (selecionado == 2) {
			if(scriptInventario.gold >= 80 && scriptInventario.arma == 0){
				scriptInventario.gold -= 80;
				scriptInventario.arma = 2;
			}
			else if(scriptInventario.gold < 80){
				TextDialogue.GetComponent<Text>().text = "Você não possui gold suficiente para comprar esta arma!";
			}
			else if(scriptInventario.arma != 0){
				TextDialogue.GetComponent<Text>().text = "Você já possui uma arma!";
			}
		}
	}
	
	public void proximoFerreiro(){
		if (dialogueFerreito) {
			GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
			Time.timeScale = 1;
			dialogueFerreito = false;
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
