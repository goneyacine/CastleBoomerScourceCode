using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainMenuUiManager : MonoBehaviour
{
    public TMP_Text playerName;
    public TMP_Text xp;
    public TMP_Text profileLV;
    private void Start()
    {
        UpdateUI();
    }
    public void UpdateUI()
    {
        profileLV.text = ((int)DataSerialization.GetObject("LV")).ToString();
        playerName.text = (string)DataSerialization.GetObject("name");
        xp.text = ((int)DataSerialization.GetObject("xp")).ToString() + "xp";
    }
}
