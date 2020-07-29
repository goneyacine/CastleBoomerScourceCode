using UnityEngine;
using UnityEngine.UI;

public class Damage_ScoreUI_Mannager : MonoBehaviour
{
    public Castle_Manager castle_Manager;
    private int score;
    public Text ScoreText;
    public Text DamagePercentageText;

    private void Update()
    {
        score =(int) (castle_Manager.startSpace - castle_Manager.currentSpace);
        ScoreText.text = score.ToString() + " xp";
        DamagePercentageText.text = castle_Manager.damagePercentage.ToString() + "%";
    }
}
