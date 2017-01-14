using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlightSim : MonoBehaviour 
{
	private Rigidbody rb;
	public Transform model;
	public Animator anim;

	public const string VERTICAL_AXIS = "Vertical";
	public const string HORIZONTAL_AXIS = "Horizontal";
	public KeyCode THRUST_AXIS = KeyCode.Space;

	public bool invertPitch = false;

	public float rollSpeed = 1;
	public float yawSpeed = 1;
	public float pitchSpeed = 1;
	public float thrustSpeed = 1;

	private void GetAndProcessInputs()
	{
		float yaw = Input.GetAxis (HORIZONTAL_AXIS);
		float pitch = Input.GetAxis (VERTICAL_AXIS);
		pitch *= (invertPitch) ? 1 : -1;

		bool thrustActive = Input.GetKey (THRUST_AXIS);


		YawMovement (yaw);
		PitchMovement (pitch);

		ApplyThrust (thrustActive);

		anim.SetBool ("HasThrust",thrustActive);
		anim.SetFloat ("Yaw", yaw);
		anim.SetFloat ("Pitch", pitch);
	}
		
	private void ApplyThrust(bool applied)
	{
		if (applied) {
			rb.AddForce (transform.forward * thrustSpeed, ForceMode.Force);
		}
	}

	private void PitchMovement(float pitch)
	{
		if (pitch != 0) {
			transform.Rotate (Vector3.right, pitch * pitchSpeed);
		}

	}
	private void YawMovement(float yaw)
	{
		if (yaw != 0) {
			transform.Rotate (Vector3.up, yaw * yawSpeed);

		} 
	}
		
	private float ClampAngle(float angle, float min, float max)
	{
		if (angle < 90 || angle > 270) {
			if (angle > 180)
				angle -= 360;
			if (max > 180)
				max -= 360;
			if (min > 180)
				min -= 360;
		}
		angle = Mathf.Clamp (angle, min, max);
		if (angle < 0)
			angle += 360;
		return angle;
	}

	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
	}


	void Update()
	{
		GetAndProcessInputs ();
	}

}
