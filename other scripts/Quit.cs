using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour
{
  public void Quit_()
  {
        Application.Quit();
        Debug.Log("Quit");
  }
}
