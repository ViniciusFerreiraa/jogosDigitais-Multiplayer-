﻿private	var _OpenDoor			: OpenDoor;

public	var whoBeguin					: String;

static	var currentPress				: String;

private	var arBlue;
private	var arRed;
private	var arYellow;
private	var arSiBlue;
private	var arSiRed;
private	var arSiYellow;

private	var arButBlue;
private	var arButRed;
private	var arButYellow;

private	var currentObject				: GameObject;
private var player						: GameObject;

function Start()
{
	player = GameObject.Find("Player");

	arBlue		= GameObject.FindGameObjectsWithTag ("Blue");
	arRed		= GameObject.FindGameObjectsWithTag ("Red");
	arYellow	= GameObject.FindGameObjectsWithTag ("Yellow");
	
	arSiBlue	= GameObject.FindGameObjectsWithTag ("SiBlue");
	arSiRed		= GameObject.FindGameObjectsWithTag ("SiRed");
	arSiYellow	= GameObject.FindGameObjectsWithTag ("SiYellow");
	
	arButBlue	= GameObject.FindGameObjectsWithTag ("BBlue");
	arButRed	= GameObject.FindGameObjectsWithTag ("BRed");
	arButYellow	= GameObject.FindGameObjectsWithTag ("BYellow");
	
	if (whoBeguin != "")
	{
		currentPress= whoBeguin;
		return;
	}
	currentPress = "RGB";
	Change();
}

function Update()
{
	if (currentPress != "")
	{
		Change();
		currentPress = "";
	}
}


function OnTriggerEnter ( other : Collider )
{
	if (other.transform.name == "Player" && currentPress != "Blue")
	{
		currentPress = "Blue";
	}
	else if (other.transform.name == "ButtonRed" && currentPress != "Red")
	{
		currentPress = "Red";
	}
	else if (other.transform.name == "ButtonYellow" && currentPress != "Yellow")
	{
		currentPress = "Yellow";
	}
	
	/*if (other.transform.name == "DoorCollider" && _OpenDoor.isOpen)
	{
		currentObject.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
		currentObject.collider.isTrigger = true;
		for (var tempButBlue:GameObject in arButBlue)
		{
			tempButBlue.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
		}
		
		for (var tempButYellow:GameObject in arButYellow)
		{
			tempButYellow.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
		}
	
		for (var tempButRed:GameObject in arButRed)
		{
			tempButRed.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
		}
	}*/
}


function Change()
{
	ActiveBlue();
	ActiveRed();
	ActiveYellow();
	ActiveSiBlue();
	ActiveSiRed();
	ActiveSiYellow();
	ActiveButtonBlue();
	ActiveButtonRed();
	ActiveButtonYellow();
	
	if (currentPress == "RGB")
	{
		DeactiveBlue();
		DeactiveRed();
		DeactiveYellow();
	}
	else if (currentPress == "Blue")
	{
		DeactiveButtonBlue();
		DeactiveRed();
		DeactiveYellow();
		DeactiveSiBlue();
	}
	else if (currentPress == "Red")
	{
		DeactiveButtonRed();
		DeactiveBlue();
		DeactiveYellow();
		DeactiveSiRed();
	}
	else if (currentPress == "Yellow")
	{
		DeactiveButtonYellow();
		DeactiveBlue();
		DeactiveRed();
		DeactiveSiYellow();
	}
}

function Active()
{
	currentObject.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
	currentObject.collider.isTrigger = false;
}

function Deactive()
{
	currentObject.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
	currentObject.collider.isTrigger = true;
}

// ---------- BUTTONS ---------
function ActiveButtonBlue()
{
	for (var tempButBlue:GameObject in arButBlue)
	{
		tempButBlue.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
	}
}
function ActiveButtonRed()
{
	for (var tempButRed:GameObject in arButRed)
	{
		tempButRed.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
	}
}
function ActiveButtonYellow()
{
	for (var tempButYellow:GameObject in arButYellow)
	{
		tempButYellow.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
	}
}
// deactive //
function DeactiveButtonBlue()
{
	for (var tempButBlue:GameObject in arButBlue)
	{
		tempButBlue.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
	}
}
function DeactiveButtonRed()
{
	for (var tempButRed:GameObject in arButRed)
	{
		tempButRed.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
	}
}
function DeactiveButtonYellow()
{
	for (var tempButYellow:GameObject in arButYellow)
	{
		tempButYellow.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
	}
}


// ---------- ACTIVE ----------
function ActiveBlue()
{
	for (var tempBlue in arBlue)
	{
		currentObject = tempBlue;
		Active();
	}
}

function ActiveRed()
{
	for (var tempRed in arRed)
	{
		currentObject = tempRed;
		Active();
	}
}

function ActiveYellow()
{
	for (var tempYellow in arYellow)
	{
		currentObject = tempYellow;
		Active();
	}
}

function ActiveSiBlue()
{
	for (var tempSiBlue in arSiBlue)
	{
		currentObject = tempSiBlue;
		Active();
	}
}

function ActiveSiRed()
{
	for (var tempSiRed in arSiRed)
	{
		currentObject = tempSiRed;
		Active();
	}
}

function ActiveSiYellow()
{
	for (var tempSiYellow in arSiYellow)
	{
		currentObject = tempSiYellow;
		Active();
	}
}

// ---------- DEACTIVE ----------
function DeactiveBlue()
{
	for (var tempBlue in arBlue)
	{
		currentObject = tempBlue;
		Deactive();
	}
}

function DeactiveRed()
{
	for (var tempRed in arRed)
	{
		currentObject = tempRed;
		Deactive();
	}
}

function DeactiveYellow()
{
	for (var tempYellow in arYellow)
	{
		currentObject = tempYellow;
		Deactive();
	}
}

function DeactiveSiBlue()
{
	for (var tempSiBlue in arSiBlue)
	{
		currentObject = tempSiBlue;
		Deactive();
	}
}

function DeactiveSiRed()
{
	for (var tempSiRed in arSiRed)
	{
		currentObject = tempSiRed;
		Deactive();
	}
}

function DeactiveSiYellow()
{
	for (var tempSiYellow in arSiYellow)
	{
		currentObject = tempSiYellow;
		Deactive();
	}
}