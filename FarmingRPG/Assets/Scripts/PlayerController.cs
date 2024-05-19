using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement components
    private CharacterController characterController;
    private Animator animator;
    private float moveSpeed = 4f;

    [Header("Movement System")]

    private float walkSpeed = 4f;
    private float runSpeed = 8f;

    // Interaction components
    PlayerInteraction playerInteraction;

    // Start is called before the first frame update
    void Start()
    {
        // Get movement components
        characterController = GetComponent<CharacterController>(); 
        animator = GetComponent<Animator>();

        // Get interaction components
        playerInteraction = GetComponentInChildren<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        // Run function that handles all movements
        Move();

        // Run function that handles all interactions
        Interact();
    }

    public void Move()
    {
        // Get the horizontal and vertical inputs as a number
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // DIrection in a normalised vector
        Vector3 dir = new Vector3 (horizontal, 0f, vertical).normalized;
        Vector3 velocity = moveSpeed * Time.deltaTime * dir;

        // Check if sprint key is pressed down
        if (Input.GetButton("Sprint"))
        {
            moveSpeed = runSpeed;
            animator.SetBool("Running", true);
        } else
        {
            moveSpeed = walkSpeed;
            animator.SetBool("Running", false);
        }

        // Check if there is movement
        if (dir.magnitude > 0.1f)
        {
            // Look towards that direction
            transform.rotation = Quaternion.LookRotation(dir);

            // Move
            characterController.Move(velocity);
        }

        animator.SetFloat("Speed", velocity.magnitude);
    }

    public void Interact()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerInteraction.Interact();
        }
    }
}
