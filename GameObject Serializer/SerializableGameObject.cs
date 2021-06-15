using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableGameObject
{
	public SerializableGameObject(string name,List<SerializableComponent> serializableComponents, List<List<float>> transformData, List<SerializableGameObject> childs)
	{
		this.serializableComponents = serializableComponents;
		this.transformData = transformData;
		this.childs = childs;
		this.name = name;
	}
//the transform data list contains the position rotation & scale data
	public List<SerializableComponent> serializableComponents;
	public List<List<float>> transformData;
	public List<SerializableGameObject> childs;
	public string name;
}

[System.Serializable]
public class SerializableComponent
{
	public SerializableComponent(Type componentType, List<string> propertiesNames, List<object> values)
	{
		this.componentType = componentType;
		this.propertiesNames = propertiesNames;
		this.values = values;
	}


	public Type componentType;
	public List<string> propertiesNames;
	public List<object> values;
}

/* the classes below are used to serialize some of the unity classes that can't be serialized using binary
  serializing */

[System.Serializable]
public class SerializableVector2
{
	public SerializableVector2(Vector2 vector)
	{
		this.x = vector.x;
		this.y = vector.y;
	}
	public float x;
	public float y;
}
[System.Serializable]
public class SerializableVector3
{
	public SerializableVector3(Vector3 vector)
	{
		this.x = vector.x;
		this.y = vector.y;
		this.z = vector.z;
	}
	public float x;
	public float y;
	public float z;
}
[System.Serializable]
public class SerializableQuaternion
{

	public SerializableQuaternion(Quaternion quat) {
		this.x = quat.x;
		this.y = quat.y;
		this.z = quat.z;
		this.w = quat.w;
	}
	public float x;
	public float y;
	public float z;
	public float w;
}
[System.Serializable]
public class SerializableSprite
{
	public SerializableSprite(Sprite sprite)
	{
		this.spriteName = sprite.name;
	}
	public string spriteName;
}
[System.Serializable]
public class SerializableColor
{
	public SerializableColor(Color color)
	{
		this.r = color.r;
		this.g = color.g;
		this.b = color.b;
		this.a = color.a;
	}
	public float r;
	public float g;
	public float b;
	public float a;
}
[System.Serializable]
public class SerializableVector4
{
	public SerializableVector4(Vector4 vector)
	{
		this.x = vector.x;
		this.y = vector.y;
		this.z = vector.z;
		this.w = vector.w;
	}

	public float x;
	public float y;
	public float z;
	public float w;
}
[System.Serializable]
public class SerializableBounds
{
	public SerializableBounds(Bounds bounds)
	{
		this.center[0] = bounds.center.x;
		this.center[1] = bounds.center.y;
		this.center[2] = bounds.center.z;

		this.size[0] = bounds.size.x;
		this.size[1] = bounds.size.y;
		this.size[2] = bounds.size.z;
	}

	public float[] center = new float[3];
	public float[] size = new float[3];
}
[System.Serializable]
public class Serializable4x4Matrix
{
	public Serializable4x4Matrix(Matrix4x4 matrix)
	{
		this.data[0, 0] = matrix[0, 0];
		this.data[0, 1] = matrix[0, 1];
		this.data[0, 2] = matrix[0, 2];
		this.data[0, 3] = matrix[0, 3];


		this.data[1, 0] = matrix[1, 0];
		this.data[1, 1] = matrix[1, 1];
		this.data[1, 2] = matrix[1, 2];
		this.data[1, 3] = matrix[1, 3];


		this.data[2, 0] = matrix[2, 0];
		this.data[2, 1] = matrix[2, 1];
		this.data[2, 2] = matrix[2, 2];
		this.data[2, 3] = matrix[2, 3];


		this.data[3, 0] = matrix[3, 0];
		this.data[3, 1] = matrix[3, 1];
		this.data[3, 2] = matrix[3, 2];
		this.data[3, 3] = matrix[3, 3];
	}
	public float[,] data = new float[4, 4];
}
[System.Serializable]
public class SerializableAnimatorController
{
	public SerializableAnimatorController(RuntimeAnimatorController animatorController)
	{
		this.animatorControllerName = animatorController.name;
	}
	public string animatorControllerName;
}