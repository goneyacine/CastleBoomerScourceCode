using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/* this class is used to store the ID of the other player when the match start so we can
translate that ID into IP than join the two player with */
public class PlayersIDSaver : MonoBehaviour
{
	public void ManageIDs(string player1ID, string player2ID)
	{
		if (player1ID.Equals(myID))
		{
			isHost = true;
			otherPlayerID = player2ID;
			otherPlayerIP = ID_Generator.ID_to_IP(otherPlayerID);
			PlayerPrefs.SetInt("isHost", 1);
            PlayerPrefs.SetString("otherPlayerID",otherPlayerID);
		} else
		{
			isHost = false;
			otherPlayerID = player1ID;
			otherPlayerIP = ID_Generator.ID_to_IP(otherPlayerID);
			PlayerPrefs.SetInt("isHost", 0);
            PlayerPrefs.SetString("otherPlayerID",otherPlayerID);
		}
	}

	public string myID;
	public string otherPlayerID;
	public string otherPlayerIP;
	public bool isHost = false;
}