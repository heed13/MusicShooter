using UnityEngine;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
	public string name;
	public GameObject projectile;
	public int projectileCount = 15;

	protected List<GameObject> projectileObjs = new List<GameObject>();

	void Start()
	{
		projectileObjs = InstantiateObjects (transform.position, transform.rotation);
	}

	public virtual List<GameObject> InstantiateObjects(Vector3 pos, Quaternion rot)
	{
		List<GameObject> objs = new List<GameObject>();
		for (int i = 0; i < projectileCount; i++) {
			objs.Add((GameObject)GameObject.Instantiate (projectile, pos, rot));
		}
		return objs;
	}
	public virtual void Activate(Vector3 aimPos)
	{
		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;
		LaunchProjectile (pos, rot, aimPos);
	}
	protected virtual void LaunchProjectile(Vector3 pos, Quaternion rot, Vector3 aimPos)
	{
		for (int i = 0; i < projectileObjs.Count; i++) {
			GameObject bullet = projectileObjs [i];
			if (!bullet.activeInHierarchy) {
				bullet.transform.position = pos;
				bullet.transform.rotation = rot;
				bullet.transform.LookAt (aimPos);
				bullet.GetComponent<Projectile> ().weapon = this;
				bullet.SetActive (true);
				break;
			}
		}

	}
}