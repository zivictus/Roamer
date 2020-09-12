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

    private float _rotationX;
    private float _rotationY;

    MouseLook()
    {
        _rotationX = 0;
        _rotationY = 0;

        Axes = RotationAxes.MouseX;
        Sensitivity = 5.0f;
        MaxVertical = 45f;
        MinVertical = -MaxVertical;
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
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * Sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, MinVertical, MaxVertical);

            _rotationY += Input.GetAxis("Mouse X") * Sensitivity;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }
}
