using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _mouseSensitivity = 10f;
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] Camera _camera;
    float _currentTilt = 0f;

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        Aim();
        Movement();
    }

    // Position camera relative to mouse movements
    void Aim() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * _mouseSensitivity);

        _currentTilt -= mouseY * _mouseSensitivity;
        _currentTilt = Mathf.Clamp(_currentTilt, -90, 90);
        _camera.transform.localEulerAngles = new Vector3(_currentTilt, 0, 0);
    }

    // Position player model relative to inputs
    void Movement() {
        Vector3 lateralMove = transform.right * Input.GetAxis("Horizontal");
        Vector3 forwardMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 move = lateralMove + forwardMove;
        GetComponent<CharacterController>().Move(move * _moveSpeed * Time.deltaTime);
    }
}
