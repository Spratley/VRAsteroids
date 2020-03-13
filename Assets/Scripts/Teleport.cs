using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    bool justTeleported = false;

    private void OnTriggerEnter(Collider other)
    {
        if (justTeleported) {
            justTeleported = !justTeleported;
            //return;
        }

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
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    justTeleported = false;
    //}
}
