using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "New Castle Object", menuName = "Castle/Castle Object")]
public class Castle_Object : ScriptableObject
{
    public new string name;
    public bool isRandomBox = false;
    public Sprite icon;
    public float price;
    public Vector2 scale;
    public Vector2 boxColliderScale;
    public Sprite texture;
    public float maxHealth;
    public float space;
    public GameObject dieEffect;
    public bool effect_has_my_color = true;
    public UnityEvent onCreate;
    public UnityEvent onAlive;
    public UnityEvent onDestroy;
    //the damage value that should be taken when the object fall or hit something
    public float hitDamage;
    //needed speed value to damage the object when it's falling or hit something
    public float neededHitSpeed;
}
