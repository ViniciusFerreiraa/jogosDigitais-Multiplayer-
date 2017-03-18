public	var uvAnimationTileX 		: int;										// número de colunas da sprite 
public	var uvAnimationTileY 		: int;										// número de linhas da sprite
public	var framesPerSecond 		: float;										// frames por segundo

public	var anim1					: GameObject;
public	var anim2					: GameObject;
public	var anim3					: GameObject;

static	var index					: int;

static	var stop					: String;

static	var currentTime				: float;

function Awake()
{		
	if (this.transform.name == "BGMenuAnim1")
		stop = "BGMenuAnim1";
}

function Update () 
{	
	if (stop == this.transform.name)
	{
		currentTime += (Time.deltaTime * 1);
		
		index = currentTime * framesPerSecond;											// calcula o index: tempo por frames por segundos
		//var index : int = 1 * Time.deltaTime;
		index = index % (uvAnimationTileX * uvAnimationTileY);								// setando o index
		var size = Vector2 (1.0 / uvAnimationTileX, 1.0 / uvAnimationTileY);				// tamanho de cada tile
	 
		// divide os index verticais e horizontais
		var uIndex = index % uvAnimationTileX;
		var vIndex = index / uvAnimationTileX;
		
		var offset = Vector2 (uIndex * size.x, 1.0 - size.y - vIndex * size.y);					// criando o offset
	 
		renderer.material.SetTextureOffset ("_MainTex", offset);							// setando offset da textura
		renderer.material.SetTextureScale ("_MainTex", size);								// setando escada da textura
			
		if (index == 5)
		{		
			if (this.transform.name == "BGMenuAnim1")
			{
				stop = "BGMenuAnim2";
				anim2.SetActive(true);
			}
			else if (this.transform.name == "BGMenuAnim2")
			{
				stop = "BGMenuAnim3";
				anim3.SetActive(true);
			}
			this.gameObject.SetActive(false);
					
			currentTime = 0;
		}
	}
}