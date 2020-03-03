using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour, breakable
{

  
    public float minScale = 0.25f;
   
    public void TakeDamage (ScoreManager score) 
    {
        score.AddScore((int)(10 / transform.localScale.x));
        var pool = ObjectPoolManager.GetManager().GetPool("Asteroid Pool");

        if (transform.localScale.x < minScale)
        {
            pool.PoolObject(gameObject);
        }
        else
        {
            transform.localScale /= 2;
            
            var obj = pool.GetObject();
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
