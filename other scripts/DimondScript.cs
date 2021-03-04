using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimondScript : MonoBehaviour {
	//the object used to balance the dimond object,
   // if this object is not set or is destroyed we remove the spring joint component,
   // so the dimond object can fall.
	public GameObject balanceObject;
    public float deadVelocity = 5f;
    private Rigidbody2D rb;
	//we don't update the data every frame because of the optimization so we do it every 6 frames
    int currentRate;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update(){
     if(currentRate < 6)
     currentRate ++;
     else {
     	if(balanceObject == null)
     	Destroy(GetComponent<SpringJoint2D>());
     currentRate = 0;
     }
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TNT_Range")
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision){
    if(rb.velocity.x > deadVelocity || rb.velocity.y > deadVelocity)
        Destroy(gameObject);
    }
    private void OnDestroy(){
    	//when the dimond object is destroyed the player lose
    	FindObjectOfType<Level_End_Checker>().GetComponent<Level_End_Checker>().Lose();
    }
}