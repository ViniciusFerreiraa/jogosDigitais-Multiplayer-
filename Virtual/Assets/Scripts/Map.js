private	var _Save						: Save;

function Start()
{
	for (var i:int = 2; i <= _Save.whoIsOpen; i++)
	{
		var temp = GameObject.Find("ButtonBlockStage" + i);
		var temp2 = GameObject.Find("LineBlockStage" + i);
		
		if (temp != null)
		{	
			Destroy (temp.gameObject);
		}
		if (temp2 != null)
		{
			Destroy (temp2.gameObject);
		}
	}
}