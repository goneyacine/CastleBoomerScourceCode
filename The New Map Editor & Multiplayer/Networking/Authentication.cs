using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
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

	public static string SessionTicket;
	private void Awake()
	{
		if (!File.Exists(Application.persistentDataPath + "/AuthenticationData.authentication"))
		{
			loginMainPanel.SetActive(true);
		}else 
		{
         BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/AuthenticationData.authentication";
		FileStream stream = new FileStream(path, FileMode.Create);
		PlayerAuthenticationData playerAuthenticationData = formatter.Deserialize(stream) as PlayerAuthenticationData;
		stream.Close();
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
		{
			Username = playerAuthenticationData.userName,
			Password = playerAuthenticationData.password
		}, result =>
		{
			SessionTicket = result.SessionTicket;
		}, error =>
		{
			 Debug.Log(error.GenerateErrorReport());
		});
		}

	}
	public void SignUp()
	{
		PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
		{
			Username = signUpUserNameInputField.text,
			Email = signUpEmailInputField.text,
			Password = loginPasswordInputField.text
		}, result =>
		{
			SessionTicket = result.SessionTicket;
			signUpMainPanel.SetActive(false);
			loginMainPanel.SetActive(true);
		}, error =>
		{
			singUpErrorDisplayer.text = error.GenerateErrorReport();
		});
	}
	public void Login()
	{
		PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
		{
			Username = loginUserNameInputField.text,
			Password = loginPasswordInputField.text
		}, result =>
		{
			SessionTicket = result.SessionTicket;
			loginMainPanel.SetActive(false);
			RememberUser(loginUserNameInputField.text, loginPasswordInputField.text);
		}, error =>
		{
			loginErrorDisplayer.text = error.GenerateErrorReport();
		});
	}
	public void RememberUser(string userName, string password)
	{
		PlayerAuthenticationData playerAuthenticationData = new PlayerAuthenticationData(userName, password);
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