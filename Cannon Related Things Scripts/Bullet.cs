using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "New Bullet", menuName = "Cannon/Bullet")]
public class Bullet : ScriptableObject
{
    public Sprite icon;
    public Sprite texture;
    public new string name;
    public Vector2 scale;
    public float space;
    public float price;
    public float damage;
    public float lifeTime;
    public Color color;
    public float velocity;
    public UnityEvent onCreate;
    public UnityEvent onAlive;
    public UnityEvent onDie;
    public float mass;
    public GameObject bulletDieEffect;
    public bool effect_has_my_color = true;
    public float roatingSpeed;
    public float circleColiderRadius;
    public Vector2 circleColiderPos;
    public LineRenderer lineRenderer;
    public ShapeAlgorithm shapeAlgorithm;
    public ParticleSystem particleSystem;
}
public interface ShapeAlgorithm
{
 void DrawShape(LineRenderer lineRenderer);
}
