using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Castle_Object_Manager : MonoBehaviour
{
    
    public Castle_Object castle_Object;
    public float health;
    private void Start()
    {
        health = castle_Object.maxHealth;
    }

    private void Update()
    {
        //set the texture of the castle object 
        GetComponent<SpriteRenderer>().sprite = castle_Object.texture;
        //set the color of the castle object
        GetComponent<SpriteRenderer>().color = castle_Object.color;
        //set the scale
        transform.localScale = castle_Object.scale;
        //set the size of the box collider 
        GetComponent<BoxCollider2D>().size = castle_Object.boxColliderScale;
        //calling "onAlive" unity event
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
            health -= collision.collider.GetComponent<BulletManager>().bullet.damage;
        else if (collision.collider.tag == "Lava")
            health = 0;
        if (GetComponent<Rigidbody2D>().velocity.y >= castle_Object.neededHitSpeed || GetComponent<Rigidbody2D>().velocity.x >= castle_Object.neededHitSpeed)
        {
            health -= castle_Object.hitDamage;
            Castle_Object_Manager colliderCastleObjectManager = collision.collider.GetComponent<Castle_Object_Manager>();
            if (colliderCastleObjectManager != null &&
            (colliderCastleObjectManager.castle_Object.neededHitSpeed <= GetComponent<Rigidbody2D>().velocity.y ||
             colliderCastleObjectManager.castle_Object.neededHitSpeed <= GetComponent<Rigidbody2D>().velocity.x))
            {
                colliderCastleObjectManager.health -= colliderCastleObjectManager.castle_Object.hitDamage;
            }
        }
    }
    //the die method
    private void Die()
    {
        //destroy the object
        Destroy(gameObject);
        //create die effects
        if(castle_Object.dieEffect != null)
        {
            GameObject dieEffect = Instantiate(castle_Object.dieEffect, transform.position, castle_Object.dieEffect.transform.rotation);
            Destroy(dieEffect, 5f);
        }
    }
    private void OnEnable()
    {
        castle_Object.onCreate.Invoke();
    }
    private void OnDestroy()
    {
        castle_Object.onDestroy.Invoke();
    }
}
