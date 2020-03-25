using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Impulse : MonoBehaviour
{

    public UnityEvent impulse;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            impulse.Invoke();
        }
    }
}
