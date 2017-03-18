private	var _SpritePlayer		: SpritePlayer;
private	var _Save				: Save;
public	var buttons				: GameObject;
public	var currentStage		: int;

private	var currentPos			: Vector3;
private	var targetPos			: Vector3;

private	var canMoveX			: boolean;
private	var canMoveY			: boolean;

private var rdn 				:int;
//private var num.Random;

private	var ray;

function Awake()
{
	#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBPLAYER
	//buttons.SetActive(false);
	#else
	buttons.SetActive(true);
	#endif
}

function Start()
{
	for (var i:int = 2; i <= _Save.whoIsOpen; i++)
	{
		var temp = GameObject.Find("ButtonBlockStage" + i);
		var temp2 = GameObject.Find("LineBlockStage" + i);
		
		if (temp != null)
		{	
			Destroy (temp.gameObject);
		}
		if (temp2 != null)
		{
			Destroy (temp2.gameObject);
		}
	}
	
	currentStage = PlayerPrefs.GetInt("CurrentMapLvl");
	if (currentStage == 0)
	{
		currentStage = 1;
	}
	Search();
	canMoveX = true;
	canMoveY = true;
	this.transform.localPosition.x = targetPos.x;
	this.transform.localPosition.y = (targetPos.y + 0.5);
}

function Update()
{
	currentPos = Vector3 (this.transform.position.x, this.transform.position.y, -7);
	
	if (canMoveX && canMoveY)
	{
		if (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			Enter();
		}
		
		if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
		{
			Down();
		}
	
		if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
		{
			Up();
		}
	
		if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
		{
			Right();
		}
		if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
		{
			Left();
		}
	}
	
	if (currentPos.x <= (targetPos.x + 0.1) && currentPos.x >= (targetPos.x - 0.1))
	{
		canMoveX = true;
	}
	if (currentPos.y <= (targetPos.y + 0.6) && currentPos.y >= (targetPos.y + 0.4))
	{
		canMoveY = true;
	}
	
	if (!canMoveX)
	{
		this.transform.localPosition.x = Mathf.Lerp(currentPos.x, targetPos.x, 0.1);
	}
	if (!canMoveY)
	{
		this.transform.localPosition.y = Mathf.Lerp(currentPos.y, (targetPos.y + 0.5), 0.1);
	}
	
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

function Click()
{
	var hit		: RaycastHit;
	if (Physics.Raycast (ray, hit))
	{
		if (hit.collider.name.Contains ("ButtonReturn"))
		{
			Application.LoadLevel("Menu");
		}
		
		if (canMoveX && canMoveY)
		{
			if (hit.collider.name.Contains ("Up"))
			{
				Up();
			}
			if (hit.collider.name.Contains ("Down"))
			{
				Down();
			}
			if (hit.collider.name.Contains ("Left"))
			{
				Left();
			}
			if (hit.collider.name.Contains ("Right"))
			{
				Right();
			}
			
			if (hit.collider.name.Contains ("ButtonStage"))
			{
				for (var i:int = 1; i <= 18; i++)
				{
					if (currentStage == i && hit.collider.name == "ButtonStage" + i.ToString())
					{
						PlayerPrefs.SetInt("CurrentMapLvl", currentStage);
						Application.LoadLevel("Stage" + i);
						return;
					}
				}
			}
		}
	}
}

function Search()
{
	canMoveX = false;
	canMoveY = false;
	for (var i:int = 1; i <= 18; i++)
	{
		if (currentStage == i)
		{
			var temp = GameObject.Find("ButtonStage" + i);
			targetPos.x = temp.transform.position.x;
			targetPos.y = temp.transform.position.y;
			return;
		}
	}
}

function Enter()
{

	//rdn = num.Next(3);
	for (var i:int = 1; i <= 18; i++)
	{
		if (currentStage == i)
		{
			PlayerPrefs.SetInt("CurrentMapLvl", currentStage);
			/*if(rdn == 1)
			{
				Application.LoadLevel("StageMario" + i);
			}
			if(rdn == 2)
			{
				Application.LoadLevel("StageMegaman" + i);
			}
			if(rdn == 3)
			{
				Application.LoadLevel("StageSonic" + i);
			}*/
			
			return;
		}
	}
}
function Right()
{
	if (currentStage == 18)
	{
		currentStage = 1;
	}

	else if (currentStage < 6 || (currentStage > 12 && currentStage < 18))
	{
		if (currentStage == _Save.whoIsOpen)
		{
			currentStage = 1;
		}
		else if (currentStage < _Save.whoIsOpen)
		{
			currentStage++;
		}
	}
	
	else if (currentStage < 13 && currentStage > 7)
	{
		currentStage--;
	}
	_SpritePlayer.flip = 1;
	Search();
}

function Left()
{
	if ((currentStage > 1 && currentStage < 7) || (currentStage > 13))
	{
		currentStage--;
		_SpritePlayer.flip = -1;
		
	}
	
	else if (currentStage > 6 && currentStage < 12)
	{
		if (currentStage == _Save.whoIsOpen)
		{
			currentStage = 1;
			_SpritePlayer.flip = 1;
		}
		else
		{
			currentStage++;
			_SpritePlayer.flip = -1;
		}
	}
	
	else if (currentStage == 1)
	{
		currentStage = _Save.whoIsOpen;
		_SpritePlayer.flip = -1;
	}
	Search();
}

function Up()
{
	if (currentStage == 7)
	{
		currentStage--;
		_SpritePlayer.flip = -1;
	}
	
	if (currentStage == 13)
	{
		currentStage--;
		_SpritePlayer.flip = 1;
	}
	
	Search();
}

function Down()
{
	if (currentStage == 6)
	{
		if (currentStage == _Save.whoIsOpen)
		{
			currentStage = 1;
			_SpritePlayer.flip = 1;
		}
		else if (currentStage < _Save.whoIsOpen)
		{
			currentStage++;
			_SpritePlayer.flip = -1;
		}
	}
	if (currentStage == 12)
	{
		if (currentStage == _Save.whoIsOpen)
		{
			currentStage = 1;
			_SpritePlayer.flip = 1;
		}
		else if (currentStage < _Save.whoIsOpen)
		{
			currentStage++;
			_SpritePlayer.flip = 1;
		}
	}
	
	Search();
}