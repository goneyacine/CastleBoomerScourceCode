using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainMenuUiManager : MonoBehaviour
{
    public TMP_Text playerName;
    public TMP_Text xp;
    public TMP_Text stars;
    public Text gold;
    public Text money;
    public Text lv;
    private void Update()
    {
        lv.text = "LV " + ((int)DataSerialization.GetObject("LV")).ToString();
        money.text = ((int)DataSerialization.GetObject("money")).ToString();
        gold.text = ((int)DataSerialization.GetObject("gold")).ToString();
        playerName.text = (string)DataSerialization.GetObject("name");
        xp.text = ((int)DataSerialization.GetObject("xp")).ToString() + "xp";
        List<int> levelStars =(List<int>)DataSerialization.GetObject("singlePlayerStars");
        int totalStars = 0;
        foreach (int i in levelStars)
            totalStars += i;
        int maxStars = ((int)DataSerialization.GetObject("lastOpenedLevel")) * 3;
        stars.text = totalStars.ToString() + "/" + maxStars.ToString(); 
    }
}
