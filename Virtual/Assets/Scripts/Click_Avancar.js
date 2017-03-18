private var _RandonLvl 				: RandomLvl;
public	var buttonAnim				: Transform;

public var rend: Renderer;
function Start()
{
	rend = GetComponent.<Renderer>();
	buttonAnim = this.transform.Find("ButtonAnim");
	buttonAnim.gameObject.SetActive(false);
}

function OnMouseDown()
{
	this.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
	_RandonLvl.avancar = true;
}

function OnMouseUp()
{
	this.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
	buttonAnim.gameObject.SetActive(false);
}

function OnMouseEnter()
{
	this.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
	buttonAnim.gameObject.SetActive(true);
}

function OnMouseExit()
{
	buttonAnim.gameObject.SetActive(false);
	this.rend.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
}