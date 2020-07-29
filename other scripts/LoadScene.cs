using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadScene_(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
