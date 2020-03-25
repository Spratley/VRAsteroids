using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Teleport : MonoBehaviour
{
    static public Boundry s_boundary;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    bool justTeleported = false;

    private bool MovingTowards(GameObject bound)
    {
        Vector3 objVelocity = rb.velocity;
        Vector3 triggerOut = bound.GetComponent<VectorOut>().vectorOut;

        if (Vector3.Dot(triggerOut, objVelocity) > 0)
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (justTeleported)
        {
            justTeleported = !justTeleported;
            //return;
        }

        if (other.name == s_boundary.bottom.name || other.name == s_boundary.top.name)
        {
            if (MovingTowards((s_boundary.bottom.name == other.name) ? s_boundary.bottom : s_boundary.top))
            {
                var pos = transform.position;
                pos.y = -pos.y * 0.99f;
                transform.position = pos;
            }
        }
        if (other.name == s_boundary.left.name || other.name == s_boundary.right.name)
        {
            if (MovingTowards((s_boundary.left.name == other.name) ? s_boundary.left : s_boundary.right))
            {
                var pos = transform.position;
                pos.x = -pos.x * 0.99f;
                transform.position = pos;
            }
        }
        if (other.name == s_boundary.front.name || other.name == s_boundary.back.name)
        {
            if (MovingTowards((s_boundary.front.name == other.name) ? s_boundary.front : s_boundary.back))
            {
                var pos = transform.position;
                pos.z = -pos.z * 0.99f;
                transform.position = pos;
            }
        }
    }
}
