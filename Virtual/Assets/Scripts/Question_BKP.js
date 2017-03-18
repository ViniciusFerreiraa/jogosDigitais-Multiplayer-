//private	var _Checkpoint					: Checkpoint;
//private	var _SplitTxt					: SplitTxt;
//
//public	var arrQuestions				: Questions[];
//public	var randomQuestion				: int;
//
//public	var	tQuestion					: GameObject;
//
//public	var tTxtQuestion				: GameObject;
//public	var tTxtAnswerA					: GameObject;
//public	var tTxtAnswerB					: GameObject;
//public	var tTxtAnswerC					: GameObject;
//public	var tTxtAnswerD					: GameObject;
//
//public	var tempId						: int;
//public	var	tempSerie					: int;
//public	var tempMateria					: String;
//
//public	var tempQuestion				: String;
//public	var tempAnswerA					: String;
//public	var tempAnswerB					: String;
//public	var tempAnswerC					: String;
//public	var tempAnswerD					: String;
//
//public	var tempCorrectAnswer			: String;
//static	var playerChose					: String;
//private	var currentQuestion				: int;
//
//
//public	var arrCheckpoints				: Checkpoints[];
//private	var tKeys						: GameObject;
//public	var arrLength					: int;
//
//class Checkpoints
//{
//	var id								: int;
//	var name							: String;
//	var canTake							: boolean;
//}
//
//class Questions
//{
//	var id								: int;
//	var	serie							: int;
//	var materia							: String;
//		
//	var question						: String;
//	var answerA							: String;
//	var answerB							: String;
//	var answerC							: String;
//	var answerD							: String;
//	
//	var correctAnswer					: String;
//}
//
//function Start()
//{
//	tKeys			= GameObject.Find("Keys");
//	
//	playerChose		= "";
//	currentQuestion = 0;
//	
//	tQuestion		= GameObject.Find("Question");
//	
//	tTxtQuestion	= GameObject.Find("TxtQuestion");
//	tTxtAnswerA		= GameObject.Find("TxtAnswerA");
//	tTxtAnswerB		= GameObject.Find("TxtAnswerB");
//	tTxtAnswerC		= GameObject.Find("TxtAnswerC");
//	tTxtAnswerD		= GameObject.Find("TxtAnswerD");
//	
//	InitializeArray();
//	RandonQuestion();
//}
//
//function Update()
//{
//	if (playerChose != "")
//	{
//		Check();
//	}
//	
//	if (Input.GetKeyDown(KeyCode.Q))
//	{
//		InitializeArray();
//	}
//}
//
//function Check()
//{
//	if (playerChose == tempCorrectAnswer)
//	{
//		currentQuestion = 0;
//		Time.timeScale = 1;
//		tQuestion.transform.position.x = 60;
//	}
//	
//	else if (playerChose != tempCorrectAnswer)
//	{
//		currentQuestion++;
//		RandonQuestion();
//	}
//	
//	if (currentQuestion == 10)
//	{
//		currentQuestion = 0;
//		Time.timeScale = 1;
//		tQuestion.transform.position.x = 60;
//	}
//	
//	playerChose = "";
//}
//
//function RandonQuestion()
//{
//	randomQuestion = Random.Range(0, arrQuestions.length);
//	
//	tempId			= arrQuestions[randomQuestion].id;
//	tempSerie		= arrQuestions[randomQuestion].serie;
//	tempMateria		= arrQuestions[randomQuestion].materia;
//	
//	tempQuestion	= arrQuestions[randomQuestion].question;
//	print(tempQuestion);
//	tTxtQuestion.GetComponent(TextMesh).text = tempQuestion;
//	
//	tempAnswerA		= arrQuestions[randomQuestion].answerA;
//	tTxtAnswerA.GetComponent(TextMesh).text = "A: " + tempAnswerA;
//	
//	tempAnswerB		= arrQuestions[randomQuestion].answerB;
//	tTxtAnswerB.GetComponent(TextMesh).text = "B: " + tempAnswerB;
//	
//	tempAnswerC		= arrQuestions[randomQuestion].answerC;
//	tTxtAnswerC.GetComponent(TextMesh).text = "C: " + tempAnswerC;
//	
//	tempAnswerD		= arrQuestions[randomQuestion].answerD;
//	tTxtAnswerD.GetComponent(TextMesh).text = "D: " + tempAnswerD;
//	
//	tempCorrectAnswer = arrQuestions[randomQuestion].correctAnswer;
//	
//	
//	_SplitTxt = tTxtQuestion.GetComponent(SplitTxt);
//	_SplitTxt.ResolveTextSize (tTxtQuestion.transform.GetComponent(TextMesh).text, 29);
//	
//	_SplitTxt = tTxtAnswerA.GetComponent(SplitTxt);
//	_SplitTxt.ResolveTextSize (tTxtAnswerA.transform.GetComponent(TextMesh).text, 29);
//	_SplitTxt = tTxtAnswerB.GetComponent(SplitTxt);
//	_SplitTxt.ResolveTextSize (tTxtAnswerB.transform.GetComponent(TextMesh).text, 29);
//	_SplitTxt = tTxtAnswerC.GetComponent(SplitTxt);
//	_SplitTxt.ResolveTextSize (tTxtAnswerC.transform.GetComponent(TextMesh).text, 29);
//	_SplitTxt = tTxtAnswerD.GetComponent(SplitTxt);
//	_SplitTxt.ResolveTextSize (tTxtAnswerD.transform.GetComponent(TextMesh).text, 29);
//}
//
//function InitializeArray()
//{
//	if (tKeys != null)
//	{
//		arrLength = tKeys.transform.childCount;
//		arrCheckpoints = new Checkpoints[arrLength];
//	}
//	
//	if (arrCheckpoints.Length == 0)
//		arrLength = 1;
//	
////	for (var i:int = 0; i < arrCheckpoints.Length; i++)
////	{
////		arrCheckpoints[i].id		= i;
////		arrCheckpoints[i].name		= "Key" + i.ToString();
////		arrCheckpoints[i].canTake	= false;
////	}
//	//.renderer.material.SetTextureOffset ("_MainTex", Vector2 (0.5, 0));
//}