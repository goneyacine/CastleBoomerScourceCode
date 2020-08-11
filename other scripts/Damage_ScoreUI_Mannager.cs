using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Damage_ScoreUI_Mannager : MonoBehaviour
{
    public Castle_Manager castle_Manager;
    private int score;
    public Text ScoreText;
    public Text DamagePercentageText;
    public TMP_Text gameOverTotalXp;
    public TMP_Text gameOverDamagePercentage;
    private void Update()
    {
        score =(int) (castle_Manager.startSpace - castle_Manager.currentSpace);
        ScoreText.text = score.ToString() + " xp";
        DamagePercentageText.text = castle_Manager.damagePercentage.ToString() + "%";
        gameOverTotalXp.text = "Total XP : "  + score.ToString() + " XP";
        gameOverDamagePercentage.text = "Total Damage : " + castle_Manager.damagePercentage.ToString() + "%";
    }
}
