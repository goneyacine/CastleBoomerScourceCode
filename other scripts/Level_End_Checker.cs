using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class Level_End_Checker : MonoBehaviour
{

    public CannonHeadBulletsManager bulletsManager;
    public Castle_Manager castle_Manager;
    private Damage_ScoreUI_Mannager damage_ScoreUI_Mannager;
    public UnityEvent onEndLevel;
    public int finalScore;
    //if it's true then nothing in castle is moving
    private bool noThingIsMoving = true;
    //bullets array
    private GameObject[] bullets;
    private bool done = false;
    public TMP_Text loseOrWin;
    public bool isMultiplayer = false;
    private void OnEnable()
    {
        damage_ScoreUI_Mannager = FindObjectOfType<Damage_ScoreUI_Mannager>();
    }
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
        if (!done)
        {
            if ((castle_Manager.damagePercentage >= 95 || bulletsNumber == 0) && noThingIsMoving && bullets.Length == 0)
                Invoke("OnEndLevel", .3f);
        }
        if(isMultiplayer){
            if(oneVoneVarManager.OneVoneVarManager.gameDone){
              oneVoneVarManager.OneVoneVarManager.waitingResults.SetActive(false);
              onEndLevel.Invoke();
            }else if(oneVoneVarManager.OneVoneVarManager.localGameDone && !oneVoneVarManager.OneVoneVarManager.gameDone){
              oneVoneVarManager.OneVoneVarManager.waitingResults.SetActive(false);
            }
        }
    }
    public void OnEndLevel()
    {
        if (done)
            return;
        finalScore = castle_Manager.damagePercentage;
        if (finalScore >= 50 && !isMultiplayer)
        {
          if((int)DataSerialization.GetObject("selectedLevel") + 1 == (int)DataSerialization.GetObject("lastOpenedLevel"))
          DataSerialization.SaveData((int)DataSerialization.GetObject("lastOpenedLevel") + 1, "lastOpenedLevel");
            loseOrWin.text = "Win";
        }
        else
        {
            if(!isMultiplayer)
            loseOrWin.text = "Lose";
        }
        DataSerialization.SaveData((int)DataSerialization.GetObject("xp") + damage_ScoreUI_Mannager.score, "xp");
        if(!isMultiplayer){
        done = true;
        onEndLevel.Invoke();
        }
        else{
        oneVoneVarManager.OneVoneVarManager.localGameDone = true;
        oneVoneVarManager.OneVoneVarManager.myTotalXP = damage_ScoreUI_Mannager.score;
        oneVoneVarManager.OneVoneVarManager.myTotalDamage = damage_ScoreUI_Mannager.castle_Manager.damagePercentage;

    }
    }
}
