using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Mirror;
public class MyPlayerNetworkManager : NetworkBehaviour
{

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!isClientOnly)
			CmdSendLevelToHost(GameStarter.starter.selectedLevelData);
		else
			RpcSendLevelToClientOnly(GameStarter.starter.selectedLevelData);
	}
	[Command]
	public void CmdSendLevelToHost(string levelData)
	{
		if (isServerOnly)
			return;
		GameStarter.starter.LoadLevel(levelData);
	}
	[ClientRpc]
	public void RpcSendLevelToClientOnly(string levelData)
	{
		if (!isClientOnly)
			return;
		GameStarter.starter.LoadLevel(levelData);
	}

}