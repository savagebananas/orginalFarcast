using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator playerHead;
    public Animator playerBody;
    public Animator playerLegs;

    public Rigidbody2D playerRb;
    public CursorControls playerInput;
    public ParticleSystem runningDust;

    public float moveSpeed;
    private bool FacingRight = true;

    private void Awake()
    {
        playerInput = new CursorControls();
    }

    void FixedUpdate()
    {
        Vector2 moveInput = playerInput.Movement.move.ReadValue<Vector2>();
        playerRb.velocity = moveInput * moveSpeed * Time.fixedDeltaTime; //Vector "movement" is assigned to player's rb velocity to determine direction and distance


        //Moving and Idle Animation Calling (using animator)
        if (Mathf.Abs(playerRb.velocity.magnitude) >= 0.1) 
        {
            playerLegs.SetBool("isMoving", true);
            createDust();
        }
        if (Mathf.Abs(playerRb.velocity.magnitude) < 0.1) 
        {
            playerLegs.SetBool("isMoving", false);
        }
    }

    void Update()
    {
        //flip to direction of cursor
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (mousePos.x < transform.position.x && FacingRight){Flip();}
        if (mousePos.x > transform.position.x && !FacingRight){Flip();}
    }

    void Flip()
    {
        Vector3 tmpScale = transform.localScale;
        tmpScale.x = -tmpScale.x;
        transform.localScale = tmpScale;
        FacingRight = !FacingRight;
    }

    void createDust()
    {
        runningDust.Play();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}
