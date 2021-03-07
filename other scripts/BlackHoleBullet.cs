using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlackHoleBullet : MonoBehaviour
{
 public float grapingForce;
 [Range(0,60)]
 public int framesBetweenPhysicsUpdates = 4;
 private int currentFrame;
 //updating the physics frames info
 private void FixedUpdate(){
 	if(currentFrame <= 0)
 	currentFrame = framesBetweenPhysicsUpdates;
 	else
 	currentFrame--;
 }
 private void OnTriggerStay2D(Collider2D collider){
 if(currentFrame <= 0){
 	Rigidbody2D colliderRB = collider.GetComponent<Rigidbody2D>();
 	if(colliderRB != null)
 	colliderRB.AddForce(grapingForce * colliderRB.mass);
 }
 }
}