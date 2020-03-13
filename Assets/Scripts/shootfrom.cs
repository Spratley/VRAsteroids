using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootfrom : MonoBehaviour
{
    // Start is called before the first frame update
public void Fire(scoreManager player)
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
