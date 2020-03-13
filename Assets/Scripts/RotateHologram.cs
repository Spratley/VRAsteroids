using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHologram : MonoBehaviour
{
    public float offset = 0.0f;
    public float frequency = 0.01f;
    public float amplitude = 0.5f;

    // Update is called once per frame
    void Update()
    {
        var pos = transform.localPosition;
        transform.Rotate(0, 0.1f, 0);
        pos.y = Mathf.Sin(Time.time * frequency)*amplitude + offset;
        transform.localPosition = pos;
    }
}
