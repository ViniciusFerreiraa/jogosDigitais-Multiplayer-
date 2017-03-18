private	var _Pause				: Pause;
//public var armadilha			: GameObject;
static	var tDie				: GameObject;

function Start ()
{

	tDie = GameObject.Find("Die");
	tDie.transform.localPosition.y = 0;
	
	tDie.SetActive		(false);

	_Pause.died			= false;
}

function Update () {
	
}

function OnTriggerEnter ( other : Collider )
{
	if (other.transform.name.Contains ("Armadilha"))
	{
		_Pause.died = true;
		_Pause.morto = true;
		_Pause.chamarContadorEnter = true;
		tDie.SetActive(true);
		//Time.timeScale = 0;
	}
}