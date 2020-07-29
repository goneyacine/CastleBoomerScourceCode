using UnityEngine;
[CreateAssetMenu (fileName = "New Level",menuName = "Level")]
public class LevelObject : ScriptableObject
{
    public string sceneName;
    public Sprite icon;
    public new string name;
    public bool isOpened = false;
}
