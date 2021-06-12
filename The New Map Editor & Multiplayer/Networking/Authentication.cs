using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ModelsModules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Authentication : MonoBehaviour
{
	public InputField loginUserNameInputField;
	public InputField loginPasswordInputField;

	public InputField signUpUserNameInputField;
	public InputField signUpEmailInputField;
	public InputField signUpPasswordInputField;

	public Text loginErrorDisplayer;
	public Text singUpErrorDisplayer;

	public GameObject signUpMainPanel;
	public GameObject loginMainPanel;
	private void Awake()
	{
		if (!File.Exits(Application.persistentDataPath + "/AuthenticationData.authentication"))
		{
			loginMainPanel.SetAcitve(true);
		}
	}
	public void SignUp()
	{
		PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
		{
			Username = signUpUserNameInputField.text;
			Email = signUpEmailInputField.text;
			Password = loginPasswordInputField.text;
		}, result =>
		{
			SessionTicket = result.SessionTicket;
			signUpMainPanel.SetAcitve(false);
			loginMainPanel.SetAcitve(true);
		}, error =>
		{
			singUpErrorDisplayer.text = error.GenerateErrorReport();
		});
	}
	public void Login()
	{
		PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
		{
			Username = loginUserNameInputField.text;
			Password = loginPasswordInputField.text;
		}, result =>
		{
			SessionTicket = result.SessionTicket;
			loginMainPanel.SetAcitve(false);
			RememberUser(loginUserNameInputField.text, loginPasswordInputField.text);
		}, error =>
		{
			loginErrorDisplayer.text = error.GenerateErrorReport();
		});
	}
	public void RememberUser(string userName, string password)
	{
		PlayerAuthenticationData playerAuthenticationData = new PlayerAuthenticationData(userName, email, password);
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/AuthenticationData.authentication";
		FileStream stream = new FileStream(path, FileMode.Create);
		formatter.Serialize(stream, playerAuthenticationData);
		stream.Close();
	}
}
[System.Serializable]
public class PlayerAuthenticationData
{
	public PlayerAuthenticationData(string userName, string password)
	{
		this.userName = userName;
		this.password = password;
	}

	public string userName;
	public string password;
}