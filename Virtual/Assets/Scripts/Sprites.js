public	var uvAnimationTileX 		: int;										// número de colunas da sprite 
public	var uvAnimationTileY 		: int;										// número de linhas da sprite
public	var framesPerSecond 		: float;										// frames por segundo


public var rend: Renderer;

function Start()
{

	rend = GetComponent.<Renderer>();
	if (this.transform.name == "ButtonAnim_Não" || this.transform.name == "ButtonAnim_Não" || this.transform.name == "ButtonAnim")
	{
		uvAnimationTileX	= 1;
		uvAnimationTileY	= 1;
		framesPerSecond		= 1;
	}
}

function Update () 
{
		var index : int = Time.time * framesPerSecond;										// calcula o index: tempo por frames por segundos
		//var index : int = 1 * Time.deltaTime;
		index = index % (uvAnimationTileX * uvAnimationTileY);								// setando o index
		var size = Vector2 (1.0 / uvAnimationTileX, 1.0 / uvAnimationTileY);				// tamanho de cada tile
	 
		// divide os index verticais e horizontais
		//var uIndex = index % uvAnimationTileX;
		//var vIndex = index / uvAnimationTileX;
		
		//var offset = Vector2 (uIndex * size.x, 1.0 - size.y - vIndex * size.y);				// criando o offset
	 
		//renderer.material.SetTextureOffset ("_MainTex", offset);							// setando offset da textura
		rend.material.SetTextureScale ("_MainTex", size);								// setando escada da textura
}