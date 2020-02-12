using UnityEngine;
using System.Collections.Generic;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class SpaceShip : MonoBehaviour
{
    private Rigidbody rb;

    private Camera mainCam;
    public Vector3 camOffset;

    public float thrust;
    public float turnRate;
    public float pitchRate;
    public float spinRate;


    public List<Transform> bulletBarrels;
    public GameObject bulletPrefab;

	private void Start()
    {
        rb = GetComponent<Rigidbody>();

        mainCam = Camera.main;
    }

    private void Update()
    {
        Turn(Input.GetAxis("Horizontal") * turnRate, Vector3.up);
        Turn(Input.GetAxis("Vertical") * pitchRate, Vector3.right);
        Turn(Input.GetAxis("Roll") * spinRate, Vector3.forward);
        //Boost(transform.forward * Input.GetAxis("Jump"));
    }
    
    public void Turn(float rate, Vector3 relativeAxis)
    {
        rb.AddRelativeTorque(relativeAxis * rate);
    }

    public void BoostForward(float amount)
    {
        Boost(transform.forward * amount);
    }

    public void Boost(Vector3 direction)
    {
        rb.AddForce(direction * thrust);
    }

    public void Fire()
    {
        foreach(Transform b in bulletBarrels)
        {
            CreateBullet(b);
        }
    }

    public GameObject CreateBullet(Transform spawnTransform)
    {
        //GameObject bullet = Instantiate(bulletPrefab);
        //bullet.transform.position = spawnTransform.position;
        //bullet.transform.rotation = spawnTransform.rotation;
        
        return null;
    }
}
