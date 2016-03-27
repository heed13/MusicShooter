﻿using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour 
{
	public float spawnDelay = 3;
	public GameObject prefab;
	public int enemiesPerSpawn = 2;
	public bool active = true;
	public bool randomizeSpawner = false;

	private List<GameObject> spawnPoints;
	private int nextSpawnPoint;
	private float nextSpawn = 0;
	private int numTracks;
	private int nextSpawnTrack = 0;
	private List<KeyValuePair<int,int>> enemyTrackCounts; //key: size, value: trackId
	private GameObject targetPlayer;

	void Awake()
	{
	}
	void Start()
	{
		targetPlayer = GameObject.FindGameObjectWithTag ("Player");

		numTracks = MultiTrackGame.instance.numTracks;
		spawnPoints = new List<GameObject> (GameObject.FindGameObjectsWithTag("SpawnPoint"));
	}

	void LateUpdate ()
	{
		if (Time.time >= nextSpawn && active) {
			nextSpawn = Time.time + spawnDelay;
			Spawn ();
		}
		if (targetPlayer == null) {
			active = false;
		}
	}
	// Coroutine?
	void Spawn()
	{
		for (int i = 0; i < enemiesPerSpawn; i++) {
			int index;
			if (randomizeSpawner) {
				index = Random.Range (0, spawnPoints.Count);
			} else {
				index = nextSpawnPoint++ % spawnPoints.Count;
			}
			if (index >= spawnPoints.Count) {
				index -= spawnPoints.Count;
			}
			GameObject go = (GameObject)Instantiate (prefab, spawnPoints [index].transform.position, Quaternion.identity);
			go.GetComponent<Enemy> ().trackId = nextSpawnTrack++ % numTracks;
		}
	}

	int GetLowestTrackNumber()
	{
		enemyTrackCounts.Sort (SortByCount);
		return enemyTrackCounts [0].Key;
	}

	public int SortByCount(KeyValuePair<int,int> a, KeyValuePair<int,int> b) 
	{
		if (a.Value <= b.Value) {
			return 0;
		} else {
			return 1;
		}
	}

}
