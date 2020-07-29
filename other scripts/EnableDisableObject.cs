using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableObject : MonoBehaviour
{
    public GameObject game_object;
    public void EnableObject()
    {
        game_object.SetActive(true);
    }
    public void DisableObject()
    {
        game_object.SetActive(false);
    }
}
