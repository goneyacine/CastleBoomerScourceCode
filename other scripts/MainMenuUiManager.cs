using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainMenuUiManager : MonoBehaviour
{
    public TMP_Text playerName;
    public TMP_Text xp;
    public Text gold;
    public Text money;
    public Text lv;
    public TMP_Text profileLV;
    private void Update()
    {
        lv.text = "LV " + ((int)DataSerialization.GetObject("LV")).ToString();
        profileLV.text = ((int)DataSerialization.GetObject("LV")).ToString();
        money.text = ((int)DataSerialization.GetObject("money")).ToString();
        gold.text = ((int)DataSerialization.GetObject("gold")).ToString();
        playerName.text = (string)DataSerialization.GetObject("name");
        xp.text = ((int)DataSerialization.GetObject("xp")).ToString() + "xp";
    }
}
