function OnMouseDown()
{
	this.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
}

function OnMouseUp()
{
	this.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
}

function OnMouseEnter()
{
}

function OnMouseExit()
{
	this.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0, 0));
}