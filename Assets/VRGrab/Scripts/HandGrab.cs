using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody))]
public class HandGrab : MonoBehaviour
{
    public IGrabbable grabbed;

    public GetObjectsInTrigger trigger;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void TryGrab()
    {
        if(grabbed == null && trigger.objectsInTrigger.Count > 0) {
            IGrabbable tryGrab = null;

            foreach (var item in trigger.objectsInTrigger) {
                var monobehaviours = item.GetComponents<MonoBehaviour>().OfType<IGrabbable>().ToList();
                if (monobehaviours.Count > 0) {
                    tryGrab = monobehaviours[0];
                    break;
                }
            }

            if(tryGrab != null) {
                grabbed = tryGrab;
                grabbed.Grab(rb);
            }
        }
    }

    public void TryInteract()
    {
        if (grabbed != null)
            grabbed.Interact();
    }

    public void TryRelease()
    {
        if (grabbed != null)
        {
            grabbed.Release(rb);
            grabbed = null;
        }
    }
}
