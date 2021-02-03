using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBulletHit : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision){
   	if(collision.collider.tag == "Bullet")
   	 Destroy(gameObject);
   }
   private void OnColliderEnter2D(Collider2D other){
   	if(other.tag == "Bullet")
   	 Destroy(gameObject);
   }
}
