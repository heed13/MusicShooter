using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour 
{
	public int totalHp = 100;
	public int currentHp = 100;
	public List<GameObject> parts;
	public GameObject pilot;
	private Vector3 pilotOrigPos;
	private Quaternion pilotOrigRot;
	public GameObject deathEffect;

	private bool alive = true;


	// Use this for initialization
	void Start () 
	{
		alive = true;
		currentHp = totalHp;
		pilotOrigPos = pilot.transform.position;
		pilotOrigRot = pilot.transform.rotation;
	}
	
	public void TakeDmg(int dmg)
	{
		if (!alive)
			return;
		currentHp -= dmg;
		if (currentHp <= 0) {
			Kill ();		
		}
	}

	public void Kill()
	{
		alive = false;
		pilot.transform.position = transform.position;
		pilot.transform.rotation = transform.rotation;
		pilot.GetComponent<Animator> ().SetTrigger ("killed");
		pilot.GetComponent<Rigidbody> ().freezeRotation = false;


		int randomPartsCount = Random.Range(0, parts.Count);
		for (int i = 0; i < randomPartsCount; i++) {
			Instantiate (parts[Random.Range(0, parts.Count)], transform.position, transform.rotation);
		}

		Instantiate (deathEffect, transform.position, transform.rotation);

		gameObject.SetActive (false);
		GameManager.instance.GameOver ();
	}

	public void Revive()
	{
		alive = true;
		currentHp = totalHp;
		pilot.transform.position = pilotOrigPos;
		pilot.transform.rotation = pilotOrigRot;
		pilot.GetComponent<Animator> ().SetTrigger ("revived");
		pilot.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		pilot.GetComponent<Rigidbody> ().freezeRotation = true;
	}

}
