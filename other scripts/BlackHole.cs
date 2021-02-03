using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
   public List<Rigidbody2D> effectedObjects = new List<Rigidbody2D>();
   public float grapingForce = 100f;
   public float effectingDistance = 5f;
   
   private void FixedUpdate(){
   	foreach(Rigidbody2D rb in effectedObjects){
   	 //checking if the target rigidbody is null
   	  if(rb != null){
   	  //checking if the target rb is inside the effecting area 
      if(Vector2.Distance(transform.position,rb.gameObject.transform.position) <= effectingDistance){
      //calculating the graping force	
      float force = Vector2.Distance(transform.position,rb.gameObject.transform.position) / effectingDistance * grapingForce;
      //applying the force
      rb.AddForce((transform.position - rb.gameObject.transform.position) * force * rb.mass);
   	}
   	}else{
   	 continue;
   	}
   }
  } 
  private void OnTriggerEnter2D(Collider2D other){Destroy(other.gameObject);}
 }
