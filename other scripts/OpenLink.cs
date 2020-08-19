using UnityEngine;
using System.Collections;

public class OpenLink : MonoBehaviour
{
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
        Debug.Log("TWITTER URL OPENED");
    }
}
