using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce_ : MonoBehaviour
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(direction * speed); 
    }
    private Rigidbody2D rb;
    public float speed = 1f;
    public Vector2 direction = Vector2.right;
}
