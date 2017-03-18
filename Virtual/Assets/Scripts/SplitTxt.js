function ResolveTextSize(input : String, lineLength : int)
{
	var words	: String[] = input.Split(" "[0]);
	
	var result	: String = "";
	var line	: String = "";
	
	for (var s:String in words)
	{
		var temp : String = line + " " + s;
		
		if(temp.Length > lineLength)
		{		
			// Append current line into result
			result += line + "\n";
			// Remain word append into new line
			line = s;
		}
		// Append current word into current line
		else 
		{
			line = temp;
		}
	}
	result += line;
	
	this.transform.GetComponent(TextMesh).text = result;
	return result.Substring ( 1, result.Length - 1 );
}