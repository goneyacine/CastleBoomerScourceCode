using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LevelSelectingSceneManager : MonoBehaviour
{
    public List<LevelObject> levels;
    public int lastOpenedLevel;
    public List<LevelObject> openedLevels;
    public int targetLevelIndex = 0;
    public LevelDisplayUIManager levelDisplayUIManager;
    public LevelSelectingUIManager levelSelectingUIManager;
    private void Start()
    {
       targetLevelIndex = (int)DataSerialization.GetObject("selectedLevel");
    }
    private void Update()
    {
        lastOpenedLevel = (int)DataSerialization.GetObject("lastOpenedLevel");
        //refresh the opened levels list
        openedLevels = new List<LevelObject>();
        for (int i = 0; i < lastOpenedLevel; i++)
        {
            openedLevels.Add(levels[i]);
        }
        if (targetLevelIndex < 0)
            targetLevelIndex = openedLevels.Count - 1;
        else if (targetLevelIndex > openedLevels.Count - 1)
            targetLevelIndex = 0;
        DataSerialization.SaveData(targetLevelIndex, "selectedLevel");
        levelDisplayUIManager.targetLevelObject = levels[targetLevelIndex];
        levelSelectingUIManager.targetScene = levels[targetLevelIndex].sceneName;
    }
}
