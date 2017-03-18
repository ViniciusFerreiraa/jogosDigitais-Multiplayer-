static	var whoIsOpen			: int;
static	var dificulty			: String;
private	var ray;


public	var tButtonContinue		: GameObject;
public	var tOptions			: GameObject;
public	var tDificulty			: GameObject;

function Start()
{
	tDificulty.transform.position.y = 0;
	tDificulty.SetActive(false);
	
	PlayerPrefs.SetInt("CurrentMapLvl", 0);
	whoIsOpen = PlayerPrefs.GetInt("Stages");
	if (whoIsOpen == 0)
		whoIsOpen = 1;
		
	whoIsOpen = 18;
}

function Update()
{
	if (whoIsOpen > 18)
		whoIsOpen = 18;

	if (whoIsOpen > 1)
	{
		tButtonContinue.transform.renderer.material.color.a = 1;
	}
	else
		tButtonContinue.transform.renderer.material.color.a = 0.5;
						
	#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBPLAYER
	if (Input.GetButtonUp ("MouseClick"))
	{
		ray 	= Camera.main.ScreenPointToRay (Input.mousePosition);
		Click();
	}
	#else
	if (Input.GetTouch(0).phase == TouchPhase.Ended)
	{
		ray		= Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
		Click();
	}
	#endif
}

function Save()
{
	PlayerPrefs.SetInt("Stages", whoIsOpen);
}

function Click()
{
	var hit		: RaycastHit;
	if (Physics.Raycast (ray, hit))
	{
		if (hit.collider.name.Contains ("ButtonContinue") && whoIsOpen > 1)
		{
			Application.LoadLevel("Menu");
//			dificulty = PlayerPrefs.GetString("Dificulty");
		}
		else if (hit.collider.name.Contains ("ButtonNewGame"))
		{
			whoIsOpen = 1;
			Application.LoadLevel("Menu");
//			tDificulty.SetActive(true);
//			tOptions.SetActive(false);			
		}
		else if (hit.collider.name.Contains ("ButtonDifculty"))
		{
			if (hit.collider.name.Contains ("Easy"))
			{
				PlayerPrefs.SetString("Dificulty", "Easy");
			}
			else if (hit.collider.name.Contains ("Normal"))
			{
				PlayerPrefs.SetString("Dificulty", "Normal");
			}
			else if (hit.collider.name.Contains ("Hard"))
			{
				PlayerPrefs.SetString("Dificulty", "Hard");
			}
			dificulty = PlayerPrefs.GetString("Dificulty");
			
			whoIsOpen = 1;
			Application.LoadLevel("Menu");
		}
	}
}