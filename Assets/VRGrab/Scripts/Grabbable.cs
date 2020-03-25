using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable
{
    void Grab(Rigidbody hand);
    void Interact();
    void Release(Rigidbody hand);
}
