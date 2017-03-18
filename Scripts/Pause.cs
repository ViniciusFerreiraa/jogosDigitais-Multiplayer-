using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

	public GameObject telaPause;
	public GameObject bt1;
	public GameObject bt2;

	private bool pauseGame;
	private bool showGUI;
	
	//public RawImage telaPause;
	
	// Use this for initialization
	void Start () {
		pauseGame = false;
		showGUI = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			pauseGame = !pauseGame;
			
			if(pauseGame == true){
				paused();
			}
			
			if(pauseGame == false){
				unPaused();
			}
		}
        if(showGUI == true)
        {
			telaPause.GetComponent<Image>().enabled = true;
			bt1.SetActive(true);
			bt2.SetActive(true);
            /*GameObject.Find("bt_continue").transform.position = new Vector2(718.5f, 201.9f);
            GameObject.Find("bt_menu_inicial").transform.position = new Vector2(718.5f, 137.5f);*/
        }
        else
        {
            telaPause.GetComponent<Image>().enabled = false;
			bt1.SetActive(false);
			bt2.SetActive(false);
			/*GameObject.Find("bt_continue").transform.position = new Vector2(0f, -1000f);
            GameObject.Find("bt_menu_inicial").transform.position = new Vector2(0f, -1000f);*/
        }
	}

	void paused(){
		Time.timeScale = 0;
		pauseGame = true;
		GameObject.Find("Player").GetComponent<MoveController>().enabled = false;
		showGUI = true;
	}

	void unPaused(){
		Time.timeScale = 1;
		pauseGame = false;
		GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
		showGUI = false;
	}

	public void continuar(){
		unPaused();
	}

	public void irParaMenu(){
		Application.LoadLevel ("Menu inicial");
	}
}