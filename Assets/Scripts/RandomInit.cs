using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInit : MonoBehaviour
{
    public Vector3 FieldSize, FieldOffset;
    public float maxForce, maxTorque;
    public float minForce, minTorque;
    public int noOfAsteroids;
    void Start()
    {
        var pool = ObjectPoolManager.GetManager().GetPool("Asteroid Pool");
        for (int i = 0; i < noOfAsteroids; i++)
        {
            var asteroid = pool.GetObject();
            asteroid.transform.position = new Vector3(Random.Range(-FieldSize.x, FieldSize.x), Random.Range(-FieldSize.y, FieldSize.y), Random.Range(-FieldSize.z, FieldSize.z));
            asteroid.transform.position += FieldOffset;
            var body = asteroid.GetComponent<Rigidbody>();
            body.AddForce(Random.insideUnitSphere * Random.Range(minForce, maxForce), ForceMode.Impulse);
            body.AddTorque(Random.insideUnitSphere * Random.Range(minTorque, maxTorque), ForceMode.Impulse);
            //body.Sleep();
        }
        
    }

}
