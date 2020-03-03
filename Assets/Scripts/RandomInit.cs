using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInit : MonoBehaviour
{
    public Vector3 FieldSize, FieldOffset;
    public float maxForce, maxTorque;
    public float minForce, minTorque;
    public int initAsteroids, deltaAsteroids;
    public int wave;
    public float waveDistance;
    void Start()
    {
        SpawnWave(initAsteroids);
    }

    void Update()
    {
        var pool = ObjectPoolManager.GetManager().GetPool("Asteroid Pool");
        if (pool.Count() <= 0)
        {
            wave += 1;
            SpawnWave(initAsteroids + deltaAsteroids * wave);
        }
    }

    private void SpawnWave(int numOfAsteroids)
    {
        var pool = ObjectPoolManager.GetManager().GetPool("Asteroid Pool");
        var pos = Random.insideUnitSphere * waveDistance;
        for (int i = 0; i < numOfAsteroids; i++)
        {
            var asteroid = pool.GetObject();
            asteroid.transform.position = new Vector3(Random.Range(-FieldSize.x, FieldSize.x), Random.Range(-FieldSize.y, FieldSize.y), Random.Range(-FieldSize.z, FieldSize.z));
            asteroid.transform.position += pos;
            var body = asteroid.GetComponent<Rigidbody>();
            body.velocity = pos * -0.1f;
            body.AddForce(Random.insideUnitSphere * Random.Range(minForce, maxForce), ForceMode.Impulse);
            body.AddTorque(Random.insideUnitSphere * Random.Range(minTorque, maxTorque), ForceMode.Impulse);
        }
    }
}
