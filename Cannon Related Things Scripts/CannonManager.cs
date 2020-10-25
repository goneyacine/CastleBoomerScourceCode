using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CannonManager : MonoBehaviour
{
    public List<Cannon> cannons;
    public Cannon DefaultCannon;
    private Cannon targetCannon;
    
    private void Start()
    {
        string cannonName = null;
        try
        {
            cannonName = (string)DataSerialization.GetObject("Cannon");
        } catch (Exception e) { }
        if (cannonName != null)
            StartCoroutine("FindCannon", cannonName);
        else
            targetCannon = DefaultCannon;
        FindObjectOfType<CannonBodyManager>().cannonBody = targetCannon.cannonBase;
        FindObjectOfType<CannonHeadManager>().cannonHead = targetCannon.ammunitionStore;
        FindObjectOfType<CannonShooterManager>().cannonShooter = targetCannon.cannonMuzzle;
    }
    IEnumerator FindCannon(string cannonName)
    {
        foreach(Cannon cannon in cannons)
        {
            if (cannon.name == cannonName)
            {
                targetCannon = cannon;
                break;
            }else
            {
                continue;
            }
        }
        if (targetCannon == null)
            targetCannon =cannons[0];
        yield return null;
    }
}
