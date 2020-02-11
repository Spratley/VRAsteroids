using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsButton : PhysicsDevice
{
    [Space]
    public bool sendAsBool;
    [Tooltip("When sending as a boolean, how much space (0-1) should the button be allowed to send, offset from absolutely pressed")]
    public float sensitivity;

    public GameObject button;
    public Rigidbody buttonBody;

    public float range;
    public float heightOffset;

    public float springForce;

    public override void UpdateValue()
    {
        base.UpdateValue();
        value = (Mathf.Clamp((button.transform.localPosition.y - heightOffset) / range, 0, 1));
    }

    private void FixedUpdate()
    {
        buttonBody.AddRelativeForce(Vector3.forward * springForce);
    }

    public override void Update()
    {
        if (sendAsBool) {
            UpdateValue();

            var val = Mathf.Clamp(1 - Mathf.Floor(value / sensitivity), 0, 1);
            var prevVal = Mathf.Clamp(1 - Mathf.Floor(prevValue / sensitivity), 0, 1);

            if (val > 0 && (int)val != (int)prevVal) {
                SendData(val);
            }
            
            return;
        }

        base.Update();
    }

    private void Start()
    {
        Reposition();
    }

    private void OnValidate()
    {
        Reposition();
    }

    private void Reposition()
    {
        button.transform.localPosition = Vector3.up * (heightOffset + range / 2);

        UpdateLimit();
    }

    private void UpdateLimit()
    {
       ConfigurableJoint outJoint;
       if (button.TryGetComponent(out outJoint))
       {
           SoftJointLimit limit = outJoint.linearLimit;
           limit.limit = range/2;
           outJoint.linearLimit = limit;
       }
    }

    private void OnDrawGizmosSelected()
    {
        var start = transform.up * heightOffset + transform.position;
        var end = transform.up * (heightOffset + range) + transform.position;

        Gizmos.DrawLine(start, end);
    }
}
