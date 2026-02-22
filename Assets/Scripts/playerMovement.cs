using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        anim.SetBool("IsWalking", true);

        // context.canceled happens when button is 'unpressed'/released
        if (context.canceled)
        {
            anim.SetBool("IsWalking", false);
            anim.SetFloat("LastInputX", moveInput.x);
            anim.SetFloat("LastInputY", moveInput.y);
        }


        // must be before the anim.setfloat calls...
        moveInput = context.ReadValue<Vector2>();
        anim.SetFloat("InputX", moveInput.x);
        anim.SetFloat("InputY", moveInput.y);


    }

}

