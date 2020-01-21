using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public static int points;
    public Vector3 bounds;
    public GameObject particle;

    private void Start()
    {
        points = 0;
        Reposition(false);
    }

    public void Reposition(bool shatter = true)
    {
        if(shatter)
        {
            SpawnChunks();
        }

        transform.position = new Vector3(PMRand(bounds.x), PMRand(bounds.y), PMRand(bounds.z));
        transform.rotation = Quaternion.Euler(new Vector3(0, PMRand(180.0f), 0));
    }

    float PMRand(float size)
    {
        return Random.Range(-size, size);
    }

    void SpawnChunks()
    {
        GameObject go = Instantiate(particle);
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
        Destroy(go, 4.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Reposition();
        points++;
    }
}
