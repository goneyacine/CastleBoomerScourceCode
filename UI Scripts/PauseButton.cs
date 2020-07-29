using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton  : MonoBehaviour
{
    public GameObject OnPauseUIElementsParent;
   public void Pause()
    {
        OnPauseUIElementsParent.SetActive(true);
        OnPauseUIElementsParent.GetComponent<Animator>().SetBool("Enable", true);
        OnPauseUIElementsParent.GetComponent<Animator>().SetBool("Disable", false);
        gameObject.SetActive(false);
    }
}
