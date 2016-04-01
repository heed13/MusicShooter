using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {
	public static EnemyController instance;
	public EnemySpawner spawner;

	// Use this for initialization
	void Awake () 
	{
		if (EnemyController.instance == null) {
			EnemyController.instance = this;
		}
	}

	public void DestroyAllEnemies()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < enemies.Length; i++) {
			// TODO: make enemies an object pool
			Destroy (enemies [i]);
		}
	}

}
