using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "New Cannon Head",menuName = "Cannon/Cannon Shooter")]
public class CannonShooter : ScriptableObject
{
    //local scale of the cannon shooter object
    public Vector2 scale;
    //local position of the cannon shooter object
    public Vector2 localPos;
    //the name of the cannon shooter object
    public new string name;
    //the stroe icon
    public Sprite icon;
    //the game texture
    public Sprite texture;
    //other things
    public Vector2 shootingPointLocalPosition;
    public GameObject shootingEffect;
    public Shoot shoot;
    public float velocityBoost;
   
}
