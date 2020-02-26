using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JoystickAxis { X, Y }

public class PhysicsJoystick : PhysicsDevice
{
    [Space]
    public GameObject handle;

    public JoystickAxis axis;

    public override void UpdateValue()
    {
        base.UpdateValue();

        float val;
        switch(axis)
        {
            default:
            case JoystickAxis.X:
                val = handle.transform.localRotation.x;
                break;
            case JoystickAxis.Y:
                val = handle.transform.localRotation.z;
                break;
        }

        value = val;
    }
}
