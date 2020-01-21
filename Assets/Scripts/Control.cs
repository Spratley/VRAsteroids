using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //OVRInput.Controller activeController = OVRInput.GetActiveController();
		//
        //Vector2 thumbPos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, activeController);
        //Quaternion rotation = OVRInput.GetLocalControllerRotation(activeController);
		//
        //debugText.text = rotation.ToString();
		//
        //transform.position += new Vector3(thumbPos.x, thumbPos.y) * Time.deltaTime;
        //transform.rotation = rotation;
    }
}
