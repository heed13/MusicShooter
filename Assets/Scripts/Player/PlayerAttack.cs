using UnityEngine;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour 
{
	public GameObject trackObj;
	public float attackSpeed = 0.5f; // attacks per second
	public List<BombInfo> bomb;
	public int currentBomb = 0;

	private List<Weapon> weapons; // List of weapons (upgrades)
	private float nextAttack = 0; // Time till next attack
	private int currentWeaponUpgrade; // what weapon upgrade are we on?
	private float bombCount = 0; // How many bombs the player has
	private float nextBombAttack = 0;
	private float bombAttackDelay = 3;

	private Vector3 aimPos;

	void Awake ()
	{
		weapons = new List<Weapon>(GetComponentsInChildren<Weapon> ());

	}
	
	void Update () 
	{
		UpdateAttackEndPosition ();
		trackObj.transform.position = aimPos;
		if (Time.time >= nextAttack && Input.GetMouseButton (0)) {
			nextAttack = Time.time + (1 / attackSpeed);
			Shoot ();
		}
		if (Time.time >= nextBombAttack && Input.GetKey (KeyCode.Space)) {
		}
	}

	void UpdateAttackEndPosition()
	{
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		//Ray r = new Ray (weapons [currentWeaponUpgrade].transform.position, fwd); // Forward
		Ray r = Camera.main.ScreenPointToRay (Input.mousePosition); // At mouse
		if (Physics.Raycast (r, out hit,100.0f,1 << 10)) {
			Debug.Log (hit.collider);
			Debug.Log (hit.point);
			aimPos = hit.point;
		}
	}

	void Shoot()
	{
		weapons [currentWeaponUpgrade].Activate (aimPos);
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
