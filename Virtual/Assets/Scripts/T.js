function Start () {

}

function Update () 
{
	this.transform.GetComponent(TextMesh).text = Input.acceleration.ToString();
}

function Awake()
{ 
	Input.multiTouchEnabled = true;
}


/*
//ARE YOU HOLDING DOWN ON A GUITEXTURE?
for (var touch : Touch in Input.touches) 
{
	if(touch.phase == TouchPhase.Stationary)
	{
		if(getGUI.GetScreenRect().Contains(touch.position) )
		{
			//PUT WHAT HAPPENS IF YOU HOLD THE BUTTON HERE
		}
	}
}//END TOUCH HOLD


//ARE YOU PUSHING DOWN ON A GUITEXTURE?
for (var touch : Touch in Input.touches) 
{
	if(touch.phase == TouchPhase.Began)
	{
		if(getGUI.GetScreenRect().Contains(touch.position) )
		{
			//PUT WHAT HAPPENS IF YOU PUSH DOWN BUTTON HERE
		}
	}
}//END TOUCH PUSHING DOWN
*/