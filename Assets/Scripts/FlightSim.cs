using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlightSim : MonoBehaviour 
{
	private Rigidbody rb;
	public Transform model;

	public const string VERTICAL_AXIS = "Vertical";
	public const string HORIZONTAL_AXIS = "Horizontal";
	public KeyCode THRUST_AXIS = KeyCode.Space;

	public bool invertPitch = false;

	public float rollSpeed = 1;
	public float yawSpeed = 1;
	public float pitchSpeed = 1;
	public float thrustSpeed = 1;

	private void GetInputs()
	{
		float yaw = Input.GetAxis (HORIZONTAL_AXIS);
		float pitch = Input.GetAxis (VERTICAL_AXIS);
		pitch *= (invertPitch) ? 1 : -1;

		bool thrust = Input.GetKey (THRUST_AXIS);

		if (yaw != 0) {
			transform.Rotate (Vector3.up, yaw * yawSpeed);
			// lerp roll to 45-40deg then roll back if yaw == 0
			if (Mathf.Abs(model.rotation.z) < 45) {
				model.Rotate (Vector3.forward, rollSpeed * yaw);
			}
		} else {
			//.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, 0,1),Time.time * rollSpeed);
		}
		if (pitch != 0) {
			transform.Rotate (Vector3.right, pitch * pitchSpeed);
		}

		if (thrust) {
			rb.AddForce (transform.forward*thrustSpeed,ForceMode.Force);
		}

	}



	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
	}


	void Update()
	{
		GetInputs ();
	}

}
