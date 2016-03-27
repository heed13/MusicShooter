using UnityEngine;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour 
{
	public float attackSpeed = 0.5f; // attacks per second
	public List<BombInfo> bomb;
	public int currentBomb = 0;

	private List<Weapon> weapons; // List of weapons (upgrades)
	private float nextAttack = 0; // Time till next attack
	private int currentWeaponUpgrade; // what weapon upgrade are we on?
	private float bombCount = 0; // How many bombs the player has
	private float nextBombAttack = 0;
	private float bombAttackDelay = 3;


	void Awake ()
	{
		weapons = new List<Weapon>(GetComponentsInChildren<Weapon> ());

	}
	
	void Update () 
	{
		if (Time.time >= nextAttack && Input.GetMouseButton (0)) {
			nextAttack = Time.time + (1 / attackSpeed);
			Shoot ();
		}
		if (Time.time >= nextBombAttack && Input.GetKey (KeyCode.Space)) {
		}
	}

	void Shoot()
	{
		weapons [currentWeaponUpgrade].Activate ();
	}

	void LaunchBomb()
	{
		Instantiate (bomb[currentBomb].bombPrefab, transform.position, Quaternion.identity);
	}

	public void UpgradeAttack()
	{
		if (currentWeaponUpgrade >= weapons.Count-1) {
			// Add to points or store it or somethign
		} else {
			currentWeaponUpgrade++;
		}
	}
	public void AquireBomb(int bombId)
	{
		currentBomb = bombId;
	}
	public int GetWeaponUpgradeCount()
	{
		return weapons.Count;
	}
	public int GetCurrentWeaponUpgrade()
	{
		return currentWeaponUpgrade;
	}

	public BombInfo getCurrentBombInfo()
	{
		return bomb [currentBomb];
	}
}
