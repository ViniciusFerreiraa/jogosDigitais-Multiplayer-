function OnMouseDown()
{
	this.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
}

function OnMouseUp()
{
	this.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
}

function OnMouseEnter()
{
	this.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
}

function OnMouseExit()
{
	this.rend.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
}