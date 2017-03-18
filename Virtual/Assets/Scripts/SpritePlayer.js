public	var cAnimator			: Animator;
static	var spriteControll		: String;
static	var flip				: float;
public	var thisScale			: Vector2;


function Start()
{
	if (Application.loadedLevelName.Contains("Stage"))
	{
		thisScale.x = 6.1446;
		thisScale.y = 6.1446;
	}
	
	cAnimator = this.transform.GetComponent(Animator);
	flip = this.transform.localScale.x;
	if (Application.loadedLevelName.Contains ("StageSonic"))
	{
		spriteControll = "Idlle";
	}
	if (Application.loadedLevelName.Contains ("StageMario"))
	{
		spriteControll = "Idle_Mario";
	}
}

function Update () 
{
	if (Time.timeScale != 0)
	{	
		if (Application.loadedLevelName.Contains ("StageSonic"))
		{
			if (spriteControll == "Idlle")
			{
				cAnimator.SetInteger("SonicAnim", 1);
				cAnimator.SetTrigger("Idle");
			}
			
			if (spriteControll == "Walk")
			{
				cAnimator.SetInteger("SonicAnim", 2);
			}
			
			if (spriteControll == "Running")
			{
						cAnimator.SetInteger("SonicAnim", 3);
			}
			
 			if (spriteControll == "JumpOn")
 			{
 				cAnimator.SetInteger("SonicAnim", 4);
			}
			
	 		else if (spriteControll == "JumpOff")
	 		{
	 			cAnimator.SetInteger("SonicAnim", 5);
	 		}
		}
		
		if (Application.loadedLevelName.Contains ("StageMegaman"))
		{
			if (spriteControll == "Idlle")
			{
				cAnimator.SetInteger("MegaAnim", 1);
				cAnimator.SetTrigger("Idle");
			}
			if (spriteControll == "Walk")
			{
				cAnimator.SetInteger("MegaAnim", 5);
			}
			if (spriteControll == "JumpOn" || spriteControll == "JumpOff")
				cAnimator.SetInteger("MegaAnim", 2);
		}
		
		if (Application.loadedLevelName.Contains ("StageMario"))
		{
			if (spriteControll == "Idlle")
			{
				cAnimator.SetInteger("MarioAnim", 1);
				cAnimator.SetTrigger("Idle");
			}
			if (spriteControll == "Walk")
			{
				cAnimator.SetInteger("MarioAnim", 5);
			}
			if (spriteControll == "JumpOn" || spriteControll == "JumpOff")
				cAnimator.SetInteger("MarioAnim", 2);
		}
			
			
		if (flip > 0)
			this.transform.localScale.x = thisScale.x;
		if (flip < 0)
			this.transform.localScale.x = -thisScale.x;
	}
	
	if (Time.timeScale == 0 && flip == 0)
		this.transform.localScale.y = -thisScale.y;
	else 
		this.transform.localScale.y = thisScale.y;
}