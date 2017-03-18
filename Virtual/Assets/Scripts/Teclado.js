private	var _AnimationPause			: AnimationMovePlanes;
private var _score					: Score;
private var _scoreTotal				: ScoreTotal;

public var bt_Iniciar				: GameObject;
public var bt_Creditos				: GameObject;
public var bt_Instrucoes			: GameObject;
public var bt_Sair					: GameObject;
public var bt_Voltar				: GameObject;
public var bt_Voltar2				: GameObject;
public var bt_goToGame				: GameObject;
public var bt_goToGame2				: GameObject;

public var bonequinho_1				: Transform;
public var bonequinho_2				: Transform;
public var bonequinho_3				: Transform;
public var bonequinho_4				: Transform;

private var currentTime				: float;
private var currentSpeed			: float;
public var startPos					: float;
public var endPos					: float;

private var randomStage				: int;
static var selecionado				: int;

private	var currentControll			: String;

private var iniciar 				: boolean;
private var iniciar0 				: boolean;
private var creditos 				: boolean;
private var instrucoes 				: boolean;
private var menuPrincipal			: boolean = true;
private var mostrar_instrucoes		: boolean;
private var enterPressed			: boolean;
private var enterPressed2			: boolean;
private var mostInstru				: boolean;

private var instru2					: boolean = false;
private var credit2					: boolean = false;
private var instru3					: boolean = false;
private var credit3					: boolean = false;
private var podEntrar				: boolean = true;

public var snd_bt				   	: AudioSource;


private var rend: Renderer;

function Start ()
{
	currentSpeed = Mathf.Lerp(0, 20, (currentTime / 60));
	bt_goToGame.transform.localPosition.y = Mathf.Lerp(endPos, startPos, (currentTime / 60) * currentSpeed);
	
	bt_Voltar.SetActive(true);
	bt_goToGame2.SetActive(true);	
	selecionado = 0;


	rend = GetComponent.<Renderer>();
	//renderer.enabled = true;
}

function Update ()
{
	if(menuPrincipal)
	{
		if (Input.GetKeyUp("up"))
		{
			selecionado--;
			snd_bt.Play();
		}
		if(Input.GetKeyUp("down"))
		{
			selecionado++;
			snd_bt.Play();
		}
		if((Input.GetKeyDown("enter") || Input.GetKeyDown("return")) && podEntrar)
		{
			snd_bt.Play();
			bt_Voltar2.SetActive(true);
			if(selecionado == 0)
			{
				enterPressed = true;
				iniciar0 = true;
				bt_Voltar.SetActive(false);
				menuPrincipal = false;
				mostIntru = true;
			}
			if(selecionado == 1)
			{
				StartCoroutine(timer());
				creditos = true;
				credit3 = true;
				menuPrincipal = false;
			}
			if(selecionado == 2)
			{
				StartCoroutine(timer());
				instrucoes = true;
				instru3 = true;
				menuPrincipal = false;
			}
			if(selecionado == 3)
			{
				StartCoroutine(GameQuit());
				_AnimationPause.currentName2	= "Menu";
				menuPrincipal = false;
			}
		}
		
		if(selecionado > 3)
		{
			selecionado = 0;
		}
		if(selecionado < 0)
		{
			selecionado = 3;
		}
		
		if(selecionado == 0)
		{
			bt_Iniciar.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
			bt_Creditos.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
			bt_Instrucoes.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
			bt_Sair.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
			bonequinho_1.gameObject.SetActive(true);
			bonequinho_2.gameObject.SetActive(false);
			bonequinho_3.gameObject.SetActive(false);
			bonequinho_4.gameObject.SetActive(false);
		}
		if(selecionado == 1)
		{
			bt_Iniciar.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
			bt_Creditos.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
			bt_Instrucoes.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
			bt_Sair.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
			bonequinho_1.gameObject.SetActive(false);
			bonequinho_2.gameObject.SetActive(true);
			bonequinho_3.gameObject.SetActive(false);
			bonequinho_4.gameObject.SetActive(false);
		}
		if(selecionado == 2)
		{
			bt_Iniciar.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
			bt_Creditos.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
			bt_Instrucoes.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
			bt_Sair.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
			bonequinho_1.gameObject.SetActive(false);
			bonequinho_2.gameObject.SetActive(false);
			bonequinho_3.gameObject.SetActive(true);
			bonequinho_4.gameObject.SetActive(false);
		}
		if(selecionado == 3)
		{
			bt_Iniciar.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
			bt_Creditos.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
			bt_Instrucoes.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
			bt_Sair.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
			bonequinho_1.gameObject.SetActive(false);
			bonequinho_2.gameObject.SetActive(false);
			bonequinho_3.gameObject.SetActive(false);
			bonequinho_4.gameObject.SetActive(true);
		}
	}
	
	if(mostIntru)
	{
		currentControll = "Instructions";
		_AnimationPause.currentName		= "Instructions";
		_AnimationPause.currentName2	= "Menu";
		_AnimationPause.currentName3	= "";
		mostIntru = false;
	}
	
	if(iniciar0)
	{
		currentTime++;
		currentSpeed = Mathf.Lerp(0, 20, (currentTime / 60));
		bt_goToGame.transform.localPosition.y = Mathf.Lerp(endPos, startPos, (currentTime / 60) * currentSpeed);
		
		if(Input.GetKeyDown("enter") || Input.GetKeyDown("return") && !enterPressed)
		{
			snd_bt.Play();
			enterPressed2 = true;
			bt_goToGame2.SetActive(false);	
		}
		if(Input.GetKeyUp("enter") || Input.GetKeyUp("return") && enterPressed2)
		{
			snd_bt.Play();
			iniciar0 = false;
			iniciar = true;
		}
	}
	
	if(iniciar)
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
				if (i == 6)
				{
					Application.LoadLevel("NomeDaFase");
					return;
				}
				_scoreTotal.scoreTotal = 0;
				_score.pts = 0;				
				Application.LoadLevel(temp + (1 + i));
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
		iniciar = false;
	}

	if(creditos)
	{
		currentControll = "Credits";
		_AnimationPause.currentName		= "Credits";
		_AnimationPause.currentName2	= "Menu";
		_AnimationPause.currentName3	= "ButtonReturn";
		creditos = false;
	}
	
	if(instrucoes)
	{
		currentControll = "Instructions";
		_AnimationPause.currentName		= "Instructions";
		_AnimationPause.currentName2	= "Menu";
		_AnimationPause.currentName3	= "ButtonReturn";
		instrucoes = false;
	}
	
	if(Input.GetKeyDown("escape"))
	{
		snd_bt.Play();
		bt_Voltar2.SetActive(false);
	}
	
	if(Input.GetKeyUp("escape"))
	{
		snd_bt.Play();
		if(credit2)
		{
			StartCoroutine(timer2());
			_AnimationPause.currentName		= "Credits";
			_AnimationPause.currentName2	= "Menu";
			_AnimationPause.currentName3	= "ButtonReturn";
			menuPrincipal = true;
			credit2 = false;	
		}
		if(instru2)
		{
			StartCoroutine(timer2());
			_AnimationPause.currentName		= "Instructions";
			_AnimationPause.currentName2	= "Menu";
			_AnimationPause.currentName3	= "ButtonReturn";
			menuPrincipal = true;
			instru2 = false;
		}
	}
	
	if((Input.GetKeyDown("enter") || Input.GetKeyDown("return")))
	{
		snd_bt.Play();
		enterPressed = true;
	}
	if((Input.GetKeyUp("enter") || Input.GetKeyUp("return")))
	{
		snd_bt.Play();
		enterPressed = false;
	}
}

function GameQuit()
{
	yield WaitForSeconds (1f);
	Application.Quit();
}

function timer()
{
	yield WaitForSeconds (0.3f);
	podEntrar = false;
	if(credit3)
	{
		credit2 = true;
		credit3 = false;
	}
	
	if(instru3)
	{
		instru2 = true;
		instru3 = false;
	}
}

function timer2()
{
	yield WaitForSeconds (0.3f);
	podEntrar = true;
}