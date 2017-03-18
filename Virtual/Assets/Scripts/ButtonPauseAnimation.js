private	var thisScale				: Vector3;

private	var alphaControll			: boolean;

public var rend: Renderer;
function Start()
{
	rend = GetComponent.<Renderer>();
	alphaControll = false;
	thisScale = this.transform.localScale;
	this.transform.rend.material.color.a = 0.5;
	yield WaitForSeconds (5f);
	alphaControll = true;
	this.transform.rend.material.color.a = 1;
}

function OnMouseDown()
{
	if (!alphaControll)
		return;
	this.transform.localScale *= 1.2f;
}

function OnMouseUp()
{
	if (!alphaControll)
		return;
	this.transform.rend.material.color.a = 1;
	this.transform.localScale = thisScale;
}

function OnMouseEnter()
{	
	if (!alphaControll)
		return;
	this.transform.rend.material.color.a = 0.5;
}

function OnMouseExit()
{
	if (!alphaControll)
		return;
	this.transform.rend.material.color.a = 1;
}