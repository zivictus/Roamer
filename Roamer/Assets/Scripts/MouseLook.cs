using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes Axes;
    public float Sensitivity;
    public float MaxVertical;
    public float MinVertical;

    public float MaxZRotation;
    public float MinZRotation;

    private float _rotationX;
    private float _rotationY;
    private float _rotationRightZ;
    private float _rotationLeftZ;
    private float _rotationZ;

    private float cornerLook;
    private float lookAroundLeft;
    private float lookAroundRight;
    private Vector3 lookAround;

    MouseLook()
    {
        _rotationX = 0;
        _rotationY = 0;
        _rotationRightZ = 0;
        _rotationLeftZ = 0;
        _rotationLeftZ = 0;

        cornerLook = 2f;

        Axes = RotationAxes.MouseX;
        Sensitivity = 5.0f;
        MaxVertical = 45f;
        MinVertical = -MaxVertical;
        MaxZRotation = 15;
        MinZRotation = 0;
    }

    void Update()
    {
        if (Axes == RotationAxes.MouseX)
        {
            _rotationY += Input.GetAxis("Mouse X") * Sensitivity;
            transform.localEulerAngles = new Vector3(0, _rotationY, 0);
        }
        else if (Axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * Sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, MinVertical, MaxVertical);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, LookAroundCorner());
            transform.localPosition = new Vector3(-LookAroundCorner()*0.1f, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * Sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, MinVertical, MaxVertical);

            _rotationY += Input.GetAxis("Mouse X") * Sensitivity;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, _rotationZ);
            transform.localPosition = new Vector3(0, 0, _rotationZ);
        }
    }

    public float LookAroundCorner()
    {
        _rotationRightZ += Input.GetKey(KeyCode.Q) ? cornerLook : -cornerLook;
        _rotationRightZ = Mathf.Clamp(_rotationRightZ, MinZRotation, MaxZRotation);

        _rotationLeftZ += Input.GetKey(KeyCode.E) ? -cornerLook : cornerLook;
        _rotationLeftZ = Mathf.Clamp(_rotationLeftZ, -MaxZRotation, MinZRotation);

        return _rotationLeftZ + _rotationRightZ;
    }
}
