static public var pts		: int = 0;
private	var Pontos			: GameObject;
private var Pontos_Total	: GameObject;
private var Mostra_Pontos	: GameObject;
private	var pontos_tela		: GameObject;
private	var tDie			: GameObject;
public  var armadilha		: GameObject;

private var _pontosTotal	: ScoreTotal;
private	var _Pause			: Pause;
private var _timer			: Timer;

public var snd_pontos   	: AudioSource;

function Start ()
{
	tDie = GameObject.Find("Die");
	//tDie.transform.localPosition.y = 0;
	
	//tDie.SetActive		(false);
	//_Pause.died			= false;
}

function Update () 
{
	Pontos = GameObject.Find("Pontos");
	Pontos_Total = GameObject.Find("PontosTotal");
	Mostra_Pontos = GameObject.Find("Mostra_pts");
	pontos_tela = GameObject.Find("PontosTotal_tela");
	
	if (Application.loadedLevelName.Contains("Menu"))
	{
		_pontosTotal.scoreTotal = 0;
		Pontos_Total.GetComponent(TextMesh).text = _pontosTotal.scoreTotal.ToString("0");
	}
}

function OnTriggerEnter ( other : Collider )
{
	if (other.transform.name.Contains ("Points"))
	{
		snd_pontos.Play();
		_timer.seconds += 1;
		if(_timer.seconds >= 60)
		{
			_timer.minutes += 1;
			_timer.seconds = 1;
		}
		pts += 5;
		_pontosTotal.scoreTotal += 5;
		Pontos.GetComponent(TextMesh).text = pts.ToString("0");
		Mostra_Pontos.GetComponent(TextMesh).text = pts.ToString("0");
		Pontos_Total.GetComponent(TextMesh).text = _pontosTotal.scoreTotal.ToString("0");
		Destroy (other.gameObject);
	}
}