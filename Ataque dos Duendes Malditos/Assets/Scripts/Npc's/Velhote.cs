using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Velhote : MonoBehaviour {
	private bool dialogueVelhote, inCollision;
	private int selecionado, next;
	
	public GameObject loja;
	public GameObject Selected_1, Selected_2;
	public GameObject InfoCeva, InfoBacon;
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
		next = 0;
		dialogueVelhote = false;
		inCollision = false;
		custo.GetComponent<Text>().text = "0";
		
		InfoCeva.SetActive (false);
		InfoBacon.SetActive (false);
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
			dialogueVelhote = true;
			PersonagemFalando.GetComponent<RawImage>().texture = Personagem;
			upDialogue = true;
			loja.SetActive(true);
			
			TextDialogue.GetComponent<Text>().text = "Olaf meu jovem, que situação terrível, se não estivesse tão velho, eu mesmo iria atrás desses Duendes malditos! Confiamos em você para reaver nossas riquezas.";
			NomePersonagem.GetComponent<Text>().text = "Velhote:";
			TextButtom.GetComponent<Text>().text = "Próximo";
		}
	}
	
	public void HoverEnterCeva(){
		InfoCeva.SetActive (true);
	}
	public void HoverEnterBacon(){
		InfoBacon.SetActive (true);
	}
	public void HoverEnterComprar(){
		Bthover.SetActive (true);
	}
	public void HoverExitCeva(){
		InfoCeva.SetActive (false);
	}
	public void HoverExitBacon(){
		InfoBacon.SetActive (false);
	}
	public void HoverExitComprar(){
		Bthover.SetActive (false);
	}
	
	public void Ceva(){
		Selected_1.SetActive (true);
		Selected_2.SetActive (false);
		selecionado = 1;
		custo.GetComponent<Text>().text = "15";
	}
	public void Bacon(){
		Selected_1.SetActive (false);
		Selected_2.SetActive (true);
		selecionado = 2;
		custo.GetComponent<Text>().text = "15";
	}
	public void Comprar(){
		if (selecionado == 1) {
			if(scriptInventario.gold >= 15){
				scriptInventario.gold -= 15;
				scriptInventario.sementeCeva++;
			}
			else if(scriptInventario.gold < 15){
				TextDialogue.GetComponent<Text>().text = "Você não possui gold suficiente para comprar mais sementes!";
			}
		}
		
		if (selecionado == 2) {
			if(scriptInventario.gold >= 15){
				scriptInventario.gold -= 15;
				scriptInventario.sementeBacon++;
			}
			else if(scriptInventario.gold < 15){
				TextDialogue.GetComponent<Text>().text = "Você não possui gold suficiente para comprar mais sementes!";
			}
		}
	}
	
	public void proximo(){
		if (dialogueVelhote) {
			next++;
			if(next == 1){
				TextDialogue.GetComponent<Text>().text = "Olaf, antes de ir de uma olhada nestas sementes, elas podem lhe ajudar em sua jornada";
				TextButtom.GetComponent<Text>().text = "Sair";
			}
			if(next == 2){
				next = 0;
				GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
				Time.timeScale = 1;
				dialogueVelhote = false;
				downDialogue = true;
				Selected_1.SetActive (false);
				Selected_2.SetActive (false);
				loja.SetActive(false);
				Invoke("IncollisionFalse", 2);
			}
		}
	}
	void IncollisionFalse(){
		inCollision = false;
	}
}
