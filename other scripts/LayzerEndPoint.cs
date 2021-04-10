using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayzerEndPoint : MonoBehaviour
{
   public Vector2 direction = Vector2.up;
   public float speed = 25;
   public bool canMove = true;
   public bool layzerIsOn = false;
   private Rigidbody2D rb;
   private void Start()
    {
     rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(canMove && layzerIsOn)
        rb.velocity = speed * direction;
        else
        rb.velocity = Vector2.zero;
    }
    void OnTriggerEnter2D(Collider2D collider){
    	canMove = false;
    }
    void OnTriggerExit2D(Collider2D collider){
    	canMove = true;
    }
}
