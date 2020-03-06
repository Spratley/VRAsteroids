using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum JoystickAxis { X, Y }

public class PhysicsJoystick : PhysicsDevice
{
    [Space]
    public GameObject handle;

    public JoystickAxis axis;

    public float angleLimit;

    private float initialOffset;

    private void Start()
    {
        switch (axis)
        {
            default:
            case JoystickAxis.X:
                initialOffset = handle.transform.localEulerAngles.x;
                break;
            case JoystickAxis.Y:
                initialOffset = handle.transform.localEulerAngles.z;
                break;
        }
    }

    public override void UpdateValue()
    {
        base.UpdateValue();

        float val;
        Vector3 direction = handle.transform.forward;

        switch (axis)
        {
            default:
            case JoystickAxis.X:
                direction -= Vector3.Dot(direction, transform.right) * transform.right;
                val = Mathf.Sign(Vector3.Dot(direction, transform.forward));
                break;
            case JoystickAxis.Y:
                direction -= Vector3.Dot(direction, transform.forward) * transform.forward;
                val = Mathf.Sign(Vector3.Dot(direction, transform.right));
                break;
        }

        val *= Vector3.Angle(transform.up, direction);
        val /= angleLimit;
        val /= 2;
        val += 0.5f;
        
        value = val;
    }
}
