using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    Rigidbody rb;

    public GameObject eyeCamera;

    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //var activeController = OVRInput.GetActiveController();
		//
        //var direction = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
		//
        //rb.AddForce(new Vector3(direction.x, 0, direction.y));
    }
}
