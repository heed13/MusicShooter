using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
	public float speed = 90f;
	public bool active = true;
	public bool up = true;
	public bool forward = false;
	public bool right = false;
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (active) {
			Vector3 dir;
			dir = ((up) ? transform.up : ((forward) ? transform.forward : Vector3.right));
			transform.RotateAround (transform.position, dir, Time.deltaTime * speed);
		}
	}
}
