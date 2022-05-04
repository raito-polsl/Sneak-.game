using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform groundCheck;
    public Crouch c;

    public float speed = 9f;

    public float gravity = -20f;

    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isDashing;

    private int dashAttempts;
    private float dashStartTime;


    public float sound = 0f;

    private float standingSound = 0.25f;
    private float standingCrouchSound = 0.1f;
    private float movingSound = 0.75f;
    private float crouchingSound = 0.5f;
    private float jumpingSound = 1.0f;


    Vector3 velocity;
    public Vector3 move;

    bool isGrounded;

    [SerializeField] ParticleSystem DashPs;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -1f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        
        velocity.y += gravity* Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetKeyDown(KeyCode.E)) {                     
                controller.Move(controller.transform.forward * 30f * Time.deltaTime);          
        }
        HandleDash();
        if (move.x != 0 || move.z != 0)
        {
            if (isGrounded && !c.isCrouching)
            {
                sound = movingSound;
            }
            else if (!isGrounded)
            {
                sound = jumpingSound;
            }
            else if (c.isCrouching) {
                sound = crouchingSound;
            }
        }
        else {
            if (!isGrounded)
            {
                sound = jumpingSound;
            }
            else if (c.isCrouching)
            {
                sound = standingCrouchSound;
            }
            else {
                sound = standingSound;
            }
        }
    }
    void HandleDash() {
        bool isTryingToDash = Input.GetKeyDown(KeyCode.E);
        if (isTryingToDash && !isDashing) {
            if (dashAttempts <= 50)
            {
                DashPs.Play();
                OnStartDash();
            }

        }
        if (isDashing) { 
            if (Time.time - dashStartTime <= 0.4f)
            {
                controller.Move(controller.transform.forward * 30f * Time.deltaTime);
                
            }
            else
            {
                OnEndDash();
            }
        }
        
    }
    void OnStartDash() {
        isDashing = true;
        dashStartTime = Time.time;
        dashAttempts += 1;
    }

    void OnEndDash() { 
        isDashing = false;
        dashStartTime = 0;

    }
}
