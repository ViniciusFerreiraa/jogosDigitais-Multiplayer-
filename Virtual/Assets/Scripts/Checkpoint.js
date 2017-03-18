private	var _Player						: Player;
private	var _Save						: Save;
//private	var _Question					: Question;
private	var _Pause						: Pause;
private	var _OpenDoor					: OpenDoor;
static	var reset						: boolean;

private	var tCheckpoints				: GameObject;

static	var	whichCheck					: String;

static	var	whichReset					: String;

private	var initialPos					: Vector3;
private	var initialRot					: Vector3;
static	var checkpointPos				: Vector3;
static	var lastPos						: Vector3;

private	var keyHits						: int;

public var controle_mario				: GameObject;
public var controle_sonic				: GameObject;
public var controle_mega				: GameObject;

public var rend: Renderer;

function Start () 
{
	rend = GetComponent.<Renderer>();
//	tCheckpoints		= GameObject.Find("Checkpoints");
//	_Question			= GameObject.Find("Question").GetComponent(Question);
	whichCheck			= "";
	
	reset				= false;
	whichReset			= "InitialPos";
	
	initialPos			= GameObject.Find("RespawPlayer").transform.position;
	
	if (_Save.dificulty == "Hard")
	{
		tCheckpoints.SetActive(false);
	}
	
	//controle_mario.SetActive(false);
	//controle_mega.SetActive(false);
	//controle_sonic.SetActive(false);
}

function Update () 
{
	if (reset)
	{
		reset = false;
		
		if (whichReset == "InitialPos")
		{
			ResetToInitial();
		}
		
		//else if (whichReset == "CheckpointPos")
//		{
//			ResetToCheckpoint();
//		}
		
		else if (whichReset == "LastPos")
		{
			ResetToLast();
		}
		
		Time.timeScale = 1;
		this.transform.localScale = Vector3 (1.7, 1.7, 1);
	}
}

function ResetToInitial()
{
	for (var i:int = 1; i <= 6; i++)
	{
		if (Application.loadedLevelName.Contains(i.ToString()))
		{
			if (Application.loadedLevelName.Contains ("Mario"))
			{
				Application.LoadLevel("StageMario" + (i));
				return;
			}
			else if (Application.loadedLevelName.Contains ("Megaman"))
			{
				Application.LoadLevel("StageMegaman" + (i));
				return;
			}
			else if (Application.loadedLevelName.Contains ("Sonic"))
			{
				Application.LoadLevel("StageSonic" + (i));
				return;
			}
		}
	}
}


function ResetToLast()
{
	this.transform.position = lastPos;
	this.transform.position.z = -2;
}


function OnTriggerEnter ( other : Collider )
{
	if (other.transform.name == "Key")
	{
		Destroy (other.gameObject);

		if(Application.loadedLevelName.Contains ("StageMario"))
		{
			controle_mario.SetActive(true);
			controle_mario.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
		}
		if(Application.loadedLevelName.Contains ("StageMegaman"))
		{
			controle_mega.SetActive(true);
			controle_mega.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
		}
		if(Application.loadedLevelName.Contains ("StageSonic"))
		{
			controle_sonic.SetActive(true);
			controle_sonic.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
		}
		_OpenDoor.isOpen = true;
	}
}