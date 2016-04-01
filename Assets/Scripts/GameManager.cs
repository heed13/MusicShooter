using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using GameJolt;

public class GameManager : MonoBehaviour 
{
	public static GameManager instance;
	public int trophyNum = 100000;
	private bool trophyUnlocked = false;
	public int score;
	public GameObject player;

	public GameObject gameOverScreen;

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
		player = GameObject.FindObjectOfType<PlayerHealth> ().gameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI()
	{
		//if (GUI.Button(new Rect(0,0,50,25), "Quit")) {
		//	ExitGame ();
		//}
		GUI.Label (new Rect (Screen.width - 50, 0, 50, 50), score.ToString (), style);
		GUI.Label (new Rect (Screen.width/2 - 25, 0, 50, 50), Time.time.ToString ("0.0"), style);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}
	public void SetTimescale(float scale)
	{
		Time.timeScale = scale;
	}
	public void IncrementScore(int amount = 1)
	{
		score += amount;

		// TODO: this needs to be a proper built architecture for acheivements.
		if (score >= trophyNum && GameJolt.API.Manager.Instance.CurrentUser != null) {
			GameJolt.API.Trophies.Get (54407, (GameJolt.API.Objects.Trophy trophy) => {
				if (trophy != null) {
					if (!trophy.Unlocked && !trophyUnlocked) {
						GameJolt.API.Trophies.Unlock (54407, (bool success) => {
							if (success) {
								trophyUnlocked = true;
							}
						});
					}
				}
			});
		}
	}
	public void GameOver()
	{
		gameOverScreen.SetActive (true);
		EnemyController.instance.spawner.active = false;
	}

	public void RestartGame()
	{
		EnemyController.instance.DestroyAllEnemies ();
		GameObject[] debris = GameObject.FindGameObjectsWithTag ("Debris");
		for (int i = 0; i < debris.Length; i++) {
			Destroy (debris [i]);
		}
		player.SetActive (true);
		player.GetComponent<PlayerHealth> ().Revive ();
		score = 0;
		gameOverScreen.SetActive (false);
		MultiTrackGame.instance.incrementAllTracks (1);
		EnemyController.instance.spawner.active = true;

	}
}
