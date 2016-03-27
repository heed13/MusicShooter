using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BombDisplay : MonoBehaviour 
{
	public PlayerAttack target;
	public Transform displayParent;
	public Text bombNameText;

	private GameObject bombDisplayObj = null;
	private int currentBombId = 0;

	void Awake ()
	{
		if (displayParent == null)
			displayParent = transform.Find ("DisplayParent");
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if (currentBombId != target.getCurrentBombInfo ().bombId) {
			if (bombDisplayObj != null) {
				Destroy (bombDisplayObj);
			}
			currentBombId = target.getCurrentBombInfo ().bombId;
			bombDisplayObj = (GameObject)Instantiate (target.getCurrentBombInfo ().bombDisplayPrefab, displayParent.position, displayParent.rotation);
			bombDisplayObj.transform.parent = displayParent;
			bombNameText.text = target.getCurrentBombInfo ().bombName;
		}
	}
}
