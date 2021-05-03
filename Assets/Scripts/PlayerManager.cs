using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerMovement playerMovement;
    Animator anim;
    private void Awake()
    {
        Cursor.visible = false;
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerMovement.HandleAllMovement();
    }
    private void LateUpdate()
    {
        inputManager.rb_Input = false;
        inputManager.rt_Input = false;
    }

}
