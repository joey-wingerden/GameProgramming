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
        rb.gravityScale = 0f;
        rb.velocity = new Vector3(0, -5, 0);
        //rb.simulated = false;

    }

    public void Update()
    {
        //check if is on the ground or not
        if (!isGrounded && rb.simulated)
        {
            TetrisMovement();
            RotatePrefab();
        }
    }

     private void TetrisMovement()
    {
        
        //Check for input to move the spawned prefab
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MovePrefab(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MovePrefab(Vector3.right );
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MovePrefab(Vector3.down);
            
        }
        if(!isGrounded)
        {
            
            //MovePrefab(Vector3.down);
            
        
        }
        
         // Check for user input to rotate the object
        
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
            
            // Move the spawned prefab in the specified direction
            // Rotate the prefab based on user input
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("rotate");
                transform.Rotate(Vector3.forward * 90);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                transform.Rotate(Vector3.back * 90);
            }
    }

    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isGrounded)
        {
            //rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0.5f;
            rb.simulated = true;
            //Debug.Log("LOg");
            
        }
        isGrounded = true;
    }

    public bool GetBelow(float below)
    {
        return rb.position.y < below;
    }
    public float GetCamaraheigt()
    {
        if(isGrounded)
        {
            return rb.position.y;
        }
        return 0;
    }
    public float Getheigt()
    {
        return rb.position.y;      
    }
    public void simulated(bool onoff)
    {
        rb.simulated = onoff;
    }


   
}
