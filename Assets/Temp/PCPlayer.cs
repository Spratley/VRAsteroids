using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCPlayer : MonoBehaviour
{
    public float rotSpeed;
    public float force;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        transform.Rotate(-Vector3.up * Input.GetAxis("Mouse X") * rotSpeed, Space.World);
        transform.Rotate(Vector3.right * Input.GetAxis("Mouse Y") * rotSpeed, Space.Self);

        if(Input.GetMouseButton(0)) {
            RaycastHit hit;
        
            if(Physics.Raycast(transform.position, transform.forward, out hit)) {
                if(hit.rigidbody != null) {
                    hit.rigidbody.AddForce(transform.forward * force);
                }
            }
        }
        else if (Input.GetMouseButton(1)) {
            RaycastHit hit;
            int mask = LayerMask.GetMask("In Ship");
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, mask)) {
                if (hit.rigidbody != null) {
                    hit.rigidbody.AddForce(-transform.forward * force);
                }
            }
        }

        //if(Input.GetMouseButtonDown(0))
        //{
        //    GameObject jef = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //    jef.transform.localScale = Vector3.one * 0.15f;
        //    jef.transform.position = transform.position;
        //    Rigidbody reb = jef.AddComponent<Rigidbody>();
        //
        //    reb.AddForce(transform.forward * force);
        //}
    }
}
