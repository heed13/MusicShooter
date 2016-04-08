using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float xDist;
	public float yDist;
	public float zDist;
	public bool setDefaultLoc = true;
	//public Vector3 rotation;
	
	// Use this for initialization
	void Start () {
		if (setDefaultLoc)
			setDefaulLocation ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		center();
	}
	
	void center()
	{
		if (target != null) {
			transform.position = new Vector3 (target.position.x + xDist, 
			                                  target.position.y + yDist,
			                                  target.position.z + zDist);
			transform.LookAt (target); 
		}
	}
	
	public void setDefaulLocation()
	{
		xDist = 0.0f;
		yDist = 11.0f;
		zDist = -8.5f;
		setTargetToParent ();

	}
	public void setTargetToParent()
	{
		target = transform.parent;
	}
	public void setLocation(Vector3 pos)
	{
		xDist = pos.x;
		yDist = pos.y;
		zDist = pos.z;
	}
}