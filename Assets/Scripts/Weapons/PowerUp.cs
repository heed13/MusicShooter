using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public enum PowerUpType 
{
	weaponUpgrade,
	invulnerability,
	trackIncrements,
	bombType1,
	bombType2,
	etc,
}

public class PowerUp : MonoBehaviour
{
	public PowerUpType type;
	public GameObject aquireEffect;

	void OnTriggerEnter (Collider col) 
	{
		if (!col.CompareTag ("Player")) {
			return;
		}
		switch (type) {
		case PowerUpType.weaponUpgrade:
			col.GetComponentInParent<PlayerAttack> ().UpgradeAttack();
			break;
		case PowerUpType.invulnerability:
			break;
		case PowerUpType.bombType1:
			col.GetComponentInParent<PlayerAttack> ().AquireBomb (1);
			break;
		}
		if (aquireEffect != null)
			Instantiate (aquireEffect, transform.position, transform.rotation);
		Destroy (this.gameObject);
	}
}
