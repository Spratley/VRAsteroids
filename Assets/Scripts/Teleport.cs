using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject miniature;
    public float minimapScale;
    private GameObject mini;
    private void OnTriggerEnter(Collider other)
    {
        var body = GetComponent<Rigidbody>();
        if (other.name == "Bottom" && body.velocity.y < 0.0f || other.name == "Top" && body.velocity.y > 0.0f)
        {
            var pos = body.position;
            //Debug.Log("Y: " + pos.y);
            pos.y = -0.90f * pos.y;
            body.position = pos;
            //transform.Translate(0.0f, -1.5f * other.transform.position.y, 0.0f);
        }
        if (other.name == "Left" && body.velocity.x < 0.0f || other.name == "Right" && body.velocity.x > 0.0f)
        {
            var pos = body.position;
            //Debug.Log("X: " + pos.x);
            pos.x = -0.90f * pos.x;
            body.position = pos;
            //transform.Translate(-1.5f * other.transform.position.x, 0.0f, 0.0f);
        }
        if (other.name == "Front" && body.velocity.z < 0.0f || other.name == "Back" && body.velocity.z > 0.0f)
        {
            var pos = body.position;
            //Debug.Log("Z: " + pos.z);
            pos.z = -0.90f * pos.z;
            body.position = pos;
            //transform.Translate(0.0f, 0.0f, -1.5f * other.transform.position.z);
        }
    }

    public void Start()
    {
        var minimap = GameObject.Find("Minimap").transform;
        if (miniature)
            mini = Instantiate(miniature, minimap);
        else
        {
            mini = ObjectPoolManager.GetManager().GetPool("Miniature Pool").GetObject();
            mini.transform.SetParent(minimap);
        }
    }
    public void Update()
    {
        mini.transform.localPosition = transform.localPosition / minimapScale;
        mini.transform.localRotation = transform.localRotation;
        mini.transform.localScale = transform.localScale / minimapScale * 20.0f;
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    justTeleported = false;
    //}
}
