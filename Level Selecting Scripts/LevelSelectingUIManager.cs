using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelectingUIManager : MonoBehaviour
{

    public string targetScene;
    public LevelSelectingSceneManager levelSelectingSceneManager;
    public Image BackGroundPanelA;
    public Image BackGroundPanelAA;
    public Image BackGroundPanelB;
    public Image BackGroundPanelBB;
    public Sprite lockedLevelSprite;
    public Sprite unlockedLevelSprite;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Play()
    {
        if (levelSelectingSceneManager.targetLevelIndex == levelSelectingSceneManager.lastOpenedLevel)
            DataSerialization.SaveData(true,"IsThisLastOpenedLevel");
        else
            DataSerialization.SaveData(false, "IsThisLastOpenedLevel");
        SceneManager.LoadScene(targetScene);
    }
    private void Update()
    {
        //checking when if we should disable the background panels and when i should change the sprite
         //when i should change the sprite (to locked orr unlocked)
        if(levelSelectingSceneManager.targetLevelIndex == levelSelectingSceneManager.openedLevels.Count - 1)
        {
            BackGroundPanelA.sprite = lockedLevelSprite;
            BackGroundPanelAA.sprite = lockedLevelSprite;
        }else if (levelSelectingSceneManager.targetLevelIndex == levelSelectingSceneManager.openedLevels.Count - 2)
        {
            BackGroundPanelA.sprite = unlockedLevelSprite;
            BackGroundPanelAA.sprite = lockedLevelSprite;
        }else if (levelSelectingSceneManager.targetLevelIndex < levelSelectingSceneManager.openedLevels.Count - 2)
        {
            BackGroundPanelA.sprite = unlockedLevelSprite;
            BackGroundPanelAA.sprite = unlockedLevelSprite;
        }
         //when i should enable the panels
         if(levelSelectingSceneManager.targetLevelIndex == 0)
        {
            BackGroundPanelBB.gameObject.SetActive(false);
            BackGroundPanelB.gameObject.SetActive(false);
        }else if(levelSelectingSceneManager.targetLevelIndex == 1)
        {
            BackGroundPanelBB.gameObject.SetActive(false);
            BackGroundPanelB.gameObject.SetActive(true);
        }else if (levelSelectingSceneManager.targetLevelIndex > 1)
        {
            BackGroundPanelBB.gameObject.SetActive(true);
            BackGroundPanelB.gameObject.SetActive(true);
        }

        if (levelSelectingSceneManager.targetLevelIndex == levelSelectingSceneManager.levels.Count -1)
        {
            BackGroundPanelA.gameObject.SetActive(false);
            BackGroundPanelAA.gameObject.SetActive(false);
        }else if (levelSelectingSceneManager.targetLevelIndex == levelSelectingSceneManager.levels.Count - 2)
        {
            BackGroundPanelA.gameObject.SetActive(true);
            BackGroundPanelAA.gameObject.SetActive(false);
        }else if (levelSelectingSceneManager.targetLevelIndex < levelSelectingSceneManager.levels.Count - 2)
        {
            BackGroundPanelA.gameObject.SetActive(true);
            BackGroundPanelAA.gameObject.SetActive(true);
        }
    }
    public void GoLeft()
    {
        levelSelectingSceneManager.targetLevelIndex--;
        animator.SetBool("Go Left", true);
        animator.SetBool("Go Right", false);
    }
    public void GoRight()
    {
        levelSelectingSceneManager.targetLevelIndex++;
        animator.SetBool("Go Left", false);
        animator.SetBool("Go Right", true);
    }
    public void EndAnimation()
    {
        animator.SetBool("Go Left",false);
        animator.SetBool("Go Right",false);
    }
}

