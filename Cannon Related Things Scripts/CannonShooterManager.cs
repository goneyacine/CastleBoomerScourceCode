using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class CannonShooterManager : MonoBehaviour
{
    public CannonShooter cannonShooter;
    private void Update()
    {
        transform.localScale = cannonShooter.scale;
        transform.localPosition = cannonShooter.localPos;
        gameObject.GetComponent<SpriteRenderer>().sprite = cannonShooter.texture;
        transform.Find("Shooting Point").localPosition = cannonShooter.shootingPointLocalPosition;

    }
}
