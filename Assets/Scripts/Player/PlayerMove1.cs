using UnityEngine;
using System.Collections;

public class PlayerMove1 : MonoBehaviour {

	public playerRotateTypes rotateType;
	public enum playerRotateTypes {
		mouse,
		gamepad,
	}

	public float moveSpeed = 60;
	public float RotateSpeed = 5;
	float gravity = -9.8f;

	CharacterController charController;
	Vector3 lastPos;
	Animator anim;

	float animSpeed;
	Vector3 currentMovement;
	float currentTurnSpeed;


	void Start () {
		charController = GetComponent<CharacterController> ();
		if (charController == null) {
			charController = gameObject.AddComponent<CharacterController>();
		}
		anim = GetComponent<Animator> ();
		if (anim == null) {
		}
	}

	void Update () {
		GetPlayerMovement ();
		UpdateAnimation ();
	}

	void GetPlayerMovement()
	{
		// Get Movement
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis ("Vertical");

		// Move in dir
		currentMovement = new Vector3 (x, gravity, z).normalized * moveSpeed;
		charController.Move( currentMovement * Time.deltaTime );

		// get Rotation Type
		switch(rotateType) {
		case playerRotateTypes.gamepad:
			playerGamePadRotate();
			break;
		case playerRotateTypes.mouse:
			playerMouseRotate();
			break;
		}

	}
	// NOTE: / TODO: gamepad players have no rotational speed, but mouse players do
	void playerGamePadRotate()
	{
		float x = Input.GetAxis ("RotationHorizontal");
		float y = Input.GetAxis ("RotationVertical");
		if (x != 0 || y != 0)
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
	}
	void playerMouseRotate()
	{
		var playerPlane = new Plane(Vector3.up, transform.position);
		// Generate a ray from the cursor position
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float hitdist = 0.0f;
		// If the ray is parallel to the plane, Raycast will return false.
		if (playerPlane.Raycast (ray, out hitdist)) {
			// Get the point along the ray that hits the calculated distance.
			var targetPoint = ray.GetPoint (hitdist);
			// Determine the target rotation.  This is the rotation if the transform looks at the target point.
			var targetRotation = Quaternion.LookRotation (targetPoint - transform.position);

			// Smoothly rotate towards the target point.
			transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, RotateSpeed * Time.deltaTime);
		}
	}
	void UpdateAnimation()
	{
		if (anim != null) {
			Vector3 movementVector = transform.position - lastPos;

			float speed = Vector3.Dot (movementVector.normalized, transform.forward);
			float direction = Vector3.Dot (movementVector.normalized, transform.right);

			if (Mathf.Abs (speed) < 0.2f) {
				speed = 0f;
			}

			if (speed > 0.8f) {
				speed = 1f;
				direction = 0f;
			}

			if (speed >= 0f) {
				if (Mathf.Abs (direction) > 0.7f) {
					speed = 1f;
				}
			}

			animSpeed = Mathf.MoveTowards (animSpeed, speed, Time.deltaTime * 5f);

			anim.SetFloat ("Speed", animSpeed);
			anim.SetFloat ("Direction", direction);

			lastPos = transform.position;
		}
	}

	public void modifyMoveSpeed(float percentage)
	{
		moveSpeed += moveSpeed*percentage;
	}

}