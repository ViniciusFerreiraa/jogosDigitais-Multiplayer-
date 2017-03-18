// Script: Main Camera
// Scene: Loading

private var cameraTarget			: GameObject;					//	objeto que será seguido
private var player					: GameObject;					//	objeto do player para mover

private	var statusX					: String;
private	var statusY					: String;
private	var isFollowX				: boolean;						//	camera segue na horizontal (x)
private	var isFollowY				: boolean;						//	camera segue na vertical (y)
private	var velocity				: Vector2;						//	velocidade de movimento da camera (vector2 porque só usa X e Y)

public	var smoothTime				: float;
public	var cameraFollowX			: boolean;
public	var cameraFollowY			: boolean;

public	var posBot					: float;
public	var posTop					: float;
public	var posLeft					: float;
public	var posRight				: float;

public	var cameraHeight			: float;
public	var cameraLength			: float;

private	var thisTrans				: Vector2;

function Start()
{

	player = GameObject.Find("Player");
	cameraTarget = GameObject.Find("CameraTarget");
	
	isFollowX = false;
	isFollowY = false;
	if (cameraFollowX)
	{
		if (this.transform.position.x == posLeft)
		{
			statusX = "StoppedLeft";
		}
		else if (this.transform.position.x == posRight)
		{
			statusX = "StoppedRight";
		}
		else
		{
			statusX = "Moving";
			isFollowX = true;
		}
	}
	if (cameraFollowY)
	{
		if (this.transform.position.y == posBot)
		{
			statusY = "StoppedBot";
		}
		else if (this.transform.position.y == posTop)
		{
			statusY = "StoppedTop";
		}
		else
		{
			statusY = "Moving";
			isFollowY = true;
		}
	}
	if (!cameraFollowX && !cameraFollowY)
	{
		statusY = "";
	}
}

function Update () 
{	
	// -------------------- X --------------------
	if (this.transform.position.x <= posLeft && statusX == "Moving")
	{
		statusX = "StoppedLeft";
		isFollowX = false;
	}
	else if (this.transform.position.x >= posRight && statusX == "Moving")
	{
		statusX = "StoppedRight";
		isFollowX = false;
	}
	else if (player.transform.position.x >= (posLeft + cameraLength) && statusX == "StoppedLeft")
	{
		statusX = "Moving";
		isFollowX = true;
	}
	else if (player.transform.position.x <= (posRight - cameraLength) && statusX == "StoppedRight")
	{
		statusX = "Moving";
		isFollowX = true;
	}	
	
	if (isFollowX)
	{
		this.transform.position.x = Mathf.SmoothDamp (this.transform.position.x, cameraTarget.transform.position.x, velocity.x, smoothTime);
	}
	
	// -------------------- Y --------------------
	if (this.transform.position.y <= posBot && statusY == "Moving")
	{
		statusY = "StoppedBot";
		isFollowY = false;
		
		if (this.transform.position.y < posBot)
		{
			this.transform.position.y = posBot;
		}
	}
	else if (player.transform.position.y >= (posBot + cameraHeight) && statusY == "StoppedBot")
	{
		statusY = "Moving";
		isFollowY = true;
	}
	
	if (this.transform.position.y >= posTop && statusY == "Moving")
	{
		statusY = "StoppedTop";
		isFollowY = false;
	}

	else if (player.transform.position.y <= (posTop - cameraHeight) && statusY == "StoppedTop")
	{
		statusY = "Moving";
		isFollowY = true;
	}	
	
	if (isFollowY)
	{
		this.transform.position.y = Mathf.SmoothDamp (this.transform.position.y, cameraTarget.transform.position.y, velocity.y, smoothTime);
	}
}