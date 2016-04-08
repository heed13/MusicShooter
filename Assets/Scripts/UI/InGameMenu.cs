using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using GameJolt;

public class InGameMenu : MonoBehaviour 
{
	private const string usernameEmptyText = "Logged Out";
	public Text usernameText;
	public GameObject userDisplayPanel;

	void Start()
	{
		usernameText.text = usernameEmptyText;
	}

	public void GameJoltBtnPressed()
	{
		if (GameJolt.API.Manager.Instance.CurrentUser == null) {
			GameJolt.UI.Manager.Instance.ShowSignIn ();
			userDisplayPanel.SetActive (false);

		} else {
			usernameText.text = GameJolt.API.Manager.Instance.CurrentUser.Name;
			userDisplayPanel.SetActive (!userDisplayPanel.activeInHierarchy);
		}
	}
	public void logout()
	{
		GameJolt.API.Manager.Instance.CurrentUser.SignOut ();
		usernameText.text = usernameEmptyText;
	}


}
