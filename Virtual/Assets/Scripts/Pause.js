private	var _Save						: Save;
private	var _Question					: Question;
private	var _Player						: Player;
private	var _Armadilha					: Armadilhas;
private	var _Checkpoint					: Checkpoint;
private	var _AnimationPause				: AnimationMovePlanes;
private var _Timer						: Timer;
private var _Score						: Score;
private var _ScoreTotal					: ScoreTotal;

private	var tPause						: GameObject;
private	var tInterface					: GameObject;
private	var tButtonMute					: GameObject;
private	var tButtonUnmute				: GameObject;
private	var tButtonMotionOn				: GameObject;
private	var tButtonMotionOff			: GameObject;
private	var tInterfaceKey				: GameObject;
private	var tButtonsToMove				: GameObject;

public var p_bt_select1					: GameObject;
public var p_bt_select2					: GameObject;
public var bt_select1					: GameObject;
public var bt_select2					: GameObject;

//temCerteza(false)
public var bt_sim						: GameObject;
public var bt_nao						: GameObject;
public var boneq_morte_vt_menu			: GameObject;
public var boneq_morte_Sim				: GameObject;

//temCerteza(true)
public var t_certeza_1					: GameObject;
public var t_certeza_2					: GameObject;
public var tc_bt_sim					: GameObject;
public var tc_bt_nao					: GameObject;
public var tc_boneco_sim				: GameObject;
public var tc_boneco_nao				: GameObject;
private var tem_certeza					: boolean;
private var podPrecionarEnter			: boolean;
static public var chamarContadorEnter	: boolean; 

static	var key							: boolean;
static	var died						: boolean;
static	var motion						: boolean;
private	var keyControll					: boolean;
private var pause						: boolean;
static var morto						: boolean;

private	var retryControll				: float;

private	var resetPos					: Vector3;
private	var resetRot					: Vector3;

private	var ray;
private	var fingerID3					: int;

private var selecionado					: int;
private var selecionado_died			: int;
private var selecionado_t_c				: int;

private var pausado						: boolean = true;



public var rend: Renderer;


function Awake()
{
	tPause				= GameObject.Find("Pause");
	tInterface			= GameObject.Find("Interface");
	tButtonMute 		= GameObject.Find("ButtonMute");
	tButtonUnmute 		= GameObject.Find("ButtonUnmute");
	tButtonMotionOn 	= GameObject.Find("ButtonMotionOn");
	tButtonMotionOff 	= GameObject.Find("ButtonMotionOff");
	tInterfaceKey		= GameObject.Find("InterfaceKey");
	tButtonsToMove		= GameObject.Find("ButtonsToMove");
}

function Start()
{	
	rend = GetComponent.<Renderer>();
	selecionado = 0;
	selecionado_died = 0;
	selecionado_t_c = 0;
	
	tem_certeza = false;
	podPrecionarEnter = false;
	chamarContadorEnter = false;
}


function Update()
{	
	if (keyControll && key)
	{
		tInterfaceKey.transform.rend.material.color.a = 1;
		keyControll = false;
	}

	if (_Player.fingerID1 == 1)
		fingerID = 0;
	else if (Input.touchCount == 1)
		fingerID = 1;
	else if (Input.touchCount == 2)
		fingerID = 2;
	
	if (Input.GetKey("r"))
	{
		retryControll++;
		if (retryControll > 90)
		{
			retryControll = 0;
			Retry();
		}
	}
	if (Input.GetKeyUp("r"))
	{
		retryControll = 0;
	}
	if (died)
	{
		if (_Save.dificulty == "Easy")
		{
			_Checkpoint.whichReset = "LastPos";
		}
		else if (_Save.dificulty == "Normal")
		{
			_Checkpoint.whichReset = "CheckpointPos";
		}
		else if (_Save.dificulty == "Hard")
		{
			_Checkpoint.whichReset = "InitialPos";
		}
	}
		
	if(!pause && !morto && pausado)
	{
		if(Input.GetKeyDown("escape"))
		{
			StartCoroutine(timer());
			_AnimationPause.currentName		= "Pause";
			pause = true;
			pausado = false;
		}
	}
	
	if(pause && !morto && pausado)
	{
		if(Input.GetKeyUp("up"))
		{
			selecionado--;		
		}
		if(Input.GetKeyUp("down"))
		{
			selecionado++;		
		}
		if(selecionado > 1)
			selecionado = 0;
		
		if(selecionado < 0)
			selecionado = 1;
			
		if(selecionado == 0)
		{
			p_bt_select1.SetActive(true);
			p_bt_select2.SetActive(false);
			bt_select1.SetActive(false);
			bt_select2.SetActive(true);
			if((Input.GetKey("return") || Input.GetKey("enter")))
			{
				StartCoroutine(timer());
				Time.timeScale 					= 1;
				_AnimationPause.currentName		= "Pause";
				pause = false;
				pausado = false;
			}
		}
		
		if(selecionado == 1)
		{
			p_bt_select1.SetActive(false);
			p_bt_select2.SetActive(true);
			bt_select1.SetActive(true);
			bt_select2.SetActive(false);
			if((Input.GetKey("return") || Input.GetKey("enter")))
			{
				Application.LoadLevel("Menu");
				Time.timeScale 					= 1;
				_AnimationPause.currentName		= "Pause";
				pause = false;
				pausado = false;
				_ScoreTotal.scoreTotal = 0;
				_Score.pts = 0;
			}
		}
	}
	
	if(chamarContadorEnter)
	{
		StartCoroutine(toEnter());
		chamarContadorEnter = false;	
	}
	
	
	if(morto && tem_certeza == false)
	{
		if(Input.GetKeyUp("left"))
		{
			selecionado_died--;
		}
		if(Input.GetKeyUp("right"))
		{
			selecionado_died++;
		}
		
		if(selecionado_died > 1)
			selecionado_died = 0;
		if(selecionado_died < 0)
			selecionado_died = 1;
			
		if(selecionado_died == 0)
		{
			bt_sim.SetActive(false);
			bt_nao.SetActive(true);
			boneq_morte_Sim.SetActive(true);
			boneq_morte_vt_menu.SetActive(false);
		}
		
		if(selecionado_died == 1)
		{
			bt_sim.SetActive(true);
			bt_nao.SetActive(false);
			boneq_morte_Sim.SetActive(false);
			boneq_morte_vt_menu.SetActive(true);
		}
		if(podPrecionarEnter)
		{
			if(Input.GetKey("return") || Input.GetKey("enter"))
			{
				if(selecionado_died == 0)
				{
					_ScoreTotal.scoreTotal -= _Score.pts;
					_Score.pts = 0;
					_Checkpoint.whichReset = "InitialPos";
					Retry();
					morto = false;
					pause = false;
					podPrecionarEnter = false;
					StartCoroutine(toEnter());
				}
				if(selecionado_died == 1)
				{
					tem_certeza = true;
					podPrecionarEnter = false;
					Time.timeScale = 1;
					StartCoroutine(toEnter());
				}
			}
		}
	}
	
	if(tem_certeza)
	{
		t_certeza_2.SetActive(true);
		if(Input.GetKeyUp("left"))
		{
			selecionado_t_c--;
		}
		if(Input.GetKeyUp("right"))
		{
			selecionado_t_c++;
		}
		
		if(selecionado_t_c > 1)
			selecionado_t_c = 0;
		if(selecionado_t_c < 0)
			selecionado_t_c = 1;
			
		if(selecionado_t_c == 0)
		{
			tc_bt_sim.SetActive(false);
			tc_bt_nao.SetActive(true);
			tc_boneco_sim.SetActive(true);
			tc_boneco_nao.SetActive(false);
		}
		
		if(selecionado_t_c == 1)
		{
			tc_bt_sim.SetActive(true);
			tc_bt_nao.SetActive(false);
			tc_boneco_sim.SetActive(false);
			tc_boneco_nao.SetActive(true);
		}
		
		if(podPrecionarEnter)
		{
			if(Input.GetKeyDown("return") || Input.GetKeyDown("enter"))
			{
				if(selecionado_t_c == 0)
				{
					tem_certeza = false;
					t_certeza_1.SetActive(true);
					_ScoreTotal.scoreTotal -= _Score.pts;
					_Score.pts = 0;
					morto = false;
					pause = false;
					Time.timeScale = 1;
					_Timer.timeHolder = 1;
					_Timer.time	= 60;
					_Timer.minutes = _Timer.timeHolder;
					_Timer.seconds = 0;
					_Armadilha.tDie.SetActive(false);
					died = false;
					podPrecionarEnter = false;
					Application.LoadLevel("Menu");
				}
				if(selecionado_t_c == 1)
				{
					tem_certeza = false;
					t_certeza_1.SetActive(true);
					Time.timeScale = 1;
					podPrecionarEnter = false;
					StartCoroutine(toEnter());
				}
			}
		}
	}
	else
	{
		t_certeza_2.SetActive(false);
		t_certeza_1.SetActive(false);
	}
}

function Retry()
{
	Time.timeScale = 1;
	_Timer.timeHolder = 1;
	_Timer.time	= 60;
	_Timer.minutes = _Timer.timeHolder;
	_Timer.seconds = 0;
	_Armadilha.tDie.SetActive(false);
	_Checkpoint.reset = true;
	died = false;
}

function timer()
{
	yield WaitForSeconds (0.3f);
	pausado = true;
	if(pause)
	{
		Time.timeScale = 0;			
	}
}

function toEnter()
{
	yield WaitForSeconds (0.3f);
	podPrecionarEnter = true;
	Time.timeScale = 0;
}