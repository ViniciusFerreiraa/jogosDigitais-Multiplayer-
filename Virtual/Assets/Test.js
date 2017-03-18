public	var cAnimiator	: Animator;

function Start () 
{
	cAnimiator = this.transform.GetComponent(Animator);
}

function Update () 
{
	// down
	if (Input.GetKeyDown(KeyCode.S))
	{
		cAnimiator.SetInteger("DuckAnim", 3);
	}
	
	// left
	if (Input.GetKeyDown(KeyCode.A))
	{
		cAnimiator.SetInteger("DuckAnim", 1);
	}
	
	// jumpon
	if (Input.GetKeyDown(KeyCode.W))
	{
		cAnimiator.SetInteger("DuckAnim", 2);
	}
	
	// right
	if (Input.GetKeyDown(KeyCode.D))
	{
		cAnimiator.SetInteger("DuckAnim", 0);
	}
}