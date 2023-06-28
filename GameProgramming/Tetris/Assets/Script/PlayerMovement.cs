using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;    // Speed of the player movement
    //public float jumpForce = 5f;    // Force applied when jumping
    private float moveDelay = 0.05f; // Delay between each movement
    private float RotateDelay = 0.1f; // Delay between each movement
    public float rotationSpeed = 100f;
    private float timerMove; // Timer to track the delay
    private float timerRotate; 

    private Rigidbody2D rb;
    public bool isGrounded;
    public bool Tetris;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        //check if is on the ground or not
        if (!isGrounded)
        {
            if(Tetris)
            {
                TetrisMovement();
            }else
            {
                DropMovement();
            }
        }
        
    }

    private void DropMovement()
    {
        // Read input for movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // // Jumping
        // if (Input.GetButtonDown("Jump") && isGrounded)
        // {
        //     rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        //     isGrounded = false;
        // }

        // Move the player
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }
     private void TetrisMovement()
    {
        
        //Check for input to move the spawned prefab
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MovePrefab(Vector3.left / 2 );
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MovePrefab(Vector3.right / 2);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MovePrefab(Vector3.down);
        }

        
         // Check for user input to rotate the object
        RotatePrefab();
    }
    private void MovePrefab(Vector3 direction)
    {
        // Check if enough time has passed since the last movement
        if (Time.time - timerMove >= moveDelay)
        {
            // Move the spawned prefab in the specified direction
            transform.position += direction;

            // Update the timer
            timerMove = Time.time;
        }
    }
    private void RotatePrefab()
    {
        // Check if enough time has passed since the last movement
        
            Debug.Log(transform.rotation.z);
            // Move the spawned prefab in the specified direction
            // Rotate the prefab based on user input
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("rotate");
                transform.Rotate(Vector3.forward * 45);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                transform.Rotate(Vector3.back * 45);
            }

            // Update the timer
         

        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isGrounded)
        {
            //Debug.Log("LOg");
            
        }
        isGrounded = true;
    }

    public bool GetBelow(float below)
    {
        return rb.position.y < below;
    }
    public float Getheigt()
    {
        if(isGrounded)
        {
            return rb.position.y;
        }
        return 0;
    }


   
}
