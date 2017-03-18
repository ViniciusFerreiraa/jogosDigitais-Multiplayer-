using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HousesLife : MonoBehaviour {

	public float life;
	private GameObject BkgVida;

	// Use this for initialization
	void Start () {
		life = 100;
	}
	
	// Update is called once per frame
	void Update () {
		BkgVida = this.gameObject;
		BkgVida.GetComponent<Image> ().fillAmount = life / 100;
	}
}
