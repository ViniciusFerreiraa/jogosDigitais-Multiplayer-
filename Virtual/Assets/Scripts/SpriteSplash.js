public	var uvAnimationTileX 		: int;										// número de colunas da sprite 
public	var uvAnimationTileY 		: int;										// número de linhas da sprite
public	var framesPerSecond 		: float;										// frames por segundo
public	var start					: boolean;


public var rend: Renderer;


function Start()
{
	rend = GetComponent.<Renderer>();
}

function Update () 
{
	if (start)
	{
		var index : int = Time.time * framesPerSecond;										// calcula o index: tempo por frames por segundos
		//var index : int = 1 * Time.deltaTime;
		index = index % (uvAnimationTileX * uvAnimationTileY);								// setando o index
		var size = Vector2 (1.0 / uvAnimationTileX, 1.0 / uvAnimationTileY);				// tamanho de cada tile
	 
		// divide os index verticais e horizontais
		var uIndex = index % uvAnimationTileX;
		var vIndex = index / uvAnimationTileX;
		
		var offset = Vector2 (uIndex * size.x, 1.0 - size.y - vIndex * size.y);				// criando o offset
	 
		rend.material.SetTextureOffset ("_MainTex", offset);							// setando offset da textura
		rend.material.SetTextureScale ("_MainTex", size);								// setando escada da textura
	}
	if (index == 6)
	{
		start = false;
		index = 0;
		offset.x = 0;
		rend.material.SetTextureOffset ("_MainTex", offset);
	}
}