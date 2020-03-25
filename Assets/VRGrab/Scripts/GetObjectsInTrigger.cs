using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjectsInTrigger : MonoBehaviour
{
    public List<GameObject> objectsInTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (!objectsInTrigger.Contains(other.gameObject))
            objectsInTrigger.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectsInTrigger.Contains(other.gameObject))
            objectsInTrigger.Remove(other.gameObject);
    }
}
