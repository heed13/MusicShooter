using UnityEngine;
using System.Collections.Generic;

public class DoubleWeapon : Weapon 
{
	public List<Transform> shootFrom;


	public override void Activate ()
	{
		if (shootFrom.Count > 0) {
			LaunchProjectile (shootFrom [0].position, shootFrom [0].rotation);
			LaunchProjectile (shootFrom [1].position, shootFrom [1].rotation);
		}
	}
}
