﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour, breakable
{


    public float minScale = 0.25f;
   
    public void TakeDamage ()
      
    {
        if (transform.localScale.x<minScale)
        {
            ObjectPoolManager.GetManager().GetPool("Asteroid Pool").PoolObject(gameObject);
            return;
        }
        if (transform.localScale.x >= minScale)
        {
            transform.localScale /= 2;
            var obj = ObjectPoolManager.GetManager().GetPool("Asteroid Pool").GetObject();
            obj.transform.localScale = transform.localScale;
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
        }
    }

    static void Create(Vector3 position, float scale, GameObject asteroid)
    {
        ObjectPoolManager.GetManager().GetPool("Asteroid Pool").GetObject();
    }

}
