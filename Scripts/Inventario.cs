using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventario : MonoBehaviour {

	public int gold;
	public int arma;
	public int pocoesVida;
	public int pocoesMana;
	public int sementeCeva;
	public int sementeBacon;
    public int level;
	
	public float vida;
	public float mana;

	public bool itemSuborno;
	public bool poder_1_Ok;
	public bool poder_2_Ok;

	public Text vidaText;
	public Text manaText;
	public Text potionVidaText;
	public Text potionManaText;
	public Text goldText;
	public GameObject BkgMana, BkgVida;

	public bool MatouGuarda;
	// Use this for initialization
	void Start () {

		gold = 100;
		vida = 100;
		mana = 100;
		arma = 0;
		pocoesVida = 0;
		pocoesMana = 0;
		MatouGuarda = false;
		itemSuborno = false;
		level = 1;
	}

	// Update is called once per frame
	void Update () {
		BkgMana.GetComponent<Image> ().fillAmount = mana / 100;
		BkgVida.GetComponent<Image> ().fillAmount = vida / 100;

		vidaText.GetComponent<Text>().text = vida.ToString ();
		manaText.GetComponent<Text>().text = mana.ToString ();
		potionVidaText.GetComponent<Text>().text = pocoesVida.ToString ();
		potionManaText.GetComponent<Text>().text = pocoesMana.ToString ();
		goldText.GetComponent<Text>().text = gold.ToString ();

		if (arma == 1) {
			//animacao jogador com arma 1
			//acoes  arma 1
		}

		if (arma == 2) {
			//animacao jogador com arma 2
			//acoes  arma 2
		}
	}
}
