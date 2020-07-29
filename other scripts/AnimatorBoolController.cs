using UnityEngine;

public class AnimatorBoolController : MonoBehaviour
{
    public Animator animator;
    public new string name;
    public bool value;
    public void SetAnimatorBool(){ animator.SetBool(name, value); }

}
