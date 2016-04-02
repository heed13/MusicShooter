using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class Sun : MonoBehaviour 
{
	public int playerDmg = 15;
	public GameObject particleBurn;
	public GameObject particleExplode;
	public float destoryWaitTime = 1.5f;

	private List<GameObject> alreadyBurningObjs = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) 
	{
		if (alreadyBurningObjs.Contains (col.gameObject)) {
			return;
		}
		
		alreadyBurningObjs.Add (col.gameObject);
		GameObject go = (GameObject)Instantiate (particleBurn, col.transform.position, Quaternion.identity);
		go.transform.parent = col.gameObject.transform;
		if (!col.gameObject.CompareTag ("Player")) {
			StartCoroutine (DestroyObj (col.gameObject));
		} else {
			StartCoroutine (stopBurning(col.gameObject));
		}


	}

	IEnumerator DestroyObj(GameObject obj)
	{
		yield return new WaitForSeconds(destoryWaitTime);
		try {
			if (obj != null) {
				alreadyBurningObjs.Remove (obj);
				Instantiate (particleExplode, obj.transform.position, Quaternion.identity);
				Destroy (obj);
			}
		}
		catch (Exception e) {
			Debug.Log (e);
		}
	}

	IEnumerator stopBurning(GameObject obj)
	{
		obj.GetComponent<PlayerHealth> ().TakeDmg (playerDmg);
		yield return new WaitForSeconds (destoryWaitTime);
		alreadyBurningObjs.Remove (obj);
	}
}
