private var _RandonLvl 				: RandomLvl;
public	var buttonAnim				: Transform;

function Start()
{
	buttonAnim = this.transform.Find("ButtonAnim");
	buttonAnim.gameObject.SetActive(false);
}

function OnMouseDown()
{
	this.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
	_RandonLvl.avancar = true;
}

function OnMouseUp()
{
	this.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
	buttonAnim.gameObject.SetActive(false);
}

function OnMouseEnter()
{
	this.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
	buttonAnim.gameObject.SetActive(true);
}

function OnMouseExit()
{
	buttonAnim.gameObject.SetActive(false);
	this.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
}