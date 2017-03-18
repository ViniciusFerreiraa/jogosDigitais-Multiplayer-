private	var _Checkpoint			: Checkpoint;
private	var _SpritePlayer		: SpritePlayer;
private	var _Save				: Save;
private	var _Pause				: Pause;
private	var _OpenDoor			: OpenDoor;
public	var tButtonsMove		: GameObject;

// variáveis de controle do player
public	var moveSpeed			: float;
public	var superSpeed			: float;										// velocidade atual (para troca entre walk/run/jump)
public	var jumpHeight			: float;											// pulo atual, para troca quando upgrade tiver liberado
public	var gravity				: float;											// gravidade
public	var maxTimePressing		: float;
public	var maxTimeAir			: float;
public	var tabletJump			: boolean;

// character controller
private var hitJumpForceDown	: float;											// forca aplicada quando hitar na "cabeça" do player
private	var velocity			: Vector3;											// 
static	var speedLerp 			: float;
private var currentTime			: float;
private	var timePressing		: float;
private	var canJump				: boolean;
private	var currentCollider		: String;

private var controller 			: CharacterController;
private	var ray1;
private	var ray2;

static	var questionOn			: boolean;

static	var fingerID1			: int;
static	var fingerID2			: int;

public var arrColisao			: Colisao[];

function Awake()
{
	fingerID1	= -1;
	fingerID2	= -1;
	questionOn	= false;
	
	#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBPLAYER
		//tButtonsMove.SetActive(false);
	#else
		tButtonsMove.SetActive(true);
		Input.multiTouchEnabled = true;
	#endif
	
	hitJumpForceDown	= 2;
	velocity			= Vector3.zero;
	speedLerp 			= 0.0;  
	
	controller = this.GetComponent (CharacterController);
	
	if (Application.loadedLevelName.Contains ("StageMario"))
	{
		controller.radius = arrColisao[0].playerRadius;
		controller.height = arrColisao[0].playerHeight;
		controller.center = arrColisao[0].playerCenter;
	}
	
	if (Application.loadedLevelName.Contains ("StageMegaman"))
	{
		controller.radius = arrColisao[1].playerRadius;
		controller.height = arrColisao[1].playerHeight;
		controller.center = arrColisao[1].playerCenter;
	}
	
	if (Application.loadedLevelName.Contains ("StageSonic"))
	{
		controller.radius = arrColisao[2].playerRadius;
		controller.height = arrColisao[2].playerHeight;
		controller.center = arrColisao[2].playerCenter;
	}
	
	timePressing 		= 0;
	canJump				= true;
}

class Colisao
{
	var name			: String;
	var playerRadius	: float;
	var playerHeight	: float;
	var playerCenter	: Vector3;
}

function Update()
{
	if (Application.loadedLevelName.Contains ("StageMario") || Application.loadedLevelName.Contains ("StageMegaman"))
	{
		superSpeed = 0;	
	}
	if ((Input.GetKey("space") || Input.GetKey("w") || Input.GetKey("up")))
	{
		Jump();
	}
	
	if (controller.isGrounded)
	{
		if (Input.GetKey("a") || Input.GetKey("left"))
		{
			MoveLeft();
			_SpritePlayer.spriteControll = "Walk";
		}
		
		else if (Input.GetKey("d") || Input.GetKey("right"))
		{
			MoveRight();
			_SpritePlayer.spriteControll = "Walk";
		}
		else
		{
			_SpritePlayer.spriteControll = "Idlle";
		}
	}
	if (!controller.isGrounded)
	{ 		
		if (Application.loadedLevelName.Contains ("StageSonic"))
		{
			//if (velocity.y > 1)
			//{
		//		_SpritePlayer.spriteControll = "JumpOn";
		//	}
			//if (velocity.y > 1)
		//	{
				_SpritePlayer.spriteControll = "JumpOff";
		//	}
		}
		else
		{
			_SpritePlayer.spriteControll = "JumpOn";
		}

		
		velocity.y -= gravity * Time.deltaTime;
		
		if (controller.collisionFlags == CollisionFlags.Above) 							// fazendo o player descer quando bater a cabeça
		{
			velocity.y 	= 0;
			velocity.y 	-= hitJumpForceDown;
			canJump		= false;
		}
			
		if (Input.GetKey("a") || Input.GetKey("left"))
		{
			MoveLeft();
		}
		
		else if (Input.GetKey("d") || Input.GetKey("right"))
		{
			MoveRight();
		}
	}
	
	if (controller.isGrounded)
	{
		timePressing 	= 0f;
		canJump			= true;
		
		if (velocity.y < -27 && currentCollider != "Water")
		{
			velocity.y = 0;
		}
		else if (velocity.y < -5)
		{
			velocity.y	= 0;
		}
		
		if ((velocity.y > -5 && velocity.y < 1) && Time.timeScale == 1)
		{
			_Checkpoint.lastPos = this.transform.position;
		}
		
		if (!Input.GetKey("a") && !Input.GetKey("left") && !Input.GetKey("d") && !Input.GetKey("right"))
		{
			_SpritePlayer.spriteControll = "Idlle";
		}
	}
	
	if (Input.GetKeyUp("w") || Input.GetKeyUp("up") || Input.GetKeyUp("space"))
	{
		JumpUp();
		
		if (Input.GetKey("a") || Input.GetKey("left"))
		{
			MoveLeft();
		}
		
		else if (Input.GetKey("d") || Input.GetKey("right"))
		{
			MoveRight();
		}
	}
	
	if (Input.GetKeyUp("d") || Input.GetKeyUp("right") || Input.GetKeyUp("a") || Input.GetKeyUp("left"))
	{
		MoveUp();
	}
	
	velocity.y -= gravity * Time.deltaTime;												// gravidade
	velocity.x = Mathf.Lerp(0, speedLerp, Time.time - currentTime);
	
	
	if(!Input.GetKey(KeyCode.LeftShift))
	{	
		velocity.x *= moveSpeed;
	}
	
	if (Application.loadedLevelName.Contains ("StageSonic"))
	{	
		if(Input.GetKey(KeyCode.LeftShift))
		{
			velocity.x *= superSpeed;
			_SpritePlayer.spriteControll = "Running";
		}
	}
	controller.Move (velocity * Time.deltaTime);										// movimento
}

function MoveLeft()
{
	//_SpritePlayer.spriteControll = "Walk";
	speedLerp	= -1;
	_SpritePlayer.flip = -10;	
}

function MoveRight()
{
	//_SpritePlayer.spriteControll = "Walk";
	speedLerp	= 1;
	_SpritePlayer.flip = 10;
}

function MoveUp()
{
	speedLerp	= 0;
}
function JumpUp()
{
	canJump		= false;
}

function Jump()
{
	if (timePressing < maxTimePressing && canJump)
	{
		if (velocity.y > maxTimeAir)
		{
			timePressing 	+= 1 * Time.deltaTime;
			velocity.y 		= jumpHeight;
		}
	}
}

function Click()
{
	if (ray1)
		var hit				: RaycastHit;
	if (ray2)
		var hit2			: RaycastHit;
		
	if (Physics.Raycast (ray1, hit) || Physics.Raycast (ray2, hit2))
	{
		if (hit.collider.name.Contains ("ButtonLeft"))
		{
			MoveLeft();
		}
		if (hit.collider.name.Contains ("ButtonRight"))
		{
			MoveRight();
		}
		if (!hit.collider.name.Contains ("ButtonLeft") && !hit.collider.name.Contains ("ButtonRight"))
		{
			MoveUp();
		}
		 
		if (hit.collider.name.Contains ("ButtonJump"))
		{
			Jump();
		}
	}
}