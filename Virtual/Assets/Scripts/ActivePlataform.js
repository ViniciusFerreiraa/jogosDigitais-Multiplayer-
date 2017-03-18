static	var isGrounded		: boolean;

function Start()
{
	isGrounded = false;
}

function OnTriggerStay ( other : Collider )
{
	if (other.transform.name.Contains ("Plataform") && isGrounded)
	{
		var Children = other.gameObject.GetComponentsInChildren(Transform);
		for (var child : Transform in Children)
		{
		    child.transform.renderer.material.color.a = 0.5;
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
		    child.transform.renderer.material.color.a = 1;
		}
	}
}