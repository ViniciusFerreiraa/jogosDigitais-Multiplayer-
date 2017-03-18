private	var _Player						: Player;
private	var _Checkpoint					: Checkpoint;
private	var _SplitTxt					: SplitTxt;

public	var arrQuestions				: Questions[];
public	var randomQuestion				: int;

public	var	tQuestion					: GameObject;

public	var tTxtQuestion				: GameObject;
public	var tTxtAnswerA					: GameObject;
public	var tTxtAnswerB					: GameObject;
public	var tTxtAnswerC					: GameObject;
public	var tTxtAnswerD					: GameObject;
public	var tTxtFeedback				: GameObject;

public	var tempId						: int;
public	var	tempSerie					: int;
public	var tempMateria					: String;

public	var tempQuestion				: String;
public	var tempAnswerA					: String;
public	var tempAnswerB					: String;
public	var tempAnswerC					: String;
public	var tempAnswerD					: String;
public	var tempFeedback				: String;

public	var tempCorrectAnswer			: String;
static	var playerChose					: String;
private	var currentQuestion				: int;

public	var whichQuestion				: GameObject;
private	var addTxt						: String;

public	var arrCheckpoints				: Checkpoints[];
private	var tKeys						: GameObject;
public	var arrLength					: int;

class Checkpoints
{
	var id								: int;
	var name							: String;
	var canTake							: boolean;
}

class Questions
{
	var id								: int;
	var	serie							: int;
	var materia							: String;
		
	var question						: String;
	var answerA							: String;
	var feedbackA						: String;
	var answerB							: String;
	var feedbackB						: String;
	var answerC							: String;
	var feedbackC						: String;
	var answerD							: String;
	var feedbackD						: String;
	
	var correctAnswer					: String;
	
	var shortQuestion					: boolean;
}

function Start()
{
	tKeys			= GameObject.Find("Keys");
	
	playerChose		= "";
	currentQuestion = 0;
	
	tQuestion		= GameObject.Find("Question");
	

	InitializeArray();
	RandonQuestion();
}

function Update()
{
	if (playerChose != "")
	{
		Check();
	}
	
	if (Input.GetKeyDown(KeyCode.Q))
	{
		InitializeArray();
	}
}

function Check()
{
	Feedback();
	yield WaitForSeconds(1.5f);
	tTxtFeedback.GetComponent(TextMesh).text	= "";
	
	if (playerChose == tempCorrectAnswer)
	{
		ResetQuestion();
	}
	
	else if (playerChose != tempCorrectAnswer)
	{
		currentQuestion++;
		RandonQuestion();
	}
	
	if (currentQuestion == 3)
	{
		ResetQuestion();
	}
	
	_Player.speedLerp = 0;
	playerChose = "";
}

function ResetQuestion()
{
	currentQuestion = 0;
	_Player.questionOn = false;
	tQuestion.transform.localPosition.x = 60;
}

function Feedback()
{
	if (playerChose == "A")
		tempFeedback = arrQuestions[randomQuestion].feedbackA;
	else if (playerChose == "B")
		tempFeedback = arrQuestions[randomQuestion].feedbackB;
	else if (playerChose == "C")
		tempFeedback = arrQuestions[randomQuestion].feedbackC;
	else if (playerChose == "D")
		tempFeedback = arrQuestions[randomQuestion].feedbackD;
	
	tTxtFeedback.GetComponent(TextMesh).text = tempFeedback;
}

function RandonQuestion()
{
	randomQuestion = Random.Range(0, arrQuestions.length);
	
	tempId			= arrQuestions[randomQuestion].id;
	tempSerie		= arrQuestions[randomQuestion].serie;
	tempMateria		= arrQuestions[randomQuestion].materia;
	
	tempQuestion	= arrQuestions[randomQuestion].question;
	tempAnswerA		= arrQuestions[randomQuestion].answerA;
	tempAnswerB		= arrQuestions[randomQuestion].answerB;
	tempAnswerC		= arrQuestions[randomQuestion].answerC;
	tempAnswerD		= arrQuestions[randomQuestion].answerD;
	
	tempCorrectAnswer = arrQuestions[randomQuestion].correctAnswer;
	
	FindObjects();
}

function FindObjects()
{
	if (whichQuestion != null)
		whichQuestion.SetActive(true);
	
	if (arrQuestions[randomQuestion].shortQuestion)
		addTxt = "Long";
	else
		addTxt = "Short";
		
	whichQuestion = GameObject.Find("Question" + addTxt);
	whichQuestion.SetActive(false);
		
	tTxtQuestion	= GameObject.Find("TxtQuestion");
	tTxtAnswerA		= GameObject.Find("TxtAnswerA");
	tTxtAnswerB		= GameObject.Find("TxtAnswerB");
	tTxtAnswerC		= GameObject.Find("TxtAnswerC");
	tTxtAnswerD		= GameObject.Find("TxtAnswerD");
	tTxtFeedback	= GameObject.Find("TxtFeedback");
		
	ComponentAndSplitTxt();
}

function ComponentAndSplitTxt()
{
	tTxtQuestion.GetComponent(TextMesh).text	= tempQuestion;
	tTxtAnswerA.GetComponent(TextMesh).text		= "A: " + tempAnswerA;
	tTxtAnswerB.GetComponent(TextMesh).text		= "B: " + tempAnswerB;
	tTxtAnswerC.GetComponent(TextMesh).text		= "C: " + tempAnswerC;
	tTxtAnswerD.GetComponent(TextMesh).text		= "D: " + tempAnswerD;
	
	_SplitTxt = tTxtQuestion.GetComponent(SplitTxt);
	_SplitTxt.ResolveTextSize (tTxtQuestion.transform.GetComponent(TextMesh).text, 30);
	
	_SplitTxt = tTxtAnswerA.GetComponent(SplitTxt);
	_SplitTxt.ResolveTextSize (tTxtAnswerA.transform.GetComponent(TextMesh).text, 15);
	_SplitTxt = tTxtAnswerB.GetComponent(SplitTxt);
	_SplitTxt.ResolveTextSize (tTxtAnswerB.transform.GetComponent(TextMesh).text, 15);
	_SplitTxt = tTxtAnswerC.GetComponent(SplitTxt);
	_SplitTxt.ResolveTextSize (tTxtAnswerC.transform.GetComponent(TextMesh).text, 15);
	_SplitTxt = tTxtAnswerD.GetComponent(SplitTxt);
	_SplitTxt.ResolveTextSize (tTxtAnswerD.transform.GetComponent(TextMesh).text, 15);
}

function InitializeArray()
{
	if (tKeys != null)
	{
		arrLength = tKeys.transform.childCount;
		arrCheckpoints = new Checkpoints[arrLength];
	}
	
	if (arrCheckpoints.Length == 0)
		arrLength = 1;
	
//	for (var i:int = 0; i < arrCheckpoints.Length; i++)
//	{
//		arrCheckpoints[i].id		= i;
//		arrCheckpoints[i].name		= "Key" + i.ToString();
//		arrCheckpoints[i].canTake	= false;
//	}
	//.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
}