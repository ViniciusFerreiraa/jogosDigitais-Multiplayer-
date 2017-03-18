public	var transformToMove			: GameObject;
public	var startSpeed				: float;
public	var endSpeed				: float;
private	var startTime				: float;
private	var currentSpeed			: float;

private	var currentPos				: Vector3;
public	var startPos				: float;
public	var endPos					: float;

public	var moveX					: boolean;
public	var moveY					: boolean;

private	var status					: String;
static	var currentName				: String;
static	var currentName2			: String;
static	var currentName3			: String;
private	var currentTime				: float;



function Start()
{
	transformToMove = this.transform.gameObject;
	currentSpeed	= 0;
	status			= "StoppedStart";
}

function Update()
{
	if (currentName != this.transform.name && currentName2 != this.transform.name && currentName3 != this.transform.name)
	{
		return;
	}
	else
	{
		if (status == "StoppedStart")
		{
			status = "MovingToEnd";
		}
		else if (status == "StoppedEnd")
		{
			status = "MovingToStart";
		}
	}
	
	currentPos = this.transform.position;
	
	if (moveX)
	{
		if (currentPos.x == endPos && status == "MovingToEnd" && status != "StoppedStart")
		{
			status 		= "StoppedEnd";
			currentTime	= 0;
			NameVerify();
		}
		else if (currentPos.x == startPos && status == "MovingToStart" && status != "StoppedEnd")
		{
			status 		= "StoppedStart";
			currentTime	= 0;
			NameVerify();
		}
		else if (status == "MovingToEnd")
		{
			currentTime++;
			currentSpeed = Mathf.Lerp(startSpeed, endSpeed, (currentTime / 60));
			transformToMove.transform.position.x = Mathf.Lerp(startPos, endPos, (currentTime / 60) * currentSpeed);
		}
		else if (status == "MovingToStart")
		{
			currentTime++;
			currentSpeed = Mathf.Lerp(startSpeed, endSpeed, (currentTime / 60));
			transformToMove.transform.position.x = Mathf.Lerp(endPos, startPos, (currentTime / 60) * currentSpeed);
		}
	}
	
	if (moveY)
	{
		if (currentPos.y == endPos && status == "MovingToEnd")
		{
			status 		= "StoppedEnd";
			currentTime	= 0;
			NameVerify();
		}
		else if (status == "MovingToEnd")
		{
			currentTime++;
			currentSpeed = Mathf.Lerp(startSpeed, endSpeed, (currentTime / 60));
			transformToMove.transform.position.y = Mathf.Lerp(startPos, endPos, (currentTime / 60) * currentSpeed);
		}
		
		if (currentPos.y == startPos && status == "MovingToStart")
		{
			status 		= "StoppedStart";
			currentTime	= 0;
			NameVerify();
		}
		
		else if (status == "MovingToStart")
		{
			currentTime++;
			currentSpeed = Mathf.Lerp(startSpeed, endSpeed, (currentTime / 60));
			transformToMove.transform.position.y = Mathf.Lerp(endPos, startPos, (currentTime / 60) * currentSpeed);
		}
	}
}

function NameVerify()
{
	if (this.transform.name == currentName)
	{
		currentName = "";
	}
	else if (this.transform.name == currentName2)
	{
		currentName2 = "";
	}
	else if (this.transform.name == currentName3)
	{
		currentName3 = "";
	}
}