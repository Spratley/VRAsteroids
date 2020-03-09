using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class SimpleGrabbable : MonoBehaviour, IGrabbable
{
    List<FixedJoint> grabbedPoints = new List<FixedJoint>();
    float breakForce = Mathf.Infinity;

    public UnityEvent interactEvent;

    public void Grab(Rigidbody hand)
    {
        var joints = GetGrabbing(hand);
        if (joints.Count < 1)
            AddFixedJoint(hand);
    }

    public void Interact()
    {
        interactEvent.Invoke();
    }

    public void Release(Rigidbody hand)
    {
        var joints = GetGrabbing(hand);
        if(joints.Count > 0)
        {
            foreach(FixedJoint j in joints)
            {
                grabbedPoints.Remove(j);
                Destroy(j);
            }
        }
    }

    private FixedJoint AddFixedJoint(Rigidbody attached)
    {
        var fj = gameObject.AddComponent<FixedJoint>();
        fj.connectedBody = attached;
        fj.breakForce = breakForce;

        grabbedPoints.Add(fj);
        return fj;
    }

    private List<FixedJoint> GetGrabbing(Rigidbody query)
    {
        return grabbedPoints.Where(joint => joint.connectedBody == query).ToList();
    }
}
