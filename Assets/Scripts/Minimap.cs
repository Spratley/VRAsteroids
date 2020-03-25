using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    //public RectTransform playerIndicator;

    //TODO: Make it scale with worldsize. ATM it's just coincedentally both 50x50

    //private void Update()
    //{
    //    playerIndicator.transform.localPosition = new Vector3(transform.position.x - 50, transform.position.z + 50, 0);
    //
    //    var shipForward = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
    //    var angle = Vector3.SignedAngle(Vector3.forward, shipForward, Vector3.up);
    //
    //    playerIndicator.transform.rotation = Quaternion.Euler(Vector3.forward * (-angle + 180));
    //}

    public void Update()
    {
        //var asteroids = ObjectPoolManager.GetManager().GetPool("Mini-Asteroid Pool");
    }
}
