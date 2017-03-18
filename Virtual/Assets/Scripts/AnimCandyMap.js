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
private	var currentTime				: float;

private	var timer					: float;

private	var randomY					: float;

function Start()
{
	transformToMove = this.transform.gameObject;
	currentSpeed	= 0;
	status			= "MovingToEnd";
	timer			= -1;
	randomY = Random.Range(8, -8);
	this.transform.position.y = randomY;
}

function Update()
{
	currentPos = this.transform.position;
	
	/*if (timer > -1)
	{
		timer += 1 * Time.deltaTime;
		if (timer == 2)
		{
			timer = -1;
		}
		return;
	}*/
	
	if (moveX)
	{
		if (currentPos.x == endPos && status == "MovingToEnd")
		{
			status 		= "MovingToStart";
			currentTime	= 0;
			randomY = Random.Range(8, -8);
			this.transform.position.y = randomY;
		}
		else if (status == "MovingToEnd")
		{
			currentTime++;
			currentSpeed = Mathf.Lerp(startSpeed, endSpeed, (currentTime / 60));
			transformToMove.transform.position.x = Mathf.Lerp(startPos, endPos, (currentTime / 60) * currentSpeed);
		}
		
		if (currentPos.x == startPos && status == "MovingToStart")
		{
			status 		= "MovingToEnd";
			currentTime	= 0;
			randomY = Random.Range(8, -8);
			this.transform.position.y = randomY;
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
			status 		= "MovingToStart";
			currentTime	= 0;
		}
		else if (status == "MovingToEnd")
		{
			currentTime++;
			currentSpeed = Mathf.Lerp(startSpeed, endSpeed, (currentTime / 60));
			transformToMove.transform.position.y = Mathf.Lerp(startPos, endPos, (currentTime / 60) * currentSpeed);
		}
		
		if (currentPos.y == startPos && status == "MovingToStart")
		{
			status 		= "MovingToEnd";
			currentTime	= 0;
		}
		
		else if (status == "MovingToStart")
		{
			currentTime++;
			currentSpeed = Mathf.Lerp(startSpeed, endSpeed, (currentTime / 60));
			transformToMove.transform.position.y = Mathf.Lerp(endPos, startPos, (currentTime / 60) * currentSpeed);
		}
	}
}