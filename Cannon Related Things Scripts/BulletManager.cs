using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
public class BulletManager : MonoBehaviour
{
    public Bullet bullet;
    private UnityEvent onCreate;
    private UnityEvent onAlive;
    private UnityEvent onDie;
    private float time;
    private float deadTime;
    private void Start()
    {
        //set the needed unity event
        if(bullet.onCreate != null)
        onCreate = bullet.onCreate;
        if(bullet.onAlive != null)
        onAlive = bullet.onAlive;
        if(bullet.onDie != null)
        onDie = bullet.onDie;
        //set other values
        time = Time.time;
        deadTime = Time.time  + bullet.lifeTime;
        //adding line renderer and partical system componets if they are not null
        if (bullet.particleSystem != null)
        {
            ParticleSystem particalSystem = bullet.particleSystem;
            gameObject.AddComponent<ParticleSystem>();
        }
    }
    private void OnEnable()
    {
        if(onCreate != null)
        onCreate.Invoke();
    }
    private void OnDestroy()
    {
        try
        {
            FindObjectOfType<SoundManager>().Play("bullet");
        } catch (Exception e)
        {
            Debug.LogWarning(e);
        }
        //create bullet die effect
        if (bullet.bulletDieEffect != null)
        {
            GameObject dieEffect = Instantiate(bullet.bulletDieEffect,transform.position,bullet.bulletDieEffect.transform.rotation);
          //  dieEffect.transform.localScale = transform.localScale;
            if(bullet.effect_has_my_color)
            //.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
            Destroy(dieEffect, 5f);
        }
        //call the die event
        if(onDie != null)
        onDie.Invoke();
    }
    private void Update()
    {
        //set the mass of the bullet
        GetComponent<Rigidbody2D>().mass = bullet.mass;
        //update the bullet living time 
        time = Time.time;
        //set the texture of the bullet
        GetComponent<SpriteRenderer>().sprite = bullet.texture;
        //set the color of the bullet 
        GetComponent<SpriteRenderer>().color = bullet.color;
        //set the scale of the bullet 
        transform.localScale = bullet.scale;
        //when the player is alive we invoke onAlive() event
        if(onAlive != null)
        onAlive.Invoke();
        //check if the living time of the bullet is bigger than or equal the max life time if it is than the bullet should dead
        if (time >= deadTime)
            Destroy(gameObject);
        transform.eulerAngles += Vector3.forward * bullet.roatingSpeed;
        GetComponent<CircleCollider2D>().radius = bullet.circleColiderRadius;
        GetComponent<CircleCollider2D>().offset = bullet.circleColiderPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
