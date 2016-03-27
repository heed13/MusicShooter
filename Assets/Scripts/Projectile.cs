using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Projectile : MonoBehaviour {
	public float speed = 0.4f; 
	public float range = 100;
	public int penetrationLevel = 1;


	public Weapon weapon;


	private float startTime; 
	private Vector3 startPos;
	private List<GameObject> alreadyHitObjects;
	private int penetrationCurrent = 0;

	
	void OnEnable () 
	{
		startTime = Time.time; 
		alreadyHitObjects = new List<GameObject> ();
		startPos = transform.position;
	} 
	
	void FixedUpdate () {
		// Move forward 
		this.gameObject.transform.position += speed * this.gameObject.transform.forward;
		// If we have passed our range
		if (Vector3.Distance(transform.position , startPos) >= range) {
			die ();
		}
	}


	
	void OnTriggerEnter(Collider col)
	{
		switch (col.tag) {
		case "Player":
			return;
		case "Enemy": 
			col.GetComponent<Enemy> ().PlayerKilled ();
			break;
		case "Debris":
			Destroy (col.gameObject);
			break;
		default:
			return;
		}
	
		if (++penetrationCurrent >= penetrationLevel) {
			die ();
		}

	}

	
	void die()
	{
		this.gameObject.SetActive (false);
	}
}