using System;
using PlayFab;
using PlayFab.MultiplayerModels;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

public class MatchMaker : MonoBehaviour
{
	private void Start()
	{
		//generating the player ID once he open this scene
		string hostName = Dns.GetHostName();
		string ip = Dns.GetHostByName(hostName).AddressList[0].ToString();
		playerID = ID_Generator.IP_to_ID(ip);
	}
	public void StartMatchmaking()
	{
		cancelMatchButton.SetActive(false);
		queueStatusText.text = "Searching For Player...";
		randomMatchMakingPanel.SetActive(true);
		mainPanel.SetActive(false);

		PlayFabMultiplayerAPI.CreateMatchmakingTicket(
		    new CreateMatchmakingTicketRequest
		{
			Creator = new MatchmakingPlayer
			{
				Entity = new EntityKey
				{
					Id = authentication.id,
					Type = "title_player_account",
				},
				Attributes = new MatchmakingPlayerAttributes
				{
					DataObject = new { IP = playerID }
				}
			},

			GiveUpAfterSeconds = 120,

			QueueName = queueName
		},
		OnMatchmakingTicketCreated,
		OnMatchmakingError
		);
	}
	public void LeaveQueue()
	{
		randomMatchMakingPanel.SetActive(false);
		mainPanel.SetActive(true);

		PlayFabMultiplayerAPI.CancelMatchmakingTicket(
		    new CancelMatchmakingTicketRequest
		{
			QueueName = queueName,
			TicketId = ticketId
		},
		OnTicketCanceled,
		OnMatchmakingError
		);
	}

	private void OnTicketCanceled(CancelMatchmakingTicketResult result)
	{
		randomMatchMakingPanel.SetActive(false);
		mainPanel.SetActive(true);
	}

	private void OnMatchmakingTicketCreated(CreateMatchmakingTicketResult result)
	{
		ticketId = result.TicketId;
		pollTicketCoroutine = StartCoroutine(PollTicket(result.TicketId));

		cancelMatchButton.SetActive(true);
		queueStatusText.text = "Player Found...";
	}

	private void OnMatchmakingError(PlayFabError error)
	{
		queueStatusText.text = error.GenerateErrorReport();
		Debug.LogError(error.GenerateErrorReport());
	}

	private IEnumerator PollTicket(string ticketId)
	{
		while (true)
		{
			PlayFabMultiplayerAPI.GetMatchmakingTicket(
			    new GetMatchmakingTicketRequest
			{
				TicketId = ticketId,
				QueueName = queueName
			},
			OnGetMatchMakingTicket,
			OnMatchmakingError
			);

			yield return new WaitForSeconds(6);
		}
	}

	private void OnGetMatchMakingTicket(GetMatchmakingTicketResult result)
	{
		queueStatusText.text = $"Status: {result.Status}";

		switch (result.Status)
		{
		case "Matched":
			StopCoroutine(pollTicketCoroutine);
			StartMatch(result.MatchId);
			break;
		case "Canceled":
			StopCoroutine(pollTicketCoroutine);
			randomMatchMakingPanel.SetActive(false);
			mainPanel.SetActive(true);
			break;
		}
	}

	private void StartMatch(string matchId)
	{
		queueStatusText.text = $"Starting Match...";

		PlayFabMultiplayerAPI.GetMatch(
		    new GetMatchRequest
		{
			MatchId = matchId,
			QueueName = queueName,
			ReturnMemberAttributes = true
		},
		OnGetMatch,
		OnMatchmakingError
		);
	}

	private void OnGetMatch(GetMatchResult result)
	{
		
		//storing the players IDs on the PlayersIDSaver two join them
		JArray p1 = result.Members[0].Attributes.DataObject as JArray;
		JArray p2 = result.Members[1].Attributes.DataObject as JArray;
		idSaver.ManageIDs((string)p1[0].Value<object>(),(string)p2[0].Value<object>());
		SceneManager.LoadScene(multiplayerSceneName);
	}
	public string playerID;
	public string queueName = "1V1CastleBoomer";
	public GameObject playButton;
	public GameObject cancelMatchButton;
	public Text queueStatusText;
	public PlayersIDSaver idSaver;
	public string multiplayerSceneName = "1V1";
	private Coroutine pollTicketCoroutine;
	private string ticketId;
	public GameObject randomMatchMakingPanel;
	public GameObject mainPanel;
	public Authentication authentication;
}
public class MyDataObject
{
 public string name;
 public string myValue;
}
