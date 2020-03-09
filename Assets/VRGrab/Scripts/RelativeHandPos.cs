using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RelativeHandPos : MonoBehaviour
{
    private GameObject handPosAbs;
    private Rigidbody rb;

    public float maxDistanceDelta;

    public ConfigurableJoint cj;
    public float rotationDrive;

    private void Start()
    {
        handPosAbs = transform.parent.gameObject;
        rb = GetComponent<Rigidbody>();
    }
    

    private void FixedUpdate()
    {
        //POSITION
        
        // Project the object into the future to compensate for any current forces
        Vector3 velocity = rb.velocity;
        Vector3 projectedPos = transform.position + velocity * Time.fixedDeltaTime;

        var dir = Vector3.ClampMagnitude(handPosAbs.transform.position - projectedPos, maxDistanceDelta);

        Vector3 force = rb.mass * dir / Time.fixedDeltaTime;

        rb.AddForce(force, ForceMode.Impulse);

        //ROTATION

        // Rotation is handled by a configurable joint as it's far easier lol
        cj.targetRotation = Quaternion.Inverse(handPosAbs.transform.rotation);

        var drive = cj.angularXDrive;
        drive.positionSpring = rotationDrive;
        cj.angularXDrive = drive;
        cj.angularYZDrive = drive;
    }
}
