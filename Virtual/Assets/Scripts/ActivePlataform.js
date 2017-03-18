static	var isGrounded		: boolean;

public var rend: Renderer;
function Start()
{
	rend = GetComponent.<Renderer>();
	isGrounded = false;
}

function OnTriggerStay ( other : Collider )
{
	if (other.transform.name.Contains ("Plataform") && isGrounded)
	{
		var Children = other.gameObject.GetComponentsInChildren(Transform);
		for (var child : Transform in Children)
		{
		    child.transform.rend.material.color.a = 0.5;
		}
	}
}

function OnTriggerExit ( other : Collider )
{
	if (other.transform.name.Contains ("Plataform"))
	{
		var Children = other.gameObject.GetComponentsInChildren(Transform);
		for (var child : Transform in Children)
		{
		    child.transform.rend.material.color.a = 1;
		}
	}
}