using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{
    public GameObject pooledAsteroid;
    public GameObject pooledLaser;
    public int noOfAsteroids = 30;
    public int noOfLasers = 25;

    void Awake()
    {
  
        ObjectPoolManager.GetManager().InitPool("Asteroid Pool", 20, pooledAsteroid);
        ObjectPoolManager.GetManager().InitPool("Laser Pool", noOfLasers, pooledLaser);
    
    }
}
