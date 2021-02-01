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
   	  if(rb != null){
      if(Vector2.Distance(transform.position,rb.gameObject.transform.position) <= effectingDistance){
      float force = Vector2.Distance(transform.position,rb.gameObject.transform.position) / effectingDistance * grapingForce;
      rb.AddForce((transform.position - rb.gameObject.transform.position) * force);
   	}
   	}else{
   	 continue;
   	}
   }
  }
 }
