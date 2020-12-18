using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
[ExecuteInEditMode]
public class Castle_Object_Manager : MonoBehaviour
{
    
    public Castle_Object castle_Object;
    public float health;
    public UnityEvent dieEvent;
    public UnityEvent hitEvent;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rb;
    private void Start()
    {
        health = castle_Object.maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //set the texture of the castle object 
        spriteRenderer.sprite = castle_Object.texture;
        //set the color of the castle object
        spriteRenderer.color = castle_Object.color;
        //set the scale
        transform.localScale = castle_Object.scale;
        //set the size of the box collider 
        boxCollider2D.size = castle_Object.boxColliderScale;
        //calling "onAlive" unity event
        if(castle_Object.onAlive != null)
        castle_Object.onAlive.Invoke();
        //check if the object is still alive if not then die
        if(health <= 0)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if a bullet hit this object , if that happen then take damage
        if (collision.collider.tag == "Bullet")
        {
            health -= collision.collider.GetComponent<BulletManager>().bullet.damage;
        }
       
        if (rb.velocity.y >= castle_Object.neededHitSpeed || rb.velocity.x >= castle_Object.neededHitSpeed)
        {
            if (collision.collider.tag != "Bullet" || collision.collider.tag != "TNT_Range")
            {
                try
                {
                    FindObjectOfType<SoundManager>().Play("hit");
                }
                catch (Exception e) { }
            }
            health -= castle_Object.hitDamage;
            Castle_Object_Manager colliderCastleObjectManager = collision.collider.GetComponent<Castle_Object_Manager>();
            if (colliderCastleObjectManager != null &&
            (colliderCastleObjectManager.castle_Object.neededHitSpeed <= rb.velocity.y ||
             colliderCastleObjectManager.castle_Object.neededHitSpeed <= rb.velocity.x))
            {
                colliderCastleObjectManager.health -= colliderCastleObjectManager.castle_Object.hitDamage;
            }

        }
        
        hitEvent.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "TNT_Range")
        {
            health = 0;
        }
    }
    //the die method
    private void Die()
    {
        try
        {
            FindObjectOfType<SoundManager>().Play("hit");
        }catch(Exception e) { }
        dieEvent.Invoke();
        //create die effects
        if(castle_Object.dieEffect != null)
        {
            GameObject dieEffect = Instantiate(castle_Object.dieEffect, transform.position, castle_Object.dieEffect.transform.rotation);
            Destroy(dieEffect, 5f);
        }
        Destroy(gameObject);
    }
   
    private void OnDestroy()
    {
        try
        {
            FindObjectOfType<Castle_Manager>().UpdateData();
        }catch(Exception e) { }
    }
}
