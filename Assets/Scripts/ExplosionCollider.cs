using UnityEngine;
using System.Collections;

public class ExplosionCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnParticleCollision(GameObject other)
	{
		Debug.Log (other);
	}
}
