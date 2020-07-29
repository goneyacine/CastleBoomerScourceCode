using UnityEngine;
using System.Collections;

public class OnPauseUIElementManager : MonoBehaviour
{
    public Animator animator;
    public GameObject pauseButton;
    public ShootingManager shootingManager;
    public LookAtMouse lookAtMouse;
    //when enable this object it'll play the Enable Animation
    private void OnEnable()
    {
        animator.SetBool("Enable", true);
        animator.SetBool("Disable", false);
 
    }
    //when the on enable animation event is called this method will be called too 
    public void OnEnableAnimationEndEvent()
    {
        animator.SetBool("Enable", false);
        animator.SetBool("Disable", false);
        shootingManager.enabled = false;
        lookAtMouse.enabled = false;
        Time.timeScale = 0;
    }
    //when the on disable animation event is called this method will be called too 
    public void OnDisableAnimationEndEvent() {
        animator.SetBool("Enable", false);
        animator.SetBool("Disable", false);
        pauseButton.SetActive(true);
        gameObject.SetActive(false);
        shootingManager.enabled = true;
        lookAtMouse.enabled = true;
    }
    //when the player click the continue button this method will be called
    public void Play()
    {
        Time.timeScale = 1;
        animator.SetBool("Enable", false);
        animator.SetBool("Disable", true);
    }
}
