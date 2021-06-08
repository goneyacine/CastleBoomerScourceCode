﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Level
{
	public new string name = "New Level";
	public SerializableGameObject levelData;

	public void SetLevel(GameObject level)
	{
		GameObjectSerializer gameObjectSerializer = new GameObjectSerializer();
		levelData = gameObjectSerializer.ToSerializableGameObject(level);
	}

}
