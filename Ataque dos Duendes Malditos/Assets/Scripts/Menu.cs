using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GameObject anim_click_para_iniciar;
    public GameObject anim_bt_novo_jogo;
    public GameObject anim_bt_opcoes;
    public GameObject anim_bt_creditos;


    public GameObject bt_click_para_iniciar;
	public GameObject bt_novo_jogo;
	public GameObject bt_opcoes;
	public GameObject bt_creditos;
	public GameObject bt_sair;

	public GameObject ray_click_para_iniciar;
	public GameObject ray_novo_jogo;
	public GameObject ray_opcoes;
	public GameObject ray_creditos;

	public GameObject opcoes;
	public GameObject creditos;

    public GameObject cutScene;
	public GameObject txtsKIP;
	public bool inCut;

	public Camera  cameraPrincipal;

	private Vector3 posicaoRaio ;
	private Vector3 direcaoRaio ;
	private Vector3 posicaoDoMouse ;
	private RaycastHit hit ;

	private bool canClickParaIniciar;
	private bool canClickNovoJogo;
	private bool canClickOpcoes;
	private bool canClickCreditos;
	private bool canPressEsc;

	private bool voltar;
	private bool goToOpcoes;
	private bool goToCreditos;

    public AudioClip music;
    public AudioClip musicCutscene;

	public AudioController scriptAudio;

	public GameObject xLigado, xDesligado;

	
	// Use this for initialization
	void Start () {
		scriptAudio.ligado = true;
        cutScene.SetActive(false);
        canClickNovoJogo = false;
		canClickOpcoes = false;
		canClickCreditos = false;
		canClickParaIniciar = false;
		canPressEsc = false;

		txtsKIP.SetActive (false);

		voltar = false;
		goToOpcoes = false;
		goToCreditos = false;

		Time.timeScale = 1;

		inCut = false;

        GetComponent<AudioSource>().clip = music;
        GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		posicaoDoMouse = Input.mousePosition;
		posicaoRaio = cameraPrincipal.ScreenToWorldPoint(posicaoDoMouse);
		posicaoDoMouse.z += 1;
		direcaoRaio = cameraPrincipal.ScreenToWorldPoint(posicaoDoMouse) - posicaoRaio;

		if (Physics.Raycast (posicaoRaio, direcaoRaio, out hit, 1000f)) {
			Debug.DrawRay (posicaoRaio, direcaoRaio * 1000f, Color.red);

			if (hit.transform.gameObject == ray_click_para_iniciar && bt_click_para_iniciar.GetComponent<SpriteRenderer>().enabled == true) {
				canClickParaIniciar = true;
			}
			if (hit.transform.gameObject == ray_novo_jogo && bt_novo_jogo.GetComponent<SpriteRenderer>().enabled == true) {
				canClickNovoJogo = true;
			}

			if (hit.transform.gameObject == ray_opcoes && bt_opcoes.GetComponent<SpriteRenderer>().enabled == true) {
				canClickOpcoes = true;
			}

			if (hit.transform.gameObject == ray_creditos && bt_creditos.GetComponent<SpriteRenderer>().enabled == true) {
				canClickCreditos = true;
			}
		} else {
			canClickNovoJogo = false;
			canClickOpcoes = false;
			canClickCreditos = false;
		}

		if (canClickParaIniciar && Input.GetMouseButton (0)) {
			ray_click_para_iniciar.GetComponent<MeshCollider>().enabled = false;
			bt_click_para_iniciar.GetComponent<SpriteRenderer>().enabled = false;
			anim_click_para_iniciar.GetComponent<SpriteRenderer>().enabled = true;
			anim_click_para_iniciar.GetComponent<Animator>().enabled = true;
            Invoke("clickParaIniciar", 1);
			canClickParaIniciar = false;
		}

		if (canClickNovoJogo && Input.GetMouseButton (0)) {
			ray_novo_jogo.GetComponent<MeshCollider>().enabled = false;
			ray_opcoes.GetComponent<MeshCollider>().enabled = false;
			ray_creditos.GetComponent<MeshCollider>().enabled = false;
            bt_novo_jogo.GetComponent<SpriteRenderer>().enabled = false;
            anim_bt_novo_jogo.GetComponent<SpriteRenderer>().enabled = true;
            anim_bt_novo_jogo.GetComponent<Animator>().enabled = true;
            Invoke("CutsceneInicial", 1);
		}

		if (canClickOpcoes && Input.GetMouseButton (0)) {
			ray_novo_jogo.GetComponent<MeshCollider>().enabled = false;
			ray_opcoes.GetComponent<MeshCollider>().enabled = false;
			ray_creditos.GetComponent<MeshCollider>().enabled = false;
            bt_opcoes.GetComponent<SpriteRenderer>().enabled = false;
            anim_bt_opcoes.GetComponent<SpriteRenderer>().enabled = true;
            anim_bt_opcoes.GetComponent<Animator>().enabled = true;
            Invoke("ClickOpcoes", 1);
		}

		if (canClickCreditos && Input.GetMouseButton (0)) {
			ray_novo_jogo.GetComponent<MeshCollider>().enabled = false;
			ray_opcoes.GetComponent<MeshCollider>().enabled = false;
			ray_creditos.GetComponent<MeshCollider>().enabled = false;
            bt_creditos.GetComponent<SpriteRenderer>().enabled = false;
            anim_bt_creditos.GetComponent<SpriteRenderer>().enabled = true;
            anim_bt_creditos.GetComponent<Animator>().enabled = true;
            Invoke("ClickCreditos", 1);
		}

		if(inCut && Input.GetKeyDown(KeyCode.Escape)){
			ClickNovoJogo();
		}

		if (voltar) {
			opcoes.SetActive(false);
			creditos.SetActive(false);
			/*if (bkg_secundario.transform.position.y < 21.79f) {
				bkg_secundario.transform.Translate (0f, 0f, 4f);
			}
			if (opcoes.transform.position.y < 21.79f) {
				opcoes.transform.Translate (0f, 4f, 0f);
			}
			if (creditos.transform.position.y < 21.79f) {
				creditos.transform.Translate (0f, 4f, 0f);
			}
			if(bt_voltar.transform.position.y < 13.94f){
				bt_voltar.transform.Translate (0f, 4f, 0f);
			}
			if(creditos.transform.position.y >= 21.79f && opcoes.transform.position.y >= 21.79f && bkg_secundario.transform.position.y >= 21.79f && bt_voltar.transform.position.y >= 13.94f)
			{
				ray_novo_jogo.GetComponent<MeshCollider>().enabled = true;
				ray_opcoes.GetComponent<MeshCollider>().enabled = true;
				ray_creditos.GetComponent<MeshCollider>().enabled = true;
				ray_voltar.GetComponent<MeshCollider>().enabled = true;
				bt_sair.SetActive (true);
				voltar = false;
			}*/
		}

		if (goToOpcoes) {
			opcoes.SetActive(true);
			/*if (bkg_secundario.transform.position.y > 0f) {
				bkg_secundario.transform.Translate (0f, 0f, -2f);
				opcoes.transform.Translate (0f, -2f, 0f);
				bt_voltar.transform.Translate (0f, -2f, 0f);
			}
			else{
				goToOpcoes = false;
			}*/
		}
	}

	public void sair(){
		Application.Quit();
	}

	void pressEscape(){
		voltar = true;
		canPressEsc = false;
	}

    void CutsceneInicial() {
        cutScene.SetActive(true);
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = musicCutscene;
        GetComponent<AudioSource>().Play();
		bt_sair.SetActive (false);
		inCut = true;
		Cursor.visible = false; 
		txtsKIP.SetActive (true);
        Invoke("ClickNovoJogo", 17);
    }

	void ClickNovoJogo(){
		Cursor.visible = true; 
		Application.LoadLevel("Game");
	}

	void ClickOpcoes(){
		bt_novo_jogo.GetComponent<SpriteRenderer>().enabled = false;
		bt_opcoes.GetComponent<SpriteRenderer>().enabled = false;
		bt_creditos.GetComponent<SpriteRenderer>().enabled = false;
		goToOpcoes = true;
        anim_bt_opcoes.GetComponent<SpriteRenderer>().enabled = false;
        anim_bt_opcoes.GetComponent<Animator>().enabled = false;
		bt_sair.SetActive (false);
    }

	void ClickCreditos(){
		creditos.SetActive(true);
        bt_creditos.GetComponent<SpriteRenderer>().enabled = true;
        anim_bt_creditos.GetComponent<SpriteRenderer>().enabled = false;
        anim_bt_creditos.GetComponent<Animator>().enabled = false;
		bt_novo_jogo.GetComponent<SpriteRenderer>().enabled = false;
		bt_opcoes.GetComponent<SpriteRenderer>().enabled = false;
		bt_creditos.GetComponent<SpriteRenderer>().enabled = false;
		bt_sair.SetActive (false);
    }

	void clickParaIniciar(){
		bt_novo_jogo.GetComponent<SpriteRenderer>().enabled = true;
		bt_opcoes.GetComponent<SpriteRenderer>().enabled = true;
		bt_creditos.GetComponent<SpriteRenderer>().enabled = true;
		anim_click_para_iniciar.GetComponent<Animator>().enabled = false;
		anim_click_para_iniciar.GetComponent<SpriteRenderer>().enabled = false;
		bt_sair.SetActive (true);
	}

	public void LigarAudio(){
		xLigado.SetActive (true);
		xDesligado.SetActive (false);
		scriptAudio.ligado = true;
	}

	public void DesligarAudio(){
		xLigado.SetActive (false);
		xDesligado.SetActive (true);
		scriptAudio.ligado = false;
	}

	public void SairDeOpcoes(){
		goToOpcoes = false;
		opcoes.SetActive (false);
		ray_novo_jogo.GetComponent<MeshCollider>().enabled = true;
		ray_opcoes.GetComponent<MeshCollider>().enabled = true;
		ray_creditos.GetComponent<MeshCollider>().enabled = true;
		bt_novo_jogo.GetComponent<SpriteRenderer>().enabled = true;
		bt_opcoes.GetComponent<SpriteRenderer>().enabled = true;
		bt_creditos.GetComponent<SpriteRenderer>().enabled = true;
		bt_sair.SetActive (true);
	}

	public void SairDeCreditos(){
		goToCreditos = false;
		creditos.SetActive (false);
		ray_novo_jogo.GetComponent<MeshCollider>().enabled = true;
		ray_opcoes.GetComponent<MeshCollider>().enabled = true;
		ray_creditos.GetComponent<MeshCollider>().enabled = true;
		bt_novo_jogo.GetComponent<SpriteRenderer>().enabled = true;
		bt_opcoes.GetComponent<SpriteRenderer>().enabled = true;
		bt_creditos.GetComponent<SpriteRenderer>().enabled = true;
		bt_sair.SetActive (true);
	}
}
