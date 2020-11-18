using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 2f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 2f;
    CharacterController controller;
    Camera mainCamera;
    float currentTilt = 0f;
    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        mainCamera = transform.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        Aim();
        Movement();
    }

    /* 
    Movement() and Aim() code provided by
    Brackeys https://www.youtube.com/watch?v=_QajrabyTJc&ab_channel=Brackeys
    */

    // Position camera relative to mouse movements
    void Aim() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX);

        currentTilt -= mouseY;
        currentTilt = Mathf.Clamp(currentTilt, -90f, 90f);
        mainCamera.transform.localEulerAngles = new Vector3(currentTilt, 0, 0);
    }

    // Position player model relative to inputs
    void Movement() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        float lateralMove = Input.GetAxisRaw("Horizontal");
        float forwardMove = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * lateralMove + transform.forward * forwardMove;
        // move = Vector3.Normalize(move) * moveSpeed * Time.deltaTime;
        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
