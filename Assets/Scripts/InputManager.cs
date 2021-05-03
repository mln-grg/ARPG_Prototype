using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;

    PlayerControls playerControls;
    
    AnimatorManager animatorManager;
    PlayerMovement playerMovement;
    PlayerAttacker playerAttacker;
    PlayerInventory playerInventory;

    Vector2 MovementInput;
    Vector2 CameraInput;
    float horizontalInput;
    float verticalInput;
    float mouseX;
    float mouseY;

    public bool rb_Input;
    public bool rt_Input;

    public float moveAmount;
    public bool isInteracting;

    public float HorizontalInput { get { return horizontalInput; } }
    public float VerticalInput { get { return verticalInput; } }
    public bool b_Input;
    public bool rollFlag;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        animatorManager = GetComponent<AnimatorManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttacker = GetComponent<PlayerAttacker>();
        playerInventory = GetComponent<PlayerInventory>();

    }
    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => MovementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => CameraInput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleRollInput();
        HandleAttackInput();

    }
    
    void HandleMovementInput()
    {
        horizontalInput = MovementInput.x;
        verticalInput = MovementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        mouseX = CameraInput.x;
        mouseY = CameraInput.y;
        animatorManager.UpdateAnimatorValues(0, moveAmount); 
    }
    private void HandleRollInput()
    {
        b_Input = playerControls.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
        if (b_Input)
        {
            rollFlag = true;
        }
    }

    private void HandleAttackInput() 
    {
        playerControls.PlayerActions.RB.performed += i => rb_Input = true;
        playerControls.PlayerActions.RT.performed += i => rt_Input = true;

        if (rb_Input)
        {
            playerAttacker.HandleLightAttack(playerInventory.rightWeapon); 
        }
        if (rt_Input)
        {
            playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);
        }
    }

}
