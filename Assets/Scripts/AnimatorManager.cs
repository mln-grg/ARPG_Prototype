using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public InputManager inputManager;
    public PlayerMovement playerMovement;
    int horizontal;
    int vertical;
    //int velocity;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
        //velocity = Animator.StringToHash("Velocity");
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
    {
        animator.SetFloat(horizontal, horizontalMovement, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, verticalMovement, 0.1f, Time.deltaTime);
    }

    public void PlayTargetAnimation(string targetAnim, bool isInteracting)
    {
        inputManager.rollFlag = false;
        animator.applyRootMotion = isInteracting;
        animator.SetBool("isInteracting", isInteracting);
        animator.CrossFade(targetAnim, 0.2f);
    }


    private void OnAnimatorMove()
    {
        if (inputManager.isInteracting == false)
            return;
        float delta = Time.deltaTime;
        playerMovement.playerRb.drag = 0f;
        Vector3 deltaPosition = animator.deltaPosition;
        deltaPosition.y = 0;
        Vector3 velocity = deltaPosition / delta;
        playerMovement.playerRb.velocity = velocity;
    }
}
