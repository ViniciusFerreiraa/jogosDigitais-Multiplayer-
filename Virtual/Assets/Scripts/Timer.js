private	var _Save			: Save;
private var _Armadilhas		: Armadilhas;

private	var timer			: GameObject;

static	var timeHolder		: int;

static	var minutes			: int;
static	var seconds			: int;

static	var time			: int;

private	var _Pause				: Pause;
//public	var tDie				: GameObject;

function Start()
{
	timeHolder = 1;
	
	//_Armadilhas.tDie.transform.localPosition.y = 0;
	
	//_Armadilhas.tDie.SetActive		(false);

	_Pause.died			= false;
		
	timer = GameObject.Find("Time");	
	time	= 60;
	
	minutes = timeHolder;
}

function Update()
{
	if (minutes >= 0)
	{
		if (seconds == 0 && minutes == 0)
		{
			_Pause.died = true;
			_Pause.morto = true;
			_Armadilhas.tDie.SetActive(true);
			Time.timeScale = 0;
		}
		
		else if (time == 0)
		{
			seconds--;
			time = 60;
		}	
			
		else if (seconds == 0)
		{
			minutes--;
			seconds = 59;
		}
		
		time -= 1 * Time.deltaTime;
	}
	timer.GetComponent(TextMesh).text = minutes.ToString("00") + ":" + seconds.ToString("00");
}

function Check()
{
	
}