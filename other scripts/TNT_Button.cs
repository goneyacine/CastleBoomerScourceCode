using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TNT_Button : MonoBehaviour
{
     private void OnCollisionEnter2D(Collision2D collision)
    {
        TNT[] tnts = FindObjectsOfType<TNT>();
        foreach (TNT tnt in tnts)
        {
            tnt.Explod();
        }
    }
}