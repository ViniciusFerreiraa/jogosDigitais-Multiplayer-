private var respawPlayer			: GameObject;

function Start()
//function OnLevelWasLoaded (level : int)
{
	if (Application.loadedLevelName.Contains("Stage"))		// procura pelo respaw apenas se estiver nas fases, ou seja: o level for diferente de 0 (seleçao de fases)
	{
		respawPlayer = GameObject.Find("RespawPlayer");
		this.transform.position = respawPlayer.transform.position;
	}
}