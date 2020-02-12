using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositions : MonoBehaviour
{
    public Vector3 FieldSize;
    public Vector3 FieldOffset;
    public int noOfAsteroids;
    void Start()
    {
        var pool = ObjectPoolManager.GetManager().GetPool("Asteroid Pool");
        for (int i = 0; i < noOfAsteroids; i++)
        {
           var asteroid = pool.GetObject();
           asteroid.transform.position = new Vector3(Random.Range(-FieldSize.x, FieldSize.x), Random.Range(-FieldSize.y, FieldSize.y), Random.Range(-FieldSize.z, FieldSize.z));
           asteroid.transform.position += FieldOffset;
           asteroid.GetComponent<Rigidbody>().Sleep();
        }
        
    }

}
