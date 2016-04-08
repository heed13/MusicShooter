using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HPBar : MonoBehaviour
{
	public PlayerHealth target;
	private Slider slider;

	// Use this for initialization
	void Start () 
	{
		slider = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		slider.value = ((float)target.currentHp / (float)target.totalHp);
	}
}
