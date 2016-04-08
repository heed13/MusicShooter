using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour 
{
	public float destructTime = 2;
	public bool disable = false;

	// Use this for initialization
	void OnEnable () 
	{
		Invoke ("Die", destructTime);
	}
	
	// Update is called once per frame
	void Die()
	{
		if (disable) {
			gameObject.SetActive (false);
		} else {
			Destroy (this.gameObject);
		}
	}
}
