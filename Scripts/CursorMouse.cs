using UnityEngine;
using System.Collections;

public class CursorMouse : MonoBehaviour {

	public Texture2D cursorImage;
	
	private int cursorWidth = 32;
	private int cursorHeight = 32;
	
	void Start()
	{
		Cursor.visible = false; 
	}
	
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), cursorImage);
	}
}
