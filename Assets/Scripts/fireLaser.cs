﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class fireLaser : MonoBehaviour
{
    public UnityEvent fire;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fire.Invoke();
        }
        
    }
}
