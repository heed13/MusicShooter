using UnityEngine;
using System.Collections;

[System.Serializable]
public struct BombInfo{
	public int bombId;
	public string bombName;
	public GameObject bombPrefab;
	public GameObject bombDisplayPrefab;
}
public class Bomb : MonoBehaviour
{
	public GameObject explosion;

	private float speed = 0.4f; 
	private float range = 100;
	private float startTime; 
	private Vector3 startPos;


	void OnEnable () 
	{
		startTime = Time.time; 
		startPos = transform.position;
	} 

	void FixedUpdate () {
		// Move forward 
		this.gameObject.transform.position += speed * this.gameObject.transform.forward;
		// If we have passed our range
		if (Vector3.Distance(transform.position , startPos) >= range) {
			Die ();
		}
	}

	void Die()
	{
	}
}
