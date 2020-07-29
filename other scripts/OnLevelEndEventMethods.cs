using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnLevelEndEventMethods : MonoBehaviour
{
    public GameObject losePanel;
    public List<GameObject> DisableWhenEnd;
    public ShootingManager shootingManager;

    public void EnableLosePanel()
    {
        losePanel.SetActive(true);
    }
    public void ScalingTime(float newTimeScale)
    {
        Time.timeScale = newTimeScale;
    }
    public void DisablingOnEnd()
    {
        foreach (GameObject obj in DisableWhenEnd)
            obj.SetActive(false);
        shootingManager.enabled = false;
    }
}
