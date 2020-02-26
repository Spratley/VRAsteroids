using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var body = GetComponent<Rigidbody>();
        if (other.name == "Bottom" && body.velocity.y < 0.0f || other.name == "Top" && body.velocity.y > 0.0f)
        {
            var pos = body.position;
            Debug.Log("Y: " + pos.y);
            pos.y = -0.90f * pos.y;
            body.position = pos;
            //transform.Translate(0.0f, -1.5f * other.transform.position.y, 0.0f);
        }
        if (other.name == "Left" && body.velocity.x < 0.0f || other.name == "Right" && body.velocity.x > 0.0f)
        {
            var pos = body.position;
            Debug.Log("X: " + pos.x);
            pos.x = -0.90f * pos.x;
            body.position = pos;
            //transform.Translate(-1.5f * other.transform.position.x, 0.0f, 0.0f);
        }
        if (other.name == "Front" && body.velocity.z < 0.0f || other.name == "Back" && body.velocity.z > 0.0f)
        {
            var pos = body.position;
            Debug.Log("Z: " + pos.z);
            pos.z = -0.90f * pos.z;
            body.position = pos;
            //transform.Translate(0.0f, 0.0f, -1.5f * other.transform.position.z);
        }

        /*
        if (other.name == "Bottom" || other.name == "Top")
        {
            var pos = transform.position;
            pos.y = -pos.y * 0.99f;
            transform.position = pos;

            //this.transform.Translate(0.0f, -(other.gameObject.transform.position.y * 2.0f - 2.0f * this.transform.localScale.y) - 2.0f * other.bounds.size.y, 0.0f, Space.World);
            justTeleported = true;
        }
        if (other.name == "Left" || other.name == "Right")
        {
            var pos = transform.position;
            pos.x = -pos.x * 0.99f;
            transform.position = pos;
            //this.transform.Translate(-(other.gameObject.transform.position.x * 2.0f - 2.0f * this.transform.localScale.x) - 2.0f * other.bounds.size.x, 0.0f, 0.0f, Space.World);
            justTeleported = true;
        }
        if (other.name == "Front" || other.name == "Back")
        {
            var pos = transform.position;
            pos.z = -pos.z * 0.99f;
            transform.position = pos;
            //this.transform.Translate(0.0f, 0.0f, -(other.gameObject.transform.position.z * 2.0f - 2.0f * this.transform.localScale.z) - 2.0f * other.bounds.size.z, Space.World);
            justTeleported = true;
        }
        */
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    justTeleported = false;
    //}
}
