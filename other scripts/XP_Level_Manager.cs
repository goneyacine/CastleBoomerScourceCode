using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class XP_Level_Manager : MonoBehaviour
{
    public List<int> NEEDED_XP_FOREACH_LEVEL;
    private int currentXP_Level = 1;
    public Text currentXPText;
    public Text neededXPToNextLevelText;
    private bool canStart = true;
    private void Update()
    {
        if (canStart)
        {
            for (int i = 0; i < NEEDED_XP_FOREACH_LEVEL.Count; i++)
            {
                if ((int)DataSerialization.GetObject("xp") >= NEEDED_XP_FOREACH_LEVEL[i])
                    currentXP_Level = i + 1;
                else
                    break;
            }
            if (NEEDED_XP_FOREACH_LEVEL.Count - 1 == currentXP_Level)
            {

                currentXPText.text = "";
                neededXPToNextLevelText.text = "";
            }
            else
            {
                currentXPText.text = ((int)DataSerialization.GetObject("xp")).ToString() + "xp /";
                neededXPToNextLevelText.text = NEEDED_XP_FOREACH_LEVEL[currentXP_Level].ToString() + "xp";
            }
            DataSerialization.SaveData(currentXP_Level, "LV");

        }
        canStart = false;
    }
}
