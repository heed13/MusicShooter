using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
	public float moveSpeed = 2;
	public int trackId = 0;
	public int suicideDamage = 10;
	public GameObject particleEffect;
	public List<GameObject> parts;

	private GameObject target;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		transform.Find ("default").GetComponent<Renderer> ().material = MultiTrackGame.instance.song.tracks [trackId].color.enemyMat;
		GetComponent<MapMarker>().markerSprite = MultiTrackGame.instance.song.tracks [trackId].color.mapMarker;

		target = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate()
	{
		if (target != null) {
			transform.LookAt (target.transform.position);
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, moveSpeed * Time.deltaTime);
		}
		//if (Vector3.Distance(transform.position, new Vector3(transform.position.x, 0, transform.position.z)) > .5) {
		if (transform.position.y >= 0.01f || transform.position.y <= 0.01f) {
			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		}

	}
	public virtual void PlayerKilled()
	{
		// Increment music timer
		MultiTrackGame.instance.incrementTimeOfTrack (trackId);
		// Increment player score
		GameManager.instance.IncrementScore();
		Kill ();
	}
	public virtual void Kill()
	{
		
		// Spawn Parts
		int randomPartsCount = Random.Range(0, parts.Count);
		for (int i = 0; i < randomPartsCount; i++) {
			Instantiate (parts[Random.Range(0, parts.Count)], transform.position, transform.rotation);
		}
		// Spawn Explosion
		Instantiate (particleEffect, transform.position, transform.rotation);

		// Destroy this object
		Destroy (this.gameObject);

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			col.GetComponentInParent<PlayerHealth> ().TakeDmg (suicideDamage);
			Kill ();
		}

	}
}
