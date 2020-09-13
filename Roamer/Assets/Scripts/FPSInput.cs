using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float maxCornerLook = 3;
    public float cornerLookSpeed = 1;
    public float jumpHeight = 10;
    public float shiftSpeed = 2;

    private CharacterController _charController;
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        Vector3 jump = new Vector3(0, jumpHeight, 0);

        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;

        jump = transform.TransformDirection(jump);
        movement = transform.TransformDirection(movement);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement.x = movement.x * shiftSpeed;
            movement.z = movement.z * shiftSpeed;
        }

        _charController.Move(movement);

        if (Input.GetButtonDown("Jump"))
            _charController.Move(jump);
    }
}
