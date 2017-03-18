using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fazenda : MonoBehaviour {

	public Inventario scriptInventario;

	public GameObject[] options;
	public GameObject[] TxtOptions;
	public GameObject[] buttons;

	public GameObject aviso, textAviso;

	public GameObject ceva, bacon;

	private int cevaParaColher, baconParaColher; 

	private bool InFarm;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (InFarm) {
			options[0].SetActive(true);
			options[1].SetActive(true);
			options[2].SetActive(true);
			options[3].SetActive(true);

			if(scriptInventario.sementeCeva > 0){
				buttons[0].SetActive(true);
				if(scriptInventario.sementeCeva == 1)
					TxtOptions[0].GetComponent<Text>().text = "Você tem 1 semente de Cerveja para ser plantada";
				else
					TxtOptions[0].GetComponent<Text>().text = "Você tem " + scriptInventario.sementeCeva.ToString() + " sementes de Cerveja para serem plantadas";
			}
			else{
				TxtOptions[0].GetComponent<Text>().text = "Você não tem sementes de cerveja";
				buttons[0].SetActive(false);
			}

			if(cevaParaColher > 0){
				buttons[1].SetActive(true);
				if(cevaParaColher == 1)
					TxtOptions[1].GetComponent<Text>().text = "Você tem 1 Cerveja para ser colhida";
				else
					TxtOptions[1].GetComponent<Text>().text = "Você tem " + cevaParaColher.ToString() + " Cervejas para serem colhidas";
			}
			else{
				TxtOptions[1].GetComponent<Text>().text = "Você não tem Cerveja para colher";
				buttons[1].SetActive(false);
			}

			if(scriptInventario.sementeBacon > 0){
				buttons[2].SetActive(true);
				if(scriptInventario.sementeBacon == 1)
					TxtOptions[2].GetComponent<Text>().text = "Você tem 1 semente de Bacon para ser plantada";
				else
					TxtOptions[2].GetComponent<Text>().text = "Você tem " + scriptInventario.sementeBacon.ToString() + " sementes de Bacon para serem plantadas";
			}
			else{
				TxtOptions[2].GetComponent<Text>().text = "Você não tem sementes de Bacon";
				buttons[2].SetActive(false);
			}

			if(baconParaColher > 0){
				buttons[3].SetActive(true);
				if(baconParaColher == 1)
					TxtOptions[3].GetComponent<Text>().text = "Você tem 1 Bacon para ser colhido";
				else
					TxtOptions[3].GetComponent<Text>().text = "Você tem " + baconParaColher.ToString() + " Bacons para serem colhidos";
			}
			else{
				TxtOptions[3].GetComponent<Text>().text = "Você não tem Bacons para colher";
				buttons[3].SetActive(false);
			}
		}
		else{
			options[0].SetActive(false);
			options[1].SetActive(false);
			options[2].SetActive(false);
			options[3].SetActive(false);
		}
	}

	public void PlantarCeva(){
		scriptInventario.sementeCeva--;
		Invoke ("NascerCeva", 5);
	}

	public void ColherCeva(){
		if (scriptInventario.mana < 100) {
			cevaParaColher--;
			scriptInventario.mana += 50;
			if(scriptInventario.mana > 100){
				scriptInventario.mana = 100;
			}
		}
		else {
			aviso.SetActive(true);
			textAviso.GetComponent<Text>().text = "Seu mana ja esta completa";
			Invoke("escondeAviso", 5);
		}
	}

	public void PlantarBacon(){
		scriptInventario.sementeBacon--;
		Invoke ("NascerBacon", 5);
	}

	public void ColherBacon(){
		if (scriptInventario.vida < 100) {
			baconParaColher--;
			scriptInventario.vida += 50;
			if (scriptInventario.vida > 100) {
				scriptInventario.vida = 100;
			}

			GameObject[] destroyBacon = GameObject.FindGameObjectsWithTag ("Bacon");
			Destroy (destroyBacon [destroyBacon.Length - 1]);
		} else {
			aviso.SetActive(true);
			textAviso.GetComponent<Text>().text = "Sua vida ja esta completa";
			Invoke("escondeAviso", 5);
		}
	}

	void NascerCeva(){
		GameObject newCeva = Instantiate (ceva, new Vector3(Random.Range(13f, 20f), 5.55f, Random.Range(-48.2f, -42.5f)), Quaternion.identity)as GameObject;
		newCeva.transform.Rotate(90f, 180f, 0f);
		cevaParaColher++;
	}

	void NascerBacon(){
		GameObject newBacon = Instantiate (bacon, new Vector3(Random.Range(13f, 20f), 5.55f, Random.Range(-48.2f, -42.5f)), Quaternion.identity)as GameObject;
		newBacon.transform.Rotate(90f, 0f, 0f);
		baconParaColher++;
	}

	void escondeAviso(){
		aviso.SetActive (false);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "PlayerCharacter") {
			InFarm = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "PlayerCharacter") {
			InFarm = false;
		}
	}
}
