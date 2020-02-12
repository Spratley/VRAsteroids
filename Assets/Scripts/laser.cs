using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class laser : MonoBehaviour
{
    public float distance = 400;
    public Rigidbody rb;
    public Vector3 LaserOrigin;

    public float speed;
    
    void Update()
    {
        rb.AddRelativeForce(Vector3.forward * speed);

        if ((LaserOrigin - transform.position).sqrMagnitude >= distance)
        {
            ObjectPoolManager.GetManager().GetPool("Laser Pool").PoolObject(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var lasers = collision.gameObject.GetComponents<MonoBehaviour>().Where(script => script.GetType().GetInterface("breakable") != null);
        Debug.Log(lasers.Count());

        if (lasers.Count() > 0)
        {
            foreach (breakable item in lasers)
            {
                ObjectPoolManager.GetManager().GetPool("Laser Pool").PoolObject(this.gameObject);
                item.TakeDamage();
                
            }
        }
    }

}
