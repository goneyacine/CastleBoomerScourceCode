using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Cannon Head",menuName = "Cannon/Cannon Head")]
public class CannonHead : ScriptableObject
{
    //the store icon of the cannon headC:\Users\dtech\Castle Boomer\Assets\Scripts\CannonHead.cs
    public Sprite icon;
    //the image or the texture of the cannon head 
    public Sprite texture;
    //the name of the cannon head
    public new string name;
    //the scale of the cannon head
    public Vector2 scale;
    //the min and the max power of the cannon head 
    public float MaxSpace;
    //the local position of the cannon head
    public Vector2 localPos;
    public Color color;
   
}
