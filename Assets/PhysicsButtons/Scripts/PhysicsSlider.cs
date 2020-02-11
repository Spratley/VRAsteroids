using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PhysicsSlider : PhysicsDevice
{
    [Space]
    public GameObject handle;
    
    public float range;

    public override void UpdateValue()
    {
        base.UpdateValue();

        value = (handle.transform.localPosition.z / range + 1) / 2;
    }

    private void Start()
    {
        Reposition();
        UpdateLimit();
    }

    private void OnValidate()
    {
        UpdateLimit();
    }

    private void Reposition()
    {
        var localPos = handle.transform.localPosition;
        float newZ = (value * 2) - 1;
        localPos.z = newZ * range;
        
        handle.transform.localPosition = localPos;
    }

    private void UpdateLimit()
    {
        ConfigurableJoint outJoint;
        if (handle.TryGetComponent(out outJoint))
        {
            SoftJointLimit limit = outJoint.linearLimit;
            limit.limit = range;
            outJoint.linearLimit = limit;
        }
    }

    public override void SetValue(float newValue)
    {
        base.SetValue(newValue);
        Reposition();
    }

    private void OnDrawGizmosSelected()
    {
        var l_start = transform.position - transform.forward * range;
        var start = l_start + transform.up * handle.transform.localPosition.y;
        var l_end = transform.position + transform.forward * range;
        var end = l_end + transform.up * handle.transform.localPosition.y;

        Gizmos.DrawLine(start, end);
        Gizmos.DrawLine(start, l_start);
        Gizmos.DrawLine(end, l_end);

    }
}