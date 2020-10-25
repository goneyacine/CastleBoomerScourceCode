using UnityEngine;
using System.Collections;
using System;
public class Ballon : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "TNT_Range")
            Die();
    }
    public void Die()
    {
        GameObject effects = Instantiate(BallonEffects, transform.position, Quaternion.identity);
        Destroy(effects, 3f);
        try
        {
            FindObjectOfType<SoundManager>().Play("Ballon");
        }
        catch (Exception e) { }
        Destroy(gameObject);
    }
    public GameObject BallonEffects;
}
