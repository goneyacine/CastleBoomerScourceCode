using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Level_End_Checker : MonoBehaviour
{

    public CannonHeadBulletsManager bulletsManager;
    public Castle_Manager castle_Manager;
    public UnityEvent onEndLevel;
    public int finalScore;
    public int starsNum;
    //if it's true then nothing in castle is moving
    private bool noThingIsMoving = true;
    //bullets array
    private GameObject[] bullets;
    void Update()
    {
        //find the bullets number
        int bulletsNumber = 0;
        foreach (int num in bulletsManager.bulletsNumbers)
            bulletsNumber += num;
        //find if any of the castle objects are moving
         noThingIsMoving = true;
         for(int i = 0; i < castle_Manager.transform.childCount; i++)
         {
            if (castle_Manager.transform.GetChild(i).GetComponent<Rigidbody2D>().velocity != Vector2.zero) {
                noThingIsMoving = false;
                break;
            }
         }
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
     
        if ((castle_Manager.damagePercentage >= 99 || bulletsNumber == 0) && noThingIsMoving && bullets.Length == 0)
            OnEndLevel();
    }
    public void OnEndLevel()
    {
        finalScore = castle_Manager.damagePercentage;
        if (finalScore < 50)
            starsNum = 0;
        else if (finalScore >= 50 && finalScore < 75)
            starsNum = 1;
        else if (finalScore >= 75 && finalScore < 99)
            starsNum = 2;
        else
            starsNum = 3;
        onEndLevel.Invoke();
    }
}
