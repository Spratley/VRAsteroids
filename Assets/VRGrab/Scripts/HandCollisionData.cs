using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionData : MonoBehaviour
{
    public List<GameObject> touchingObjects;

    private void OnCollisionEnter(Collision collision)
    {
        touchingObjects.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        touchingObjects.Remove(collision.gameObject);
    }
}
