using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

[SelectionBase]
public class PhysicsSwitch : PhysicsDevice
{
    [Space]
    public GameObject handle;
    public HingeJoint handleJoint;

    public float range;

    public float gizmoRadius;

    public float angleToCenter = 270;
    private float angleOffset;

    private void Start()
    {
        UpdateLimit();
    }

    private void OnValidate()
    {
        UpdateLimit();
        handle.transform.localEulerAngles = Vector3.right * angleToCenter;
    }

    private void UpdateLimit()
    {
        // Update the angle so that the value is true
        float newAngle = angleToCenter + ((value - 0.5f) * range);
        handle.transform.localEulerAngles = Vector3.right * newAngle;

        JointLimits limit = handleJoint.limits;
        limit.max = range / 2;
        limit.min = -limit.max;
        handleJoint.limits = limit;
    }

    public override void UpdateValue()
    {
        base.UpdateValue();

        var rotation = handleJoint.angle;

        value = (rotation / range) + 0.5f;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Handles.color = new Color(1, 1, 1, 0.1f);

    //    Handles.DrawSolidArc(handle.transform.position, transform.right, transform.up, range / 2, gizmoRadius);
    //    Handles.DrawSolidArc(handle.transform.position, transform.right, transform.up, -range / 2, gizmoRadius);

    //    Handles.color = new Color(1, 1, 1, 1);

    //    Handles.DrawWireArc(handle.transform.position, transform.right, transform.up, range / 2, gizmoRadius);
    //    Handles.DrawWireArc(handle.transform.position, transform.right, transform.up, -range / 2, gizmoRadius);
    //}
}