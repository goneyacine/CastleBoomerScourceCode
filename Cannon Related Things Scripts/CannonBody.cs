using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "New Cannon Body" , menuName = "Cannon/Cannon Body")]
public class CannonBody : ScriptableObject
{
    public Vector2 scale;
    public Vector2 localPos;
    public new string name;
    public Sprite icon;
    public Sprite texture;
    public Color color;
}
