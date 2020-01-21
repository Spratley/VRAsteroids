using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAtDistance : MonoBehaviour
{
    public float distance;

    private void Update()
    {
        if (transform.position.sqrMagnitude >= distance * distance)
            Destroy(gameObject);
    }
}
