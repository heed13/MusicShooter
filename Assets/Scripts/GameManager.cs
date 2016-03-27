using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public static GameManager instance;
	public int score;

	public bool godMode = true;

	GUIStyle style;

	void Awake()
	{
		if (GameManager.instance == null) {
			GameManager.instance = this;
		}
	}
	// Use this for initialization
	void Start () 
	{
		style = new GUIStyle ();
		style.normal.textColor = Color.red;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI()
	{
		
		GUI.Label (new Rect (Screen.width - 50, 0, 50, 50), score.ToString (), style);
		GUI.Label (new Rect (Screen.width/2 - 25, 0, 50, 50), Time.time.ToString ("0.0"), style);
	}
}
