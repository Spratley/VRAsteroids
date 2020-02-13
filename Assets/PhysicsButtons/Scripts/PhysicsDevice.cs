using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[SelectionBase]
[System.Serializable]
public class FloatEvent : UnityEvent<float> {}

public class PhysicsDevice : MonoBehaviour
{
    public bool sendEveryFrame;
    [Tooltip("When true the value will be converted from 0 -> 1 to -1 -> 1, where 0.5 is now 0")]
    public bool sendNegativeToPositive;

    public FloatEvent toCall;

    [Range(0, 1)]
    public float value;
    protected float prevValue;

    public float valueScale;

    public virtual void Update()
    {
        UpdateValue();

        if(sendEveryFrame || value != prevValue)
        {
            SendData(value);
        }
    }

    public virtual void SetValue(float newValue)
    {
        value = newValue;
    }

    public virtual void UpdateValue()
    {
        prevValue = value;
    }

    protected void SendData(float val)
    {
        val = Mathf.Clamp(val, 0, 1);

        if (sendNegativeToPositive)
            val = (val - 0.5f) * 2;

        toCall.Invoke(val * valueScale);
    }
}