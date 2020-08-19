using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class Castle_Manager : MonoBehaviour
{
    public List<Castle_Object> castle_Objects;
    private GameObject[] castleObjects_Obj;
    public float startSpace = 0;
    public float currentSpace;
    public int damagePercentage;
    public int gold = 0;
    public int money = 0;
    public TMP_Text gameOverTotalGoldText;
    public TMP_Text gameOverTotalMoneyText;
    private void Start()
    {
        UpdateCastleObjectList();
        foreach(Castle_Object CO in castle_Objects) {
            if (((bool)DataSerialization.GetObject("playerCurrentLevel") &&(bool)DataSerialization.GetObject("IsThisLastOpenedLevel"))
                || (bool)DataSerialization.GetObject("IsThisLastOpenedLevel"))
            {
                startSpace += CO.space / 10;
            }
            else
            {
                startSpace += CO.space;
            }
        }
        currentSpace = startSpace;
    }

    private void Update()
    {
        UpdateCastleObjectList();
        currentSpace = 0;
        foreach (Castle_Object CO in castle_Objects)
        {
            if (((bool)DataSerialization.GetObject("playerCurrentLevel")&& (bool) DataSerialization.GetObject("IsThisLastOpenedLevel") 
                || (bool)DataSerialization.GetObject("IsThisLastOpenedLevel"))) {
                currentSpace += CO.space / 10;
            }
            else
            {
                currentSpace += CO.space;
            }
        }
        damagePercentage = (int)((startSpace - currentSpace) * 100 / (Mathf.Abs(startSpace) + 1));
        if (damagePercentage == 99)
            damagePercentage++;
        gameOverTotalGoldText.text = "Gold : " + gold.ToString();
        gameOverTotalMoneyText.text = "Money : " +  money.ToString();
    }
    private void UpdateCastleObjectList()
    {
        castleObjects_Obj = GameObject.FindGameObjectsWithTag("CastleObject");
        castle_Objects = new List<Castle_Object>();
        foreach (GameObject obj in castleObjects_Obj)
        {
            castle_Objects.Add(obj.GetComponent<Castle_Object_Manager>().castle_Object);
        }
    }
  
}
