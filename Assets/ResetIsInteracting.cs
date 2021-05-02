using UnityEngine;

public class ResetIsInteracting : StateMachineBehaviour
{
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isInteracting", false);
        InputManager.instance.rollFlag = false;
    }
}
