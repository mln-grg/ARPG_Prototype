using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;

    PlayerControls playerControls;
    
    AnimatorManager animatorManager;
    PlayerMovement playerMovement;
    PlayerAttacker playerAttacker;
    PlayerInventory playerInventory;
    public WeaponHolderSlot weaponHolder;

    Vector2 MovementInput;
    Vector2 CameraInput;
    float horizontalInput;
    float verticalInput;
    float mouseX;
    float mouseY;

    public bool rb_Input;
    public bool rt_Input;

    public bool sheatheUnsheathe_Input;
    public float moveAmount;
    public bool isInteracting;

    public float HorizontalInput { get { return horizontalInput; } }
    public float VerticalInput { get { return verticalInput; } }
    public bool b_Input;
    public bool rollFlag;

    public bool isHoldingWeapon;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        animatorManager = GetComponent<AnimatorManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttacker = GetComponent<PlayerAttacker>();
        playerInventory = GetComponent<PlayerInventory>();

    }
    private void Start()
    {
        isHoldingWeapon = false;
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
        HandleSheatheUnsheatheInput();
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
            if (animatorManager.animator.GetBool("isInteracting"))
                return;
            if (isHoldingWeapon)
                playerAttacker.HandleLightAttack(playerInventory.rightWeapon);
            else
                playerAttacker.HandleLightAttack(playerInventory.Unarmed);
        }
        if (rt_Input)
        {
            if (animatorManager.animator.GetBool("isInteracting"))
                return;
            if (isHoldingWeapon)
                playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);
            else
                playerAttacker.HandleHeavyAttack(playerInventory.Unarmed);
            
        }
    }
    private void HandleSheatheUnsheatheInput()
    {
        //playerControls.PlayerActions.SheatheUnsheathe.performed += i => sheatheUnsheathe_Input=true;
        //Debug.Log("dd");
        
        if (Keyboard.current.capsLockKey.wasPressedThisFrame)
            sheatheUnsheathe_Input = true;
        else
            sheatheUnsheathe_Input = false;
            if (sheatheUnsheathe_Input)
        {
            
            if (isHoldingWeapon)
            {
                animatorManager.animator.CrossFade(playerInventory.rightWeapon.sheathe, 0.2f);
                isHoldingWeapon = false;
            }
            else
            {
                animatorManager.animator.CrossFade(playerInventory.rightWeapon.unSheathe, 0.2f);
                isHoldingWeapon = true;
            }
        }
    }

}
