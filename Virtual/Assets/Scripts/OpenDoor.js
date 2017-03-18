static	var isOpen					: boolean;
static  var abrir					:boolean;
abrir = true;
private	var velocity				: Vector2;

private	var thisTransformPos		: float;

function Awake() 
{
	isOpen = false;
	thisTransformPos = this.transform.position.y;
}

function Update()
{
	if (isOpen && abrir)
	{
		this.transform.position.y = Mathf.SmoothDamp (this.transform.position.y, this.transform.position.y + 0.3, velocity.y, 0.1);
	}
	
	if (this.transform.position.y >= thisTransformPos + 5)
	{
		abrir = false;
		//Destroy	(this.gameObject);
	}
}