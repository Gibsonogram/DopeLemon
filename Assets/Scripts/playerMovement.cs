using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float footstepSpd = 0.5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;
    private bool playingFootsteps = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // The following is a non-state machine solution for pause. 
        // I would probably make PAUSE a state in the future...
        if (PauseController.isPaused)
        {
            rb.linearVelocity = Vector2.zero;
            anim.SetBool("IsWalking", false);
            StopFootsteps();
            return;
        }
        rb.linearVelocity = moveInput * moveSpeed;
        anim.SetBool("IsWalking", rb.linearVelocity.magnitude > 0);

        if (rb.linearVelocity.magnitude > 0 && !playingFootsteps)
        {
            StartFootsteps();
        }
        else if (rb.linearVelocity.magnitude == 0)
        {
            StopFootsteps();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {

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

    void StartFootsteps()
    {
        playingFootsteps = true;
        InvokeRepeating(nameof(PlayFootstep), 0f, footstepSpd); // nameof() must take fxn...
    }

    void StopFootsteps()
    {
        playingFootsteps = false;
        CancelInvoke(nameof(PlayFootstep));
    }


    void PlayFootstep()
    {
        SoundEffectManager.Play("Footsteps", true);
    }

}

