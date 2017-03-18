using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EirAprisionada : MonoBehaviour {
	private bool dialogueEirPresa, inCollision, semArma;
	
	public Inventario scriptInventario;
	
	public GameObject[] poder; 
	public GameObject Eir;
	
	public GameObject Dialogue;
	public GameObject TextDialogue;
	public GameObject NomePersonagem;
	public GameObject TextButtom;
	public GameObject PersonagemFalando;
	public Texture Personagem;
	private bool upDialogue, downDialogue;
	
	private bool seguePlayer;
	
	public GameObject particle, particleEir;
	private GameObject player;
	private GameObject newParticle;
	// Use this for initialization
	void Start () {
		dialogueEirPresa = false;
		inCollision = false;
		semArma = false;
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
		
		if (seguePlayer) {
			newParticle.transform.position = player.transform.position;
		}
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && !inCollision){
			GameObject.Find("Player").GetComponent<MoveController>().enabled = false;
			Time.timeScale = 0;
			
			player = other.gameObject;
			
			inCollision = true;
			dialogueEirPresa = true;
			PersonagemFalando.GetComponent<RawImage>().texture = Personagem;
			upDialogue = true;
			
			TextDialogue.GetComponent<Text>().text = "Olaf! Obrigado por me resgatar, como recompensa vou lhe ensinar uma nova habilidade! Agora vou voltar para minha loja de poções, se precisar de cura ou mana sabe onde me encontrar!";
			NomePersonagem.GetComponent<Text>().text = "Eir:";
			TextButtom.GetComponent<Text>().text = "Próximo";
		}
	}
	
	private void desativeCaixa(){
		poder[0].SetActive(false);
		poder[1].SetActive(false);
		poder[2].SetActive(false);
		poder[3].SetActive(false);
	}
	
	public void habilidade(){
		if (dialogueEirPresa) {
			int rdm = Random.Range(1,3);
			if(scriptInventario.arma == 1){
				semArma = false;
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
				semArma = false;
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
			
			if(scriptInventario.arma == 0 && !semArma){
				TextDialogue.GetComponent<Text>().text = "Me desculpe Olaf, mas você não possui nenhuma arma. Quando comprar uma vá até minha loja e receba um poder extra para ela. Até logo";
				semArma = true;
			}
			else{
				Time.timeScale = 1;
				recebeHabilidade();
				dialogueEirPresa = false;
				downDialogue = true;
				Invoke("IncollisionFalse", 2);
			}
		}
	}
	void IncollisionFalse(){
		inCollision = false;
	}
	
	void recebeHabilidade(){
		if (semArma) {
			newParticle = Instantiate (particle, new Vector3 (player.transform.position.x, 5.61f, player.transform.position.z), Quaternion.identity)as GameObject;
			seguePlayer = true;
		}
		Invoke("destroyParticle", 2);
	}
	
	void destroyParticle(){
		GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
		Time.timeScale = 1;
		seguePlayer = false;
		Destroy (newParticle);
		newParticle = Instantiate (particleEir, new Vector3(transform.position.x, 5.61f, transform.position.z), Quaternion.identity)as GameObject;
		Invoke("destroyThis", 3);
	}
	
	void destroyThis(){
		poder[0].SetActive(false);
		poder[1].SetActive(false);
		poder[2].SetActive(false);
		poder[3].SetActive(false);
		Eir.SetActive (true);
		Destroy (newParticle);
		Destroy (this.gameObject);
	}
}