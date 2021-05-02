using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    AnimatorManager animatorManager;

    Vector3 moveDirection;
    public Rigidbody playerRb;
    Transform cameraObject;

    [Header("Stats")]
    [SerializeField] float movementSpeed = 7f;
    [SerializeField] float rotationSpeed = 7f;

    private float animSpeed = 0f;
    public float Velocity { get { return animSpeed; } }

    public float backStepSpeed = -2f;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        animatorManager = GetComponent<AnimatorManager>();
        playerRb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }
    void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.VerticalInput;
        moveDirection += cameraObject.right * inputManager.HorizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * movementSpeed*Time.deltaTime;
        
        Vector3 movementVelocity = moveDirection;
        playerRb.velocity = movementVelocity;
    }
    void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * inputManager.VerticalInput;
        targetDirection += cameraObject.right * inputManager.HorizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
    
    public void HandleRollingAndBackStep()
    {
        if (animatorManager.animator.GetBool("isInteracting"))
            return;
        if (inputManager.rollFlag)
        {
            moveDirection = cameraObject.forward * inputManager.VerticalInput;
            moveDirection += cameraObject.right * inputManager.HorizontalInput;

            if(inputManager.moveAmount > 0)
            {
                animatorManager.PlayTargetAnimation("Rolling", true);
                moveDirection.y = 0;
                Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = rollRotation;
            }
            else
            {
                InputManager.instance.rollFlag = false;
            }
        }
        
    }
   

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
        HandleRollingAndBackStep();
    }
}
