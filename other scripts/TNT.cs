using UnityEngine;
using System.Collections;
using System;
public class TNT : MonoBehaviour
{
    public void Explod()
    {
        GameObject explosionRangeObject = Instantiate(tntExplosionRangePrefab,transform.position,Quaternion.identity);
        explosionRangeObject.GetComponent<CircleCollider2D>().radius = explosionScale;
        GameObject explosionEf = Instantiate(explosionEffects,transform.position,Quaternion.identity);
        try
        {
            FindObjectOfType<SoundManager>().Play("TNT");
        }catch(Exception e) { }
        Destroy(explosionEf, 3f);
        Destroy(explosionRangeObject, 1f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet" || collision.collider.tag == "End Point")
            Explod();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TNT_Range")
            Explod();
    }
    public GameObject tntExplosionRangePrefab;
    public int explosionScale;
    public GameObject explosionEffects;
}
