using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootfrom : MonoBehaviour
{
    public void Fire(ScoreManager player)
    { 
        {
            var laser = ObjectPoolManager.GetManager().GetPool("Laser Pool").GetObject();
            laser.GetComponent<laser>().player = player;
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            Rigidbody rb = laser.GetComponent<Rigidbody>();
            rb.Sleep();
            rb.AddForce(this.transform.forward * 10, ForceMode.Impulse);
        }
    }
}
