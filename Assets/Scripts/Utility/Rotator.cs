using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
	public Transform around;
	public float speed = 90f;
	public bool active = true;
	public bool up = true;
	public bool forward = false;
	public bool right = false;


	void Start()
	{
		if (around == null) {
			around = this.transform;
		}
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (active) {
			Vector3 dir = Vector3.zero;
			if (up) {
				dir += transform.up;
			}
			if (forward) {
				dir += transform.forward;
			}
			if (right) {
				dir += transform.right;
			}

			transform.RotateAround (around.position, dir, Time.deltaTime * speed);
		}
	}
}
