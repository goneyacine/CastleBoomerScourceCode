using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
   public List<Rigidbody2D> effectedObjects = new List<Rigidbody2D>();
   public float grapingForce = 100f;
   public float effectingDistance = 5f;
   private int currentFrame = 0;
   public int maxFrames = 0;
   private void FixedUpdate(){
      if(currentFrame <= 0){
   	foreach(Rigidbody2D rb in effectedObjects){
   	 //checking if the target rigidbody is null
   	  if(rb != null){
         float distance = Vector2.Distance(transform.position,rb.gameObject.transform.position);
   	  //checking if the target rb is inside the effecting area 
      if( distance <= effectingDistance){
      //calculating the graping force	
      float force = distance / effectingDistance * grapingForce;
      //applying the force
      rb.AddForce((transform.position - rb.gameObject.transform.position) * force * rb.mass);
   	}
   	}else{
   	 continue;
   	}
   }
   currentFrame = maxFrames;
  }else 
   currentFrame--;
} 
  private void OnTriggerEnter2D(Collider2D other){Destroy(other.gameObject);}
 }
