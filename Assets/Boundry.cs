using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Boundry : MonoBehaviour
{
    public Vector3 limit;

    public GameObject bottom, top;
    public GameObject left, right;
    public GameObject front, back;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bottom.transform.position = new Vector3(0.0f, -limit.y, 0.0f);
        top.transform.position = new Vector3(0.0f, limit.y, 0.0f);
        left.transform.position = new Vector3(-limit.x, 0.0f, 0.0f);
        right.transform.position = new Vector3(limit.x, 0.0f, 0.0f);
        front.transform.position = new Vector3(0.0f, 0.0f, -limit.z);
        back.transform.position = new Vector3(0.0f, 0.0f, limit.z);
        
        bottom.transform.localScale = new Vector3(limit.x * 2.1f, limit.y / 10.0f, limit.z * 2.1f);
        top.transform.localScale = new Vector3(limit.x * 2.1f, limit.y / 10.0f, limit.z * 2.1f);
        left.transform.localScale = new Vector3(limit.x / 10.0f, limit.y * 2.1f, limit.z * 2.1f);
        right.transform.localScale = new Vector3(limit.x / 10.0f, limit.y * 2.1f, limit.z * 2.1f);
        front.transform.localScale = new Vector3(limit.x * 2.1f, limit.y * 2.1f, limit.z / 10.0f);
        back.transform.localScale = new Vector3(limit.x * 2.1f, limit.y * 2.1f, limit.z / 10.0f);
    }
}
