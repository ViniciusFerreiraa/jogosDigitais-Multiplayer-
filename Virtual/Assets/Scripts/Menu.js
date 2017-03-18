private	var _AnimationPause				: AnimationMovePlanes;
private	var _Save						: Save;

private var _score			: Score;
private var _scoreTotal		: ScoreTotal;

public	var tMenuOptions				: GameObject;
public	var tButtonReturn				: GameObject;
public	var tDone						: GameObject;
public	var tButtonAnim					: GameObject;

private	var currentControll				: String;

private var randomStage					: int;

private	var ray;

function Start() 
{
	tMenuOptions.SetActive	(true);
	tDone.SetActive			(false);
	tButtonAnim.SetActive	(false);
}

function Update() 
{

}

function GameQuit()
{
	yield WaitForSeconds (1f);
	Application.Quit();
}