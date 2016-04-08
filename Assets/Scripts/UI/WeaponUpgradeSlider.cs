using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class WeaponUpgradeSlider : MonoBehaviour 
{
	public PlayerAttack target;
	private Slider slider;

	void Start ()
	{
		slider = GetComponent<Slider> ();
		slider.wholeNumbers = true;
		slider.maxValue = target.GetWeaponUpgradeCount () - 1;

	}
	
	void LateUpdate () 
	{
		slider.value = target.GetCurrentWeaponUpgrade ();
	}
}
