private var _score						: Score;
private var _scoreTotal					: ScoreTotal;
private var _Move_tela_pontos			: Move_tela_pontos;
private	var _AnimationPause				: AnimationMovePlanes;
private var _Timer						: Timer;

private var randomStage					: int;
private	var _OpenDoor					: OpenDoor;
private var respawPlayer				: GameObject;
public	var pontos						: GameObject;
public	var pontos_tela					: GameObject;
public	var timer_tela					: GameObject;
public  var enter						: GameObject;

private var player						: GameObject;

public var sonicSprite	 				: GameObject;
public var marioSprite 					: GameObject;
public var megamanSprite				: GameObject;

private	var tPassou						: GameObject;
private	var tInterface					: GameObject;
private	var tButtonMute					: GameObject;
private	var tButtonUnmute				: GameObject;
private	var tButtonMotionOn				: GameObject;
private	var tButtonMotionOff			: GameObject;
private	var tInterfaceKey				: GameObject;
private	var tButtonsToMove				: GameObject;
private var tPause						: GameObject;
private var Mostra_Pontos				: GameObject;

private var pod_avancar					: boolean;

private	var ray;

private var minutes						: int;
private var seconds						: int;
private var diminuiTimer				: boolean;
private var atualizaTimer				: boolean = true;

public var avancar						: boolean = false;

public var snd_pontos				   	: AudioSource;


function Start () 
{	
	pod_avancar = false;
	
	Mostra_Pontos = GameObject.Find("Mostra_pts");
	respawPlayer = GameObject.Find("RespawPlayer");
	player = GameObject.Find("Player");

	if (Application.loadedLevelName.Contains ("Mario"))
	{
		marioSprite.SetActive(true);
		sonicSprite.SetActive(false);
		megamanSprite.SetActive(false);
	}
	else if (Application.loadedLevelName.Contains ("Megaman"))
	{
		marioSprite.SetActive(false);
		sonicSprite.SetActive(false);
		megamanSprite.SetActive(true);
	}
	else if (Application.loadedLevelName.Contains ("Sonic"))
	{
		marioSprite.SetActive(false);
		sonicSprite.SetActive(true);
		megamanSprite.SetActive(false);
	}
	
	enter.SetActive(true);
}

function Awake()
{
	tPause				= GameObject.Find("Pause");
	tPassou				= GameObject.Find("Tela_pontos");
	tInterface			= GameObject.Find("Interface");
	tButtonMute 		= GameObject.Find("ButtonMute");
	tButtonUnmute 		= GameObject.Find("ButtonUnmute");
	tButtonMotionOn 	= GameObject.Find("ButtonMotionOn");
	tButtonMotionOff 	= GameObject.Find("ButtonMotionOff");
	tInterfaceKey		= GameObject.Find("InterfaceKey");
	tButtonsToMove		= GameObject.Find("ButtonsToMove");
}


function Update () 
{
	if(atualizaTimer)
	{
		minutes = _Timer.minutes;
		seconds = _Timer.seconds;
		pontos.GetComponent(TextMesh).text = _scoreTotal.scoreTotal.ToString("0");
		pontos_tela.GetComponent(TextMesh).text = _scoreTotal.scoreTotal.ToString("0");
		timer_tela.GetComponent(TextMesh).text = minutes.ToString("00") + ":" + seconds.ToString("00");
	}

	if (diminuiTimer)
	{
		if(minutes >= 0)
		{
			snd_pontos.Play();
			seconds--;
			_score.pts++;
			_scoreTotal.scoreTotal++;
			Mostra_Pontos.GetComponent(TextMesh).text = _score.pts.ToString("0");		
			pontos.GetComponent(TextMesh).text = _score.pts.ToString("0");
			pontos_tela.GetComponent(TextMesh).text = _scoreTotal.scoreTotal.ToString("0");
			
			if(seconds == 0)
			{
				if(minutes > 0)
				{
					minutes -= 1;
					seconds = 59;
				}
				if(minutes == 0)
				{
					if(seconds == 0)
					{
						minutes = 0;
						seconds = 0;
						diminuiTimer = false;
					}
				}
			}
		}
		else
		{
		
		}
		timer_tela.GetComponent(TextMesh).text = minutes.ToString("00") + ":" + seconds.ToString("00");
	}
	if(avancar)
	{		
		randomStage = Random.Range(1, 4);
		var temp : String;
		if (randomStage == 1)
		{
			temp = "StageMario";
		}
		else if (randomStage == 2)
		{
			temp = "StageMegaman";
		}
		else if (randomStage == 3)
		{
			temp = "StageSonic";
		}
		
		for	(var i:int = 1; i < 7; i++)
		{
			if (Application.loadedLevelName.Contains(i.ToString()))
			{
				_score = GameObject.Find("Player").GetComponent("Score");
				//_scoreTotal.scoreTotal += _score.pts;
				_score.pts = 0;		
				Mostra_Pontos.GetComponent(TextMesh).text = _score.pts.ToString("0");
				pontos.GetComponent(TextMesh).text = _score.pts.ToString("0");
				pontos_tela.GetComponent(TextMesh).text = _scoreTotal.scoreTotal.ToString("0");
				_AnimationPause.currentName		= "";
				Time.timeScale 					= 1;
				_Timer.timeHolder = 1;
				_Timer.time	= 60;
				_Timer.minutes = _Timer.timeHolder;
				_Timer.seconds = 0;
				//_Timer.minutes = 0;
				
				if (i == 6)
				{
					_scoreTotal.scoreTotal = 0;
					Application.LoadLevel("Menu");
					avancar = false;
					return;
				}
				Application.LoadLevel(temp + (1 + i));
				avancar = false;
				return;
			}
		}
		
		if (Application.loadedLevelName.Contains ("Stage"))
		{
		
		}
		else
		{
			Application.LoadLevel(temp + 1);
		}
	}
	
	if(pod_avancar)
	{
		if(Input.GetKeyDown("return") || Input.GetKeyDown("enter"))
		{
			enter.SetActive(false);
		}
		if(Input.GetKeyUp("return") || Input.GetKeyUp("enter"))
		{
			avancar = true;
		}
	}
}

function OnTriggerEnter ( other : Collider )
{
	if (other.transform.name == "DoorCollider" && _OpenDoor.isOpen)
	{
		_Move_tela_pontos.currentName = "Tela_pontos";
		_Move_tela_pontos.colidiu_porta = true;
		_score = GameObject.Find("Player").GetComponent("Score");
						
		Mostra_Pontos.GetComponent(TextMesh).text = _score.pts.ToString("0");
		pontos.GetComponent(TextMesh).text = _score.pts.ToString("0");
		pontos_tela.GetComponent(TextMesh).text = _scoreTotal.scoreTotal.ToString("0");
		Time.timeScale 					= 0;			
		//_AnimationPause.currentName		= "Pause";
		tPause.SetActive				(false);
		//tInterface.SetActive			(false);
		diminuiTimer = true;
		atualizaTimer = false;
		pod_avancar = true;
	}
}