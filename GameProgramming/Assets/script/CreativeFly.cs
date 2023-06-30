using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeFly : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeedMultiplier = 1.5f;
    public float jumpForce = 5f;
    public float mouseSensitivity = 2f;

    private Rigidbody rb;
    private bool isGrounded;
    private float rotationX = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Read player input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool isJumping = Input.GetKeyDown(KeyCode.Space);
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calculate movement direction relative to the camera's forward direction
        Vector3 movement = (moveHorizontal * Camera.main.transform.right + moveVertical * Camera.main.transform.forward).normalized;

        // Apply movement speed based on running
        float currentMoveSpeed = isRunning ? moveSpeed * runSpeedMultiplier : moveSpeed;
        Vector3 moveVelocity = movement * currentMoveSpeed;

        // Apply movement to the rigidbody
        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);

        // Rotate player with the mouse
        float rotationY = mouseX * mouseSensitivity;
        transform.Rotate(Vector3.up * rotationY);

        // Rotate camera vertically with the mouse
        rotationX -= mouseY * mouseSensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Jumping
        if (isJumping && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}