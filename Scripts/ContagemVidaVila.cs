using UnityEngine;
using System.Collections;

public class ContagemVidaVila : MonoBehaviour {

	private GameObject[] Casas;
	private GameObject[] Enemys;
	private bool CameraAtivada;
	private int contAvisos;
	public GameObject CameraDeAtaque;

	public GameObject TelaGameOver;

	// Use this for initialization
	void Start () {
		CameraAtivada = false;
		contAvisos = 0;
	}
	
	// Update is called once per frame
	void Update () {

		Casas = GameObject.FindGameObjectsWithTag ("CasasVikings");
		if(!CameraAtivada){
			if(Casas.Length <= 5 && contAvisos == 0){
				contAvisos++;
				CameraAtivada = true;
				CameraDeAtaque.SetActive(true);
				Invoke("DesactiveCamera", 5);
			}
			if(Casas.Length <= 5 && contAvisos == 1){
				contAvisos++;
				CameraAtivada = true;
				CameraDeAtaque.SetActive(true);
				Invoke("DesactiveCamera", 5);
			}
			if(Casas.Length <= 5 && contAvisos == 2){
				contAvisos++;
				CameraAtivada = true;
				CameraDeAtaque.SetActive(true);
				Invoke("DesactiveCamera", 5);
			}
			if(Casas.Length <= 5 && contAvisos == 3){
				contAvisos++;
				CameraAtivada = true;
				CameraDeAtaque.SetActive(true);
				Invoke("DesactiveCamera", 5);
			}
			if(Casas.Length <= 5 && contAvisos == 4){
				contAvisos++;
				CameraAtivada = true;
				CameraDeAtaque.SetActive(true);
				Invoke("DesactiveCamera", 5);
			}
		}
		if(Casas.Length == 0){
			GameOver();
		}
	}

	void DesactiveCamera(){
		CameraAtivada = false;
		CameraDeAtaque.SetActive(false);
	}

	void GameOver(){
		Enemys = GameObject.FindGameObjectsWithTag ("EnemyAtacando");
		foreach(GameObject EnemyTemp in Enemys){
			Destroy(EnemyTemp);
		}
		TelaGameOver.SetActive (true);
	}

	public void ContinuarGame(){
		Application.LoadLevel ("Game");
	}
}
