public	var grids	: GameObject[,];
public	var tGrid	: GameObject;

private	var baseX	: float = -16.89802;
private	var baseY	: float = -9.12021;
private	var multiply: float	= 1.7;
private	var tempX	: float;
private	var tempY	: float;

public	var lengthX	: int;
public	var lengthY	: int;

function Start () 
{
	tempX = 0;
	tempY = 0;
}

function Update () 
{
	if (Input.GetKeyDown(KeyCode.G))
	{
		for (var obj : Transform in this.transform)
		{
			Destroy(obj.gameObject);
		}
		tempY = baseY;
		CreateGrid ( lengthX, lengthY );
	}
}

function CreateGrid ( gridX : int, gridY : int )
{
	grids = new GameObject [ gridX, gridY ];
	
		
	for (var i : int = 0; i < gridY; i++)
	{
		tempX = baseX;
		if (i > 0)
			tempY += multiply;
		for (var j : int = 0; j < gridX; j++)
		{
			if (j > 0)
				tempX += multiply;
			
			grids[j, i] = Instantiate (tGrid, Vector3(tempX, tempY, 0), tGrid.transform.rotation);
			grids[j, i].transform.parent = this.transform;
		}
	}
}
