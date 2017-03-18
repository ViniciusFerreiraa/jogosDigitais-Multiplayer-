private	var _Player		: Player;
private	var tPlayer		: GameObject;
private	var thisObject	: String;
private	var move		: boolean;

static	var question	: boolean;

public	var teste:GameObject;

#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBPLAYER

#else
function Start()
{
	question = false;
	
	Input.multiTouchEnabled = true;
	tPlayer = GameObject.Find("Player");
	_Player = tPlayer.GetComponent(Player);
	/*
	if (this.transform.name == "ButtonRight")
		thisObject = "Right";
	if (this.transform.name == "ButtonLeft")
		thisObject = "Left";
	*/
	if (this.transform.name == "ButtonJump")
		thisObject = "Jump";
}

function Update()
{		
	if (move)
	{
		if (thisObject == "Right")
		{
			_Player.MoveRight();
		}
		if (thisObject == "Left")
		{
			_Player.MoveLeft();
		}
		if (thisObject == "Jump")
		{
			_Player.Jump();
		}
	}
}

function OnMouseDown()
{
	move = true;
}
function OnMouseUp()
{
	move = false;
	Exit();	
}
function OnMouseExit()
{
	move = false;
	Exit();	
}

function Exit()
{
	if (thisObject == "Right" || thisObject == "Left")
	{
		_Player.MoveUp();
	}
	if (thisObject == "Jump")
	{
		_Player.JumpUp();
	}
}
#endif