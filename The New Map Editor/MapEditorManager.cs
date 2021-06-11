using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class MapEditorManager : MonoBehaviour
{
  public MapEditorManager() {
    if (mapEditorManager == null)
      mapEditorManager = this;
    else
      Destroy(this);
  }
  private void Start() {
    //I'm setting the time value to 0 so the physics will not work when the player is making a level
    Time.timeScale = 0;

    LoadLevels();
  }
  private void Update() {
    //setting the position of the transform & rotatings tools
    if (selectedMapEditorObject != null)
    {
      transformTool.gameObject.SetActive(true);
      rotatingTool.gameObject.SetActive(true);
      transformTool.position = selectedMapEditorObject.gameObject.transform.position;
      rotatingTool.position =  selectedMapEditorObject.gameObject.transform.position;
    } else {
      transformTool.gameObject.SetActive(false);
      rotatingTool.gameObject.SetActive(false);
    }
    //doing the rotating & the trasforming things
    if (selectedMapEditorObject != null) {
      if (Input.GetMouseButton(0) || Input.touchCount > 0) {
        if (playerIsRotating)
          Rotate();
        else if (playerIsTransforming)
          Transform();

      }
    }
    if (selectedMapEditorObject != null)
      myOldPosition = (Vector2)selectedMapEditorObject.transform.position;
    oldMousePosition = (Vector2)mouseFollower.position;
  }
  public void Rotate()
  {
    Vector2 mouseDirection = ((Vector2)mouseFollower.position - (Vector2)selectedMapEditorObject.transform.position) / Vector2.Distance((Vector2)mouseFollower.position, selectedMapEditorObject.transform.position);
    selectedMapEditorObject.transform.eulerAngles = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg * Vector3.forward;
  }
  public void Transform()
  {
    selectedMapEditorObject.transform.position = myOldPosition + ((Vector2)mouseFollower.position - oldMousePosition) * transformAxis * transformSpeed;
  }

  public void SetPlayerIsRotating(bool value) {this.playerIsRotating = value;}
  public void SetPlayerIsTransfroming(bool value) {this.playerIsTransforming = value;}

  public void SetAxisToX() {this.transformAxis = Vector2.right;}
  public void SetAxisToY() {this.transformAxis = Vector2.up;}
  public void SetAxisToAll() {this.transformAxis = Vector2.one;}

  public void DestroySelectedObject()
  {
    Destroy(selectedMapEditorObject.gameObject);
  }
  public void QuitMapEditor()
  {
    //when the player quits the level editor we should reset the time scale to 1 so everything will work normally
    Time.timeScale = 1;
  }
  /*this method is used to load the saved levels from the multiplayer levels folder, it should be called every
  time we update the data in that folder*/
  public void LoadLevels()
  {

    levels = new List<Level>();
    string[] filePaths = Directory.GetFiles(Application.persistentDataPath + "/Multiplayer Levels/", "*.level");
    BinaryFormatter formatter = new BinaryFormatter();

    foreach (string path in filePaths)
    {
      FileStream stream = new FileStream(path, FileMode.Open);
      levels.Add(formatter.Deserialize(stream) as Level);
      stream.Close();
    }
    UpdateUI();
  }
  public void UpdateUI()
  {
      for (int i = 0; i <= 3; i++)
      {
        if (startingIndex + i >= levels.Count)
        {
          levelPanels[i].parent.SetActive(false);
          continue;
        }
        else
        {
          levelPanels[i].parent.SetActive(true);
          levelPanels[i].levelNameText.text = levels[i].name;
        }
      }
  }
  public void DelteLevel(int panelIndex)
  {
    string levelPath = Application.persistentDataPath + "/Multiplayer Levels/" + levels[startingIndex + panelIndex].name + ".level";
    File.Delete(levelPath);
    LoadLevels();
    UpdateUI();
  }
  public void OpenLevel(int panelIndex)
  {
    string levelName = levels[startingIndex + panelIndex].name;
    saver.OpenLevel(levelName);
  }
  public void UpdateStartingIndex(int updateValue)
  {
    if (startingIndex + updateValue >= 0 && startingIndex + updateValue < levels.Count)
      startingIndex += updateValue;
    else if (startingIndex + updateValue < 0)
      startingIndex = 0;
    else if (startingIndex + updateValue >= levels.Count)
      startingIndex = levels.Count - 1;
  }

  public static MapEditorManager mapEditorManager;
//the selected map editor object
  public MapEditorObject selectedMapEditorObject;
//the trasnform of the transform & rotating tools
  public Transform transformTool;
  public Transform rotatingTool;
//the mouse follower transform (the mouse follower follows the mouse & also follows touch)
  public Transform mouseFollower;

  private bool playerIsRotating = false;
  private bool playerIsTransforming = false;

  private Vector2 myOldPosition;
  private Vector2 oldMousePosition;

  public Vector2 transformAxis;
  private List<Level> levels;

  [Range(.001f, 500f)]
  public float transformSpeed = 1.5f;

  public int startingIndex = 0;

  public List<LevelPanel> levelPanels;
  public LevelSaver saver;

}
[System.Serializable]
public class LevelPanel
{
  public GameObject parent;
  public Text levelNameText;
}