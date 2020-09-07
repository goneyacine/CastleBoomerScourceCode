using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameOverButtons : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel(string levelSelectingSceneName)
    {
        int selectedLevelIndex = (int)DataSerialization.GetObject("selectedLevel");
        DataSerialization.SaveData(selectedLevelIndex + 1, "selectedLevel");
        SceneManager.LoadScene(levelSelectingSceneName);
    }
}