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

        inputManager.isInteracting = anim.GetBool("isInteracting");
        /*if (!inputManager.isInteracting)
        {
            if (inputManager.rollFlag)
            {
                inputManager.rollFlag = false;
            }
        }*/
    }

    private void FixedUpdate()
    {
        playerMovement.HandleAllMovement();
    }
}
